using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UyJoyIjara
{
    public partial class NewHouse : Form
    {
        public string Vil { get; private set; }
        public string Tum { get; private set; }
        public string Mah { get; private set; }
        public string Koch { get; private set; }
        public int Uy { get; private set; }
        public int Xon { get; private set; }
        public string Tur { get; private set; }
        public int Qavat { get; private set; }
        public int Xona { get; private set; }
        public double Narx { get; private set; }
        public string Tel { get; private set; }

        public string PicPath { get; private set; }

        string dataPath = "c:\\Program Files\\UyJoyIjara\\Images";

        public NewHouse()
        {
            InitializeComponent();
        }

        public NewHouse(DataGridViewRow dgvRow)
        {
            InitializeComponent();
            cmbVil.Text = dgvRow.Cells[1].Value.ToString();
            txtTum.Text = dgvRow.Cells[2].Value.ToString();
            txtMah.Text = dgvRow.Cells[3].Value.ToString();
            txtKoch.Text = dgvRow.Cells[4].Value.ToString();
            txtUy.Text = dgvRow.Cells[5].Value.ToString();
            txtXon.Text = dgvRow.Cells[6].Value.ToString();
            cmbTur.Text = dgvRow.Cells[7].Value.ToString();
            cmbQav.Text = dgvRow.Cells[8].Value.ToString();
            cmbXona.Text = dgvRow.Cells[9].Value.ToString();
            txtNarx.Text = dgvRow.Cells[10].Value.ToString();
            txtTel.Text = dgvRow.Cells[11].Value.ToString();

            try
            {
                pictureBox1.BackgroundImage = Image.FromFile(dataPath + $"\\{dgvRow.Cells[0].Value.ToString()}.jpg");
            }
            catch
            {

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                Vil = cmbVil.SelectedItem.ToString();
                Tum = txtTum.Text;
                Mah = txtMah.Text;
                Koch = txtKoch.Text;
                Uy = Convert.ToInt32(txtUy.Text);
                Xon = Convert.ToInt32(txtXon.Text);
                Tur = cmbTur.SelectedItem.ToString();
                Qavat = Convert.ToInt32(cmbQav.SelectedItem.ToString());
                Xona = Convert.ToInt32(cmbXona.SelectedItem.ToString());
                Narx = Convert.ToDouble(txtNarx.Text);
                Convert.ToUInt64(txtTel.Text);
                Tel = txtTel.Text;
                pictureBox1.BackgroundImage.Dispose();
            }
            catch
            {
                MessageBox.Show("Ma'lumotlar noto'g'ri kiritildi!", "Xato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.DialogResult = DialogResult.None;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Rasmlar|*.jpg";
            openFileDialog1.ShowDialog();
            if (openFileDialog1.FileName != "")
            {
                pictureBox1.BackgroundImage = Image.FromFile(openFileDialog1.FileName);
                PicPath = openFileDialog1.FileName;
            }
        }
        

    }
}
