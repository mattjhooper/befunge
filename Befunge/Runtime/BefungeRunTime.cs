using System;
using System.Text;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {
    public class BefungeRunTime : IBefungeRunTime {        
        private Stack<int> _intStack;
        private readonly string[] _befungeGrid;
        private StringBuilder _output = new StringBuilder();

        private char _currentInstruction;

        public char CurrentInstruction { 
            get
            {
                return _currentInstruction;
            } 
        }

        public Direction CurrentDirection { get; set; }

        public IMode CurrentMode { get; set; }

        public CoOrds CurrPos { get; set; }

        public bool EndProgram { get; set; }
        public string Output 
        { get 
          { 
              return _output.ToString();
          }
          set 
          {
              _output.Append(value);
          }
        }

        public BefungeRunTime(string befungeCode) {
            _befungeGrid = befungeCode.Split("\n");
            _intStack = new Stack<int>();
            CurrPos = new CoOrds(0,0);  
            CurrentMode = new NumberMode();

            ReadInstruction();   
            CurrentDirection = new MoveRight(); 
            EndProgram = false;     
        }

        public void ExecuteInstruction() {
            CurrentMode.ExecuteInstruction(this, CurrentInstruction);            
        }

        public void StoreValue(int value) {
            _intStack.Push(value);
        }
        public int RetrieveLastValue() {
            return _intStack.Pop();
        }
        public int RetrieveLastValueOrDefault(int defaultValue) {
            return _intStack.Count == 0 ? defaultValue : _intStack.Pop();
        }

        public int ReviewLastValue() {
            return _intStack.Peek();
        }
        public int ReviewLastValueOrDefault(int defaultValue) {
            return _intStack.Count == 0 ? defaultValue : _intStack.Peek();
        }

        public void ReadInstruction() {
            _currentInstruction = _befungeGrid[CurrPos.y][CurrPos.x];
        }
        
    }
}