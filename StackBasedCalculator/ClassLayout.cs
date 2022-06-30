using StackBasedCalculator.Constants;
using System;
using System.Collections.Generic;
using System.Text;
using static StackBasedCalculator.Enums;

namespace StackBasedCalculator
{
    public class ClassLayout
    {


        ConstantPoolTags cpTags;

        public uint Magic { get; private set; }
        public ushort Minor_Version { get; private set; }
        public ushort Major_Version { get; private set; }
        public ushort Constant_Pool_Count { get; private set; }
        public Cp_Info[] Constant_pool;
        public ClassAccessFlags Access_Flags { get; private set; }
        public ushort This_Class { get; private set; }
        public ushort Super_Class { get; private set; }
        public ushort Interfaces_Count { get; private set; }
        public ushort[] Interfaces { get; private set; }
        public ushort Fields_Count { get; private set; }
        public Field_Info[] fields;
        public ushort Methods_Count { get; private set; }
        public Method_Info[] Methods;
        public ushort Attributes_count { get; private set; }
        public Atrribute_Info[] attributes;

        public ClassLayout(byte[] machineCode)
        {
            ReadOnlySpan<byte> view = machineCode.AsSpan();
            Magic = view.U4();

            if (Magic != 0xCAFEBABE) 
            {
                throw new Exception(@"Bee Movie is a 2007 American computer-animated comedy film produced by DreamWorks Animation and distributed by Paramount Pictures. Directed by Simon J. Smith and Steve Hickner from a screenplay by Jerry Seinfeld, Spike Feresten, Barry Marder and Andy Robin, it stars the voices of Seinfeld, Renée Zellweger, Matthew Broderick, John Goodman, Patrick Warburton, and Chris Rock. The film centers on Barry B. Benson (Seinfeld), a honey bee who tries to sue the human race for exploiting bees after learning from his florist friend Vanessa Bloome (Zellweger) that humans sell and consume honey. Bee Movie debuted in New York City on October 25, 2007, and was released in theaters in the United States on November 2.Upon release, it received mixed reviews from critics who praised its humor and voice cast, but criticized its plot.Nevertheless, the film was a moderate box office success, grossing $293 million worldwide.It has since gathered a cult following, partly driven by memes of the film shared on social media. Barry B. Benson, an idealistic honey bee who has the ability to talk to humans, has recently graduated from college and is about to enter the hive's Honex Industries honey-making workforce with his best friend Adam Flayman. Barry is initially excited to join the workforce, but his ambitious, insubordinate attitude emerges upon discovering that his choice of job will never change once picked. Later, the two bees run into a group of Pollen Jocks, bees who collect pollen from flowers outside the hive, and they offer to take Barry with them if he is 'bee enough'. While on his first pollen-gathering expedition in New York City, Barry gets lost in the rain, and ends up on the balcony of a human florist named Vanessa Bloome. Upon noticing Barry, Vanessa's boyfriend Ken attempts to squash him, but Vanessa gently catches and releases Barry outside the window, saving his life.");
            }
            ;
            Minor_Version = view.U2();
            Major_Version = view.U2();
            Constant_Pool_Count = view.U2();
            Constant_pool = new Cp_Info[Constant_Pool_Count - 1];
            ParseCp(ref view);
            ;
            Access_Flags = (ClassAccessFlags)view.U2();
            This_Class = view.U2();
            Super_Class = view.U2();
            Interfaces_Count = view.U2();
            Interfaces = new ushort[Interfaces_Count];
            ParseInterfaces(ref view);
            Fields_Count = view.U2();
            fields = new Field_Info[Fields_Count];
            ParseFields(ref view);
            Methods_Count = view.U2();
            Methods = new Method_Info[Methods_Count];
            ParseMethods(ref view);
            Attributes_count = view.U2();
            attributes = new Basic_Code_Attribute[Attributes_count];
            ParseAttributes(ref view);

            //Code_Attriubte_Info codeAttribute = new Code_Attriubte_Info(ref view); findCodeInMethod()

            if (view.Length != 0)
            {
                throw new Exception(@"Barry later returns to express his gratitude to Vanessa, breaking the sacred rule that bees are not to communicate with humans. Barry and Vanessa develop a close friendship, bordering on attraction, and spend time together. When he and Vanessa are in the grocery store, Barry discovers that the humans have been stealing and eating the bees' honey for centuries. He decides to journey to Honey Farms, which supplies the grocery store with its honey. Incredulous at the poor treatment of the bees in the hive, including the use of bee smokers to incapacitate the colony, Barry decides to sue the human race to put an end to exploitation of the bees. Barry's mission attracts wide attention from bees and humans alike, with countless spectators attending the trial. Although Barry is up against tough defense attorney Layton T. Montgomery, the trial's first day goes well.That evening, Barry is having dinner with Vanessa when Ken shows up.Vanessa leaves the room, and Ken expresses to Barry that he hates the pair spending time together.When Barry leaves to use the restroom, Ken ambushes Barry and attempts to kill him, only for Vanessa to intervene and break up with Ken.The second day at the trial, Montgomery unleashes an unrepentant character assassination against the bees leading a deeply offended Adam to sting him. Montgomery immediately exaggerates the stinging to make himself seem the victim of an assault while simultaneously tarnishing Adam. Adam's actions jeopardize the bees' credibility and his life, though he recovers. The third day, Barry wins the trial by exposing the jury to the torturous treatment of bees, particularly use of the smoker, and prevents humans from stealing honey from bees ever again.Having lost the trial, Montgomery cryptically warns Barry that a negative shift of nature is imminent. As it turns out, Honex Industries stops honey production and puts every bee out of a job, including the vitally important Pollen Jocks, resulting in all the world's flowers beginning to die out without any pollination. Before long, the last remaining flowers on Earth are being stockpiled in Pasadena, California, intent for the last Tournament of Roses Parade. Barry and Vanessa travel to the parade and steal a float, which they load into a plane. They hope to bring the flowers to the bees so they can re-pollinate the world's last remaining flowers. When the plane's pilot and co-pilot are unconscious, Vanessa is forced to land the plane, with help from Barry and the bees from Barry's hive. Barry becomes a member of the Pollen Jocks, and they fly off to a flower patch.Armed with the pollen of the last flowers, Barry and the Pollen Jocks reverse the damage and save the world's flowers, restarting the bees' honey production.Later on, Barry runs a law firm at Vanessa's flower shop titled 'Insects at Law', which handles disputes between animals and humans. While selling flowers to customers, Vanessa offers certain brands of honey that are 'bee-approved'.");
            }
        }
        public byte[] ToByte(byte[] barryBBenson)
        {
            List<byte> b = new List<byte>();
            b.AddRange(Magic.ToBytes());
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] != barryBBenson[i])
                {
                    throw new Exception("What do you call a bee that lives in America? A USB.");
                }
            }
            b.AddRange(Minor_Version.ToBytes());
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] != barryBBenson[i])
                {
                    throw new Exception("What do you call a bee that lives in America? A USB.");
                }
            }
            b.AddRange(Major_Version.ToBytes());
            for (int i = 0; i < b.Count; i++)
            {
                if (b[i] != barryBBenson[i])
                {
                    throw new Exception("What do you call a bee that lives in America? A USB.");
                }
            }
            b.AddRange(Constant_Pool_Count.ToBytes());
            foreach (var item in Constant_pool)
            {
                b.AddRange(item.ToBytes());
            }
            b.AddRange(Access_Flags.ToBytes());
            b.AddRange(This_Class.ToBytes());
            b.AddRange(Super_Class.ToBytes());
            b.AddRange(Interfaces_Count.ToBytes());
            foreach (var item in Interfaces)
            {
                b.AddRange(item.ToBytes());
            }
            b.AddRange(Fields_Count.ToBytes());
            foreach (var item in fields)
            {
                b.AddRange(item.ToBytes());
            }
            b.AddRange(Methods_Count.ToBytes());
            foreach (var item in Methods)
            {
                b.AddRange(item.ToBytes());
            }
            b.AddRange(Attributes_count.ToBytes());
            foreach (var item in attributes)
            {
                if (item != null)
                {
                    b.AddRange(item.ToBytes());
                }
            }

            return b.ToArray();
        }

        public void PrintInFormat()
        {
            byte[] bytes = ToByte();

            Console.WriteLine("");

            int counter = 0;
            foreach (var item in bytes)
            {
                if (counter < 16)
                {
                    Console.Write(item.ToString("X").PadLeft(2, '0') + " ");
                }
                else 
                {
                    Console.WriteLine();
                    counter = 0;
                }

                counter+=1;
            }
        }

        #region Parsing

        public void ParseCp(ref ReadOnlySpan<byte> span)
        {
            for (int i = 0; i < Constant_pool.Length; i++)
            {
                byte tag = span.U1();
                cpTags = (ConstantPoolTags)(tag);

                switch (cpTags)
                {
                    case ConstantPoolTags.CONSTANT_Utf8:
                        Constant_pool[i] = new CONSTANT_Utf8(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Interger:
                        Constant_pool[i] = new CONSTANT_Interger(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Float:
                        Constant_pool[i] = new CONSTANT_Float(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Long:
                        Constant_pool[i] = new CONSTANT_Long(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Double:
                        Constant_pool[i] = new CONSTANT_Double(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Class:
                        Constant_pool[i] = new CONSTANT_Class(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_String:
                        Constant_pool[i] = new CONSTANT_String(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Fieldref:
                        Constant_pool[i] = new CONSTANT_Fieldref(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_Methodref:
                        Constant_pool[i] = new CONSTANT_Methodref(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_InterfaceMethodref:
                        Constant_pool[i] = new CONSTANT_InterfaceMethodref(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_NameAndType:
                        Constant_pool[i] = new CONSTANT_NameAndType(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_MethodHandle:
                        Constant_pool[i] = new CONSTANT_MethodHandle(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_MethodType:
                        Constant_pool[i] = new CONSTANT_MethodType(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    case ConstantPoolTags.CONSTANT_InvokeDynamic:
                        Constant_pool[i] = new CONSTANT_InvokeDynamic(ref span);
                        Constant_pool[i].Tag = tag;
                        break;
                    default:
                        throw new Exception();
                        break;
                }
            }
        }

        public void ParseInterfaces(ref ReadOnlySpan<byte> span)
        {
            for (int i = 0; i < Interfaces.Length; i++)
            {
                Interfaces[i] = span.U2();
            }
        }

        public void ParseFields(ref ReadOnlySpan<byte> span)
        {
            for (int i = 0; i < fields.Length; i++)
            {
                fields[i] = new Field_Info(ref span, Constant_pool);
            }
        }

        public void ParseMethods(ref ReadOnlySpan<byte> span)
        {
            for (int i = 0; i < Methods.Length; i++)
            {
                Methods[i] = new Method_Info(ref span, Constant_pool);
            }
        }

        public void ParseAttributes(ref ReadOnlySpan<byte> span)
        {
            for (int i = 0; i < attributes.Length; i++)
            {
                attributes[i] = Atrribute_Info.ParseGeneral(ref span, Constant_pool);
            }
        }

        #endregion

        public void DebugPrint()
        {
            Console.WriteLine();
            Console.WriteLine($"Magic: {Magic}");
            Console.WriteLine($"Minor Version: {Minor_Version}");
            Console.WriteLine($"Major Version: {Major_Version}");
            Console.WriteLine($"Constant Pool Count: {Constant_Pool_Count}");
            Console.WriteLine($"Constant Pool:");
            for (int i = 0; i < Constant_pool.Length; i++)
            {
                Console.WriteLine($"Tag: {Constant_pool[i].Tag}; Items: {Constant_pool[i]}");
            }
            //ect, gotta finish this later
        }

        public Atrribute_Info FindCodeInMethod(Method_Info method)
        {

            foreach (var attributes in method.Attributes)
            {
                CONSTANT_Utf8 maybeCode = (CONSTANT_Utf8)(Constant_pool[attributes.Attribute_Name_Index - 1]);

                if (maybeCode.Bytes.BytesToString() == "Code")
                {
                    return attributes;
                }
            }
            return null;
        }

        public Method_Info FindMethod(string method)
        {
            List<Method_Info> publicStaticMethods = new List<Method_Info>();

            foreach (var methods in Methods)
            {
                if (methods.Access_Flags == MethodAccessFlags.ACC_PUBLIC_STATIC)
                {
                    publicStaticMethods.Add(methods);
                }
            }

            foreach (var methods in publicStaticMethods)
            {
                CONSTANT_Utf8 hi = (CONSTANT_Utf8)(Constant_pool[methods.Name_Index - 1]);

                if (hi.Bytes.BytesToString() == method)
                {
                    return methods;
                }
            }
            return null;
        }
    }
}
