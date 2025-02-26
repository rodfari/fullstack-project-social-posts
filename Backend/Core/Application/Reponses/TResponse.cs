
namespace Core.Application.Reponses;
public class TResponse<T>
{
    public bool Success { get; private set; }
    public T Data { get; private set; } = default!;
    public Pagination Pagination { get; set; } = new Pagination();
    public List<Error> Errors { get; private set; } = [];

    public TResponse<T> SetIsSuccess(bool status)
    {
        this.Success = status;
        return this;
    }

    public TResponse<T> SetData(T data)
    {
        this.Data = data;
        return this;
    }

    public TResponse<T> SetErrors(List<Error> errors)
    {
        this.Errors = errors;
        return this;
    }
}

public struct Error
{
    public string Code { get; set; }
    public string Message { get; set; }
}