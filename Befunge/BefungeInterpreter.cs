using System;
using System.Collections.Generic;
using Befunge.Runtime;

namespace Befunge
{
    public class BefungeInterpreter {

        public static string interpret(string befungeCode) {

            
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode);
            
            while (!runTime.EndProgram) {
                runTime.ExecuteInstruction();
            }

            return runTime.Output;
            
        }
    }
}