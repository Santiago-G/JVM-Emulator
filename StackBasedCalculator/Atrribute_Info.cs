using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public class Atrribute_Info
    {
        public ushort Attribute_Name_Index { get; private set; }
        public uint Attribute_Length { get; private set; }
        public byte[] info;

        public Atrribute_Info(ref ReadOnlySpan<byte> view)
        {
            Attribute_Name_Index = view.U2();
            Attribute_Length = view.U4();
            info = new byte[Attribute_Length];

            for (int i = 0; i < info.Length; i++)
            {
                info[i] = view.U1();
            }
        }

        public IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Attribute_Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Attribute_Length.ToBytes());
            iHateThisSoMuch.AddRange(info);

            return iHateThisSoMuch;
        }
    }
}
