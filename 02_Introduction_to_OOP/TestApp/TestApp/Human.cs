using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Human
    {
        private Hand left = new Hand('l');
        private Hand right = new Hand('r');

        private string name;
        public string Name { get => name; set => name = value; }

        public Human(string Name)
        {
            name = Name;
        }

        public void Sing()
        {
            Console.WriteLine(name + " will sing a guitar song!!!");
            left.TakeGuitar();
            right.PlayGuitar();
            Console.WriteLine("Tanks a lot for " + name + "\n");

        }
    }
}
