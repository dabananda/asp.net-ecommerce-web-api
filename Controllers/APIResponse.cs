using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ASP.NET_Ecommerce_Web_API.Controllers
{
    public class APIResponse<T>
    {
        public bool Success { get; set; }
        public T? Data { get; set; }
        public string? Message { get; set; } = string.Empty;
        public List<string>? Errors { get; set; }
        public int StatusCode { get; set; }
        public DateTime TimeStamp { get; set; }

        // Constructor for response
        public APIResponse(bool success, T? data, string? message, int statusCode, List<string>? errors)
        {
            Success = success;
            Data = data;
            Message = message;
            StatusCode = statusCode;
            TimeStamp = DateTime.UtcNow;
            Errors = errors ?? new List<string>();
        }

        // Static method for creating a succesful response
        public static APIResponse<T> SuccessfullResponse(T? data, int statusCode, string message = "")
        {
            return new APIResponse<T>(true, data, message, statusCode, null);
        }

        // Static method for creting error response
        public static APIResponse<T> ErrorResponse(List<string> errors, int statusCode, string message = "")
        {
            return new APIResponse<T>(false, default!, message, statusCode, errors);
        }
    }
}