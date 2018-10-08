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

namespace TestManagerTool
{
    public partial class Form1 : Form
    {
        string arduinoFolder = "testPulseGenerator\\";
        public Form1()
        {
            InitializeComponent();
            Assembly asm = Assembly.GetExecutingAssembly();

            /* 出力フォルダの作成 */
            if (Directory.Exists(arduinoFolder))
            {
                Directory.Delete(arduinoFolder, true);
            }
            Directory.CreateDirectory(arduinoFolder);

            foreach (string infile in asm.GetManifestResourceNames())
            {
                if (string.Compare(Path.GetExtension(infile), ".resources")==0)
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

        private void button1_Click(object sender, EventArgs e)
        {
            string arg = "--upload " + System.IO.Directory.GetCurrentDirectory() +"\\"+ arduinoFolder + "testPluseGenerator.ino";
            Process p = Process.Start("arduino", arg);
        }
    }
}
