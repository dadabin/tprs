using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Bll;
using System.IO;
using System.Text;

public partial class Admin_itemselect1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindGridView(GridView1, AspNetPager1);

        }

    }


    public void bindGridView(GridView gv,AspNetPager pager)
    {
        if(Session["user_loginName"]!=null&&Session["user_loginName"].ToString()!=""){
            string loginName = Session["user_loginName"].ToString();
            ItemBll bll = new ItemBll();
            string where = " WHERE LOGINNAME=@LOGINNAME and AUDIT = 1";
            bll.userBindItem(gv, pager,loginName,where);

        }
        //ItemBll bll1 = new ItemBll();
        //bll1.userBindItem(gv, pager, "");
    }

    /// <summary>
    ///  绑定数据分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
      protected void  AspNetPager1_PageChanged(object sender, EventArgs e)
     {
         bindGridView(GridView1, AspNetPager1);
     }

    ///// <summary>
    ///// 导出Excel模板
    ///// </summary>
    ///// <param name="sender"></param>
    ///// <param name="e"></param>
    //  protected void Button1_Click(object sender, EventArgs e)
    //  {
    //      //生成一个新的文件名用全球唯一标示符（GUID）
    //      string newpath = Server.MapPath(".") + @"\Excel\" + Guid.NewGuid() + ".xls";
    //      //调用的模板文件
    //      FileInfo mode = new FileInfo(Server.MapPath("~/Admin/Excel/1.xls"));
    //      Excel.Application app = new Excel.Application();
    //      if (app == null)
    //      {
    //          return;
    //      }
    //      app.Application.DisplayAlerts = false;
    //      app.Visible = false;
    //      if (mode.Exists)
    //      {
    //          Excel.Workbook tworkbook;
    //          Object missing = System.Reflection.Missing.Value;
    //          app.Workbooks.Add(missing);
    //          //调用模板
    //          tworkbook = app.Workbooks.Open(mode.FullName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
    //          Excel.Worksheet tworksheet = (Excel.Worksheet)tworkbook.Sheets[1];

    //          //=============设置单元格样式
    //          Excel.Range range = app.get_Range(app.Cells[6, 3], app.Cells[6, 4]);
    //          range.Font.Name = "黑体";
    //          range.Font.Size = 20;
    //          //=============设置单元格样式
    //          //===============合并单元格
    //         range = app.get_Range(app.Cells[6, 3], app.Cells[6, 4]);
    //          range.MergeCells = true;

    //          tworksheet.Cells[6, 3] = "测试";
    //          tworksheet.Cells[6, 4] = "测试";
    //          tworksheet.SaveAs(newpath, missing, missing, missing, missing, missing, missing, missing, missing, missing);

    //          tworkbook.Close(false, mode.FullName, missing);
    //          app.Workbooks.Close();
    //          app.Quit();
    //          if (app != null)
    //          {
    //              foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
    //              {
    //                  //先判断当前进程是否是excel   
    //                  if (!p.CloseMainWindow())
    //                  {
    //                      p.Kill();
    //                  }
    //              }
    //          }
    //          tworkbook = null;
    //          app = null;
    //          //强制对所有代进行垃圾回收
    //          GC.Collect();
    //      }
    //      //打开保存对话框
    //      Response.Clear();
    //      Response.ClearHeaders();
    //      Response.Buffer = false;
    //      Response.Charset = "UTF-8";
    //      Response.ContentType = "application/ms-excel";
    //      Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(mode.Name));
    //      Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
    //      Response.AppendHeader("Content-Length", mode.Length.ToString());
    //      Response.Charset = "";
    //      this.EnableViewState = false;
    //      Response.WriteFile(newpath);
    //      //删除创建的Excel文件
    //      FileInfo fileinf = new FileInfo(newpath);
    //      fileinf.Delete();
    //      //关闭连接
    //      Response.Flush();
    //      Response.End();


    //  }
    /// <summary>
    /// 导出word
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //  protected void Button2_Click(object sender, EventArgs e)
    //  {
    //      //object oMissing = System.Reflection.Missing.Value;
    //      //Word._Application oWord;
    //      //Word._Document oDoc;
    //      //oWord = new Word.Application();
    //      //oWord.Visible = false;
    //      //oDoc = oWord.Documents.Add(ref oMissing, ref oMissing, ref oMissing, ref oMissing);


    //      System.Data.DataTable dt = new System.Data.DataTable();
    //      Object miss = System.Reflection.Missing.Value;
    //      //1.创建一个Word应用程序
    //      Word._Application appWord = new Word.ApplicationClass();
    //      //2.创建一个Word文档对象
    //      Word._Document docWord = appWord.Documents.Add(ref miss, ref miss, ref miss, ref miss);
    //      //3.创建一个Word中的表格对象
    //      Word.Table tableWord = docWord.Tables.Add(appWord.Selection.Range, 5, 5, ref miss, ref miss);
    //      for (int i = 1; i <= dt.Rows.Count; i++)
    //      {
    //          for (int j = 1; j <= dt.Columns.Count; j++)
    //          {
    //              tableWord.Rows[i].Cells[j].Range.Text = dt.Rows[i - 1][j - 1].ToString();
    //          }
    //      }
    //    // 添加页眉

    //      appWord.ActiveWindow.View.Type = WdViewType.wdOutlineView;
    //      appWord.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;
    //      appWord.ActiveWindow.ActivePane.Selection.InsertAfter(" [页眉内容] ");
    //      appWord.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight; // 设置右对齐
    //      appWord.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // 跳出页眉设置

    //      //4:设置Word表格中的信息
    //      tableWord.Rows[1].Cells[1].Range.Text = "测试数据";
    //      //5:设置或获取文档对象保存路径
    //      Object path = Server.MapPath(".") + "\\Word\\" + Guid.NewGuid().ToString() + ".doc";
    //      //6:保存当前Word文档对象到物理路径
    //      docWord.SaveAs(ref path, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss, ref miss);
    //      //7:关闭当前Word文档对象
    //      docWord.Close(ref miss, ref miss, ref miss);
    //      //8:关闭当前Word应用程序
    //      appWord.Quit(ref miss, ref miss, ref miss);

    //      Response.Clear();
    //      Response.ClearHeaders();
    //      Response.Buffer = false;
    //      Response.Charset = "UTF-8";
    //      Response.ContentType = "application/ms-excel";
    //      Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(new FileInfo(path.ToString()).Name));
    //      Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
    //      Response.AppendHeader("Content-Length", new FileInfo(path.ToString()).Length.ToString());
    //      Response.Charset = "";
    //      this.EnableViewState = false;
    //      Response.WriteFile(path.ToString());
    //      //删除创建的Excel文件
    //      FileInfo fileinf = new FileInfo(path.ToString());
    //      fileinf.Delete();
    //      //关闭连接
    //      Response.Flush();
    //      Response.End();
         



    ////       string  message  =   "" ;

    ////try

    ////{
    ////      Object Nothing = System.Reflection.Missing.Value;

    ////      Directory.CreateDirectory(" C:/CNSI ");   // 创建文件所在目录

    ////      string name = " CNSI_ " + DateTime.Now.ToShortTimeString() + " .doc ";

    ////      object filename = " C://CNSI// " + name;   // 文件保存路径

    ////      // 创建Word文档

    ////      Word.Application WordApp = new Word.ApplicationClass();

    ////      Word.Document WordDoc = WordApp.Documents.Add(ref  Nothing, ref  Nothing, ref  Nothing, ref  Nothing);

    ////      // 添加页眉

    ////      WordApp.ActiveWindow.View.Type = WdViewType.wdOutlineView;

    ////      WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekPrimaryHeader;

    ////      WordApp.ActiveWindow.ActivePane.Selection.InsertAfter(" [页眉内容] ");

    ////      WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight; // 设置右对齐

    ////      WordApp.ActiveWindow.View.SeekView = WdSeekView.wdSeekMainDocument; // 跳出页眉设置

    ////      WordApp.Selection.ParagraphFormat.LineSpacing = 15f; // 设置文档的行间距

    ////      // 移动焦点并换行

    ////      object count = 14;

    ////      object WdLine = Word.WdUnits.wdLine; // 换一行;

    ////      WordApp.Selection.MoveDown(ref  WdLine, ref  count, ref  Nothing); // 移动焦点

    ////      WordApp.Selection.TypeParagraph(); // 插入段落

    ////      // 文档中创建表格

    ////      Word.Table newTable = WordDoc.Tables.Add(WordApp.Selection.Range, 12, 3, ref  Nothing, ref  Nothing);

    ////      // 设置表格样式

    ////      newTable.Borders.OutsideLineStyle = Word.WdLineStyle.wdLineStyleThickThinLargeGap;

    ////      newTable.Borders.InsideLineStyle = Word.WdLineStyle.wdLineStyleSingle;

    ////      newTable.Columns[1].Width = 100f;

    ////      newTable.Columns[2].Width = 220f;

    ////      newTable.Columns[3].Width = 105f;

    ////      // 填充表格内容

    ////      newTable.Cell(1, 1).Range.Text = " 产品详细信息表 ";

    ////      newTable.Cell(1, 1).Range.Bold = 2; // 设置单元格中字体为粗体

    ////      // 合并单元格

    ////      newTable.Cell(1, 1).Merge(newTable.Cell(1, 3));

    ////      WordApp.Selection.Cells.VerticalAlignment = Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter; // 垂直居中

    ////      WordApp.Selection.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter; // 水平居中
    ////      // 填充表格内容

    ////newTable.Cell( 2 ,  1 ).Range.Text  =   " 产品基本信息 " ;

    ////newTable.Cell( 2 ,  1 ).Range.Font.Color  =  Word.WdColor.wdColorDarkBlue; // 设置单元格内字体颜色

    ////// 合并单元格

    ////newTable.Cell( 2 ,  1 ).Merge(newTable.Cell( 2 ,  3 ));

    ////WordApp.Selection.Cells.VerticalAlignment  =  Word.WdCellVerticalAlignment.wdCellAlignVerticalCenter;

    ////// 填充表格内容

    ////newTable.Cell( 3 ,  1 ).Range.Text  =   " 品牌名称： " ;

    //////newTable.Cell( 3 ,  2 ).Range.Text  =  BrandName;
    ////newTable.Cell(3, 2).Range.Text = "";

    ////// 纵向合并单元格

    ////newTable.Cell( 3 ,  3 ).Select(); // 选中一行

    ////object  moveUnit  =  Word.WdUnits.wdLine;

    ////object  moveCount  =   5 ;

    ////object  moveExtend  =  Word.WdMovementType.wdExtend;

    ////WordApp.Selection.MoveDown( ref  moveUnit,  ref  moveCount,  ref  moveExtend);

    ////WordApp.Selection.Cells.Merge();

    ////// 插入图片

    //////string  FileName  =  Picture; // 图片所在路径
    ////string FileName = ""; // 图片所在路径
    ////object  LinkToFile  =   false ;

    ////object  SaveWithDocument  =   true ;

    ////object  Anchor  =  WordDoc.Application.Selection.Range;

    ////WordDoc.Application.ActiveDocument.InlineShapes.AddPicture(FileName, ref  LinkToFile, ref  SaveWithDocument, ref  Anchor);

    ////WordDoc.Application.ActiveDocument.InlineShapes[1].Width = 100f; // 图片宽度

    ////WordDoc.Application.ActiveDocument.InlineShapes[1].Height = 100f; // 图片高度

    ////// 将图片设置为四周环绕型

    ////Word.Shape s = WordDoc.Application.ActiveDocument.InlineShapes[1].ConvertToShape();

    ////s.WrapFormat.Type = Word.WdWrapType.wdWrapSquare;

    ////newTable.Cell( 12 ,  1 ).Range.Text  =   " 产品特殊属性 " ;

    ////newTable.Cell( 12 ,  1 ).Merge(newTable.Cell( 12 ,  3 ));

    ////// 在表格中增加行

    ////WordDoc.Content.Tables[ 1 ].Rows.Add( ref  Nothing);

    ////WordDoc.Paragraphs.Last.Range.Text  =   " 文档创建时间： "   +  DateTime.Now.ToString(); // “落款”

    ////WordDoc.Paragraphs.Last.Alignment  =  Word.WdParagraphAlignment.wdAlignParagraphRight;

    ////// 文件保存

    ////WordDoc.SaveAs( ref  filename,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing,  ref  Nothing);

    ////WordDoc.Close( ref  Nothing,  ref  Nothing,  ref  Nothing);

    ////WordApp.Quit( ref  Nothing,  ref  Nothing,  ref  Nothing);

    ////message = name + " 文档生成成功，以保存到C:CNSI下 " ;

    ////}

    ////catch {

    ////message  =   " 文件导出异常！ " ;

    ////}

     


    //  }

     
}