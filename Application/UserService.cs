using Azure.Core;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Application
{
    public class UserService : IUserService
    {
        private readonly IHttpContextAccessor accessor;

        public UserService(IHttpContextAccessor accessor)
        {
            this.accessor = accessor;
        }

        public ClaimsPrincipal GetUser()
        {
            return accessor?.HttpContext?.User as ClaimsPrincipal;
        }
        public int? GetUserId()
        {
            try
            {
                var x3 = accessor?.HttpContext?.Connection.RemoteIpAddress.MapToIPv4();
               var x2 = accessor?.HttpContext?.User as ClaimsPrincipal;
                return Convert.ToInt32( x2.FindFirst(ClaimTypes.Name).Value.ToString());
            }
            catch (Exception ex)
            {
                return null;
            }


        }

        public int? GetUserCountry()
        {
            try { 
               var x2 = accessor?.HttpContext?.User as ClaimsPrincipal;
            return Convert.ToInt32(x2.FindFirst("Country").Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        [Obsolete]
        public string? GetUserIdaddress()
        {
            try
            {
                var ip2 = accessor?.HttpContext?.Connection?.RemoteIpAddress?.ToString();
                var tt= new string[] { ip2, "value" };
                System.Net.IPAddress ip;
                var headers = accessor?.HttpContext?.Request.Headers.ToList();
                if (headers.Exists((kvp) => kvp.Key == "X-Forwarded-For"))
                {
                    // when running behind a load balancer you can expect this header
                    var header = headers.First((kvp) => kvp.Key == "X-Forwarded-For").Value.ToString();
                    // in case the IP contains a port, remove ':' and everything after
                    ip = System.Net.IPAddress.Parse(header.Remove(header.IndexOf(':')));
                }
                else
                {
                    // this will always have a value (running locally in development won't have the header)
                    ip = accessor?.HttpContext?.Request.HttpContext.Connection.RemoteIpAddress;
                }

                return ip?.ToString();
            
            }
            catch (Exception ex)
            {
                return null;
            }


        }

    }
}