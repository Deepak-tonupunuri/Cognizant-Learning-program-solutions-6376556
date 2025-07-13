using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.IO;

namespace WebApi.Filters
{
    public class CustomExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            string message = $"[{DateTime.Now}] Exception: {context.Exception.Message}\n{context.Exception.StackTrace}";
            File.AppendAllText("error_log.txt", message + "\n\n");

            context.Result = new ObjectResult("An error occurred. Please contact admin.")
            {
                StatusCode = 500
            };
        }
    }
}
