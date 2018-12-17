using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class BranchUpOrDown : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveDown = new MoveDown();
            Direction moveUp = new MoveUp();
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveDown : moveUp;

            base.Execute(befungeRunTime);
        }
    }
}