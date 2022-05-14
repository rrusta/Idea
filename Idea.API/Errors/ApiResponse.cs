using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Idea.API.Errors
{
    public class ApiResponse
    {
        public ApiResponse(int statusCode,string message=null)
        {
            StatusCode = statusCode;
            Message = message ?? GetDefaultMessageForStatusCode(statusCode);
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        private string GetDefaultMessageForStatusCode(int statusCode)
        {
            return statusCode switch
            {
                400 => "A bad requests,you have made",
                401 => "Not Authorized",
                404 => "Resourse not found",
                500 => "Error Code 500",
                _ => null
            };
        }
    }
}
