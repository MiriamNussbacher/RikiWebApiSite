using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ShopSite.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PageNotFoundMiddleware
    {
        private readonly RequestDelegate _next;

        public PageNotFoundMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            await _next(httpContext);

            if (httpContext.Response.StatusCode == 404)
            {
                httpContext.Response.ContentType = "text/html";
                await httpContext.Response.SendFileAsync("./wwwroot/404.html");
            }


        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PageNotFoundMiddlewareExtensions
    {
        public static IApplicationBuilder UsePageNotFoundMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PageNotFoundMiddleware>();
        }
    }
}
