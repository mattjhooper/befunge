using System;
using System.Collections.Generic;
using Befunge.Runtime;
using Befunge.Mode;

namespace Befunge
{
    public class BefungeInterpreter {

        public static string Interpret(string befungeCode) {

            IMode mode = NumberMode.Instance;
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode, mode);
            
            while (!runTime.EndProgram) {
                runTime.ExecuteInstruction();
            }

            return runTime.Output;
            
        }
    }
}