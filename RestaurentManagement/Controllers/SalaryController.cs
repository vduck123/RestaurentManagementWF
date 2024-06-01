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
    internal class SalaryController
    {
        private static SalaryController instance;
        public static SalaryController Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SalaryController();
                }
                return instance;
            }
        }

        public int InsertSalary(Salary s)
        {
            string query = @"INSERT INTO Salary
                             VALUES (@id,@month,@basic,@hsl,@hour,@num,@bonus,@fine,@total,@staff_id)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", s.ID } ,
                {"@month", s.Month } ,
                {"@basic", s.salaryBasic } ,
                {"@hsl", s.hsl } ,
                {"@hour", s.salaryHour } ,
                {"@num", s.numHour } ,
                {"@bonus", s.Bonus } ,
                {"@fine", s.Fine } ,
                {"@total", s.Total } ,
                {"@staff_id", s.staffID }

            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int UpdateSalary(Salary s)
        {
            string query = @"UPDATE Salary
                             SET salary_month = @month,
                                 salary_basic = @basic ,
                                 hsl = @hsl ,
                                 salary_hour = @hour ,
                                 num_hour = @num ,
                                 bonus = @bonus ,
                                 fine = @fine ,
                                 total = @total
                                 Where salary_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", s.ID } ,
                {"@month", s.Month } ,
                {"@basic", s.salaryBasic } ,
                {"@hsl", s.hsl } ,
                {"@hour", s.salaryHour } ,
                {"@num", s.numHour } ,
                {"@bonus", s.Bonus } ,
                {"@fine", s.Fine } ,
                {"@total", s.Total } ,
                {"@staff_id", s.staffID }

            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteSalary(string id)
        {
            string query = @"DELETE FROM Salary WHERE salary_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id} 
            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteSalaryBystaffId(string id)
        {
            string query = @"DELETE FROM Salary WHERE staff_id = @id";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                {"@id", id}
            };
            int data = DBHelper.Instance.ExecuteNonQuery(query, parameters);
            return data;
        }

        public int DeleteAll()
        {
            string query = @"DELETE FROM Salary";
            int data = DBHelper.Instance.ExecuteNonQuery(query,null);
            return data;
        }


        public List<Salary> SelectSalaryByParam(string option, string opera ,string param)
        {
            List<Salary> salaries = new List<Salary>();
            string query = $"SELECT * FROM Salary WHERE {option} {opera} {param}";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Salary s = new Salary(item);
                salaries.Add(s);
            }
            return salaries;
        }




        public List<Salary> GetListSalary()
        {
            List<Salary> salaries = new List<Salary>();
            string query = $"SELECT * FROM Salary";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow item in dt.Rows)
            {
                Salary s = new Salary(item);
                salaries.Add(s);
            }
            return salaries;
        }

        public int GetOrderNumInList()
        {
            string query = $"SELECT COUNT(salary_id) FROM Salary";
            int orderNum = Convert.ToInt32(DBHelper.Instance.ExecuteScalar(query));
            return orderNum;
        }
    }
}
