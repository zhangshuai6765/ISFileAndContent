using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.NPOIUtil
{
    public class PptUtil: OfficeUtil
    {
        public override string Read(string filePath)
        {
            return "";
            //PDDocument doc = PDDocument.load(file.FullName);

            //PDFTextStripper pdfStripper = newPDFTextStripper();

            //string text = pdfStripper.getText(doc);

            //StreamWriter swPdfChange = newStreamWriter(txtfile.FullName, false, Encoding.GetEncoding("gb2312"));

            //swPdfChange.Write(text);

            //swPdfChange.Close();
        }
    }
}
