using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using NachtWieselVoting.BusinessLogic.CommonServices;

namespace NachtWieselVoting.BusinessLogic.DependencyInjectionExtensions;

public static class AuthExtensions
{
    public static IServiceCollection AddCookieAuth(this IServiceCollection services)
    {
        services.AddTransient<IUserManager, UserManager>()
            .AddHttpContextAccessor()
            .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login";
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
            });
        return services.AddAuthorizationCore();
    }

    public static void MapLogout(this WebApplication app)
    {
        app.MapGet("/Logout", async (IUserManager _userManager) =>
        {
            await _userManager.SignOutAsync();
            return Results.Redirect("/");
        });
    }
}
