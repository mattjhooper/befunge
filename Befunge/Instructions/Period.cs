using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Period : IInstruction {
        public void Execute(IBefungeRunTime befungeRunTime) {
            int a = befungeRunTime.RetrieveLastValue();
            
            befungeRunTime.Output = a.ToString();
        }
    }
}