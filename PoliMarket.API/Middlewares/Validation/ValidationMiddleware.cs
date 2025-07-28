using PoliMarket.Models.Enums;
using PoliMarket.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PoliMarket.API.Middlewares.Validation
{
    public class ValidationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRH _iRhService;

        public ValidationMiddleware(RequestDelegate next, IRH iRhService)
        {
            _next = next;
            _iRhService = iRhService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var endpoint = context.GetEndpoint();
            if (endpoint != null)
            {
                var permissionAttributes = endpoint.Metadata.GetOrderedMetadata<RequiresPermissionAttribute>();
                if (permissionAttributes.Any())
                {
                    if (!context.Request.Headers.TryGetValue("X-Username", out var username))
                    {
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                        await context.Response.WriteAsync("Missing X-Username header.");
                        return;
                    }

                    var userPermissions = GetPermissionsForUser(username);

                    foreach (var attr in permissionAttributes)
                    {
                        if (!userPermissions.Contains(attr.Permission))
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            await context.Response.WriteAsync("Forbidden: Missing required permission.");
                            return;
                        }
                    }
                }
            }

            await _next(context);
        }

        private List<SistemaEnum> GetPermissionsForUser(string username)
        {
            var user = _iRhService.ObtenerUsuario(username);
            return user?.Permisos?.Select(p => (SistemaEnum)p.IdSistema).ToList() ?? [];
        }
    }

}
