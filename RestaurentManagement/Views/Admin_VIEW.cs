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
    public partial class Admin_VIEW : Form
    {
        public Admin_VIEW()
        {
            InitializeComponent();
        }


        //private void Timer_Tick(object sender, EventArgs e)
        //{
        //    // Gọi phương thức để cập nhật thời gian
        //    UpdateTime();
        //}

        //private void Admin_VIEW_Load(object sender, EventArgs e)
        //{
        //    // Gọi lần đầu để hiển thị thời gian ban đầu
        //    UpdateTime();
        //}

        //void UpdateTime()
        //{
        //    DateTime dt = DateTime.Now;
        //    string hour = null;
        //    if (dt.Hour < 10)
        //    {
        //        hour = $"0{dt.Hour.ToString()}";

        //    }
        //    string Clock = $"{hour}:{dt.Minute.ToString()}";
        //    lbCLock.Text = Clock;
        //    lbSecond.Text = dt.Second.ToString();

        //    string canlendar = $"{dt.Day}/{dt.Month}/{dt.Year}";
        //    lbCalendar.Text = canlendar;
        //    lbDay.Text = dt.DayOfWeek.ToString();
        //}

        

        Form currentForm = null;

        void OpenhChildForm(Form childForm)
        {
            if(currentForm != null)
            {
                currentForm.Close();
            }

            currentForm = childForm;

            childForm.TopLevel = false;

            childForm.FormBorderStyle = FormBorderStyle.None;

            childForm.Dock = DockStyle.Fill;

            guna2Panel4.Controls.Add(childForm);

            childForm.BringToFront();
            childForm.Show();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            OpenhChildForm(new Home_VIEW());
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            OpenhChildForm(new Order_VIEW());

        }
    }
}
