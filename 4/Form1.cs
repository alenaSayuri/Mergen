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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet(); 
            string ConnectionString = "Data Source=D:/4lab;Version=3;"; 
            SQLiteConnection conn = new SQLiteConnection(ConnectionString); 
            SQLiteDataAdapter da = new SQLiteDataAdapter("Select * From one", conn);
            da.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
      
            for (int i = 0; i < 5; i++)
            {
                dataGridView1.Columns[i].SortMode = DataGridViewColumnSortMode.Programmatic;
            }
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullColumnSelect;
            conn.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int a = dataGridView1.SelectedColumns[0].Index;
            string path = dataGridView1.Columns[a].Name;
            Form2 f2 = new Form2();
            CallBackMy.callbackEventHandler(path);
            f2.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            f2.Show();
            this.Hide();
        }
    }
}
