using System;
using Xunit;
using Befunge.Instructions;
using Befunge.Mode;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_ToggleStringModeShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_ToggleStringModeShould() 
        {
            _sit = new ToggleStringMode();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void TurnOnStringMode() {
            
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            Assert.True(_runtime.Object.CurrentMode is StringMode);           
        }

        [Fact]
        public void TurnOffStringMode() {
            // Arrange
            _runtime.SetupProperty(r => r.CurrentMode, (new Mock<StringMode>()).Object);
            
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            Assert.True(_runtime.Object.CurrentMode is NumberMode);           
        }

        

    }
}