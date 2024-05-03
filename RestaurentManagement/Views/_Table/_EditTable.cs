using RestaurentManagement.Controllers;
using RestaurentManagement.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Views._Table
{
    public partial class _EditTable : Form
    {
        MainForm mf = new MainForm();
        string _ID;
        public _EditTable(string id)
        {
            InitializeComponent();
            _ID = id;
        }
        private void _EditTable_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult qs = mf.NotifyConfirm("Chọn OK để xác nhận thông tin");
            if(qs == DialogResult.OK)
            {
                Table tb = new Table(_ID, txtName.Text, cbbStatus.SelectedItem.ToString());
                int rs = TableController.Instance.UpdateTable(tb);
                if(rs > 0)
                {
                    mf.NotifySuss("Cập nhật thông tin thành công");
                    this.Close();
                }
            }
        }

        
        private void btnHide_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        void LoadData()
        {
            GetData();
            LoadStatus();
        }

        void GetData()
        {
            if(_ID != null)
            {
                List<Table> list = TableController.Instance.GetTablesByParam("table_id", $"'{_ID}'", "LIKE");
                foreach (Table t in list)
                {
                    txtName.Text = t.Name;
                    cbbStatus.SelectedItem = t.Status;
                }
            } 
        }

        void LoadStatus()
        {
            List<string> status = new List<string>
            {
                "Trống" ,
                "Đầy"
            };
            cbbStatus.DataSource = status;
        }
    }
}
