using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ClienteApi.Middleware
{
    public class ApiKeyMiddleware
    {
        private const string HeaderName = "X-API-KEY";
        private readonly RequestDelegate _next;
        private readonly string _validApiKey;

        public ApiKeyMiddleware(RequestDelegate next, IConfiguration config)
        {
            _next = next;
            _validApiKey = config["ApiKey"] ?? throw new ArgumentNullException("ApiKey");
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (!context.Request.Headers.TryGetValue(HeaderName, out var extractedKey) ||
                extractedKey != _validApiKey)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("API KEY Perdida o Invalida.");
                return;
            }

            await _next(context);
        }
    }

    // Extension para registrar
    public static class ApiKeyMiddlewareExtensions
    {
        public static IApplicationBuilder UseApiKeyValidation(this IApplicationBuilder app) =>
            app.UseMiddleware<ApiKeyMiddleware>();
    }
}
