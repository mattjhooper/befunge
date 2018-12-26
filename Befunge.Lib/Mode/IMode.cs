using Befunge.Runtime;

namespace Befunge.Mode {
    /// <summary>
    /// Mode Interface.
    /// </summary>
    public interface IMode
    {
        #region properties
        /// <summary>
        /// Returns true if this is Number mode and false otherwise
        /// </summary>
        bool IsNumberMode { get; }

        #endregion

        #region methods
        /// <summary>
        /// Returns true if this is Number mode and false otherwise
        /// </summary>
        void ExecuteInstruction(IBefungeRunTime runTime);

        #endregion
    }
}

