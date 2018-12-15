using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Discard : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();
            
            base.Execute(befungeRunTime);
        }
    }
}