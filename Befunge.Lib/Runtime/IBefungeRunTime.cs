using System;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {

    /// <summary>
    /// IBefungeRunTime interface.
    /// Contains the methods that are needed to run the befunge interpreter
    /// </summary>
    public interface IBefungeRunTime {

        #region properties
        /// <summary>
        /// Get or Set the current direction
        /// </summary>
        Direction CurrentDirection { get; set; }
        /// <summary>
        /// Get the current instruction
        /// </summary>
        char CurrentInstruction { get; }

        /// <summary>
        /// Get or Set the current mode (e.g. NumberMode or StringMode)
        /// </summary>
        IMode CurrentMode { get; set; }

        /// <summary>
        /// Get or Set the current position as an X/Y coordinate
        /// </summary>
        CoOrds CurrentPosition { get; set; }
        /// <summary>
        /// Return true if the program is at the end or false otherwise
        /// </summary>
        bool EndProgram { get; set; }

        /// <summary>
        /// Get the Maximum extent of the befunge grid as an x/y coordinate
        /// </summary>
        CoOrds MaxExtent { get; }

        /// <summary>
        /// Get or Set the output for the befunge program
        /// </summary>
        string Output { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// Execute the current instruction
        /// </summary>
        void ExecuteInstruction();

        /// <summary>
        /// Get the character at the specified position
        /// </summary>
        /// <returns>
        /// Returns the character stored at the specified position
        /// </returns>
        /// <param name="getPosition">x/y coordinate of the character to retrieve.</param>
        char GetValue(CoOrds getPosition);

        /// <summary>
        /// Ask the user for input (using the supplied prompt and return it)
        /// </summary>
        /// <returns>
        /// Returns the input string entered by the user
        /// </returns>
        /// <param name="prompt">a prompt to display to the user to request the input.</param>
        string Input(String prompt);

        /// <summary>
        /// Store the supplied character at the specified position
        /// </summary>
        /// <param name="putPosition">x/y coordinate position to store the supplied character.</param>
        /// <param name="value">the character to store.</param>
        void PutValue(CoOrds putPosition, char value);
        
        /// <summary>
        /// Read the current instruction
        /// </summary>
        void ReadInstruction();
        
        /// <summary>
        /// Retrieve the last value stored in memory and return it.
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored on the stack
        /// </returns>
        int RetrieveLastValue();
        /// <summary>
        /// Retrieve the last value stored in memory and return it.
        /// If no value has been stored, return the supplied default value
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory or a default
        /// </returns>
        /// <param name="defaultValue">the default value to return if there is nothing in memory.</param>
        int RetrieveLastValueOrDefault(int defaultValue);
        
        /// <summary>
        /// Peek at the last value stored in memory and return it without removing from memory.
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory
        /// </returns>
        int ReviewLastValue();
        
        /// <summary>
        /// Peek at the last value stored in memory and return it without removing from memory.
        /// If no value has been stored, return the supplied default value
        /// </summary>
        /// <returns>
        /// Returns the last integer value stored in memory
        /// </returns>
        /// <param name="defaultValue">the default value to return if the stack is empty.</param>
        int ReviewLastValueOrDefault(int defaultValue);
        
        /// <summary>
        /// Store the supplied value in memory
        /// </summary>
        /// <param name="value">the default value to return if there is nothing in memory.</param>
        void StoreValue(int value);

        #endregion


    }
}