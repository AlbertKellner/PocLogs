using Microsoft.AspNetCore.Http;
using PocLogs.Api.Middlewares;

namespace PocLogs.Tests;

public class CorrelationIdMiddlewareTests
{
    [Theory]
    [InlineData("existing-id")]
    [InlineData(null)]
    public async Task Middleware_SetsCorrelationId(string? id)
    {
        var context = new DefaultHttpContext();
        if (id is not null)
            context.Request.Headers["X-Correlation-Id"] = id;

        var middleware = new CorrelationIdMiddleware(_ => Task.CompletedTask);
        await middleware.InvokeAsync(context);

        Assert.True(context.Response.Headers.ContainsKey("X-Correlation-Id"));
        var header = context.Response.Headers["X-Correlation-Id"].ToString();
        if (id is not null)
            Assert.Equal(id, header);
        else
            Assert.False(string.IsNullOrEmpty(header));
    }
}
