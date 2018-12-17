using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_OutputNumberShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_OutputNumberShould() 
        {
            _sit = new OutputNumber();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void OutputCorrectResult() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(1);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.Output = "1");

        }
    }
}