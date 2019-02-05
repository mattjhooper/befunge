using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// Base for any direction classes
    /// </summary>
    public abstract class Direction : IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public virtual void Execute(IBefungeRunTime befungeRunTime)
        {
            befungeRunTime.CurrentDirection = this;
            befungeRunTime.ReadInstruction();
        }
    }
}