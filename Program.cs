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
                Console.WriteLine("Usage: <employee_signature> <preparer_signature> <employer_signature> <user_password> <owner_password>");
                string[] ps = Environment.GetCommandLineArgs();
                string f = Pdf.Create(Directory.GetCurrentDirectory() + "\\out.pdf", Image.FromFile(ps[0]), Image.FromFile(ps[1]), Image.FromFile(ps[2]), ps[3], ps[4]);
                Console.WriteLine("Created pdf: " + f);
                Process.Start(f);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR: " + e.Message);
                for (; e.InnerException != null; e = e.InnerException)
                    Console.WriteLine("<= " + e.Message);
            }
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}