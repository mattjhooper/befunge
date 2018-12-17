using Befunge.Runtime;
using Befunge.Instructions;

namespace Befunge.Mode {
    public class StringMode : IMode
    {
        #region fields
        private readonly IInstruction _defaultInstruction = new StringDefault();
        private readonly IInstruction _toggleStringMode = new ToggleStringMode();

        #endregion

        #region methods

        public void ExecuteInstruction(IBefungeRunTime runTime, char instruction) {
            IInstruction currentInstruction = runTime.CurrentInstruction == '"' ? _toggleStringMode :  _defaultInstruction;
            currentInstruction.Execute(runTime); 
        }
        #endregion
    }
}
