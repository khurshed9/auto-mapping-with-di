public class ApiResponse<T>
{
    public bool IsSuccessed{get; init;}
    public List<string?> Messages{get; init;}=[];
    public T? Data{get; init;}

    private ApiResponse(bool isSuccessed, string? message, List<string?> messages, T? data)
    {
        this.IsSuccessed=isSuccessed;
        if(message!=null) this.Messages.Add(message);
        this.Messages=messages;
        this.Data=data;
    }

    public static ApiResponse<T> Success(List<string?> messages, T? data, string message="Success")
    => new ApiResponse<T>(true, message, messages, data);

    public static ApiResponse<T> Fail(List<string?> messages, T? data, string message="Fail")
    => new ApiResponse<T>(false, message, messages, data);
}