using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic.FileIO;
using System.Xml;

namespace TestManagerTool
{
    public partial class TestConfirmationCtrl : UserControl
    {
        private enum LimitType
        {
            Time,
            Counter
        }
        private enum ParamType
        {
            Fix,
            Random,
            Increment,
            Decrement
        }

        public TestConfirmationCtrl()
        {
            InitializeComponent();
        }
        private void TestDataTableDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow testDataRow = testDataTableDataGridView.CurrentRow;
            UInt64 testNum = (UInt64)testDataRow.Cells["TestNumColumn"].Value;
            DataRow[] dataRows = testCaseDataSet.Tables["ParameterDataTable"].Select("TestNum = " + testNum.ToString());
            ParameterPreview.Clear();
            foreach (DataRow d in dataRows)
            {
                ParamType type = (ParamType)((Byte)d["ParameterType"]);
                ParameterPreview.AppendText("Port(" + d["Port"].ToString() + "):" + ((Boolean)d["Level"]==true? "High":"Low") + Environment.NewLine);
                ParameterPreview.AppendText("  Type(" + GetTypeString(type) + "): ");
                if (type == ParamType.Fix)
                {
                    ParameterPreview.AppendText(d["Param1"].ToString() + Environment.NewLine);
                }
                else
                {
                    ParameterPreview.AppendText("[" + d["Param1"].ToString() + ":"+ d["Param2"].ToString() + "]"+ Environment.NewLine);
                }
            }
        }
        public void LoadTestcase(string testfilename)
        {
            testCaseDataSet.Clear();
            PerformTestCaseExcelExporter(testfilename);
            LoadTestCaseXml(Directory.GetParent(testfilename).ToString());
        }
        public void Clear()
        {
            testCaseDataSet.Clear();
            ParameterPreview.Clear();
        }
        private void PerformTestCaseExcelExporter(string path)
        {
            // Excel.Application の新しいインスタンスを生成する
            var xlApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbooks xlBooks;

            // xlApplication から WorkBooks を取得する
            // 既存の Excel ブックを開く
            xlBooks = xlApp.Workbooks;
            xlBooks.Open(path, ReadOnly: true);

            // Excel を表示する
            xlApp.Visible = true;

            // マクロを実行する
            // 標準モジュール内のexportメソッドに thisPath を引数で渡し実行
            var filename = Path.GetFileName(path);
            var thisPath = Path.GetDirectoryName(path);
            xlApp.Run(filename + "!export", thisPath);

            // Excel を終了する
            xlApp.DisplayAlerts = false;
            xlApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlBooks);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(xlApp);
        }
        private void LoadTestCaseXml(string path)
        {
            string[] files = System.IO.Directory.GetFiles(path, "*.xml", System.IO.SearchOption.AllDirectories);

            foreach (string filepath in files) {
                XmlDocument xmlDocument = new XmlDocument();
                xmlDocument.Load(filepath);
                XmlNodeList nodeList = xmlDocument.SelectNodes("/root/TestCase");
                foreach (XmlNode n in nodeList)
                {
                    ImportTestDB(n);
                }
            }
        }
        private void ImportTestDB(XmlNode node)
        {
            UInt64 testNum = UInt64.Parse(node.SelectSingleNode("TestNum").InnerText);
            DataRow testDataRow = testCaseDataSet.Tables["TestDataTable"].NewRow();
            testDataRow["TestNum"] = testNum;
            testDataRow["Name"] = node.SelectSingleNode("TestName").InnerText;
            testDataRow["LimitType"] = Byte.Parse(node.SelectSingleNode("LimitType").InnerText);
            testDataRow["LimitValue"] = UInt64.Parse(node.SelectSingleNode("LimitValue").InnerText);
            testDataRow["Enable"] = Boolean.Parse(node.SelectSingleNode("Enable").InnerText);
            testCaseDataSet.Tables["TestDataTable"].Rows.Add(testDataRow);

            foreach(XmlNode n in node.SelectNodes("Param"))
            {
                DataRow paramDataRow = testCaseDataSet.Tables["ParameterDataTable"].NewRow();
                paramDataRow["TestNum"] = testNum;
                paramDataRow["Port"] = Byte.Parse(n.SelectSingleNode("Port").InnerText);
                paramDataRow["Level"] = Boolean.Parse(n.SelectSingleNode("Level").InnerText);
                paramDataRow["ParameterType"] = Byte.Parse(n.SelectSingleNode("ParamType").InnerText);
                paramDataRow["Param1"] = UInt64.Parse(n.SelectSingleNode("Param1").InnerText);
                paramDataRow["Param2"] = UInt64.Parse(n.SelectSingleNode("Param2").InnerText);
                testCaseDataSet.Tables["ParameterDataTable"].Rows.Add(paramDataRow);
            }
        }
        private String GetTypeString(LimitType type)
        {
            switch(type)
            {
                case LimitType.Counter:
                    return "Counter";
                case LimitType.Time:
                    return "Time";
                default:
                    return "Unknown";
            }
        }
        private String GetTypeString(ParamType type)
        {
            switch (type)
            {
                case ParamType.Fix:
                    return "Fix";
                case ParamType.Random:
                    return "Random";
                case ParamType.Increment:
                    return "Increment";
                case ParamType.Decrement:
                    return "Decrement";
                default:
                    return "Unknown";
            }
        }
    }
}
