using DShop.CrossCutting.MultiTenant;
using Microsoft.AspNetCore.Http;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace DsLine.Core.Services.Api
{
    public class TenantMiddleware
    {
        private readonly RequestDelegate _next;

        public TenantMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, ITenant Itenant)
        {
            if (httpContext.Request.Headers.Keys.Contains("Authorization"))
            {
                var tenant = httpContext.Request.Headers["Authorization"].ToString();
                Itenant.TenantId = tenant;
                var claim = new Claim(ClaimTypes.Authentication, tenant);
                var principal = new ClaimsPrincipal(new ClaimsIdentity(new[] { claim }, "Authorization"));
                httpContext.User = principal;
            }

            await _next(httpContext); // calling next middleware

        }
    }
}
