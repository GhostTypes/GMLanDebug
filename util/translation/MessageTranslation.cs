using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GMLanDebug.util
{
    public class MessageTranslation
    {

        private static readonly Dictionary<string, Func<GMLanMessage, string>> Parsers = new Dictionary<string, Func<GMLanMessage, string>>
        {
            { "100A60", ParseGPSDateAndTime },
        };
        
        
        public static TranslationResult Translate(GMLanMessage message)
        {
            var values = ConvertHexString(message.Data);
            var parsedMessage = ParseData(message);
            return new TranslationResult(values.DecimalValuesString, values.AsciiValuesString, parsedMessage);
        }
        
        private static (string DecimalValuesString, string AsciiValuesString) ConvertHexString(string hexString)
        {
            var decimalValues = new List<int>();
            var asciiValues = new List<string>();

            // Split the input string by spaces
            var hexValues = hexString.Split(' ');

            foreach (var hex in hexValues)
            {
                var decimalValue = Convert.ToInt32(hex, 16); 
                decimalValues.Add(decimalValue);

                // Convert to ASCII if printable; otherwise, use a placeholder
                if (decimalValue >= 32 && decimalValue <= 126) asciiValues.Add(((char)decimalValue).ToString());
                else asciiValues.Add(".");
            }

            var ascii = "No data";
            if (IsValidAscii(asciiValues)) ascii = string.Join("", asciiValues);
            
            return (string.Join(", ", decimalValues), ascii);
        }

        private static bool IsValidAscii(List<string> values)
        {
            return values.Any(value => !value.Equals("."));
        }


        public static string ParseData(GMLanMessage message)
        {
            return Parsers.TryGetValue(message.Header, out var parser)
                ? parser(message)
                : "Unknown";
        }


        private static string ParseGPSDateAndTime(GMLanMessage message)
        {
            try
            {
                var b = GetMessageData(message);
                //Console.WriteLine(message.DLC);
                //Console.WriteLine(b.ToString());
                var year = 2000 + Convert.ToInt32(b[0], 16);
                var month = TranslationUtils.GetMonthName(Convert.ToInt32(b[1], 16));
                var day = GetTimeString(b[2]);
                var hour = GetTimeString(b[3]);
                var minute = GetTimeString(b[4]);
                var second = GetTimeString(b[5]);

                return $"{hour}:{minute}:{second} - {month} {day} {year}";
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message + "\n" + e.StackTrace);
                return "Err";
            }
        }

        private static string[] GetMessageData(GMLanMessage message)
        {
            // todo improve/sanity check(s) ?
            return message.Data.Split(' ');
        }
        
        
        
        private static void LogError(Exception e, GMLanMessage message)
        {
            var errorMessage = new StringBuilder()
                .AppendLine($"Error parsing message with header: {message.Header}")
                .AppendLine($"Data: {message.Data}")
                .AppendLine($"Error: {e.Message}")
                .AppendLine(e.StackTrace)
                .ToString();

            Console.WriteLine(errorMessage);
            // Could also log to file or logging service
        }

        private static string GetTimeString(string data)
        {
            var i = Convert.ToInt32(data, 16);
            return i < 10 ? $"0{i}" : i.ToString();
        }
    }
}