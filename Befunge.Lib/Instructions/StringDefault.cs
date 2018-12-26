using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class StringDefault : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.StoreValue((int)befungeRunTime.CurrentInstruction);
                        
            base.Execute(befungeRunTime);
        }
    }
}