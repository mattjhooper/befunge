using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveLeft : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int x = 0 == befungeRunTime.CurrentPosition.x ? befungeRunTime.MaxExtent.x : befungeRunTime.CurrentPosition.x-1;
            befungeRunTime.CurrentPosition = new CoOrds(x, befungeRunTime.CurrentPosition.y);            
            base.Execute(befungeRunTime);
        }
    }
}