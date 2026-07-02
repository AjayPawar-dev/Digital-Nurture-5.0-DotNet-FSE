using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeManagementApi.Filters
{
    public class CustomExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            string path = Path.Combine(
                Directory.GetCurrentDirectory(),
                "ErrorLog.txt");

            File.AppendAllText(
                path,
                $"[{DateTime.Now}] {context.Exception}{Environment.NewLine}");

            context.Result = new ObjectResult(new
            {
                Message = "Internal Server Error",
                Error = context.Exception.Message
            })
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };

            context.ExceptionHandled = true;
        }
    }
}