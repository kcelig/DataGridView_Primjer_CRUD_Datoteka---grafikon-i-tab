using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DataGridView_Primjer_CRUD_Datoteka
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            int rowcount = frm.dgv.RowCount - 1;
            string c1 = "";
            int c2 = 0;

            for (int i = 0; i < rowcount; i++)
            {
                c1 = Convert.ToString(frm.dgv.Rows[i].Cells[0].Value);
                c2 = Convert.ToInt32(frm.dgv.Rows[i].Cells[1].Value);
                chart1.Series["Series1"].Points.AddXY(c1, c2);
            }
          
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            int rowcount = frm.dgv.RowCount - 1;
            string c1 = "";
            int c2 = 0;

            for (int i = 0; i < rowcount; i++)
            {
                c1 = Convert.ToString(frm.dgv.Rows[i].Cells[0].Value);
                c2 = Convert.ToInt32(frm.dgv.Rows[i].Cells[1].Value);
                chart1.Series["Series1"].Points.AddXY(c1, c2);
            }
        }
    }
}
