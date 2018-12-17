using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_MoveDownShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_MoveDownShould() 
        {
            _sit = new MoveDown();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void MoveInCorrectDirection() {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(0,0));

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(0,1));             
        }
    }
}