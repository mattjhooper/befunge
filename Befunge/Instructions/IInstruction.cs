using System;

namespace Befunge {
    public interface IInstruction {
        void execute(IBefungeRunTime runTime);
    }
}