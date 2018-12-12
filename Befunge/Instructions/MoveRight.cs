using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveRight : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            base.Execute(befungeRunTime);
            befungeRunTime.CurrPos = new CoOrds(befungeRunTime.CurrPos.x + 1, befungeRunTime.CurrPos.y);            
        }
    }
}