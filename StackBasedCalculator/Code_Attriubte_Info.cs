using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public class Code_Attriubte_Info : Atrribute_Info
    {
        public ushort Max_Stack { get; private set; }
        public ushort Max_Local { get; private set; }
        public uint Code_Length { get; private set; }
        public byte[] Code;

        public ushort Exception_Table_Length { get; private set; }
        public Exceptions_Table[] exceptionsTable;
        public ushort Attributes_Count { get; private set; }
        public Basic_Code_Attribute[] attributes;

        public Code_Attriubte_Info(ref ReadOnlySpan<byte> view) : base(ref view)
        {
            Max_Stack = view.U2();
            Max_Local = view.U2();
            Code_Length = view.U4();
            Code = new byte[Code_Length];
            for (int i = 0; i < Code.Length; i++)
            {
                Code[i] = view.U1();
            }

            Exception_Table_Length = view.U2();
            exceptionsTable = new Exceptions_Table[Exception_Table_Length];
            for (int i = 0; i < exceptionsTable.Length; i++)
            {
                exceptionsTable[i] = new Exceptions_Table(ref view);
            }

            Attributes_Count = view.U2();
            attributes = new Basic_Code_Attribute[Attributes_Count];
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i] = new Basic_Code_Attribute(ref view);
            }

        }

        public override IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Attribute_Name_Index.ToBytes());
            iHateThisSoMuch.AddRange(Attribute_Length.ToBytes());
            iHateThisSoMuch.AddRange(Max_Stack.ToBytes());
            iHateThisSoMuch.AddRange(Max_Local.ToBytes());
            iHateThisSoMuch.AddRange(Code_Length.ToBytes());
            iHateThisSoMuch.AddRange(Code);
            iHateThisSoMuch.AddRange(Exception_Table_Length.ToBytes());
            foreach (var item in exceptionsTable)
            {
                iHateThisSoMuch.AddRange(item.ToBytes());
            }

            iHateThisSoMuch.AddRange(Attributes_Count.ToBytes());
            foreach (var item in attributes)
            {
                iHateThisSoMuch.AddRange(item.ToBytes());
            }

            return iHateThisSoMuch;
        }
    }
}
