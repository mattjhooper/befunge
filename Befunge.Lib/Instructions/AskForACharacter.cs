using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Ask user for a character and push its ASCII value
    /// </summary>
    public class AskForACharacter : Instruction, IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime)
        {
            string input = "";

            while (input.Length == 0)
            {
                input = befungeRunTime.Input("Please supply a Character:");
            }

            // take the first character and get the ASCII value
            int ASCIIvalue = (int)input[0];
            befungeRunTime.StoreValue(ASCIIvalue);
            base.Execute(befungeRunTime);
        }
    }
}