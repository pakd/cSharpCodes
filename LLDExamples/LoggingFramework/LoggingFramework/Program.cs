using System;

namespace LoggingFramework
{
    public class Program
    {
        public static void Main(string[] args)
        {
            LoggingFramework.GetInstance().LogDebug("hi, this is debug message");
            
            LoggingFramework.GetInstance().LogInfo("hi, this is info message");
            
            LoggingFramework.GetInstance().LogError("hi, this is error message");
        }
    }
}