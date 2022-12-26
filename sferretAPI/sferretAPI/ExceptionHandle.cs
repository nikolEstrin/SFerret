using Newtonsoft.Json;
using System.Net;

namespace sferretAPI
{
    public class ExceptionHandle
    {
        private readonly RequestDelegate requestDelegate;
        public ExceptionHandle(RequestDelegate requestDelegate)
        {
            this.requestDelegate = requestDelegate;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await requestDelegate(context);
            }
            catch (Exception ex)
            {
                await HandleException(context, ex);
            }
        }
        
        private async Task HandleException(HttpContext context, Exception ex)
        {
            
            var errorMessage = JsonConvert.SerializeObject(new { Message = ex.Message, Code = "GE" });

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            await context.Response.WriteAsync(errorMessage);
            //return context.Response.WriteAsync(errorMessage);
        }
    }
}
