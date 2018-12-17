using System;
using Befunge.Instructions;
using Befunge.Mode;

namespace Befunge.Runtime {

    public interface IBefungeRunTime {

        #region properties
        Direction CurrentDirection { get; set; }
        char CurrentInstruction { get; }

        IMode CurrentMode { get; set; }

        CoOrds CurrentPosition { get; set; }
        bool EndProgram { get; set; }

        string Output { get; set; }

        #endregion

        #region methods

        void ExecuteInstruction();
        char GetValue(CoOrds getPosition);
        void PutValue(CoOrds putPosition, char value);
        void ReadInstruction();
        int RetrieveLastValue();
        int RetrieveLastValueOrDefault(int defaultValue);
        int ReviewLastValue();
        int ReviewLastValueOrDefault(int defaultValue);
        void StoreValue(int value);

        #endregion


    }
}