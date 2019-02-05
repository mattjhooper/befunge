using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Pop value and output as an integer followed by a space
    /// </summary>
    public class OutputNumber : Instruction, IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime)
        {
            int a = befungeRunTime.RetrieveLastValue();

            befungeRunTime.Output = a.ToString();

            base.Execute(befungeRunTime);
        }
    }
}