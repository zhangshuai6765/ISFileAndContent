using NPOI.XWPF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISFileAndContent.NPOIUtil
{
    public class WordUtil: OfficeUtil
    {
        public override string Read(string filePath)
        {
            StringBuilder wordAll = new StringBuilder();
            Stream stream = File.OpenRead(filePath);
            XWPFDocument doc = new XWPFDocument(stream);
            foreach (var para in doc.Paragraphs)
            {
                string text = para.ParagraphText; //获得文本
                if (text.Trim() != "")
                    wordAll.Append(text.Trim());
            }
            return wordAll.ToString();
        }
    }
}
