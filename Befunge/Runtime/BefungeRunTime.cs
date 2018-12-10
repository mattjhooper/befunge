using System;
using System.Text;
using System.Collections.Generic;

namespace Befunge.Runtime {
    public class BefungeRunTime : IBefungeRunTime {        
        private Stack<int> intStack;
        private StringBuilder output = new StringBuilder();

        public char CurrentInstruction { get; set; }
        public string Output 
        { get 
          { 
              return output.ToString();
          }
          set 
          {
              output.Append(value);
          }
    
        
        }

        public BefungeRunTime() {
            intStack = new Stack<int>();
        }
        public void StoreValue(int value) {
            intStack.Push(value);
        }
        public int RetrieveLastValue() {
            return intStack.Pop();
        }
        public int RetrieveLastValueOrDefault(int defaultValue) {
            return intStack.Count == 0 ? defaultValue : intStack.Pop();
        }
        
    }
}