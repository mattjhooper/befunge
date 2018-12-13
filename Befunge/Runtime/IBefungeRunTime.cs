using System;
using Befunge.Instructions;

namespace Befunge.Runtime {
    public interface IBefungeRunTime {
        Direction CurrentDirection { get; set; }
        char CurrentInstruction { get; }
        CoOrds CurrPos { get; set; }

        string Output { get; set; }
        void StoreValue(int value);
        int RetrieveLastValue();
        int RetrieveLastValueOrDefault(int defaultValue);

        void ReadInstruction();


    }
}