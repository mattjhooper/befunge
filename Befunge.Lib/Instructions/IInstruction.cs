using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public interface IInstruction {
        void Execute(IBefungeRunTime befungeRunTime);
    }
}