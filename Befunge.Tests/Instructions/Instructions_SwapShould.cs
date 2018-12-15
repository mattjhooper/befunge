using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_SwapShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_SwapShould() 
        {
            _sit = new Swap();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.Setup(r => r.RetrieveLastValue()).Returns(1);
            _runtime.Setup(r => r.RetrieveLastValueOrDefault(0)).Returns(0);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValueOrDefault(0), Times.Exactly(1));
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(1));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==0)), Times.Exactly(1));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==1)), Times.Exactly(1));

        }

        // [Theory]
        // [InlineData(1)]
        // [InlineData(5)]
        // [InlineData(-1)]
        // [InlineData(0)]
        // public void PushCorrectResults(int a) {
        //     // Arrange
        //     _runtime.SetupSequence(r => r.ReviewLastValueOrDefault(0)).Returns(a);

        //     // Act
        //     _sit.Execute(_runtime.Object);

        //     // Assert
        //     _runtime.Verify(r => r.ReviewLastValueOrDefault(0), Times.Exactly(1));
        //     _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==a)), Times.Exactly(1));

        // }
    }
}