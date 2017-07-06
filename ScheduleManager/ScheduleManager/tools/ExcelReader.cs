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
using ScheduleManager.exceptions;

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

        public static void personalExcelToDB(IProgress<int> progress, string path)
        {
            DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

            if (!isPersonalTable(result.Columns))
            {
                throw new BadExcelFormatException();
            }

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

                int recordNum = result.Rows.IndexOf(dataRow) + 1;
                progress.Report(100 * recordNum / result.Rows.Count);
            }
        }

        public static void personalFrenteAGrupoExcelToDB(IProgress<int> progress, string path)
        {
            DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

            if (!isPersonalFrenteAGrupoTable(result.Columns))
            {
                throw new BadExcelFormatException();
            }

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

                int recordNum = result.Rows.IndexOf(dataRow) + 1;
                progress.Report(100 * recordNum / result.Rows.Count);
            }
        }

        public static void EstructuraExcelToDB(IProgress<int> progress, string path)
        {
            DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

            if (!isEstructuraTable(result.Columns))
            {
                throw new BadExcelFormatException();
            }

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

                int recordNum = result.Rows.IndexOf(dataRow) + 1;
                progress.Report(100 * recordNum / result.Rows.Count);
            }
        }

        public static void DistribucionExcelToDB(IProgress<int> progress, string path)
        {
            DataTable result = ExcelReader.GetExcelWorksheet(path, "32200");

            if (!isDistribucionTable(result.Columns))
            {
                throw new BadExcelFormatException();
            }

            foreach (DataRow dataRow in result.Rows)
            {
                Distribucion d = new Distribucion()
                {
                    ccdepcve = getNullableInt(dataRow["ccdepcve"]),
                    ccpercve = getInt(dataRow["ccpercve"]),
                    ccpertar = getNullableInt(dataRow["ccpertar"]),
                    ccpernom = Convert.ToString(dataRow["ccpernom"]),
                    cccve = Convert.ToString(dataRow["cccve"]),
                    cchrst = getInt(dataRow["cchrst"]),
                    ccdes = getInt(dataRow["ccdes"]),
                    cceso = getInt(dataRow["cceso"]),
                    ccnmat = getInt(dataRow["ccnmat"]),
                    ccmath = getInt(dataRow["ccmath"]),
                    ccexc = getInt(dataRow["ccexc"]),
                    ccmot = Convert.ToString(dataRow["ccmot"]),
                    ccperara = getNullableDateTime(dataRow["ccperara"]),
                    cctitnco = Convert.ToString(dataRow["cctitnco"]),
                    ccesrced = getNullableInt(dataRow["ccesrced"]),
                    cccar1a = getInt(dataRow["cccar1a"]),
                    cccar1b = getInt(dataRow["cccar1b"]),
                    cccar2a = getInt(dataRow["cccar2a"]),
                    cccar2b = getInt(dataRow["cccar2b"]),
                    cccar3a = getInt(dataRow["cccar3a"]),
                    cccar3b = getInt(dataRow["cccar3b"]),
                    cccar4a = getInt(dataRow["cccar4a"]),
                    cccar4b = getInt(dataRow["cccar4b"]),
                    cccar5a = getInt(dataRow["cccar5a"]),
                    cccar5b = getInt(dataRow["cccar5b"]),
                    cccar6a = getInt(dataRow["cccar6a"]),
                    cccar6b = getInt(dataRow["cccar6b"]),
                    cccar7a = getInt(dataRow["cccar7a"]),
                    cccar7b = getInt(dataRow["cccar7b"]),
                    cccar8a = getInt(dataRow["cccar8a"]),
                    cccar8b = getInt(dataRow["cccar8b"]),
                    cccar9a = getInt(dataRow["cccar9a"]),
                    cccar9b = getInt(dataRow["cccar9b"]),
                    cccar10a = getInt(dataRow["cccar10a"]),
                    cccar10b = getInt(dataRow["cccar10b"]),
                    ccpdo1a = getInt(dataRow["ccpdo1a"]),
                    ccpdo1b = getInt(dataRow["ccpdo1b"]),
                    ccpdo2a = getInt(dataRow["ccpdo2a"]),
                    ccpdo2b = getInt(dataRow["ccpdo2b"]),
                    ccpdo3a = getInt(dataRow["ccpdo3a"]),
                    ccpdo3b = getInt(dataRow["ccpdo3b"]),
                    ccpdo4a = getInt(dataRow["ccpdo4a"]),
                    ccpdo4b = getInt(dataRow["ccpdo4b"]),
                    ccpdo5a = getInt(dataRow["ccpdo5a"]),
                    ccpdo5b = getInt(dataRow["ccpdo5b"]),
                    ccpdo6a = getInt(dataRow["ccpdo6a"]),
                    ccpdo6b = getInt(dataRow["ccpdo6b"]),
                    ccpdo7a = getInt(dataRow["ccpdo7a"]),
                    ccpdo7b = getInt(dataRow["ccpdo7b"]),
                    ccpdo8a = getInt(dataRow["ccpdo8a"]),
                    ccpdo8b = getInt(dataRow["ccpdo8b"]),
                    ccpdo9a = getInt(dataRow["ccpdo9a"]),
                    ccpdo9b = getInt(dataRow["ccpdo9b"]),
                    ccpdo10a = getInt(dataRow["ccpdo10a"]),
                    ccpdo10b = getInt(dataRow["ccpdo10b"])
                };

                ScheduleManagerEntities context = new ScheduleManagerEntities();
                context.Distribucion.Add(d);
                context.SaveChanges();

                int recordNum = result.Rows.IndexOf(dataRow) + 1;
                progress.Report(100 * recordNum / result.Rows.Count);
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

        static bool isPersonalTable(DataColumnCollection excelColumns)
        {
            List<string> personalColumnNames = new List<string>
            {
                "ccdepcve", "ccperdepa", "ccpercve", "ccpertar", "ccpernom",
                "ccperara", "cctitnco", "ccesrced", "ccperrfc"
            };

            foreach (string column in personalColumnNames)
                if (!excelColumns.Contains(column)) return false;

            return true;
        }

        static bool isPersonalFrenteAGrupoTable(DataColumnCollection excelColumns)
        {
            List<string> personalFrenteAGrupoColumnNames = new List<string>
            {
                "ccdepcve", "ccpercve", "ccpertar", "ccpernom", "cccve", "cchrst",
                "ccdes", "cceso", "ccnmat", "ccmath", "ccexc", "ccmot"
            };

            foreach (string column in personalFrenteAGrupoColumnNames)
                if (!excelColumns.Contains(column)) return false;

            if (excelColumns.Contains("ccperara")) return false;

            return true;
        }

        static bool isEstructuraTable(DataColumnCollection excelColumns)
        {
            List<string> estructuraColumnNames = new List<string>
            {
                "ccdepcve", "ccpercve", "ccpertar", "ccpernom", "ccplmcve",
                "ccperara", "cccatcve", "ccplmhrs", "cchfglic", "cchfgpos",
                "ccdes", "ccfac", "ccmot", "ccmatcve", "ccmatnco", "ccmathte",
                "ccmathpr", "ccngp", "cccarnco", "cctitnco", "ccesrced", "ccperrfc",
                "ccacdnco", "ccacdhrs", "ccmatnom"
            };

            foreach (string column in estructuraColumnNames)
                if (!excelColumns.Contains(column)) return false;

            return true;
        }

        static bool isDistribucionTable(DataColumnCollection excelColumns)
        {
            List<string> distribucionColumnNames = new List<string>
            {
                "ccdepcve", "ccpercve", "ccpertar", "ccpernom", "cccve", "cchrst",
                "ccdes", "cceso", "ccnmat", "ccmath", "ccexc", "ccmot", "ccperara",
                "cctitnco", "ccesrced", "cccar1a", "cccar1b", "cccar2a", "cccar2b",
                "cccar3a", "cccar3b", "cccar4a", "cccar4b", "cccar5a", "cccar5b",
                "cccar6a", "cccar6b", "cccar7a", "cccar7b", "cccar8a", "cccar8b",
                "cccar9a", "cccar9b", "cccar10a", "cccar10b", "ccpdo1a", "ccpdo1b",
                "ccpdo2a", "ccpdo2b", "ccpdo3a", "ccpdo3b", "ccpdo4a", "ccpdo4b",
                "ccpdo5a", "ccpdo5b", "ccpdo6a", "ccpdo6b", "ccpdo7a", "ccpdo7b",
                "ccpdo8a", "ccpdo8b", "ccpdo9a", "ccpdo9b", "ccpdo10a", "ccpdo10b"
            };

            foreach (string column in distribucionColumnNames)
                if (!excelColumns.Contains(column)) return false;

            return true;
        }
    }
}
