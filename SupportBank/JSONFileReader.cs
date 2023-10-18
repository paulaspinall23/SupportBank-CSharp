using Newtonsoft.Json;

namespace SupportBank;

public class JSONFileReader
{
    public List<Transaction> transactions = new List<Transaction>();

    public List<Transaction> ReadJSON(string path)
    {
        using(var reader = new StreamReader(path))
        {
            string json = reader.ReadToEnd();
            var list = JsonConvert.DeserializeObject<List<Transaction>>(json);
            foreach (var item in list)
            {
                Transaction transaction = new Transaction(Convert.ToDateTime(item.Date), item.FromAccount, item.ToAccount, item.Narrative, item.Amount);
                transactions.Add(transaction);
            }
        }
        return transactions;
    }
}