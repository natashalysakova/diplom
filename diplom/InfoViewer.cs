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
    public partial class InfoViewer : Form
    {
        Uri uri;

        public InfoViewer(IAlgorythm instance)
        {
            InitializeComponent();

            uri = new Uri(Directory.GetCurrentDirectory() + instance.GetDescription());
            this.Text = "Теоретичні відомості - " + instance.Name;

        }

        private void InfoViewer_Load(object sender, EventArgs e)
        {
            webBrowser1.Url = uri;
        }
    }
}
