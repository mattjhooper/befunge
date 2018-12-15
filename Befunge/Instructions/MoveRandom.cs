using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveRandom : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            Direction[] directions = { new MoveDown(), new MoveLeft(), new MoveRight(), new MoveUp() };
            int randomIndex = (new Random()).Next(directions.Length);
            
            befungeRunTime.CurrentDirection = directions[randomIndex];

            base.Execute(befungeRunTime);
        }
    }
}