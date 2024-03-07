using buildxact_supplies.Services;
using buildxact_supplies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Linq;

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
                //in the very least can method extract...
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    IJsonService jsonService = scope.ServiceProvider.GetRequiredService<IJsonService>();
                    ICsvService csvService = scope.ServiceProvider.GetRequiredService<ICsvService>();
                    var humphriesSupplies = csvService.GetSuppliesFromHumphries();
                    var megacorpSupplies = jsonService.GetSuppliesFromMegacorp();

                    var supplies = humphriesSupplies.Concat(megacorpSupplies);
                    var sortedSupplies = supplies.OrderByDescending(supply => supply.Price);
                    foreach(var supply in sortedSupplies)
                    {
                        Console.WriteLine(supply.ToString());
                        Console.WriteLine();
                    }

                    //process megacorp
                    //  This includes ensuring that all guids are unique - if they are not, need to adjust...
                    //  megacorp needs to be adjusted from USD to AUD
                    //retrieve megacorp
                }

                runHost(host);
            }
        }
    }
}
