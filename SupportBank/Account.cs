namespace SupportBank;

public class Account
{
    private List<Transaction> Transactions { get; set; }
    //public string? Name { get; set; }

    //public decimal AccountBalance { get; set; }

    public Account(string path)
    {
        //var reader = new CsvFileReader();
        //Transactions = reader.ReadCSV(path);
        var reader = new JSONFileReader();
        Transactions = reader.ReadJSON(path);
        
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

    // public void ListAll(string Name, List<Transaction> transactions)
    // {
    //     AccountBalance = 0;
    //     foreach (var transaction in transactions)
    //     {
    //         if (transaction.From == Name)
    //         {
    //             AccountBalance -= transaction.Amount;
    //         } 

    //         if (transaction.To == Name)
    //         {
    //             AccountBalance += transaction.Amount;
    //         } 
    //     }
    //     Console.WriteLine("{1}'s Account Balance is: £" + "{0:0.00}", AccountBalance, Name);
    // }

    // public void ListAccount(string Name, List<Transaction> transactions)
    // {
    //     foreach (var transaction in transactions)
    //     {
    //         if (transaction.From == Name)
    //         {
    //             AccountBalance -= transaction.Amount;
    //             Console.WriteLine("{0}, £{1} to {2} for {3}", 
    //                 transaction.Date, 
    //                 transaction.Amount, 
    //                 transaction.To, 
    //                 transaction.Narrative);
    //         } 

    //         if (transaction.To == Name)
    //         {
    //             AccountBalance += transaction.Amount;
    //             Console.WriteLine("{0}, £{1} from {2} for {3}", 
    //                 transaction.Date, 
    //                 transaction.Amount, 
    //                 transaction.From, 
    //                 transaction.Narrative);
    //         } 
    //     }
    //     Console.WriteLine("\n{1}'s Total Account Balance is: £" + "{0:0.00}\n", AccountBalance, Name);
    // }
}
