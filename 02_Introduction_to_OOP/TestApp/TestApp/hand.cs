using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Hand
    {
        private string intr;

        public Hand(char c)
        {
            SetHand(c);
        }

        public void SetHand(char c)
        {
            if (c == 'l') intr = " left hand";
            if (c == 'r') intr = " right hand";
        }

        public void PlayGuitar()
        {
            Console.WriteLine("drium drium drium with" + intr);
        }

        public void TakeGuitar()
        {
            Console.WriteLine("take guitar in" + intr);
        }
    }
}
