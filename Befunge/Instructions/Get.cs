using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class Get : Instruction, IInstruction {
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = befungeRunTime.RetrieveLastValue();
            int x = befungeRunTime.RetrieveLastValue();
            int val = (int)befungeRunTime.GetValue(new CoOrds(x,y));

            befungeRunTime.StoreValue(val);

            base.Execute(befungeRunTime);
        }
    }
}