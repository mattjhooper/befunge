using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class LogicalNot : IInstruction {
        public void Execute(IBefungeRunTime befungeRunTime) {
            int val = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.StoreValue(val == 0 ? 1 : 0);
        }
    }
}