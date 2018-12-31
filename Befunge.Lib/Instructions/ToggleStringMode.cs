using System;
using Befunge.Mode;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Start string mode: push each character's ASCII value all the way up to the next "
    /// </summary>
    public class ToggleStringMode : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            IMode numberMode = NumberMode.Instance;
            IMode stringMode = StringMode.Instance;

            befungeRunTime.CurrentMode = (befungeRunTime.CurrentMode.IsNumberMode) ? stringMode : numberMode;

            base.Execute(befungeRunTime);
        }
    }
}