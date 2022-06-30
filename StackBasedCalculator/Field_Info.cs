using System;
using System.Collections.Generic;
using System.Text;
using static StackBasedCalculator.Enums;

namespace StackBasedCalculator
{
    public class Field_Info
    {
        public FieldAccessFlags Access_Flags { get; private set; }
        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }
        public ushort Attributes_Count { get; private set; }
        public Atrribute_Info[] attributes { get; private set; }

        public Field_Info(ref ReadOnlySpan<byte> view, Cp_Info[] Constant_pool)
        {
            Access_Flags = (FieldAccessFlags)view.U2();
            Name_Index = view.U2();
            Descriptor_Index = view.U2();
            Attributes_Count = view.U2();
            attributes = new Atrribute_Info[Attributes_Count];

            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i] = Atrribute_Info.ParseGeneral(ref view, Constant_pool);
            }
        }

        public IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Access_Flags.ToBytes());
            iHateThisSoMuch.AddRange(Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Descriptor_Index.ToBytes());
            iHateThisSoMuch.AddRange(Attributes_Count.ToBytes());
            foreach (var item in attributes)
            {
                iHateThisSoMuch.AddRange(item.ToBytes());
            }
            return iHateThisSoMuch;
        }
    }
}
