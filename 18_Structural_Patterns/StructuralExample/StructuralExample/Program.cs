using System;

namespace Facade
{
    class MyFile
    {
        public string Information = null;
        public bool IsWrited = false;
        public bool IsSaved = false;
        public bool IsCompiled = false;
        public bool IsRuning = false;
    }
    class Program
    {
        static void Main(string[] args)
        {
            MyFile MyCode = new MyFile() { Information = "test it" };
            TextEditor vim = new TextEditor();
            Compiller GCC = new Compiller();
            CLR myCLR = new CLR();
            VisuaStudioFacade visualStudio = new VisuaStudioFacade(vim, GCC, myCLR);

            visualStudio.CompileAndRun(MyCode);
            //visualStudio.Stop(MyCode);
            vim.WriteInFile(MyCode);

            Console.ReadKey();
        }  
    }
}
