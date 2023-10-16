namespace SupportBank;

internal class Program
{
    static void Main(string[] args)
    {
        List<string> names = new List<string>();
        List<Transaction> transactions = new List<Transaction>();

        using(var reader = new StreamReader(@"C:\Users\PA83195\.vscode\Training\SupportBank-CSharp\Transactions2014.csv"))
        {
            reader.ReadLine();
            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine()!.Split(',');
                names.Add(line[1]);
                names.Add(line[2]);
                Transaction transaction = new Transaction(DateTime.Parse(line[0]), line[1], line[2], line[3], float.Parse(line[4]));
                transactions.Add(transaction);
            } 
        }
        List<string> uniqueNames = names.Distinct().ToList();
        Console.Write("Please select a numbered choice: 1) List All, 2) List [account]: ");
        string choice = Console.ReadLine()!;

        if (choice == "1")
        {
            Console.WriteLine();
            foreach (var name in uniqueNames)
            {
                Account account = new Account();           
                account.TransactionAll(name, transactions);
            }  
        }

        if (choice == "2")
        {
            Console.Write("Who's account would you like to list?: ");
            String name = Console.ReadLine()!;
            Console.WriteLine();
            Account account = new Account();            
            account.TransactionDetailed(name, transactions);
        }
    }
}

class Transaction
{
    public DateTime Date { get; set; }
    public string From { get; set; }
    public string To { get; set; }
    public string Narrative { get; set; }
    public float Amount { get; set; }

    public Transaction(DateTime date, string from, string to, string narrative, float amount)
    {
        Date = date;
        From = from;
        To = to;
        Narrative = narrative;
        Amount = amount;
    }
}

class Account
{
    public string? Name { get; set; }

    public double AccountBalance { get; set; }

    // public Account()
    // {
    // }

    public void TransactionAll(string Name, List<Transaction> transactions)
    {
        AccountBalance = 0;
        foreach (var transaction in transactions)
        {
            if (transaction.From == Name)
            {
                AccountBalance -= transaction.Amount;
            } 

            if (transaction.To == Name)
            {
                AccountBalance += transaction.Amount;
            } 
        }
        Console.WriteLine("{1}'s Account Balance is: £" + "{0:0.00}", AccountBalance, Name);
    }

    public void TransactionDetailed(string Name, List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            if (transaction.From == Name)
            {
                AccountBalance -= transaction.Amount;
                Console.WriteLine("{0}, £{1} to {2} for {3}", 
                    transaction.Date.ToShortDateString(), 
                    transaction.Amount, 
                    transaction.To, 
                    transaction.Narrative);
            } 

            if (transaction.To == Name)
            {
                AccountBalance += transaction.Amount;
                Console.WriteLine("{0}, £{1} from {2} for {3}", 
                    transaction.Date.ToShortDateString(), 
                    transaction.Amount, 
                    transaction.From, 
                    transaction.Narrative);
            } 
        }
        Console.WriteLine("\n{1}'s Total Account Balance is: £" + "{0:0.00}\n", AccountBalance, Name);
    }
}
