using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Logical NOT: Pop a value. If the value is zero, push 1; otherwise, push zero.
    /// </summary>
    public class LogicalNot : Instruction, IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime)
        {
            int val = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(val == 0 ? 1 : 0);

            base.Execute(befungeRunTime);
        }
    }
}