using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_InvokeDynamic : Cp_Info
    {
        public ushort Bootstrap_Method_Attr_Index { get; private set; }
        public ushort Name_And_Type_Index { get; private set; }

        public CONSTANT_InvokeDynamic(ref ReadOnlySpan<byte> view)
        {
            Bootstrap_Method_Attr_Index = view.U2();
            Name_And_Type_Index = view.U2();
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Bootstrap_Method_Attr_Index.ToBytes());
            iHateThisSoMuch.AddRange(Name_And_Type_Index.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
