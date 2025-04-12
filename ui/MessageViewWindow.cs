using System.Windows.Forms;
using GMLanDebug.util;

namespace GMLanDebug.ui
{
    public partial class MessageViewWindow : Form
    {
        public MessageViewWindow(GMLanMessage message)
        {
            InitializeComponent();
            idLabel.Text += message.Id;
            headerLabel.Text += message.Header;
            senderLabel.Text += message.Sender;
            priorityLabel.Text += message.Priority;
            dlcLabel.Text += message.DLC;
            dataLabel.Text += message.Data;

            var translation = MessageTranslation.Translate(message);
            dataTranslated.Text += translation.TranslatedMessage;
            decimalLabel.Text += translation.DecimalData;
            asciiLabel.Text += translation.AsciiData;
        }

        private void MessageViewWindow_FormClosed(object sender, FormClosedEventArgs e)
        {
            //maybe not a good idea
            //var mainWindow = Owner as MainWindow;
            //mainWindow?.resumeLoggingButton_Click(null, null); // resume logging when closing
        }
    }
}