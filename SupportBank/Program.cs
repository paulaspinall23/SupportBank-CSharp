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

        string choice = "";
        
        for (int i = 1; i < args.Length; i++)           
        {
            choice += args[i] + " ";
        }
              
        if (choice.ToLower().Trim() == "all")
        {
            var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2014.csv");
            //var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2013.json");
            account.ListAll();
        }
        else
        {
            //var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2014.csv");
            var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2013.json");
            account.ListAccount(choice.Trim());
        }
    }
}