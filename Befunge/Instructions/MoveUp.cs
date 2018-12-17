using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveUp : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x, befungeRunTime.CurrentPosition.y-1);            
            base.Execute(befungeRunTime);
        }
    }
}