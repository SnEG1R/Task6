namespace Task6.Domain;

public class Message
{
    public long Id { get; set; }
    public string RecipientName { get; set; }
    public string Header { get; set; }
    public string Body { get; set; }
    public DateTime DateSend { get; set; }
    
    public User Owner { get; set; }
}