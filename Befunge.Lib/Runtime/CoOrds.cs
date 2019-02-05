using System;

namespace Befunge.Runtime
{
    /// <summary>
    /// CoOrds.
    /// Represents a two dimensional point on an x/y axis.
    /// </summary>
    public struct CoOrds
    {
        /// <summary>
        /// x and y coordinates
        /// </summary>
        public int x, y;

        /// <summary>
        /// Initialise a new x/y CoOrd
        /// </summary>
        /// <example>
        /// <code>
        /// CoOrds startPoint = new CoOrds(0, 0);
        /// </code>
        /// <code>
        /// string theOutput = BefungeInterpreter.Interpret(">321...@", Console.Out);
        /// </code>
        /// </example>
        /// <param name="inX">Zero based horizontal position (x).</param>
        /// <param name="inY">Zero based vertical position (y).</param>
        public CoOrds(int inX, int inY)
        {
            x = inX;
            y = inY;
        }
    }
}
