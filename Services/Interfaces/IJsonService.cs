using buildxact_supplies.Domain.Entities;
using System.Collections.Generic;

namespace buildxact_supplies.Services.Interfaces
{
    public interface IJsonService
    {
        List<Supply> GetSuppliesFromMegacorp();
    }
}
