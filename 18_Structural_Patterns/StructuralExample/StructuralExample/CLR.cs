using System;
using System.Threading;

namespace Facade
{
    class CLR
    {
        public void Run(MyFile Code)
        {
            if(Code.IsCompiled && !Code.IsRuning)
            {
                Code.IsRuning = true;
                Console.WriteLine("Executing application");
                Thread.Sleep(400);
            }
            else Console.WriteLine("Error while try to run");
            
        }

        public void Stop(MyFile Code)
        {
            Code.IsRuning = false;
            Console.WriteLine("Stoping the application");
            Thread.Sleep(200);
        }
    }
}
