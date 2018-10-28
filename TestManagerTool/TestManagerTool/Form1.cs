using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;
using System.Diagnostics;
using System.IO.Ports;

namespace TestManagerTool
{
    public partial class Form1 : Form
    {
        string arduinoFolder = "testPulseGenerator\\";
        public Form1()
        {
            InitializeComponent();

            WriteArduinoProject();

            backgroundWorker1.WorkerSupportsCancellation = true;
            backgroundWorker1.WorkerReportsProgress = true;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                portComboBox.Items.Add(port);
            }
            if (portComboBox.Items.Count > 0)
            {
                portComboBox.SelectedIndex = 0;
            }
        }
        private void LoadBtn_Click(object sender, EventArgs e)
        {
            string arg = "--upload " + System.IO.Directory.GetCurrentDirectory() + "\\" + arduinoFolder + "testPluseGenerator.ino";
            Process p = Process.Start("arduino", arg);
        }
        private void ComOpenClose_Click(object sender, EventArgs e)
        {
            if (ComOpenClose.Text == "Open")
            {
                serialPort1.BaudRate = 115200;
                serialPort1.Parity = Parity.None;
                serialPort1.DataBits = 8;
                serialPort1.StopBits = StopBits.One;
                serialPort1.Handshake = Handshake.None;
                serialPort1.PortName = portComboBox.Text;
                serialPort1.Open();
                ComOpenClose.Text = "Close";
                backgroundWorker1.RunWorkerAsync();
            }
            else
            {
                serialPort1.Close();
                backgroundWorker1.CancelAsync();
                ComOpenClose.Text = "Open";
            }
        }
        private delegate void updateTextDelegate(char c);
        private void UpdateText(char c)
        {
            textBox1.AppendText(c.ToString());
        }
        private void BackgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            while (true)
            {
                try
                {
                    if (serialPort1.IsOpen)
                    {
                        char c = (char)serialPort1.ReadChar();
                        Invoke(new updateTextDelegate(UpdateText), c);
                    }

                    if (backgroundWorker1.CancellationPending)
                    {
                        e.Cancel = true;
                        return;
                    }
                }
                catch
                {

                }
            }
        }
        private void StartBtn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("S");
        }
        private void StopBtn_Click(object sender, EventArgs e)
        {
            serialPort1.Write("C");
        }
        private void ClearLogBtn_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
        }


        private void TestImportBtn_Click(object sender, EventArgs e)
        {
            testConfirmationCtrl1.Clear();
            openFileDialog1.Filter = "Excel(*.xlsm)|*.xlsm";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                TestPathTxt.Text = openFileDialog1.FileName;
                testConfirmationCtrl1.LoadTestcase(TestPathTxt.Text);
            }
        }

        private void RunTestsBtn_Click(object sender, EventArgs e)
        {
            int testCount = testConfirmationCtrl1.GetTestCount();
            TestCaseContainer test = testConfirmationCtrl1.GetTest(0);
        }

        private void WriteArduinoProject()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            /* 出力フォルダの作成 */
            if (Directory.Exists(arduinoFolder))
            {
                Directory.Delete(arduinoFolder, true);
            }
            Directory.CreateDirectory(arduinoFolder);

            foreach (string infile in asm.GetManifestResourceNames())
            {
                if (string.Compare(Path.GetExtension(infile), ".resources") == 0)
                {
                    continue;
                }
                string filename = infile.Replace("TestManagerTool.Template.", "");

                // 書き出し
                Stream resStream = asm.GetManifestResourceStream(infile);
                StreamReader sr = new StreamReader(resStream);
                string text = sr.ReadToEnd();
                File.WriteAllText(arduinoFolder + filename, text);
            }
        }
    }
}
