using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator.Constants
{
    public class CONSTANT_Utf8 : Cp_Info
    {
        public ushort Length { get; private set; }
        public byte[] Bytes { get; private set; }

        public CONSTANT_Utf8(ref ReadOnlySpan<byte> view)
        {
            Length = view.U2();

            Bytes = new byte[Length];

            for (int i = 0; i < Length; i++)
            {
                Bytes[i] = view.U1();
            }
            ;
        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(Tag);
            iHateThisSoMuch.AddRange(Length.ToBytes());
            iHateThisSoMuch.AddRange(Bytes);
            return iHateThisSoMuch;
        }
    }
}
