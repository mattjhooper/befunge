using System;
using Befunge.Runtime;

namespace Befunge.Instructions {
    public class MoveUp : Direction, IInstruction {
        #region lazy_singleton
        private static readonly Lazy<MoveUp> _lazyMoveUpSingleton = new Lazy<MoveUp>(() => new MoveUp());

        #endregion

        #region constructors
        private MoveUp() {
            
        }

        #endregion

        public override void Execute(IBefungeRunTime befungeRunTime) {
            int y = 0 == befungeRunTime.CurrentPosition.y ? befungeRunTime.MaxExtent.y : befungeRunTime.CurrentPosition.y-1;
            befungeRunTime.CurrentPosition = new CoOrds(befungeRunTime.CurrentPosition.x, y);            
            base.Execute(befungeRunTime);
        }

        public static MoveUp Instance { get { return _lazyMoveUpSingleton.Value; } }
    }
}