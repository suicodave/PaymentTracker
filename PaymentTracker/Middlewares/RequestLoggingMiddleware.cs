using Microsoft.ApplicationInsights.DataContracts;
using System.Text;

namespace PaymentTracker.Middlewares
{
    public class RequestLoggingMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var method = context.Request.Method;

            var recordableMethods = new string[] {
                HttpMethod.Post.ToString(),
                HttpMethod.Put.ToString(),
            };

            context.Request.EnableBuffering();

            if (!recordableMethods.Any(x => x == method))
            {
                await next(context);

                return;
            }

            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                false,
                1024,
                true
                );

            var requestBody = await reader.ReadToEndAsync();

            context.Request.Body.Position = 0;

            var requestTelemetry = context.Features.Get<RequestTelemetry>();

            requestTelemetry?.Properties.Add("RequestBody", requestBody);

            await next(context);
        }
    }
}
