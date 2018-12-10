using System;

namespace Befunge.Runtime {
    public interface IBefungeRunTime {
        void storeValue(int value);
        int retrieveLastValue();

        int retrieveLastValueOrDefault(int defaultValue);
    }
}