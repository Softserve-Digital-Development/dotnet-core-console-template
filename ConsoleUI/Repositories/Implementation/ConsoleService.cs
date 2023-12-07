using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using NetCoreConsoleApp.Repositories.Interface;
using System;
using System.Threading.Tasks;

namespace NetCoreConsoleApp.Repositories.Implementation
{
    public class ConsoleService : IConsoleService
    {
        private readonly ILogger<ConsoleService> _log;
        private readonly IConfiguration _config;

        public ConsoleService(ILogger<ConsoleService> log, IConfiguration config)
        {
            _log = log;
            _config = config;
        }

        public async Task Run()
        {
            bool exitRequested = false;
            ConsoleKey previousKey = default;
            do
            {
                if (previousKey == default)
                {
                    Console.WriteLine("Choose an option and press Enter:");
                    Console.WriteLine("1. Run option 1 (log information).");
                    Console.WriteLine("2. Run option 2 (log error).");
                    Console.WriteLine("Press Escape key to exit.");
                }
                else
                {
                    Console.Write((char)previousKey);
                }

                ConsoleKeyInfo key = Console.ReadKey(intercept: true);


                if (key.Key == ConsoleKey.Enter)
                {
                    switch (previousKey)
                    {
                        case ConsoleKey.NumPad1:
                        case ConsoleKey.D1:
                            Console.WriteLine();

                            _log.LogInformation("Running Option 1...");

                            /*---DO SOME WORK---*/
                            await Task.Delay(1000);

                            _log.LogInformation("Done running Option 1!");
                            break;
                        case ConsoleKey.NumPad2:
                        case ConsoleKey.D2:
                            Console.WriteLine();

                            _log.LogError("Running Option 2...");

                            /*---DO SOME WORK---*/
                            await Task.Delay(3000);

                            _log.LogError("Done running Option 2!");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine();
                            Console.WriteLine("Invalid option. Please try a different option.");
                            Console.ForegroundColor = ConsoleColor.White;
                            break;
                    }
                    Console.WriteLine("------------------------------------------------------");
                    Console.WriteLine("------------------------------------------------------");

                    previousKey = default;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    exitRequested = true;
                }
                else
                {
                    previousKey = key.Key;
                }
            } while (!exitRequested);
        }
    }
}
