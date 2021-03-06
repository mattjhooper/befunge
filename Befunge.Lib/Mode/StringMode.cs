using System;
using Befunge.Runtime;
using Befunge.Instructions;

namespace Befunge.Mode
{
    /// <summary>
    /// String mode.
    /// </summary>
    public class StringMode : IMode
    {
        #region lazy_singleton
        private static readonly Lazy<StringMode> _lazyStringModeSingleton = new Lazy<StringMode>(() => new StringMode());

        #endregion

        #region fields
        private readonly IInstruction _defaultInstruction = new StringDefault();
        private readonly IInstruction _toggleStringMode = new ToggleStringMode();

        #endregion

        #region properties

        /// <summary>
        /// Returns true if this is Number mode and false otherwise
        /// </summary>
        public bool IsNumberMode { get { return false; } }

        #endregion

        #region constructors
        private StringMode()
        {

        }

        #endregion

        #region methods

        /// <summary>
        /// Execute the current instruction
        /// </summary>
        public void ExecuteInstruction(IBefungeRunTime runTime)
        {
            IInstruction currentInstruction = runTime.CurrentInstruction == '"' ? _toggleStringMode : _defaultInstruction;
            currentInstruction.Execute(runTime);
        }

        /// <summary>
        /// Return the instance
        /// </summary>
        /// <returns>
        /// Return the singleton instance of StringMode
        /// </returns>
        public static StringMode Instance { get { return _lazyStringModeSingleton.Value; } }

        #endregion
    }
}
