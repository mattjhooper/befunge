using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Pop a value; move down if value=0, up otherwise
    /// </summary>
    public class BranchUpOrDown : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();

            Direction moveDown = MoveDown.Instance;
            Direction moveUp = MoveUp.Instance;
                        
            befungeRunTime.CurrentDirection = val == 0 ? moveDown : moveUp;

            base.Execute(befungeRunTime);
        }
    }
}