using System;

namespace StackBasedCalculator
{

    //read uint and read ushort functions
    //return uint/ushort and
    //u4
    //u2
    //u1
    class Program
    {
        static void Main(string[] args)
        {
            Calculator cal = new Calculator();

            byte[] bytes = System.IO.File.ReadAllBytes(@"\\gmrdc1\Folder Redirection\Santiago.Gomez\Documents\VSCode\JAVA\JVMTesting\Program.class");

            //byte[] bytes = System.IO.File.ReadAllBytes(@"C:\Users\Santiago.Gomez\source\repos\Santiago-G\BinaryConverter\BinaryConverter\Program.cs");

            ClassLayout classFile = new ClassLayout(bytes);

            classFile.PrintInFormat();

            //classFile.DebugPrint();

            //cal.Push(2);
            //cal.Push(6);
            //cal.Divide();

            //cal.Push(3);
            //cal.Push(5);
            //cal.Multiple();
            //cal.Push(2);
            //cal.Add();
            //;

            //cal.Subtract();

            //Console.WriteLine(cal.stacky.Peek());
            //cal.Pop();

            Console.ReadKey();
        }
    }
}
