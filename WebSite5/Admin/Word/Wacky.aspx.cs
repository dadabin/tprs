using System;

using org.in2bits.MyXls;
using System.IO;

public partial class Wacky : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        XlsDocument xls = new XlsDocument();//新建一个xls文档
        xls.FileName = "Wacky.xls";//设定文件名
        
        //Add some metadata (visible from Excel under File -> Properties)
        xls.SummaryInformation.Author = "Tim Erickson"; //填加xls文件作者信息
        xls.SummaryInformation.Subject = "A wacky display of Excel file generation";//填加文件主题信息
        xls.DocumentSummaryInformation.Company = "in2bits.org";//填加文件公司信息

        #region 欢儿 2008-05-17 增加


        string sheetName = "chc 实例";
        Worksheet sheet = xls.Workbook.Worksheets.AddNamed(sheetName);//填加名为"chc 实例"的sheet页
        Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
        //单元格1-base
        Cell cell = cells.Add(1, 2, "抗");//设定第一行，第二例单元格的值
        cell.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
        cell.Font.FontName = "方正舒体";//设定字体
        cell.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
        cell.UseBorder = true;//使用边框
        cell.BottomLineStyle = 2;//设定边框底线为粗线
        cell.BottomLineColor = Colors.DarkRed;//设定颜色为暗红


        //cell的格式还可以定义在一个xf对象中
        XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
        cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
        cellXF.Font.FontName = "方正舒体";//设定字体
        cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
        cellXF.UseBorder = true;//使用边框
        cellXF.BottomLineStyle = 2;//设定边框底线为粗线
        cellXF.BottomLineColor = Colors.DarkRed;//设定颜色为暗红
        
        cell = cells.AddValueCellXF(2, 2,"震", cellXF);//以设定好的格式填加cell

        cellXF.Font.FontName = "仿宋_GB2312";
        cell = cells.AddValueCellXF(3, 2, "救", cellXF);//格式可以多次使用

        ColumnInfo colInfo = new ColumnInfo(xls, sheet);//生成列格式对象
        //设定colInfo格式的起作用的列为第2列到第5列(列格式为0-base)
        colInfo.ColumnIndexStart = 1;//起始列为第二列
        colInfo.ColumnIndexEnd = 5;//终止列为第六列
        colInfo.Width = 15 * 256;//列的宽度计量单位为 1/256 字符宽
        sheet.AddColumnInfo(colInfo);//把格式附加到sheet页上（注：AddColumnInfo方法有点小问题，不给把colInfo对象多次附给sheet页）
        colInfo.ColumnIndexEnd = 6;//可以更改列对象的值
        ColumnInfo colInfo2 = new ColumnInfo(xls, sheet);//通过新生成一个列格式对象，才到能设定其它列宽度
        colInfo2.ColumnIndexStart = 7;
        colInfo2.ColumnIndexEnd = 8;
        colInfo2.Width = 1 * 256;
        sheet.AddColumnInfo(colInfo2);

        MergeArea meaA = new MergeArea(1,2,3,4);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
        sheet.AddMergeArea(meaA);//填加合并单元格
        cellXF.VerticalAlignment=  VerticalAlignments.Centered;
        cellXF.Font.Height = 48 * 20;
        cellXF.Font.Bold = true;
        cellXF.Pattern = 3;//设定单元格填充风格。如果设定为0，则是纯色填充
        cellXF.PatternBackgroundColor = Colors.DarkRed;//填充的底色
        cellXF.PatternColor = Colors.DarkGreen;//设定填充线条的颜色
        cell = cells.Add(1, 3, "灾",cellXF);

        #endregion



        for (int sheetNumber = 1; sheetNumber <= 5; sheetNumber++)
        {
            sheetName = "Sheet " + sheetNumber;
            int rowMin = sheetNumber;
            int rowCount = sheetNumber + 10;
            int colMin = sheetNumber;
            int colCount = sheetNumber + 10;
            sheet = xls.Workbook.Worksheets.AddNamed(sheetName);
            cells = sheet.Cells;
            for (int r = 0; r < rowCount; r++)
            {
                if (r == 0)
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        cells.Add(rowMin + r, colMin + c, "Fld" + (c + 1)).Font.Bold = true;
                    }
                }
                else
                {
                    for (int c = 0; c < colCount; c++)
                    {
                        int val = r + c;
                        cell = cells.Add(rowMin + r, colMin + c, val);
                        if (val % 2 != 0)
                        {
                            cell.Font.FontName = "Times New Roman";
                            cell.Font.Underline = UnderlineTypes.Double;
                            cell.Rotation = 45; //字符倾斜45度
                        }
                    }
                }
            }
        }

        xls.Save(Server.MapPath("~/Admin/Excel"));
        string fileName = "Wacky.xls";//客户端保存的文件名
        string filePath = Server.MapPath("~/Admin/Excel/Wacky.xls");//路径
        FileInfo fileInfo = new FileInfo(filePath);
        Response.Clear();
        Response.ClearContent();
        Response.ClearHeaders();
        Response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
        Response.AddHeader("Content-Length", fileInfo.Length.ToString());
        Response.AddHeader("Content-Transfer-Encoding", "binary");
        Response.ContentType = "application/octet-stream";
        Response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
        Response.WriteFile(fileInfo.FullName);
        Response.Flush();
        try
        {
            File.Delete(filePath);
        }
        catch (Exception exx)
        {
            throw new Exception(exx.Message);
        }
        finally
        {
            Response.End();
        }
    }
}
