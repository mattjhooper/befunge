using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Duplicate : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            
            int val = befungeRunTime.ReviewLastValueOrDefault(0);            

            befungeRunTime.StoreValue(val);
            
            base.Execute(befungeRunTime);
        }
    }
}