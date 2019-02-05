using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_AskForACharacterShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_AskForACharacterShould()
        {
            _sit = new AskForACharacter();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void PushCorrectResult()
        {
            // Arrange
            _runtime.Setup(r => r.Input(It.IsAny<string>())).Returns("a");

            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.Verify(r => r.Input(It.Is<string>(s => s == "Please supply a Character:")), Times.Exactly(1));
            _runtime.Verify(r => r.StoreValue(It.Is<int>(i => i == 97)), Times.Exactly(1));

        }
    }
}