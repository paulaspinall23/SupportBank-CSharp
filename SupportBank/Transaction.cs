namespace SupportBank;

public class Transaction
{
    public DateTime Date { get; set; } 
    public string FromAccount { get; set; }
    public string From { get; set; }
    public string ToAccount { get; set; }
    public string To { get; set; }
    public string Narrative { get; set; }
    public decimal Amount { get; set; }

    public Transaction(DateTime date, string from, string to, string narrative, decimal amount)
    {
        Date = date;
        FromAccount = from;
        From = from;
        ToAccount = to;
        To = to;
        Narrative = narrative;
        Amount = amount;
    }

    public override string ToString()
    {
        return $"{Date.ToShortDateString()}: £{Amount} from {From} to {To}, for \"{Narrative}\"";
    }
}