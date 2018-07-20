using System;
using System.Collections;
using System.Collections.Generic;

namespace YouShallNotPass
{
    public abstract class Motorcicle : Entity<int>, IComparer<Motorcicle>, IEqualityComparer<Motorcicle>
    {
        protected int ProductionYear;

        protected int EngineDisplacement;

        protected MotoType MotoType;

        static int Number = 0;

        public Motorcicle()
        {
            Id = Number++;
        }


        public string GetTypeOfMoto()
        {
            switch (MotoType)
            {
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
            if (EngineDisplacement < (int)MotoType.Mini) MotoType = MotoType.Mini;
            else if (EngineDisplacement < (int)MotoType.Small) MotoType = MotoType.Small;
            else if (EngineDisplacement < (int)MotoType.Medium) MotoType = MotoType.Medium;
            else if (EngineDisplacement < (int)MotoType.Big) MotoType = MotoType.Big;
            else if (EngineDisplacement < (int)MotoType.Heavy) MotoType = MotoType.Heavy;
            else MotoType = MotoType.ExtraHeavy;
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

        public void AddMileage(double mileagePassed)
        {
            if (mileagePassed > 0.001) mileage += mileagePassed;
        }
        public const bool IsItAwersome = true;
        public abstract int GetPrice();
        public abstract int YearMaintenancePrice();
        public abstract string GetTotalInformation();

        public int Compare(Motorcicle t, Motorcicle p)
        {
            if (t.EngineDisplacement > p.EngineDisplacement) return 1;
            if (t.EngineDisplacement < p.EngineDisplacement) return -1;
            return 0;
        }

        //public override bool Equals(object x)
        //{
        //    Motorcicle t = (Motorcicle)x;
        //    Motorcicle p = (Motorcicle)y;

        //    bool rs;

        //    rs =(t.ModelName == p.ModelName) &&
        //        (t.MotoType == p.MotoType) &&
        //        (t.EngineDisplacement == p.EngineDisplacement) &&
        //        (t.ProductionYear == p.ProductionYear);

        //    return rs;

        //}

        public int GetHashCode(Motorcicle obj)
        {
            return Id*13+EngineDisplacement*17+ProductionYear;
        }

        public bool Equals(Motorcicle t, Motorcicle p)
        {
            bool rs;

            rs = (t.ModelName == p.ModelName) &&
                (t.MotoType == p.MotoType) &&
                (t.EngineDisplacement == p.EngineDisplacement) &&
                (t.ProductionYear == p.ProductionYear);

            return rs;

        }
    }
}
