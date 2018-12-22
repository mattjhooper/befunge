using System;
using System.IO;
using System.Collections.Generic;
using Befunge.Runtime;
using Befunge.Mode;

namespace Befunge
{
    public class BefungeInterpreter {

        public static string Interpret(string befungeCode, TextWriter outputStream = null) {

            IMode mode = NumberMode.Instance;
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode, mode, outputStream);
            
            while (!runTime.EndProgram) {
                runTime.ExecuteInstruction();
            }

            return runTime.Output;
            
        }
    }
}