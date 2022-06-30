using StackBasedCalculator.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using static StackBasedCalculator.Enums;

namespace StackBasedCalculator
{
    public class Method_Info
    {
        public MethodAccessFlags Access_Flags { get; private set; }
        public ushort Name_Index { get; private set; }
        public ushort Descriptor_Index { get; private set; }
        public ushort Attributes_Count { get; private set; }
        public Atrribute_Info[] Attributes {get; private set;}

        public Method_Info(ref ReadOnlySpan<byte> view, Cp_Info[] Constant_pool)
        {
            Access_Flags = (MethodAccessFlags)view.U2();
            Name_Index = view.U2();
            Descriptor_Index = view.U2();
            Attributes_Count = view.U2();
            Attributes = new Atrribute_Info[Attributes_Count];

            for (int i = 0; i < Attributes.Length; i++)
            {
                Attributes[i] = Atrribute_Info.ParseGeneral(ref view, Constant_pool);
            }
        }

        public IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Access_Flags.ToBytes());
            iHateThisSoMuch.AddRange(Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Descriptor_Index.ToBytes());
            iHateThisSoMuch.AddRange(Attributes_Count.ToBytes());
            foreach (var item in Attributes)
            {
                iHateThisSoMuch.AddRange(item.ToBytes());
            }
            return iHateThisSoMuch;
        }
    }
}
