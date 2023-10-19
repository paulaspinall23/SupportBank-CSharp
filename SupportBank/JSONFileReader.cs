using Newtonsoft.Json;
using NLog;

namespace SupportBank;

public class JSONFileReader
{
    private static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    public List<Transaction> transactions = new List<Transaction>();

    public List<Transaction> ReadJSON(string path)
    {
        using(var reader = new StreamReader(path))
        {
            Logger.Info($"Reading file \"{path}\"");
            
            int lineNumber = 1;

            string json = reader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Transaction>>(json);

                DateTime date;               
                
                lineNumber ++;

            if (list is null)
            {
                throw new Exception(" ");
            }
            foreach (var item in list)
            {
                try
                {
                    date = Convert.ToDateTime(item.Date);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine($"Error parsing line {lineNumber}: cannot parse {item.Date} as Date");
                    Logger.Error($"Error parsing line {lineNumber}: cannot parse {item.Date} as Date");
                    throw ex;
                }

                Transaction transaction = new Transaction(date, item.FromAccount, item.ToAccount, item.Narrative, item.Amount);
                transactions.Add(transaction);

                lineNumber ++;
            }  
        }
        return transactions;
    }
}