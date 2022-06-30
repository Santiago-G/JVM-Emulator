using System;
using System.Collections.Generic;
using System.Text;
using static StackBasedCalculator.Enums;

namespace StackBasedCalculator
{
    public static class Extentions
    {
        public static byte U1(this ref ReadOnlySpan<byte> span)
        {
            byte ret = span[0];
            span = span.Slice(1);
            return ret;
        }

        public static ushort U2(this ref ReadOnlySpan<byte> span)
        {
            return (ushort)(U1(ref span) << 8 | U1(ref span));
        }

        public static uint U4(this ref ReadOnlySpan<byte> span)
        {
            return (uint)(U2(ref span) << 16 | U2(ref span));
        }

        public static IEnumerable<byte> ToBytes(this uint numb)
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(PullOutNthShort(numb, 1).ToBytes());
            iHateThisSoMuch.AddRange(PullOutNthShort(numb, 0).ToBytes());
            return iHateThisSoMuch;
        }

        public static IEnumerable<byte> ToBytes(this ushort numb)
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.Add(PullOutNthByte(numb, 1));
            iHateThisSoMuch.Add(PullOutNthByte(numb, 0));
            return iHateThisSoMuch;
        }

        public static IEnumerable<byte> ToBytes(this MethodAccessFlags test)
        {
            return ((uint)test).ToBytes(); 
        }

        public static IEnumerable<byte> ToBytes(this ClassAccessFlags test)
        {
            return ((uint)test).ToBytes();
        }

        public static IEnumerable<byte> ToBytes(this FieldAccessFlags test)
        {
            return ((uint)test).ToBytes();
        }

        static byte PullOutNthByte(ushort number, int byteIndex)
        {
            byte NthByte = 0;

            number >>= byteIndex * 8;

            NthByte = (byte)(number & 0b_11111111);

            return NthByte;
        }

        static ushort PullOutNthShort(uint number, int shortIndex)
        {
            ushort NthShort = 0;

            number >>= shortIndex * 16;

            NthShort = (ushort)(number & 0b_1111111111111111);

            return NthShort;
        }

        public static string BytesToString(this byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }
    }
}
