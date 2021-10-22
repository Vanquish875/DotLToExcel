using DotLToExcel.POCOS;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;

namespace DotLToExcel.Excel
{
    public class ExcelManager
    {
        public void WriteToExcel(IList<Station> stations, IList<Remote> remotes, IList<Connection> connections, IList<Analog> analogs,
            IList<Rate> rates, IList<Digital> status, IList<Multistate> multistates, IList<Message> messages, IList<CGLTemplateDef> cgls)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Station");
                excel.Workbook.Worksheets.Add("Remote");
                excel.Workbook.Worksheets.Add("Connection");
                excel.Workbook.Worksheets.Add("Analog");
                excel.Workbook.Worksheets.Add("Rate");
                excel.Workbook.Worksheets.Add("Digital");
                excel.Workbook.Worksheets.Add("Multistate");
                excel.Workbook.Worksheets.Add("Message");
                excel.Workbook.Worksheets.Add("CGLTemplates");

                // Target a worksheet
                var StationWorksheet = excel.Workbook.Worksheets["Station"];
                var RemoteWorksheet = excel.Workbook.Worksheets["Remote"];
                var ConnectionWorksheet = excel.Workbook.Worksheets["Connection"];
                var AnalogWorksheet = excel.Workbook.Worksheets["Analog"];
                var RateWorksheet = excel.Workbook.Worksheets["Rate"];
                var DigitalWorksheet = excel.Workbook.Worksheets["Digital"];
                var MultistateWorksheet = excel.Workbook.Worksheets["Multistate"];
                var MessageWorksheet = excel.Workbook.Worksheets["Message"];
                var CGLWorksheet = excel.Workbook.Worksheets["CGLTemplates"];

                // Popular header row data
                StationWorksheet.Cells.LoadFromCollection(stations, true);
                RemoteWorksheet.Cells.LoadFromCollection(remotes, true);
                ConnectionWorksheet.Cells.LoadFromCollection(connections, true);
                AnalogWorksheet.Cells.LoadFromCollection(analogs, true);
                RateWorksheet.Cells.LoadFromCollection(rates, true);
                DigitalWorksheet.Cells.LoadFromCollection(status, true);
                MultistateWorksheet.Cells.LoadFromCollection(multistates, true);
                MessageWorksheet.Cells.LoadFromCollection(messages, true);
                CGLWorksheet.Cells.LoadFromCollection(cgls, true);

                FileInfo excelFile = new FileInfo(@"E:\TCEnergy\DBMigration.xlsx");
                excel.SaveAs(excelFile);
            }
        }
    }
}
