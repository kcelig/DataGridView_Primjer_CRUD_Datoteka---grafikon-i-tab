using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DataGridView_Primjer_CRUD_Datoteka
{
    public partial class Form1 : Form
    {
     
        public Form1()
        {
            InitializeComponent();
        }

        //pohrana i loadanje
        public void PohraniUDatoteku() {
            string vrijednosti = "";
            for (int i = 0; i < dgv.Rows.Count; i++) {
                vrijednosti = vrijednosti + (string)dgv.Rows[i].Cells[0].Value + "\n" + (string)dgv.Rows[i].Cells[1].Value + "\n";
            }
            System.IO.File.WriteAllText(Application.StartupPath + "\\zadaci.txt", vrijednosti);

        }

        public void UcitavanjeIzDatoteke() {
            if (System.IO.File.Exists(Application.StartupPath + "\\zadaci.txt")) {
                string vrijednosti = System.IO.File.ReadAllText(Application.StartupPath + "\\zadaci.txt");
                char[] znak = new char[1];
                znak[0] = '\n';
                string[] v = vrijednosti.Split(znak, StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < v.Length; i += 2) {
                    dgv.Rows.Add(v[i], v[i + 1]);
                }
            }
        }



        private void btnDodaj_Click(object sender, EventArgs e)
        {
            Form2 formaUnos = new Form2();
            if (formaUnos.ShowDialog() == DialogResult.OK) {
                dgv.Rows.Add(formaUnos.txtZadatak.Text.Trim(), formaUnos.txtOpis.Text.Trim());
                PohraniUDatoteku();
                osvjezi();
            }
        }

        private void btnUredi_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) {
                return;
            }
            Form2 formaUnos = new Form2();
            formaUnos.txtZadatak.Text = (String)dgv.SelectedRows[0].Cells[0].Value;
            formaUnos.txtOpis.Text = (String)dgv.SelectedRows[0].Cells[1].Value;

            if (formaUnos.ShowDialog() == DialogResult.OK) {
                dgv.Rows.Remove(dgv.SelectedRows[0]);
                dgv.Rows.Add(formaUnos.txtZadatak.Text.Trim(), formaUnos.txtOpis.Text.Trim());
                PohraniUDatoteku();
                osvjezi();
            }


        }

        private void btnObrisi_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count == 0) {
                return;
            }
            dgv.Rows.Remove(dgv.SelectedRows[0]);
            PohraniUDatoteku();
            osvjezi();
        }

        private void Form1_Load(object sender, EventArgs e)

        {

            UcitavanjeIzDatoteke();

            osvjezi();
            
        }

        private void btnUcitaj_Click(object sender, EventArgs e)
        {
            btnUcitaj.Text = "Osvježi";


            osvjezi();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

            Form3 frm = new Form3();
            frm.ShowDialog();

        }

        private void osvjezi() {
            chart1.Series["Series1"].Points.Clear();

            int rowcount = dgv.RowCount;
            string c1 = "";
            int c2 = 0;

            for (int i = 0; i < rowcount; i++)
            {
                c1 = Convert.ToString(dgv.Rows[i].Cells[0].Value);
                c2 = Convert.ToInt32(dgv.Rows[i].Cells[1].Value);
                chart1.Series["Series1"].Points.AddXY(c1, c2);
                //chart1.Series["Series1"].
            }
        }

        
    }
}
