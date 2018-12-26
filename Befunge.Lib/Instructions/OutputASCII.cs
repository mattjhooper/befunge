using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Pop value and output as ASCII character
    /// </summary>
    public class OutputASCII : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            char val = (char)befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.Output = val.ToString();

            base.Execute(befungeRunTime);
        }
    }
}