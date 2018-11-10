using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestManagerTool
{
    public class TestCaseContainer
    {
        private UInt64 testnum;
        private string testname;
        private Byte limitType;
        private UInt64 limitValue;
        private Boolean enabled;
        public List<TestParamContainer> param;
        public ulong Testnum { get => testnum; set => testnum = value; }
        public byte LimitType { get => limitType; set => limitType = value; }
        public ulong LimitValue { get => limitValue; set => limitValue = value; }
        public bool Enabled { get => enabled; set => enabled = value; }
        public string Testname { get => testname; set => testname = value; }
        public TestCaseContainer()
        {
            param = new List<TestParamContainer>();
        }
        public void Clear()
        {
            param.Clear();
        }

        public void Set(UInt64 n, string name, byte ltype, UInt64 lvalue, bool e)
        {
            Testnum = n;
            Testname = name;
            LimitType = ltype;
            LimitValue = lvalue;
            Enabled = e;
        }
        public void AddParam(TestParamContainer p)
        {
            param.Add(p);
        }
    }
}
