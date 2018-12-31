using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Swap two values on top of the stack.
    /// If there is only one value, pretend there is an extra 0 on bottom of the stack.
    /// </summary>
    public class Swap : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            
            int a = befungeRunTime.RetrieveLastValue();            
            int b = befungeRunTime.RetrieveLastValueOrDefault(0);            

            befungeRunTime.StoreValue(a);
            befungeRunTime.StoreValue(b);
            
            base.Execute(befungeRunTime);
        }
    }
}