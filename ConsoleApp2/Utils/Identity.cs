using ConsoleApp2.models;
using System;
using System.Collections.Generic;

namespace ConsoleApp2.Utils
{
    [Serializable]
    public class Identity 
    {
        private readonly Dictionary<Type, SeedAndIncrementValuePair> objectAndTheirInitialPair
                = new Dictionary<Type, SeedAndIncrementValuePair>();




        public void InitType(Type target, Int32 seedValue, Int32 incrementValue)
        {
            if(!objectAndTheirInitialPair.ContainsKey(target))
                objectAndTheirInitialPair[target] = new SeedAndIncrementValuePair(seedValue, incrementValue);
        }


        public Int32 GetNextValue(Type o)
        {
            SeedAndIncrementValuePair currentObjectPair;

            if(!objectAndTheirInitialPair.TryGetValue(o, out currentObjectPair)){
                throw new ArgumentException("Object should be Initialized before try to get next value");
            }
            else
            {
                currentObjectPair.IncrementSeed();
                return currentObjectPair.Seed;
            }
        }

       
    }
}
