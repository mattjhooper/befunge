using System;
using System.Collections.Generic;

namespace Befunge
{
    public class BefungeInterpreter {
        private static CoOrds currPos;
        private static List<string[]> codeGrid;

        public static string interpret(string befungeCode) {

            currPos = new CoOrds(0,0);
            char currVal = befungeCode[currPos.x];
            string returnVal = "";

            while (currVal != '@') {
                returnVal += currVal;
                currVal = befungeCode[++currPos.x];
            }

            return returnVal;
            
        }
    }
}