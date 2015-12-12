using Algorythms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace diplom
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DynamicalProgramming d = new DynamicalProgramming();
            CreateAlgorythmForm(d);
        }

        private void CreateAlgorythmForm(IAlgorythm d)
        {
            new AlgorythmForm(d).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            BranchAndBound b = new BranchAndBound();
            CreateAlgorythmForm(b);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CombineMethod c = new CombineMethod();
            CreateAlgorythmForm(c);
        }
    }
}
