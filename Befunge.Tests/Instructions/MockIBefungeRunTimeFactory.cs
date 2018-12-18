using System;
using Befunge.Instructions;
using Befunge.Mode;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions {
    public static class MockIBefungeRunTimeFactory {
        public static Mock<IBefungeRunTime> Create() {
            Mock<IBefungeRunTime> _runtime = new Mock<IBefungeRunTime>();
            Mock<Direction> _direction = new Mock<Direction>();
            Mock<IMode> _mode = new Mock<IMode>(); 
            _mode.SetupGet(m => m.IsNumberMode).Returns(true);

            _runtime.SetupProperty(r => r.CurrentDirection, _direction.Object);
            _runtime.SetupProperty(r => r.CurrentMode, _mode.Object);
            _runtime.SetupGet(r => r.MaxExtent).Returns(new CoOrds(10,10));

            return _runtime;
        }
    }
}