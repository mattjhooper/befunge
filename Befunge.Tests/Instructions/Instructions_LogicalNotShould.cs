using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_LogicalNotShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_LogicalNotShould()
        {
            _sit = new LogicalNot();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }


        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(-1)]
        [InlineData(0)]
        public void PushCorrectResults(int val)
        {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(val);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(1));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i == (val == 0 ? 1 : 0))), Times.Exactly(1));

        }
    }
}