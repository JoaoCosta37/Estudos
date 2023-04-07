using System.Data;

namespace ReadingExcelFiles
{
    public interface ExcelReaderStrategy
    {
        DataTable ReadFile(string fileName);
    }
}