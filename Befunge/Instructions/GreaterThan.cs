using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class GreaterThan : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(b > a ? 1 : 0);  

            base.Execute(befungeRunTime);          
        }
    }
}