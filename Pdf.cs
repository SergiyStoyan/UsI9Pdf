//********************************************************************************************
//Author: Sergey Stoyan
//        sergey.stoyan@gmail.com
//        http://www.cliversoft.com
//********************************************************************************************
using System;
using System.Data.Linq;
using System.Collections.Generic;
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
        
        public static Dictionary<string, string> GetEmptyFields2Value()
        {
            return new Dictionary<string, string> {
                {"form1[0].#subform[6].AlienNumber[0]", ""},
                {"form1[0].#subform[6].TelephoneNumber[0]", ""},
                {"form1[0].#subform[6].MiddleInitial[0]", ""},
                {"form1[0].#subform[6].FamilyName[0]", ""},
                {"form1[0].#subform[6].GivenName[0]", ""},
                {"form1[0].#subform[6].OtherNamesUsed[0]", ""},
                {"form1[0].#subform[6].StreetNumberName[0]", ""},
                {"form1[0].#subform[6].AptNumber[0]", ""},
                {"form1[0].#subform[6].CityOrTown[0]", ""},
                {"form1[0].#subform[6].State[0]", ""},
                {"form1[0].#subform[6].DateOfBirth[0]", ""},
                //{"form1[0].#subform[6].EmployeeSignature[0]", ""},
                {"form1[0].#subform[6].DateofSignaturebyEmployee[0]", ""},
                {"form1[0].#subform[6].DateofSignature[0]", ""},
                //{"form1[0].#subform[6].Signature[0]", ""},
                {"form1[0].#subform[6].StreetNumberName[1]", ""},
                {"form1[0].#subform[6].CityOrTown[1]", ""},
                {"form1[0].#subform[6].LastName[0]", ""},
                {"form1[0].#subform[6].FirstName[0]", ""},
                {"form1[0].#subform[6].Checkbox1a[0]", ""},
                {"form1[0].#subform[6].Checkbox1b[0]", ""},
                {"form1[0].#subform[6].Checkbox1c[0]", ""},
                {"form1[0].#subform[6].Checkbox1d[0]", ""},
                {"form1[0].#subform[6].AlienNumber[1]", ""},
                {"form1[0].#subform[6].I94Number[0]", ""},
                {"form1[0].#subform[6].PassportNumber[0]", ""},
                {"form1[0].#subform[6].email[0]", ""},
                {"form1[0].#subform[6].SocialSecurityNumber1[0]", ""},
                {"form1[0].#subform[6].SocialSecurityNumber2[0]", ""},
                {"form1[0].#subform[6].SocialSecurityNumber3[0]", ""},
                {"form1[0].#subform[6].ExpirationDate[0]", ""},
                {"form1[0].#subform[6].CountryOfIssuance[0]", ""},
                {"form1[0].#subform[6].ZipCode[0]", ""},
                {"form1[0].#subform[6].ZipCode[1]", ""},
                {"form1[0].#subform[6].State_Preparer[0]", ""},
                //{"form1[0].#subform[7].Section3_Signature[0]", ""},
                {"form1[0].#subform[7].EmployeeName[0]", ""},
                {"form1[0].#subform[7].FirstDayOfWork[0]", ""},
                {"form1[0].#subform[7].DateofSignature[1]", ""},
                {"form1[0].#subform[7].StreetNumberName[2]", ""},
                {"form1[0].#subform[7].State[1]", ""},
                {"form1[0].#subform[7].CityOrTown[2]", ""},
                {"form1[0].#subform[7].FamilyName[1]", ""},
                {"form1[0].#subform[7].GivenName[1]", ""},
                {"form1[0].#subform[7].Title[0]", ""},
                {"form1[0].#subform[7].DateofRehire[0]", ""},
                {"form1[0].#subform[7].DocumentTitle[0]", ""},
                {"form1[0].#subform[7].DocumentNumber[0]", ""},
                {"form1[0].#subform[7].GivenName[2]", ""},
                {"form1[0].#subform[7].FamilyName[2]", ""},
                {"form1[0].#subform[7].MiddleInitial[1]", ""},
                {"form1[0].#subform[7].ListC_IssuingAuthority[0]", ""},
                {"form1[0].#subform[7].ListC_DocumentNumber1[0]", ""},
                {"form1[0].#subform[7].ListC_DocumentTitle[0]", ""},
                {"form1[0].#subform[7].ListB_DocumentTitle[0]", ""},
                {"form1[0].#subform[7].ListBDocumentNumber1[0]", ""},
                {"form1[0].#subform[7].ListB_IssuingAuthority[0]", ""},
                {"form1[0].#subform[7].ListB_IssuingAuthority[1]", ""},
                {"form1[0].#subform[7].ListADocumentNumber1[0]", ""},
                {"form1[0].#subform[7].ListADocumentNumber1[1]", ""},
                {"form1[0].#subform[7].ListA_DocumentTitle[0]", ""},
                {"form1[0].#subform[7].ListC_ExpirationDate[0]", ""},
                {"form1[0].#subform[7].ListBExpirationDate[0]", ""},
                {"form1[0].#subform[7].ExpirationDate[1]", ""},
                {"form1[0].#subform[7].ListA_DocumentTitle[1]", ""},
                {"form1[0].#subform[7].ListA_DocumentTitle[2]", ""},
                {"form1[0].#subform[7].ListADocumentNumber1[2]", ""},
                {"form1[0].#subform[7].ListADocumentNumber1[3]", ""},
                {"form1[0].#subform[7].ListADocumentNumber1[4]", ""},
                {"form1[0].#subform[7].ListAExpirationDate_3[0]", ""},
                {"form1[0].#subform[7].ListAExpirationDate_2[0]", ""},
                {"form1[0].#subform[7].ListAExpirationDate_1[0]", ""},
                {"form1[0].#subform[7].DateofSignature[2]", ""},
                {"form1[0].#subform[7].EmployerBusinessOfOrgName[0]", ""},
                {"form1[0].#subform[7].EmployerOrAuthRepName[0]", ""},
                {"form1[0].#subform[7].ZipCode[2]", ""},
                //{"form1[0].#subform[7].Signature[1]", ""}
            };
        }

        static public string Create(string output_pdf, Dictionary<string, string> fields2value, System.Drawing.Image employee_signature, System.Drawing.Image preparer_signature, System.Drawing.Image employer_signature, string user_password, string owner_password)
        {
            PdfReader.unethicalreading = true;

            PdfReader pr;

            pr = new PdfReader(OriginPdf);
            MemoryStream ms = new MemoryStream();
            pr.RemoveUsageRights();
            pr.SelectPages("7,8");
            PdfStamper ps = new PdfStamper(pr, ms);

            //String[] values = ps.AcroFields.GetAppearanceStates("form1[0].#subform[6].Checkbox1a[0]");
            //string fs = "";
            //foreach (KeyValuePair<string, AcroFields.Item> kvp in ps.AcroFields.Fields)
            //    //fs += "\n{\"" + kvp.Key + "\", \"\"},";
            //    fs += "\n{\"\", \"" + kvp.Key + "\"},";

            foreach (KeyValuePair<string, string>kvp in fields2value)
                set_field(ps.AcroFields, kvp.Key, kvp.Value);
            ps.FormFlattening = true;

            var pcb = ps.GetOverContent(1);
            add_image(pcb, employee_signature, new System.Drawing.Point(140, 213));
            add_image(pcb, preparer_signature, new System.Drawing.Point(180, 120));
            pcb = ps.GetOverContent(2);
            add_image(pcb, employer_signature, new System.Drawing.Point(60, 256));
            add_image(pcb, employer_signature, new System.Drawing.Point(65, 30));
            ps.Close();
            pr.Close();
            
            pr = new PdfReader(new MemoryStream(ms.GetBuffer()));
            using (Stream output = new FileStream(output_pdf, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                PdfEncryptor.Encrypt(pr, output, true, user_password, owner_password, PdfWriter.ALLOW_SCREENREADERS);
            }
            pr.Close();
            return output_pdf;
        }

        static void set_field(AcroFields form, string field_key, string value)
        {
            switch (form.GetFieldType(field_key))
            {
                case AcroFields.FIELD_TYPE_CHECKBOX:
                case AcroFields.FIELD_TYPE_RADIOBUTTON:
                    //bool v;
                    //if (bool.TryParse(value, out v))
                    //    value = !v ? "false" : "true";
                    //else
                    //{
                    //    int i;
                    //    if (int.TryParse(value, out i))
                    //        value = i == 0 ? "false" : "true";
                    //    else
                    //        value = string.IsNullOrEmpty(value) ? "false" : "true";
                    //}
                    //form.SetField(field_key, value);
                    //break;
                case AcroFields.FIELD_TYPE_COMBO:
                case AcroFields.FIELD_TYPE_LIST:
                case AcroFields.FIELD_TYPE_NONE:
                case AcroFields.FIELD_TYPE_PUSHBUTTON:
                case AcroFields.FIELD_TYPE_SIGNATURE:
                case AcroFields.FIELD_TYPE_TEXT:
                    form.SetField(field_key, value);
                    break;
                default:
                    throw new Exception("Unknown option: " + form.GetFieldType(field_key));
            }
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