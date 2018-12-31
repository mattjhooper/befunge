using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// A "get" call (a way to retrieve data in storage). 
    /// Pop y and x, then push ASCII value of the character at that position in the program
    /// </summary>
    public class Get : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = befungeRunTime.RetrieveLastValue();
            int x = befungeRunTime.RetrieveLastValue();
            int val = (int)befungeRunTime.GetValue(new CoOrds(x,y));

            befungeRunTime.StoreValue(val);

            base.Execute(befungeRunTime);
        }
    }
}