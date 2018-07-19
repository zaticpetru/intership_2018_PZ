using System;
using System.Collections.Generic;
using System.Linq;

namespace YouShallNotPass
{
    class Program
    {
        static void Main(string[] args)
        {

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

            Repository<Motorcicle> DataBase = new Repository<Motorcicle>();
            DataBase.AddRange(new List<Motorcicle> { kawa, honda, kawa, kawa });



            Console.ReadKey();
        }
    }
}
