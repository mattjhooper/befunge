using System;
using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_PipeShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_PipeShould() 
        {
            _sit = new Pipe();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void MoveDownForZero() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(0);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            Type t = _runtime.Object.CurrentDirection.GetType();

            // Assert
            Assert.Equal(typeof(MoveDown), t);           
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(10)]
        [InlineData(-1)]
        public void MoveUpForOthers(int val) {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(val);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            Type t = _runtime.Object.CurrentDirection.GetType();

            // Assert
            Assert.Equal(typeof(MoveUp), t);           
        }

    }
}