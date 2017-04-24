using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data;
using Excel;
using ScheduleManager.interfaces;
using ScheduleManager.enums;
using ScheduleManager.common;

namespace ScheduleManager.tools
{
    class ExcelReader : IExcelReader
    {

        public ExcelReader() {
           
        }

        public void readExcel()
        {
            FileBrowser.Instance.getFilePathWithFormat(FileFormatsEnum.EXCELFILES, readingExcel);
        }

        private void readingExcel(string path) {
            if (path != "")
            {
                try
                {
                    IExcelDataReader excelReader = null;
                    FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read);
                    FileInfo file = new FileInfo(stream.Name);
                    if (file.Extension == ".xls")
                    {
                        excelReader = ExcelReaderFactory.CreateBinaryReader(stream);

                    }
                    else {
                        excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                    }

                    excelReader.IsFirstRowAsColumnNames = true;
                    DataSet result = excelReader.AsDataSet();

                    foreach (DataTable table in result.Tables)
                    {
                        Debug.WriteLine(table.Rows.Count);
                        Debug.WriteLine(table.Columns.Count);

                        //for (int i = 0; i < table.Rows.Count; i++)
                        //{
                        //    for (int j = 0; j < table.Columns.Count; j++)
                        //        Debug.WriteLine("\"" + table.Rows[i].ItemArray[j] + "\";");
                        //}
                    }
                }
                catch (Exception e) {
                    Debug.WriteLine(e.Message);
                }

            }
        }

        public void renderExcel()
        {

        }
    }
}
