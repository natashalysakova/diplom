using Algorythms;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace diplom
{
    public partial class AlgorythmForm : Form
    {
        private List<List<TextBox>> _boxes;
        IAlgorythm instance;


        public AlgorythmForm(IAlgorythm algorythmInstance)
        {
            InitializeComponent();

            instance = algorythmInstance;
            this.Text = instance.Name;

            _boxes = new List<List<TextBox>>();
            int j = 0;
            for (int i = 0; i < 6; i++)
            {
                _boxes.Add(new List<TextBox>());
                for (int k = 0; k < 6; k++)
                {
                    j++;
                    Control t = tableLayoutPanel1.Controls.Find("textBox" + j.ToString(), false)[0];
                    _boxes[i].Add((TextBox)t);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Random random = new Random();

            for (int i = 0; i < tableLayoutPanel1.Controls.Count; i++)
            {
                Control control = tableLayoutPanel1.Controls[i];
                if (control is TextBox)
                {
                    if (i % 7 != 0)
                    {
                        int r = random.Next(1, 10);
                        (control as TextBox).Text = r.ToString();
                    }
                    else
                    {
                        (control as TextBox).Text = (-1).ToString();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            List<List<int>> arr = LoadFromTextBoxes();

            IAlgorythm newAlgorythm = Agent.Analyse(arr);
            if (newAlgorythm.GetType() != instance.GetType())
            {
                DialogResult result = MessageBox.Show("Інтелектуальний агент вважає, що для введених даних \nкраще використовувати " + newAlgorythm.Name + "\nЗмінити обраний алгоритм на запропонований?" , "Змінити алгоритм?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                switch (result)
                {
                    case DialogResult.Cancel: return;

                    case DialogResult.Yes: instance = newAlgorythm;
                        break;
                }
            }

            instance.Data = arr;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string s = instance.Calculate();
            stopwatch.Stop();

            MessageBox.Show(
                
                "Результат: " + s, instance.Name + " працював " + stopwatch.ElapsedMilliseconds + " мілісекунд",
                MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1
                );


        }

        private List<List<int>> LoadFromTextBoxes()
        {
            List<List<int>> list = new List<List<int>>();
            for (int i = 0; i < _boxes.Count; i++)
            {
                list.Add(new List<int>());
                for (int j = 0; j < _boxes[i].Count; j++)
                {
                    list[i].Add(Convert.ToInt32(_boxes[i][j].Text));
                }
            }
            return list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new InfoViewer(instance).Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new SourceViewer(instance).Show();
        }

        private void AlgorythmForm_Load(object sender, EventArgs e)
        {

        }
    }
}
