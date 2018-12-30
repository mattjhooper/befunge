using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Modulo: Pop a and b, then push the remainder of the integer division of b/a.
    /// If a is zero, push zero.
    /// </summary>
    public class Modulo : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(a == 0 ? 0 : b % a);

            base.Execute(befungeRunTime);
        }
    }
}