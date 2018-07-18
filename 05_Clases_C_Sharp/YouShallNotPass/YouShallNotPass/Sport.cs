namespace YouShallNotPass
{
    class Sport : Motorcicle
    {
        private Sport(string ModelName, int ProductionYear, int EngineDisplacement)
        {
            this.ModelName = ModelName;
            this.ProductionYear = ProductionYear;
            this.EngineDisplacement = EngineDisplacement;
        }
        public static Sport Create(string ModelName, int ProductionYear, int EngineDisplacement)
        {
            if (ProductionYear >= 1860 && EngineDisplacement >= 10 && !string.IsNullOrEmpty(ModelName)) return new Sport(ModelName, ProductionYear, EngineDisplacement);
            return null;
        }

        private int Wins = 0;
        private int Looses = 0;
        public int Races { get { return Wins + Looses; } }

        public void AfterRace(int HowManyRaces, bool isWiner)
        {
            if (isWiner) Wins += HowManyRaces;
            else Looses += HowManyRaces;
        }

        public override int GetPrice()
        {
            return (200 * ProductionYear);
        }

        public override string GetTotalInformation()
        {
            return ModelName + " produced in " + ProductionYear + ", particiated in " + Races + " races, where wins " +
                Wins + "\n you can buy it at only " + GetPrice() + " $\nA one year maintenance cost: " + YearMaintenancePrice() + "\nTotal mileage = " + mileage;
        }

        public override int YearMaintenancePrice()
        {
            return (Age + Races) * 12;
        }
    }
}
