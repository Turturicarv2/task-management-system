using Microsoft.AspNetCore.Identity;

public class Task
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime DueDate { get; set; }
    public string AssignedUserId { get; set; }
    public IdentityUser AssignedUser { get; set; }
    public string Status { get; set; } 
}
