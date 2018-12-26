using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveRight : Direction, IInstruction {
        #region lazy_singleton
        private static readonly Lazy<MoveRight> _lazyMoveRightSingleton = new Lazy<MoveRight>(() => new MoveRight());

        #endregion

        #region constructors
        private MoveRight() {
            
        }

        #endregion
        public override void Execute(IBefungeRunTime befungeRunTime) {
            int x = befungeRunTime.MaxExtent.x == befungeRunTime.CurrentPosition.x ? 0 : befungeRunTime.CurrentPosition.x+1;
            befungeRunTime.CurrentPosition = new CoOrds(x, befungeRunTime.CurrentPosition.y);            
            base.Execute(befungeRunTime);            
        }

        public static MoveRight Instance { get { return _lazyMoveRightSingleton.Value; } }
    }
}