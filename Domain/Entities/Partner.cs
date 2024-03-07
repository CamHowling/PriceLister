using System.Collections.Generic;

namespace buildxact_supplies.Domain.Entities
{
    public class Partner
    {
        public string Name { get; set; }
        public string PartnerType { get; set; }
        public string PartnerAddress { get; set; }
        public List<Supply> Supplies { get; set; }
    }
}
