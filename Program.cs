using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using GithubPfSm.Services;
using Blazored.LocalStorage;

namespace GithubPfSm
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("app");

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
            builder.Services.AddAntDesign();
            builder.Services.AddBlazoredLocalStorage(config =>
       config.JsonSerializerOptions.WriteIndented = true);
            builder.Services.AddScoped<GithubService>();
            builder.Services.AddScoped<UserService>();
            await builder.Build().RunAsync();
        }
    }
}
