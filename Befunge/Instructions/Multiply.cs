using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Multiply : IInstruction {
        public void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(a * b);
        }
    }
}