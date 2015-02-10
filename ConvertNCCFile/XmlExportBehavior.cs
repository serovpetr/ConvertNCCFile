using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel; 

namespace ConvertNCCFile
{
    public class XmlExportBehavior : IExportBehavior
    {
        public void Export(string filePath, ICollection<Bill> bills)
        {
            var xlApp = new Excel.Application();
            if (xlApp == null)
            {
                throw new Exception("Excel is not properly installed!!");
            }

            object misValue = System.Reflection.Missing.Value;

            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add(misValue);
            var xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.Item[1];
            
            if (xlWorkSheet == null)
                throw new Exception("xlWorkSheet");

            xlWorkSheet.Cells[1, 1] = "Номер телефона";
            xlWorkSheet.Cells[1, 2] = "Сумма (у.е.)";

            var index = 2;
            foreach (var bill in bills)
            {
                xlWorkSheet.Cells[index, 1] = bill.Subscriber;
                xlWorkSheet.Cells[index, 2] = bill.Total;

                index++;
            }

            xlWorkBook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
