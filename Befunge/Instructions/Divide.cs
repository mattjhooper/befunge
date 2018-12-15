using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Divide : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.StoreValue(a == 0 ? 0 : (b / a));

            base.Execute(befungeRunTime);
        }
    }
}