using Horoscope.form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horoscope
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new DateHoro();
            form.ShowDialog(this);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var form = new YearPrediction();
            form.ShowDialog(this);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "resource/help/help.chm");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
