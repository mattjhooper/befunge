using System;
using Befunge.Mode;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class ToggleStringMode : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            IMode numberMode = new NumberMode();
            IMode stringMode = new StringMode();

            befungeRunTime.CurrentMode = (befungeRunTime.CurrentMode is NumberMode) ? stringMode : numberMode;

            base.Execute(befungeRunTime);
        }
    }
}