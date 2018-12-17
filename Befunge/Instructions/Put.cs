using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Put : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = befungeRunTime.RetrieveLastValue();
            int x = befungeRunTime.RetrieveLastValue();
            char v = (char)befungeRunTime.RetrieveLastValue();

            befungeRunTime.PutValue(new CoOrds(x, y), v);

            base.Execute(befungeRunTime);
        }
    }
}