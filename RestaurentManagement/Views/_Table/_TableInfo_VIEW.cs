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
    public partial class _TableInfo_VIEW : Form
    {
        MainForm mf = new MainForm();
        string _ID = null;
        public _TableInfo_VIEW()
        {
            InitializeComponent();
        }
        private void _TableInfo_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        DataGridViewRow rowSelected = null;

        private void dgvTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0)
            {
                rowSelected = dgvTable.Rows[e.RowIndex];
                _ID = rowSelected.Cells[0].Value.ToString();
            }
        }

        

        private void btnSearch_Click(object sender, EventArgs e)
        {
            dgvTable.Columns.Clear();
            DataTable dt = HandleSearch(cbbOption.SelectedItem.ToString(), txtParam.Text);
            dgvTable.DataSource = dt;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            Refresh();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _AddTable view = new _AddTable();
            view.ShowDialog();  
        }

        private void sửaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(_ID == null)
            {
                return;
            }
            _EditTable view = new _EditTable(_ID);
            view.ShowDialog();

        }

        private void xóaBànToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_ID == null)
            {
                return;
            }

            DialogResult qs = mf.NotifyConfirm($"Chọn OK để xác nhận xóa {TableController.Instance.GetNameTableById(_ID)}");
            if(qs == DialogResult.OK)
            {
                int rs = TableController.Instance.DeleteTableByID(_ID);
                if(rs > 0)
                {
                    mf.NotifySuss("Xóa bàn thành công");
                    Refresh();
                }
            }
        }


        #region Method

        DataTable HandleSearch(string option, string param)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bàn");
            dt.Columns.Add("Tên bàn");
            dt.Columns.Add("Trạng thái");
            List<Table> tables = new List<Table>();

            switch(option)
            {
                case "Tìm kiếm theo mã bàn":
                    {
                        tables = TableController.Instance.GetTablesByParam("table_id", $"'{param}'", "=");
                        break;
                    }
                case "Tìm kiếm theo tên bàn":
                    {
                        tables = TableController.Instance.GetTablesByParam("table_name", $"N'%{param}%'", "LIKE");
                        break;
                    }
                case "Tìm kiếm theo trạng thái":
                    {
                        tables = TableController.Instance.GetTablesByParam("status", $"N'%{param}%'", "LIKE");
                        break;
                    }
            }



            foreach (Table tb in tables)
            {
                dt.Rows.Add(tb.Id, tb.Name, tb.Status);
            }

            return dt;
        }
        void LoadData()
        {
            LoadOption();
            LoadTable();
        }

        void LoadTable()
        {
            dgvTable.Columns.Clear();
            DataTable dt = new DataTable();
            dt.Columns.Add("Mã bàn");
            dt.Columns.Add("Tên bàn");
            dt.Columns.Add("Trạng thái");
            List<Table> tables = TableController.Instance.GetListTable();
            foreach (Table tb in tables)
            {
                dt.Rows.Add(tb.Id, tb.Name, tb.Status);
            }

            dgvTable.DataSource = dt;

        }

        void LoadOption()
        {
            List<string> options = new List<string>
            {
                "Tìm kiếm theo mã bàn" ,
                "Tìm kiếm theo tên bàn" ,
                "Tìm kiếm theo trạng thái"
            };

            cbbOption.DataSource = options;
        }

        void Refresh()
        {
            LoadData();
            txtParam.ResetText();
        }
        #endregion
    }
}
