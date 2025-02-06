using Microsoft.AspNetCore.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;

        public JwtMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var userId = context.User.Claims.FirstOrDefault()?.Value;
            var role = context.User.FindFirstValue(ClaimTypes.Role);

            if (!string.IsNullOrEmpty(userId))
            {
                context.Items["UserId"] = userId;
                context.Items["RoleId"] = role;
            }

            await _next(context);
        }
    }
}
