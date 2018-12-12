using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_GreaterThanShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_GreaterThanShould() 
        {
            _sit = new GreaterThan();
            _runtime = new Mock<IBefungeRunTime>();
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
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==(b>a ? 1 : 0))), Times.Exactly(1));

        }
    }
}