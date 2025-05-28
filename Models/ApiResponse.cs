namespace RG_Graph.Models;

public class ApiResponse<T>
{
    public bool Success { get; set; }
    public T Data { get; set; }
    public string ErrorMessage { get; set; }
    
    public static ApiResponse<T> CreateSuccess(T data) => new() { Success = true, Data = data };
    public static ApiResponse<T> CreateError(string errorMessage) => new() { Success = false, ErrorMessage = errorMessage };
}