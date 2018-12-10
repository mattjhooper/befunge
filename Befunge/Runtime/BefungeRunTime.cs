using System;

namespace Befunge.Runtime {
    public class BefungeRunTime : IBefungeRunTime {
        private static Stack<int> intStack;
        
        public void storeValue(int value) {
            intStack.Push(value);
        }

        public int retrieveLastValue() {
            return intStack.Pop();
        }

        public int retrieveLastValueOrDefault(int defaultValue) {
            return intStack.Count == 0 ? defaultValue : intStack.Pop();
        }
    }
}