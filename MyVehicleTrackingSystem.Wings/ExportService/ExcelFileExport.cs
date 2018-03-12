using Domain.DTO;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI.WebControls;
using Domain.Driver;
using OfficeOpenXml.Drawing;
using System.Drawing;
using System.Web.Mvc;
using Domain.Trips;

namespace ExportService
{
    public class ExcelFileExport
    {
        public void ExportTripReportToExcel(ReportViewDto report, HttpResponseBase response)
        {
            string[] header;
            GridView GridView1 = new GridView();
            GridView1.DataSource = report.ReportList;

            GridView1.DataBind();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TranscendDriveReport");

            System.Drawing.Image logo = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/4.png"));
            System.Drawing.Image rhDaily = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/1.png"));
            System.Drawing.Image rhDriver = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/2.png"));

            var p1 = workSheet.Drawings.AddPicture("Logo", logo);
            p1.SetPosition(0, 0, 0, 0);
            p1.SetSize(100);

            header = new string[] { "Voucher Number", "Created By", "Updated By", "Created Date", "Updated Date", "Vehicle No", "Driver Name", "Guest Name", "Room Number", "Hotel", "Package", "Package Cost", "Add Km", "Waiting", "Amount", "Payment Type", "Payment Category", "Corporate Name", "Status" };
            var reportPic = workSheet.Drawings.AddPicture("Name", rhDaily);
            reportPic.SetPosition(0, 0, 4, 0);
            reportPic.SetSize(15);

            workSheet.Cells[6, 1].Value = "Generated From :" + report.ReportDto.StartDate + " To :" + report.ReportDto.EndDate;
            workSheet.Cells[7, 1].Value = "Created By :" + System.Web.HttpContext.Current.User.Identity.Name;
            workSheet.Cells[8, 1].Value = " Generated Date :" + report.CurrentDate.ToString("yyyy/MM/dd");
            workSheet.Cells[9, 1].Value = " Generated Time :" + report.CurrentDate.ToString("h:mm tt");

            if (report.ReportList.Count() != 0)
            {
                var totalCols = GridView1.Rows[0].Cells.Count;
                var totalRows = GridView1.Rows.Count;
                var headerRow = GridView1.HeaderRow;
                for (var i = 1; i <= header.Count(); i++)
                {
                    workSheet.Cells[12, i].Value = header[i - 1];
                    workSheet.Cells[12, i].Style.Font.Bold = true;
                }
                int x = 12;
                for (var j = 1; j <= totalRows; j++)
                {
                    for (var i = 1; i <= totalCols; i++)
                    {
                        var product = report.ReportList.ElementAt(j - 1);
                        workSheet.Cells[x + 1, i].Value = product.GetType().GetProperty(headerRow.Cells[i - 1].Text).GetValue(product, null);
                        workSheet.Cells[x + 1, i].AutoFitColumns();
                    }
                    x++;
                }
                workSheet.Column(4).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";
                workSheet.Column(5).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";
                workSheet.Cells[(x + 3), 1].Value = "Total Amount : " + report.ReportList.Sum(i => i.Amount);
            }
            else
            {

            }
            using (var memoryStream = new MemoryStream())
            {
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment;  filename=TranscendDrive_Trip_Report_" + CustomDataHelper.CurrentDateTimeSL.GetCurrentDate() + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(response.OutputStream);
                response.Flush();
                response.End();
            }
        }

        public void ExportDriverReportToExcel(ReportViewDto report, HttpResponseBase response)
        {
            string[] header;
            GridView GridView1 = new GridView();
            GridView1.DataSource = report.DriverReportList;

            GridView1.DataBind();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TranscendDriveReport");

            System.Drawing.Image logo = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/4.png"));
            System.Drawing.Image rhDriver = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/3.png"));

            var p1 = workSheet.Drawings.AddPicture("Logo", logo);
            p1.SetPosition(0, 0, 0, 0);
            p1.SetSize(100);
            header = new string[] { "Voucher Number", "Created By", "Updated By", "Created Date", "Updated Date", "Employee Number", "Driver Name","Vehicle Number", "Trip Name", "Hotel","Batta", "Amount"};
            var reportPic = workSheet.Drawings.AddPicture("Name", rhDriver);
            reportPic.SetPosition(0, 0, 4, 0);
            reportPic.SetSize(15);


            workSheet.Cells[6, 1].Value = "Generated From :" + report.ReportDto.StartDate + " To :" + report.ReportDto.EndDate;
            workSheet.Cells[7, 1].Value = "Created By :" + System.Web.HttpContext.Current.User.Identity.Name;
            workSheet.Cells[8, 1].Value = " Generated Date :" + report.CurrentDate.ToString("yyyy/MM/dd");
            workSheet.Cells[9, 1].Value = " Generated Time :" + report.CurrentDate.ToString("h:mm tt");

            if (report.DriverReportList.Count() != 0)
            {
                var totalCols = GridView1.Rows[0].Cells.Count;
                var totalRows = GridView1.Rows.Count;
                var headerRow = GridView1.HeaderRow;
                for (var i = 1; i <= header.Count(); i++)
                {
                    workSheet.Cells[12, i].Value = header[i - 1];
                    workSheet.Cells[12, i].Style.Font.Bold = true;
                }
                int x = 12;
                for (var j = 1; j <= totalRows; j++)
                {
                    for (var i = 1; i <= totalCols; i++)
                    {
                        var product = report.DriverReportList.ElementAt(j - 1);
                        workSheet.Cells[x + 1, i].Value = product.GetType().GetProperty(headerRow.Cells[i - 1].Text).GetValue(product, null);
                        workSheet.Cells[x + 1, i].AutoFitColumns();
                    }
                    x++;
                }
                workSheet.Column(4).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";
                workSheet.Column(5).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";

                workSheet.Cells[(x + 3), 1].Value = "Total Amount : " + report.DriverReportList.Sum(a => a.BataAmount);
            }
            else
            {

            }
            using (var memoryStream = new MemoryStream())
            {
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment;  filename=TranscendDrive_Driver_Report_" + CustomDataHelper.CurrentDateTimeSL.GetCurrentDate() + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(response.OutputStream);
                response.Flush();
                response.End();
            }
        }

        public void ExportVehicleReportToExcel(ReportViewDto report, HttpResponseBase response)
        {
            string[] header;
            GridView GridView1 = new GridView();
            GridView1.DataSource = report.VehicleReportList;
            GridView1.DataBind();
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("TranscendDriveReport");

            System.Drawing.Image logo = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/4.png"));
            System.Drawing.Image rhVehicle = System.Drawing.Image.FromFile(HttpContext.Current.Server.MapPath("~/Content/Images/2.png"));

            var p1 = workSheet.Drawings.AddPicture("Logo", logo);
            p1.SetPosition(0, 0, 0, 0);
            p1.SetSize(100);

            header = new string[] { "Voucher Number", "Created By", "Updated By", "Created Date", "Updated Date", "Driver Name", "Vehicle Reg No", "Vehicle Type", "Make", "Model", "Trip Name", "Meter Reading Start", "Meter Reading End", " Trip Mileage", "Trip Duration", "Remarks", "Amount", "Status" };
            var reportPic = workSheet.Drawings.AddPicture("Name", rhVehicle);
            reportPic.SetPosition(0, 0, 4, 0);
            reportPic.SetSize(15);


            workSheet.Cells[6, 1].Value = "Generated From :" + report.ReportDto.StartDate + " To :" + report.ReportDto.EndDate;
            workSheet.Cells[7, 1].Value = "Created By :" + System.Web.HttpContext.Current.User.Identity.Name;
            workSheet.Cells[8, 1].Value = " Generated Date :" + report.CurrentDate.ToString("yyyy/MM/dd");
            workSheet.Cells[9, 1].Value = " Generated Time :" + report.CurrentDate.ToString("h:mm tt");
            if (report.VehicleReportList.Count() != 0)
            {

                var totalCols = GridView1.Rows[0].Cells.Count;
                var totalRows = GridView1.Rows.Count;
                var headerRow = GridView1.HeaderRow;
                for (var i = 1; i <= header.Count(); i++)
                {
                    workSheet.Cells[12, i].Value = header[i - 1];
                    workSheet.Cells[12, i].Style.Font.Bold = true;
                }
                int x = 12;
                for (var j = 1; j <= totalRows; j++)
                {
                    for (var i = 1; i <= totalCols; i++)
                    {
                        var product = report.VehicleReportList.ElementAt(j - 1);
                        workSheet.Cells[x + 1, i].Value = product.GetType().GetProperty(headerRow.Cells[i - 1].Text).GetValue(product, null);
                        workSheet.Cells[x + 1, i].AutoFitColumns();
                    }
                    x++;
                }
                workSheet.Column(4).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";
                workSheet.Column(5).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";

               // workSheet.Column(15).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";
               // workSheet.Column(16).Style.Numberformat.Format = "yyyy-MM-dd HH:mm";

                workSheet.Cells[(x + 3), 1].Value = "Total Amount : " + report.VehicleReportList.Sum(i => i.Amount);

            }
            else
            {

            }

            using (var memoryStream = new MemoryStream())
            {
                response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                response.AddHeader("content-disposition", "attachment;  filename=TranscendDrive_Vehicle_Report_" + CustomDataHelper.CurrentDateTimeSL.GetCurrentDate() + ".xlsx");
                excel.SaveAs(memoryStream);
                memoryStream.WriteTo(response.OutputStream);
                response.Flush();
                response.End();
            }
        }
    }
}

