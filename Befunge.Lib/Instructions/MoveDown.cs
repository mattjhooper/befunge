using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Start moving down
    /// </summary>
    public class MoveDown : Direction, IInstruction {
        #region lazy_singleton
        private static readonly Lazy<MoveDown> _lazyMoveDownSingleton = new Lazy<MoveDown>(() => new MoveDown());

        #endregion

        #region constructors
        private MoveDown() {
            
        }

        #endregion
        
        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = befungeRunTime.MaxExtent.y == befungeRunTime.CurrentPosition.y ? 0 : befungeRunTime.CurrentPosition.y+1;
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x, y);            
            base.Execute(befungeRunTime);
        }

        /// <summary>
        /// Return the instance
        /// </summary>
        /// <returns>
        /// Return the singleton instance of MoveDown
        /// </returns>
        public static MoveDown Instance { get { return _lazyMoveDownSingleton.Value; } }
    }
}