using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_Float : Cp_Info
    {
        public uint Bytes { get; private set; }
        public CONSTANT_Float(ref ReadOnlySpan<byte> view)
        {
            Bytes = view.U4();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Tag);
            iHateThisSoMuch.AddRange(Bytes.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
