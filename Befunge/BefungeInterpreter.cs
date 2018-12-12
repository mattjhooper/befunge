using System;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge
{
    public class BefungeInterpreter {
        private static CoOrds currPos;
        //private static List<string[]> codeGrid;

        private static Dictionary<char,IInstruction> instructionsLookup;

        public static string interpret(string befungeCode) {

            currPos = new CoOrds(0,0);
            
            instructionsLookup = new Dictionary<char, IInstruction>();
            instructionsLookup.Add('+', new Add());
            instructionsLookup.Add('-', new Subtract());
            instructionsLookup.Add('*', new Multiply());
            instructionsLookup.Add('/', new Divide());
            instructionsLookup.Add('%', new Modulo());
            instructionsLookup.Add('!', new LogicalNot());
            instructionsLookup.Add('`', new GreaterThan());
            instructionsLookup.Add('.', new Period());

            IInstruction defaultInstruction = new NumberDefault();
            IBefungeRunTime runTime = new BefungeRunTime();
            runTime.CurrentInstruction = befungeCode[currPos.x];

            while (runTime.CurrentInstruction != '@') {
                IInstruction currentInstruction = instructionsLookup.GetValueOrDefault(runTime.CurrentInstruction, defaultInstruction);
                currentInstruction.Execute(runTime);

                runTime.CurrentInstruction = befungeCode[++currPos.x];
            }

            return runTime.Output;
            
        }
    }
}