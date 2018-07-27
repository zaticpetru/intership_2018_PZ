using System;
using System.Threading;

namespace StructuralExample
{
    class Compiller
    {
        public void Compile(MyFile Code)
        {
            if (!Code.IsSaved)
            {
                Console.WriteLine("Code is not saved!, save the code and try again");
                return;
            }
            if(Code.IsCompiled)
            {
                Console.WriteLine("Code is already compiled");
                return;
            }
            Code.IsCompiled = true;
            Console.WriteLine("Compiling ...");
            Thread.Sleep(200);
        }
    }
}
