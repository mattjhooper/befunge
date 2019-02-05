using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Push each character's ASCII value on the stack
    /// </summary>
    public class StringDefault : Instruction, IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime)
        {
            befungeRunTime.StoreValue((int)befungeRunTime.CurrentInstruction);

            base.Execute(befungeRunTime);
        }
    }
}