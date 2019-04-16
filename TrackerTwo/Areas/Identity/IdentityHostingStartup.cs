using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrackerTwo.Data;
using TrackerTwo.Models;

[assembly: HostingStartup(typeof(TrackerTwo.Areas.Identity.IdentityHostingStartup))]
namespace TrackerTwo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                //This doesn't work. See https://stackoverflow.com/questions/52531131/asp-net-core-2-1-identity-role-based-authorization-access-denied for reason why. 
                // Also note that Policy-based Authorization appears to be the trend with .Net Core https://msdn.microsoft.com/en-us/magazine/mt826337.aspx
                //Also note - I should probably add a default policy to blanket access unless signed in and then use authorize = anon to explcitly declare when no user sign in is needed (more secure when adding pages)
                //services.AddDefaultIdentity<IdentityUser>().AddRoles<IdentityRole>()
                //    .AddEntityFrameworkStores<ApplicationDbContext>();


                services.AddIdentity<ApplicationUser, IdentityRole>()
        .AddRoleManager<RoleManager<IdentityRole>>()
        .AddDefaultUI()
        .AddDefaultTokenProviders()
        .AddEntityFrameworkStores<ApplicationDbContext>();

            });
        }
    }
}