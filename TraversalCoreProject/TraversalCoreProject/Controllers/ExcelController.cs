﻿using ClosedXML.Excel;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using TraversalCoreProject.Models;

namespace TraversalCoreProject.Controllers
{
    public class ExcelController : Controller
    {
        public IActionResult Index()
        {
           
            return View();

        }
        public List<DestinationModel> DestiantionList()
        {
            List<DestinationModel> destinationModels = new List<DestinationModel>();
            using(var c=new Context())
            {

                destinationModels=c.Destinations.Select(x=> new DestinationModel
                {
                    City = x.City,  
                    DayNight = x.DayNight,
                    Price = x.Price,
                    Capacity=x.Capacity
                }).ToList();
           
            }
            return destinationModels;
        }
        public IActionResult StaticExcelReport()
        {
            ExcelPackage excel = new ExcelPackage();
            var workSheet = excel.Workbook.Worksheets.Add("Sayfa1");
            workSheet.Cells[1, 1].Value = "Rota";
            workSheet.Cells[1, 2].Value = "Rehber";
            workSheet.Cells[1, 3].Value = "Kontenjan";

            workSheet.Cells[2, 1].Value = "Almanya Hannover Turu";
            workSheet.Cells[1, 2].Value = "Sinan Çıvak";
            workSheet.Cells[1, 3].Value = "50";

            workSheet.Cells[2, 1].Value = "Hollanda  Turu";
            workSheet.Cells[1, 2].Value = "Zeynep Öztürk";
            workSheet.Cells[1, 3].Value = "30";

            var bytes = excel.GetAsByteArray();
            return File(bytes, "application/vnd.openxmlformants-officedocument.spreadsheetml.sheet", "dosya1.xlsx");

        }

        public IActionResult DestinationExcelReport()
        {
            using(var worBook=new XLWorkbook())
            {
                var workSheet = worBook.Worksheets.Add("Tur Listesi");
                workSheet.Cell(1, 1).Value = "Şehir";
                workSheet.Cell(1, 2).Value = "Konaklama Süresi";
                workSheet.Cell(1, 3).Value = "Fiyat";
                workSheet.Cell(1, 4).Value = "Kapasite";

                int rowCount = 2;

                foreach (var item in DestiantionList())
                {
                    workSheet.Cell(rowCount, 1).Value=item.City;
                    workSheet.Cell(rowCount, 2).Value=item.DayNight;
                    workSheet.Cell(rowCount, 3).Value=item.Price;
                    workSheet.Cell(rowCount, 4).Value=item.Capacity;
                    rowCount++;
                    

                }
                using(var stream=new MemoryStream())
                {
                    worBook.SaveAs(stream);
                    var content=stream.ToArray();
                    return File(content, "application/vnd.openxmlformants-officedocument.spreadsheetml.sheet", "YeniListe.xlsx");
                }


            }

        }
    }
}
