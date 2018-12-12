using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_ModuloShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_ModuloShould() 
        {
            _sit = new Modulo();
            _runtime = new Mock<IBefungeRunTime>();
        }

        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(3).Returns(10);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==1)), Times.Exactly(1));

        }

        [Fact]
        public void HandleZeroDivisor() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(0).Returns(1);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==0)), Times.Exactly(1));

        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 10)]
        [InlineData(-1, 1)]
        [InlineData(1, 1)]
        public void PushCorrectResults(int a, int b) {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(a).Returns(b);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==(b%a))), Times.Exactly(1));

        }
    }
}