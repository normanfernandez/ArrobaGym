using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

namespace ArrobaGym.Utils
{
    public class AtGymPDFReport
    {
        private Document PDFDocument;
        private PdfWriter writer;
        
        public AtGymPDFReport(string filename, Func<DateTime, bool> date_exp)
        {
            //Prototype! Ignore lambda expression, pass null
            PDFDocument = new Document();
            writer = PdfWriter.GetInstance(PDFDocument, 
                new FileStream(filename, FileMode.Create));

        }

        public void GenerateReport()
        {
            PDFDocument.Open();

            PDFDocument.Add(new Paragraph("Ingresos por membresías: "));
            PDFDocument.Add(new Paragraph("Ingresos por calentamientos: "));
            PDFDocument.Add(new Paragraph(""));
            PDFDocument.Add(new Paragraph("Ingresos por Ventas: "));
            PDFDocument.Add(new Paragraph("Pagos a empleados: "));
            PDFDocument.Add(new Paragraph("Alquiler del Local: "));
            PDFDocument.Add(new Paragraph("Pago de electricidad: "));
            PDFDocument.Add(new Paragraph("Gastos de Mantenimiento: "));
            PDFDocument.Add(new Paragraph("Compra de mercancía: "));
            PDFDocument.Add(new Paragraph("BALANCE NETO: "));

            PDFDocument.Close();
        }
    }
}
