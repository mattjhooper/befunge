using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class LogicalNot : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.StoreValue(val == 0 ? 1 : 0);

            base.Execute(befungeRunTime);
        }
    }
}