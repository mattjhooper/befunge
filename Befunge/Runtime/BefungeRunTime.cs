using System;
using System.Text;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {
    public class BefungeRunTime : IBefungeRunTime {  

        #region fields      
        private readonly string[] _befungeGrid;
        private char _currentInstruction;
        private Stack<int> _intStack;

        private StringBuilder _output = new StringBuilder();

        #endregion

        #region properties
        public Direction CurrentDirection { get; set; }
        public char CurrentInstruction { 
            get
            {
                return _currentInstruction;
            } 
        }


        public IMode CurrentMode { get; set; }

        public CoOrds CurrentPosition { get; set; }

        public bool EndProgram { get; set; }

        public CoOrds MaxExtent 
        { get
            {
              int y = _befungeGrid.Length - 1;
              int x = _befungeGrid[CurrentPosition.y].Length -1;
              return new CoOrds(x, y);
            }         
        }
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

        #endregion

        #region constructors
        public BefungeRunTime(string befungeCode, IMode mode) {
            _befungeGrid = befungeCode.Split("\n");
            _intStack = new Stack<int>();
            CurrentPosition = new CoOrds(0,0);  
            CurrentMode = mode;

            ReadInstruction();   
            CurrentDirection = new MoveRight(); 
            EndProgram = false;     
        }

        #endregion

        #region methods

        public void ExecuteInstruction() {
            CurrentMode.ExecuteInstruction(this, CurrentInstruction);            
        }

        public char GetValue(CoOrds getPosition) {
            return _befungeGrid[getPosition.y][getPosition.x];
        }

        public void PutValue(CoOrds putPosition, char value) {
            char[] yChars = _befungeGrid[putPosition.y].ToCharArray();
            yChars[putPosition.x] = value;
            _befungeGrid[putPosition.y] = new string(yChars);
        }
        public void ReadInstruction() {
            _currentInstruction = _befungeGrid[CurrentPosition.y][CurrentPosition.x];
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

        public void StoreValue(int value) {
            _intStack.Push(value);
        }

       

        

        #endregion
        
    }
}