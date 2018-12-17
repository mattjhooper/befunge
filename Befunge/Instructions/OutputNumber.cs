using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class OutputNumber : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.Output = a.ToString();

            base.Execute(befungeRunTime);
        }
    }
}