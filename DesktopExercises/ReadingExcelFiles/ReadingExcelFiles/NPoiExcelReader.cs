using DocumentFormat.OpenXml.Drawing.Charts;
using DocumentFormat.OpenXml.Spreadsheet;
using NPOI.HPSF;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CellType = NPOI.SS.UserModel.CellType;
using DataTable = System.Data.DataTable;

namespace ReadingExcelFiles
{
    public class NPoiExcelReader : ExcelReaderStrategy
    {
        public const String COL_ROW_NUM = "numeroLinha";
        private int? columnCount = 50;
        public DataTable ReadFile(string fileName)
        {
            HSSFWorkbook hssfwb;

            using (FileStream file = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
            {
                hssfwb = new HSSFWorkbook(file);
            }

            DataTable tableToFill = new DataTable();
            var sheet = hssfwb.GetSheetAt(0);
            tableToFill.TableName = sheet.SheetName;
            int totalRows = sheet.LastRowNum;

            //    criarColunas(tableToFill, sheet.GetRow(0),contemHeader);
            tableToFill.Columns.Add(COL_ROW_NUM);

            int indiceInicial = 1;

            for (int iRow = indiceInicial; iRow <= totalRows; iRow++)
            {
                IRow row = sheet.GetRow(iRow);

                if (row != null)
                {
                    DataRow dataRow = tableToFill.NewRow();

                    dataRow[COL_ROW_NUM] = iRow + 1;

                    int totalColumnsSheet = row.LastCellNum;

                    if (columnCount != null && columnCount.Value < totalColumnsSheet)
                    {
                        totalColumnsSheet = columnCount.Value;
                    }

                    for (int iColumn = 0; iColumn < totalColumnsSheet; iColumn++)
                    {
                        ICell cell = row.GetCell(iColumn);
                        object value = getCellValue(cell);
                        criarColunaSeNaoExiste(tableToFill, iColumn);
                        dataRow[iColumn + 1] = value ?? DBNull.Value;
                    }

                    tableToFill.Rows.Add(dataRow);
                }
            }
            return tableToFill;
        }
        object getCellValue(ICell cell)
        {
            if (cell == null)
                return null;
            switch (cell.CellType)
            {
                case CellType.Blank:
                    return cell.StringCellValue;
                case CellType.Boolean:
                    return cell.BooleanCellValue;
                case CellType.Error:
                    return cell.ErrorCellValue;
                case CellType.Formula:
                    return null;
                case CellType.Numeric:
                    {
                        if (DateUtil.IsCellDateFormatted(cell))
                            return DateUtil.GetJavaDate(cell.NumericCellValue);

                        return cell.NumericCellValue;
                    }
                case CellType.String:
                    return cell.StringCellValue;
                case CellType.Unknown:
                    return cell.StringCellValue;
                default:
                    return null;
            }
        }
        void criarColunaSeNaoExiste(DataTable table, int indice)
        {
            String nomeColuna = "COL" + (indice + 1);

            if (!table.Columns.Contains(nomeColuna))
            {
                table.Columns.Add(nomeColuna);
            }
        }
    }
}
