using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// 0-9 - Push this number on the stack
    /// </summary>
    public class NumberDefault : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        /// <exception cref="UnsupportedInstructionException">Thrown when an unknown instruction is encountered</exception>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int value;
            
            if (Int32.TryParse(befungeRunTime.CurrentInstruction.ToString(), out value)) {
                befungeRunTime.StoreValue(value);
            }
            else {
                string message = $"Unsupported Instruction: {befungeRunTime.CurrentInstruction.ToString()}.";
                Console.WriteLine(message);
                throw new UnsupportedInstructionException(message);
            }

            base.Execute(befungeRunTime);
            
        }
    }
}