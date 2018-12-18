using Befunge.Runtime;

namespace Befunge.Mode {
    public interface IMode
    {
        #region properties
        bool IsNumberMode { get; }

        #endregion

        #region methods
        void ExecuteInstruction(IBefungeRunTime runTime, char instruction);

        #endregion
    }
}

