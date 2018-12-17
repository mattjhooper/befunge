using Befunge.Runtime;

namespace Befunge.Mode {
    public interface IMode
    {
        #region methods
        void ExecuteInstruction(IBefungeRunTime runTime, char instruction);

        #endregion
    }
}

