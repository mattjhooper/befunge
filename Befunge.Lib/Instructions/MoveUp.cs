using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    /// <summary>
    /// Start moving right
    /// </summary>
    public class MoveUp : Direction, IInstruction {
        #region lazy_singleton
        private static readonly Lazy<MoveUp> _lazyMoveUpSingleton = new Lazy<MoveUp>(() => new MoveUp());

        #endregion

        #region constructors
        private MoveUp() {
            
        }

        #endregion

        /// <summary>
        /// Execute the instruction
        /// </summary>
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = 0 == befungeRunTime.CurrentPosition.y ? befungeRunTime.MaxExtent.y : befungeRunTime.CurrentPosition.y-1;
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x, y);            
            base.Execute(befungeRunTime);
        }

        /// <summary>
        /// Return the instance
        /// </summary>
        /// <returns>
        /// Return the singleton instance of MoveUp
        /// </returns>
        public static MoveUp Instance { get { return _lazyMoveUpSingleton.Value; } }
    }
}