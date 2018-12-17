using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveUp : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = 0 == befungeRunTime.CurrentPosition.y ? befungeRunTime.MaxExtent.y : befungeRunTime.CurrentPosition.y-1;
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x, y);            
            base.Execute(befungeRunTime);
        }
    }
}