using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace UyJoyIjara
{
    public partial class Form1 : Form
    {
        DataTable datatable = new DataTable();
        string dataPath = "c:\\Program Files\\UyJoyIjara\\Images";
        public Form1()
        {
            try
            {
                DB.db = new Data();
                DB.db.Data_init(@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Baza.accdb;Persist Security Info=False;");
                DB.db.Connect();
            }
            catch (System.Data.OleDb.OleDbException exp)
            {
                MessageBox.Show(exp.ToString());
            }

            if (!Directory.Exists(dataPath))
            {
                Directory.CreateDirectory(dataPath);
            }
            InitializeComponent();

            datatable = DB.db.Query("select * from Uylar");
            dgvMain.DataSource = datatable;
            dgvMain.Columns[0].Visible = false;
            for (int i = 0; i < dgvMain.ColumnCount; i++)
            {
                dgvMain.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }
        
        
        private void yangiUyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHouse yangiUy = new NewHouse();
            yangiUy.ShowDialog();
            if (yangiUy.DialogResult == DialogResult.OK)
            {
                string sql = $"INSERT INTO Uylar (Viloyat, Tuman,Mahalla, Kocha, Uy, Xonadon, Tur, Qavat, Xona,Narx, Telefon)" +
                    $" VALUES('{yangiUy.Vil}', '{yangiUy.Tum}','{yangiUy.Mah}','{yangiUy.Koch}'," +
                    $"'{yangiUy.Uy.ToString()}', '{yangiUy.Xon.ToString()}','{yangiUy.Tur}'," +
                    $"'{yangiUy.Qavat.ToString()}','{yangiUy.Xona.ToString()}','{yangiUy.Narx}', '{yangiUy.Tel}')";
                datatable = DB.db.Query(sql);

                //MessageBox.Show(sql);
                datatable = DB.db.Query("select * from Uylar");
                dgvMain.DataSource = datatable;
            }
        }

        private void tsmosish_Click(object sender, EventArgs e)
        {
            dgvMain.Sort(dgvMain.Columns[8], ListSortDirection.Ascending);
        }

        private void tsmKamay_Click(object sender, EventArgs e)
        {
            dgvMain.Sort(dgvMain.Columns[8], ListSortDirection.Descending);
        }

        private void tsmNom_Click(object sender, EventArgs e)
        {
            dgvMain.Sort(dgvMain.Columns[2], ListSortDirection.Ascending);
        }

        int textLength = 0;
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (textLength > txtSearch.Text.Length)
            {
                datatable = DB.db.Query("select * from Uylar");
                dgvMain.DataSource = datatable;
            }
            for (int i = 0; i < dgvMain.Rows.Count; i++)
            {
                for (int j = 0; j < dgvMain.Columns.Count; j++)
                {
                    if (!dgvMain.Rows[i].Cells[j].Value.ToString().ToLower().Contains(txtSearch.Text.ToLower()))
                    {
                        if (j == 11)
                        {
                            dgvMain.Rows.Remove(dgvMain.Rows[i]);
                        }
                    }
                    else
                    {
                        break;
                    }
                }
            }

            textLength = txtSearch.Text.Length;
        }

        private void изменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewHouse yangiUy = new NewHouse(dgvMain.CurrentRow);
            yangiUy.ShowDialog();
            if (yangiUy.DialogResult == DialogResult.OK)
            {
                string sql = $"UPDATE Uylar SET Viloyat='{yangiUy.Vil}', Tuman='{yangiUy.Tum}'," +
                    $" Mahalla='{yangiUy.Mah}',Kocha='{yangiUy.Koch}', Uy='{yangiUy.Uy.ToString()}', " +
                    $" Xonadon='{yangiUy.Xon.ToString()}', Tur='{yangiUy.Tur}'," +
                    $" Qavat='{yangiUy.Qavat.ToString()}', Xona='{yangiUy.Xona.ToString()}'," +
                    $" Narx='{yangiUy.Narx}',Telefon='{yangiUy.Tel}'" +
                    $" WHERE Id={dgvMain.CurrentRow.Cells[0].Value.ToString()}";
                datatable = DB.db.Query(sql);
                //MessageBox.Show(sql);
                
                 File.Copy(yangiUy.PicPath, dataPath + $"\\{dgvMain.CurrentRow.Cells[0].Value.ToString()}.jpg", true);
                datatable = DB.db.Query("select * from Uylar");
                dgvMain.DataSource = datatable;
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bu ma'lumotlarni rostdan o'chirmoqchimisiz?", "Ma'lumot",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                datatable = DB.db.Query($"delete * from Uylar where Id={dgvMain.CurrentRow.Cells[0].Value.ToString()}");
                datatable = DB.db.Query("select * from Uylar");
                dgvMain.DataSource = datatable;
            }
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowHouse show = new ShowHouse(dgvMain.CurrentRow);
            show.ShowDialog();
        }
    }
}
