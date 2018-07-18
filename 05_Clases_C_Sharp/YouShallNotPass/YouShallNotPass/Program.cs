using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShallNotPass
{
    public abstract class Motorcicle{

        protected int ProductionYear;

        protected int EngineDisplacement;

        protected string ModelName;
        public int Age
        {
            get { return DateTime.Now.Year - ProductionYear; }
        }

        protected double mileage = 0;

        public void AddMileage(double mileage_passed)
        {
            if (mileage_passed > 0.001) mileage += mileage_passed;
        }
        public const bool IsItAwersome = true;
        public abstract int GetPrice();
        public abstract int YearMaintenancePrice();
        public abstract string GetTotalInformation();
    }

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

    class Road : Motorcicle
    {
        private Road(string ModelName, int ProductionYear, int EngineDisplacement)
        {
            this.ModelName = ModelName;
            this.ProductionYear = ProductionYear;
            this.EngineDisplacement = EngineDisplacement;
        }

        private DateTime NextTC = DateTime.Now.AddDays(60);

        public int GetDaysUntilNextTC()
        {
            return (int)(NextTC - DateTime.Now).TotalDays;
        }

        public bool UpdateTC(int regNumber)
        {
            if (regNumber == 7243)
            {
                NextTC = DateTime.Now.AddDays(90);
                return true;
            }
            return false;
        }

        public static Road Create(string ModelName, int ProductionYear, int EngineDisplacement)
        {
            if (ProductionYear >= 1860 && EngineDisplacement >= 10 && !string.IsNullOrEmpty(ModelName)) return new Road(ModelName, ProductionYear, EngineDisplacement);
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
                 + "\n you can buy NOW AND HERE!!! -> " + GetPrice() + " $\nA one year maintenance cost: " + YearMaintenancePrice() + "\nTotal mileage = " + mileage;
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Sport kawa = Sport.Create("Kawasakii H2r", 2014, 1099);
            Road honda = Road.Create("Honda CB500", 1998, 500);

            Console.WriteLine(kawa.GetTotalInformation() + "\n\n");
            Console.WriteLine(honda.GetTotalInformation()+ "\n\n");

            honda.AddMileage(100000);
            honda.UpdateTC(7243);

            kawa.AddMileage(3526);
            kawa.AfterRace(97, true);
            kawa.AfterRace(3, false);

            Console.WriteLine(kawa.GetTotalInformation() + "\n\n");
            Console.WriteLine(honda.GetTotalInformation() + "\n\n");

            Console.ReadKey();
        }
    }
}
