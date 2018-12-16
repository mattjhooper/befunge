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
        [InlineData(typeof(MoveDown), 0, 0, 0, 2)]
        [InlineData(typeof(MoveLeft), 2, 0, 0, 0)]
        [InlineData(typeof(MoveRight), 0, 0, 2, 0)]
        [InlineData(typeof(MoveUp), 0, 2, 0, 0)]
        public void SkipNextCellInCorrectDIrection(Type currentDirectionType, int oldX, int oldY, int newX, int newY) {
            // Arrange
            Direction currentDirection = (Direction)Activator.CreateInstance(currentDirectionType);
            _runtime.SetupProperty(r => r.CurrPos, new CoOrds(oldX, oldY));
            _runtime.SetupProperty(r => r.CurrentDirection, currentDirection);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrPos = new CoOrds(newX, newY));   
        }

    }
}