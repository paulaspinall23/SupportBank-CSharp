namespace SupportBank;

using NLog;
using NLog.Config;
using NLog.Targets;

internal class Program
{
    static void Main(string[] args)
    {
        var config = new LoggingConfiguration();
        var target = new FileTarget { FileName = @"C:\New Training\SupportBank-CSharp\Logs\supportbank.log", Layout = @"${longdate} ${level} - ${logger}: ${message}" };
        config.AddTarget("File Logger", target);
        config.LoggingRules.Add(new LoggingRule("*", LogLevel.Debug, target));
        LogManager.Configuration = config;
        
        if (args[0].ToLower() == "import" && args[1].ToLower() == "file")
        {
            var account = new Account(args[2]);
            Console.WriteLine("Which function would you like to perform?");
            Console.WriteLine("1 = List All,");
            Console.Write("2 = List [Account]: ");
            string choice = Console.ReadLine()!;
            if (choice.ToLower() == "1")
            {
                account.ListAll();
            }
            else if (choice.ToLower() == "2")
            {
                Console.Write("Who's account would you like to check?: ");
                string response = Console.ReadLine()!;
                account.ListAccount(response);
            }
            else
            {
                Console.WriteLine("I'm sorry, I couldn't understand your command");
            }
        }
    }
}