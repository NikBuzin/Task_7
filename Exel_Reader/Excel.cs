using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Microsoft.Office.Interop.Excel;

namespace Exel_Reader
{
    public class Excel
    {
        public List<Candle> ReadFile(string fileName)
        {
            List<Candle> result = new List<Candle>();
            using (var package = new ExcelPackage(new FileInfo(fileName)))
            {
                
                var worksheet = package.Workbook.Worksheets[1];
                for (int i = worksheet.Dimension.Start.Row + 1; i <= worksheet.Dimension.End.Row; i++)
                {
                    var dateValue = worksheet.Cells[i, 3].Value;
                    var timeValue = worksheet.Cells[i, 4].Value;
                    var openValue = Convert.ToDecimal((worksheet.Cells[i, 5]).Value); /// 1e5m;
                    var highValue = Convert.ToDecimal((worksheet.Cells[i, 6]).Value); /// 1e5m;
                    var lowValue = Convert.ToDecimal((worksheet.Cells[i, 7]).Value); /// 1e5m;
                    var closeValue = Convert.ToDecimal((worksheet.Cells[i, 8]).Value); /// 1e5m;
                    var date = DateTime.ParseExact($"{dateValue} {timeValue}", "yyyyMMdd HHmmss", CultureInfo.InvariantCulture);
                    result.Add( new Candle(highValue, lowValue, openValue, closeValue, date));
                }
            }
            return result;
        }
    }
}
