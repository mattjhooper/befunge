using System;

namespace Befunge.Instructions {
    public class Add : IInstruction {
        void execute(IBefungeRunTime runTime) {
            int a = runTime.retrieveLastValue();
            int b = runTime.retrieveLastValue();
            runTime.storeValue(a + b);
        }
    }
}