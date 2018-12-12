using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_SubtractShould
    {
        private readonly IInstruction _add;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_SubtractShould() 
        {
            _add = new Subtract();
            _runtime = new Mock<IBefungeRunTime>();
        }

        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(5).Returns(10);

            // Act
            _add.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==5)), Times.Exactly(1));

        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        [InlineData(-1, 1)]
        [InlineData(1, 1)]
        [InlineData(0, 1)]
        public void PushCorrectResults(int a, int b) {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(a).Returns(b);

            // Act
            _add.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==(b-a))), Times.Exactly(1));

        }
    }
}