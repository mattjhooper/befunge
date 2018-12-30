using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Integer division: Pop a and b, then push b/a, rounded towards 0.
    /// If a is zero, push zero.
    /// </summary>
    public class Divide : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.StoreValue(a == 0 ? 0 : (b / a));

            base.Execute(befungeRunTime);
        }
    }
}