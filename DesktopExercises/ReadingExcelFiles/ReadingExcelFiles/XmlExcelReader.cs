using ClosedXML.Excel;
using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.HPSF;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataTable = System.Data.DataTable;

namespace ReadingExcelFiles
{
    public class XmlExcelReader : ExcelReaderStrategy
    {
        public const String COL_ROW_NUM = "numeroLinha";
        object getCellValue(IXLWorksheet sheet, int row, int column)
        {
            var cellValue = sheet.Cell(row, column).Value;

            if (cellValue is String cellStr)
            {
                if (String.IsNullOrEmpty(cellStr))
                {
                    cellValue = null;
                }
            }

            return cellValue ?? DBNull.Value;
        }
        void criarColunas(DataTable table, IXLWorksheet sheet, bool contemHeader, int? columnCount)
        {
            int totalColumnsSheet = sheet.ColumnsUsed().Count();

            if (columnCount != null && columnCount.Value < totalColumnsSheet)
            {
                totalColumnsSheet = columnCount.Value;
            }

            table.Columns.Add(COL_ROW_NUM);

            for (int i = 1; i <= totalColumnsSheet; i++)
            {
                if (contemHeader)
                    table.Columns.Add((sheet.Cell(1, i).Value ?? DBNull.Value).ToString());
                else
                    table.Columns.Add("COL" + i);
            }


        }
        public DataTable ReadFile(string fileName)
        {

            var _workbook = new XLWorkbook(fileName);
            //tableToFill.TableName = sheet.Name;
            var sheet = _workbook.Worksheets.ElementAt(0);
            int totalColumnsSheet = sheet?.ColumnsUsed().Count() ?? 0;

            DataTable tableToFill = new DataTable();

            criarColunas(tableToFill, sheet, true, 50);

            int indiceInicial = 2;


            if (totalColumnsSheet == 0)
                return tableToFill;

            int totalRows = sheet.RowsUsed().Count();

            for (int row = indiceInicial; row <= totalRows; row++)
            {
                DataRow dr = tableToFill.NewRow();

                dr[COL_ROW_NUM] = row;

                for (int column = 1; column <= totalColumnsSheet; column++)
                {
                    dr[column] = getCellValue(sheet, row, column);
                }
                tableToFill.Rows.Add(dr);
            }

            return tableToFill;
        }
    }
}
