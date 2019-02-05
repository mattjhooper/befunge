using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Base for any instruction classes
    /// </summary>
    public abstract class Instruction : IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public virtual void Execute(IBefungeRunTime befungeRunTime)
        {
            // Move in the current direction
            befungeRunTime.CurrentDirection.Execute(befungeRunTime);
        }
    }
}