using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectAuto
{
    public class Excel
    {
        int firstEmptyCol = 4;// based on template
        Application excel = new Application();
        Workbook wb;
        Worksheet ws;
        public void OpenExcel(string path, int sheet)
        {
            wb = excel.Workbooks.Open(path);
            ws = wb.Worksheets[sheet];
        }
        public string ReadFromExcel(int col, int row)
        {
            return ws.Cells[col][row].value;
        }
        public void WriteOnExcel(int col, int row, string content)
        {
            ws.Cells[col][row].value = content;
        }
        public void WriteOnFirstEmptyColumn(int row, string content)
        {
            if (ws.Cells[firstEmptyCol][row].value == null)//4 -4
            {
                ws.Cells[firstEmptyCol][row].value = content;

            }
            else
            {
                firstEmptyCol++;//5
                WriteOnFirstEmptyColumn(row, content);
            }
        }
        public void CloseExcel()
        {
            wb.Save();
            excel.Workbooks.Close();
        }
    }
}
