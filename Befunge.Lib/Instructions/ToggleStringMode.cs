using System;
using Befunge.Mode;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class ToggleStringMode : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            IMode numberMode = NumberMode.Instance;
            IMode stringMode = StringMode.Instance;

            befungeRunTime.CurrentMode = (befungeRunTime.CurrentMode.IsNumberMode) ? stringMode : numberMode;

            base.Execute(befungeRunTime);
        }
    }
}