using System.Xml;

namespace SupportBank;

public class XMLFileReader
{
    public List<Transaction> transactions = new List<Transaction>();

    List<object> line = new List<object>();
    DateTime datumDate = new DateTime(1899, 12, 30);

    public List<Transaction> ReadXML(string path)
    {
        XmlTextReader reader = new XmlTextReader(path);

        while (reader.Read())
        {
            switch (reader.NodeType) 
            {
                case XmlNodeType.Element: 
                    if (reader.Name == "Parties")
                    {  
                    }
                    else if (reader.Name == "SupportTransaction")
                    {
                        if (reader.HasAttributes)
                        {
                            reader.MoveToNextAttribute(); 
                            DateTime Date = datumDate.AddDays(Convert.ToDouble(reader.Value));
                            line.Add(Date);
                        }
                    }
                break;
                
                case XmlNodeType.Text: 
                    
                    line.Add(reader.Value);
                    
                break;
            }
        }
        
        for (int i = 0; i < line.Count; i+=5)
        {    
            Transaction transaction = new Transaction((DateTime)line[i], (string)line[i+3], (string)line[i+4], (string)line[i+1], Convert.ToDecimal(line[i+2]));
            transactions.Add(transaction);
        }
        return transactions;
    }
}