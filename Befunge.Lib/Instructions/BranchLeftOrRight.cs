using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class BranchLeftOrRight : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveRight = MoveRight.Instance;
            Direction moveLeft = MoveLeft.Instance;
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveRight : moveLeft;

            base.Execute(befungeRunTime);
        }
    }
}