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
        private AtGymReport report;
        
        public AtGymPDFReport(string filename, AtGymReport report)
        {
            //Prototype! Ignore lambda expression, pass null
            PDFDocument = new Document();
            writer = PdfWriter.GetInstance(PDFDocument, 
                new FileStream(filename, FileMode.Create));
            this.report = report;

        }

        public void GenerateReport()
        {
            PDFDocument.Open();

            PDFDocument.Add(new Paragraph("Ingresos por membresías: " + report.MembershipIncome));
            PDFDocument.Add(new Paragraph("Ingresos por calentamientos: " + report.WarmupIncome));
            PDFDocument.Add(new Paragraph(""));
            PDFDocument.Add(new Paragraph("Ingresos por Ventas: " + report.SalesIncome));
            PDFDocument.Add(new Paragraph("Pagos a empleados: " + report.EmployeesPayment));
            PDFDocument.Add(new Paragraph("Alquiler del Local: " + report.Rental));
            PDFDocument.Add(new Paragraph("Pago de electricidad: " + report.ElectricityCosts));
            PDFDocument.Add(new Paragraph("Gastos de Mantenimiento: " + report.Mantainment));
            PDFDocument.Add(new Paragraph("Compra de mercancía: " + report.Merchandise));
            PDFDocument.Add(new Paragraph("BALANCE NETO: " + report.NetBalance));

            PDFDocument.Close();
        }
    }
}
