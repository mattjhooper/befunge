using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_StringDefaultShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;
        
        public Instructions_StringDefaultShould() 
        {
            _sit = new StringDefault();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Theory]
        [InlineData('a', 97)]
        [InlineData('b', 98)]
        public void ShouldStoreASCIIValue(char inValue, int outValue) {
            // Arrange
            _runtime.SetupGet(r => r.CurrentInstruction).Returns(inValue); 
            
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==outValue)), Times.Exactly(1));
        }       
    }
}