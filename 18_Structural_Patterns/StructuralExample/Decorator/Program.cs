using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    public abstract class Mobile
    {
        protected string Descriprion = "Unknown description";
        public virtual string GetDescription() { return Descriprion; }
    }

    public abstract class GadgetDecorator : Mobile
    {
        public override abstract string GetDescription();
    }

    public class Htc : Mobile
    {
        public Htc()
        {
            Descriprion = "Model: HTC\n";
        }
    }

    public class Husa : GadgetDecorator
    {
        Mobile Mobile;
        string HusaType = "";
        public Husa(Mobile mobile)
        {
            Mobile = mobile;
        }
        public Husa(Mobile mobile, string husaType)
        {
            Mobile = mobile;
            HusaType = husaType;
        }

        public override string GetDescription()
        {
            return Mobile.GetDescription() + "With husa " + HusaType + "\n";
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Mobile test = new Htc();
            test = new Husa(test);

            Mobile test1 = new Htc();

            Mobile test2 = new Htc();
            test2 = new Husa(test);
            test2 = new Husa(test, "Wery Beautyfull husaa");

            Console.WriteLine(test.GetDescription()); 
            Console.WriteLine(test1.GetDescription()); 
            Console.WriteLine(test2.GetDescription());

            Console.ReadKey();
        }
    }
}
