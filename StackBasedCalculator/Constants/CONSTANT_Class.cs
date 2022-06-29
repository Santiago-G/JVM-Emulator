using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_Class : Cp_Info
    {
        public ushort Name_Index { get; private set; }

        public CONSTANT_Class(ref ReadOnlySpan<byte> view)
        {
            Name_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Name_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
