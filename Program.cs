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
                fs2v["form1[0].#subform[6].AlienNumber[0]"] = "1";
                fs2v["form1[0].#subform[6].TelephoneNumber[0]"] = "2";
                fs2v["form1[0].#subform[6].MiddleInitial[0]"] = "3";
                fs2v["form1[0].#subform[6].FamilyName[0]"] = "4";
                fs2v["form1[0].#subform[6].GivenName[0]"] = "5";
                fs2v["form1[0].#subform[6].OtherNamesUsed[0]"] = "6";
                fs2v["form1[0].#subform[6].StreetNumberName[0]"] = "7";
                fs2v["form1[0].#subform[6].AptNumber[0]"] = "8";
                fs2v["form1[0].#subform[6].CityOrTown[0]"] = "9";
                fs2v["form1[0].#subform[6].State[0]"] = "10";
                fs2v["form1[0].#subform[6].DateOfBirth[0]"] = "1/21/2020";
                fs2v["form1[0].#subform[6].DateofSignaturebyEmployee[0]"] = "2/22/2020";
                fs2v["form1[0].#subform[6].DateofSignature[0]"] = "3/23/2020";
                fs2v["form1[0].#subform[6].StreetNumberName[1]"] = "11";
                fs2v["form1[0].#subform[6].CityOrTown[1]"] = "12";
                fs2v["form1[0].#subform[6].LastName[0]"] = "13";
                fs2v["form1[0].#subform[6].FirstName[0]"] = "14";
                fs2v["form1[0].#subform[6].Checkbox1a[0]"] = "Y";
                fs2v["form1[0].#subform[6].Checkbox1b[0]"] = "Y";
                fs2v["form1[0].#subform[6].Checkbox1c[0]"] = "Y";
                fs2v["form1[0].#subform[6].Checkbox1d[0]"] = "Y";
                fs2v["form1[0].#subform[6].AlienNumber[1]"] = "19";
                fs2v["form1[0].#subform[6].I94Number[0]"] = "20";
                fs2v["form1[0].#subform[6].PassportNumber[0]"] = "21";
                fs2v["form1[0].#subform[6].email[0]"] = "22";
                fs2v["form1[0].#subform[6].SocialSecurityNumber1[0]"] = "231";
                fs2v["form1[0].#subform[6].SocialSecurityNumber2[0]"] = "24";
                fs2v["form1[0].#subform[6].SocialSecurityNumber3[0]"] = "2567";
                fs2v["form1[0].#subform[6].ExpirationDate[0]"] = "4/23/2021";
                fs2v["form1[0].#subform[6].CountryOfIssuance[0]"] = "26";
                fs2v["form1[0].#subform[6].ZipCode[0]"] = "27";
                fs2v["form1[0].#subform[6].ZipCode[1]"] = "28";
                fs2v["form1[0].#subform[6].State_Preparer[0]"] = "29";
                fs2v["form1[0].#subform[7].EmployeeName[0]"] = "30";
                fs2v["form1[0].#subform[7].FirstDayOfWork[0]"] = "5/25/2021";
                fs2v["form1[0].#subform[7].DateofSignature[1]"] = "6/23/2022";
                fs2v["form1[0].#subform[7].StreetNumberName[2]"] = "32";
                fs2v["form1[0].#subform[7].State[1]"] = "33";
                fs2v["form1[0].#subform[7].CityOrTown[2]"] = "33";
                fs2v["form1[0].#subform[7].FamilyName[1]"] = "34";
                fs2v["form1[0].#subform[7].GivenName[1]"] = "35";
                fs2v["form1[0].#subform[7].Title[0]"] = "36";
                fs2v["form1[0].#subform[7].DateofRehire[0]"] = "7/23/2022";
                fs2v["form1[0].#subform[7].DocumentTitle[0]"] = "37";
                fs2v["form1[0].#subform[7].DocumentNumber[0]"] = "38";
                fs2v["form1[0].#subform[7].GivenName[2]"] = "39";
                fs2v["form1[0].#subform[7].FamilyName[2]"] = "40";
                fs2v["form1[0].#subform[7].MiddleInitial[1]"] = "41";
                fs2v["form1[0].#subform[7].ListC_IssuingAuthority[0]"] = "42";
                fs2v["form1[0].#subform[7].ListC_DocumentNumber1[0]"] = "43";
                fs2v["form1[0].#subform[7].ListC_DocumentTitle[0]"] = "44";
                fs2v["form1[0].#subform[7].ListB_DocumentTitle[0]"] = "45";
                fs2v["form1[0].#subform[7].ListBDocumentNumber1[0]"] = "46";
                fs2v["form1[0].#subform[7].ListB_IssuingAuthority[0]"] = "47";
                fs2v["form1[0].#subform[7].ListB_IssuingAuthority[1]"] = "48";
                fs2v["form1[0].#subform[7].ListADocumentNumber1[0]"] = "49";
                fs2v["form1[0].#subform[7].ListADocumentNumber1[1]"] = "50";
                fs2v["form1[0].#subform[7].ListA_DocumentTitle[0]"] = "51";
                fs2v["form1[0].#subform[7].ListC_ExpirationDate[0]"] = "8/23/2023";
                fs2v["form1[0].#subform[7].ListBExpirationDate[0]"] = "9/23/2024";
                fs2v["form1[0].#subform[7].ExpirationDate[1]"] = "10/23/2025";
                fs2v["form1[0].#subform[7].ListA_DocumentTitle[1]"] = "52";
                fs2v["form1[0].#subform[7].ListA_DocumentTitle[2]"] = "53";
                fs2v["form1[0].#subform[7].ListADocumentNumber1[2]"] = "54";
                fs2v["form1[0].#subform[7].ListADocumentNumber1[3]"] = "55";
                fs2v["form1[0].#subform[7].ListADocumentNumber1[4]"] = "56";
                fs2v["form1[0].#subform[7].ListAExpirationDate_3[0]"] = "11/23/2021";
                fs2v["form1[0].#subform[7].ListAExpirationDate_2[0]"] = "12/23/2021";
                fs2v["form1[0].#subform[7].ListAExpirationDate_1[0]"] = "12/23/2022";
                fs2v["form1[0].#subform[7].DateofSignature[2]"] = "12/23/2023";
                fs2v["form1[0].#subform[7].EmployerBusinessOfOrgName[0]"] = "57";
                fs2v["form1[0].#subform[7].EmployerOrAuthRepName[0]"] = "58";
                fs2v["form1[0].#subform[7].ZipCode[2]"] = "59";
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