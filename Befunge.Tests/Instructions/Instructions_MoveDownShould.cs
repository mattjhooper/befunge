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
            _sit = MoveDown.Instance;
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void MoveInCorrectDirection()
        {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(0, 0));

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(0, 1));
        }

        [Fact]
        public void WrapAround()
        {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentPosition, new CoOrds(0, 10));
            _runtime.SetupGet(r => r.MaxExtent).Returns(new CoOrds(10, 10));

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.CurrentPosition = new CoOrds(0, 0));
        }
    }
}