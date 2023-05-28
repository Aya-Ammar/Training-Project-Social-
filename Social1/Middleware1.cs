using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Social1
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class Middleware1 : IMiddleware
    {



        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            ActionContext actioncontext = new ActionContext() { HttpContext = context };


            try
            {
                // Call the next middleware in the pipeline
                await next(context);
            }
            catch (Exception ex)
            {
                var result = new BadRequestObjectResult(ex.Message);
                //var res= new ObjectRe
                await result.ExecuteResultAsync(actioncontext);


                //context.Response.StatusCode =(int)HttpStatusCode.InternalServerError;
                //ProblemDetails details = new()
                //{
                //    Status=(int)HttpStatusCode.InternalServerError,
                //    Type="Server error",
                //    Title= "Server error",
                //    Detail="AN internal"

                //};
                //string json=JsonSerializer.Serialize(details);

                //await context.Response.WriteAsync(json);

                //context.Response.ContentType = "application/json";
            }
        }
    }
}



