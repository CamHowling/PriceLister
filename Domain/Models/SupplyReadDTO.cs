using System;

namespace buildxact_supplies.Domain.Models
{
    public class SupplyReadDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Uom { get; set; }
        public int PriceInCents { get; set; }
        public Guid ProviderId { get; set; }
        public string MaterialType { get; set; }
    }
}
