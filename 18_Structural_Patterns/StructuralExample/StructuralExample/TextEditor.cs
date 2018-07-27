using System;
using System.Threading;

namespace Facade
{
    class TextEditor
    {
        public void WriteInFile(MyFile Code)
        {
            if (Code.IsRuning)
            {
                Console.WriteLine("Please stop the aplication before making some changes");
                return;
            }
            if(Code.Information == null)
            {
                Console.WriteLine("Put some info in your file!");
                return;
            }
            Code.IsWrited = true;
            Console.WriteLine("Writiiiing...");
            Thread.Sleep(200);
        }

        public void Save(MyFile Code)
        {
            if(Code.IsWrited && !Code.IsRuning)
            {
                Code.IsSaved = true;
                Console.WriteLine("File Saving");
                Thread.Sleep(200);
            }
            else Console.WriteLine("error while saving");
        }
    }
}
