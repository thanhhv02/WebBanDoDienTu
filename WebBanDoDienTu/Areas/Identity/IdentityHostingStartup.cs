﻿using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebBanDoDienTu.Areas.Identity.Data;
using WebBanDoDienTu.Data;

[assembly: HostingStartup(typeof(WebBanDoDienTu.Areas.Identity.IdentityHostingStartup))]
namespace WebBanDoDienTu.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<WebBanDoDienTuContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("WebBanDoDienTuContextConnection")));

                services.AddDefaultIdentity<WebBanDoDienTuUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<WebBanDoDienTuContext>();
            });
        }
    }
}