using System;
using Befunge.Runtime;

namespace Befunge.Instructions
{
    /// <summary>
    /// The Instruction interface
    /// </summary>
    public interface IInstruction
    {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        void Execute(IBefungeRunTime befungeRunTime);
    }
}