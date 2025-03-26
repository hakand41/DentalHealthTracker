using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

public class JwtBlacklistMiddleware
{
    private readonly RequestDelegate _next;

    public JwtBlacklistMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        var token = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        if (!string.IsNullOrEmpty(token) && DentalHealthTracker.API.Controllers.AuthController.IsTokenBlacklisted(token))
        {
            context.Response.StatusCode = 401; // Unauthorized
            await context.Response.WriteAsync("Token geçersiz veya süresi dolmuş.");
            return;
        }

        await _next(context);
    }
}
