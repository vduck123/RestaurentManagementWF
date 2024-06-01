using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;

namespace RestaurentManagement.utils
{
    internal class Office
    {
        static Office()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private static Office _instance;

        public static Office Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Office();
                }
                return _instance;
            }
        }

        public void ExportExcel(DataGridView dataGridView1, string fileName)
        {
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                for (int col = 0; col < dataGridView1.Columns.Count; col++)
                {
                    worksheet.Cells[1, col + 1].Value = dataGridView1.Columns[col].HeaderText;
                    worksheet.Cells[1, col + 1].Style.Font.Bold = true;
                    worksheet.Cells[1, col + 1].Style.Fill.PatternType = ExcelFillStyle.Solid;
                    worksheet.Cells[1, col + 1].Style.Fill.BackgroundColor.SetColor(Color.LightGray);
                }

                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        worksheet.Cells[row + 2, col + 1].Value = dataGridView1.Rows[row].Cells[col].Value?.ToString();
                    }
                }
                FileInfo fileInfo = new FileInfo(fileName);
                package.SaveAs(fileInfo);
            }
        }
    }
}
