namespace Backend.Core.Domain;

public class DailyPostLimit
{
    public int UserId { get; set; }
    public DateTime PostDate { get; set; }
    public int PostCount { get; set; }

    public User User { get; set; }
}

