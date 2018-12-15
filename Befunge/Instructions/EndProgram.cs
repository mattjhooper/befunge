using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class EndProgram : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.EndProgram = true;            
            base.Execute(befungeRunTime);
        }
    }
}