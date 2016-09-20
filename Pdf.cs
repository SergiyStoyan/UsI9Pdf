using System;
using System.Diagnostics;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text.RegularExpressions;

namespace UsI9Pdf
{
    class Pdf
    {
        //for web context
        //static public string OriginPdf = Path.GetDirectoryName(System.Web.Compilation.BuildManager.GetGlobalAsaxType().BaseType.Assembly.GetName(false).CodeBase) + "\\i-9.pdf";

        //for desktop context
        static public string OriginPdf = Regex.Replace( Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().GetName(false).CodeBase) + "\\i-9.pdf", @"file:\\", "", RegexOptions.IgnoreCase);

        static public string Create(string output_pdf, System.Drawing.Image employee_signature, System.Drawing.Image preparer_signature, System.Drawing.Image employer_signature, string user_password, string owner_password)
        {
            PdfReader.unethicalreading = true;

            string f = Path.GetDirectoryName(output_pdf) + "\\out1.pdf";
            PdfReader pr = new PdfReader(OriginPdf);
            Document d = new Document(pr.GetPageSizeWithRotation(7));
            PdfCopy pcp = new PdfCopy(d, new System.IO.FileStream(f, System.IO.FileMode.Create));
            d.Open();
            pcp.AddPage(pcp.GetImportedPage(pr, 7));
            pcp.AddPage(pcp.GetImportedPage(pr, 8));
            d.Close();
            pr.Close();

            pr = new PdfReader(f);
            f = Path.GetDirectoryName(output_pdf) + "\\out2.pdf";
            PdfStamper ps = new PdfStamper(pr, new FileStream(f, FileMode.Create));
            var pcb = ps.GetOverContent(1);
            Image i = Image.GetInstance(employee_signature, (BaseColor)null);
            i.SetAbsolutePosition(100, 100);
            pcb.AddImage(i);
            i = Image.GetInstance(preparer_signature, (BaseColor)null);
            i.SetAbsolutePosition(100, 300);
            pcb.AddImage(i);
            pcb = ps.GetOverContent(2);
            i = Image.GetInstance(employer_signature, (BaseColor)null);
            i.SetAbsolutePosition(100, 100);
            pcb.AddImage(i);
            i.SetAbsolutePosition(100, 300);
            pcb.AddImage(i);
            ps.Close();
            pr.Close();

            pr = new PdfReader(f);
            f = output_pdf;
            using (Stream output = new FileStream(f, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfEncryptor.Encrypt(pr, output, true, user_password, owner_password, PdfWriter.ALLOW_SCREENREADERS);
                pr.Close();
            }
            return f;
        }
    }
}