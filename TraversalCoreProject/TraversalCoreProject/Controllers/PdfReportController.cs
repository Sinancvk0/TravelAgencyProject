
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace TraversalCoreProject.Controllers
{
    public class PdfReportController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult StaticPdfReport()
        {

            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya1.pdf");
            var stream = new FileStream(path, FileMode.Create);

            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document, stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Traversal Rezervasyon Pdf Raporu");

            document.Add(paragraph);
            document.Close();

            return File("/PdfReports/dosya1.pdf", "application/pdf", "dosya1.pdf");




        }

        public IActionResult StaticCustomerReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/PdfReports/" + "dosya2.pdf");

            using (var stream = new FileStream(path, FileMode.Create))
            {
                Document document = new Document(PageSize.A4);
                PdfWriter writer = PdfWriter.GetInstance(document, stream);
                document.Open();

                PdfPTable pdfPTable = new PdfPTable(3);

                pdfPTable.AddCell("Misafir Adı");
                pdfPTable.AddCell("Misafir Soyad");
                pdfPTable.AddCell("Misafir TC");

                pdfPTable.AddCell("Sinan");
                pdfPTable.AddCell("Çıvak");
                pdfPTable.AddCell("12313211313");

                pdfPTable.AddCell("Feyyaz");
                pdfPTable.AddCell("Çıvak");
                pdfPTable.AddCell("12313211313");

                pdfPTable.AddCell("Emre");
                pdfPTable.AddCell("Çıvak");
                pdfPTable.AddCell("12313211313");

                document.Add(pdfPTable);
                document.Close();
            }

            return File("/PdfReports/dosya2.pdf", "application/pdf", "dosya2.pdf");
        }

    }
}
