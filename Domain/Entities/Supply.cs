using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buildxact_supplies.Domain.Entities
{
    public class Supply
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public string Uom { get; set; }
        public int PriceInCents { get; set; }
        public string ProviderId { get; set; }
        public string MaterialType { get; set; }
    }
}
