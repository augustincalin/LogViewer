using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ASampleApp {
    class Program {
        static void Main(string[] args) {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            var logger = LogManager.GetLogger(typeof(Program));
            logger.Info("Program started!");
            string message = string.Empty;
            bool goOn = true;
            Console.WriteLine("LOG GENERATOR");
            Console.WriteLine("=============");

            while (goOn) {
                Console.Write("Warn, Error, Info, Quit ( W / E / I / Q ): ");
                ConsoleKeyInfo key = Console.ReadKey();
                goOn = key.Key != ConsoleKey.Q;
                Console.WriteLine();
                if (goOn) {
                    Console.Write("Message: ");
                    message = Console.ReadLine();
                }
                switch (key.Key) {
                    case ConsoleKey.W:
                        logger.Warn(message);
                        break;
                    case ConsoleKey.E:
                        logger.Error(message);
                        break;
                    case ConsoleKey.I:
                        logger.Info(message);
                        break;
                }
            };
        }
    }
}
