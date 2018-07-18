using System;

namespace YouShallNotPass
{
    class RoadMoto : Motorcicle
    {
        private RoadMoto(string modelName, int ProductionYear, int EngineDisplacement)
        {
            ModelName = modelName;// check or  throw new ArgumentNullException(nameof(modelName));

            ModelName = modelName;
            this.ProductionYear = ProductionYear;
            this.EngineDisplacement = EngineDisplacement;
            SetTypeOfMoto();
        }

        private DateTime NextTechnicalCheck = DateTime.Now.AddDays(60);

        public int GetDaysUntilNextTC()
        {
            return (int)(NextTechnicalCheck - DateTime.Now).TotalDays;
        }

        public bool UpdateTC(int regNumber)
        {
            if (regNumber == 7243)
            {
                NextTechnicalCheck = DateTime.Now.AddDays(90);
                return true;
            }
            return false;
        }

        public static RoadMoto Create(string ModelName, int ProductionYear, int EngineDisplacement)
        {
            var isValidProduction = ProductionYear >= 1860;
            if (isValidProduction && EngineDisplacement >= 10 && !string.IsNullOrEmpty(ModelName))
                return new RoadMoto(ModelName, ProductionYear, EngineDisplacement);
            return null;
        }

        public override int GetPrice()
        {
            return Age * 600;
        }
        public override int YearMaintenancePrice()
        {
            return Age ^ 2 / 2;
        }
        public override string GetTotalInformation()
        {
            return ModelName + " produced in " + ProductionYear + ", days until next tehnical revision " + GetDaysUntilNextTC() 
                 + "\n you can buy NOW AND HERE!!! -> " + GetPrice() + " $\nA one year maintenance cost: " + YearMaintenancePrice() + "\nTotal mileage = " + mileage + " Type of moto: " + GetTypeOfMoto();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
