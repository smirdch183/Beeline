using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Beeline.FolderData;
using Microsoft.Win32;
using Excel = Microsoft.Office.Interop.Excel;

namespace Beeline.FolderClass
{
    class ClassExport
    {
        public static void ToExcelFile(DataGrid listDataGrid, string nameList)
        {
            Excel.Application excelApplication = null;
            Excel.Workbook workbook = null;
            Excel.Worksheet sheet = null;
            var process = Process.GetProcessesByName("EXCEL");

            SaveFileDialog openDlg = new SaveFileDialog();
            openDlg.FileName = nameList;
            openDlg.Filter = "Excel (.xls)|*.xls |Excel (.xlsx)|*.xlsx |All files (*.*)|*.*";
            openDlg.FilterIndex = 2;
            openDlg.RestoreDirectory = true;
            string path = openDlg.FileName;

            if (openDlg.ShowDialog() == true)
            {
                excelApplication = new Excel.Application();
                excelApplication.Visible = true;
                workbook = excelApplication.Workbooks.Add(System.Reflection.Missing.Value);
                sheet = (Excel.Worksheet)workbook.Sheets[1];

                for (int j = 0; j < listDataGrid.Columns.Count; j++)
                {
                    Excel.Range myRange = (Excel.Range)sheet.Cells[1, j + 1];
                    sheet.Cells[1, j + 1].Font.Bold = true;
                    sheet.Cells[1, j + 1].Style.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    myRange.Value2 = listDataGrid.Columns[j].Header;
                }
                for (int i = 0; i < listDataGrid.Columns.Count; i++)
                {
                    for (int j = 0; j < listDataGrid.Items.Count; j++)
                    {
                        TextBlock b = listDataGrid.Columns[i].GetCellContent(listDataGrid.Items[j]) as TextBlock;
                        Excel.Range myRange = (Excel.Range)sheet.Cells[j + 2, i + 1];
                        myRange.Value2 = b.Text;
                    }
                }         

                sheet.Columns.AutoFit();

                workbook.SaveAs("Клиенты");
            }
        }

    }
}

