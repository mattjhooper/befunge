using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_Discard
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_Discard() 
        {
            _sit = new Discard();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        
        [Fact]
        public void PushCorrectResults() {
            // Arrange
            _runtime.Setup(r => r.RetrieveLastValue()).Returns(0);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(1));
        }
    }
}