using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurentManagement.utils
{
    internal class SeparetePage
    {
        private static SeparetePage instance;
        public static SeparetePage Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new SeparetePage();
                }
                return instance;
            }
        }
        private DataTable _data;
        private int _currentPage;
        private int _pageSize;


        public DataTable NextPage(DataTable data, int pageSize, int current)
        {
            if (_currentPage < (_data.Rows.Count / _pageSize))
            {
                _currentPage++;
            }
            return GetPage();
        }

        public DataTable PreviousPage(DataTable data, int pageSize, int current)
        {
            if (_currentPage > 0)
            {
                _currentPage--;
            }
            return GetPage();
        }

        public DataTable GetPage()
        {
            DataTable dtNew = _data.Clone(); // Clone the structure of the original DataTable
            int start = _currentPage * _pageSize;
            int end = Math.Min(start + _pageSize, _data.Rows.Count);

            for (int i = start; i < end; i++)
            {
                dtNew.ImportRow(_data.Rows[i]);
            }
            return dtNew;
        }
    }
}
