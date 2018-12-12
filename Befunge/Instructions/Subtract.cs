using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Subtract : IInstruction {
        public void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            int b = befungeRunTime.RetrieveLastValue();

            befungeRunTime.StoreValue(b - a);
        }
    }
}