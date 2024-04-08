using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace SharedLib.Dtos
{
    public class AppResponse<T>
    {
        public T Data { get; set; }
        public int StatusCode { get; set; }
        public List<string> Errors { get; set; }
        public static AppResponse<T> Success(T data, int statusCode=200)
        {
            return new AppResponse<T>
            {
                Data = data,
                StatusCode = statusCode
            };
        }
        public static AppResponse<T> Success(int statusCode=200)
        {
            return new AppResponse<T>
            {
                Data = default(T),
                StatusCode = statusCode
            };
        }
        public static AppResponse<T> Fail(List<string> errors, int statusCode)
        {
            return new AppResponse<T>
            {
                Errors = errors,
                StatusCode = statusCode
            };
        }
        public static AppResponse<T> Fail(string error, int statusCode)
        {
            return new AppResponse<T>
            {
                Errors = new List<string>() { error },
                StatusCode = statusCode
            };
        }
    }
}
