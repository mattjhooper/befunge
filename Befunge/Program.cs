﻿using System;

namespace Befunge
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine(BefungeInterpreter.interpret("Hello Befunge"));
        }
    }
}
