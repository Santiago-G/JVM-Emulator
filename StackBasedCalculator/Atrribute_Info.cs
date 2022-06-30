using StackBasedCalculator.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public abstract class Atrribute_Info
    {
        public ushort Attribute_Name_Index { get; private set; }
        public uint Attribute_Length { get; private set; }

        public Atrribute_Info(ref ReadOnlySpan<byte> view)
        {
            Attribute_Name_Index = view.U2();
            Attribute_Length = view.U4();
        }

        abstract public IEnumerable<byte> ToBytes();

        public static Atrribute_Info ParseGeneral(ref ReadOnlySpan<byte> view, Cp_Info[] Constant_pool)
        {
            ushort Attribute_Name_Index = (ushort)(view[0] << 8 | view[1]);

            CONSTANT_Utf8 maybeCode = (CONSTANT_Utf8)(Constant_pool[Attribute_Name_Index - 1]);

            if (maybeCode.Bytes.BytesToString() == "Code")
            {
                return new Code_Attriubte_Info(ref view);
            }
            else
            {
                return  new Basic_Code_Attribute(ref view);
            }
        }
    }
}
