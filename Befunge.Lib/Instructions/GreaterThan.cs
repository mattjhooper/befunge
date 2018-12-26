using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Greater than: Pop a and b, then push 1 if b>a, otherwise zero.
    /// </summary>
    public class GreaterThan : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(b > a ? 1 : 0);  

            base.Execute(befungeRunTime);          
        }
    }
}