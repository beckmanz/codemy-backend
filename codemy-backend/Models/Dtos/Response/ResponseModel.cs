namespace codemy_backend.Models.Dtos.Response;

public abstract class ResponseModel
{
    protected ResponseModel(bool isSuccess, string message)
    {
        IsSuccess = isSuccess;
        Message = message;
    }
    public bool IsSuccess { get; private set; }
    public string Message { get; private set; }
}

public class ResponseData<T> : ResponseModel
{
    public ResponseData(T? data, bool isSuccess = true, string message = "") : base(isSuccess, message)
    {
        Data = data;
    }
    public T? Data { get; set; }
    public static ResponseData<T> Success(T data, string message = "Operação realizada com sucesso.") => new (data, true, message);
    
}