using System;

namespace Befunge.Runtime {
    public interface IBefungeRunTime {
        char CurrentInstruction { get; set; }
        string Output { get; set; }
        void StoreValue(int value);
        int RetrieveLastValue();
        int RetrieveLastValueOrDefault(int defaultValue);


    }
}