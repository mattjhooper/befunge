using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Amazon.Lambda.Core;
using Befunge;


// Assembly attribute to enable the Lambda function's JSON input to be converted into a .NET class.
[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))]

namespace BefungeLambda
{
    public class Function
    {
        
        /// <summary>
        /// A befunge interpreter function that takes a string of befungeCode and returns any output
        /// </summary>
        /// <param name="inputBefungeCode"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public string FunctionHandler(string inputBefungeCode, ILambdaContext context)
        {
            return BefungeInterpreter.Interpret(inputBefungeCode);
        }
    }
}
