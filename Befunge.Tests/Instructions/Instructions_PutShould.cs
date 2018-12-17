using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_PutShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_PutShould() 
        {
            _sit = new Put();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void PutCorrectValue() {
            // Arrange
            _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(2).Returns(1).Returns(97);

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.RetrieveLastValue(), Times.Exactly(3));
            _runtime.Verify(r => r.PutValue(It.Is<CoOrds>(xy => xy.x == 1 && xy.y == 2) ,It.Is<char>(c => c=='a')), Times.Exactly(1));

        }        
    }
}