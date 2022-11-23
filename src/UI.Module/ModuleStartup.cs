using Lamar.Microsoft.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using ProgrammingWithPalermo.ChurchBulletin.UI.Api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UI.Module;

[assembly: HostingStartup(typeof(ModuleStartup))]
namespace UI.Module
{
    internal class ModuleStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            Console.WriteLine("Configuring module");
            builder.ConfigureServices(this.ConfigureServices);

            //Can also do
            //builder.Configure(app =>
            //{
            //    app.UseMiddleware<>();
            //});
        }

        private void ConfigureServices(IServiceCollection obj)
        {
            obj.AddControllersWithViews();
            var builder =  obj.AddRazorPages();
            obj.AddLamar(new UiServiceRegistry());
        }
    }
}
