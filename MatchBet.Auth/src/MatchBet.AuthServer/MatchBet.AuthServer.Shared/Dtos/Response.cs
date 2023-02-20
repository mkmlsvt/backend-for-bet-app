using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Shared.Dtos
{
    public class Response<T> where T: class
    {
        [AllowNull]
        public T Data { get; private set; }
        public int Status { get; private set; }
        public ErrorDto Error { get; set; }

        [JsonIgnore]
        public bool IsSuccessful { get; set; }

        public static Response<T> Success(T data, int statusCode)
        {
            return new Response<T> { Data = data, Status = statusCode, IsSuccessful = true };
        }
        public static Response<T> Success(int statusCode)
        {
            return new Response<T> {Data=default , Status = statusCode, IsSuccessful = true };
        }
        public static Response<T> Fail(int statusCode, ErrorDto errorDto) 
        {
            return new Response<T>
            {
                
                Error = errorDto,
                Status = statusCode,
                IsSuccessful = false

            };
        }
        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);

            return new Response<T> { Error = errorDto, Status = statusCode, IsSuccessful = false };
        }
    }
}
