using Microsoft.AspNetCore.SignalR;

namespace Project_1.api.Model;

public class BlogPost{
    public int Id { get; set; } // Primary Key
    public required string Title { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public required string Author { get; set; } // Can be linked to a User model in the future
}
