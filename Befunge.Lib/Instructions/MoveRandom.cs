using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Start moving in a random cardinal direction
    /// </summary>
    public class MoveRandom : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            Direction[] directions = { MoveDown.Instance, MoveLeft.Instance, MoveRight.Instance, MoveUp.Instance };
            int randomIndex = (new Random()).Next(directions.Length);
            
            befungeRunTime.CurrentDirection = directions[randomIndex];

            base.Execute(befungeRunTime);
        }
    }
}