using System;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge
{
    public class BefungeInterpreter {
        //private static List<string[]> codeGrid;

        private static Dictionary<char,IInstruction> instructionsLookup;

        public static string interpret(string befungeCode) {

            instructionsLookup = new Dictionary<char, IInstruction>();
            instructionsLookup.Add('+', new Add());
            instructionsLookup.Add('-', new Subtract());
            instructionsLookup.Add('*', new Multiply());
            instructionsLookup.Add('/', new Divide());
            instructionsLookup.Add('%', new Modulo());
            instructionsLookup.Add('!', new LogicalNot());
            instructionsLookup.Add('`', new GreaterThan());
            instructionsLookup.Add('.', new Period());
            instructionsLookup.Add('>', new MoveRight());
            instructionsLookup.Add('<', new MoveLeft());
            instructionsLookup.Add('^', new MoveUp());
            instructionsLookup.Add('v', new MoveDown());
            instructionsLookup.Add(' ', new Space());
            instructionsLookup.Add(':', new Colon());
            instructionsLookup.Add('_', new Underscore());

            IInstruction defaultInstruction = new NumberDefault();
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode);
            
            int i = 0;

            while (i < 100 && runTime.CurrentInstruction != '@') {
                IInstruction currentInstruction = instructionsLookup.GetValueOrDefault(runTime.CurrentInstruction, defaultInstruction);
                currentInstruction.Execute(runTime);

                i++;
            }

            return runTime.Output;
            
        }
    }
}