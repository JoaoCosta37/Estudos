using System;
using System.IO;

namespace ReadingExcelFiles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ExcelReader excelReader = new ExcelReader("C:\\Users\\Joaoc\\Desktop\\Teste.xls");
            ExcelReader excelReaderX = new ExcelReader("C:\\Users\\Joaoc\\Desktop\\Teste.xlsx");
            var result = excelReader.ReadFile();
            var resultX = excelReaderX.ReadFile();
        }
    }
}
