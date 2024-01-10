using System.Security.Claims;


namespace Application
{
    public interface IUserService
    {
        ClaimsPrincipal GetUser();
        int? GetUserId();
        int? GetUserCountry();
        string? GetUserIdaddress();
    }
}
