using System.Windows.Forms;
using GMLanDebug.util;

namespace GMLanDebug.ui
{

    public class GMLanListViewItem : ListViewItem
    {
        public GMLanMessage Message { get; private set; }

        public GMLanListViewItem(GMLanMessage message) : base(message.Id) // Use ID as the main item text
        {
            Message = message;

            // Add sub-items for the other fields
            SubItems.Add(message.Header);
            SubItems.Add($"{message.Sender} ({message.SenderName})");
            SubItems.Add(message.Priority);
            SubItems.Add(message.DLC);
            SubItems.Add(message.Data);
        }
    }

}