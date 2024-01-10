using Microsoft.Extensions.Configuration;

namespace Hub_API.Settings
{
    public class TenantSettings
    {
        public Configuration Defaults { get; set; } = default!;
        public List<Tenant> Tenants { get; set; } = new();
    }
}
