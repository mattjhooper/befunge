using System;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions {
    public static class MockIBefungeRunTimeFactory {
        public static Mock<IBefungeRunTime> Create() {
            Mock<IBefungeRunTime> _runtime = new Mock<IBefungeRunTime>();
            Mock<Direction> _direction = new Mock<Direction>();
            _runtime.SetupProperty(r => r.CurrentDirection, _direction.Object);

            return _runtime;
        }
    }
}