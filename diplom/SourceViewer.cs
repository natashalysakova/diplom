using Algorythms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class SourceViewer : Form
    {
        Uri uri;

        public SourceViewer(IAlgorythm instance)
        {
            InitializeComponent();

            uri = new Uri(Directory.GetCurrentDirectory() +  instance.GetSourceCode());
            this.Text = "Програмний код - " + instance.Name;
        }

        private void SourceViewer_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = uri;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                webBrowser1.Document.ExecCommand("SelectAll", false, null);
                webBrowser1.Document.ExecCommand("Copy", false, null);
                string code = Clipboard.GetText();

                using (StreamWriter s = new StreamWriter(new FileStream(saveFileDialog1.FileName, FileMode.OpenOrCreate, FileAccess.Write)))
                {
                    s.WriteLine(code);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Document.ExecCommand("SelectAll", false, null);
            webBrowser1.Document.ExecCommand("Copy", false, null);
        }
    }
}
