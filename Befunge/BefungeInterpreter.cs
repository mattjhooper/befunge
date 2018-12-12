using System;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge
{
    public class BefungeInterpreter {
        private static CoOrds currPos;
        //private static List<string[]> codeGrid;

        private static Dictionary<char,IInstruction> instuctionsLookup;

        public static string interpret(string befungeCode) {

            currPos = new CoOrds(0,0);
            
            instuctionsLookup = new Dictionary<char, IInstruction>();
            instuctionsLookup.Add('+', new Add());
            instuctionsLookup.Add('-', new Subtract());
            instuctionsLookup.Add('*', new Multiply());
            instuctionsLookup.Add('/', new Divide());
            instuctionsLookup.Add('%', new Modulo());
            instuctionsLookup.Add('!', new LogicalNot());
            instuctionsLookup.Add('`', new GreaterThan());
            instuctionsLookup.Add('.', new Period());

            IInstruction defaultInstruction = new NumberDefault();
            IBefungeRunTime runTime = new BefungeRunTime();
            runTime.CurrentInstruction = befungeCode[currPos.x];

            while (runTime.CurrentInstruction != '@') {
                IInstruction currentInstruction = instuctionsLookup.GetValueOrDefault(runTime.CurrentInstruction, defaultInstruction);
                currentInstruction.Execute(runTime);

                runTime.CurrentInstruction = befungeCode[++currPos.x];
            }

            return runTime.Output;
            
        }
    }
}