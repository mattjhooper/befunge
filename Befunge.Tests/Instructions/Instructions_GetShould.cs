using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_GetShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_GetShould() 
        {
            _sit = new Get();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Theory]
        [InlineData('a', 97)]
        [InlineData('b', 98)]
        public void GetCorrectValue(char getValue, int storeValue) {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(2).Returns(1);
            _runtime.Setup(r => r.GetValue(It.Is<CoOrds>(xy => xy.x == 1 && xy.y == 2))).Returns(getValue);
            
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==storeValue)), Times.Exactly(1));
        }            
    }
}