using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Pop value from the stack and discard it
    /// </summary>
    public class Discard : Instruction, IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime)
        {
            int val = befungeRunTime.RetrieveLastValue();

            base.Execute(befungeRunTime);
        }
    }
}