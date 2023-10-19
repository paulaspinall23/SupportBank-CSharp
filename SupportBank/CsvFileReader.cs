using NLog;

namespace SupportBank;

public class CsvFileReader
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    //public List<string> names = new List<string>();
    public List<Transaction> transactions = new List<Transaction>();

    public List<Transaction> ReadCSV(string path)
    {
        using(var reader = new StreamReader(path))
        {
            Logger.Info($"Reading file \"{path}\"");

            reader.ReadLine();

            int lineNumber = 2;

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!.Split(',');

                DateTime date;
                decimal amount;
                try
                {
                    date = DateTime.Parse(line[0]);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {line[0]} as DateTime");
                    Logger.Error($"Error parsing line {lineNumber}: cannot parse {line[0]} as DateTime");
                    throw ex;
                }

                try
                {
                    amount = decimal.Parse(line[4]);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {line[4]} as decimal");
                    Logger.Error($"Error parsing line {lineNumber}: cannot parse {line[4]} as decimal");
                    throw ex;
                }
                
                Transaction transaction = new Transaction(date, line[1], line[2], line[3], amount);
                transactions.Add(transaction);
                //names.Add(line[1]);
                //names.Add(line[2]);

                lineNumber ++;
            } 
            
        }
        return transactions;
    }
}