using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_NameAndType : Cp_Info
    {
        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }

        public CONSTANT_NameAndType(ref ReadOnlySpan<byte> view)
        {
            Name_Index = view.U2();
            Descriptor_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Tag);
            iHateThisSoMuch.AddRange(Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Descriptor_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
