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
    public partial class ShowHouse : Form
    {
        public ShowHouse(DataGridViewRow dgvRow)
        {
            InitializeComponent();
            try
            {
                pictureBox1.BackgroundImage = Image.FromFile($"C:\\Program Files\\UyJoyIjara\\Images\\{dgvRow.Cells[0].Value.ToString()}.jpg");
            }
            catch
            {

            }
            label1.Text = $"Manzil: {dgvRow.Cells[1].Value.ToString()}, {dgvRow.Cells[2].Value.ToString()} tumani, " +
                $"{dgvRow.Cells[3].Value.ToString()} mahallasi, {dgvRow.Cells[4].Value.ToString()} ko'chasi," +
                $"{dgvRow.Cells[5].Value.ToString()}-uy, {dgvRow.Cells[6].Value.ToString()}-xonadon\n" +
                $"Turi: {dgvRow.Cells[7].Value.ToString()}\n" +
                $"Qavatlari soni: {dgvRow.Cells[8].Value.ToString()}\n" +
                $"Xonalari soni: {dgvRow.Cells[9].Value.ToString()}\n" +
                $"Narxi: {dgvRow.Cells[10].Value.ToString()} so'm\n" +
                $"Telefon: {dgvRow.Cells[11].Value.ToString()}";
        }

    }
}
