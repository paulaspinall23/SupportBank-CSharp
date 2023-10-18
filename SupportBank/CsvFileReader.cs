namespace SupportBank;

public class CsvFileReader
{
    //public List<string> names = new List<string>();
    public List<Transaction> transactions = new List<Transaction>();

    public List<Transaction> ReadCSV(string path)
    {
        using(var reader = new StreamReader(path))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!.Split(',');
                Transaction transaction = new Transaction(DateTime.Parse(line[0]), line[1], line[2], line[3], decimal.Parse(line[4]));
                transactions.Add(transaction);
                //names.Add(line[1]);
                //names.Add(line[2]);
            } 
        }
        return transactions;
    }
}