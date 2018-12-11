using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_AddShould
    {
        private readonly IInstruction _add;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_AddShould() 
        {
            _add = new Add();
            _runtime = new Mock<IBefungeRunTime>();
        }

        [Fact]
        public void RetrieveValues() {
            // Arrange
            _runtime.Setup(r => r.RetrieveLastValue()).Returns(1);

            // Act
            _add.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(2));


        }
 
        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(1).Returns(2);

            // Act
            _add.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==3)), Times.Exactly(1));

        }
    }
}