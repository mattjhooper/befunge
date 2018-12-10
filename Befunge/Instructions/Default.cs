using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Default : IInstruction {
        public void Execute(IBefungeRunTime befungeRunTime) {
            int value;

            if (Int32.TryParse(befungeRunTime.CurrentInstruction.ToString(), out value)) {
                befungeRunTime.StoreValue(value);
            }
            else {
                Console.WriteLine("Unsupported Instruction: " + befungeRunTime.CurrentInstruction.ToString());
            }
            
        }
    }
}