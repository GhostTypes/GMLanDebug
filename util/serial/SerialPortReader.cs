using System;
using System.IO.Ports;
using System.Threading;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;

namespace GMLanDebug.util.serial
{
    public class SerialPortReader : IDisposable
    {
        private const int BUFFER_SIZE = 4096;
        private const int READ_TIMEOUT_MS = 50;
        private const int WRITE_TIMEOUT_MS = 50;

        private readonly SerialPort _serialPort;
        private readonly ConcurrentQueue<string> _messageQueue;
        private CancellationTokenSource _cancellationTokenSource;
        private Task _processTask;
        private volatile bool _isProcessing;

        public event Action<GMLanMessage> OnGMLanMessageReceived; // More descriptive event name

        public SerialPortReader(string portName, int baudRate)
        {
            _messageQueue = new ConcurrentQueue<string>();
            _cancellationTokenSource = new CancellationTokenSource();

            _serialPort = new SerialPort
            {
                PortName = portName,
                BaudRate = baudRate,
                Parity = Parity.None,
                DataBits = 8,
                StopBits = StopBits.One,
                DtrEnable = true,
                ReadTimeout = READ_TIMEOUT_MS,
                WriteTimeout = WRITE_TIMEOUT_MS,
                ReadBufferSize = BUFFER_SIZE,
                WriteBufferSize = BUFFER_SIZE,
                ReceivedBytesThreshold = 1
            };
        }

        public void Start()
        {
            if (_serialPort.IsOpen)
            {
                throw new InvalidOperationException("Serial port is already open.");
            }

            try
            {
                _serialPort.Open();
                _serialPort.DiscardInBuffer();
                _serialPort.DiscardOutBuffer();
                _cancellationTokenSource = new CancellationTokenSource();
                _isProcessing = true; // Set after successful opening
                _serialPort.DataReceived += HandleSerialEvent;

                _processTask = Task.Run(ProcessMessageQueue, _cancellationTokenSource.Token);
            }
            catch (Exception ex)
            {
                CleanupResources();
                throw new InvalidOperationException("Failed to start serial port reader.", ex);
            }
        }

        public void Stop()
        {
            _isProcessing = false;
            _cancellationTokenSource.Cancel();

            if (_serialPort != null && _serialPort.IsOpen)
            {
                _serialPort.DataReceived -= HandleSerialEvent;
                _serialPort.Close();
            }

            try
            {
                _processTask?.Wait(1000);
            }
            catch (Exception)
            {
                // Ignore task cancellation exceptions
            }

            CleanupResources();
        }

        private byte[] _readBuffer = new byte[BUFFER_SIZE * 2]; // Double the buffer size
        private int _bufferIndex = 0;

        private void HandleSerialEvent(object sender, SerialDataReceivedEventArgs e)
        {
            if (e.EventType != SerialData.Chars || !_serialPort.IsOpen) return;

            try
            {
                int bytesToRead = _serialPort.BytesToRead;
                if (bytesToRead > 0)
                {
                    int bytesRead = _serialPort.Read(_readBuffer, _bufferIndex, bytesToRead);
                    _bufferIndex += bytesRead;

                    // Process complete lines from the buffer
                    int startIndex = 0;
                    for (int i = 0; i < _bufferIndex; i++)
                    {
                        if (_readBuffer[i] == '\n') // Assuming newline is the line delimiter
                        {
                            int length = i - startIndex;
                            if (length > 0)
                            {
                                string line = System.Text.Encoding.ASCII.GetString(_readBuffer, startIndex, length).Trim();
                                _messageQueue.Enqueue(line);
                            }
                            startIndex = i + 1;
                        }
                    }

                    // Shift remaining data to the beginning of the buffer
                    if (startIndex > 0)
                    {
                        int remainingBytes = _bufferIndex - startIndex;
                        if (remainingBytes > 0)
                            Array.Copy(_readBuffer, startIndex, _readBuffer, 0, remainingBytes);
                        _bufferIndex = remainingBytes;
                    }
                    if (_bufferIndex >= _readBuffer.Length)
                    {
                        _bufferIndex = 0;
                    }
                }
            }
            catch (TimeoutException ex)
            {
                Console.WriteLine($"Serial read timeout: {ex.Message}");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Serial port error: {ex.Message}");
                Stop();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Serial port error: {ex.Message}");
                Stop();
            }
        }

        private async Task ProcessMessageQueue()
        {
            while (_isProcessing && !_cancellationTokenSource.Token.IsCancellationRequested)
            {
                while (_messageQueue.TryDequeue(out string message))
                {
                    try
                    {
                        var gmMsg = new GMLanMessage(message);
                        OnGMLanMessageReceived?.Invoke(gmMsg); // Use the more descriptive event name
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error processing message: {ex.Message}");
                    }
                }

                await Task.Delay(1, _cancellationTokenSource.Token);
            }
        }

        private void CleanupResources()
        {
            _serialPort?.Dispose();
            _cancellationTokenSource?.Dispose();
        }

        public void Dispose()
        {
            Stop();
            CleanupResources();
        }
    }
}