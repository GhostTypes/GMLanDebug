using System.Windows.Forms;
using GMLanDebug.util;

namespace GMLanDebug.ui
{
    // For FilterControlWindow (show unique headers/select show hide etc)
    public class GMLanHeaderListViewItem : ListViewItem
    {
        //public GMLanMessage Message { get; private set; }
        public string Header { get; private set; }
        private string SenderName { get; }
        private int MessageCount { get; set; }

        public GMLanHeaderListViewItem(GMLanMessage message, int messageCount)
            : base($"{message.Header} [{message.SenderName}] ({messageCount})")
        {
            Header = message.Header;
            MessageCount = messageCount;
            SenderName = message.SenderName;
        }
        
        
        public void UpdateMessageCount(int newCount)
        {
            MessageCount = newCount;
            Text = $"{Header} [{SenderName}] ({MessageCount})"; // Update the text displayed in the ListViewItem
        }
    }
}