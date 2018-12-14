using System;
using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;

namespace Befunge.UnitTests.Runtime
{
    public class BefungeRuntime_Should
    {
        private static readonly string _befungeCode = ">987v>.v\nv456<  :\n>321 ^ _@";

        [Fact]
        public void HaveCorrectDefaultCurrPos() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);

            // Assert
            Assert.Equal(new CoOrds(0,0), sit.CurrPos);

        }

        [Fact]
        public void HaveCorrectDefaultCurrentInstruction() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);

            // Assert
            Assert.Equal('>', sit.CurrentInstruction);

        }

        [Fact]
        public void HaveCorrectDefaultCurrentDirection() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Act
            Type t = sit.CurrentDirection.GetType();

            // Assert
            Assert.Equal(typeof(MoveRight), t);

        }

    }
}    