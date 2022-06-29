using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_String : Cp_Info
    {
        public ushort string_Index { get; private set; }

        public CONSTANT_String(ref ReadOnlySpan<byte> view)
        {
            string_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Tag);
            iHateThisSoMuch.AddRange(string_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
