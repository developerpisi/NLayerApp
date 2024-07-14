using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs;

public class CustomResponseDto<T>
{ 
    public T Data { get; set; }  
    [JsonIgnore]
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; }  

    public CustomResponseDto()
    {
    }

    public CustomResponseDto(T data, int statusCode)
    {
        Data = data;
        StatusCode = statusCode;
    }

    public CustomResponseDto(int statusCode)
    {
        StatusCode = statusCode;
    }

    public CustomResponseDto(int statusCode, List<string> errors)
    {
        StatusCode = statusCode;
        Errors = errors;
    }

    public CustomResponseDto(int statusCode, string error)
    {
        StatusCode = statusCode;
        Errors = new List<string> { error };
    }

    public static CustomResponseDto<T> Success(int statusCode, T data)
    {
        return new CustomResponseDto<T>(data, statusCode);
    }

    public static CustomResponseDto<T> Success(int statusCode)
    {
        return new CustomResponseDto<T>(statusCode);
    }

    public static CustomResponseDto<T> Fail(int statusCode, List<string> errors)
    {
        return new CustomResponseDto<T>(statusCode, errors);
    }

    public static CustomResponseDto<T> Fail(int statusCode, string error)
    {
        return new CustomResponseDto<T>(statusCode, new List<string> { error });
    }
}