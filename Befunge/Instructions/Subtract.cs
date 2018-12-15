using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Subtract : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(b - a);

            base.Execute(befungeRunTime);
        }
    }
}