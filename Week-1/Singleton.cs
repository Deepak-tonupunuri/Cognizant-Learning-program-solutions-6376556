using System;

namespace SingletonPatternExample
{
    public sealed class Logger
    {
        private static Logger? _instance = null;

        private static readonly object _lock = new object();

        private Logger()
        {
            Console.WriteLine("Logger initialized.");
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock) 
                    {
                        if (_instance == null)
                        {
                            _instance = new Logger();
                        }
                    }
                }
                return _instance;
            }
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern\n");

            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            logger1.Log("Hello World!");
            logger2.Log("Welcome to C# Singleton");

            if (object.ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("\nBoth logger1 and logger2 refer to the same instance.");
            }
            else
            {
                Console.WriteLine("\nlogger1 and logger2 are different instances.");
            }
        }
    }
}
