namespace SupportBank;

public class Account
{
    private List<Transaction> Transactions { get; set; }

    public Account(string path)
    {
        string extension = Path.GetExtension(path);
        if (extension == ".csv")
        {
            var reader = new CsvFileReader();
            Transactions = reader.ReadCSV(path);
        }
        else if (extension == ".json")
        {
            var reader = new JSONFileReader();
            Transactions = reader.ReadJSON(path);
        }
    }

    public void ListAll()
    {
        var names = GetUniqueNames();
        foreach (var name in names)
        {
            decimal balance = 0;

            var transactionsForAccount = GetTransactionsForAccount(name);
            foreach (var transaction in transactionsForAccount)
            {
                if (transaction.From == name)
                {
                    balance -= transaction.Amount;
                }
                else
                {
                    balance += transaction.Amount;
                }
            }

            Console.WriteLine($"Account {name}: £{balance}");
        }
    }

    public void ListAccount(string name)
    {
        var transactionsForAccount = GetTransactionsForAccount(name);

        for (int i = 0; i < transactionsForAccount.Count; i++)
        {
            var transaction = transactionsForAccount[i];
            Console.WriteLine(transaction.ToString());
        }
    }

    private List<Transaction> GetTransactionsForAccount(string name)
    {
        var result = new List<Transaction>();

        for (int i = 0; i < Transactions.Count; i++)
        {
            var transaction = Transactions[i];
            if (transaction.From == name || transaction.To == name)
            {
                result.Add(transaction);
            } 
        }
        return result;
    }

    private List<string> GetUniqueNames()
    {
        var result = new List<string>();

        for (int i = 0; i < Transactions.Count; i++)
        {
            var transaction = Transactions[i];

            var from = transaction.From;
            if (!result.Contains(from))
            {
                result.Add(from);
            } 

            var to = transaction.To;
            if (!result.Contains(to))
            {
                result.Add(to);
            } 
        }
        return result;
    }
}
