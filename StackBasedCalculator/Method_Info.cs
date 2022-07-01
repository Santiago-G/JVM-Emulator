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

        public uint[] Locals;
        public void Execute(Cp_Info[] Constant_pool, ClassLayout classFile, bool ClearLocals=true)
        {
            Code_Attriubte_Info codeInfo = FindCode(Constant_pool);
            if (ClearLocals)
            {
                Locals = new uint[codeInfo.Max_Local];
            }
            ReadOnlySpan<byte> view = codeInfo.Code.AsSpan();
            ;
            while (view.Length != 0)
            {
                RunInstruction(ref view, Constant_pool, classFile);
            }
        }

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

        public void RunInstruction(ref ReadOnlySpan<byte> view, Cp_Info[] Constant_pool, ClassLayout classfile)
         {
            byte instruction = view.U1();
            InstrucByteCode byteCode = (InstrucByteCode)instruction;
            switch (byteCode)
            {
                case InstrucByteCode.invokestatic:


                    ushort index = view.U2();

                    //CONSTANT_Utf8 method = (CONSTANT_Utf8)Constant_pool[((CONSTANT_NameAndType)Constant_pool[((CONSTANT_Methodref)Constant_pool[index]).Name_And_Type_Index - 1]).Descriptor_Index];
                    CONSTANT_NameAndType nameAndType = ((CONSTANT_NameAndType)Constant_pool[((CONSTANT_Methodref)Constant_pool[index - 1]).Name_And_Type_Index - 1]);
                    ushort name = nameAndType.Name_Index;
                    ushort descriptorIndex = nameAndType.Descriptor_Index;
                    Method_Info test =  classfile.FindMethod(((CONSTANT_Utf8)Constant_pool[name - 1]).Bytes.BytesToString());

                    test.Locals = new uint[Program.stack.Count];

                    for (int i = 0; i < test.Locals.Length; i++)
                    {
                        test.Locals[i] = Program.stack.Pop();
                    }
                    
                    test.Execute(Constant_pool, classfile, false);
                    ;
                    
                    // Program.stack.Push(con);
                    break;
                case InstrucByteCode.iconst_0:
                    Program.stack.Push(0);
                    break;
                case InstrucByteCode.iconst_1:
                    Program.stack.Push(1);
                    break;
                case InstrucByteCode.iconst_2:
                    Program.stack.Push(2);
                    break;
                case InstrucByteCode.iconst_3:
                    Program.stack.Push(3);
                    break;
                case InstrucByteCode.iconst_4:
                    Program.stack.Push(4);
                    break;
                case InstrucByteCode.iconst_5:
                    Program.stack.Push(5);
                    break;
                case InstrucByteCode.istore_1:
                    Locals[1] = Program.stack.Pop();
                    break;
                case InstrucByteCode.istore_2:
                    Locals[2] = Program.stack.Pop();
                    break;
                case InstrucByteCode.istore_3:
                    Locals[3] = Program.stack.Pop();
                    break;
                case InstrucByteCode.bipush:
                    byte val = view.U1();
                    Program.stack.Push(val);
                    break;
                case InstrucByteCode.iload_0:
                    Program.stack.Push(Locals[0]);
                    break;
                case InstrucByteCode.iload_1:
                    Program.stack.Push(Locals[1]);
                    break;
                case InstrucByteCode.iload_2:
                    Program.stack.Push(Locals[2]);
                    break;
                case InstrucByteCode.iadd:
                    Program.stack.Push(Program.stack.Pop() + Program.stack.Pop());
                    break;
                case InstrucByteCode.eclipse:
                    //and the sun is eclipsed by the moon
                    ;
                    return;
                    break;
            }
        }
        public Code_Attriubte_Info FindCode(Cp_Info[] Constant_pool)
        {
            foreach (var attributes in Attributes)
            {
                CONSTANT_Utf8 maybeCode = (CONSTANT_Utf8)(Constant_pool[attributes.Attribute_Name_Index - 1]);

                if (maybeCode.Bytes.BytesToString() == "Code")
                {
                    return (Code_Attriubte_Info)attributes;
                }
            }
            return null;
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
