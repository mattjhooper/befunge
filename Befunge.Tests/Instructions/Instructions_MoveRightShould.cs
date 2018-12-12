using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_MoveRightShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_MoveRightShould() 
        {
            _sit = new MoveRight();
            _runtime = new Mock<IBefungeRunTime>();
        }

        [Fact]
        public void MoveInCorrectDirection() {
            // Arrange
            _runtime.SetupProperty(r => r.CurrPos, new CoOrds(0,0));

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrPos = new CoOrds(1,0));             
        }
    }
}