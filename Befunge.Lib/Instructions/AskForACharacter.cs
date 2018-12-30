using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Ask user for a character and push its ASCII value
    /// </summary>
    public class AskForACharacter : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int value = (int)befungeRunTime.Input("Please supply a Character:");            
            befungeRunTime.StoreValue(value);
            base.Execute(befungeRunTime);
        }
    }
}