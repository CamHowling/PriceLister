using buildxact_supplies.Services;
using buildxact_supplies.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


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
                using (IServiceScope scope = host.Services.CreateScope())
                {
                    IJsonService jsonService = scope.ServiceProvider.GetRequiredService<IJsonService>();
                    ICsvService csvService = scope.ServiceProvider.GetRequiredService<ICsvService>();
                    csvService.PrintHumphries();
                }

                runHost(host);
            }
        }
    }
}
