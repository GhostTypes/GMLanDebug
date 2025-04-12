using System.Linq;

using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GMLanDebug.ui;
using GMLanDebug.util;
using GMLanDebug.util.serial;
using Timer = System.Windows.Forms.Timer;

namespace GMLanDebug
{

    
    public partial class MainWindow : Form
    {
        private int _rawMessageCount;
        private int _maxMessages = 500;


        //private readonly object _filterMsgCountLock = new object();
        private readonly GMLanMessageCache _messageCache; // claude code
        private readonly FilterControlWindow _filterControlWindow;
        private readonly ConcurrentQueue<GMLanMessage> _messageQueue;
        
        public readonly ConcurrentDictionary<string, int> MessageCounts = new ConcurrentDictionary<string, int>();
        
        private readonly Timer _updateStatsTimer;

        private SerialDevice _currentDevice;
        private SerialPortReader _serialReader;
        private List<GMLanMessage> _allMessages = new List<GMLanMessage>();
        private List<GMLanMessage> _filteredMessages = new List<GMLanMessage>();
        private Func<GMLanMessage, bool> _activeFilter = _ => true;

        //private int messageCount;
        private DateTime lastUpdateTime = DateTime.Now;
        private bool isLogging;

        private enum LogState
        {
            Active,
            Paused,
            Stopped
        }

        private LogState _logState = LogState.Stopped;

        public MainWindow()
        {
            InitializeComponent();
            InitLog();
            InitTranslators();

            _filterControlWindow = new FilterControlWindow { Owner = this };
            _messageQueue = new ConcurrentQueue<GMLanMessage>();
            _messageCache = new GMLanMessageCache(); // claude code
            _updateStatsTimer = new Timer { Interval = 100 };

            logList.VirtualMode = true;
            logList.RetrieveVirtualItem += LogList_RetrieveVirtualItem;
            EnableDoubleBuffering(logList);

            _updateStatsTimer.Tick += UpdateStatsTimer_Tick;
            stateLabel.Text = "State: Stopped";
        }

        private static void EnableDoubleBuffering(Control control)
        {
            typeof(ListView).InvokeMember("DoubleBuffered",
                System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.SetProperty,
                null, control, new object[] { true });
        }

        private void InitTranslators()
        {
            HsLan.Init();
            LsLan.Init();
        }

        private void InitLog()
        {
            logList.View = View.Details;
            logList.FullRowSelect = true;
            logList.GridLines = true;
            InitColumns();
        }

        private void InitColumns()
        {
            var columnHeaders = new[] { "ID", "Header", "Sender (Name or ECU)", "Priority", "DLC", "Data" };
            foreach (var header in columnHeaders)
            {
                logList.Columns.Add(header);
            }

            ResizeColumns();
        }

        private void ResetLog()
        {
            _allMessages.Clear();
            _filteredMessages.Clear();
            logList.VirtualListSize = 0;
            logList.Items.Clear();
            ResizeColumns();
        }

        private bool ShouldResizeColumns(GMLanMessage message)
        {
            for (var i = 0; i < logList.Columns.Count; i++)
            {
                var columnText = GetColumnText(message, i);
                if (TextRenderer.MeasureText(columnText, logList.Font).Width > logList.Columns[i].Width)
                {
                    return true;
                }
            }

            return false;
        }

        private string GetColumnText(GMLanMessage message, int columnIndex)
        {
            switch (columnIndex)
            {
                case 0: return message.Id;
                case 1: return message.Header;
                case 2: return message.Sender;
                case 3: return message.Priority;
                case 4: return message.DLC;
                case 5: return message.Data;
                default: return string.Empty;
            }
        }

        private void ResizeColumns()
        {
            //foreach (ColumnHeader column in logList.Columns)
            //{
            //    column.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
            //}
            for (int i = 0; i <= logList.Columns.Count - 1; i++) {
                logList.Columns[i].Width = -2;
            }
        }

        private void AutoScrollToBottom(bool update)
        {
            if (logList.Items.Count == 0 || _logState != LogState.Active) return;
            if (update) logList.BeginUpdate();
            try
            {
                logList.Items[logList.Items.Count - 1].EnsureVisible();
            }
            finally
            {
                if (update) logList.EndUpdate();
            }
        }

        private void ApplyFilter(Func<GMLanMessage, bool> filter)
        {
            logList.BeginUpdate();
            try
            {
                _activeFilter = filter;
                // Apply filter to existing messages without clearing them
                _filteredMessages = _allMessages.Where(filter).ToList();
                logList.VirtualListSize = _filteredMessages.Count;
            }
            finally
            {
                logList.EndUpdate();
            }
        }

        private void LogList_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (e.ItemIndex < 0 || e.ItemIndex >= _filteredMessages.Count)
            {
                var item = new ListViewItem("");
                // also needs empty columns or will crash
                for (int i = 1; i < logList.Columns.Count; i++)
                {
                    item.SubItems.Add("");
                }
                e.Item = item;
                return;
            }

            var message = _filteredMessages[e.ItemIndex];
            e.Item = new GMLanListViewItem(message);
        }

        private void UpdateStatsTimer_Tick(object sender, EventArgs e)
        {
            var timeElapsed = DateTime.Now - lastUpdateTime;
        
            int currentRawCount;

            currentRawCount = _rawMessageCount;
            _rawMessageCount = 0;

            double rawMessagesPerSecond = currentRawCount / timeElapsed.TotalSeconds;
            
            messagesPerSecondLabel.Text = $"Msg/sec: {rawMessagesPerSecond:F2}";
            totalMsgsLabel.Text = $"Total: {_allMessages.Count}";
            filteredMsgsLabel.Text = $"Filtered: {_filteredMessages.Count}";

            // Update logList in the same timer tick
            logList.BeginInvoke(new Action(UpdateLogList));

            lastUpdateTime = DateTime.Now;
        }
        

        private void ConnectToDevice()
        {
            var devicePicker = new SerialDevicePicker();
            if (devicePicker.ShowDialog() == DialogResult.OK)
            {
                _currentDevice = devicePicker.SelectedDevice;
                _serialReader = new SerialPortReader(_currentDevice.Port, 115200);
            }
            else
            {
                MessageBox.Show("No device selected", "Operation cancelled");
            }
        }

        private void StartLogging()
        {
            if (!CheckDevice() 
                || _logState == LogState.Active // already running
                || _logState == LogState.Paused // don't restart logging if paused
                ) return;

            _logState = LogState.Active;
            stateLabel.Text = "State: Active";
            HookSerialReader();
            ResetLog();
            _updateStatsTimer.Start();
            _serialReader.Start();

            Task.Run(ProcessMessageQueue);
        }

        private void HookSerialReader()
        {
            _serialReader.OnGMLanMessageReceived += OnSerialMessage;
        }

        private void UnhookSerialReader()
        {
            _serialReader.OnGMLanMessageReceived -= OnSerialMessage;
        }

        private void OnSerialMessage(GMLanMessage message)
        {
            if (_logState != LogState.Active) return;
        
            _rawMessageCount++;
            _messageQueue.Enqueue(message);
        }

        private void ProcessMessageQueue()
        {
            while (_logState == LogState.Active)
            {
                if (_messageQueue.TryDequeue(out var message))
                {
                    // trim _allMessages
                    if (_allMessages.Count >= _maxMessages) _allMessages.Remove(_allMessages.First());
                    
                    // trim _filteredMessages
                    if (_filteredMessages.Count >= _maxMessages) _filteredMessages.Remove(_filteredMessages.First());
                    
                    if (_messageCache.IsUnique(message))
                    {
                        _allMessages.Add(message);
                        if (_activeFilter(message))
                        {
                            _filteredMessages.Add(message);
                        }
                        MessageCounts.AddOrUpdate(message.Header, 1, (key, oldValue) => oldValue + 1);
                        _filterControlWindow.Check(message);
                    }
                    
                }
                else Thread.Sleep(1);
            }
        }

        private void UpdateLogList()
        {
            logList.BeginUpdate();
            try
            {
                List<GMLanMessage> filteredMessagesCopy; // The copy
                filteredMessagesCopy = new List<GMLanMessage>(_filteredMessages);

                logList.VirtualListSize = filteredMessagesCopy.Count; // Use the copy's count
                if (filteredMessagesCopy.Any() && ShouldResizeColumns(filteredMessagesCopy.Last())) // Use the copy
                {
                    ResizeColumns();
                }
                AutoScrollToBottom(false);
            }
            finally
            {
                logList.EndUpdate();
            }
        }

        private void PauseLogging()
        {
            if (!CheckDevice() || _logState != LogState.Active) return;

            _logState = LogState.Paused;
            stateLabel.Text = "State: Paused";
            UnhookSerialReader();
            _serialReader.Stop();
            
        }

        private void ResumeLogging()
        {
            if (!CheckDevice() || _logState != LogState.Paused) return;

            // Use BeginUpdate to prevent visual artifacts during cleanup
            logList.BeginUpdate();
            try 
            {
                // Clear all possible selection/focus states
                logList.SelectedIndices.Clear();
                logList.FocusedItem = null;
        
                // First set size to 0 to clear everything
                logList.VirtualListSize = 0;
                logList.Invalidate();
        
                // Now set the proper size back
                logList.VirtualListSize = _filteredMessages.Count;
            }
            finally
            {
                logList.EndUpdate();
            }
    
            _logState = LogState.Active;
            stateLabel.Text = "State: Active";
            HookSerialReader();
            _serialReader.Start();
            Task.Run(ProcessMessageQueue);
        }

        private void StopLogging()
        {
            if (!CheckDevice() || !(_logState == LogState.Active || _logState == LogState.Paused)) return;

            //isLogging = false;
            _logState = LogState.Stopped;
            stateLabel.Text = "State: Stopped";
            UnhookSerialReader();
            _serialReader.Stop();
            _updateStatsTimer.Stop();
        }

        private bool CheckDevice()
        {
            if (_currentDevice != null && _serialReader != null)
                return true;
        
            MessageBox.Show("Connect to a serial device first!", "Not connected");
            return false;
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            ConnectToDevice();
        }

        private void startLoggingButton_Click(object sender, EventArgs e)
        {
            StartLogging();
        }

        private void pauseLoggingButton_Click(object sender, EventArgs e)
        {
            PauseLogging();
        }

        public void resumeLoggingButton_Click(object sender, EventArgs e)
        {
            ResumeLogging();
        }

        private void stopLoggingButton_Click(object sender, EventArgs e)
        {
            StopLogging();
        }

        private void openFilteringMenuButton_Click(object sender, EventArgs e)
        {

            PauseLogging(); // Pause logging when configuring filters
            _filterControlWindow.ShowDialog();
        }

        public void OnFilterUpdated()
        {
            ApplyFilter(_filterControlWindow.GetActiveFilter());
        }

        private void logList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var hit = logList.HitTest(e.Location);
            if (hit.Item == null) return;

            PauseLogging();
            GMLanMessage message = _filteredMessages[hit.Item.Index];
            //var message = _filteredMessages[hit.Item.Index];
            var messageWindow = new MessageViewWindow(message);
            messageWindow.Owner = this;
            messageWindow.ShowDialog();
        }

        private void MainWindow_Click(object sender, EventArgs e)
        {
            if (!logList.ClientRectangle.Contains(logList.PointToClient(Cursor.Position)))
            {
                BeginInvoke((Action)(() => ActiveControl = null));
            }
        }

        private void logList_MouseClick(object sender, MouseEventArgs e)
        {
            PauseLogging();
        }


        private void applyFilterRateButton_Click(object sender, EventArgs e)
        {
            var ok = int.TryParse(filterRateBox.Text, out var interval);
            if (!ok)
            {
                MessageBox.Show("Input a valid delay in ms!", "Invalid input");
                return;
            }
            
            var cleanupInterval = Math.Max(interval / 3, 50);
            _messageCache.UpdateInterval(cleanupInterval, interval);
        }

        private void applyMaxMessagesButton_Click(object sender, EventArgs e)
        {
            var ok = int.TryParse(maxMessagesBox.Text, out var mm);
            if (!ok)
            {
                MessageBox.Show("Input a valid number!", "Invalid input");
                return;
            }
            Console.WriteLine("Max messages set to : " + mm);
            _maxMessages = mm;
        }

        private void allowDuplicateMsg_CheckedChanged(object sender, EventArgs e)
        {
            if (allowDuplicateMsg.Checked) _messageCache.Disable(); // allow all duplicates to pass through at any interval
            else _messageCache.Enable(); // use message cache to remove duplicate messages from the 'stream'
        }
        
    }
}