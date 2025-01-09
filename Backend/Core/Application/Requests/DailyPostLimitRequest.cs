using Core.Domain.Entities;

namespace Core.Application.Requests;
public class DailyPostLimitRequest
{
    public int PostCount { get; set; }
    public User User { get; set; }
}