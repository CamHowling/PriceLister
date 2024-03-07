using System.Collections.Generic;

namespace buildxact_supplies.Domain.Models
{
    public class PartnerReadDTO
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public List<SupplyReadDTO> Supplies { get; set; }
    }
}
