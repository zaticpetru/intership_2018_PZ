using System;
using System.Collections.Generic;
using System.Linq;

namespace YouShallNotPass
{

    public class Base
    {

    }

    public class Derived: Base
    {

    }

    public class SubDerived : Derived
    {

    }


    public interface ICovariant< T>
    {

    }

    //public class Covarinat<T> : ICovariant<T>
    //{

    //}



    public class Covarinat<Derived> : ICovariant<Base>
    {

    }





    class Program
    {





        static void Main(string[] args)
        {

            Base b = new Derived();
            ICovariant<Base> r = new Covarinat<SubDerived>();



















            Dictionary<Motorcicle, Owner> AllMoto = new Dictionary<Motorcicle, Owner>();

            Owner KawasakiCo = new Owner("Kawasaki", "Corporation", true);
            Owner HondaMotors = new Owner("Honda", "Motors", true);

            Sport kawa = Sport.Create("Kawasakii H2r", 2014, 1099);
            AllMoto[kawa] = KawasakiCo;

            RoadMoto honda = RoadMoto.Create("Honda CB500", 1998, 999);
            AllMoto[honda] = HondaMotors;

            Console.WriteLine(kawa.GetTotalInformation() + "\n\n");
            Console.WriteLine(honda.GetTotalInformation()+ "\n\n");

            honda.AddMileage(100000);
            honda.UpdateTC(7243);

            kawa.AddMileage(3526);
            kawa.AfterRace(97, true);
            kawa.AfterRace(3, false);

            honda.BuyMoto();
            Owner Vasile = new Owner("Vasile", "Boboc", false);
            AllMoto[honda] = Vasile;

            Console.WriteLine(kawa.GetTotalInformation() + "\n\n");
            Console.WriteLine(honda.GetTotalInformation() + "\n\n");

            Repository<Motorcicle,int> DataBase = new Repository<Motorcicle,int>();
            DataBase.AddRange(new List<Motorcicle> { kawa, honda, kawa, kawa });

            string interpolationTest = "testing this pice of s";
            Console.WriteLine($"{interpolationTest} la la la ");

            Console.ReadKey();
        }
    }
}
