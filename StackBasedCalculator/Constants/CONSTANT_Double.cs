using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class  CONSTANT_Double : Cp_Info
    {
        public uint High_Bytes { get; private set; }
        public uint Low_Bytes { get; private set; }

        public CONSTANT_Double(ref ReadOnlySpan<byte> view)
        {
            High_Bytes = view.U4();
            Low_Bytes = view.U4();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(High_Bytes.ToBytes());
            iHateThisSoMuch.AddRange(Low_Bytes.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
