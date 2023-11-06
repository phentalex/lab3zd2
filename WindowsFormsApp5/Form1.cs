using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace WindowsFormsApp5
{
        public partial class Form1 : Form
        {
        public struct shooting
        {
            public string shoot;
            public string hit;
            public shooting(string _shoot, string _hit)
            {
                shoot = _shoot;
                hit = _hit;
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        List<shooting> shootings = new List<shooting>();


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            DataTable table = new DataTable();
            table.Columns.Add("Выстрел", typeof(string));
            table.Columns.Add("Попадание", typeof(string));
            string[] x = richTextBox1.Text.Split(';');
            string[] y = richTextBox2.Text.Split(';');
            double r = 3;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (Double.Parse(x[i]) >= 0 && Math.Pow(Double.Parse(x[i]), 2) + Math.Pow(Double.Parse(y[i]), 2) <= Math.Pow(r, 2) ||
                        Double.Parse(x[i]) <= 0 && r >= Double.Parse(y[i]) && Double.Parse(y[i]) >= Double.Parse(x[i]) && -r <= Double.Parse(y[i]) && Double.Parse(y[i]) <= Double.Parse(x[i]))
                    {
                        shootings.Add(new shooting(Convert.ToString(i + 1), "Попал"));
                        //dataGridView1.Rows[i].Cells[j].Style.BackColor = Color.FromArgb(38, 173, 74);
                    }
                    else
                    {
                        shootings.Add(new shooting(Convert.ToString(i + 1), "Не попал"));
                    }
                }
                table.Rows.Add(shootings[i].shoot, shootings[i].hit);
            }
            dataGridView1.DataSource = table;
        }
    }
}