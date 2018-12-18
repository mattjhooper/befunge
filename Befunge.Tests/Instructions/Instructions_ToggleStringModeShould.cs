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
            Assert.False(_runtime.Object.CurrentMode.IsNumberMode);           
        }

        [Fact]
        public void TurnOffStringMode() {
            // Arrange
            Mock<IMode> mode = new Mock<IMode>(); 
            mode.SetupGet(m => m.IsNumberMode).Returns(false);
            _runtime.SetupProperty(r => r.CurrentMode, mode.Object);
            
            // Act
            _sit.Execute(_runtime.Object);

            // Assert
            Assert.True(_runtime.Object.CurrentMode.IsNumberMode);           
        }
    }
}