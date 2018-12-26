using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {
    public class BefungeRunTime : IBefungeRunTime {  

        #region fields      
        private readonly string[] _befungeGrid;
        private char _currentInstruction;

        private CoOrds _currentPosition;
        private readonly Stack<int> _intStack;

        private StringBuilder _output = new StringBuilder();

        private readonly TextWriter _outputStream;

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

        public CoOrds CurrentPosition 
        { get
            {
                return _currentPosition;
            } 
          set
            {
                if (CheckPosition(value))
                   _currentPosition = value;
            } 
        }

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
              _outputStream.Write(value);
              _outputStream.Flush();
              _output.Append(value);
          }
        }

        #endregion

        #region constructors
        public BefungeRunTime(string befungeCode, IMode mode, TextWriter outputStream = null) {
            _befungeGrid = CreateGridFromString(befungeCode);
            _intStack = new Stack<int>();
            CurrentPosition = new CoOrds(0,0);  
            CurrentMode = mode;

            ReadInstruction();   
            CurrentDirection = MoveRight.Instance; 
            EndProgram = false;   
            _outputStream = outputStream == null ? Console.Out : outputStream;            
        }

        #endregion

        #region methods

        private bool CheckPosition(CoOrds checkPosition) {
            bool isValid = (0 <= checkPosition.x && checkPosition.x <= MaxExtent.x && 0 <= checkPosition.y && checkPosition.y <= MaxExtent.y);

            if (!isValid) {
                string message = $"Invalid Position specified: [{checkPosition.x},{checkPosition.y}].";
                throw new InvalidOperationException(message); 
            }

            return isValid;
        }

        private string[] CreateGridFromString(string befungeCode)
        {
            string[] grid = befungeCode.Split('\n');
            int maxWidth = grid.Aggregate(0, (currMax, next) => next.Length > currMax ? next.Length : currMax);

            for(int line = 0; line < grid.Length; line++) 
            {
                grid[line] = grid[line].PadRight(maxWidth, ' ');
            }

            return grid;
        }

        public void ExecuteInstruction() {
            CurrentMode.ExecuteInstruction(this);            
        }

        public char GetValue(CoOrds getPosition) {
            char rtn=' ';
            if (CheckPosition(getPosition))
                rtn = _befungeGrid[getPosition.y][getPosition.x];
            return rtn;
        }

        public void PutValue(CoOrds putPosition, char value) {
            if (CheckPosition(putPosition)) 
            {
                char[] yChars = _befungeGrid[putPosition.y].ToCharArray();
                yChars[putPosition.x] = value;
                _befungeGrid[putPosition.y] = new string(yChars);
            }
        }
        public void ReadInstruction() {
            if (CheckPosition(CurrentPosition))
                _currentInstruction = _befungeGrid[CurrentPosition.y][CurrentPosition.x];
        }

        public int RetrieveLastValue() {
            if (_intStack.Count == 0) 
            {
                string message = $"Invalid Operation at position [{CurrentPosition.x},{CurrentPosition.y}]. Cannot retrieve a value when the stack is empty.";
                throw new InvalidOperationException(message); 
            }
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