using System;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge.Mode {
    public sealed class NumberMode : IMode {

        #region lazy_singleton
        private static readonly Lazy<NumberMode> _lazyNumberModeSingleton = new Lazy<NumberMode>(() => new NumberMode());

        #endregion

        #region fields

        private readonly IInstruction _defaultInstruction = new NumberDefault();
        private readonly Dictionary<char,IInstruction> _instructionsLookup;

        #endregion

        #region properties
        public bool IsNumberMode { get {return true;} }

        #endregion

        #region constructors
        private NumberMode() {
            _instructionsLookup = new Dictionary<char, IInstruction>();
            SetupInstructionLookup();
        }

        #endregion

        #region methods
        public void ExecuteInstruction(IBefungeRunTime runTime, char instruction) {
            IInstruction currentInstruction = _instructionsLookup.GetValueOrDefault(runTime.CurrentInstruction, _defaultInstruction);
            currentInstruction.Execute(runTime); 
        }

        public static NumberMode Instance { get { return _lazyNumberModeSingleton.Value; } }

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
            _instructionsLookup.Add('>', MoveRight.Instance);
            _instructionsLookup.Add('<', MoveLeft.Instance);
            _instructionsLookup.Add('^', MoveUp.Instance);
            _instructionsLookup.Add('v', MoveDown.Instance);
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