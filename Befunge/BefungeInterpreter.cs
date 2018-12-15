using System;
using System.Collections.Generic;
using Befunge.Runtime;

namespace Befunge
{
    public class BefungeInterpreter {

        public static string interpret(string befungeCode) {

            
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode);
            
            int i = 0;

            while (i < 1000 && !runTime.EndProgram) {

                runTime.ExecuteInstruction();

                i++;
            }

            return runTime.Output;
            
        }
    }
}