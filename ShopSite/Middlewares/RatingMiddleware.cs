using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Services;
using Entities; 

namespace ShopSite.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class RatingMiddleware
    {
        private readonly RequestDelegate _next;

        public RatingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext,IRatingService ratingService)
        {
            Rating rating = new()
            {
            Host = httpContext.Request.Host.Host,
            Method= httpContext.Request.Method,
            Path=httpContext.Request.Path,
            Referer = httpContext.Request.Headers["Referer"],
            UserAgent= httpContext.Request.Headers["User-Agent"], 
            RecordDate=DateTime.Now
 
            };
            ratingService.AddRating(rating); 
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class RatingMiddlewareExtensions
    {
        public static IApplicationBuilder UseRatingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RatingMiddleware>();
        }
    }
}
