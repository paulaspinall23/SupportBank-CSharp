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

        //var account = new Account("C:\\New Training\\SupportBank-CSharp\\DodgyTransactions2015.csv");
        //account.ListAll();
        string choice = "";
        for (int i = 1; i < args.Length; i++)
        {
            choice += args[i] + " ";
        }
        Console.WriteLine(choice);
      
        if (choice.ToLower() == "all")
        {
            Console.WriteLine("Yes");
            // var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2013.json");
            // account.ListAll();
        }
        else
        {
            Console.WriteLine(choice.GetType());
            Console.WriteLine(choice);
            Console.WriteLine("No");
        }
        // else
        // {
        //     var account = new Account("C:\\New Training\\SupportBank-CSharp\\Transactions2013.json");
        //     account.ListAccount(choice);
        // }
        
        
        

        //account.ListAccount("Tim L");
        
        //var reader = new JSONFileReader();
        

        //List<string> uniqueNames = reader.names.Distinct().ToList();
        //Console.Write("Please select a numbered choice: 1) List All, 2) List [account]: ");
        //string choice = Console.ReadLine()!;

        // if (choice == "1")
        // {
        //     Console.WriteLine();
        //     foreach (var name in uniqueNames)
        //     {
        //         Account account = new Account();           
        //         account.ListAll(name, reader.transactions);
        //     }  
        // }

        // if (choice == "2")
        // {
        //     Console.Write("Who's account would you like to list?: ");
        //     String name = Console.ReadLine()!;
        //     Console.WriteLine();
        //     Account account = new Account();            
        //     account.ListAccount(name, reader.transactions);
        // }
    }
}