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

namespace measure
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveFileDialog1.ShowDialog();
        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = saveFileDialog1.FileName;
            dataSet1.WriteXml(Path);
        }
        private int id = 0;
        private void button2_Click(object sender, EventArgs e)
        {
            dataSet1.Tables[0].Rows.Add(id++,0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = dataSet1.Tables[0];
            dataGridView1.DataSource = bindingSource1;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog(this);   
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            string Path = openFileDialog1.FileName;
            dataSet1.ReadXml(Path);
        }
    }
}
