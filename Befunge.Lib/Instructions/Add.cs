using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Addition: Pop a and b, then push a+b
    /// </summary>
    public class Add : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(a + b);

            base.Execute(befungeRunTime);
        }
    }
}