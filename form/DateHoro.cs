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
    public partial class DateHoro : Form
    {
        public DateHoro()
        {
            InitializeComponent();
        }
        public void updateAll()
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = HoroDBService.monthCharacter(dateTimePicker1.Value).Tables[0].DefaultView;
            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                column.Width = 400;
            }
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = HoroDBService.yearCharacter(dateTimePicker1.Value.Year).Tables[0].DefaultView;
            foreach (DataGridViewColumn column in dataGridView2.Columns)
            {
                column.Width = 400;
            }
            dataGridView3.DataSource = null;
            dataGridView3.DataSource = HoroDBService.dayPrediction(dateTimePicker1.Value).Tables[0].DefaultView;
            foreach (DataGridViewColumn column in dataGridView3.Columns)
            {
                column.Width = 400;
            }
        }
        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            updateAll();
        }
    }
}
