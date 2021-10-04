using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Travel_Experts__Workshop_4.Areas.Identity.Data;
using Travel_Experts__Workshop_4.Data;

[assembly: HostingStartup(typeof(Travel_Experts__Workshop_4.Areas.Identity.IdentityHostingStartup))]
namespace Travel_Experts__Workshop_4.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<Travel_Experts__Workshop_4Context>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("Travel_Experts__Workshop_4ContextConnection")));

                services.AddDefaultIdentity<Travel_Experts__Workshop_4User>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                })
                    .AddEntityFrameworkStores<Travel_Experts__Workshop_4Context>();
            });
        }
    }
}