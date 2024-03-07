using buildxact_supplies.Services.Interfaces;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using buildxact_supplies.Domain.Entities;
using buildxact_supplies.Domain.Models;
using System;

namespace buildxact_supplies.Services
{
    public class JsonService : IJsonService
    {
        public List<Supply> GetSuppliesFromMegacorp()
        {
            var supplyDTOs = ReadMegacorp();
            var supplies = new List<Supply>();
            foreach (var supplyDTO in supplyDTOs)
            {
                var supply = new Supply(
                   Guid.NewGuid(),
                   supplyDTO.Description,
                   supplyDTO.Uom,
                   costAud: null,
                   costUsd: supplyDTO.PriceInCents / 100,
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
