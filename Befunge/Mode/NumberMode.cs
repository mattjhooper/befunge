using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge.Mode {
    public class NumberMode : IMode {

        #region fields
        private readonly IInstruction _defaultInstruction = new NumberDefault();
        private readonly Dictionary<char,IInstruction> _instructionsLookup;

        #endregion

        #region constructors
        public NumberMode() {
            _instructionsLookup = new Dictionary<char, IInstruction>();
            SetupInstructionLookup();
        }

        #endregion

        #region methods
        public void ExecuteInstruction(IBefungeRunTime runTime, char instruction) {
            IInstruction currentInstruction = _instructionsLookup.GetValueOrDefault(runTime.CurrentInstruction, _defaultInstruction);
            currentInstruction.Execute(runTime); 
        }

        private void SetupInstructionLookup() {
            _instructionsLookup.Clear();
            _instructionsLookup.Add('+', new Add());
            _instructionsLookup.Add('-', new Subtract());
            _instructionsLookup.Add('*', new Multiply());
            _instructionsLookup.Add('/', new Divide());
            _instructionsLookup.Add('%', new Modulo());
            _instructionsLookup.Add('!', new LogicalNot());
            _instructionsLookup.Add('`', new GreaterThan());
            _instructionsLookup.Add('.', new OutputNumber());
            _instructionsLookup.Add('>', new MoveRight());
            _instructionsLookup.Add('<', new MoveLeft());
            _instructionsLookup.Add('^', new MoveUp());
            _instructionsLookup.Add('v', new MoveDown());
            _instructionsLookup.Add(' ', new Ignore());
            _instructionsLookup.Add(':', new Duplicate());
            _instructionsLookup.Add('_', new BranchLeftOrRight());
            _instructionsLookup.Add('|', new BranchUpOrDown());
            _instructionsLookup.Add('?', new MoveRandom());
            _instructionsLookup.Add('$', new Discard());
            _instructionsLookup.Add('\\', new Swap());
            _instructionsLookup.Add('@', new EndProgram());
            _instructionsLookup.Add('"', new ToggleStringMode());
            _instructionsLookup.Add(',', new OutputASCII());
            _instructionsLookup.Add('#', new Trampoline());
            _instructionsLookup.Add('g', new Get());
            _instructionsLookup.Add('p', new Put());
        }

        #endregion       
    }
}