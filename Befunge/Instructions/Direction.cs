using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public abstract class Direction : IInstruction {
        public virtual void Execute(IBefungeRunTime befungeRunTime) {
            befungeRunTime.CurrentDirection = this;
        }
    }
}