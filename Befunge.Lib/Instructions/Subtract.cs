using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Subtraction: Pop a and b, then push b-a
    /// </summary>
    public class Subtract : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(b - a);

            base.Execute(befungeRunTime);
        }
    }
}