using System;

namespace SingletonPatternExample
{
    public class Logger
    {
        // 1. A private static variable to hold the one and only instance
        private static Logger _instance;

        // 2. Private constructor so no one else can use 'new' to create it
        private Logger()
        {
            Console.WriteLine("Logger instance created for the first time.");
        }

        // 3. Public static method to give the same instance to everyone
        public static Logger GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Logger();
            }
            return _instance;
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}