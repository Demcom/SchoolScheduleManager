using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;
using System.Data;
using System.Data.OleDb;
using Excel;
using ScheduleManager.interfaces;
using ScheduleManager.enums;
using ScheduleManager.common;
using ScheduleManager.model;

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

        public static DataTable GetExcelWorksheet(string path, string workSheetName)
        {
            using (OleDbConnection conn = new OleDbConnection())
            {
                DataTable result = new DataTable();

                using (FileStream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                {
                    FileInfo fileinfo = new FileInfo(stream.Name);

                    if (fileinfo.Extension == ".xls")
                        conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
                    else if (fileinfo.Extension == ".xlsx")
                        conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                }

                using (OleDbCommand comm = new OleDbCommand())
                {
                    comm.CommandText = "Select * from [" + workSheetName + "$]";
                    comm.Connection = conn;

                    using (OleDbDataAdapter da = new OleDbDataAdapter())
                    {
                        da.SelectCommand = comm;
                        da.Fill(result);
                    }
                }

                return result;
            }
        }

        public static void personalExcelToDB()
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);

            if (path != "")
            {
                DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

                foreach (DataRow dataRow in result.Rows)
                {
                    Personal p = new Personal()
                    {
                        ccdepcve = getNullableInt(dataRow["ccdepcve"]),
                        ccesrced = getNullableInt(dataRow["ccesrced"]),
                        ccperara = getNullableDateTime(dataRow["ccperara"]),
                        ccpercve = getInt(dataRow["ccpercve"]),
                        ccperdepa = getNullableInt(dataRow["ccperdepa"]),
                        ccpernom = Convert.ToString(dataRow["ccpernom"]),
                        ccperrfc = Convert.ToString(dataRow["ccperrfc"]),
                        ccpertar = getNullableInt(dataRow["ccpertar"]),
                        cctitnco = Convert.ToString(dataRow["cctitnco"])
                    };

                    ScheduleManagerEntities context = new ScheduleManagerEntities();
                    context.Personals.Add(p);
                    context.SaveChanges();
                }
            }
        }

        public static void personalFrenteAGrupoExcelToDB()
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);

            if (path != "")
            {
                DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

                foreach (DataRow dataRow in result.Rows)
                {
                    PersonalFrenteAGrupo p = new PersonalFrenteAGrupo()
                    {
                        cccve = Convert.ToString(dataRow["cccve"]),
                        ccdepcve = getNullableInt(dataRow["ccdepcve"]),
                        ccdes = getInt(dataRow["ccdes"]),
                        cceso = getInt(dataRow["cceso"]),
                        ccexc = getInt(dataRow["ccexc"]),
                        cchrst = getInt(dataRow["cchrst"]),
                        ccmath = getInt(dataRow["ccmath"]),
                        ccmot = Convert.ToString(dataRow["ccmot"]),
                        ccnmat = getInt(dataRow["ccnmat"]),
                        ccpercve = getInt(dataRow["ccpercve"]),
                        ccpernom = Convert.ToString(dataRow["ccpernom"]),
                        ccpertar = getNullableInt(dataRow["ccpertar"])
                   };

                    ScheduleManagerEntities context = new ScheduleManagerEntities();
                    context.PersonalFrenteAGrupo.Add(p);
                    context.SaveChanges();
                }
            }
        }

        public static void EstructuraExcelToDB()
        {
            string path = FileBrowser.Instance.getFilePath(FileFormatsEnum.EXCELFILES);

            if (path != "")
            {
                DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

                foreach (DataRow dataRow in result.Rows)
                {
                    Estructura p = new Estructura()
                    {
                        ccacdhrs = getInt(dataRow["ccacdhrs"]),
                        ccacdnco = Convert.ToString(dataRow["ccacdnco"]),
                        cccarnco = Convert.ToString(dataRow["cccarnco"]),
                        cccatcve = Convert.ToString(dataRow["cccatcve"]),
                        ccdepcve = getInt(dataRow["ccdepcve"]),
                        ccdes = getInt(dataRow["ccdes"]),
                        ccesrced = getInt(dataRow["ccesrced"]),
                        ccfac = getNullableBool(dataRow["ccfac"]),
                        cchfglic = getInt(dataRow["cchfglic"]),
                        cchfgpos = getInt(dataRow["cchfgpos"]),
                        ccmatcve = Convert.ToString(dataRow["ccmatcve"]),
                        ccmathpr = getInt(dataRow["ccmathpr"]),
                        ccmathte = getInt(dataRow["ccmathte"]),
                        ccmatnco = Convert.ToString(dataRow["ccmatnco"]),
                        ccmatnom = Convert.ToString(dataRow["ccmatnom"]),
                        ccmot = Convert.ToString(dataRow["ccmot"]),
                        ccngp = getInt(dataRow["ccngp"]),
                        ccperara = getNullableDateTime(dataRow["ccperara"]),
                        ccpercve = getInt(dataRow["ccpercve"]),
                        ccpernom = Convert.ToString(dataRow["ccpernom"]),
                        ccperrfc = Convert.ToString(dataRow["ccperrfc"]),
                        ccpertar = getInt(dataRow["ccpertar"]),
                        ccplmcve = getInt(dataRow["ccplmcve"]),
                        ccplmhrs = getInt(dataRow["ccplmhrs"]),
                        cctitnco = Convert.ToString(dataRow["cctitnco"])
                    };

                    ScheduleManagerEntities context = new ScheduleManagerEntities();
                    context.Estructura.Add(p);
                    context.SaveChanges();
                }
            }
        }

        static int? getNullableInt(object cell)
        {
            if (cell.GetType() == typeof(double))
            {
                if (Double.IsInfinity((double)cell))
                    return null;

                return Convert.ToInt32(cell);
            }
            else if (cell.GetType() == typeof(string))
            {
                int result;
                return int.TryParse(cell.ToString(), out result) ? result : (int?)null;
            }

            return null;
        }

        static DateTime? getNullableDateTime(object cell)
        {
            return cell == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(cell);
        }

        static bool? getNullableBool(object cell)
        {
            bool? result = null;

            if (cell.GetType() == typeof(string))
            {
                if (Convert.ToString(cell) == "SI")
                    result = true;
                else if (Convert.ToString(cell) == "NO")
                    result = false;
            }

            return result;
        }

        static int getInt(object cell)
        {
            int result = 0;

            if (cell.GetType() == typeof(double))
                result = Convert.ToInt32(cell);
            else if (cell.GetType() == typeof(string))
                int.TryParse(cell.ToString(), out result);

            return result;
        }
    }
}
