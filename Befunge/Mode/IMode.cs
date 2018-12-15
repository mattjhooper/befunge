using Befunge.Runtime;

namespace Befunge.Mode {
    public interface IMode
    {
        void ExecuteInstruction(IBefungeRunTime runTime, char instruction);
    }
}

