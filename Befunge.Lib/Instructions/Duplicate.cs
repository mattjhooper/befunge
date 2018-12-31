using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Duplicate value on top of the stack. If there is nothing on top of the stack, push a 0
    /// </summary>
    public class Duplicate : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            
            int val = befungeRunTime.ReviewLastValueOrDefault(0);            

            befungeRunTime.StoreValue(val);
            
            base.Execute(befungeRunTime);
        }
    }
}