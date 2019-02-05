using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_EndProgramShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_EndProgramShould()
        {
            _sit = new EndProgram();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void SetEndProgram()
        {
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            _runtime.VerifySet(r => r.EndProgram = true);
        }


    }
}