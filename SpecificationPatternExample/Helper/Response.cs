using System.Collections.Generic;

namespace SpecificationPatternExample.Helper
{
    public class Response<T>
    {
        public Response()
        {
        }
        public Response(T data, string message = null)
        {
            Succeeded = true;
            Message = message;
            Data = data;
        }
        public Response(string message)
        {
            Succeeded = false;
        }

        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<string> Errors { get; set; } = new List<string>();
        public T Data { get; set; }
    }


    public class Response
    {
        public Response(string code = "", string description = "")
        {
            resultCode = code;
            resultDescription = description;
        }

        public string resultCode { get; set; }
        public string resultDescription { get; set; }
    }
}