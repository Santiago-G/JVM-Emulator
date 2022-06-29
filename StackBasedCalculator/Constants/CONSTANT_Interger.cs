using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_Interger : Cp_Info
    {
        public uint Bytes { get; private set; }

        public CONSTANT_Interger(ref ReadOnlySpan<byte> view)
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
