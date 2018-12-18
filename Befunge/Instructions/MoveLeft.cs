using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveLeft : Direction, IInstruction {
        #region lazy_singleton
        private static readonly Lazy<MoveLeft> _lazyMoveLeftSingleton = new Lazy<MoveLeft>(() => new MoveLeft());

        #endregion

        #region constructors
        private MoveLeft() {
            
        }

        #endregion
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int x = 0 == befungeRunTime.CurrentPosition.x ? befungeRunTime.MaxExtent.x : befungeRunTime.CurrentPosition.x-1;
            befungeRunTime.CurrentPosition = new CoOrds(x, befungeRunTime.CurrentPosition.y);            
            base.Execute(befungeRunTime);
        }

        public static MoveLeft Instance { get { return _lazyMoveLeftSingleton.Value; } }
    }
}