using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.Controllers
{
    internal class VoucherController
    {

        private static VoucherController instance;

        internal static VoucherController Instance 
        {
            get
            {
                if(instance == null)
                {
                    instance = new VoucherController();
                }   
                return instance;
            }
        }

        public List<Voucher> GetListVoucher()
        {
            List<Voucher> vouchers = new List<Voucher>();   
            string query = "SELECT * FROM Voucher";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Voucher voucher = new Voucher(dr);
                vouchers.Add(voucher);
            }
            return vouchers;
        }
    }
}
