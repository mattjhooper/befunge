using System;
using System.IO;
using System.Collections.Generic;
using Befunge.Runtime;
using Befunge.Mode;

namespace Befunge
{
/// <summary>
/// Main Befunge class.
/// Contains the Interpret method that can be used to interpret Befunge code
/// </summary>
public class BefungeInterpreter {

        /// <summary>
        /// Interprets the supplied befungeCode and returns the output as a string
        /// </summary>
        /// <returns>
        /// Returns the output of the supplied code
        /// </returns>
        /// <example>
        /// <code>
        /// string theOutput = BefungeInterpreter.Interpret(">321...@");
        /// </code>
        /// <code>
        /// string theOutput = BefungeInterpreter.Interpret(">321...@", Console.Out);
        /// </code>
        /// </example>
        /// <param name="befungeCode">A String containing befunge code.</param>
        /// <param name="outputStream">An optional TextWriter. It can be used to output to a file.</param>
        public static string Interpret(string befungeCode, TextWriter outputStream = null) {

            IMode mode = NumberMode.Instance;
            IBefungeRunTime runTime = new BefungeRunTime(befungeCode, mode, outputStream);
            
            while (!runTime.EndProgram) {
                runTime.ExecuteInstruction();
            }

            return runTime.Output;
            
        }
    }
}