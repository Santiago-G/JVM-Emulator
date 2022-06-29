using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public abstract class Cp_Info
    {
        public byte Tag;

        public abstract IEnumerable<byte> ToBytes();
    }
}
