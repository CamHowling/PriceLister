using System;


namespace buildxact_supplies.Domain.Entities
{
    public class Supply
    {
        public Guid Id { get; set; } 
        public string Description { get; set; }
        public string UnitsOfMeasurement { get; set; }
        public double? CostAud { get; set; }
        public double? CostUsd{ get; set; }
        public Guid? ProviderId { get; set; }
        public string MaterialType { get; set; }

        public Supply(Guid id, string description, string unitsOfMeasurement, double? costAud, double? costUsd, Guid? providerId, string materialType) 
        { 
            Id = id;
            Description = description;
            UnitsOfMeasurement = unitsOfMeasurement;
            CostAud = costAud;
            CostUsd = costUsd;
            ProviderId = providerId;
            MaterialType = materialType;
        }

        //need to update
        public double Price
        {
            get
            {
                return (double)this.CostAud;
            }
        }

        public override string ToString()
        {
            var output = this.Id.ToString() + ", " + this.Description + ", " + this.Price.ToString(); //potentially add toFixed(2)
            return output;
        }
    }
}
