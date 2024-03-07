using buildxact_supplies.Services;
using buildxact_supplies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace SuppliesPriceLister
{
    class Program
    {
        static async void runHost(IHost host)
        {
            await host.RunAsync();
        }

        static void Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder(args);

            builder.ConfigureServices((hostContext, services) =>
              {
                  services.AddSingleton<IJsonService, JsonService>();
                  services.AddSingleton<ICsvService, CsvService>();
              });

            using (IHost host = builder.Build())
            {
                //Consider adding an intermediate service to demonstrate a more typical approach to DI
                //in the very least can method extract...
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    IJsonService jsonService = scope.ServiceProvider.GetRequiredService<IJsonService>();
                    ICsvService csvService = scope.ServiceProvider.GetRequiredService<ICsvService>();
                    var humphriesSupplies = csvService.GetSuppliesFromHumphries();
                    
                    foreach(var supply in humphriesSupplies)
                    {
                        Console.WriteLine(supply.ToString());
                    }
                    //structure:
                    //process humphries
                    //retrieve supplies
                    //process megacorp
                    //  This includes ensuring that all guids are unique - if they are not, need to adjust...
                    //  megacorp needs to be adjusted from USD to AUD
                    //retrieve megacorp

                    //sort all by price
                    //print with newline between; fields: Id, Item Name, and Price
                }

                runHost(host);
            }
        }
    }
}
