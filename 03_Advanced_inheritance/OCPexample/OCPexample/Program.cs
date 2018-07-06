using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OCPexample
{

    class KavasakiH2r
    {
        public int Engine_Displacement()
        {
            return (998);
        }

        public int GetFails()
        {
            return (3);
        }

        public int GetWins()
        {
            return (97);
        }

        public int GetTotalParticipations()
        {
            return (GetWins() + GetFails());
        }

        public int GetUsedMotohours()
        {
            return (0);
        }

        public int Horsepower()
        {
            return (310);
        }

        public string GetTotalInformation()
        {
            return ("\nEngine displacement: " + Engine_Displacement()
               + "\nFails: " + GetFails() + " Wins: " + GetFails() + " Total partitipation:" + GetTotalParticipations()
               + "\nMotohours used: " + GetUsedMotohours()
               + "\nHorsepowers: " + Horsepower() + "\n");
        }
    }

    class HondaCB500
    {
        public int Engine_Displacement()
        {
            return (500);
        }

        public int GetMileage()
        {
            return (23025);
        }

        public string GetRegistrationNumber()
        {
            return ("QWD 220");
        }

        public int GetYearOfIssue()
        {
            return (1998);
        }

        public int Horsepower()
        {
            return (57);
        }

        public string GetTotalInformation()
        {
            return ("\nEngine displacement: " + Engine_Displacement()
               + "\nMileage: " + GetMileage() + " Registration number: " + GetRegistrationNumber() + " Year of issue:" + GetYearOfIssue()
               + "\nHorsepowers: " + Horsepower() + "\n");
        }
    }


    class KTM : Motocycle
    {
        public override string GetInformation()
        {
            return ("A good motorcycle for extrim!!!");
        }

        public override int GetPrice()
        {
            return 4500;
        }
    }

    class Ducati : Motocycle
    {
        public override string GetInformation()
        {
            return ("Italiano mujiko race!");
        }

        public override int GetPrice()
        {
            return 9000;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<object> list = new List<object>();
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());

            foreach (object moto in list)
            {
                if(moto is KavasakiH2r s)
                {
                    Console.WriteLine("This Kawasaki H2R moto win in : "  + s.GetWins() + " races");
                }

                if (moto is HondaCB500 r)
                {
                    Console.WriteLine("This HondaCB500 was produced in: " + r.GetYearOfIssue() + " year");
                }
            }


            Console.WriteLine("\n\n\nNOW THE CORRECT!!!");

            List<Motocycle> correct = new List<Motocycle>();
            correct.Add(new KTM());
            correct.Add(new Ducati());
            correct.Add(new KTM());
            correct.Add(new Ducati());
            correct.Add(new KTM());
            correct.Add(new Ducati());
            correct.Add(new Ducati());
            correct.Add(new Ducati());
            correct.Add(new Ducati());

            foreach (Motocycle i in correct)
            {
                Console.WriteLine(i.GetInformation() + " with only !!! - " + i.GetPrice() + "$");
            }

            Console.ReadKey();
        }
    }
}