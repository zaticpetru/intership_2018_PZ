using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShallNotPass
{
    public enum MotoType {
        Mini = 50,
        Small = 125,
        Medium = 400,
        Big = 600,
        Heavy = 1000,
        ExtraHeavy = 1200
    }
    public abstract class Motorcicle{

        protected int ProductionYear;

        protected int EngineDisplacement;

        protected MotoType T;

        public string GetTypeOfMoto()
        {
            switch (T){
                case MotoType.Mini: return nameof(MotoType.Mini);
                case MotoType.Small: return nameof(MotoType.Small);
                case MotoType.Medium: return nameof(MotoType.Medium);
                case MotoType.Big: return nameof(MotoType.Big);
                case MotoType.Heavy: return nameof(MotoType.Heavy);
                case MotoType.ExtraHeavy: return nameof(MotoType.ExtraHeavy);
                default: return "unknown";
            }
        }

        public void SetTypeOfMoto()
        {
            if (EngineDisplacement < (int)MotoType.Mini) T = MotoType.Mini;
            else if (EngineDisplacement < (int)MotoType.Small) T = MotoType.Small;
            else if (EngineDisplacement < (int)MotoType.Medium) T = MotoType.Medium;
            else if (EngineDisplacement < (int)MotoType.Big) T = MotoType.Big;
            else if (EngineDisplacement < (int)MotoType.Heavy) T = MotoType.Heavy;
            else T = MotoType.ExtraHeavy;

        }

        protected string ModelName;
        public int Age
        {
            get { return DateTime.Now.Year - ProductionYear; }
        }

        protected DateTime? LastBuyDate = null;
        protected DateTime? LastSellDate = null;

        public void BuyMoto()
        {
            if (LastBuyDate == null)
                Console.WriteLine("Congratulation, you are the first buyer!!!!");
            LastBuyDate = DateTime.Now;
        }

        public void SellMoto()
        {
            if (LastSellDate == null)
                Console.WriteLine("Congratulation, you are the first seller!!!!");
            LastSellDate = DateTime.Now;
        }

        public string GetLastBuyDate()
        {
            if (LastBuyDate.HasValue)
                return Convert.ToString(LastBuyDate);
            else return "Motorcicle was not selled yet!";
        }

        public string GetLastSellDate()
        {
            if (LastSellDate.HasValue)
                return Convert.ToString(LastSellDate);
            else return "Motorcicle was not buyed yet!";
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
            SetTypeOfMoto();
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
                 + "\n you can buy NOW AND HERE!!! -> " + GetPrice() + " $\nA one year maintenance cost: " + YearMaintenancePrice() + "\nTotal mileage = " + mileage + " Type of moto: " + GetTypeOfMoto();
        }
    }
    class Program
    {

        static void Main(string[] args)
        {
            Sport kawa = Sport.Create("Kawasakii H2r", 2014, 1099);
            Road honda = Road.Create("Honda CB500", 1998, 999);

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
