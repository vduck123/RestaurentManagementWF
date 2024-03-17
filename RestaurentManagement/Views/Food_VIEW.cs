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

namespace RestaurentManagement.Views
{
    public partial class Food_VIEW : Form
    {
        public Food_VIEW()
        {
            InitializeComponent();
        }

        private void Food_VIEW_Load(object sender, EventArgs e)
        {
            LoadData();
            Refresh();
        }

        #region Method
        void LoadData()
        {
            dgvFood.Columns.Clear();
            List<Food> foods = FoodController.Instance.GetListFood();

            DataTable dt = new DataTable();
            dt.Columns.Add("ID Cateroty");
            dt.Columns.Add("Food name");
            dt.Columns.Add("Price");
            dt.Columns.Add("ID Food");
            foreach (Food f in foods)
            {
                dt.Rows.Add(FoodCategoryController.Instance.GetNameCatgoryFoodByID(f.FoodType),f.Name,f.Price,f.ID);
            }
            dgvFood.DataSource = dt;
        }

        void Refresh()
        {
            LoadData();
            txtFoodID.ResetText();
            txtFoodName.ResetText();
            txtFoodPrice.ResetText();
        }
        #endregion

        #region Event
        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnDel_Click(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {

        }
        #endregion


    }
}
