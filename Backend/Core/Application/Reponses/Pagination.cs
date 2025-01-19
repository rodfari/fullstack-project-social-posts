namespace Core.Application.Reponses;

public class Pagination
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public int Total { get; set; }
}