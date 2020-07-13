using Horoscope.service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Horoscope.form
{
    public partial class YearPrediction : Form
    {
        public YearPrediction()
        {
            InitializeComponent();
            dataGridView1.DataSource = HoroDBService.yearHoro(DateTime.Now.Year).Tables[0].DefaultView;
            dataGridView1.Columns[0].Width = 800;
        }
    }
}
