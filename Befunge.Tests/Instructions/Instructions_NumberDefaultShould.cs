using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_NumberDefaultShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_NumberDefaultShould()
        {
            _sit = new NumberDefault();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Theory]
        [InlineData('0', 0)]
        [InlineData('1', 1)]
        [InlineData('2', 2)]
        [InlineData('3', 3)]
        [InlineData('4', 4)]
        [InlineData('5', 5)]
        [InlineData('6', 6)]
        [InlineData('7', 7)]
        [InlineData('8', 8)]
        [InlineData('9', 9)]
        public void ShouldStoreNumber(char inValue, int outValue)
        {
            // Arrange
            _runtime.SetupGet(r => r.CurrentInstruction).Returns(inValue);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i == outValue)), Times.Exactly(1));
        }

        [Fact]
        public void ShouldThrowUnsupportedInstructionException()
        {
            // Arrange
            _runtime.SetupGet(r => r.CurrentInstruction).Returns('X');

            // Act
            var ex = Assert.Throws<UnsupportedInstructionException>(() => _sit.Execute(_runtime.Object));

        }
    }
}