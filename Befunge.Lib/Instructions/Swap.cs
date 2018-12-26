using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Swap : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            
            int a = befungeRunTime.RetrieveLastValue();            
            int b = befungeRunTime.RetrieveLastValueOrDefault(0);            

            befungeRunTime.StoreValue(a);
            befungeRunTime.StoreValue(b);
            
            base.Execute(befungeRunTime);
        }
    }
}