using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_AskForANumberShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_AskForANumberShould() 
        {
            _sit = new AskForANumber();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void PushCorrectResult() {
            // Arrange
            _runtime.Setup(r => r.Input(It.IsAny<string>())).Returns("1");

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.Input(It.Is<string>(s=>s=="Please supply an Integer:")), Times.Exactly(1));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==1)), Times.Exactly(1));

        }  

        [Fact]
        public void KeepTryingUntilANumberIsReturned() {
            // Arrange
            _runtime.SetupSequence(r => r.Input(It.IsAny<string>())).Returns("A").Returns("B").Returns("1");

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.Input(It.Is<string>(s=>s=="Please supply an Integer:")), Times.Exactly(3));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i==1)), Times.Exactly(1));

        }          
    }
}