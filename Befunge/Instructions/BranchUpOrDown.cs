using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class BranchUpOrDown : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveDown = MoveDown.Instance;
            Direction moveUp = MoveUp.Instance;
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveDown : moveUp;

            base.Execute(befungeRunTime);
        }
    }
}