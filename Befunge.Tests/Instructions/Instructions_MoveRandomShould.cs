using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Befunge.Instructions;
using Befunge.Runtime;
using Moq;

namespace Befunge.UnitTests.Instructions
{
    public class Instructions_MoveRandomShould
    {
        private readonly IInstruction _sit;
        private readonly Mock<IBefungeRunTime> _runtime;

        public Instructions_MoveRandomShould() 
        {
            _sit = new MoveRandom();
            _runtime = MockIBefungeRunTimeFactory.Create();
        }

        [Fact]
        public void MoveRandomly() {
            // Arrange
            // Setup a dictionary to keep a count of the number of directions
            Dictionary<Type, int> directionCount = new Dictionary<Type, int>();
            directionCount.Add(typeof(MoveDown), 0);
            directionCount.Add(typeof(MoveLeft), 0);
            directionCount.Add(typeof(MoveRight), 0);
            directionCount.Add(typeof(MoveUp), 0);

            for (int i=0; i<20; i++) {
                // Act
                _sit.Execute(_runtime.Object);

                Type t = _runtime.Object.CurrentDirection.GetType();

                directionCount[t] = ++directionCount[t];
            }

            // Assert
            Assert.True(directionCount.All( v => 1 <= v.Value ));
            
        }

        // [Theory]
        // [InlineData(1)]
        // [InlineData(2)]
        // [InlineData(10)]
        // [InlineData(-1)]
        // public void MoveUpForOthers(int val) {
        //     // Arrange
        //     _runtime.SetupSequence(r => r.RetrieveLastValue()).Returns(val);

        //     // Act
        //     _sit.Execute(_runtime.Object);

        //     // Assert
        //     Type t = _runtime.Object.CurrentDirection.GetType();

        //     // Assert
        //     Assert.Equal(typeof(MoveUp), t);           
        // }

    }
}
