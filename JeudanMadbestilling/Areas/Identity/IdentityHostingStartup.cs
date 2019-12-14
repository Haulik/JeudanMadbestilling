using System;
using JeudanMadbestilling.Areas.Identity.Data;
using JeudanMadbestilling.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(JeudanMadbestilling.Areas.Identity.IdentityHostingStartup))]
namespace JeudanMadbestilling.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<MadbestillingJeudanIContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("MadbestillingJeudanIContextConnection")));

                services.AddDefaultIdentity<MadbestillingJeudanUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<MadbestillingJeudanIContext>();
            });
        }
    }
}