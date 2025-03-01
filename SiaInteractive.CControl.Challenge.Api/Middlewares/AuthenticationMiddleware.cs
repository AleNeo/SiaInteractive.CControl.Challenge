using Microsoft.AspNetCore.Http;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SiaInteractive.CControl.Challenge.Api.Middlewares;

public class AuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public AuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        await _next(context);

        if (context.GetEndpoint() is null &&
            context.Response.StatusCode == (int)HttpStatusCode.NotFound && 
            !context.User.Identity.IsAuthenticated)
        {
            context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
        }
    }
}