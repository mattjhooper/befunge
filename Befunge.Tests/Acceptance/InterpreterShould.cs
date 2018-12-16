using System;
using Xunit;
using Befunge;

namespace Befunge.AcceptanceTests
{
    public class InterpreterShould
    {
        [Fact]
        public void ReadAndReturnANumber()
        {
            Assert.Equal("9", BefungeInterpreter.interpret("9.@"));
        }
        
         
        [Fact]
        public void AddTwoNumbers()
        {
            Assert.Equal("3", BefungeInterpreter.interpret("21+.@"));
        }  

        [Theory]
        [InlineData("11+2+2*.@","8")]
        [InlineData("54321.....@","12345")]
        [InlineData("21`9*55+*.@","90")]
        [InlineData("21`9*55+*9+9/.@","11")]
        public void HandleMultipleInstructions(string testInput, string expectedOutput)
        {
            Assert.Equal(expectedOutput, BefungeInterpreter.interpret(testInput));
        } 

        [Fact]
        public void HandleDirectionChanges()
        {
            Assert.Equal("123456789", BefungeInterpreter.interpret(">987v>.v\nv456<  :\n>321 ^ _@"));
        } 

        [Fact]
        public void HandleFactorial()
        {
            Assert.Equal("40320", BefungeInterpreter.interpret("08>:1-:v v *_$.@ \n  ^    _$>\\:^  ^    _$>\\:^"));
        }

        [Fact]
        public void HandleLogicalNot()
        {
            Assert.Equal("0", BefungeInterpreter.interpret("9!.@"));
            Assert.Equal("1", BefungeInterpreter.interpret("0!.@"));
        }  

        [Fact]
        public void PrintHelloWorld()
        {
            Assert.Equal("Hello World!\n", BefungeInterpreter.interpret(">25*\"!dlroW olleH\":v\n                v:,_@\n                >  ^"));
        } 

        [Fact]
        public void HandleRandomDirection()
        {            
            string output = BefungeInterpreter.interpret("v@.<\n >1^\n>?<^\n >2^");
            Assert.True("1" == output || "2" == output);
        } 

        [Fact]
        public void HandleSieve()
        {
            string befungeCode = "2>:3g\" \"-!v\\  g30          <\n |!`\"&\":+1_:.:03p>03g+:\"&\"`|\n @               ^  p3\\\" \":<\n2 2345678901234567890123456789012345678";
            Assert.Equal("23571113171923293137", BefungeInterpreter.interpret(befungeCode));

        }

        [Fact]
        public void HandleQuine()
        {
            string befungeCode = "01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@";
            Assert.Equal("01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@", BefungeInterpreter.interpret(befungeCode));

        }
     }
}
