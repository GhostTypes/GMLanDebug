namespace GMLanDebug.util
{
    public class TranslationUtils
    {
        private static readonly string[] Months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
        
        public static string GetMonthName(int month)
        {
            if (month < 1 || month > 12) return "Invalid Month";
            
            return Months[month - 1];
        }
    }
}