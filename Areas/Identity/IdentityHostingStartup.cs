using System;
using HrProject.Areas.Identity.Data;
using HrProject.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(HrProject.Areas.Identity.IdentityHostingStartup))]
namespace HrProject.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<HrProjectContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("HrProjectContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;


                })
                    .AddEntityFrameworkStores<HrProjectContext>();
            });
        }
    }
}