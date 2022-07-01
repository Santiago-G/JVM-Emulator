using StackBasedCalculator.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using static StackBasedCalculator.Enums;

namespace StackBasedCalculator
{

    //read uint and read ushort functions
    //return uint/ushort and
    //u4
    //u2
    //u1
    class Program
    {
        public static Stack<uint> stack;
        public static uint[] locals;

        static void Main(string[] args)
        {
            byte[] bytes = System.IO.File.ReadAllBytes(@"\\gmrdc1\Folder Redirection\Santiago.Gomez\Documents\VSCode\JAVA\JVMTesting\Program.class");
            //bytes = System.IO.File.ReadAllBytes(@"C:\Users\Santiago.Gomez\source\repos\Santiago-G\BinaryConverter\BinaryConverter\Program.cs");

            stack = new Stack<uint>();
            

            ClassLayout classFile = new ClassLayout(bytes);

            Method_Info main = classFile.FindMain();
            ;
            //Method_Info otherFunction = classFile.FindMethod("main");
            main.Execute(classFile.Constant_pool, classFile);


            byte[] barryBBenson = classFile.ToByte(bytes);

            classFile.PrintInFormat(bytes);

            //classFile.DebugPrint();

            #region the stack based calculator
            //Calculator stack = new Calculator();
            //cal.Push(2);
            //cal.Push(6);
            //cal.Divide();

            //cal.Push(3);
            //cal.Push(5);
            //cal.Multiple();
            //cal.Push(2);
            //cal.Add();

            //cal.Subtract();
            //Console.WriteLine(cal.stacky.Peek());
            //cal.Pop();
            #endregion

            Console.ReadKey();
        }
    }
}
