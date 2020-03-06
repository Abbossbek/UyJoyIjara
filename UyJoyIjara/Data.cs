using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;

namespace UyJoyIjara
{
    class Data
    {
        OleDbConnection cn;
        string ConnectionString;

        public void Data_init(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public void Connect()
        {
            try
            {
                cn = new OleDbConnection();
                cn.ConnectionString = ConnectionString;
                cn.Open();
            }

            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to SQL Server" + exp.Message);
                return;
            }
        }

        public void Disconnect()
        {
            try
            {
                cn.Close();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("Can't connect to SQL Server" + exp.Message);
                return;
            }
        }

        public DataTable Query(string SQLstring)
        {
            OleDbCommand cm = null;
            try
            {
                cm = new OleDbCommand(SQLstring, cn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cm;
                DataTable _table = new DataTable();
                da.Fill(_table);
                da.Dispose();
                cm.Dispose();
                return _table;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                cm.Dispose();
                return null;
            }

        }
        public DataTable Query(string SQLstring, out OleDbDataAdapter oda)
        {
            OleDbCommand cm = null;
            try
            {
                cm = new OleDbCommand(SQLstring, cn);
                OleDbDataAdapter da = new OleDbDataAdapter();
                da.SelectCommand = cm;
                DataTable _table = new DataTable();
                da.Fill(_table);
                da.Dispose();
                cm.Dispose();
                oda = da;
                return _table;
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show(exp.Message);
                cm.Dispose();
                oda = null;
                return null;
            }

        }

        public int SetCommand(string SQLstring)
        {
            OleDbCommand cm = null;
            int res = -1;
            try
            {
                cm = new OleDbCommand(SQLstring, cn);
                res = cm.ExecuteNonQuery();
                cm.Dispose();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("SQL Base Drive.\n" + exp.Message);
                cm.Dispose();
                return res;
            }
            return res;

        }
    }
}
