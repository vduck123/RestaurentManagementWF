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
    public partial class Home_VIEW : Form
    {
        public Home_VIEW()
        {
            InitializeComponent();
        }

        private void Home_VIEW_Load(object sender, EventArgs e)
        {
            UpdateTime();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Interval += 1000;
            UpdateTime();
        }
        void UpdateTime()
        {
            DateTime dt = DateTime.Now;
            string Clock = $"{dt.Hour} : {dt.Minute}";
            lbCLock.Text = Clock ;
            lbSecond.Text = dt.Second.ToString();

            string Calender = $"{dt.Month}/{dt.Day}/{dt.Year}";
            lbCalendar.Text = Calender;
            lbDay.Text = dt.DayOfWeek.ToString();

        }
    }
}
