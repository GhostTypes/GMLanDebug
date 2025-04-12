using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GMLanDebug.ui;
using GMLanDebug.util;

namespace GMLanDebug
{
    public partial class FilterControlWindow : Form
    {
        private HashSet<string> _uniqueHeaders;

        public FilterControlWindow()
        {
            InitializeComponent();
            _uniqueHeaders = new HashSet<string>();

            rbShowAll.CheckedChanged += OnFilterOptionChanged;
            rbShowSelected.CheckedChanged += OnFilterOptionChanged;
            rbHideSelected.CheckedChanged += OnFilterOptionChanged;
            headerList.SelectedIndexChanged += OnFilterOptionChanged;
        }

        private int GetMessageCount(GMLanMessage message)
        {
            var messageCount = 0;
            if (Owner is MainWindow mainWindow)
            {
                // Retrieve the count from the message cache (MainWindow's _messageCounts)
                mainWindow.MessageCounts.TryGetValue(message.Header, out messageCount);
            }

            return messageCount;
        }
        
        public void Check(GMLanMessage message)
        {
            // Only track and display unique headers, don't filter messages
            if (!_uniqueHeaders.Contains(message.Header))
            {
                _uniqueHeaders.Add(message.Header);

                var messageCount = GetMessageCount(message);

                // If we're on a different thread, use Invoke
                if (headerList.InvokeRequired)
                {
                    headerList.Invoke(new Action(() => headerList.Items.Add(new GMLanHeaderListViewItem(message, messageCount))));
                }
                else
                {
                    headerList.Items.Add(new GMLanHeaderListViewItem(message, messageCount));
                }
            }
            else
            { 
                // Update message count for existing items
                foreach (var i in headerList.Items)
                {
                    if (i is GMLanHeaderListViewItem headerItem && headerItem.Header == message.Header)
                    {
                        headerItem.UpdateMessageCount(GetMessageCount(message)); // Update count
                        break; // Exit once we've found the correct item
                    }
                }
            }
        }


        public Func<GMLanMessage, bool> GetActiveFilter()
        {
            // todo add another radio button for data filtering mode or improve this logic
            if (rbShowAll.Checked)
            {
                return _ => true; // checking if the message data contains X works fine here
            }

            if (rbShowSelected.Checked)
            {
                var selectedHeaders = headerList.SelectedItems
                    .Cast<GMLanHeaderListViewItem>()
                    .Select(item => item.Header)
                    .ToHashSet();
                return msg => selectedHeaders.Contains(msg.Header);
            }

            var hiddenHeaders = headerList.SelectedItems
                .Cast<GMLanHeaderListViewItem>()
                .Select(item => item.Header)
                .ToHashSet();
            return msg => !hiddenHeaders.Contains(msg.Header);
        }

        private void OnFilterOptionChanged(object sender, EventArgs e)
        {
            var mainWindow = Owner as MainWindow;
            mainWindow?.OnFilterUpdated();
        }

        private void ResizeColumns()
        {
            foreach (ColumnHeader column in headerList.Columns)
            {
                column.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
            }
        }

        private void FilterControlWindow_Load(object sender, EventArgs e)
        {
            ResizeColumns();
        }

        private void FilterControlWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            var mainWindow = Owner as MainWindow;
            mainWindow?.resumeLoggingButton_Click(null, null);
        }
        
        // todo impl apply data filter button click
        // todo impl clear data filter button + click
    }
}