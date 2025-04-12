namespace GMLanDebug.util
{
    public class TranslationResult
    {
        public string DecimalData { get; private set; }
        public string AsciiData { get; private set; }
        
        public string TranslatedMessage { get; private set; }

        public TranslationResult(string decimalData, string asciiData, string translatedMessage)
        {
            DecimalData = decimalData;
            AsciiData = asciiData;
            TranslatedMessage = translatedMessage;
        }
        
    }
}