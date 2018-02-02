using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace ASampleApp {
    class Program {
        private static string[] messages = new string[] { "a message", "another message", "yet another message", "something" };
        private static ILog logger;
        static void Main(string[] args) {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));
            logger = LogManager.GetLogger(typeof(Program));
            logger.Info("Program started!");
            string message = string.Empty;
            bool goOn = true;
            Console.WriteLine("LOG GENERATOR");
            Console.WriteLine("=============");

            while (goOn) {
                Console.Write("Warn, Error, Info, eXception, Auto, Quit ( W / E / I / X / A / Q ): ");
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
                    case ConsoleKey.X:
                        try { throw new Exception(message); } catch (Exception exc)
                        {
                            logger.Fatal(message, exc);
                        }
                        break;
                    case ConsoleKey.A:
                        do {
                            GenerateRandom();
                        } while (!Console.KeyAvailable);
                        break;
                }
            };
        }

        private static void GenerateRandom()
        {
            Random r = new Random();
            int indexMessage = r.Next(messages.Length);
            int type = r.Next(4);
            switch (type)
            {
                case 0:
                    logger.Info(messages[indexMessage]);
                    break;
                case 1:
                    logger.Warn(messages[indexMessage]);
                    break;
                case 2:
                    logger.Error(messages[indexMessage]);
                    break;
                case 3:
                    logger.Fatal(messages[indexMessage], new Exception("an exception"));
                    break;
            }
        }
    }
}
