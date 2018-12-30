using System;
using System.IO;
using Xunit;
using Befunge.Instructions;
using Befunge.Mode;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Runtime
{
    public class BefungeRuntime_Should
    {
        private static readonly string _befungeCode = ">987v>.v\nv456<  :\n>321 ^ _@";
        private readonly BefungeRunTime _runtime;

        private readonly Mock<TextReader> _textReaderMock;
        private readonly Mock<TextWriter> _textWriterMock;

        public BefungeRuntime_Should() {
            
            
            _textReaderMock = new Mock<TextReader>();
            _textWriterMock = new Mock<TextWriter>();
            _runtime = new BefungeRunTime(_befungeCode, NumberMode.Instance, _textWriterMock.Object, _textReaderMock.Object);
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
            
            // Assert
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
            // Arrange
            var putPosition = new CoOrds(1,1);

            // Act
            _runtime.PutValue(putPosition, 'X');

            
            // Assert
            Assert.Equal('X', _runtime.GetValue(putPosition));
        }

        [Fact]
        public void AlwaysHaveConsistentExtents() {
            // Arrange
            var defaultExtent = _runtime.MaxExtent;

            CoOrds position;
            position.x = 0;

            for (position.y = 1; position.y <= defaultExtent.y; position.y++) 
            {
                // Act
                _runtime.CurrentPosition = position; 
                Assert.Equal(_runtime.MaxExtent, defaultExtent);    
            }            
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 100)]
        [InlineData(100, 0)]
        public void RaiseInvalidOperationExceptionForBadPosition(int x, int y) {
            // Arrange
            CoOrds testPosition = new CoOrds(x, y);
            
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _runtime.CurrentPosition = testPosition);
            Assert.Equal(ex.Message, $"Invalid Position specified: [{x},{y}].");
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 100)]
        [InlineData(100, 0)]
        public void RaiseInvalidOperationExceptionForBadPutValuePosition(int x, int y) {
            // Arrange
            CoOrds testPosition = new CoOrds(x, y);
            
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _runtime.PutValue(testPosition, 'X'));
            Assert.Equal(ex.Message, $"Invalid Position specified: [{x},{y}].");
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(0, -1)]
        [InlineData(0, 100)]
        [InlineData(100, 0)]
        public void RaiseInvalidOperationExceptionForBadGetValuePosition(int x, int y) {
            // Arrange
            CoOrds testPosition = new CoOrds(x, y);
            
            // Assert
            var ex = Assert.Throws<InvalidOperationException>(() => _runtime.GetValue(testPosition));
            Assert.Equal(ex.Message, $"Invalid Position specified: [{x},{y}].");
        }

        [Fact]
        public void ThrowExceptionIfRetrieveLastValueIsCalledWhenStackIsEmpty() {
            
            // Assert
            Assert.Equal(1, _runtime.RetrieveLastValueOrDefault(1));
            var ex = Assert.Throws<InvalidOperationException>(() => _runtime.RetrieveLastValue());
            Assert.Equal($"Invalid Operation at position [{_runtime.CurrentPosition.x},{_runtime.CurrentPosition.y}]. Cannot retrieve a value when the stack is empty.", ex.Message);

        }

        [Fact]
        public void ThrowExceptionIfReviewLastValueIsCalledWhenStackIsEmpty() {
            
            // Assert
            Assert.Equal(1, _runtime.ReviewLastValueOrDefault(1));
            var ex = Assert.Throws<InvalidOperationException>(() => _runtime.ReviewLastValue());
            Assert.Equal($"Invalid Operation at position [{_runtime.CurrentPosition.x},{_runtime.CurrentPosition.y}]. Cannot review a value when the stack is empty.", ex.Message);

        }

        [Fact]
        public void OutputPromptAndReturnInput() {
            // Arrange
            string prompt = "Please provide a number.";
            _textReaderMock.Setup(r => r.ReadLine()).Returns("1");

            Assert.Equal('1', _runtime.Input(prompt));
            _textWriterMock.Verify(m => m.Write(It.Is<string>(s => s==prompt)), Times.Exactly(1));
        }
    }
}    