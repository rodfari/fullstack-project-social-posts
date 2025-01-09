namespace Core.Domain.Entities;

public class DailyPostLimit: BaseEntity
{
    public int PostCount { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}

