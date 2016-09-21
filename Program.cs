//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Diagnostics;
using System.IO;
using System.Drawing;

namespace UsI9Pdf
{
    class Program
    {
        static void Main()
        {
            try
            {
                string[] ps = Environment.GetCommandLineArgs();
                if (ps.Length < 6)
                {
                    Console.WriteLine("USAGE: #<application.exe> <employee_signature> <preparer_signature> <employer_signature> <user_password> <owner_password>");
                    Console.WriteLine("Press any key to exit...");
                    Console.ReadKey();
                    return;
                }
                System.Collections.Generic.Dictionary<string, string> fs2v = Pdf.GetEmptyFields2Value();
                fs2v["form1[0].#subform[6].AlienNumber[0]"] = "TEST";
                fs2v["form1[0].#subform[6].Checkbox1a[0]"] = "Y";
                string f = Pdf.Create(Directory.GetCurrentDirectory() + "\\out.pdf", fs2v, Image.FromFile(ps[1]), Image.FromFile(ps[2]), Image.FromFile(ps[3]), ps[4], ps[5]);
                Console.WriteLine("Created pdf: " + f);
                Process.Start(f);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                for (; e.InnerException != null; e = e.InnerException)
                    Console.WriteLine("<= " + e.Message);
                Console.WriteLine("Press any key to exit...");
                Console.ReadKey();
                return;
            }
        }
    }
}