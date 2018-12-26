using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Pop a value; move right if value=0, left otherwise
    /// </summary>
    public class BranchLeftOrRight : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveRight = MoveRight.Instance;
            Direction moveLeft = MoveLeft.Instance;
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveRight : moveLeft;

            base.Execute(befungeRunTime);
        }
    }
}