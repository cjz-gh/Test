using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DictionaryTest
{
    public class AccessData
    {
        public static DataTable GetData()
        {
            string mdbSource = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\wpf学习\MyFirstWpfApplication\DictionaryTest\bin\x86\Debug\Resources\Data\test.accdb";
            OleDbConnection conn = new OleDbConnection(mdbSource); //Jet OLEDB:Database Password=
            OleDbCommand cmd = conn.CreateCommand();

            cmd.CommandText = "select * from 表1";
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    dt.Columns.Add(dr.GetName(i));
                }
                dt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];
                }
                dt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            return dt;
        }
    }
}
