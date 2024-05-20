using OfficeOpenXml;
using OfficeOpenXml.Style;
using System;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;
using System.Xml.Linq;
using iTextSharp.text;
using iTextSharp.text.pdf;

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

        public void ExportPdf(DataGridView dataGridView1, string fileName)
        {
            Document doc = new Document(PageSize.A4, 10f, 10f, 10f, 10f);

            try
            {
                PdfWriter.GetInstance(doc, new FileStream(fileName, FileMode.Create));

                doc.Open();

                PdfPTable pdfTable = new PdfPTable(dataGridView1.ColumnCount);

                for (int i = 0; i < dataGridView1.ColumnCount; i++)
                {
                    pdfTable.AddCell(dataGridView1.Columns[i].HeaderText);
                }

                for (int row = 0; row < dataGridView1.Rows.Count; row++)
                {
                    for (int col = 0; col < dataGridView1.Columns.Count; col++)
                    {
                        pdfTable.AddCell(dataGridView1.Rows[row].Cells[col].Value?.ToString());
                    }
                }

                doc.Add(pdfTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }
    }
}
