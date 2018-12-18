using System;
using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_TrampolineShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_TrampolineShould() 
        {
            _sit = new Trampoline();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Theory]
        [InlineData(0, 0, 2, 0)]
        public void SkipNextCellWhenDirectionIsMoveRight(int oldX, int oldY, int newX, int newY) {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(oldX, oldY));
            _runtime.SetupProperty(r => r.CurrentDirection, MoveRight.Instance);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(newX, newY));   
        }

        [Theory]
        [InlineData(2, 0, 0, 0)]
        public void SkipNextCellWhenDirectionIsMoveLeft(int oldX, int oldY, int newX, int newY) {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(oldX, oldY));
            _runtime.SetupProperty(r => r.CurrentDirection, MoveLeft.Instance);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(newX, newY));   
        }

        [Theory]
        [InlineData(0, 0, 0, 2)]
        public void SkipNextCellWhenDirectionIsMoveDown(int oldX, int oldY, int newX, int newY) {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(oldX, oldY));
            _runtime.SetupProperty(r => r.CurrentDirection, MoveDown.Instance);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(newX, newY));   
        }

        [Theory]
        [InlineData(0, 2, 0, 0)]
        public void SkipNextCellWhenDirectionIsMoveUp(int oldX, int oldY, int newX, int newY) {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(oldX, oldY));
            _runtime.SetupProperty(r => r.CurrentDirection, MoveUp.Instance);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(newX, newY));   
        }

    }
}