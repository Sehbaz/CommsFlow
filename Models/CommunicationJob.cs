namespace Commsflow.Models;

public class CommunicationJob
{
    public int Id { get; set; }
    public string RecipientName { get; set; } = string.Empty;
    public string RecipientEmail { get; set; } = string.Empty;
    public string GeneratedContent { get; set; } = string.Empty;
    public string Status { get; set; } = "Pending"; 
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

}