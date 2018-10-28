using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagerTool
{
    public class TestParamContainer
    {
        private byte _Port;
        private bool _Level;
        private byte _ParamType;
        private UInt64 _Param1;
        private UInt64 _Param2;

        public byte Port { get => _Port; set => _Port = value; }
        public bool Level { get => _Level; set => _Level = value; }
        public byte ParamType { get => _ParamType; set => _ParamType = value; }
        public ulong Param1 { get => _Param1; set => _Param1 = value; }
        public ulong Param2 { get => _Param2; set => _Param2 = value; }
        public void Set(byte p, bool lv, byte ptype, ulong p1, ulong p2)
        {
            Port = p;
            Level = lv;
            ParamType = ptype;
            Param1 = p1;
            Param2 = p2;
        }
    }
}
