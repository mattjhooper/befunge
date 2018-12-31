using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Ask user for a number and push it
    /// </summary>
    public class AskForANumber : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int value;
            string input = "";
            
            while (!Int32.TryParse(input, out value))
            {
                input = befungeRunTime.Input("Please supply an Integer:");                    
            }

            befungeRunTime.StoreValue(value);
            base.Execute(befungeRunTime);
        }
    }
}