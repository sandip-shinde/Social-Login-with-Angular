using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Xpanxion.MicroService.Api
{
    public class Program
    {
	    public static IConfigurationRoot Configuration { get; set; }
	    public static IConfigurationBuilder ConfigurationBuilder { get; set; }
		public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseIISIntegration()
                .UseStartup<Startup>()
	            .ConfigureAppConfiguration((ctx, builder) =>
	            {
		            builder.SetBasePath(ctx.HostingEnvironment.ContentRootPath)
			            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
			            .AddJsonFile($"appsettings.{ctx.HostingEnvironment.EnvironmentName}.json", optional: true)
			            .AddEnvironmentVariables();
		            ConfigurationBuilder = builder;
		            Configuration = builder.Build();
		            ConfigurationBuilder.AddAzureKeyVault(
			            $"https://{Configuration["KeyVault:vault"]}.vault.azure.net/",
			            Configuration["KeyVault:clientId"],
			            Configuration["KeyVault:clientSecret"]
		            );
				})			
	            //.UseUrls("http://*:5001")	            
	            .ConfigureServices(s => s.AddSingleton(Configuration))
	            .ConfigureServices(s => s.AddSingleton(ConfigurationBuilder))
				.Build();	    	
	}
}
