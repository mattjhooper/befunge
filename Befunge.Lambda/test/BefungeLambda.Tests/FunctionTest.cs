using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Xunit;
using Amazon.Lambda.Core;
using Amazon.Lambda.TestUtilities;

using BefungeLambda;

namespace Befunge.Lambda.Tests
{
    public class FunctionTest
    {
        [Fact]
        public void TestInterpreterFunction()
        {

            // Invoke the lambda function and confirm the string was upper cased.
            var function = new Function();
            var context = new TestLambdaContext();
            var befungeOutput = function.FunctionHandler(">987v>.v\nv456<  :\n>321 ^ _@", context);

            Assert.Equal("123456789", befungeOutput);
        }
    }
}
