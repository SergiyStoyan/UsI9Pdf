//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
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
        static public string OriginPdf = Regex.Replace(Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().GetName(false).CodeBase) + "\\i-9.pdf", @"file:\\", "", RegexOptions.IgnoreCase);

        static public System.Drawing.Size SignatureMaxSize = new System.Drawing.Size(200, 40);

        static public string Create(string output_pdf, System.Drawing.Image employee_signature, System.Drawing.Image preparer_signature, System.Drawing.Image employer_signature, string user_password, string owner_password)
        {
            PdfReader.unethicalreading = true;

            PdfReader pr;
            string f = OriginPdf;
            //Stream s = new MemoryStream();

            pr = new PdfReader(f);
            f = Path.GetDirectoryName(output_pdf) + "\\out1.pdf";
            Document d = new Document(pr.GetPageSizeWithRotation(7));
            PdfCopy pcp = new PdfCopy(d, new FileStream(f, FileMode.Create));
            d.Open();
            pcp.AddPage(pcp.GetImportedPage(pr, 7));
            pcp.AddPage(pcp.GetImportedPage(pr, 8));
            d.Close();
            pr.Close();

            pr = new PdfReader(f);
            f = Path.GetDirectoryName(output_pdf) + "\\out2.pdf";
            PdfStamper ps = new PdfStamper(pr, new FileStream(f, FileMode.Create));
            var pcb = ps.GetOverContent(1);
            add_image(pcb, employee_signature, new System.Drawing.Point(140, 213));
            add_image(pcb, preparer_signature, new System.Drawing.Point(180, 120));
            pcb = ps.GetOverContent(2);
            add_image(pcb, employer_signature, new System.Drawing.Point(60, 256));
            add_image(pcb, employer_signature, new System.Drawing.Point(65, 30));
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

        static void add_image(PdfContentByte pcb, System.Drawing.Image image, System.Drawing.Point point)
        {
            image = ImageRoutines.GetCroppedByColor(image, System.Drawing.Color.Transparent);
            Image i = Image.GetInstance(image, (BaseColor)null);
            var ratio = Math.Min((float)SignatureMaxSize.Width / image.Width, (float)SignatureMaxSize.Height / image.Height);
            i.ScalePercent(ratio * 100);
            i.SetAbsolutePosition(point.X, point.Y);
            pcb.AddImage(i);
        }
    }
}