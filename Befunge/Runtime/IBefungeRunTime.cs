using System;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {

    public interface IBefungeRunTime {
        Direction CurrentDirection { get; set; }
        char CurrentInstruction { get; }

        IMode CurrentMode { get; set; }

        CoOrds CurrPos { get; set; }
        bool EndProgram { get; set; }

        string Output { get; set; }

        void ExecuteInstruction();
        void StoreValue(int value);
        int RetrieveLastValue();
        int RetrieveLastValueOrDefault(int defaultValue);

        int ReviewLastValue();
        int ReviewLastValueOrDefault(int defaultValue);


        void ReadInstruction();


    }
}