using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public abstract class Instruction : IInstruction {
        public virtual void Execute(IBefungeRunTime befungeRunTime) {
            // Move in the current direction
            befungeRunTime.CurrentDirection.Execute(befungeRunTime);            
        }
    }
}