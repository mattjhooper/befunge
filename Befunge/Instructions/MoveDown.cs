using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveDown : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrPos = new CoOrds(befungeRunTime.CurrPos.x, befungeRunTime.CurrPos.y+1);            
            base.Execute(befungeRunTime);
        }
    }
}