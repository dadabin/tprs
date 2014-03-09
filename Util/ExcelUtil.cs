using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;
using Microsoft.Office.Interop.Word;
using System.Text;
using System.Data;


namespace Util
{
   public  class ExcelUtil:System.Web.UI.Page
    {





       public void st_excel_down(DataTable[] dts)
       {

           //生成一个新的文件名用全球唯一标示符（GUID）
           string newpath = Server.MapPath(".") + @"\Excel\" + Guid.NewGuid() + ".xls";
           //调用的模板文件
           FileInfo mode = new FileInfo(Server.MapPath("~/Admin/Excel/1.xls"));
           Excel.Application app = new Excel.Application();
           if (app == null)
           {
               return;
           }
           app.Application.DisplayAlerts = false;
           app.Visible = false;
           if (mode.Exists)
           {
               Excel.Workbook tworkbook;
               Object missing = System.Reflection.Missing.Value;
               app.Workbooks.Add(missing);
               //调用模板
               tworkbook = app.Workbooks.Open(mode.FullName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
               Excel.Worksheet tworksheet = (Excel.Worksheet)tworkbook.Sheets[1];
               tworksheet.Cells[2, 7] = "测试111111111112010年二月";
               //加载总表的数据
               for (int i = 0; i < dts[0].Rows.Count; i++)
               {
                   //数据填充到Excel总表中
                   for (int j = 0; j <= 10; j++)
                   {
                       tworksheet.Cells[i, j] = dts[0].Rows[i][j].ToString();
                   }
               }
               //
               //加载
               for (int i = 0; i < dts[1].Rows.Count; i++)
               {
                   //数据填充到Excel总表中
                   for (int j = 0; j <= 10; j++)
                   {
                       tworksheet.Cells[i, j] = dts[0].Rows[i][j].ToString();
                   }
               }
              tworksheet.SaveAs(newpath, missing, missing, missing, missing, missing, missing, missing, missing, missing);



               tworkbook.Close(false, mode.FullName, missing);
               app.Workbooks.Close();
               app.Quit();
               if (app != null)
               {
                   foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
                   {
                       //先判断当前进程是否是excel   
                       if (!p.CloseMainWindow())
                       {
                           p.Kill();
                       }
                   }
               }
               tworkbook = null;
               app = null;
               //强制对所有代进行垃圾回收
               GC.Collect();
           }
           //打开保存对话框
           Response.Clear();
           Response.ClearHeaders();
           Response.Buffer = false;
           Response.Charset = "UTF-8";
           Response.ContentType = "application/ms-excel";
           Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(mode.Name));
           Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
           Response.AppendHeader("Content-Length", mode.Length.ToString());
           Response.Charset = "";
           this.EnableViewState = false;
           Response.WriteFile(newpath);
           //删除创建的Excel文件
           FileInfo fileinf = new FileInfo(newpath);
           fileinf.Delete();
           //关闭连接
           Response.Flush();
           Response.End();

           



       }

       public void downTem( )
       {
           //生成一个新的文件名用全球唯一标示符（GUID）
           string newpath = Server.MapPath(".") + @"\Excel\" + Guid.NewGuid() + ".xls";
           //调用的模板文件
           FileInfo mode = new FileInfo(Server.MapPath("~/Admin/Excel/1.xls"));
           Excel.Application app = new Excel.Application();
           if (app == null)
           {
               return;
           }
           app.Application.DisplayAlerts = false;
           app.Visible = false;
           if (mode.Exists)
           {
               Excel.Workbook tworkbook;
               Object missing = System.Reflection.Missing.Value;
               app.Workbooks.Add(missing);
               //调用模板
               tworkbook = app.Workbooks.Open(mode.FullName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
               Excel.Worksheet tworksheet = (Excel.Worksheet)tworkbook.Sheets[1];
               tworksheet.Cells[2, 7] = "测试111111111112010年二月";
               //=============设置单元格样式
               Excel.Range range = app.get_Range(app.Cells[6, 3], app.Cells[6, 4]);
               range.Font.Name = "黑体";
               range.Font.Size = 30;
               //=============设置单元格样式
               //===============合并单元格
               range = app.get_Range(app.Cells[6, 3], app.Cells[6, 4]);
               range.MergeCells = true;

               tworksheet.Cells[6, 3] = "测试1";
               tworksheet.Cells[6, 4] = "测试2";
               tworksheet.SaveAs(newpath, missing, missing, missing, missing, missing, missing, missing, missing, missing);



               tworkbook.Close(false, mode.FullName, missing);
               app.Workbooks.Close();
               app.Quit();
               if (app != null)
               {
                   foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
                   {
                       //先判断当前进程是否是excel   
                       if (!p.CloseMainWindow())
                       {
                           p.Kill();
                       }
                   }
               }
               tworkbook = null;
               app = null;
               //强制对所有代进行垃圾回收
               GC.Collect();
           }
           //打开保存对话框
           Response.Clear();
           Response.ClearHeaders();
           Response.Buffer = false;
           Response.Charset = "UTF-8";
           Response.ContentType = "application/ms-excel";
           Response.AppendHeader("Content-Disposition", "attachment;filename=" + Server.UrlEncode(mode.Name));
           Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
           Response.AppendHeader("Content-Length", mode.Length.ToString());
           Response.Charset = "";
           this.EnableViewState = false;
           Response.WriteFile(newpath);
           //删除创建的Excel文件
           FileInfo fileinf = new FileInfo(newpath);
           fileinf.Delete();
           //关闭连接
           Response.Flush();
           Response.End();

           

       }

       public void bh_excel_down(DataTable[] dts)
       {
           //生成一个新的文件名用全球唯一标示符（GUID）
           string newpath = Server.MapPath(".") + @"\Excel\" + Guid.NewGuid() + ".xls";
           //调用的模板文件
           FileInfo mode = new FileInfo(Server.MapPath("~/Admin/Excel/bh.xls"));
           Excel.Application app = new Excel.Application();
           if (app == null)
           {
               return;
           }
           app.Application.DisplayAlerts = false;
           app.Visible = false;
           if (mode.Exists)
           {
               Excel.Workbook tworkbook;
               Object missing = System.Reflection.Missing.Value;
               app.Workbooks.Add(missing);
               //调用模板
               tworkbook = app.Workbooks.Open(mode.FullName, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing, missing);
               Excel.Worksheet tworksheet = (Excel.Worksheet)tworkbook.Sheets[1];
               tworksheet.Cells[2, 7] = "测试111111111112010年二月";
               //加载总表的数据
               //for (int i = 0; i < dts[0].Rows.Count; i++)
               //{
               //    //数据填充到Excel总表中
               //    for (int j = 0; j <= 18; j++)
               //    {
               //        tworksheet.Cells[i, j] = dts[0].Rows[i][j].ToString();
               //    }
               //}
               ////
               ////加载
               //for (int i = 0; i < dts[1].Rows.Count; i++)
               //{
               //    //数据填充到Excel总表中
               //    for (int j = 0; j <= 10; j++)
               //    {
               //        tworksheet.Cells[i, j] = dts[0].Rows[i][j].ToString();
               //    }
               //}
               tworksheet.SaveAs(newpath, missing, missing, missing, missing, missing, missing, missing, missing, missing);

               tworkbook.Close(false, mode.FullName, missing);
               app.Workbooks.Close();
               app.Quit();
               if (app != null)
               {
                   foreach (System.Diagnostics.Process p in System.Diagnostics.Process.GetProcessesByName("Excel"))
                   {
                       //先判断当前进程是否是excel   
                       if (!p.CloseMainWindow())
                       {
                           p.Kill();
                       }
                   }
               }
               tworkbook = null;
               app = null;
               //强制对所有代进行垃圾回收
               GC.Collect();
           }
           //打开保存对话框
           Response.Clear();
           Response.ClearHeaders();
           Response.Buffer = false;
           Response.Charset = "UTF-8";
           Response.ContentType = "application/ms-excel";
           Response.AppendHeader("Content-Disposition", "attachment;filename=百湖工程" + Server.UrlEncode(mode.Name));
           Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
           Response.AppendHeader("Content-Length", mode.Length.ToString());
           Response.Charset = "";
           this.EnableViewState = false;
           Response.WriteFile(newpath);
           //删除创建的Excel文件
           FileInfo fileinf = new FileInfo(newpath);
           fileinf.Delete();
           //关闭连接
           Response.Flush();
           Response.End();



       }



    }
}
