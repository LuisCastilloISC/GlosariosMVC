
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListedMnemonicSummaries
{
    public abstract class PDFFileManager
    {
        public static void Generate(string strTopic,string strLanguage)
        {
            string strTXTDirectory = "";
            string strPDFDirectory = "";
            switch (strLanguage)
            {
                case "Español":
                    if (System.IO.File.Exists(@"Resúmenes Mnemotécnicos Listados\" + strTopic + ".txt"))
                    {
                        strTXTDirectory = @"Resúmenes Mnemotécnicos Listados\" + strTopic + ".txt";
                        strPDFDirectory = @"Resúmenes Mnemotécnicos Listados\" + strTopic + ".pdf";
                    }
                    else
                        throw new Exception(strTopic + ".txt no existe.");
                    break;
                default:
                case "English":
                    if (System.IO.File.Exists(@"Listed Mnemonic Summaries\" + strTopic + ".txt"))
                    {
                        strTXTDirectory = @"Listed Mnemonic Summaries\" + strTopic + ".txt";
                        strPDFDirectory = @"Listed Mnemonic Summaries\" + strTopic + ".pdf";
                    }
                    else
                        throw new Exception(strTopic + ".txt doesn't exist.");
                    break;
            }

            using (iTextSharp.text.Document aDocument = new iTextSharp.text.Document())
            {
                iTextSharp.text.pdf.PdfWriter.GetInstance(aDocument, new System.IO.FileStream(strPDFDirectory, System.IO.FileMode.OpenOrCreate, System.IO.FileAccess.ReadWrite));
                aDocument.Open();
                aDocument.Add(new iTextSharp.text.Paragraph(ListedTextFileManager.Read(strTXTDirectory)));
            }
        }
    }
}
