using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class  CONSTANT_MethodType : Cp_Info
    {
        public ushort Descriptor_Index { get; private set; }

        public CONSTANT_MethodType(ref ReadOnlySpan<byte> view)
        {
            Descriptor_Index = view.U2();   
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Descriptor_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
