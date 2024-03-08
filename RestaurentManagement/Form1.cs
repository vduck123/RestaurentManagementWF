using RestaurentManagement.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void LoadData()
        {
            guna2DataGridView1.Columns.Clear();
            string query = "SELECT * FROM Test";
            DataTable dt = DBProvider.ExecuteDataAdapter(query);
            guna2DataGridView1.DataSource = dt;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            Test test = new Test()
            {
                ID = txtIDTest.Text,
                Name = txtNameTest.Text,
            };

            string query = @"INSERT INTO Test VALUES (@id,@name)";
            DBProvider.ExecuteNonQuery(query, test);
            LoadData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
