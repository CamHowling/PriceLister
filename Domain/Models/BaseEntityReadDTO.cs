using buildxact_supplies.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace buildxact_supplies.Domain.Models
{
    public class BaseEntityReadDTO
    {
        public List<PartnerReadDTO> Partners { get; set; }
    }
}
