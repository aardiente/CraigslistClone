using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(CraigslistClone.Areas.Identity.IdentityHostingStartup))]

namespace CraigslistClone.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => { });
        }
    }
}
