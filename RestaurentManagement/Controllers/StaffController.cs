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
    internal class StaffController
    {
        private static StaffController instance;
        public static StaffController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new StaffController();
                }
                return instance;
            }
        }

        public int InsertStaff(Staff staff)
        {
            string query = @"INSERT INTO Staff 
                             VALUES (@id,@name,@gender,@birth,@phone,@acc_id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", staff.ID},
                {"@name", staff.Name},
                {"@gender", staff.Gender } ,
                {"@birth", staff.Birth } ,
                {"@phone", staff.Phone } ,
                {"@acc_id", staff.Acc_ID}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }
        public int UpdateStaff(Staff staff)
        {
            string query = @"UPDATE Staff 
                             SET staff_name = @name ,
                                 gender = @gender ,
                                 birth = @birth ,
                                 phone = @phone ,
                             WHERE staff_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", staff.ID},
                {"@name", staff.Name},
                {"@gender", staff.Gender } ,
                {"@birth", staff.Birth } ,
                {"@phone", staff.Phone } 
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteStaff(string id)
        {
            string query = @"DELETE FROM Staff WHERE staff_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id}
            };

            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public List<Staff> SelectStaffByID(string id)
        {
            List<Staff> listStaff = new List<Staff>();
            string query = $"SELECT * FROM Staff Where staff_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Staff staff = new Staff(item);
                listStaff.Add(staff);
            }

            return listStaff;
        }

        public List<Staff> GetListStaff()
        {
            List<Staff> listStaff = new List<Staff>();
            string query = $"SELECT * FROM Staff";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow item in dt.Rows)
            {
                Staff staff = new Staff(item);
                listStaff.Add(staff);
            }
            return listStaff;
        }

        public string GetNameStaffByID(string id)
        {
            string name = null;
            string query = $"SELECT * FROM Staff Where staff_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                name = (string)row["staff_name"];
            }

            return name;
        }

        public string GetNameStaffByAccID(string id)
        {
            string name = null;
            string query = $@"SELECT s.staff_name
                             FROM dbo.Account a
                             INNER JOIN dbo.Staff s ON s.acc_id = a.acc_id
                             WHERE a.acc_id = '{id}'";

            DataTable dt = DBHelper.Instance.ExecuteQuery(query);

            foreach (DataRow row in dt.Rows)
            {
                name = row["staff_name"].ToString();
            }

            return name;
        }
    }
}
