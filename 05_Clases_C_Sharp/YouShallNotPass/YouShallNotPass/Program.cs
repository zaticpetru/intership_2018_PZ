using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YouShallNotPass
{
    class Program
    {
        static void Main(string[] args)
        {
            Sport kawa = Sport.Create("Kawasakii H2r", 2014, 1099);
            RoadMoto honda = RoadMoto.Create("Honda CB500", 1998, 999);

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
