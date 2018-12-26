using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class NumberDefault : Instruction, IInstruction {
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