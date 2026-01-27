namespace Advertisment.Middleware
{
    public class HappyThursdayMiddleware
    {
        private readonly RequestDelegate _next;
        public HappyThursdayMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            if (DayOfWeek.Thursday == DateTime.Now.DayOfWeek)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Response.ContentType = "text/plain; charset=utf-8";
                await context.Response.WriteAsync("🤩😊יום חמישי שמח!!");
                return;
            }
            await _next(context);

        }
    }
}
