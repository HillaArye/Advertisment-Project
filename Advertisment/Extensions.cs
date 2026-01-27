using Advertisment.Middleware;

namespace Advertisment
{
    public static class Extensions
    {
        public static IApplicationBuilder UseHappyThursdayMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<HappyThursdayMiddleware>();
        }
    }
}
