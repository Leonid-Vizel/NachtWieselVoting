using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using NachtWieselVoting.Data.Entities;
using System.Security.Claims;

namespace NachtWieselVoting.BusinessLogic.CommonServices;

public interface IUserManager
{
    bool GetAuthState();
    int? GetUserId();
    string? GetName();
    Task SignOutAsync();
    Task SignInAsync(UserEntity user);
}

public sealed class UserManager(IHttpContextAccessor _contextAccessor) : IUserManager
{
    public async Task SignOutAsync()
    {
        var context = _contextAccessor.HttpContext;
        if (context == null)
        {
            return;
        }
        await context.SignOutAsync();
    }

    public bool GetAuthState()
    {
        var context = _contextAccessor.HttpContext;
        if (context == null)
        {
            return false;
        }
        return context.User.Identities.Any(ident => ident.IsAuthenticated);
    }

    public int? GetUserId()
    {
        var context = _contextAccessor.HttpContext;
        if (context == null)
        {
            return null;
        }
        var idClaim = context.User.Identities.SelectMany(ident => ident.Claims).FirstOrDefault(claim => claim.Type == nameof(UserEntity.Id));
        if (idClaim == null)
        {
            return null;
        }
        var idRawValue = idClaim.Value;
        if (!int.TryParse(idRawValue, out var idLongValue))
        {
            return null;
        }
        return idLongValue;
    }
    public string? GetName()
    {
        var context = _contextAccessor.HttpContext;
        if (context == null)
        {
            return null;
        }
        var fiertNameClaim = context.User.Identities.SelectMany(ident => ident.Claims).FirstOrDefault(claim => claim.Type == nameof(UserEntity.Name));
        return fiertNameClaim?.Value;
    }

    public async Task SignInAsync(UserEntity user)
    {
        var context = _contextAccessor.HttpContext;
        if (context == null)
        {
            return;
        }
        List<Claim> claims =
        [
            new(nameof(user.Id), user.Id.ToString()),
            new(nameof(user.Login), user.Login),
            new(nameof(user.Name), user.Name),
        ];
        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(claimsIdentity);
        await context.SignInAsync(principal);
    }
}