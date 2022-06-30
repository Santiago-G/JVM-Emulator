using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public class Basic_Code_Attribute : Atrribute_Info
    {
        public byte[] info;

        public Basic_Code_Attribute(ref ReadOnlySpan<byte> view) : base(ref view)
        {
            info = new byte[Attribute_Length];

            for (int i = 0; i < info.Length; i++)
            {
                info[i] = view.U1();
            }
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Attribute_Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Attribute_Length.ToBytes());
            iHateThisSoMuch.AddRange(info);

            return iHateThisSoMuch;
        }
    }
}
