using System;
using Xunit;
using Befunge;

namespace Befunge.Test
{
    public class Arithmetic
    {
        [Fact]
        public void CanReadAndReturn()
        {
            Assert.Equal("9", BefungeInterpreter.interpret("9.@"));
        }
        
         
        [Fact]
        public void AdditionWorks()
        {
            Assert.Equal("3", BefungeInterpreter.interpret("21+.@"));
        }  
              
    }
}
