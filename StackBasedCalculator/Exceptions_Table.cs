using System;
using System.Collections.Generic;
using System.Text;

namespace StackBasedCalculator
{
    public class Exceptions_Table
    {
        public ushort Start_Pc { get; private set; }
        public ushort End_Pc { get; private set; }
        public ushort Handler_Pc { get; private set; }
        public ushort Catch_Type { get; private set; }

        public Exceptions_Table(ref ReadOnlySpan<byte> view)
        {
            Start_Pc = view.U2();
            End_Pc = view.U2();
            Handler_Pc = view.U2();
            Catch_Type = view.U2();
        }

        public IEnumerable<byte> ToBytes()
        {
            List<byte> iHateThisSoMuch = new List<byte>();
            iHateThisSoMuch.AddRange(Start_Pc.ToBytes());
            iHateThisSoMuch.AddRange(End_Pc.ToBytes());
            iHateThisSoMuch.AddRange(Handler_Pc.ToBytes());
            iHateThisSoMuch.AddRange(Catch_Type.ToBytes());
            return iHateThisSoMuch;
        }
    }
}
