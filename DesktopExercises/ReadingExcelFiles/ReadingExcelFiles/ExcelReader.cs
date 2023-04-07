using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadingExcelFiles
{
    public class ExcelReader
    {
        private readonly string filePath;
        ExcelReaderStrategy excelReaderStrategy;
        public ExcelReader(string filePath)
        {
            if (filePath.EndsWith("xls"))
                excelReaderStrategy = new NPoiExcelReader();
            else
                excelReaderStrategy = new XmlExcelReader();
            this.filePath = filePath;
        }
        public DataTable ReadFile()
        {
            return excelReaderStrategy.ReadFile(this.filePath);
        }

    }
}
