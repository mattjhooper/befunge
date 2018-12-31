using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// End program
    /// </summary>
    public class EndProgram : Direction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.EndProgram = true;            
            base.Execute(befungeRunTime);
        }
    }
}