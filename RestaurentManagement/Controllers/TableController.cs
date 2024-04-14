using RestaurentManagement.Models;
using RestaurentManagement.utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RestaurentManagement.Controllers
{
    internal class TableController
    {
        public static int tableWidth = 100;
        public static int tableHeight = 80;
        public static Font FontMain = new Font("Segoe UI Historic",12);
        public static Color status0 = Color.Green;
        public static Color status1 = Color.Red;
        public static Color isSelected = Color.AliceBlue;

        private static TableController instance;

        public static TableController Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableController();
                }
                return instance;
            }
        }

        public TableController() { }

        
        public int InsertTable(Table tb,string mess)
        {
            string query = $@"INSERT INTO _Table
                             VALUES(@id, @name, @status)";
            Dictionary<string, object> parameters = new Dictionary<string, object>()
            {
                { "@id", tb.Id } ,
                { "@name", tb.Name } ,
                { "@status", tb.Status }
            };
            
            int result = DBHelper.Instance.ExecuteNonQuery(query,parameters);

            return result ;

        }



        public List<Table> GetListTable()
        {
            List<Table> tables = new List<Table>();
            string query = "SELECT * FROM _Table";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow dr in dt.Rows)
            {
                Table tb = new Table(dr);
                tables.Add(tb);
            }
            return tables;
        }

        public string GetNameTableById(string id)
        {
            string name = string.Empty;
            string query = $"SELECT * FROM _Table WHERE table_id = '{id}'";
            DataTable dt = DBHelper.Instance.ExecuteQuery(query);
            foreach (DataRow row in dt.Rows)
            {
                name = row["table_name"].ToString();
            }
            return name;
        }

    }
}
