// https://northwind.now.sh/

using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BlazorPWA5Along.DataServices;

namespace BlazorPWA5Along
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");

            builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            //builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri("https://northwind.now.sh/api/") });

            builder.Services.AddSingleton<ProductsService>();

            await builder.Build().RunAsync();
        }
        //https://northwind.now.sh/api/
    }
}
