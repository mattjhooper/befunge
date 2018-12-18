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
        private readonly BefungeRunTime _runtime;

        public BefungeRuntime_Should() {
            
            _runtime = new BefungeRunTime(_befungeCode, NumberMode.Instance);
        }

        [Fact]
        public void HaveCorrectDefaultCurrPos() {
            // Assert
            Assert.Equal(new CoOrds(0,0), _runtime.CurrentPosition);

        }

        [Fact]
        public void HaveCorrectDefaultCurrentInstruction() {
            // Assert
            Assert.Equal('>', _runtime.CurrentInstruction);

        }

        [Fact]
        public void HaveCorrectDefaultCurrentDirection() {
            // Assert
            Assert.True(_runtime.CurrentDirection is MoveRight);

        }

        [Fact]
        public void HaveCorrectDefaultEndProgram() {
           
            // Assert
            Assert.False(_runtime.EndProgram);

        }

        [Fact]
        public void HaveCorrectDefaultMode() {
            // Assert
            Assert.True(_runtime.CurrentMode.IsNumberMode);

        }

        [Fact]
        public void HaveCorrectMaxExtent() {
            var defaultExtent = _runtime.MaxExtent;

            // Act
            _runtime.CurrentPosition = new CoOrds(0,2);
            
            // Assert
            Assert.Equal(new CoOrds(7,2), defaultExtent);
            Assert.Equal(new CoOrds(8,2), _runtime.MaxExtent);


        }

        [Fact]
        public void StoreAndRetrieveResults() {
            // Act
            _runtime.StoreValue(3);
            _runtime.StoreValue(2);
            _runtime.StoreValue(1);

            // Assert
            Assert.Equal(1, _runtime.RetrieveLastValue());
            Assert.Equal(2, _runtime.RetrieveLastValue());
            Assert.Equal(3, _runtime.RetrieveLastValue());
            Assert.Equal(4, _runtime.RetrieveLastValueOrDefault(4));

        }

        [Fact]
        public void StoreAndReviewResults() {
             // Act
            _runtime.StoreValue(3);
            _runtime.StoreValue(2);
            _runtime.StoreValue(1);

            // Assert
            Assert.Equal(1, _runtime.ReviewLastValue());
            Assert.Equal(1, _runtime.ReviewLastValue());
            Assert.Equal(1, _runtime.RetrieveLastValue());
            Assert.Equal(2, _runtime.ReviewLastValue());
            Assert.Equal(2, _runtime.RetrieveLastValue());
            Assert.Equal(3, _runtime.RetrieveLastValue());
            Assert.Equal(4, _runtime.ReviewLastValueOrDefault(4));

        }

        [Fact]
        public void MovePositionAndReadInstruction() {
            // Act
            _runtime.CurrentPosition = new CoOrds(1,1);
            _runtime.ReadInstruction();

            // Assert
            Assert.Equal('4', _runtime.CurrentInstruction);
        }

        [Fact]
        public void PutAndGetCorrectValue() {
             var putPosition = new CoOrds(1,1);

            // Act
            _runtime.PutValue(putPosition, 'X');

            
            // Assert
            Assert.Equal('X', _runtime.GetValue(putPosition));
        }

    }
}    