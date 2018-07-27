namespace StructuralExample
{
    class VisuaStudioFacade
    {
        TextEditor TextEditor;
        Compiller Compiller;
        CLR CLR;

        public VisuaStudioFacade(TextEditor textEditor, Compiller compiller, CLR clr)
        {
            TextEditor = textEditor;
            Compiller = compiller;
            CLR = clr;
        }

        public void CompileAndRun(MyFile Code)
        {
            TextEditor.WriteInFile(Code);
            TextEditor.Save(Code);
            Compiller.Compile(Code);
            CLR.Run(Code);
        }

        public void Stop(MyFile Code)
        {
            CLR.Stop(Code);
        }
    }
}
