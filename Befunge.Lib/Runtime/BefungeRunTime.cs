using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using Befunge.Instructions;
using Befunge.Mode;


namespace Befunge.Runtime {
    /// <summary>
    /// Class to manage the objects required for the befunge interpreter
    /// </summary>
    public class BefungeRunTime : IBefungeRunTime {  

        #region fields      
        private readonly string[] _befungeGrid;
        private char _currentInstruction;

        private CoOrds _currentPosition;

        private readonly TextReader _inputStream;
        private readonly Stack<int> _intStack;

        private StringBuilder _output = new StringBuilder();

        private readonly TextWriter _outputStream;

        #endregion

        #region properties
        /// <summary>
        /// Get or Set the current direction
        /// </summary>
        public Direction CurrentDirection { get; set; }
        
        /// <summary>
        /// Get the current instruction
        /// </summary>
        public char CurrentInstruction { 
            get
            {
                return _currentInstruction;
            } 
        }


        /// <summary>
        /// Get or Set the current mode (e.g. NumberMode or StringMode)
        /// </summary>
        public IMode CurrentMode { get; set; }

        /// <summary>
        /// Get or Set the current position as an X/Y coordinate
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when an invalid position is specified</exception>
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

        /// <summary>
        /// Return true if the program is at the end or false otherwise
        /// </summary>
        public bool EndProgram { get; set; }

        /// <summary>
        /// Get the Maximum extent of the befunge grid as an x/y coordinate
        /// </summary>
        public CoOrds MaxExtent 
        { get
            {
              int y = _befungeGrid.Length - 1;
              int x = _befungeGrid[CurrentPosition.y].Length -1;
              return new CoOrds(x, y);
            }         
        }
        /// <summary>
        /// Get or Set the output for the befunge program
        /// </summary>
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
        /// <summary>
        /// Create the BefungeRunTime
        /// </summary>
        /// <param name="befungeCode">A String containing befunge code.</param>
        /// <param name="mode">The mode (Number or String).</param>
        /// <param name="outputStream">An optional TextWriter. It can be used to output to a file.</param>
        /// <param name="inputStream">An optional TextReader. It can be used to pass input from a file or the console.</param>
        public BefungeRunTime(string befungeCode, IMode mode, TextWriter outputStream = null, TextReader inputStream = null) {
            _befungeGrid = CreateGridFromString(befungeCode);
            _intStack = new Stack<int>();
            CurrentPosition = new CoOrds(0,0);  
            CurrentMode = mode;

            ReadInstruction();   
            CurrentDirection = MoveRight.Instance; 
            EndProgram = false;   
            _outputStream = outputStream == null ? Console.Out : outputStream; 
            _inputStream = inputStream == null ? Console.In : inputStream;           
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

        /// <summary>
        /// Execute the current instruction
        /// </summary>
        public void ExecuteInstruction() {
            CurrentMode.ExecuteInstruction(this);            
        }

        /// <summary>
        /// Get the character at the specified position
        /// </summary>
        /// <returns>
        /// Returns the character stored at the specified position
        /// </returns>
        /// <param name="getPosition">x/y coordinate of the character to retrieve.</param>
        /// <exception cref="InvalidOperationException">Thrown when an invalid position is specified</exception>
        public char GetValue(CoOrds getPosition) {
            char rtn=' ';
            if (CheckPosition(getPosition))
                rtn = _befungeGrid[getPosition.y][getPosition.x];
            return rtn;
        }

        /// <summary>
        /// Ask the user for a character (using the supplied prompt and return it)
        /// </summary>
        /// <returns>
        /// Returns the character entered by the user
        /// </returns>
        /// <param name="prompt">a prompt to display to the user to request the input.</param>
        public char Input(String prompt)
        {
            _outputStream.Write(prompt);
            string input = _inputStream.ReadLine();
            return input[0];
        }

        /// <summary>
        /// Store the supplied character at the specified position
        /// </summary>
        /// <param name="putPosition">x/y coordinate position to store the supplied character.</param>
        /// <param name="value">the character to store.</param>
        /// <exception cref="InvalidOperationException">Thrown when an invalid position is specified</exception>
        public void PutValue(CoOrds putPosition, char value) {
            if (CheckPosition(putPosition)) 
            {
                char[] yChars = _befungeGrid[putPosition.y].ToCharArray();
                yChars[putPosition.x] = value;
                _befungeGrid[putPosition.y] = new string(yChars);
            }
        }
        /// <summary>
        /// Read the current instruction
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the current position is not valid</exception>
        public void ReadInstruction() {
            if (CheckPosition(CurrentPosition))
                _currentInstruction = _befungeGrid[CurrentPosition.y][CurrentPosition.x];
        }

        /// <summary>
        /// Retrieve the last value stored in memory and return it.
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored on the stack
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown when no value exists in memory</exception>
        public int RetrieveLastValue() {
            if (_intStack.Count == 0) 
            {
                string message = $"Invalid Operation at position [{CurrentPosition.x},{CurrentPosition.y}]. Cannot retrieve a value when the stack is empty.";
                throw new InvalidOperationException(message); 
            }
            return _intStack.Pop();
        }
        
        /// <summary>
        /// Retrieve the last value stored in memory and return it.
        /// If no value has been stored, return the supplied default value
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory or a default
        /// </returns>
        /// <param name="defaultValue">the default value to return if there is nothing in memory.</param>
        public int RetrieveLastValueOrDefault(int defaultValue) {
            return _intStack.Count == 0 ? defaultValue : _intStack.Pop();
        }

        /// <summary>
        /// Peek at the last value stored in memory and return it without removing from memory.
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory
        /// </returns>
        /// <exception cref="InvalidOperationException">Thrown when no value exists in memory</exception>
        public int ReviewLastValue() {
            if (_intStack.Count == 0) 
            {
                string message = $"Invalid Operation at position [{CurrentPosition.x},{CurrentPosition.y}]. Cannot review a value when the stack is empty.";
                throw new InvalidOperationException(message); 
            }
            return _intStack.Peek();
        }
        
        /// <summary>
        /// Peek at the last value stored in memory and return it without removing from memory.
        /// If no value has been stored, return the supplied default value
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory
        /// </returns>
        /// <param name="defaultValue">the default value to return if the stack is empty.</param>
        public int ReviewLastValueOrDefault(int defaultValue) {
            return _intStack.Count == 0 ? defaultValue : _intStack.Peek();
        }

        /// <summary>
        /// Store the supplied value in memory
        /// </summary>
        /// <param name="value">the default value to return if there is nothing in memory.</param>
        public void StoreValue(int value) {
            _intStack.Push(value);
        }

       

        

        #endregion
        
    }
}