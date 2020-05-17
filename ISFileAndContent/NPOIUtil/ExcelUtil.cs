using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.NPOIUtil
{
    public  class ExcelUtil: OfficeUtil
    {
        public override string Read(string filePath)
        {
            StringBuilder jsonAll = new StringBuilder();
            IWorkbook workbook;
            string fileExt = Path.GetExtension(filePath).ToLower();
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                //XSSFWorkbook 适用XLSX格式，HSSFWorkbook 适用XLS格式
                if (fileExt == ".xlsx") { workbook = new XSSFWorkbook(fs); } else if (fileExt == ".xls") { workbook = new HSSFWorkbook(fs); } else { workbook = null; }
                if (workbook == null) { return null; }

                //ISheet sheet = workbook.GetSheetAt(0); //只检索了第一个sheet页

                //枚举器遍历
                using (IEnumerator<ISheet> iterator = workbook.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        DataTable dt = new DataTable();
                        ISheet sheet = iterator.Current as ISheet;

                        //表头  
                        IRow header = sheet.GetRow(sheet.FirstRowNum);
                        List<int> columns = new List<int>();
                        for (int i = 0; i < header.LastCellNum; i++)
                        {
                            object obj = GetValueType(header.GetCell(i));
                            if (obj == null || obj.ToString() == string.Empty)
                            {
                                dt.Columns.Add(new DataColumn("Columns" + i.ToString()));
                            }
                            else
                                dt.Columns.Add(new DataColumn(obj.ToString()));
                            columns.Add(i);
                        }
                        //数据  
                        for (int i = sheet.FirstRowNum + 1; i <= sheet.LastRowNum; i++)
                        {
                            DataRow dr = dt.NewRow();
                            if (sheet.GetRow(i) == null)
                                continue;
                            bool hasValue = false;
                            foreach (int j in columns)
                            {
                                dr[j] = GetValueType(sheet.GetRow(i).GetCell(j));
                                if (dr[j] != null && dr[j].ToString() != string.Empty)
                                {
                                    hasValue = true;
                                }
                            }
                            if (hasValue)
                            {
                                dt.Rows.Add(dr);
                            }
                        }

                        //将datatable转成string;
                        string json = Newtonsoft.Json.JsonConvert.SerializeObject(dt);
                        jsonAll.Append(json);

                    }
                }
            }

            return jsonAll.ToString();
        }

        private object GetValueType(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank: //BLANK:  
                    return null;
                case CellType.Boolean: //BOOLEAN:  
                    return cell.BooleanCellValue;
                case CellType.Numeric: //NUMERIC:  
                    return cell.NumericCellValue;
                case CellType.String: //STRING:  
                    return cell.StringCellValue;
                case CellType.Error: //ERROR:  
                    return cell.ErrorCellValue;
                case CellType.Formula: //FORMULA:  
                default:
                    return "=" + cell.CellFormula;

            }
        }
    }
}
