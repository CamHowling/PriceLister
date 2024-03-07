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

        public double Price
        {
            get
            {
                if (this.CostAud != null)
                {
                    var price = (double)this.CostAud;
                    return price;
                }

                if (this.CostUsd != null)
                {
                    var usdPrice = (double)this.CostUsd;
                    var price = usdPrice; //need to update to use utility class//appsettings
                    return price;
                }

                else return 0;
            }
        }

        public override string ToString()
        {
            var output = Id.ToString() + ", " + Description + ", " + Price.ToString("N2");
            return output;
        }
    }
}
