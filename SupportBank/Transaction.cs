namespace SupportBank;

public class Transaction
{
    public DateTime Date { get; set; } 
    public string FromAccount { get; set; } // For Json field
    public string From { get; set; }
    public string To { get; set; }
    public string ToAccount { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }// Look at using a decimal instead of a float

    public Transaction(DateTime date, string from, string to, string narrative, decimal amount)
    {
        Date = date;
        From = from;
        FromAccount = from;
        To = to;
        ToAccount = to;
        Narrative = narrative;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: £{Amount} from {From} to {To}, for \"{Narrative}\"";
    }
}