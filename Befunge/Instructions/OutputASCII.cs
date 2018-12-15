using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class OutputASCII : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            char val = (char)befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.Output = val.ToString();

            base.Execute(befungeRunTime);
        }
    }
}