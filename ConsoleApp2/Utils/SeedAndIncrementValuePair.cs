using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2.Utils
{
    class SeedAndIncrementValuePair
    {
        private Int32 seed = 0;
        private Int32 incrementValue = 0;

        public SeedAndIncrementValuePair(Int32 seed, Int32 incrementValue)
        {
            this.seed = seed;
            this.incrementValue = incrementValue;
        }

        public void IncrementSeed() {
            seed += incrementValue;
        }
        public Int32 Seed => seed;
        public Int32 IncrementValue => incrementValue; 
    }
}
