namespace GoParkService.Entity.DTO;

public class ResultDTO<T>
{
    public bool IsSuccess { get; private set; }
    public T Data { get; private set; }
    public string Message { get; private set; }

    private ResultDTO(bool isSuccess, T data, string message)
    {
        IsSuccess = isSuccess;
        Data = data;
        Message = message;
    }

    public static ResultDTO<T> Success(T data, string message = null)
    {
        return new ResultDTO<T>(true, data, message);
    }

    public static ResultDTO<T> Failure(string message, T data = default)
    {
        return new ResultDTO<T>(false, data, message);
    }

    // Optional: Add methods to check for success/failure
    public bool Succeeded()
    {
        return IsSuccess;
    }

    public bool Failed()
    {
        return !IsSuccess;
    }
}
