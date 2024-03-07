using buildxact_supplies.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using buildxact_supplies.Domain.Entities;
using buildxact_supplies.Domain.Models;
using System;
using Microsoft.Extensions.Configuration;

namespace buildxact_supplies.Services
{
    public class JsonService : IJsonService
    {
        private readonly IConfiguration _configuration;

        public JsonService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Supply> GetSuppliesFromMegacorp()
        {
            var exchangeRate = double.Parse(_configuration["audUsdExchangeRate"]);

            var supplyDTOs = ReadMegacorp();
            var supplies = new List<Supply>();
            foreach (var supplyDTO in supplyDTOs)
            {
                var supply = new Supply(
                   Guid.NewGuid(),
                   supplyDTO.Description,
                   supplyDTO.Uom,
                   costAud: (supplyDTO.PriceInCents / 100) * exchangeRate,
                   providerId: supplyDTO.ProviderId,
                   materialType: supplyDTO.MaterialType
                   );

                supplies.Add(supply);
            }

            return supplies;
        }

        private List<SupplyReadDTO> ReadMegacorp()
        {
            string startupPath = Path.GetFullPath(@"..\..\..\");
            string jsonPath = @"" + startupPath + "megacorp.json";

            string json = File.ReadAllText(jsonPath);
            var entity = JsonConvert.DeserializeObject<BaseEntityReadDTO>(json);

            var supplies = new List<SupplyReadDTO>();
            foreach (var partner in entity.Partners)
            {
                foreach (var supply in partner.Supplies)
                {
                    supplies.Add(supply);
                }
            }

            return supplies;
        }
    }
}
