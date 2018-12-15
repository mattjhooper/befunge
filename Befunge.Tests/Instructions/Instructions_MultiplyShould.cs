using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_MultiplyShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_MultiplyShould() 
        {
            _sit = new Multiply();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(1).Returns(2);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==2)), Times.Exactly(1));

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
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==(a*b))), Times.Exactly(1));

        }
    }
}