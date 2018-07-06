using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISPexample
{
    public interface IMotorcicle
    {
        int Engine_Displacement();
        int Horsepower();
        string GetTotalInformation();
    }

    public interface ISport: IMotorcicle
    {
        int GetUsedMotohours();
        int GetWins();
        int GetFails();
        int GetTotalParticipations();
    }
    
    public interface IRoad: IMotorcicle
    {
        int GetMileage();
        int GetYearOfIssue();
        string GetRegistrationNumber();
    }

    class KavasakiH2r : ISport
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
             return("\nEngine displacement: " + Engine_Displacement()
                + "\nFails: " + GetFails() + " Wins: " + GetFails() + " Total partitipation:" + GetTotalParticipations()
                + "\nMotohours used: " + GetUsedMotohours()
                + "\nHorsepowers: " + Horsepower() + "\n");
        }
    }

    class HondaCB500 : IRoad
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


    class Program
    {
        static void Main(string[] args)
        {
            HondaCB500 b = new HondaCB500();
            List<IMotorcicle> list = new List<IMotorcicle>();
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());
            list.Add(new KavasakiH2r());
            list.Add(new HondaCB500());
            list.Add(new KavasakiH2r());

            foreach(IMotorcicle moto in list)
            {
                Console.WriteLine(moto.GetTotalInformation());
            }


            foreach (IMotorcicle moto in list)
            {
                if (moto is ISport s)
                {
                    Console.WriteLine(s.GetWins());
                }
            }

            Console.ReadKey();

        }
    }
}
