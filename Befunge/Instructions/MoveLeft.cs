using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveLeft : Direction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x-1, befungeRunTime.CurrentPosition.y);            
            base.Execute(befungeRunTime);
        }
    }
}