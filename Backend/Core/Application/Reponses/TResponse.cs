
namespace Core.Application.Reponses;
public class TResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }

    public List<Error> Errors { get; set; }
}

public struct Error
{
    public string Code { get; set; }
    public string Message { get; set; }
}