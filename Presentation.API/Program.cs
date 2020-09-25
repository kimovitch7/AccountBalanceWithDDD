using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NServiceBus;


namespace Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
             Host.CreateDefaultBuilder(args)
            .UseNServiceBus(Context =>
            {
                var endpointConfiguration = new EndpointConfiguration("AccountBalance.Presentation.API");
                endpointConfiguration.MakeInstanceUniquelyAddressable("1");
                //endpointConfiguration.EnableCallbacks();
                endpointConfiguration.UseTransport<LearningTransport>();
                return endpointConfiguration;
            })
            .ConfigureWebHostDefaults(webBuilder => webBuilder.UseStartup<Startup>());
    }
}
