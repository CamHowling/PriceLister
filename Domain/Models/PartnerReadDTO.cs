using buildxact_supplies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
