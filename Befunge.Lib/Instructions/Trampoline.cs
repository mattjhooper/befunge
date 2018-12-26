using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Bridge: Skip next cell
    /// </summary>
    public class Trampoline : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrentDirection.Execute(befungeRunTime);
                        
            base.Execute(befungeRunTime);
        }
    }
}