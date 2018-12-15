using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge.Mode {
    public class NumberMode : IMode {
        private readonly Dictionary<char,IInstruction> _instructionsLookup;
        private readonly IInstruction _defaultInstruction = new NumberDefault();

        public NumberMode() {
            _instructionsLookup = new Dictionary<char, IInstruction>();
            SetupInstructionLookup();
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
            _instructionsLookup.Add('.', new Period());
            _instructionsLookup.Add('>', new MoveRight());
            _instructionsLookup.Add('<', new MoveLeft());
            _instructionsLookup.Add('^', new MoveUp());
            _instructionsLookup.Add('v', new MoveDown());
            _instructionsLookup.Add(' ', new Space());
            _instructionsLookup.Add(':', new Duplicate());
            _instructionsLookup.Add('_', new Underscore());
            _instructionsLookup.Add('|', new Pipe());
            _instructionsLookup.Add('?', new MoveRandom());
            _instructionsLookup.Add('$', new Discard());
            _instructionsLookup.Add('\\', new Swap());
            _instructionsLookup.Add('@', new EndProgram());
            _instructionsLookup.Add('"', new ToggleStringMode());
            _instructionsLookup.Add(',', new OutputASCII());
        }

        public void ExecuteInstruction(IBefungeRunTime runTime, char instruction) {
            IInstruction currentInstruction = _instructionsLookup.GetValueOrDefault(runTime.CurrentInstruction, _defaultInstruction);
            currentInstruction.Execute(runTime); 
        }
    }
}