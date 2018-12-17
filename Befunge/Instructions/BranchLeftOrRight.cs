using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class BranchLeftOrRight : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveRight = new MoveRight();
            Direction moveLeft = new MoveLeft();
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveRight : moveLeft;

            base.Execute(befungeRunTime);
        }
    }
}