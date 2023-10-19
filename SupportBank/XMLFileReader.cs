using System.Xml;

namespace SupportBank;

public class XMLFileReader
{
    public List<Transaction> transactions = new List<Transaction>();

    // public List<Transaction> ReadXML(string path)
    // {
    //     XmlDocument xml = new XmlDocument();
    //     xml.Load("C:\\New Training\\SupportBank-CSharp\\Transactions2012.xml");
    //     xml.Save(Console.Out);
        
    //     // using(var reader = new StreamReader(path))
    //     // {
    //     //     string json = reader.ReadToEnd();
    //     //     var list = JsonConvert.DeserializeObject<List<Transaction>>(json);
    //     //     foreach (var item in list)
    //     //     {
    //     //         Transaction transaction = new Transaction(Convert.ToDateTime(item.Date), item.FromAccount, item.ToAccount, item.Narrative, item.Amount);
    //     //         transactions.Add(transaction);
    //     //     }
    //     // }
    //     // return transactions;
    // }
}