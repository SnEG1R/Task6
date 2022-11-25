using System.Diagnostics.CodeAnalysis;

namespace Task6.Domain;

public class User
{
    public long Id { get; set; }
    public string Name { get; set; }
    
    public List<Message> Messages { get; set; }
}