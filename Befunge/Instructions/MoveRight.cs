using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveRight : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int x = befungeRunTime.MaxExtent.x == befungeRunTime.CurrentPosition.x ? 0 : befungeRunTime.CurrentPosition.x+1;
            befungeRunTime.CurrentPosition = new CoOrds(x, befungeRunTime.CurrentPosition.y);            
            base.Execute(befungeRunTime);            
        }
    }
}