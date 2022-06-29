using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_MethodHandle : Cp_Info
    {
        public byte Reference_Kind { get; private set; }
        public ushort Reference_Index { get; private set; }

        public CONSTANT_MethodHandle(ref ReadOnlySpan<byte> view)
        {
            Reference_Kind = view.U1();
            Reference_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Reference_Kind);
            iHateThisSoMuch.AddRange(Reference_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
