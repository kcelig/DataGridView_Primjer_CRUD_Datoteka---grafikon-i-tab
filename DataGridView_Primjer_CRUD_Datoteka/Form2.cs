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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtZadatak.Text.Trim().Equals("")) {
                MessageBox.Show("Niste unijeli zadatak!", "Pažnja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtOpis.Text.Trim().Equals(""))
            {
                MessageBox.Show("Niste unijeli opis!", "Pažnja", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void btnOdustani_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
