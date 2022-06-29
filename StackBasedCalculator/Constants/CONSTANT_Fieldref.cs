using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_Fieldref : Cp_Info
    {
        public ushort Class_Index { get; private set; }
        public ushort Name_And_Type_Index { get; private set; }

        public CONSTANT_Fieldref(ref ReadOnlySpan<byte> view)
        {
            Class_Index = view.U2();
            Name_And_Type_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Tag);
            iHateThisSoMuch.AddRange(Class_Index.ToBytes());
            iHateThisSoMuch.AddRange(Name_And_Type_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
