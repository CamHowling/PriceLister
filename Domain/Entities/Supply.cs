using System;
using System.Configuration;

namespace buildxact_supplies.Domain.Entities
{
    public class Supply
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public string UnitsOfMeasurement { get; set; }
        public double CostAud { get; set; }
        public Guid? ProviderId { get; set; }
        public string MaterialType { get; set; }

        public Supply(Guid id, string description, string unitsOfMeasurement, double costAud, Guid? providerId, string materialType) 
        { 
            Id = id;
            Description = description;
            UnitsOfMeasurement = unitsOfMeasurement;
            CostAud = costAud;
            ProviderId = providerId;
            MaterialType = materialType;
        }

        public override string ToString()
        {
            var output = Id.ToString() + ", " + Description + ", " + CostAud.ToString("N2");
            return output;
        }
    }
}
