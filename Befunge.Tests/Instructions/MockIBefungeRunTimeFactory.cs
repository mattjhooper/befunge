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
            Mock<NumberMode> _mode = new Mock<NumberMode>();
            _runtime.SetupProperty(r => r.CurrentDirection, _direction.Object);
            _runtime.SetupProperty(r => r.CurrentMode, _mode.Object);

            return _runtime;
        }
    }
}