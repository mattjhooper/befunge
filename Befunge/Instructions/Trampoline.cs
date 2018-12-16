using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Trampoline : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrentDirection.Execute(befungeRunTime);
                        
            base.Execute(befungeRunTime);
        }
    }
}