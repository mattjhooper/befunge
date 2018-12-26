using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveRandom : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            Direction[] directions = { MoveDown.Instance, MoveLeft.Instance, MoveRight.Instance, MoveUp.Instance };
            int randomIndex = (new Random()).Next(directions.Length);
            
            befungeRunTime.CurrentDirection = directions[randomIndex];

            base.Execute(befungeRunTime);
        }
    }
}