using System;
using System.IO;

namespace Befunge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello Befunge World!");
            //Console.WriteLine(BefungeInterpreter.Interpret(">987v>.v\nv456<  :\n>321 ^ _@"));
            //BefungeInterpreter.Interpret("2>:3g\" \"-!v\\  g30          <\n |!`\"&\":+1_:.:03p>03g+:\"&\"`|\n @               ^  p3\\\" \":<\n2 2345678901234567890123456789012345678");
            //Console.WriteLine(BefungeInterpreter.Interpret(">v \n>?<\n ^ \n"));
            //BefungeInterpreter.Interpret(" v>>>>>v\n  12345 \n ^?^    \n> ? ?^  \n  v?v   \n  678@  \n  >>>> v\n ^    .<");
            //BefungeInterpreter.Interpret(">1.v   >4.\n   >2.>?<\n       >3.@");
            //BefungeInterpreter.Interpret("v\n> ^@");

            using (StreamWriter sw = new StreamWriter("befunge_output.txt"))
            {
               //BefungeInterpreter.Interpret(">.@");
               //BefungeInterpreter.Interpret("v\n> ^@");
               //BefungeInterpreter.Interpret(">7 : 1v1:<\n      `  .\n      !  :\n    @._2/^ ");
               BefungeInterpreter.Interpret(">9 : 2v2:    <\n      `      .\n      !      :\n@,\"t\"._2/:2%!|\n             >\"f\",@");
            }
        }
    }
}
