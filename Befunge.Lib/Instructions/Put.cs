using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// A "put" call (a way to store a value for later use). 
    /// Pop y, x, and v, then change the character at (x,y) 
    /// in the program to the character with ASCII value v
    /// </summary>
    public class Put : Instruction, IInstruction {
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = befungeRunTime.RetrieveLastValue();
            int x = befungeRunTime.RetrieveLastValue();
            char v = (char)befungeRunTime.RetrieveLastValue();

            befungeRunTime.PutValue(new CoOrds(x, y), v);

            base.Execute(befungeRunTime);
        }
    }
}