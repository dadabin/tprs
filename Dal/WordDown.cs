using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Aspose.Words;
using Aspose.Words.Saving;

namespace Dal
{
    public class WordDown
    {

        /// <summary>
        /// word生成
        /// </summary>
        /// <param name="titleStr"></param>
        /// <param name="contentStr"></param>
        /// <param name="response"></param>
        public void  downLoadWord(String titleStr,String contentStr,HttpResponse response){
            try
            {
                Aspose.Words.Document doc = new Aspose.Words.Document();
                Aspose.Words.DocumentBuilder builder = new Aspose.Words.DocumentBuilder(doc);
                builder.Font.Size = 16;
                builder.Font.Bold = true;
                builder.CellFormat.Borders.LineStyle = LineStyle.Single;
                builder.Writeln("");
                builder.Font.Size = 14;
                builder.ParagraphFormat.Alignment = ParagraphAlignment.Center;
                builder.Writeln(titleStr);
                builder.Font.ClearFormatting();
                builder.ParagraphFormat.ClearFormatting();
                builder.Font.Size = 14;
                builder.Writeln("");
                builder.Writeln(contentStr );
                doc.Save(response, System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + ".doc", ContentDisposition.Attachment, SaveOptions.CreateSaveOptions(SaveFormat.Doc));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
               
            }

        }


    }
}
