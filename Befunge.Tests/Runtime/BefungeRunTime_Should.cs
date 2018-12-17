using System;
using Xunit;
using Befunge.Instructions;
using Befunge.Mode;
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
            Assert.Equal(new CoOrds(0,0), sit.CurrentPosition);

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
            
            // Assert
            Assert.True(sit.CurrentDirection is MoveRight);

        }

        [Fact]
        public void HaveCorrectDefaultEndProgram() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Assert
            Assert.False(sit.EndProgram);

        }

        [Fact]
        public void HaveCorrectDefaultMode() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Assert
            Assert.True(sit.CurrentMode is NumberMode);

        }

        [Fact]
        public void HaveCorrectMaxExtent() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);

            var defaultExtent = sit.MaxExtent;

            // Act
            sit.CurrentPosition = new CoOrds(0,2);
            
            // Assert
            Assert.Equal(new CoOrds(7,2), defaultExtent);
            Assert.Equal(new CoOrds(8,2), sit.MaxExtent);


        }

        [Fact]
        public void StoreAndRetrieveResults() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Act
            sit.StoreValue(3);
            sit.StoreValue(2);
            sit.StoreValue(1);

            // Assert
            Assert.Equal(1, sit.RetrieveLastValue());
            Assert.Equal(2, sit.RetrieveLastValue());
            Assert.Equal(3, sit.RetrieveLastValue());
            Assert.Equal(4, sit.RetrieveLastValueOrDefault(4));

        }

        [Fact]
        public void StoreAndReviewResults() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Act
            sit.StoreValue(3);
            sit.StoreValue(2);
            sit.StoreValue(1);

            // Assert
            Assert.Equal(1, sit.ReviewLastValue());
            Assert.Equal(1, sit.ReviewLastValue());
            Assert.Equal(1, sit.RetrieveLastValue());
            Assert.Equal(2, sit.ReviewLastValue());
            Assert.Equal(2, sit.RetrieveLastValue());
            Assert.Equal(3, sit.RetrieveLastValue());
            Assert.Equal(4, sit.ReviewLastValueOrDefault(4));

        }

        [Fact]
        public void MovePositionAndReadInstruction() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            // Act
            sit.CurrentPosition = new CoOrds(1,1);
            sit.ReadInstruction();

            // Assert
            Assert.Equal('4', sit.CurrentInstruction);
        }

        [Fact]
        public void PutAndGetCorrectValue() {
            // Arrange
            BefungeRunTime sit = new BefungeRunTime(_befungeCode);
            
            var putPosition = new CoOrds(1,1);

            // Act
            sit.PutValue(putPosition, 'X');

            
            // Assert
            Assert.Equal('X', sit.GetValue(putPosition));
        }

    }
}    