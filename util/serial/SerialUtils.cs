namespace GMLanDebug.util.serial
{
    public class SerialUtils
    {


        public static string GetArduinoName(string deviceId)
        {
            switch (deviceId)
            {
                case "0001":
                    return "Uno";
                case "0043":
                    return "Uno R3";
                case "003E":
                    return "Due";
                default:
                    return null;
                    // todo add the one for Uno R4
            }
        }
        
    }
}