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
            Assert.Equal("9", BefungeInterpreter.Interpret("9.@"));
        }
        
         
        [Fact]
        public void AddTwoNumbers()
        {
            Assert.Equal("3", BefungeInterpreter.Interpret("21+.@"));
        }  

        [Theory]
        [InlineData("11+2+2*.@","8")]
        [InlineData("54321.....@","12345")]
        [InlineData("21`9*55+*.@","90")]
        [InlineData("21`9*55+*9+9/.@","11")]
        public void HandleMultipleInstructions(string testInput, string expectedOutput)
        {
            Assert.Equal(expectedOutput, BefungeInterpreter.Interpret(testInput));
        } 

        [Fact]
        public void HandleDirectionChanges()
        {
            Assert.Equal("123456789", BefungeInterpreter.Interpret(">987v>.v\nv456<  :\n>321 ^ _@"));
        } 

        [Fact]
        public void HandleFactorial()
        {
            Assert.Equal("40320", BefungeInterpreter.Interpret("08>:1-:v v *_$.@ \n  ^    _$>\\:^  ^    _$>\\:^"));
        }

        [Fact]
        public void HandleLogicalNot()
        {
            Assert.Equal("0", BefungeInterpreter.Interpret("9!.@"));
            Assert.Equal("1", BefungeInterpreter.Interpret("0!.@"));
        }  

        [Fact]
        public void PrintHelloWorld()
        {
            Assert.Equal("Hello World!\n", BefungeInterpreter.Interpret(">25*\"!dlroW olleH\":v\n                v:,_@\n                >  ^"));
            Assert.Equal("Hello World!", BefungeInterpreter.Interpret("v>  ,,,,,,,,,,,,@\n<^\"Hello World!\""));                         
        } 

        [Fact]
        public void HandleRandomDirection()
        {            
            string output = BefungeInterpreter.Interpret("v@.<\n >1^\n>?<^\n >2^");
            Assert.True("1" == output || "2" == output);
        } 

        [Fact]
        public void HandleSieve()
        {
            string befungeCode = "2>:3g\" \"-!v\\  g30          <\n |!`\"&\":+1_:.:03p>03g+:\"&\"`|\n @               ^  p3\\\" \":<\n2 2345678901234567890123456789012345678";
            Assert.Equal("23571113171923293137", BefungeInterpreter.Interpret(befungeCode));

        }

        [Fact]
        public void HandleQuine()
        {
            string befungeCode = "01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@";
            Assert.Equal("01->1# +# :# 0# g# ,# :# 5# 8# *# 4# +# -# _@", BefungeInterpreter.Interpret(befungeCode));

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        [InlineData(6)]
        [InlineData(7)]
        [InlineData(8)]
        [InlineData(9)]
        public void DetermineOddOrEven(int i)
        {
            Assert.Equal((i%2).ToString(), BefungeInterpreter.Interpret(">" + i.ToString() + " 2%v\n  @.1_0.@"));
        }

        [Theory]
        [InlineData(1, "t")]
        [InlineData(2, "t")]
        [InlineData(3, "f")]
        [InlineData(4, "t")]
        [InlineData(5, "f")]
        [InlineData(6, "f")]
        [InlineData(7, "f")]
        [InlineData(8, "t")]
        [InlineData(9, "f")]
        public void HandlePowerOf2(int i, string res) 
        {
            Assert.Equal(res, BefungeInterpreter.Interpret(">" + i + " : 2v2:    <\n      `      /\n      !      2 \n@,\"t\" _  :2%!|\n             >\"f\",@"));
        }
     }
}
