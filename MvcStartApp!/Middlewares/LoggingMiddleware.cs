using MvcStartApp.Models.Db;
using MvcStartApp.Repository;

namespace MvcStartApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;

        public LoggingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IBlogRepository blogRepo)
        {
            Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");

            await _next.Invoke(context);

            var request = new Request
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = context.Request.Path
            };

            await blogRepo.SaveRequest(request);
        }
    }
}
