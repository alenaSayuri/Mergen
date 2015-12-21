using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;

namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        string column = null;
        public Form2()
        {
            CallBackMy.callbackEventHandler = new CallBackMy.callbackEvent(this.Reload);
            InitializeComponent();
        }

        void Reload(string a)
        {
            column = a;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); 
            string path = "D:/4lab";
            string ConnectionString = "Data Source=" + path + ";Version=3;"; 
            SQLiteConnection conn = new SQLiteConnection(ConnectionString);
            SQLiteDataAdapter da = new SQLiteDataAdapter("Select Fio From one", conn);
            da.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0].DefaultView;
            conn.Close();

            DataGridViewCheckBoxColumn c = new DataGridViewCheckBoxColumn();
            c.HeaderText = "Присутствие";
            dataGridView1.Columns.Add(c);

            SQLiteCommand command;
            if (column == null)
            {
                for (int i = 0; i < 6; i++ )
                {
                    
                   // string sql = "INSERT INTO one (" + textBox1 + ") VALUES ('" 1 "')";
                //   command = new SQLiteCommand(sql, conn);
                    conn.Open();
              //      command.ExecuteNonQuery();
                    conn.Close();
                }
            }
            
            
            

            if (column != null)
            {
                textBox1.Text = column;
            }
            column = null;
        }
    }
}
