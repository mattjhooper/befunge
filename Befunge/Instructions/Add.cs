using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Add : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(a + b);

            base.Execute(befungeRunTime);
        }
    }
}