using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using org.in2bits.MyXls;
using System.IO;
using System.Data;

namespace Dal
{
    public class ExcelDown
    {
        #region  生态旅游重大项目
        /// <summary>
        /// admin 下载生态旅游重大项目Excel=====================
        /// </summary>
        /// <param name="response"></param>
        /// <param name="path"></param>
        public void downstExcel(HttpResponse response,String path,int year,int month)
        {
            //=========得到汇总数据===========
            Dictionary<String, String> admin_dic = getstMoneyAndCount(year, month, 2);
            Dictionary<String, String> lq_dic = getstMoneyAndCountByAddress(year, month, 2, "lqy");
            Dictionary<String, String> sl_dic = getstMoneyAndCountByAddress(year, month, 2, "sl");
            Dictionary<String, String> jt_dic = getstMoneyAndCountByAddress(year, month, 2, "jt");
            Dictionary<String, String> qbj_dic = getstMoneyAndCountByAddress(year, month, 2, "qbj");
            Dictionary<String, String> xj_dic = getstMoneyAndCountByAddress(year, month, 2, "xj");


            string filename = "st_"+System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            XlsDocument xls = new XlsDocument();//新建一个xls文档
            xls.FileName = filename + ".xls";//设定文件名
            string sheetName = "总表";
            Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
            Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXF.Font.FontName = "宋体";//设定字体
            cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXF.UseBorder = true;//使用边框
            cellXF.TextWrapRight = true;//自动换行
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.RightLineColor = Colors.Black;
            cellXF.RightLineStyle = 1;

            //===================================设置标题=====================================================//
            MergeArea meaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 20 * 20;
            cellXF.Font.Bold = true;
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            //===============================
            ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
            col1.ColumnIndexStart = 1;//起始列为第1列
            col1.ColumnIndexEnd = 31;//终止列为第1列
            col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
            sheet.AddColumnInfo(col1);//把格式附加到sheet页上
            //==================================
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", cellXF);
            //==============================================设置表头===============================================//
            MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA1);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 15 * 15;
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.Font.Bold = true;
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充


            Cell cell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    cell2 = cells.Add(j, i, "", cellXF);
            }

             cell2 = cells.Add(4, 1, "序号", cellXF);
            cell2.Font.FontName = "Times New Roman";
            MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
            sheet.AddMergeArea(meaA2);
            cell2 = cells.Add(4, 2, "所属区县", cellXF);
            MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
            sheet.AddMergeArea(meaA3);
            cell2 = cells.Add(4, 3, "项目名称", cellXF);
            MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
            sheet.AddMergeArea(meaA4);
            cell2 = cells.Add(4, 4, "建设地址", cellXF);
            MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
            sheet.AddMergeArea(meaA5);
            cell2 = cells.Add(4, 5, "建设年限", cellXF);
            MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
            sheet.AddMergeArea(meaA6);
            cell2 = cells.Add(4, 6, "建设性质", cellXF);
            MergeArea meaA7 = new MergeArea(4, 6, 7, 7);
            sheet.AddMergeArea(meaA7);
            cell2 = cells.Add(4, 7, "建设内容及规模", cellXF);
            MergeArea meaA8 = new MergeArea(4, 6, 8, 8);
            sheet.AddMergeArea(meaA8);
            cell2 = cells.Add(4, 8, "总投资", cellXF);

            MergeArea meaAt9 = new MergeArea(4, 4, 9, 14);
            sheet.AddMergeArea(meaAt9);
            cell2 = cells.Add(4, 9, "资金构成", cellXF);

            MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
            sheet.AddMergeArea(meaA9);
            cell2 = cells.Add(5, 9, "中央资金", cellXF);
            MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
            sheet.AddMergeArea(meaA10);
            cell2 = cells.Add(5, 10, "省级资金", cellXF);

            MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
            sheet.AddMergeArea(meaA11);
            cell2 = cells.Add(5, 11, "市级资金", cellXF);

            MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
            sheet.AddMergeArea(meaA12);
            cell2 = cells.Add(5, 12, "区县资金", cellXF);

            MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
            sheet.AddMergeArea(meaA13);
            cell2 = cells.Add(5, 13, "银行贷款", cellXF);
            MergeArea meaA14 = new MergeArea(5, 6, 14, 14);
            sheet.AddMergeArea(meaA14);
            cell2 = cells.Add(5, 14, "企业自筹", cellXF);

            MergeArea meaA15 = new MergeArea(4, 6, 15, 15);
            sheet.AddMergeArea(meaA15);
            cell2 = cells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", cellXF);
            MergeArea meaA16 = new MergeArea(4, 6, 16, 16);
            sheet.AddMergeArea(meaA16);
            cell2 = cells.Add(4, 16, year+"年计划投资", cellXF);

            MergeArea meaA17 = new MergeArea(4, 6, 17, 17);
            sheet.AddMergeArea(meaA17);
            cell2 = cells.Add(4, 17, "目前为止项目形象进度", cellXF);

            MergeArea meaAt18 = new MergeArea(4, 4, 18, 21);
            sheet.AddMergeArea(meaAt18);
            cell2 = cells.Add(4, 18, "项目业主", cellXF);

            MergeArea meaA18 = new MergeArea(5, 6, 18, 18);
            sheet.AddMergeArea(meaA18);
            cell2 = cells.Add(5, 18, "单位名称", cellXF);
            MergeArea meaA19 = new MergeArea(5, 6, 19, 19);
            sheet.AddMergeArea(meaA19);
            cell2 = cells.Add(5, 19, "法人代表", cellXF);

            MergeArea meaA20 = new MergeArea(5, 6, 20, 20);
            sheet.AddMergeArea(meaA20);
            cell2 = cells.Add(5, 20, "业主联系人", cellXF);

            MergeArea meaA21 = new MergeArea(5, 6, 21, 21);
            sheet.AddMergeArea(meaA21);
            cell2 = cells.Add(5, 21, "联系电话", cellXF);
            MergeArea meaA22 = new MergeArea(4, 6, 22, 22);
            sheet.AddMergeArea(meaA22);
            cell2 = cells.Add(4, 22, "开工（计划开工）时间", cellXF);

            MergeArea meaA23 = new MergeArea(4, 6, 23, 23);
            sheet.AddMergeArea(meaA23);
            cell2 = cells.Add(4, 23, "计划竣工时间", cellXF);

            MergeArea meaA24 = new MergeArea(4, 6, 24, 24);
            sheet.AddMergeArea(meaA24);
            cell2 = cells.Add(4, 24, "四个一批范筹", cellXF);

            MergeArea meaA25 = new MergeArea(4, 6, 25, 25);
            sheet.AddMergeArea(meaA25);
            cell2 = cells.Add(4, 25, "已取得土地指标（亩）", cellXF);

            MergeArea meaA26 = new MergeArea(4, 6, 26, 26);
            sheet.AddMergeArea(meaA26);
            cell2 = cells.Add(4, 26, "拟申请土地指标（亩）", cellXF);

            MergeArea meaA27 = new MergeArea(4, 6, 27, 27);
            sheet.AddMergeArea(meaA27);
            cell2 = cells.Add(4, 27, "是否政府投资项目", cellXF);

            MergeArea meaA28 = new MergeArea(4, 6, 28, 28);
            sheet.AddMergeArea(meaA28);
            cell2 = cells.Add(4, 28, "1-"+month+"月累计完成投资额", cellXF);

            MergeArea meaA29 = new MergeArea(4, 6, 29, 29);
            sheet.AddMergeArea(meaA29);
            cell2 = cells.Add(4, 29, month+"月累计完成投资额", cellXF);

            MergeArea meaA30 = new MergeArea(4, 6, 30, 30);
            sheet.AddMergeArea(meaA30);
            cell2 = cells.Add(4, 30, "需协调解决问题", cellXF);
            MergeArea meaA31 = new MergeArea(4, 6, 31, 31);
            sheet.AddMergeArea(meaA31);
            cell2 = cells.Add(4, 31, "备注", cellXF);
            //=============================表头完成======================填入正文开始===================
            XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXFcont.Font.FontName = "宋体";//设定字体
            //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXFcont.TextWrapRight = true;//自动换行
            cellXFcont.BottomLineStyle = 1;
            cellXFcont.BottomLineColor = Colors.Black;
            cellXFcont.RightLineColor = Colors.Black;
            cellXFcont.RightLineStyle = 1;
            DataBase db = new DataBase();
            //===============================投产达产=============
            System.Data.DataTable dt2 = db.GetDataTable("select * from dbo.getstReport(" + year + "," + month + ",'tcdc')");
            MergeArea meaAtcdc = new MergeArea(7, 7, 1, 7);
            sheet.AddMergeArea(meaAtcdc);
            cell2 = cells.Add(7, 1, "一、投产达产（项目共计：" + dt2.Rows.Count + "个；总投资：" + admin_dic["tcdc_all_total"] + "万元；" + year + "年计划投资：" + admin_dic["tcdc_c11"] + "万元。）", cellXF);
            int x = 8;
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
           
            //小计========
       
            x = dt2.Rows.Count + x;

            cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计",cellXF);
            cell2 = cells.Add(x, 8, admin_dic["tcdc_c1"] + "", cellXF);
            cell2 = cells.Add(x, 9, admin_dic["tcdc_c4"] + "", cellXF);
            cell2 = cells.Add(x, 10, admin_dic["tcdc_c5"] + "", cellXF);
            cell2 = cells.Add(x, 11, admin_dic["tcdc_c6"] + "", cellXF);
            cell2 = cells.Add(x, 12, admin_dic["tcdc_c7"] + "", cellXF);
            cell2 = cells.Add(x, 13, admin_dic["tcdc_c8"] + "", cellXF);
            cell2 = cells.Add(x, 14, admin_dic["tcdc_c9"] + "", cellXF);
            cell2 = cells.Add(x, 15, admin_dic["tcdc_c10"] + "", cellXF);
            cell2 = cells.Add(x, 16, admin_dic["tcdc_c11"] + "", cellXF);
            cell2 = cells.Add(x, 25, admin_dic["tcdc_c12"] + "",cellXF);
            cell2 = cells.Add(x, 26, admin_dic["tcdc_c13"] + "", cellXF);
            cell2 = cells.Add(x, 28, admin_dic["tcdc_c14"] + "", cellXF);
            cell2 = cells.Add(x, 29, admin_dic["tcdc_c15"] + "", cellXF);

            //====================
            x = x + 1;
            
            //===============================加快建设=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'jkjs')");
            MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
            sheet.AddMergeArea(meaAjkjs);
            cell2 = cells.Add(x, 1, "二、加快建设（项目共计：" + dt4.Rows.Count + "个；总投资：" + admin_dic["jkjs_all_total"] + "万元；" + System.DateTime.Now.Year + "年计划投资：" + admin_dic["jkjs_c11"] + "万元。）", cellXF);
            x = x + 1;
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dt4.Rows.Count + x;
            cell2 = cells.Add(x, 1, dt4.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计",cellXF);
            cell2 = cells.Add(x, 8, admin_dic["jkjs_c1"] + "", cellXF);
            cell2 = cells.Add(x, 9, admin_dic["jkjs_c4"] + "", cellXF);
            cell2 = cells.Add(x, 10, admin_dic["jkjs_c5"] + "", cellXF);
            cell2 = cells.Add(x, 11, admin_dic["jkjs_c6"] + "", cellXF);
            cell2 = cells.Add(x, 12, admin_dic["jkjs_c7"] + "", cellXF);
            cell2 = cells.Add(x, 13, admin_dic["jkjs_c8"] + "", cellXF);
            cell2 = cells.Add(x, 14, admin_dic["jkjs_c9"] + "", cellXF);
            cell2 = cells.Add(x, 15, admin_dic["jkjs_c10"] + "", cellXF);
            cell2 = cells.Add(x, 16, admin_dic["jkjs_c11"] + "", cellXF);
            cell2 = cells.Add(x, 25, admin_dic["jkjs_c12"] + "", cellXF);
            cell2 = cells.Add(x, 26, admin_dic["jkjs_c13"] + "", cellXF);
            cell2 = cells.Add(x, 28, admin_dic["jkjs_c14"] + "", cellXF);
            cell2 = cells.Add(x, 29, admin_dic["jkjs_c15"] + "", cellXF);

            //====================
            ////小计======
            //MergeArea meaAjkjs_total = new MergeArea(dt4.Rows.Count + x, dt4.Rows.Count + x, 1, 1);
            //sheet.AddMergeArea(meaAjkjs_total);
            //cell2=cells.Add(dt4.Rows.Count + x,1,"小计");

            x =1 + x;
            //===============================促进开工=============
            //System.Data.DataTable dt5 = db.GetDataTable("select * from dbo.getMoneyTotalAndNumAll(" + year + "," + month + ",'cjkg')");
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'cjkg')");
            MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
            sheet.AddMergeArea(meaAcjkg);
            cell2 = cells.Add(x, 1, "三、促进开工（项目共计：" + dt6.Rows.Count + "个；总投资：" + admin_dic["cjkg_all_total"] + "万元；" + System.DateTime.Now.Year + "年计划投资：" + admin_dic["cjkg_c11"] + "万元。）", cellXF);
            x = x + 1;
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dt6.Rows.Count  + x;
            cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计", cellXF);
            cell2 = cells.Add(x, 8, admin_dic["cjkg_c1"] + "", cellXF);
            cell2 = cells.Add(x, 9, admin_dic["cjkg_c4"] + "", cellXF);
            cell2 = cells.Add(x, 10, admin_dic["cjkg_c5"] + "", cellXF);
            cell2 = cells.Add(x, 11, admin_dic["cjkg_c6"] + "", cellXF);
            cell2 = cells.Add(x, 12, admin_dic["cjkg_c7"] + "", cellXF);
            cell2 = cells.Add(x, 13, admin_dic["cjkg_c8"] + "", cellXF);
            cell2 = cells.Add(x, 14, admin_dic["cjkg_c9"] + "", cellXF);
            cell2 = cells.Add(x, 15, admin_dic["cjkg_c10"] + "", cellXF);
            cell2 = cells.Add(x, 16, admin_dic["cjkg_c11"] + "", cellXF);
            cell2 = cells.Add(x, 25, admin_dic["cjkg_c12"] + "", cellXF);
            cell2 = cells.Add(x, 26, admin_dic["cjkg_c13"] + "", cellXF);
            cell2 = cells.Add(x, 28, admin_dic["cjkg_c14"] + "", cellXF);
            cell2 = cells.Add(x, 29, admin_dic["cjkg_c15"] + "", cellXF);

            //====================
            
            //小计

            x =  1 + x;
            //===============================前期储备=============
            System.Data.DataTable dt8 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'qqcb')");
            MergeArea meaAqqcb = new MergeArea(x, x, 1, 7);
            sheet.AddMergeArea(meaAqqcb);
            cell2 = cells.Add(x, 1, "四、前期储备（项目共计：" + dt8.Rows.Count + "个；总投资：" + admin_dic["qqcb_all_total"] + "万元；" + System.DateTime.Now.Year + "年计划投资：" + admin_dic["qqcb_c11"] + "万元。）", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = dt8.Rows.Count + x;
            cell2 = cells.Add(x, 1, dt8.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计",cellXF);
            cell2 = cells.Add(x, 8, admin_dic["qqcb_c1"] + "",cellXF);
            cell2 = cells.Add(x, 9, admin_dic["qqcb_c4"] + "",cellXF);
            cell2 = cells.Add(x, 10, admin_dic["qqcb_c5"] + "",cellXF);
            cell2 = cells.Add(x, 11, admin_dic["qqcb_c6"] + "",cellXF);
            cell2 = cells.Add(x, 12, admin_dic["qqcb_c7"] + "",cellXF);
            cell2 = cells.Add(x, 13, admin_dic["qqcb_c8"] + "",cellXF);
            cell2 = cells.Add(x, 14, admin_dic["qqcb_c9"] + "",cellXF);
            cell2 = cells.Add(x, 15, admin_dic["qqcb_c10"] + "",cellXF);
            cell2 = cells.Add(x, 16, admin_dic["qqcb_c11"] + "",cellXF);
            cell2 = cells.Add(x, 25, admin_dic["qqcb_c12"] + "",cellXF);
            cell2 = cells.Add(x, 26, admin_dic["qqcb_c13"] + "",cellXF);
            cell2 = cells.Add(x, 28, admin_dic["qqcb_c14"] + "",cellXF);
            cell2 = cells.Add(x, 29, admin_dic["qqcb_c15"]+"",cellXF);

            x = x + 1;

            cell2 = cells.Add(x, 1, dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count + dt8.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "总合计",cellXF);
            cell2 = cells.Add(x, 8, (decimal.Parse(admin_dic["qqcb_c1"])+decimal.Parse(admin_dic["cjkg_c1"])+decimal.Parse(admin_dic["jkjs_c1"])+decimal.Parse(admin_dic["tcdc_c1"])) + "",cellXF);
            cell2 = cells.Add(x, 9, (decimal.Parse(admin_dic["qqcb_c4"]) + decimal.Parse(admin_dic["cjkg_c4"]) + decimal.Parse(admin_dic["jkjs_c4"]) + decimal.Parse(admin_dic["tcdc_c4"])) + "",cellXF);
            cell2 = cells.Add(x, 10, (decimal.Parse(admin_dic["qqcb_c5"]) + decimal.Parse(admin_dic["cjkg_c5"]) + decimal.Parse(admin_dic["jkjs_c5"]) + decimal.Parse(admin_dic["tcdc_c5"])) + "",cellXF);
            cell2 = cells.Add(x, 11, (decimal.Parse(admin_dic["qqcb_c6"]) + decimal.Parse(admin_dic["cjkg_c6"]) + decimal.Parse(admin_dic["jkjs_c6"]) + decimal.Parse(admin_dic["tcdc_c6"])) + "",cellXF);
            cell2 = cells.Add(x, 12, (decimal.Parse(admin_dic["qqcb_c7"]) + decimal.Parse(admin_dic["cjkg_c7"]) + decimal.Parse(admin_dic["jkjs_c7"]) + decimal.Parse(admin_dic["tcdc_c7"])) + "",cellXF);
            cell2 = cells.Add(x, 13, (decimal.Parse(admin_dic["qqcb_c8"]) + decimal.Parse(admin_dic["cjkg_c8"]) + decimal.Parse(admin_dic["jkjs_c8"]) + decimal.Parse(admin_dic["tcdc_c8"])) + "",cellXF);
            cell2 = cells.Add(x, 14, (decimal.Parse(admin_dic["qqcb_c9"]) + decimal.Parse(admin_dic["cjkg_c9"]) + decimal.Parse(admin_dic["jkjs_c9"]) + decimal.Parse(admin_dic["tcdc_c9"])) + "",cellXF);
            cell2 = cells.Add(x, 15, (decimal.Parse(admin_dic["qqcb_c10"]) + decimal.Parse(admin_dic["cjkg_c10"]) + decimal.Parse(admin_dic["jkjs_c10"]) + decimal.Parse(admin_dic["tcdc_c10"])) + "",cellXF);
            cell2 = cells.Add(x, 16, (decimal.Parse(admin_dic["qqcb_c11"]) + decimal.Parse(admin_dic["cjkg_c11"]) + decimal.Parse(admin_dic["jkjs_c11"]) + decimal.Parse(admin_dic["tcdc_c11"])) + "",cellXF);
            cell2=cells.Add(x,25,(decimal.Parse(admin_dic["qqcb_c12"])+decimal.Parse(admin_dic["cjkg_c12"])+decimal.Parse(admin_dic["jkjs_c12"])+decimal.Parse(admin_dic["tcdc_c12"]))+"",cellXF);
            cell2 = cells.Add(x, 26, (decimal.Parse(admin_dic["qqcb_c13"])+decimal.Parse(admin_dic["cjkg_c13"])+decimal.Parse(admin_dic["jkjs_c13"])+decimal.Parse(admin_dic["tcdc_c13"])) + "",cellXF);
            cell2=cells.Add(x,28,(decimal.Parse(admin_dic["qqcb_c14"])+decimal.Parse(admin_dic["cjkg_c14"])+decimal.Parse(admin_dic["jkjs_c14"])+decimal.Parse(admin_dic["tcdc_c14"]))+"",cellXF);
            cell2 = cells.Add(x, 29, (decimal.Parse(admin_dic["qqcb_c15"])+decimal.Parse(admin_dic["cjkg_c15"])+decimal.Parse(admin_dic["jkjs_c15"])+decimal.Parse(admin_dic["tcdc_c15"])) + "", cellXF);
            //====================
           
            //汇总所有的资金很项目个数
            ///===========================表头
            MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
            sheet.AddMergeArea(meaAttaddre);
            cell2 = cells.Add(3, 2, "填报单位（盖章）");

            MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
            sheet.AddMergeArea(meaAttname);
            cell2 = cells.Add(3, 4, "填报人：");
            MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
            sheet.AddMergeArea(meaAttname1);
            cell2 = cells.Add(3, 6, "审核人：");

            MergeArea meaAtt = new MergeArea(3, 3, 10, 17);
            sheet.AddMergeArea(meaAtt);
            cell2 = cells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(admin_dic["tcdc_c14"]) + decimal.Parse(admin_dic["cjkg_c14"]) + decimal.Parse(admin_dic["jkjs_c14"]) + decimal.Parse(admin_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea meaAttu = new MergeArea(3, 3, 28, 29);
            sheet.AddMergeArea(meaAttu);
            cell2 = cells.Add(3, 28, "单位：万元、亩");
            //======================================================================================龙泉驿区======
            string sheetlqName = "龙泉";
            Worksheet sheetlq = xls.Workbook.Worksheets.Add(sheetlqName);//填加名为"总表"的sheetlq页

            Cells lqcells = sheetlq.Cells;//Cells实例是sheetlq页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF lqcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            lqcellXF.Font.FontName = "宋体";//设定字体
            lqcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            lqcellXF.UseBorder = true;//使用边框
            lqcellXF.TextWrapRight = true;//自动换行
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.RightLineColor = Colors.Black;
            lqcellXF.RightLineStyle = 1;
            //cell = lqcells.AddValueCellXF(2, 2, "震", lqcellXF);//以设定好的格式填加cell
            //lqcellXF.Font.FontName = "宋体";
            //cell = lqcells.AddValueCellXF(3, 2, "救", lqcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea lqmeaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 20 * 20;
            lqcellXF.Font.Bold = true;
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell lqcell = lqcells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", lqcellXF);
            //==============================================设置表头===============================================//
            sheetlq.AddColumnInfo(col1);//把格式附加到sheet页上
            //===============================
            sheetlq.AddColumnInfo(col1);//把格式附加到sheet页上
            //==================================
            MergeArea lqmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA1);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 15 * 15;
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.Font.Bold = true;
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell lqcell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    lqcell2 = lqcells.Add(j, i, "", cellXF);
            }

             lqcell2 = lqcells.Add(4, 1, "序号", lqcellXF);
            //=============
            lqcell2.Font.FontName = "Times New Roman";
            MergeArea lqmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetlq.AddMergeArea(lqmeaA2);
            lqcell2 = lqcells.Add(4, 2, "所属区县", lqcellXF);
            MergeArea lqmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetlq.AddMergeArea(lqmeaA3);
            lqcell2 = lqcells.Add(4, 3, "项目名称", lqcellXF);
            MergeArea lqmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetlq.AddMergeArea(lqmeaA4);
            lqcell2 = lqcells.Add(4, 4, "建设地址", lqcellXF);
            MergeArea lqmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetlq.AddMergeArea(lqmeaA5);
            lqcell2 = lqcells.Add(4, 5, "建设年限", lqcellXF);
            MergeArea lqmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetlq.AddMergeArea(lqmeaA6);
            lqcell2 = lqcells.Add(4, 6, "建设性质", lqcellXF);
            MergeArea lqmeaA7 = new MergeArea(4, 6, 7, 7);
            sheetlq.AddMergeArea(lqmeaA7);
            lqcell2 = lqcells.Add(4, 7, "建设内容及规模", lqcellXF);
            MergeArea lqmeaA8 = new MergeArea(4, 6, 8, 8);
            sheetlq.AddMergeArea(lqmeaA8);
            lqcell2 = lqcells.Add(4, 8, "总投资", lqcellXF);

            MergeArea lqmeaAt9 = new MergeArea(4, 4, 9, 14);
            sheetlq.AddMergeArea(lqmeaAt9);
            lqcell2 = lqcells.Add(4, 9, "资金构成", lqcellXF);

            MergeArea lqmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetlq.AddMergeArea(lqmeaA9);
            lqcell2 = lqcells.Add(5, 9, "中央资金", lqcellXF);
            MergeArea lqmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetlq.AddMergeArea(lqmeaA10);
            lqcell2 = lqcells.Add(5, 10, "省级资金", lqcellXF);

            MergeArea lqmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetlq.AddMergeArea(lqmeaA11);
            lqcell2 = lqcells.Add(5, 11, "市级资金", lqcellXF);

            MergeArea lqmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetlq.AddMergeArea(lqmeaA12);
            lqcell2 = lqcells.Add(5, 12, "区县资金", lqcellXF);

            MergeArea lqmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetlq.AddMergeArea(lqmeaA13);
            lqcell2 = lqcells.Add(5, 13, "银行贷款", lqcellXF);
            MergeArea lqmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetlq.AddMergeArea(lqmeaA14);
            lqcell2 = lqcells.Add(5, 14, "企业自筹", lqcellXF);

            MergeArea lqmeaA15 = new MergeArea(4, 6, 15, 15);
            sheetlq.AddMergeArea(lqmeaA15);
            lqcell2 = lqcells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", lqcellXF);
            MergeArea lqmeaA16 = new MergeArea(4, 6, 16, 16);
            sheetlq.AddMergeArea(lqmeaA16);
            lqcell2 = lqcells.Add(4, 16, year+"年计划投资", lqcellXF);

            MergeArea lqmeaA17 = new MergeArea(4, 6, 17, 17);
            sheetlq.AddMergeArea(lqmeaA17);
            lqcell2 = lqcells.Add(4, 17, "目前为止项目形象进度", lqcellXF);

            MergeArea lqmeaAt18 = new MergeArea(4, 4, 18, 21);
            sheetlq.AddMergeArea(lqmeaAt18);
            lqcell2 = lqcells.Add(4, 18, "项目业主", lqcellXF);

            MergeArea lqmeaA18 = new MergeArea(5, 6, 18, 18);
            sheetlq.AddMergeArea(lqmeaA18);
            lqcell2 = lqcells.Add(5, 18, "单位名称", lqcellXF);
            MergeArea lqmeaA19 = new MergeArea(5, 6, 19, 19);
            sheetlq.AddMergeArea(lqmeaA19);
            lqcell2 = lqcells.Add(5, 19, "法人代表", lqcellXF);

            MergeArea lqmeaA20 = new MergeArea(5, 6, 20, 20);
            sheetlq.AddMergeArea(lqmeaA20);
            lqcell2 = lqcells.Add(5, 20, "业主联系人", lqcellXF);

            MergeArea lqmeaA21 = new MergeArea(5, 6, 21, 21);
            sheetlq.AddMergeArea(lqmeaA21);
            lqcell2 = lqcells.Add(5, 21, "联系电话", lqcellXF);
            MergeArea lqmeaA22 = new MergeArea(4, 6, 22, 22);
            sheetlq.AddMergeArea(lqmeaA22);
            lqcell2 = lqcells.Add(4, 22, "开工（计划开工）时间", lqcellXF);

            MergeArea lqmeaA23 = new MergeArea(4, 6, 23, 23);
            sheetlq.AddMergeArea(lqmeaA23);
            lqcell2 = lqcells.Add(4, 23, "计划竣工时间", lqcellXF);

            MergeArea lqmeaA24 = new MergeArea(4, 6, 24, 24);
            sheetlq.AddMergeArea(lqmeaA24);
            lqcell2 = lqcells.Add(4, 24, "四个一批范筹", lqcellXF);

            MergeArea lqmeaA25 = new MergeArea(4, 6, 25, 25);
            sheetlq.AddMergeArea(lqmeaA25);
            lqcell2 = lqcells.Add(4, 25, "已取得土地指标（亩）", lqcellXF);

            MergeArea lqmeaA26 = new MergeArea(4, 6, 26, 26);
            sheetlq.AddMergeArea(lqmeaA26);
            lqcell2 = lqcells.Add(4, 26, "拟申请土地指标（亩）", lqcellXF);

            MergeArea lqmeaA27 = new MergeArea(4, 6, 27, 27);
            sheetlq.AddMergeArea(lqmeaA27);
            lqcell2 = lqcells.Add(4, 27, "是否政府投资项目", lqcellXF);

            MergeArea lqmeaA28 = new MergeArea(4, 6, 28, 28);
            sheetlq.AddMergeArea(lqmeaA28);
            lqcell2 = lqcells.Add(4, 28, "1-"+month+"月累计完成投资额", lqcellXF);

            MergeArea lqmeaA29 = new MergeArea(4, 6, 29, 29);
            sheetlq.AddMergeArea(lqmeaA29);
            lqcell2 = lqcells.Add(4, 29, month+"月累计完成投资额", lqcellXF);

            MergeArea lqmeaA30 = new MergeArea(4, 6, 30, 30);
            sheetlq.AddMergeArea(lqmeaA30);
            lqcell2 = lqcells.Add(4, 30, "需协调解决问题", lqcellXF);

            MergeArea lqmeaA31 = new MergeArea(4, 6, 31, 31);
            sheetlq.AddMergeArea(lqmeaA31);
            lqcell2 = lqcells.Add(4, 31, "备注", lqcellXF);

            //=========================投产达产========
            x = 7;
            MergeArea meaAtcdc1 = new MergeArea(x, x, 1, 7);
            sheetlq.AddMergeArea(meaAtcdc1);

            System.Data.DataTable dtlq2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','lqy',2)");

            lqcell2 = lqcells.Add(x, 1, "一、投产达产（项目共计：" + dtlq2.Rows.Count + "个；总投资：" + lq_dic["tcdc_total"] + "万元；" + year + "年计划投资：" + lq_dic["tcdc_c11"] + "万元。）", lqcellXF);
            x = x + 1;
          
            for (int i = 0; i < dtlq2.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtlq2.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dtlq2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = dtlq2.Rows.Count  + x;
            lqcell2 = lqcells.Add(x, 1, dtlq2.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计",cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["tcdc_c1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 9, lq_dic["tcdc_c4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["tcdc_c5"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["tcdc_c6"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["tcdc_c7"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 13, lq_dic["tcdc_c8"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 14, lq_dic["tcdc_c9"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 15, lq_dic["tcdc_c10"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 16, lq_dic["tcdc_c11"] + "", cellXF);
            lqcell2=lqcells.Add(x,25,lq_dic["tcdc_c12"]+"",cellXF);
            lqcell2 = lqcells.Add(x, 26, lq_dic["tcdc_c13"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 28, lq_dic["tcdc_c14"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 29, lq_dic["tcdc_c15"] + "", cellXF);

            //====================

            x =  1 + x;
            //=========================加快建设================
            MergeArea meaAjkjs1 = new MergeArea(x, x, 1, 7);
            sheetlq.AddMergeArea(meaAjkjs1);
            System.Data.DataTable dtlq4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','lqy',2)");

            lqcell2 = lqcells.Add(x, 1, "二、加快建设（项目共计：" + dtlq4.Rows.Count + "个；总投资：" + lq_dic["jkjs_total"] + "万元；" + year + "年计划投资：" + lq_dic["jkjs_c11"] + "万元。）", lqcellXF);
            x = x + 1;
           
            for (int i = 0; i < dtlq4.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtlq4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dtlq4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtlq4.Rows.Count + x;
            lqcell2 = lqcells.Add(x, 1, dtlq4.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计", cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["jkjs_c1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 9, lq_dic["jkjs_c4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["jkjs_c5"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["jkjs_c6"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["jkjs_c7"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 13, lq_dic["jkjs_c8"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 14, lq_dic["jkjs_c9"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 15, lq_dic["jkjs_c10"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 16, lq_dic["jkjs_c11"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 25, lq_dic["jkjs_c12"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 26, lq_dic["jkjs_c13"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 28, lq_dic["jkjs_c14"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 29, lq_dic["jkjs_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================促进开工================
            MergeArea meaAcjkg1 = new MergeArea(x, x, 1, 7);
            sheetlq.AddMergeArea(meaAcjkg1);
            System.Data.DataTable dtlq6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','lqy',2)");
            lqcell2 = lqcells.Add(x, 1, "三、促进开工（项目共计：" + dtlq6.Rows.Count + "个；总投资：" + lq_dic["cjkg_total"] + "万元；" + System.DateTime.Now.Year + "年计划投资：" + lq_dic["cjkg_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtlq6.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtlq6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dtlq6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtlq6.Rows.Count + x;
            lqcell2 = lqcells.Add(x, 1, dtlq6.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计",cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["cjkg_c1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 9, lq_dic["cjkg_c4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["cjkg_c5"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["cjkg_c6"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["cjkg_c7"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 13, lq_dic["cjkg_c8"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 14, lq_dic["cjkg_c9"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 15, lq_dic["cjkg_c10"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 16, lq_dic["cjkg_c11"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 25, lq_dic["cjkg_c12"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 26, lq_dic["cjkg_c13"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 28, lq_dic["cjkg_c14"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 29, lq_dic["cjkg_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================前期储备================
            MergeArea meaAqqcb1 = new MergeArea(x, x, 1, 7);
            sheetlq.AddMergeArea(meaAqqcb1);

            System.Data.DataTable dtlq8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','lqy',2)");
            lqcell2 = lqcells.Add(x, 1, "四、前期储备（项目共计：" + dtlq8.Rows.Count + "个；总投资：" + lq_dic["qqcb_total"] + "万元；" + System.DateTime.Now.Year + "年计划投资：" + lq_dic["qqcb_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtlq8.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtlq8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dtlq8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = x + dtlq8.Rows.Count;
            //小计========
          //  x = x + 1;

            lqcell2 = lqcells.Add(x, 1, dtlq8.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计",cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["qqcb_c1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 9, lq_dic["qqcb_c4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["qqcb_c5"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["qqcb_c6"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["qqcb_c7"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 13, lq_dic["qqcb_c8"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 14, lq_dic["qqcb_c9"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 15, lq_dic["qqcb_c10"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 16, lq_dic["qqcb_c11"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 25, lq_dic["qqcb_c12"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 26, lq_dic["qqcb_c13"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 28, lq_dic["qqcb_c14"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 29, lq_dic["qqcb_c15"] + "", cellXF);
            x = x + 1;

            lqcell2 = lqcells.Add(x, 1, dtlq2.Rows.Count + dtlq4.Rows.Count + dtlq6.Rows.Count + dtlq8.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "总合计",cellXF);
            lqcell2 = lqcells.Add(x, 8, (decimal.Parse(lq_dic["qqcb_c1"]) + decimal.Parse(lq_dic["jkjs_c1"]) + decimal.Parse(lq_dic["cjkg_c1"]) + decimal.Parse(lq_dic["tcdc_c1"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 9, (decimal.Parse(lq_dic["qqcb_c4"]) + decimal.Parse(lq_dic["jkjs_c4"]) + decimal.Parse(lq_dic["cjkg_c4"]) + decimal.Parse(lq_dic["tcdc_c4"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, (decimal.Parse(lq_dic["qqcb_c5"]) + decimal.Parse(lq_dic["jkjs_c5"]) + decimal.Parse(lq_dic["cjkg_c5"]) + decimal.Parse(lq_dic["tcdc_c5"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, (decimal.Parse(lq_dic["qqcb_c6"]) + decimal.Parse(lq_dic["jkjs_c6"]) + decimal.Parse(lq_dic["cjkg_c6"]) + decimal.Parse(lq_dic["tcdc_c6"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, (decimal.Parse(lq_dic["qqcb_c7"]) + decimal.Parse(lq_dic["jkjs_c7"]) + decimal.Parse(lq_dic["cjkg_c7"]) + decimal.Parse(lq_dic["tcdc_c7"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 13, (decimal.Parse(lq_dic["qqcb_c8"]) + decimal.Parse(lq_dic["jkjs_c8"]) + decimal.Parse(lq_dic["cjkg_c8"]) + decimal.Parse(lq_dic["tcdc_c8"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 14, (decimal.Parse(lq_dic["qqcb_c9"]) + decimal.Parse(lq_dic["jkjs_c9"]) + decimal.Parse(lq_dic["cjkg_c9"]) + decimal.Parse(lq_dic["tcdc_c9"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 15, (decimal.Parse(lq_dic["qqcb_c10"]) + decimal.Parse(lq_dic["jkjs_c10"]) + decimal.Parse(lq_dic["cjkg_c10"]) + decimal.Parse(lq_dic["tcdc_c10"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 16, (decimal.Parse(lq_dic["qqcb_c11"]) + decimal.Parse(lq_dic["jkjs_c11"]) + decimal.Parse(lq_dic["cjkg_c11"]) + decimal.Parse(lq_dic["tcdc_c11"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 25, (decimal.Parse(lq_dic["qqcb_c12"])+decimal.Parse(lq_dic["jkjs_c12"])+decimal.Parse(lq_dic["cjkg_c12"])+decimal.Parse(lq_dic["tcdc_c12"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 26, (decimal.Parse(lq_dic["qqcb_c13"])+decimal.Parse(lq_dic["jkjs_c13"])+decimal.Parse(lq_dic["cjkg_c13"])+decimal.Parse(lq_dic["tcdc_c13"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 28, (decimal.Parse(lq_dic["qqcb_c14"])+decimal.Parse(lq_dic["jkjs_c14"])+decimal.Parse(lq_dic["cjkg_c14"])+decimal.Parse(lq_dic["tcdc_c14"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 29, (decimal.Parse(lq_dic["qqcb_c15"])+decimal.Parse(lq_dic["jkjs_c15"])+decimal.Parse(lq_dic["cjkg_c15"])+decimal.Parse(lq_dic["tcdc_c15"])) + "", cellXF);
            //====================

            ///===========================表头
            MergeArea lqmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetlq.AddMergeArea(lqmeaAttaddre);
            lqcell2 = lqcells.Add(3, 2, "填报单位（盖章）");

            MergeArea lqmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetlq.AddMergeArea(lqmeaAttname);
            lqcell2 = lqcells.Add(3, 4, "填报人：");
            MergeArea lqmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetlq.AddMergeArea(lqmeaAttname1);
            lqcell2 = lqcells.Add(3, 6, "审核人：");

            MergeArea lqmeaAtt = new MergeArea(3, 3, 10, 17);
            sheetlq.AddMergeArea(lqmeaAtt);
            lqcell2 = lqcells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(lq_dic["tcdc_c14"]) + decimal.Parse(lq_dic["cjkg_c14"]) + decimal.Parse(lq_dic["jkjs_c14"]) + decimal.Parse(lq_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea lqmeaAttu = new MergeArea(3, 3, 28, 29);
            sheetlq.AddMergeArea(lqmeaAttu);
            lqcell2 = lqcells.Add(3, 28, "单位：万元、亩");


            //==========================双流========================================
            string sheetslName = "双流";
            Worksheet sheetsl = xls.Workbook.Worksheets.Add(sheetslName);//填加名为"总表"的sheetsl页

            Cells slcells = sheetsl.Cells;//Cells实例是sheetsl页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF slcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            slcellXF.Font.FontName = "宋体";//设定字体
            slcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            slcellXF.UseBorder = true;//使用边框
            slcellXF.TextWrapRight = true;//自动换行
            slcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            slcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = slcells.AddValueCellXF(2, 2, "震", slcellXF);//以设定好的格式填加cell
            //slcellXF.Font.FontName = "宋体";
            //cell = slcells.AddValueCellXF(3, 2, "救", slcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea slmeaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 20 * 20;
            slcellXF.Font.Bold = true;
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell = slcells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", slcellXF);
            //==============================================设置表头===============================================//

            sheetsl.AddColumnInfo(col1);//把格式附加到sheet页上
            MergeArea slmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA1);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 15 * 15;
            slcellXF.BottomLineStyle = 1;
            slcellXF.BottomLineColor = Colors.Black;
            slcellXF.Font.Bold = true;
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    slcell2 = slcells.Add(j, i, "", cellXF);
            }

             slcell2 = slcells.Add(4, 1, "序号", slcellXF);
            //=============
            slcell2.Font.FontName = "Times New Roman";
            MergeArea slmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetsl.AddMergeArea(slmeaA2);
            slcell2 = slcells.Add(4, 2, "所属区县", slcellXF);
            MergeArea slmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetsl.AddMergeArea(slmeaA3);
            slcell2 = slcells.Add(4, 3, "项目名称", slcellXF);
            MergeArea slmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetsl.AddMergeArea(slmeaA4);
            slcell2 = slcells.Add(4, 4, "建设地址", slcellXF);
            MergeArea slmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetsl.AddMergeArea(slmeaA5);
            slcell2 = slcells.Add(4, 5, "建设年限", slcellXF);
            MergeArea slmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetsl.AddMergeArea(slmeaA6);
            slcell2 = slcells.Add(4, 6, "建设性质", slcellXF);
            MergeArea slmeaA7 = new MergeArea(4, 6, 7, 7);
            sheetsl.AddMergeArea(slmeaA7);
            slcell2 = slcells.Add(4, 7, "建设内容及规模", slcellXF);
            MergeArea slmeaA8 = new MergeArea(4, 6, 8, 8);
            sheetsl.AddMergeArea(slmeaA8);
            slcell2 = slcells.Add(4, 8, "总投资", slcellXF);

            MergeArea slmeaAt9 = new MergeArea(4, 4, 9, 14);
            sheetsl.AddMergeArea(slmeaAt9);
            slcell2 = slcells.Add(4, 9, "资金构成", slcellXF);

            MergeArea slmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetsl.AddMergeArea(slmeaA9);
            slcell2 = slcells.Add(5, 9, "中央资金", slcellXF);
            MergeArea slmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetsl.AddMergeArea(slmeaA10);
            slcell2 = slcells.Add(5, 10, "省级资金", slcellXF);

            MergeArea slmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetsl.AddMergeArea(slmeaA11);
            slcell2 = slcells.Add(5, 11, "市级资金", slcellXF);

            MergeArea slmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetsl.AddMergeArea(slmeaA12);
            slcell2 = slcells.Add(5, 12, "区县资金", slcellXF);

            MergeArea slmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetsl.AddMergeArea(slmeaA13);
            slcell2 = slcells.Add(5, 13, "银行贷款", slcellXF);
            MergeArea slmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetsl.AddMergeArea(slmeaA14);
            slcell2 = slcells.Add(5, 14, "企业自筹", slcellXF);

            MergeArea slmeaA15 = new MergeArea(4, 6, 15, 15);
            sheetsl.AddMergeArea(slmeaA15);
            slcell2 = slcells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", slcellXF);
            MergeArea slmeaA16 = new MergeArea(4, 6, 16, 16);
            sheetsl.AddMergeArea(slmeaA16);
            slcell2 = slcells.Add(4, 16, year+"年计划投资", slcellXF);

            MergeArea slmeaA17 = new MergeArea(4, 6, 17, 17);
            sheetsl.AddMergeArea(slmeaA17);
            slcell2 = slcells.Add(4, 17, "目前为止项目形象进度", slcellXF);

            MergeArea slmeaAt18 = new MergeArea(4, 4, 18, 21);
            sheetsl.AddMergeArea(slmeaAt18);
            slcell2 = slcells.Add(4, 18, "项目业主", slcellXF);

            MergeArea slmeaA18 = new MergeArea(5, 6, 18, 18);
            sheetsl.AddMergeArea(slmeaA18);
            slcell2 = slcells.Add(5, 18, "单位名称", slcellXF);
            MergeArea slmeaA19 = new MergeArea(5, 6, 19, 19);
            sheetsl.AddMergeArea(slmeaA19);
            slcell2 = slcells.Add(5, 19, "法人代表", slcellXF);

            MergeArea slmeaA20 = new MergeArea(5, 6, 20, 20);
            sheetsl.AddMergeArea(slmeaA20);
            slcell2 = slcells.Add(5, 20, "业主联系人", slcellXF);

            MergeArea slmeaA21 = new MergeArea(5, 6, 21, 21);
            sheetsl.AddMergeArea(slmeaA21);
            slcell2 = slcells.Add(5, 21, "联系电话", slcellXF);
            MergeArea slmeaA22 = new MergeArea(4, 6, 22, 22);
            sheetsl.AddMergeArea(slmeaA22);
            slcell2 = slcells.Add(4, 22, "开工（计划开工）时间", slcellXF);

            MergeArea slmeaA23 = new MergeArea(4, 6, 23, 23);
            sheetsl.AddMergeArea(slmeaA23);
            slcell2 = slcells.Add(4, 23, "计划竣工时间", slcellXF);

            MergeArea slmeaA24 = new MergeArea(4, 6, 24, 24);
            sheetsl.AddMergeArea(slmeaA24);
            slcell2 = slcells.Add(4, 24, "四个一批范筹", slcellXF);

            MergeArea slmeaA25 = new MergeArea(4, 6, 25, 25);
            sheetsl.AddMergeArea(slmeaA25);
            slcell2 = slcells.Add(4, 25, "已取得土地指标（亩）", slcellXF);

            MergeArea slmeaA26 = new MergeArea(4, 6, 26, 26);
            sheetsl.AddMergeArea(slmeaA26);
            slcell2 = slcells.Add(4, 26, "拟申请土地指标（亩）", slcellXF);

            MergeArea slmeaA27 = new MergeArea(4, 6, 27, 27);
            sheetsl.AddMergeArea(slmeaA27);
            slcell2 = slcells.Add(4, 27, "是否政府投资项目", slcellXF);

            MergeArea slmeaA28 = new MergeArea(4, 6, 28, 28);
            sheetsl.AddMergeArea(slmeaA28);
            slcell2 = slcells.Add(4, 28, "1-"+month+"月累计完成投资额", slcellXF);

            MergeArea slmeaA29 = new MergeArea(4, 6, 29, 29);
            sheetsl.AddMergeArea(slmeaA29);
            slcell2 = slcells.Add(4, 29, month+"月累计完成投资额", slcellXF);

            MergeArea slmeaA30 = new MergeArea(4, 6, 30, 30);
            sheetsl.AddMergeArea(slmeaA30);
            slcell2 = slcells.Add(4, 30, "需协调解决问题", slcellXF);

            MergeArea slmeaA31 = new MergeArea(4, 6, 31, 31);
            sheetsl.AddMergeArea(slmeaA31);
            slcell2 = slcells.Add(4, 31, "备注", slcellXF);

            x = 7;
            MergeArea meaAtcdc2 = new MergeArea(x, x, 1, 7);
            sheetsl.AddMergeArea(meaAtcdc2);
            System.Data.DataTable dtsl2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','sl',2)");

            slcell2 = slcells.Add(x, 1, "一、投产达产（项目共计：" + dtsl2.Rows.Count + "个；总投资：" + sl_dic["tcdc_total"] + "万元；" + year + "年计划投资：" + sl_dic["tcdc_c11"] + "万元。）", slcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtsl2.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtsl2.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dtsl2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = dtsl2.Rows.Count + x;
            slcell2 = slcells.Add(x, 1, dtsl2.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计",cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["tcdc_c1"] + "", cellXF);
            slcell2 = slcells.Add(x, 9, sl_dic["tcdc_c4"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["tcdc_c5"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["tcdc_c6"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["tcdc_c7"] + "", cellXF);
            slcell2 = slcells.Add(x, 13, sl_dic["tcdc_c8"] + "", cellXF);
            slcell2 = slcells.Add(x, 14, sl_dic["tcdc_c9"] + "", cellXF);
            slcell2 = slcells.Add(x, 15, sl_dic["tcdc_c10"] + "", cellXF);
            slcell2 = slcells.Add(x, 16, sl_dic["tcdc_c11"] + "", cellXF);

            slcell2 = slcells.Add(x, 25, sl_dic["tcdc_c12"] + "", cellXF);
            slcell2 = slcells.Add(x, 26, sl_dic["tcdc_c13"] + "", cellXF);
            slcell2 = slcells.Add(x, 28, sl_dic["tcdc_c14"] + "", cellXF);
            slcell2 = slcells.Add(x, 29, sl_dic["tcdc_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================加快建设================
            MergeArea meaAjkjs2 = new MergeArea(x, x, 1, 7);
            sheetsl.AddMergeArea(meaAjkjs2);
            System.Data.DataTable dtsl4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','sl',2)");
            slcell2 = slcells.Add(x, 1, "二、加快建设（项目共计：" + dtsl4.Rows.Count + "个；总投资：" + sl_dic["jkjs_total"] + "万元；" + year + "年计划投资：" + sl_dic["jkjs_c11"] + "万元。）", lqcellXF);
            x = x + 1;
        
            for (int i = 0; i < dtsl4.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtsl4.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dtsl4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = dtsl4.Rows.Count  + x;
            slcell2 = slcells.Add(x, 1, dtsl4.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计",cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["jkjs_c1"] + "", cellXF);
            slcell2 = slcells.Add(x, 9, sl_dic["jkjs_c4"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["jkjs_c5"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["jkjs_c6"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["jkjs_c7"] + "", cellXF);
            slcell2 = slcells.Add(x, 13, sl_dic["jkjs_c8"] + "", cellXF);
            slcell2 = slcells.Add(x, 14, sl_dic["jkjs_c9"] + "", cellXF);
            slcell2 = slcells.Add(x, 15, sl_dic["jkjs_c10"] + "", cellXF);
            slcell2 = slcells.Add(x, 16, sl_dic["jkjs_c11"] + "", cellXF);
            slcell2 = slcells.Add(x, 25, sl_dic["jkjs_c12"] + "", cellXF);
            slcell2 = slcells.Add(x, 26, sl_dic["jkjs_c13"] + "", cellXF);
            slcell2 = slcells.Add(x, 28, sl_dic["jkjs_c14"] + "", cellXF);
            slcell2 = slcells.Add(x, 29, sl_dic["jkjs_c15"] + "", cellXF);

            //====================

            x =  1 + x;
            //=========================促进开工================
            MergeArea meaAcjkg2 = new MergeArea(x, x, 1, 7);
            sheetsl.AddMergeArea(meaAcjkg2);

            System.Data.DataTable dtsl6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','sl',2)");
            slcell2 = slcells.Add(x, 1, "三、促进开工（项目共计：" + dtsl6.Rows.Count + "个；总投资：" + sl_dic["cjkg_total"] + "万元；" + year + "年计划投资：" + sl_dic["cjkg_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtsl6.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtsl6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    slcell2 = lqcells.Add(i + x, j + 2, dtsl6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtsl6.Rows.Count  + x;
            slcell2 = slcells.Add(x, 1, dtsl6.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计",cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["cjkg_c1"] + "", cellXF);
            slcell2 = slcells.Add(x, 9, sl_dic["cjkg_c4"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["cjkg_c5"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["cjkg_c6"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["cjkg_c7"] + "", cellXF);
            slcell2 = slcells.Add(x, 13, sl_dic["cjkg_c8"] + "", cellXF);
            slcell2 = slcells.Add(x, 14, sl_dic["cjkg_c9"] + "", cellXF);
            slcell2 = slcells.Add(x, 15, sl_dic["cjkg_c10"] + "", cellXF);
            slcell2 = slcells.Add(x, 16, sl_dic["cjkg_c11"] + "", cellXF);
            slcell2 = slcells.Add(x, 25, sl_dic["cjkg_c12"] + "", cellXF);
            slcell2 = slcells.Add(x, 26, sl_dic["cjkg_c13"] + "", cellXF);
            slcell2 = slcells.Add(x, 28, sl_dic["cjkg_c14"] + "", cellXF);
            slcell2 = slcells.Add(x, 29, sl_dic["cjkg_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================前期储备================
            MergeArea meaAqqcb2 = new MergeArea(x, x, 1, 7);
            sheetsl.AddMergeArea(meaAqqcb2);
            System.Data.DataTable dtsl8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','sl',2)");
            slcell2 = slcells.Add(x, 1, "四、前期储备（项目共计：" + dtsl8.Rows.Count + "个；总投资：" + sl_dic["qqcb_total"] + "万元；" + year+ "年计划投资：" + sl_dic["qqcb_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtsl8.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtsl8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dtsl8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = x + dtsl8.Rows.Count;

            slcell2 = slcells.Add(x, 1, dtsl8.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计",cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["qqcb_c1"] + "", cellXF);
            slcell2 = slcells.Add(x, 9, sl_dic["qqcb_c4"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["qqcb_c5"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["qqcb_c6"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["qqcb_c7"] + "", cellXF);
            slcell2 = slcells.Add(x, 13, sl_dic["qqcb_c8"] + "", cellXF);
            slcell2 = slcells.Add(x, 14, sl_dic["qqcb_c9"] + "", cellXF);
            slcell2 = slcells.Add(x, 15, sl_dic["qqcb_c10"] + "", cellXF);
            slcell2 = slcells.Add(x, 16, sl_dic["qqcb_c11"] + "", cellXF);

            slcell2 = slcells.Add(x, 25, sl_dic["qqcb_c12"] + "", cellXF);
            slcell2 = slcells.Add(x, 26, sl_dic["qqcb_c13"] + "", cellXF);
            slcell2 = slcells.Add(x, 28, sl_dic["qqcb_c14"] + "", cellXF);
            slcell2 = slcells.Add(x, 29, sl_dic["qqcb_c15"] + "", cellXF);
            x = x + 1;

            slcell2 = slcells.Add(x, 1, dtsl2.Rows.Count + dtsl4.Rows.Count + dtsl6.Rows.Count + dtsl8.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "总合计", cellXF);
            slcell2 = slcells.Add(x, 8, (decimal.Parse(sl_dic["qqcb_c1"]) + decimal.Parse(sl_dic["cjkg_c1"]) + decimal.Parse(sl_dic["jkjs_c1"]) + decimal.Parse(sl_dic["tcdc_c1"])) + "", cellXF);
            slcell2 = slcells.Add(x, 9, (decimal.Parse(sl_dic["qqcb_c4"]) + decimal.Parse(sl_dic["cjkg_c4"]) + decimal.Parse(sl_dic["jkjs_c4"]) + decimal.Parse(sl_dic["tcdc_c4"])) + "", cellXF);
            slcell2 = slcells.Add(x, 10, (decimal.Parse(sl_dic["qqcb_c5"]) + decimal.Parse(sl_dic["cjkg_c5"]) + decimal.Parse(sl_dic["jkjs_c5"]) + decimal.Parse(sl_dic["tcdc_c5"])) + "", cellXF);
            slcell2 = slcells.Add(x, 11, (decimal.Parse(sl_dic["qqcb_c6"]) + decimal.Parse(sl_dic["cjkg_c6"]) + decimal.Parse(sl_dic["jkjs_c6"]) + decimal.Parse(sl_dic["tcdc_c6"])) + "", cellXF);
            slcell2 = slcells.Add(x, 12, (decimal.Parse(sl_dic["qqcb_c7"]) + decimal.Parse(sl_dic["cjkg_c7"]) + decimal.Parse(sl_dic["jkjs_c7"]) + decimal.Parse(sl_dic["tcdc_c7"])) + "", cellXF);
            slcell2 = slcells.Add(x, 13, (decimal.Parse(sl_dic["qqcb_c8"]) + decimal.Parse(sl_dic["cjkg_c8"]) + decimal.Parse(sl_dic["jkjs_c8"]) + decimal.Parse(sl_dic["tcdc_c8"])) + "", cellXF);
            slcell2 = slcells.Add(x, 14, (decimal.Parse(sl_dic["qqcb_c9"]) + decimal.Parse(sl_dic["cjkg_c9"]) + decimal.Parse(sl_dic["jkjs_c9"]) + decimal.Parse(sl_dic["tcdc_c9"])) + "", cellXF);
            slcell2 = slcells.Add(x, 15, (decimal.Parse(sl_dic["qqcb_c10"]) + decimal.Parse(sl_dic["cjkg_c10"]) + decimal.Parse(sl_dic["jkjs_c10"]) + decimal.Parse(sl_dic["tcdc_c10"])) + "", cellXF);
            slcell2 = slcells.Add(x, 16, (decimal.Parse(sl_dic["qqcb_c11"]) + decimal.Parse(sl_dic["cjkg_c11"]) + decimal.Parse(sl_dic["jkjs_c11"]) + decimal.Parse(sl_dic["tcdc_c11"])) + "", cellXF);
            slcell2 = slcells.Add(x, 25, (decimal.Parse(sl_dic["qqcb_c12"])+decimal.Parse(sl_dic["cjkg_c12"])+decimal.Parse(sl_dic["jkjs_c12"])+decimal.Parse(sl_dic["tcdc_c12"])) + "", cellXF);
            slcell2 = slcells.Add(x, 26, (decimal.Parse(sl_dic["qqcb_c13"])+decimal.Parse(sl_dic["cjkg_c13"])+decimal.Parse(sl_dic["jkjs_c13"])+decimal.Parse(sl_dic["tcdc_c13"])) + "", cellXF);
            slcell2 = slcells.Add(x, 28, (decimal.Parse(sl_dic["qqcb_c14"])+decimal.Parse(sl_dic["cjkg_c14"])+decimal.Parse(sl_dic["jkjs_c14"])+decimal.Parse(sl_dic["tcdc_c14"])) + "", cellXF);
            slcell2 = slcells.Add(x, 29, (decimal.Parse(sl_dic["qqcb_c15"])+decimal.Parse(sl_dic["cjkg_c15"])+decimal.Parse(sl_dic["jkjs_c15"])+decimal.Parse(sl_dic["tcdc_c15"])) + "", cellXF);

            //====================

            ///===========================表头
            MergeArea slmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetsl.AddMergeArea(slmeaAttaddre);
            slcell2 = slcells.Add(3, 2, "填报单位（盖章）");

            MergeArea slmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetsl.AddMergeArea(slmeaAttname);
            slcell2 = slcells.Add(3, 4, "填报人：");


            MergeArea slmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetsl.AddMergeArea(slmeaAttname1);
            slcell2 = slcells.Add(3, 6, "审核人：");

            MergeArea slmeaAtt = new MergeArea(3, 3, 10, 17);
            sheetsl.AddMergeArea(slmeaAtt);
            slcell2 = slcells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(sl_dic["tcdc_c14"]) + decimal.Parse(sl_dic["cjkg_c14"]) + decimal.Parse(sl_dic["jkjs_c14"]) + decimal.Parse(sl_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea slmeaAttu = new MergeArea(3, 3, 28, 29);
            sheetsl.AddMergeArea(slmeaAttu);
            slcell2 = slcells.Add(3, 28, "单位：万元、亩");

            //===============================金堂===========================
            string sheetjtxName = "金堂";
            Worksheet sheetjtx = xls.Workbook.Worksheets.Add(sheetjtxName);//填加名为"总表"的sheetjtx页

            Cells jtxcells = sheetjtx.Cells;//Cells实例是sheetjtx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF jtxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            jtxcellXF.Font.FontName = "宋体";//设定字体
            jtxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            jtxcellXF.UseBorder = true;//使用边框
            jtxcellXF.TextWrapRight = true;//自动换行
            jtxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            jtxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = jtxcells.AddValueCellXF(2, 2, "震", jtxcellXF);//以设定好的格式填加cell
            //jtxcellXF.Font.FontName = "宋体";
            //cell = jtxcells.AddValueCellXF(3, 2, "救", jtxcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea jtxmeaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 20 * 20;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell jtxcell = jtxcells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", jtxcellXF);
            //==============================================设置表头===============================================//

            sheetjtx.AddColumnInfo(col1);//把格式附加到sheet页上
            MergeArea jtxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA1);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 15 * 15;
            jtxcellXF.BottomLineStyle = 1;
            jtxcellXF.BottomLineColor = Colors.Black;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

            Cell jtxcell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    jtxcell2 = jtxcells.Add(j, i, "", cellXF);
            }
             jtxcell2 = jtxcells.Add(4, 1, "序号", jtxcellXF);
            //=============
            jtxcell2.Font.FontName = "Times New Roman";
            MergeArea jtxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetjtx.AddMergeArea(jtxmeaA2);
            jtxcell2 = jtxcells.Add(4, 2, "所属区县", jtxcellXF);
            MergeArea jtxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetjtx.AddMergeArea(jtxmeaA3);
            jtxcell2 = jtxcells.Add(4, 3, "项目名称", jtxcellXF);
            MergeArea jtxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetjtx.AddMergeArea(jtxmeaA4);
            jtxcell2 = jtxcells.Add(4, 4, "建设地址", jtxcellXF);
            MergeArea jtxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetjtx.AddMergeArea(jtxmeaA5);
            jtxcell2 = jtxcells.Add(4, 5, "建设年限", jtxcellXF);
            MergeArea jtxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetjtx.AddMergeArea(jtxmeaA6);
            jtxcell2 = jtxcells.Add(4, 6, "建设性质", jtxcellXF);
            MergeArea jtxmeaA7 = new MergeArea(4, 6, 7, 7);
            sheetjtx.AddMergeArea(jtxmeaA7);
            jtxcell2 = jtxcells.Add(4, 7, "建设内容及规模", jtxcellXF);
            MergeArea jtxmeaA8 = new MergeArea(4, 6, 8, 8);
            sheetjtx.AddMergeArea(jtxmeaA8);
            jtxcell2 = jtxcells.Add(4, 8, "总投资", jtxcellXF);

            MergeArea jtxmeaAt9 = new MergeArea(4, 4, 9, 14);
            sheetjtx.AddMergeArea(jtxmeaAt9);
            jtxcell2 = jtxcells.Add(4, 9, "建设性质", jtxcellXF);

            MergeArea jtxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetjtx.AddMergeArea(jtxmeaA9);
            jtxcell2 = jtxcells.Add(5, 9, "中央资金", jtxcellXF);
            MergeArea jtxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetjtx.AddMergeArea(jtxmeaA10);
            jtxcell2 = jtxcells.Add(5, 10, "省级资金", jtxcellXF);

            MergeArea jtxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetjtx.AddMergeArea(jtxmeaA11);
            jtxcell2 = jtxcells.Add(5, 11, "市级资金", jtxcellXF);

            MergeArea jtxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetjtx.AddMergeArea(jtxmeaA12);
            jtxcell2 = jtxcells.Add(5, 12, "区县资金", jtxcellXF);

            MergeArea jtxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetjtx.AddMergeArea(jtxmeaA13);
            jtxcell2 = jtxcells.Add(5, 13, "银行贷款", jtxcellXF);
            MergeArea jtxmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetjtx.AddMergeArea(jtxmeaA14);
            jtxcell2 = jtxcells.Add(5, 14, "企业自筹", jtxcellXF);
            MergeArea jtxmeaA15 = new MergeArea(4, 6, 15, 15);
            sheetjtx.AddMergeArea(jtxmeaA15);
            jtxcell2 = jtxcells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", jtxcellXF);
            MergeArea jtxmeaA16 = new MergeArea(4, 6, 16, 16);
            sheetjtx.AddMergeArea(jtxmeaA16);
            jtxcell2 = jtxcells.Add(4, 16, year+"年计划投资", jtxcellXF);

            MergeArea jtxmeaA17 = new MergeArea(4, 6, 17, 17);
            sheetjtx.AddMergeArea(jtxmeaA17);
            jtxcell2 = jtxcells.Add(4, 17, "目前为止项目形象进度", jtxcellXF);

            MergeArea jtxmeaAt18 = new MergeArea(4, 4, 18, 21);
            sheetjtx.AddMergeArea(jtxmeaAt18);
            jtxcell2 = jtxcells.Add(4, 18, "项目业主", jtxcellXF);

            MergeArea jtxmeaA18 = new MergeArea(5, 6, 18, 18);
            sheetjtx.AddMergeArea(jtxmeaA18);
            jtxcell2 = jtxcells.Add(5, 18, "单位名称", jtxcellXF);
            MergeArea jtxmeaA19 = new MergeArea(5, 6, 19, 19);
            sheetjtx.AddMergeArea(jtxmeaA19);
            jtxcell2 = jtxcells.Add(5, 19, "法人代表", jtxcellXF);

            MergeArea jtxmeaA20 = new MergeArea(5, 6, 20, 20);
            sheetjtx.AddMergeArea(jtxmeaA20);
            jtxcell2 = jtxcells.Add(5, 20, "业主联系人", jtxcellXF);

            MergeArea jtxmeaA21 = new MergeArea(5, 6, 21, 21);
            sheetjtx.AddMergeArea(jtxmeaA21);
            jtxcell2 = jtxcells.Add(5, 21, "联系电话", jtxcellXF);
            MergeArea jtxmeaA22 = new MergeArea(4, 6, 22, 22);
            sheetjtx.AddMergeArea(jtxmeaA22);
            jtxcell2 = jtxcells.Add(4, 22, "开工（计划开工）时间", jtxcellXF);

            MergeArea jtxmeaA23 = new MergeArea(4, 6, 23, 23);
            sheetjtx.AddMergeArea(jtxmeaA23);
            jtxcell2 = jtxcells.Add(4, 23, "计划竣工时间", jtxcellXF);

            MergeArea jtxmeaA24 = new MergeArea(4, 6, 24, 24);
            sheetjtx.AddMergeArea(jtxmeaA24);
            jtxcell2 = jtxcells.Add(4, 24, "四个一批范筹", jtxcellXF);

            MergeArea jtxmeaA25 = new MergeArea(4, 6, 25, 25);
            sheetjtx.AddMergeArea(jtxmeaA25);
            jtxcell2 = jtxcells.Add(4, 25, "已取得土地指标（亩）", jtxcellXF);

            MergeArea jtxmeaA26 = new MergeArea(4, 6, 26, 26);
            sheetjtx.AddMergeArea(jtxmeaA26);
            jtxcell2 = jtxcells.Add(4, 26, "拟申请土地指标（亩）", jtxcellXF);

            MergeArea jtxmeaA27 = new MergeArea(4, 6, 27, 27);
            sheetjtx.AddMergeArea(jtxmeaA27);
            jtxcell2 = jtxcells.Add(4, 27, "是否政府投资项目", jtxcellXF);

            MergeArea jtxmeaA28 = new MergeArea(4, 6, 28, 28);
            sheetjtx.AddMergeArea(jtxmeaA28);
            jtxcell2 = jtxcells.Add(4, 28, "1-"+month+"月累计完成投资额", jtxcellXF);

            MergeArea jtxmeaA29 = new MergeArea(4, 6, 29, 29);
            sheetjtx.AddMergeArea(jtxmeaA29);
            jtxcell2 = jtxcells.Add(4, 29, month+"月累计完成投资额", jtxcellXF);

            MergeArea jtxmeaA30 = new MergeArea(4, 6, 30, 30);
            sheetjtx.AddMergeArea(jtxmeaA30);
            jtxcell2 = jtxcells.Add(4, 30, "需协调解决问题", jtxcellXF);

            MergeArea jtxmeaA31 = new MergeArea(4, 6, 31, 31);
            sheetjtx.AddMergeArea(jtxmeaA31);
            jtxcell2 = jtxcells.Add(4, 31, "备注", jtxcellXF);

            x = 7;
            MergeArea meaAtcdc3 = new MergeArea(x, x, 1, 7);
            sheetjtx.AddMergeArea(meaAtcdc3);

            System.Data.DataTable dtjtx2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','jt',2)");
            jtxcell2 = jtxcells.Add(x, 1, "一、投产达产（项目共计：" + dtjtx2.Rows.Count + "个；总投资：" + jt_dic["tcdc_total"] + "万元；" + year + "年计划投资：" + jt_dic["tcdc_c11"] + "万元。）", slcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtjtx2.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtjtx2.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dtjtx2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtjtx2.Rows.Count  + x;
            jtxcell2 = jtxcells.Add(x, 1, dtjtx2.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["tcdc_c1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 9, jt_dic["tcdc_c4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["tcdc_c5"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["tcdc_c6"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["tcdc_c7"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 13, jt_dic["tcdc_c8"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 14, jt_dic["tcdc_c9"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 15, jt_dic["tcdc_c10"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 16, jt_dic["tcdc_c11"] + "", cellXF);

            jtxcell2 = jtxcells.Add(x, 25, jt_dic["tcdc_c12"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 26, jt_dic["tcdc_c13"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 28, jt_dic["tcdc_c14"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 29, jt_dic["tcdc_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================加快建设================
            MergeArea meaAjkjs3 = new MergeArea(x, x, 1, 7);
            sheetjtx.AddMergeArea(meaAjkjs3);
            System.Data.DataTable dtjtx4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','jt',2)");
            jtxcell2 = jtxcells.Add(x, 1, "二、加快建设（项目共计：" + dtjtx4.Rows.Count + "个；总投资：" + jt_dic["jkjs_total"] + "万元；" + year + "年计划投资：" + jt_dic["jkjs_c11"] + "万元。）", lqcellXF);
            x = x + 1;
         
            for (int i = 0; i < dtjtx4.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtjtx4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dtjtx4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtjtx4.Rows.Count + x;
            jtxcell2 = jtxcells.Add(x, 1, dtjtx4.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计",cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["jkjs_c1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 9, jt_dic["jkjs_c4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["jkjs_c5"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["jkjs_c6"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["jkjs_c7"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 13, jt_dic["jkjs_c8"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 14, jt_dic["jkjs_c9"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 15, jt_dic["jkjs_c10"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 16, jt_dic["jkjs_c11"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 25, jt_dic["jkjs_c12"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 26, jt_dic["jkjs_c13"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 28, jt_dic["jkjs_c14"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 29, jt_dic["jkjs_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================促进开工================
            MergeArea meaAcjkg3 = new MergeArea(x, x, 1, 7);
            sheetjtx.AddMergeArea(meaAcjkg3);
            System.Data.DataTable dtjtx6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','jt',2)");
            jtxcell2 = jtxcells.Add(x, 1, "三、促进开工（项目共计：" + dtjtx6.Rows.Count + "个；总投资：" + jt_dic["cjkg_total"] + "万元；" + year + "年计划投资：" + jt_dic["cjkg_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtjtx6.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtjtx6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dtjtx6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtjtx6.Rows.Count + x;
            jtxcell2 = jtxcells.Add(x, 1, dtjtx6.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计",cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["cjkg_c1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 9, jt_dic["cjkg_c4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["cjkg_c5"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["cjkg_c6"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["cjkg_c7"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 13, jt_dic["cjkg_c8"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 14, jt_dic["cjkg_c9"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 15, jt_dic["cjkg_c10"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 16, jt_dic["cjkg_c11"] + "", cellXF);

            jtxcell2 = jtxcells.Add(x, 25, jt_dic["cjkg_c12"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 26, jt_dic["cjkg_c13"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 28, jt_dic["cjkg_c14"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 29, jt_dic["cjkg_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================前期储备================
            MergeArea meaAqqcb3 = new MergeArea(x, x, 1, 7);
            sheetjtx.AddMergeArea(meaAqqcb3);
            System.Data.DataTable dtjtx8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','jt',2)");
            jtxcell2 = jtxcells.Add(x, 1, "四、前期储备（项目共计：" + dtjtx8.Rows.Count + "个；总投资：" + jt_dic["qqcb_total"] + "万元；" + year + "年计划投资：" + jt_dic["qqcb_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtjtx8.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtjtx8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dtjtx8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = x + dtjtx8.Rows.Count;

            jtxcell2 = jtxcells.Add(x, 1, dtjtx8.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计",cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["qqcb_c1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 9, jt_dic["qqcb_c4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["qqcb_c5"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["qqcb_c6"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["qqcb_c7"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 13, jt_dic["qqcb_c8"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 14, jt_dic["qqcb_c9"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 15, jt_dic["qqcb_c10"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 16, jt_dic["qqcb_c11"] + "", cellXF);

            jtxcell2 = jtxcells.Add(x, 25, jt_dic["qqcb_c12"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 26, jt_dic["qqcb_c13"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 28, jt_dic["qqcb_c14"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 29, jt_dic["qqcb_c15"] + "", cellXF);
            x = x + 1;

            jtxcell2 = jtxcells.Add(x, 1, dtjtx2.Rows.Count + dtjtx4.Rows.Count + dtjtx6.Rows.Count + dtjtx8.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "总合计", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, (decimal.Parse(jt_dic["qqcb_c1"]) + decimal.Parse(jt_dic["jkjs_c1"]) + decimal.Parse(jt_dic["cjkg_c1"]) + decimal.Parse(jt_dic["tcdc_c1"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 9, (decimal.Parse(jt_dic["qqcb_c4"]) + decimal.Parse(jt_dic["jkjs_c4"]) + decimal.Parse(jt_dic["cjkg_c4"]) + decimal.Parse(jt_dic["tcdc_c4"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, (decimal.Parse(jt_dic["qqcb_c5"]) + decimal.Parse(jt_dic["jkjs_c5"]) + decimal.Parse(jt_dic["cjkg_c5"]) + decimal.Parse(jt_dic["tcdc_c5"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, (decimal.Parse(jt_dic["qqcb_c6"]) + decimal.Parse(jt_dic["jkjs_c6"]) + decimal.Parse(jt_dic["cjkg_c6"]) + decimal.Parse(jt_dic["tcdc_c6"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, (decimal.Parse(jt_dic["qqcb_c7"]) + decimal.Parse(jt_dic["jkjs_c7"]) + decimal.Parse(jt_dic["cjkg_c7"]) + decimal.Parse(jt_dic["tcdc_c7"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 13, (decimal.Parse(jt_dic["qqcb_c8"]) + decimal.Parse(jt_dic["jkjs_c8"]) + decimal.Parse(jt_dic["cjkg_c8"]) + decimal.Parse(jt_dic["tcdc_c8"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 14, (decimal.Parse(jt_dic["qqcb_c9"]) + decimal.Parse(jt_dic["jkjs_c9"]) + decimal.Parse(jt_dic["cjkg_c9"]) + decimal.Parse(jt_dic["tcdc_c9"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 15, (decimal.Parse(jt_dic["qqcb_c10"]) + decimal.Parse(jt_dic["jkjs_c10"]) + decimal.Parse(jt_dic["cjkg_c10"]) + decimal.Parse(jt_dic["tcdc_c10"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 16, (decimal.Parse(jt_dic["qqcb_c11"]) + decimal.Parse(jt_dic["jkjs_c11"]) + decimal.Parse(jt_dic["cjkg_c11"]) + decimal.Parse(jt_dic["tcdc_c11"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 25, (decimal.Parse(jt_dic["qqcb_c12"])+decimal.Parse(jt_dic["jkjs_c12"])+decimal.Parse(jt_dic["cjkg_c12"])+decimal.Parse(jt_dic["tcdc_c12"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 26, (decimal.Parse(jt_dic["qqcb_c13"]) + decimal.Parse(jt_dic["jkjs_c13"]) + decimal.Parse(jt_dic["cjkg_c13"]) + decimal.Parse(jt_dic["tcdc_c13"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 28, (decimal.Parse(jt_dic["qqcb_c14"]) + decimal.Parse(jt_dic["jkjs_c14"]) + decimal.Parse(jt_dic["cjkg_c14"]) + decimal.Parse(jt_dic["tcdc_c14"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 29, (decimal.Parse(jt_dic["qqcb_c15"]) + decimal.Parse(jt_dic["jkjs_c15"]) + decimal.Parse(jt_dic["cjkg_c12"]) + decimal.Parse(jt_dic["tcdc_c15"])) + "", cellXF);


            //====================
            ///===========================表头
            MergeArea jtxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetjtx.AddMergeArea(jtxmeaAttaddre);
            jtxcell2 = jtxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea jtxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetjtx.AddMergeArea(jtxmeaAttname);
            jtxcell2 = jtxcells.Add(3, 4, "填报人：");

            MergeArea jtxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetjtx.AddMergeArea(jtxmeaAttname1);
            jtxcell2 = jtxcells.Add(3, 6, "审核人：");

            MergeArea jtxmeaAtt = new MergeArea(3, 3, 10, 17);
            sheetjtx.AddMergeArea(jtxmeaAtt);
            jtxcell2 = jtxcells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(jt_dic["tcdc_c14"]) + decimal.Parse(jt_dic["cjkg_c14"]) + decimal.Parse(jt_dic["jkjs_c14"]) + decimal.Parse(jt_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea jtxmeaAttu = new MergeArea(3, 3, 28, 29);
            sheetjtx.AddMergeArea(jtxmeaAttu);
            jtxcell2 = jtxcells.Add(3, 28, "单位：万元、亩");

            //============================================青白江=================
            string sheetqbjName = "青白江";
            Worksheet sheetqbj = xls.Workbook.Worksheets.Add(sheetqbjName);//填加名为"总表"的sheetqbj页
            Cells qbjcells = sheetqbj.Cells;//Cells实例是sheetqbj页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbjcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbjcellXF.Font.FontName = "宋体";//设定字体
            qbjcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbjcellXF.UseBorder = true;//使用边框
            qbjcellXF.TextWrapRight = true;//自动换行
            qbjcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbjcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //===================================设置标题=====================================================//
            MergeArea qbjmeaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 20 * 20;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbjcell = qbjcells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", qbjcellXF);
            //==============================================设置表头===============================================//

            sheetqbj.AddColumnInfo(col1);//把格式附加到sheet页上
            MergeArea qbjmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA1);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 15 * 15;
            qbjcellXF.BottomLineStyle = 1;
            qbjcellXF.BottomLineColor = Colors.Black;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

            Cell qbjcell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    qbjcell2 = qbjcells.Add(j, i, "", cellXF);
            }

             qbjcell2 = qbjcells.Add(4, 1, "序号", qbjcellXF);
            //=============
            qbjcell2.Font.FontName = "Times New Roman";
            MergeArea qbjmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbj.AddMergeArea(qbjmeaA2);
            qbjcell2 = qbjcells.Add(4, 2, "所属区县", qbjcellXF);
            MergeArea qbjmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbj.AddMergeArea(qbjmeaA3);
            qbjcell2 = qbjcells.Add(4, 3, "项目名称", qbjcellXF);
            MergeArea qbjmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbj.AddMergeArea(qbjmeaA4);
            qbjcell2 = qbjcells.Add(4, 4, "建设地址", qbjcellXF);
            MergeArea qbjmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbj.AddMergeArea(qbjmeaA5);
            qbjcell2 = qbjcells.Add(4, 5, "建设年限", qbjcellXF);
            MergeArea qbjmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbj.AddMergeArea(qbjmeaA6);
            qbjcell2 = qbjcells.Add(4, 6, "建设性质", qbjcellXF);
            MergeArea qbjmeaA7 = new MergeArea(4, 6, 7, 7);
            sheetqbj.AddMergeArea(qbjmeaA7);
            qbjcell2 = qbjcells.Add(4, 7, "建设内容及规模", qbjcellXF);
            MergeArea qbjmeaA8 = new MergeArea(4, 6, 8, 8);
            sheetqbj.AddMergeArea(qbjmeaA8);
            qbjcell2 = qbjcells.Add(4, 8, "总投资", qbjcellXF);
            MergeArea qbjmeaAt9 = new MergeArea(4, 4, 9, 14);
            sheetqbj.AddMergeArea(qbjmeaAt9);
            qbjcell2 = qbjcells.Add(4, 9, "资金构成", qbjcellXF);
            MergeArea qbjmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbj.AddMergeArea(qbjmeaA9);
            qbjcell2 = qbjcells.Add(5, 9, "中央资金", qbjcellXF);
            MergeArea qbjmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbj.AddMergeArea(qbjmeaA10);
            qbjcell2 = qbjcells.Add(5, 10, "省级资金", qbjcellXF);
            MergeArea qbjmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbj.AddMergeArea(qbjmeaA11);
            qbjcell2 = qbjcells.Add(5, 11, "市级资金", qbjcellXF);
            MergeArea qbjmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbj.AddMergeArea(qbjmeaA12);
            qbjcell2 = qbjcells.Add(5, 12, "区县资金", qbjcellXF);
            MergeArea qbjmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbj.AddMergeArea(qbjmeaA13);
            qbjcell2 = qbjcells.Add(5, 13, "银行贷款", qbjcellXF);
            MergeArea qbjmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetqbj.AddMergeArea(qbjmeaA14);
            qbjcell2 = qbjcells.Add(5, 14, "企业自筹", qbjcellXF);
            MergeArea qbjmeaA15 = new MergeArea(4, 6, 15, 15);
            sheetqbj.AddMergeArea(qbjmeaA15);
            qbjcell2 = qbjcells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", qbjcellXF);
            MergeArea qbjmeaA16 = new MergeArea(4, 6, 16, 16);
            sheetqbj.AddMergeArea(qbjmeaA16);
            qbjcell2 = qbjcells.Add(4, 16, year+"年计划投资", qbjcellXF);
            MergeArea qbjmeaA17 = new MergeArea(4, 6, 17, 17);
            sheetqbj.AddMergeArea(qbjmeaA17);
            qbjcell2 = qbjcells.Add(4, 17, "目前为止项目形象进度", qbjcellXF);

            MergeArea qbjmeaAt18 = new MergeArea(4, 4, 18, 21);
            sheetqbj.AddMergeArea(qbjmeaAt18);
            qbjcell2 = qbjcells.Add(4, 18, "项目业主", qbjcellXF);

            MergeArea qbjmeaA18 = new MergeArea(5, 6, 18, 18);
            sheetqbj.AddMergeArea(qbjmeaA18);
            qbjcell2 = qbjcells.Add(5, 18, "单位名称", qbjcellXF);
            MergeArea qbjmeaA19 = new MergeArea(5, 6, 19, 19);
            sheetqbj.AddMergeArea(qbjmeaA19);
            qbjcell2 = qbjcells.Add(5, 19, "法人代表", qbjcellXF);

            MergeArea qbjmeaA20 = new MergeArea(5, 6, 20, 20);
            sheetqbj.AddMergeArea(qbjmeaA20);
            qbjcell2 = qbjcells.Add(5, 20, "业主联系人", qbjcellXF);

            MergeArea qbjmeaA21 = new MergeArea(5, 6, 21, 21);
            sheetqbj.AddMergeArea(qbjmeaA21);
            qbjcell2 = qbjcells.Add(5, 21, "联系电话", qbjcellXF);
            MergeArea qbjmeaA22 = new MergeArea(4, 6, 22, 22);
            sheetqbj.AddMergeArea(qbjmeaA22);
            qbjcell2 = qbjcells.Add(4, 22, "开工（计划开工）时间", qbjcellXF);

            MergeArea qbjmeaA23 = new MergeArea(4, 6, 23, 23);
            sheetqbj.AddMergeArea(qbjmeaA23);
            qbjcell2 = qbjcells.Add(4, 23, "计划竣工时间", qbjcellXF);

            MergeArea qbjmeaA24 = new MergeArea(4, 6, 24, 24);
            sheetqbj.AddMergeArea(qbjmeaA24);
            qbjcell2 = qbjcells.Add(4, 24, "四个一批范筹", qbjcellXF);

            MergeArea qbjmeaA25 = new MergeArea(4, 6, 25, 25);
            sheetqbj.AddMergeArea(qbjmeaA25);
            qbjcell2 = qbjcells.Add(4, 25, "已取得土地指标（亩）", qbjcellXF);

            MergeArea qbjmeaA26 = new MergeArea(4, 6, 26, 26);
            sheetqbj.AddMergeArea(qbjmeaA26);
            qbjcell2 = qbjcells.Add(4, 26, "拟申请土地指标（亩）", qbjcellXF);

            MergeArea qbjmeaA27 = new MergeArea(4, 6, 27, 27);
            sheetqbj.AddMergeArea(qbjmeaA27);
            qbjcell2 = qbjcells.Add(4, 27, "是否政府投资项目", qbjcellXF);

            MergeArea qbjmeaA28 = new MergeArea(4, 6, 28, 28);
            sheetqbj.AddMergeArea(qbjmeaA28);
            qbjcell2 = qbjcells.Add(4, 28, "1-"+month+"月累计完成投资额", qbjcellXF);

            MergeArea qbjmeaA29 = new MergeArea(4, 6, 29, 29);
            sheetqbj.AddMergeArea(qbjmeaA29);
            qbjcell2 = qbjcells.Add(4, 29, month+"月累计完成投资额", qbjcellXF);

            MergeArea qbjmeaA30 = new MergeArea(4, 6, 30, 30);
            sheetqbj.AddMergeArea(qbjmeaA30);
            qbjcell2 = qbjcells.Add(4, 30, "需协调解决问题", qbjcellXF);
            MergeArea qbjmeaA31 = new MergeArea(4, 6, 31, 31);
            sheetqbj.AddMergeArea(qbjmeaA31);
            qbjcell2 = qbjcells.Add(4, 31, "备注", qbjcellXF);
            x = 7;
            MergeArea meaAtcdc4 = new MergeArea(x, x, 1, 7);
            sheetqbj.AddMergeArea(meaAtcdc4);
            System.Data.DataTable dtqbj2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','qbj',2)");
            qbjcell2 = qbjcells.Add(x, 1, "一、投产达产（项目共计：" + dtqbj2.Rows.Count + "个；总投资：" + qbj_dic["tcdc_total"] + "万元；" + year + "年计划投资：" + qbj_dic["tcdc_c11"] + "万元。）", slcellXF);
            x = x + 1;
           
            for (int i = 0; i < dtqbj2.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbj2.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dtqbj2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtqbj2.Rows.Count  + x;
            qbjcell2 = qbjcells.Add(x, 1, dtqbj2.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计",cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["tcdc_c1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 9, qbj_dic["tcdc_c4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["tcdc_c5"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["tcdc_c6"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["tcdc_c7"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 13, qbj_dic["tcdc_c8"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 14, qbj_dic["tcdc_c9"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 15, qbj_dic["tcdc_c10"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 16, qbj_dic["tcdc_c11"] + "", cellXF);

            qbjcell2 = qbjcells.Add(x, 25, qbj_dic["tcdc_c12"] + "",cellXF);
            qbjcell2 = qbjcells.Add(x, 26, qbj_dic["tcdc_c13"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 28, qbj_dic["tcdc_c14"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 29, qbj_dic["tcdc_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================加快建设================
            MergeArea meaAjkjs4 = new MergeArea(x, x, 1, 7);
            sheetqbj.AddMergeArea(meaAjkjs4);
            System.Data.DataTable dtqbj4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','qbj',2)");
            qbjcell2 = qbjcells.Add(x, 1, "二、加快建设（项目共计：" + dtqbj4.Rows.Count + "个；总投资：" + qbj_dic["jkjs_total"] + "万元；" + year + "年计划投资：" + qbj_dic["jkjs_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtqbj4.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbj4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dtqbj4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
        //    x = x + 1;
            x = dtqbj4.Rows.Count  + x;
            qbjcell2 = qbjcells.Add(x, 1, dtqbj4.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计",cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["jkjs_c1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 9, qbj_dic["jkjs_c4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["jkjs_c5"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["jkjs_c6"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["jkjs_c7"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 13, qbj_dic["jkjs_c8"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 14, qbj_dic["jkjs_c9"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 15, qbj_dic["jkjs_c10"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 16, qbj_dic["jkjs_c11"] + "", cellXF);

            qbjcell2 = qbjcells.Add(x, 25, qbj_dic["jkjs_c12"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 26, qbj_dic["jkjs_c13"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 28, qbj_dic["jkjs_c14"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 29, qbj_dic["jkjs_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================促进开工================
            MergeArea meaAcjkg4 = new MergeArea(x, x, 1, 7);
            sheetqbj.AddMergeArea(meaAcjkg4);
            System.Data.DataTable dtqbj6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','qbj',2)");
            qbjcell2 = qbjcells.Add(x, 1, "三、促进开工（项目共计：" + dtqbj6.Rows.Count + "个；总投资：" + qbj_dic["cjkg_total"] + "万元；" + year + "年计划投资：" + qbj_dic["cjkg_c11"] + "万元。）", lqcellXF);
            x = x + 1;
           
            for (int i = 0; i < dtqbj6.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbj6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dtqbj6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
         //   x = x + 1;
            x = dtqbj6.Rows.Count  + x;
            qbjcell2 = qbjcells.Add(x, 1, dtqbj6.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计",cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["cjkg_c1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 9, qbj_dic["cjkg_c4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["cjkg_c5"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["cjkg_c6"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["cjkg_c7"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 13, qbj_dic["cjkg_c8"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 14, qbj_dic["cjkg_c9"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 15, qbj_dic["cjkg_c10"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 16, qbj_dic["cjkg_c11"] + "", cellXF);

            qbjcell2 = qbjcells.Add(x, 25, qbj_dic["cjkg_c12"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 26, qbj_dic["cjkg_c13"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 28, qbj_dic["cjkg_c14"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 29, qbj_dic["cjkg_c15"] + "", cellXF);

            //====================
           
       

            x =  1 + x;
            //=========================前期储备================
            MergeArea meaAqqcb4 = new MergeArea(x, x, 1, 7);
            sheetqbj.AddMergeArea(meaAqqcb4);
            System.Data.DataTable dtqbj8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','qbj',2)");
            qbjcell2 = qbjcells.Add(x, 1, "四、前期储备（项目共计：" + dtqbj8.Rows.Count + "个；总投资：" + qbj_dic["qqcb_total"] + "万元；" + year + "年计划投资：" + qbj_dic["qqcb_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtqbj8.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbj8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dtqbj8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
          //  x = x + 1;
            x = x + dtqbj8.Rows.Count;
            qbjcell2 = qbjcells.Add(x, 1, dtqbj8.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计",cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["qqcb_c1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 9, qbj_dic["qqcb_c4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["qqcb_c5"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["qqcb_c6"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["qqcb_c7"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 13, qbj_dic["qqcb_c8"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 14, qbj_dic["qqcb_c9"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 15, qbj_dic["qqcb_c10"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 16, qbj_dic["qqcb_c11"] + "", cellXF);

            qbjcell2 = qbjcells.Add(x, 25, qbj_dic["qqcb_c12"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 26, qbj_dic["qqcb_c13"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 28, qbj_dic["qqcb_c14"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 29, qbj_dic["qqcb_c15"] + "", cellXF);

            x = x + 1;

            qbjcell2 = qbjcells.Add(x, 1, dtqbj2.Rows.Count + dtqbj4.Rows.Count + dtqbj6.Rows.Count + dtqbj8.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "总合计", cellXF);
            qbjcell2 = qbjcells.Add(x, 8, (decimal.Parse(qbj_dic["qqcb_c1"]) + decimal.Parse(qbj_dic["jkjs_c1"]) + decimal.Parse(qbj_dic["cjkg_c1"]) + decimal.Parse(qbj_dic["tcdc_c1"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 9, ((decimal.Parse(qbj_dic["qqcb_c4"]) + decimal.Parse(qbj_dic["jkjs_c4"]) + decimal.Parse(qbj_dic["cjkg_c4"]) + decimal.Parse(qbj_dic["tcdc_c4"]))) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, (decimal.Parse(qbj_dic["qqcb_c5"]) + decimal.Parse(qbj_dic["jkjs_c5"]) + decimal.Parse(qbj_dic["cjkg_c5"]) + decimal.Parse(qbj_dic["tcdc_c5"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, (decimal.Parse(qbj_dic["qqcb_c6"]) + decimal.Parse(qbj_dic["jkjs_c6"]) + decimal.Parse(qbj_dic["cjkg_c6"]) + decimal.Parse(qbj_dic["tcdc_c6"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, (decimal.Parse(qbj_dic["qqcb_c7"]) + decimal.Parse(qbj_dic["jkjs_c7"]) + decimal.Parse(qbj_dic["cjkg_c7"]) + decimal.Parse(qbj_dic["tcdc_c7"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 13, (decimal.Parse(qbj_dic["qqcb_c8"]) + decimal.Parse(qbj_dic["jkjs_c8"]) + decimal.Parse(qbj_dic["cjkg_c8"]) + decimal.Parse(qbj_dic["tcdc_c8"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 14, (decimal.Parse(qbj_dic["qqcb_c9"]) + decimal.Parse(qbj_dic["jkjs_c9"]) + decimal.Parse(qbj_dic["cjkg_c9"]) + decimal.Parse(qbj_dic["tcdc_c9"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 15, (decimal.Parse(qbj_dic["qqcb_c10"]) + decimal.Parse(qbj_dic["jkjs_c10"]) + decimal.Parse(qbj_dic["cjkg_c10"]) + decimal.Parse(qbj_dic["tcdc_c10"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 16, (decimal.Parse(qbj_dic["qqcb_c11"]) + decimal.Parse(qbj_dic["jkjs_c11"]) + decimal.Parse(qbj_dic["cjkg_c11"]) + decimal.Parse(qbj_dic["tcdc_c11"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 25, (decimal.Parse(qbj_dic["qqcb_c12"]) + decimal.Parse(qbj_dic["jkjs_c12"]) + decimal.Parse(qbj_dic["cjkg_c12"]) + decimal.Parse(qbj_dic["tcdc_c12"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 26, (decimal.Parse(qbj_dic["qqcb_c13"]) + decimal.Parse(qbj_dic["jkjs_c13"]) + decimal.Parse(qbj_dic["cjkg_c13"]) + decimal.Parse(qbj_dic["tcdc_c13"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 28, (decimal.Parse(qbj_dic["qqcb_c14"]) + decimal.Parse(qbj_dic["jkjs_c14"]) + decimal.Parse(qbj_dic["cjkg_c14"]) + decimal.Parse(qbj_dic["tcdc_c14"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 29, (decimal.Parse(qbj_dic["qqcb_c15"]) + decimal.Parse(qbj_dic["jkjs_c15"]) + decimal.Parse(qbj_dic["cjkg_c15"]) + decimal.Parse(qbj_dic["tcdc_c15"])) + "", cellXF);

            //====================
            ///===========================表头
            MergeArea qbjmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbj.AddMergeArea(qbjmeaAttaddre);
            qbjcell2 = qbjcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbjmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbj.AddMergeArea(qbjmeaAttname);
            qbjcell2 = qbjcells.Add(3, 4, "填报人：");

            MergeArea qbjmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbj.AddMergeArea(qbjmeaAttname1);
            qbjcell2 = qbjcells.Add(3, 6, "审核人：");

            MergeArea qbjmeaAtt = new MergeArea(3, 3, 10, 17);
            sheetqbj.AddMergeArea(qbjmeaAtt);
            qbjcell2 = qbjcells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(qbj_dic["tcdc_c14"]) + decimal.Parse(qbj_dic["cjkg_c14"]) + decimal.Parse(qbj_dic["jkjs_c14"]) + decimal.Parse(qbj_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea qbjmeaAttu = new MergeArea(3, 3, 28, 29);
            sheetqbj.AddMergeArea(qbjmeaAttu);
            qbjcell2 = qbjcells.Add(3, 28, "单位：万元、亩");
            //=============================新津==================
            string sheetqbxName = "新津";
            Worksheet sheetqbx = xls.Workbook.Worksheets.Add(sheetqbxName);//填加名为"总表"的sheetqbx页

            Cells qbxcells = sheetqbx.Cells;//Cells实例是sheetqbx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbxcellXF.Font.FontName = "宋体";//设定字体
            qbxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbxcellXF.UseBorder = true;//使用边框
            qbxcellXF.TextWrapRight = true;//自动换行
            qbxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = qbxcells.AddValueCellXF(2, 2, "震", qbxcellXF);//以设定好的格式填加cell
            //qbxcellXF.Font.FontName = "宋体";
            //cell = qbxcells.AddValueCellXF(3, 2, "救", qbxcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea qbxmeaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 20 * 20;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbxcell = qbxcells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", qbxcellXF);
            //==============================================设置表头===============================================//
            sheetqbx.AddColumnInfo(col1);//把格式附加到sheet页上
            MergeArea qbxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA1);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 15 * 15;
            qbxcellXF.BottomLineStyle = 1;
            qbxcellXF.BottomLineColor = Colors.Black;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

            Cell qbxcell2 = null;
            //设置边框
            for (int i = 1; i < 32; i++)
            {
                for (int j = 2; j < 200; j++)
                    qbxcell2 = qbxcells.Add(j, i, "", cellXF);
            }

             qbxcell2 = qbxcells.Add(4, 1, "序号", qbxcellXF);
            qbxcell2.Font.FontName = "Times New Roman";
            MergeArea qbxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbx.AddMergeArea(qbxmeaA2);
            qbxcell2 = qbxcells.Add(4, 2, "所属区县", qbxcellXF);
            MergeArea qbxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbx.AddMergeArea(qbxmeaA3);
            qbxcell2 = qbxcells.Add(4, 3, "项目名称", qbxcellXF);
            MergeArea qbxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbx.AddMergeArea(qbxmeaA4);
            qbxcell2 = qbxcells.Add(4, 4, "建设地址", qbxcellXF);
            MergeArea qbxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbx.AddMergeArea(qbxmeaA5);
            qbxcell2 = qbxcells.Add(4, 5, "建设年限", qbxcellXF);
            MergeArea qbxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbx.AddMergeArea(qbxmeaA6);
            qbxcell2 = qbxcells.Add(4, 6, "建设性质", qbxcellXF);
            MergeArea qbxmeaA7 = new MergeArea(4, 6, 7, 7);
            sheetqbx.AddMergeArea(qbxmeaA7);
            qbxcell2 = qbxcells.Add(4, 7, "建设内容及规模", qbxcellXF);
            MergeArea qbxmeaA8 = new MergeArea(4, 6, 8, 8);
            sheetqbx.AddMergeArea(qbxmeaA8);
            qbxcell2 = qbxcells.Add(4, 8, "总投资", qbxcellXF);
            MergeArea qbxmeaAt9 = new MergeArea(4, 4, 9, 14);
            sheetqbx.AddMergeArea(qbxmeaAt9);
            qbxcell2 = qbxcells.Add(4, 9, "资金构成", qbxcellXF);
            MergeArea qbxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbx.AddMergeArea(qbxmeaA9);
            qbxcell2 = qbxcells.Add(5, 9, "中央资金", qbxcellXF);
            MergeArea qbxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbx.AddMergeArea(qbxmeaA10);
            qbxcell2 = qbxcells.Add(5, 10, "省级资金", qbxcellXF);
            MergeArea qbxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbx.AddMergeArea(qbxmeaA11);
            qbxcell2 = qbxcells.Add(5, 11, "市级资金", qbxcellXF);
            MergeArea qbxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbx.AddMergeArea(qbxmeaA12);
            qbxcell2 = qbxcells.Add(5, 12, "区县资金", qbxcellXF);
            MergeArea qbxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbx.AddMergeArea(qbxmeaA13);
            qbxcell2 = qbxcells.Add(5, 13, "银行贷款", qbxcellXF);
            MergeArea qbxmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetqbx.AddMergeArea(qbxmeaA14);
            qbxcell2 = qbxcells.Add(5, 14, "企业自筹", qbxcellXF);
            MergeArea qbxmeaA15 = new MergeArea(4, 6, 15, 15);
            sheetqbx.AddMergeArea(qbxmeaA15);
            qbxcell2 = qbxcells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", qbxcellXF);
            MergeArea qbxmeaA16 = new MergeArea(4, 6, 16, 16);
            sheetqbx.AddMergeArea(qbxmeaA16);
            qbxcell2 = qbxcells.Add(4, 16, year+"年计划投资", qbxcellXF);
            MergeArea qbxmeaA17 = new MergeArea(4, 6, 17, 17);
            sheetqbx.AddMergeArea(qbxmeaA17);
            qbxcell2 = qbxcells.Add(4, 17, "目前为止项目形象进度", qbxcellXF);
            MergeArea qbxmeaAt18 = new MergeArea(4, 4, 18, 21);
            sheetqbx.AddMergeArea(qbxmeaAt18);
            qbxcell2 = qbxcells.Add(4, 18, "项目业主", qbxcellXF);
            MergeArea qbxmeaA18 = new MergeArea(5, 6, 18, 18);
            sheetqbx.AddMergeArea(qbxmeaA18);
            qbxcell2 = qbxcells.Add(5, 18, "单位名称", qbxcellXF);
            MergeArea qbxmeaA19 = new MergeArea(5, 6, 19, 19);
            sheetqbx.AddMergeArea(qbxmeaA19);
            qbxcell2 = qbxcells.Add(5, 19, "法人代表", qbxcellXF);
            MergeArea qbxmeaA20 = new MergeArea(5, 6, 20, 20);
            sheetqbx.AddMergeArea(qbxmeaA20);
            qbxcell2 = qbxcells.Add(5, 20, "业主联系人", qbxcellXF);
            MergeArea qbxmeaA21 = new MergeArea(5, 6, 21, 21);
            sheetqbx.AddMergeArea(qbxmeaA21);
            qbxcell2 = qbxcells.Add(5, 21, "联系电话", qbxcellXF);
            MergeArea qbxmeaA22 = new MergeArea(4, 6, 22, 22);
            sheetqbx.AddMergeArea(qbxmeaA22);
            qbxcell2 = qbxcells.Add(4, 22, "开工（计划开工）时间", qbxcellXF);
            MergeArea qbxmeaA23 = new MergeArea(4, 6, 23, 23);
            sheetqbx.AddMergeArea(qbxmeaA23);
            qbxcell2 = qbxcells.Add(4, 23, "计划竣工时间", qbxcellXF);
            MergeArea qbxmeaA24 = new MergeArea(4, 6, 24, 24);
            sheetqbx.AddMergeArea(qbxmeaA24);
            qbxcell2 = qbxcells.Add(4, 24, "四个一批范筹", qbxcellXF);
            MergeArea qbxmeaA25 = new MergeArea(4, 6, 25, 25);
            sheetqbx.AddMergeArea(qbxmeaA25);
            qbxcell2 = qbxcells.Add(4, 25, "已取得土地指标（亩）", qbxcellXF);
            MergeArea qbxmeaA26 = new MergeArea(4, 6, 26, 26);
            sheetqbx.AddMergeArea(qbxmeaA26);
            qbxcell2 = qbxcells.Add(4, 26, "拟申请土地指标（亩）", qbxcellXF);
            MergeArea qbxmeaA27 = new MergeArea(4, 6, 27, 27);
            sheetqbx.AddMergeArea(qbxmeaA27);
            qbxcell2 = qbxcells.Add(4, 27, "是否政府投资项目", qbxcellXF);
            MergeArea qbxmeaA28 = new MergeArea(4, 6, 28, 28);
            sheetqbx.AddMergeArea(qbxmeaA28);
            qbxcell2 = qbxcells.Add(4, 28, "1-"+month+"月累计完成投资额", qbxcellXF);
            MergeArea qbxmeaA29 = new MergeArea(4, 6, 29, 29);
            sheetqbx.AddMergeArea(qbxmeaA29);
            qbxcell2 = qbxcells.Add(4, 29, month+"月累计完成投资额", qbxcellXF);
            MergeArea qbxmeaA30 = new MergeArea(4, 6, 30, 30);
            sheetqbx.AddMergeArea(qbxmeaA30);
            qbxcell2 = qbxcells.Add(4, 30, "需协调解决问题", qbxcellXF);
            MergeArea qbxmeaA31 = new MergeArea(4, 6, 31, 31);
            sheetqbx.AddMergeArea(qbxmeaA31);
            qbxcell2 = qbxcells.Add(4, 31, "备注", qbxcellXF);
            x = 7;
            MergeArea meaAtcdc5 = new MergeArea(x, x, 1, 7);
            sheetqbx.AddMergeArea(meaAtcdc5);
            System.Data.DataTable dtqbx2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','xj',2)");
            qbxcell2 = qbxcells.Add(x, 1, "一、投产达产（项目共计：" + dtqbx2.Rows.Count + "个；总投资：" + xj_dic["tcdc_total"] + "万元；" + year + "年计划投资：" + xj_dic["tcdc_c11"] + "万元。）", slcellXF);
            x = x + 1;
           
            for (int i = 0; i < dtqbx2.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbx2.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dtqbx2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
           // x = x + 1;
            x = dtqbx2.Rows.Count  + x;
            qbxcell2 = qbxcells.Add(x, 1, dtqbx2.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计",cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["tcdc_c1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 9, xj_dic["tcdc_c4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["tcdc_c5"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["tcdc_c6"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["tcdc_c7"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 13, xj_dic["tcdc_c8"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 14, xj_dic["tcdc_c9"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 15, xj_dic["tcdc_c10"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 16, xj_dic["tcdc_c11"] + "", cellXF);
            qbxcell2=  qbxcells.Add(x,25,xj_dic["tcdc_c12"]+"",cellXF);
            qbxcell2 = qbxcells.Add(x, 26, xj_dic["tcdc_c13"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 28, xj_dic["tcdc_c14"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 29, xj_dic["tcdc_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================加快建设================
            MergeArea meaAjkjs5 = new MergeArea(x, x, 1, 7);
            sheetqbx.AddMergeArea(meaAjkjs5);

            System.Data.DataTable dtqbx4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','xj',2)");
            qbxcell2 = qbxcells.Add(x, 1, "二、加快建设（项目共计：" + dtqbx4.Rows.Count + "个；总投资：" + xj_dic["jkjs_total"] + "万元；" + year + "年计划投资：" + xj_dic["jkjs_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtqbx4.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbx4.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dtqbx4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
           // x = x + 1;
            x = dtqbx4.Rows.Count  + x;

            qbxcell2 = qbxcells.Add(x, 1, dtqbx2.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计",cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["jkjs_c1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 9, xj_dic["jkjs_c4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["jkjs_c5"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["jkjs_c6"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["jkjs_c7"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 13, xj_dic["jkjs_c8"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 14, xj_dic["jkjs_c9"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 15, xj_dic["jkjs_c10"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 16, xj_dic["jkjs_c11"] + "", cellXF);

            qbxcell2 = qbxcells.Add(x, 25, xj_dic["jkjs_c12"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 26, xj_dic["jkjs_c13"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 28, xj_dic["jkjs_c14"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 29, xj_dic["jkjs_c15"] + "", cellXF);

            //====================
            x = 1 + x;
            //=========================促进开工================
            MergeArea meaAcjkg5 = new MergeArea(x, x, 1, 7);
            sheetqbx.AddMergeArea(meaAcjkg5);

            System.Data.DataTable dtqbx6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','xj',2)");
            qbxcell2 = qbxcells.Add(x, 1, "三、促进开工（项目共计：" + dtqbx6.Rows.Count + "个；总投资：" + xj_dic["cjkg_total"] + "万元；" + year + "年计划投资：" + xj_dic["cjkg_c11"] + "万元。）", lqcellXF);
            x = x + 1;
           
            for (int i = 0; i < dtqbx6.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbx6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dtqbx6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
           // x = x + 1;
            x = dtqbx6.Rows.Count + x;
            qbxcell2 = qbxcells.Add(x, 1, dtqbx6.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计",cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["cjkg_c1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 9, xj_dic["cjkg_c4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["cjkg_c5"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["cjkg_c6"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["cjkg_c7"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 13, xj_dic["cjkg_c8"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 14, xj_dic["cjkg_c9"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 15, xj_dic["cjkg_c10"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 16, xj_dic["cjkg_c11"] + "", cellXF);

            qbxcell2 = qbxcells.Add(x, 25, xj_dic["cjkg_c12"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 26, xj_dic["cjkg_c13"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 28, xj_dic["cjkg_c14"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 29, xj_dic["cjkg_c15"] + "", cellXF);

            //====================
            x =  1 + x;
            //=========================前期储备================
            MergeArea meaAqqcb5 = new MergeArea(x, x, 1, 7);
            sheetqbx.AddMergeArea(meaAqqcb5);
            System.Data.DataTable dtqbx8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','xj',2)");
            qbxcell2 = qbxcells.Add(x, 1, "四、前期储备（项目共计：" + dtqbx8.Rows.Count + "个；总投资：" + xj_dic["qqcb_total"] + "万元；" + year + "年计划投资：" + xj_dic["qqcb_c11"] + "万元。）", lqcellXF);
            x = x + 1;
            
            for (int i = 0; i < dtqbx8.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dtqbx8.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dtqbx8.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计========
            x = x + dtqbx8.Rows.Count;

            qbxcell2 = qbxcells.Add(x, 1, dtqbx8.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计",cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["qqcb_c1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 9, xj_dic["qqcb_c4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["qqcb_c5"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["qqcb_c6"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["qqcb_c7"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 13, xj_dic["qqcb_c8"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 14, xj_dic["qqcb_c9"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 15, xj_dic["qqcb_c10"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 16, xj_dic["qqcb_c11"] + "", cellXF);

            qbxcell2 = qbxcells.Add(x, 25, xj_dic["qqcb_c12"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 26, xj_dic["qqcb_c13"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 28, xj_dic["qqcb_c14"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 29, xj_dic["qqcb_c15"] + "", cellXF);


            x = x + 1;

            qbxcell2 = qbxcells.Add(x, 1, dtqbx2.Rows.Count + dtqbx4.Rows.Count + dtqbx6.Rows.Count + dtqbx8.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "总合计", cellXF);
            qbxcell2 = qbxcells.Add(x, 8, (decimal.Parse(xj_dic["qqcb_c1"]) + decimal.Parse(xj_dic["jkjs_c1"]) + decimal.Parse(xj_dic["cjkg_c1"]) + decimal.Parse(xj_dic["tcdc_c1"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 9, (decimal.Parse(xj_dic["qqcb_c4"]) + decimal.Parse(xj_dic["jkjs_c4"]) + decimal.Parse(xj_dic["cjkg_c4"]) + decimal.Parse(xj_dic["tcdc_c4"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, (decimal.Parse(xj_dic["qqcb_c5"]) + decimal.Parse(xj_dic["jkjs_c5"]) + decimal.Parse(xj_dic["cjkg_c5"]) + decimal.Parse(xj_dic["tcdc_c5"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, (decimal.Parse(xj_dic["qqcb_c6"]) + decimal.Parse(xj_dic["jkjs_c6"]) + decimal.Parse(xj_dic["cjkg_c6"]) + decimal.Parse(xj_dic["tcdc_c6"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, (decimal.Parse(xj_dic["qqcb_c7"]) + decimal.Parse(xj_dic["jkjs_c7"]) + decimal.Parse(xj_dic["cjkg_c7"]) + decimal.Parse(xj_dic["tcdc_c7"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 13, (decimal.Parse(xj_dic["qqcb_c8"]) + decimal.Parse(xj_dic["jkjs_c8"]) + decimal.Parse(xj_dic["cjkg_c8"]) + decimal.Parse(xj_dic["tcdc_c8"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 14, (decimal.Parse(xj_dic["qqcb_c9"]) + decimal.Parse(xj_dic["jkjs_c9"]) + decimal.Parse(xj_dic["cjkg_c9"]) + decimal.Parse(xj_dic["tcdc_c9"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 15, (decimal.Parse(xj_dic["qqcb_c10"]) + decimal.Parse(xj_dic["jkjs_c10"]) + decimal.Parse(xj_dic["cjkg_c10"]) + decimal.Parse(xj_dic["tcdc_c10"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 16, (decimal.Parse(xj_dic["qqcb_c11"]) + decimal.Parse(xj_dic["jkjs_c11"]) + decimal.Parse(xj_dic["cjkg_c11"]) + decimal.Parse(xj_dic["tcdc_c11"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 25, (decimal.Parse(xj_dic["qqcb_c12"]) + decimal.Parse(xj_dic["jkjs_c12"]) + decimal.Parse(xj_dic["cjkg_c12"]) + decimal.Parse(xj_dic["tcdc_c13"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 26, (decimal.Parse(xj_dic["qqcb_c13"]) + decimal.Parse(xj_dic["jkjs_c13"]) + decimal.Parse(xj_dic["cjkg_c13"]) + decimal.Parse(xj_dic["tcdc_c13"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 28, (decimal.Parse(xj_dic["qqcb_c14"]) + decimal.Parse(xj_dic["jkjs_c14"]) + decimal.Parse(xj_dic["cjkg_c14"]) + decimal.Parse(xj_dic["tcdc_c14"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 29, (decimal.Parse(xj_dic["qqcb_c15"]) + decimal.Parse(xj_dic["jkjs_c15"]) + decimal.Parse(xj_dic["cjkg_c15"]) + decimal.Parse(xj_dic["tcdc_c15"])) + "", cellXF);

            //====================
            ///===========================表头
            MergeArea qbxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbx.AddMergeArea(qbxmeaAttaddre);
            qbxcell2 = qbxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbx.AddMergeArea(qbxmeaAttname);
            qbxcell2 = qbxcells.Add(3, 4, "填报人：");

            MergeArea qbxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbx.AddMergeArea(qbxmeaAttname1);
            qbxcell2 = qbxcells.Add(3, 6, "审核人：");

            MergeArea qbxmeaAtt = new MergeArea(3, 3, 10, 17);
            sheetqbx.AddMergeArea(qbxmeaAtt);
            qbxcell2 = qbxcells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(xj_dic["tcdc_c14"]) + decimal.Parse(xj_dic["cjkg_c14"]) + decimal.Parse(xj_dic["jkjs_c14"]) + decimal.Parse(xj_dic["qqcb_c14"])) + "万元 ", cellXFcont);

            MergeArea qbxmeaAttu = new MergeArea(3, 3, 28, 29);
            sheetqbx.AddMergeArea(qbxmeaAttu);
            qbxcell2 = qbxcells.Add(3, 28, "单位：万元、亩");


            //=================================
            xls.Save(path);
            string fileName = filename + ".xls";//客户端保存的文件名
            string filePath = path +"/"+ filename + ".xls";//路径
            FileInfo fileInfo = new FileInfo(filePath);
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            response.AddHeader("Content-Length", fileInfo.Length.ToString());
            response.AddHeader("Content-Transfer-Encoding", "binary");
            response.ContentType = "application/octet-stream";
            response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            response.WriteFile(fileInfo.FullName);
            response.Flush();
            try
            {
               
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message);
            }
            finally
            {
                response.End();
            }
        }
        /// <summary>
        /// 一级审核元下砸生态旅游重大项目的Excel
        /// </summary>
        /// <param name="response"></param>
        /// <param name="path"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="area"></param>
        public void downstExcel(HttpResponse response, string path, int year, int month, string area)
        {
            string addressName = "";
            if (area == "lqy")
            {
                addressName = "龙泉驿区";
            }
            else if (area == "sl")
            {
                addressName = "双流县";
            }
            else if (area == "jt")
            {
                addressName = "金堂县";
            }
            else if (area == "qbj")
            {
                addressName = "青白江区";
            }
            else if (area == "xj")
            {
                addressName = "新津县";
            }
            Dictionary<String, String> dic = getstMoneyAndCountByAddress(year, month, 1, area.Trim());

          

                string filename = "st_lqy_"+System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
                XlsDocument xls = new XlsDocument();//新建一个xls文档
                xls.FileName = filename + ".xls";//设定文件名
                string sheetName = "总表";
                Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
                Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
                //cell的格式还可以定义在一个xf对象中
                XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXF.Font.FontName = "宋体";//设定字体
                cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXF.UseBorder = true;//使用边框
                cellXF.TextWrapRight = true;//自动换行
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.RightLineColor = Colors.Black;
                cellXF.RightLineStyle = 1;

                //===================================设置标题=====================================================//
                MergeArea meaA = new MergeArea(1, 2, 1, 31);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 20 * 20;
                cellXF.Font.Bold = true;
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
                //===============================
                ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
                col1.ColumnIndexStart = 1;//起始列为第1列
                col1.ColumnIndexEnd = 31;//终止列为第1列
                col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
                sheet.AddColumnInfo(col1);//把格式附加到sheet页上
                //==================================
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
                Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游功能区重大项目表", cellXF);
                //==============================================设置表头===============================================//
                MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA1);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 15 * 15;
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.Font.Bold = true;
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

                Cell cell2 = null;
                //设置边框
                for (int i = 1; i < 32; i++)
                {
                    for (int j = 2; j < 200; j++)
                        cell2 = cells.Add(j, i, "", cellXF);
                }

                cell2 = cells.Add(4, 1, "序号", cellXF);
                cell2.Font.FontName = "Times New Roman";
                MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
                sheet.AddMergeArea(meaA2);
                cell2 = cells.Add(4, 2, "所属区县", cellXF);
                MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
                sheet.AddMergeArea(meaA3);
                cell2 = cells.Add(4, 3, "项目名称", cellXF);
                MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
                sheet.AddMergeArea(meaA4);
                cell2 = cells.Add(4, 4, "建设地址", cellXF);
                MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
                sheet.AddMergeArea(meaA5);
                cell2 = cells.Add(4, 5, "建设年限", cellXF);
                MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
                sheet.AddMergeArea(meaA6);
                cell2 = cells.Add(4, 6, "建设性质", cellXF);
                MergeArea meaA7 = new MergeArea(4, 6, 7, 7);
                sheet.AddMergeArea(meaA7);
                cell2 = cells.Add(4, 7, "建设内容及规模", cellXF);
                MergeArea meaA8 = new MergeArea(4, 6, 8, 8);
                sheet.AddMergeArea(meaA8);
                cell2 = cells.Add(4, 8, "总投资", cellXF);

                MergeArea meaAt9 = new MergeArea(4, 4, 9, 14);
                sheet.AddMergeArea(meaAt9);
                cell2 = cells.Add(4, 9, "资金构成", cellXF);

                MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
                sheet.AddMergeArea(meaA9);
                cell2 = cells.Add(5, 9, "中央资金", cellXF);
                MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
                sheet.AddMergeArea(meaA10);
                cell2 = cells.Add(5, 10, "省级资金", cellXF);

                MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
                sheet.AddMergeArea(meaA11);
                cell2 = cells.Add(5, 11, "市级资金", cellXF);

                MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
                sheet.AddMergeArea(meaA12);
                cell2 = cells.Add(5, 12, "区县资金", cellXF);

                MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
                sheet.AddMergeArea(meaA13);
                cell2 = cells.Add(5, 13, "银行贷款", cellXF);
                MergeArea meaA14 = new MergeArea(5, 6, 14, 14);
                sheet.AddMergeArea(meaA14);
                cell2 = cells.Add(5, 14, "企业自筹", cellXF);
                MergeArea meaA15 = new MergeArea(4, 6, 15, 15);
                sheet.AddMergeArea(meaA15);
                cell2 = cells.Add(4, 15, "至"+(year-1)+"年底累计完成投资", cellXF);
                MergeArea meaA16 = new MergeArea(4, 6, 16, 16);
                sheet.AddMergeArea(meaA16);
                cell2 = cells.Add(4, 16, year+"年计划投资", cellXF);

                MergeArea meaA17 = new MergeArea(4, 6, 17, 17);
                sheet.AddMergeArea(meaA17);
                cell2 = cells.Add(4, 17, "目前为止项目形象进度", cellXF);

                MergeArea meaAt18 = new MergeArea(4, 4, 18, 21);
                sheet.AddMergeArea(meaAt18);
                cell2 = cells.Add(4, 18, "项目业主", cellXF);

                MergeArea meaA18 = new MergeArea(5, 6, 18, 18);
                sheet.AddMergeArea(meaA18);
                cell2 = cells.Add(5, 18, "单位名称", cellXF);
                MergeArea meaA19 = new MergeArea(5, 6, 19, 19);
                sheet.AddMergeArea(meaA19);
                cell2 = cells.Add(5, 19, "法人代表", cellXF);

                MergeArea meaA20 = new MergeArea(5, 6, 20, 20);
                sheet.AddMergeArea(meaA20);
                cell2 = cells.Add(5, 20, "业主联系人", cellXF);

                MergeArea meaA21 = new MergeArea(5, 6, 21, 21);
                sheet.AddMergeArea(meaA21);
                cell2 = cells.Add(5, 21, "联系电话", cellXF);
                MergeArea meaA22 = new MergeArea(4, 6, 22, 22);
                sheet.AddMergeArea(meaA22);
                cell2 = cells.Add(4, 22, "开工（计划开工）时间", cellXF);

                MergeArea meaA23 = new MergeArea(4, 6, 23, 23);
                sheet.AddMergeArea(meaA23);
                cell2 = cells.Add(4, 23, "计划竣工时间", cellXF);

                MergeArea meaA24 = new MergeArea(4, 6, 24, 24);
                sheet.AddMergeArea(meaA24);
                cell2 = cells.Add(4, 24, "四个一批范筹", cellXF);

                MergeArea meaA25 = new MergeArea(4, 6, 25, 25);
                sheet.AddMergeArea(meaA25);
                cell2 = cells.Add(4, 25, "已取得土地指标（亩）", cellXF);

                MergeArea meaA26 = new MergeArea(4, 6, 26, 26);
                sheet.AddMergeArea(meaA26);
                cell2 = cells.Add(4, 26, "拟申请土地指标（亩）", cellXF);

                MergeArea meaA27 = new MergeArea(4, 6, 27, 27);
                sheet.AddMergeArea(meaA27);
                cell2 = cells.Add(4, 27, "是否政府投资项目", cellXF);

                MergeArea meaA28 = new MergeArea(4, 6, 28, 28);
                sheet.AddMergeArea(meaA28);
                cell2 = cells.Add(4, 28, "1-"+month+"月累计完成投资额", cellXF);

                MergeArea meaA29 = new MergeArea(4, 6, 29, 29);
                sheet.AddMergeArea(meaA29);
                cell2 = cells.Add(4, 29, month+"月累计完成投资额", cellXF);

                MergeArea meaA30 = new MergeArea(4, 6, 30, 30);
                sheet.AddMergeArea(meaA30);
                cell2 = cells.Add(4, 30, "需协调解决问题", cellXF);
                MergeArea meaA31 = new MergeArea(4, 6, 31, 31);
                sheet.AddMergeArea(meaA31);
                cell2 = cells.Add(4, 31, "备注", cellXF);
                //=============================表头完成======================填入正文开始===================
                XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXFcont.Font.FontName = "宋体";//设定字体
                //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXFcont.TextWrapRight = true;//自动换行
                cellXFcont.BottomLineStyle = 1;
                cellXFcont.BottomLineColor = Colors.Black;
                cellXFcont.RightLineColor = Colors.Black;
                cellXFcont.RightLineStyle = 1;
                DataBase db = new DataBase();

                System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','" + area + "',1)");
                MergeArea meaAtcdc = new MergeArea(7, 7, 1, 7);
                sheet.AddMergeArea(meaAtcdc);
                cell2 = cells.Add(7, 1, "一、投产达产（项目共计：" + dt2.Rows.Count + "个；总投资：" + dic["tcdc_total"] + "万元；" + year + "年计划投资：" + dic["tcdc_c11"] + "万元。）", cellXF);
                int x = 8;
               // int number = 0;
              

                //===============================投产达产=============
                
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                //小计========
               
                x = dt2.Rows.Count + x;
                cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "合计",cellXF);
                cell2 = cells.Add(x, 8, dic["tcdc_c1"] + "", cellXF);
                cell2 = cells.Add(x, 9, dic["tcdc_c4"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["tcdc_c5"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["tcdc_c6"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["tcdc_c7"] + "", cellXF);
                cell2 = cells.Add(x, 13, dic["tcdc_c8"] + "", cellXF);
                cell2 = cells.Add(x, 14, dic["tcdc_c9"] + "", cellXF);
                cell2 = cells.Add(x, 15, dic["tcdc_c10"] + "", cellXF);
                cell2 = cells.Add(x, 16, dic["tcdc_c11"] + "", cellXF);

                cell2 = cells.Add(x, 25, dic["tcdc_c12"] + "", cellXF);
                cell2 = cells.Add(x, 26, dic["tcdc_c13"] + "", cellXF);
                cell2 = cells.Add(x, 28, dic["tcdc_c14"] + "", cellXF);
                cell2 = cells.Add(x, 29, dic["tcdc_c15"] + "", cellXF);

                //====================
                x = x + 1;
                //===============================加快建设=============
                System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','" + area + "',1)");
                MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
                sheet.AddMergeArea(meaAjkjs);
                cell2 = cells.Add(x, 1, "二、加快建设（项目共计：" + dt4.Rows.Count + "个；总投资：" + dic["jkjs_total"] + "万元；" + year + "年计划投资：" + dic["jkjs_c11"] + "万元。）", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt4.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                //小计========
               
                x = dt4.Rows.Count  + x;

                cell2 = cells.Add(x, 1, dt4.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "合计", cellXF);
                cell2 = cells.Add(x, 8, dic["jkjs_c1"] + "", cellXF);
                cell2 = cells.Add(x, 9, dic["jkjs_c4"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["jkjs_c5"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["jkjs_c6"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["jkjs_c7"] + "", cellXF);
                cell2 = cells.Add(x, 13, dic["jkjs_c8"] + "", cellXF);
                cell2 = cells.Add(x, 14, dic["jkjs_c9"] + "", cellXF);
                cell2 = cells.Add(x, 15, dic["jkjs_c10"] + "", cellXF);
                cell2 = cells.Add(x, 16, dic["jkjs_c11"] + "", cellXF);

                cell2 = cells.Add(x, 25, dic["jkjs_c12"] + "", cellXF);
                cell2 = cells.Add(x, 26, dic["jkjs_c13"] + "", cellXF);
                cell2 = cells.Add(x, 28, dic["jkjs_c14"] + "", cellXF);
                cell2 = cells.Add(x, 29, dic["jkjs_c15"] + "", cellXF);

                //====================
                x = x + 1;
                //===============================促进开工=============
                System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','" + area + "',1)");
                MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
                sheet.AddMergeArea(meaAcjkg);
                cell2 = cells.Add(x, 1, "三、促进开工（项目共计：" + dt6.Rows.Count + "个；总投资：" + dic["cjkg_total"] + "万元；" + year + "年计划投资：" + dic["cjkg_c11"] + "万元。）", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt6.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                //小计========
               
                x = dt6.Rows.Count + x;
                cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "合计", cellXF);
                cell2 = cells.Add(x, 8, dic["cjkg_c1"] + "", cellXF);
                cell2 = cells.Add(x, 9, dic["cjkg_c4"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["cjkg_c5"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["cjkg_c6"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["cjkg_c7"] + "", cellXF);
                cell2 = cells.Add(x, 13, dic["cjkg_c8"] + "", cellXF);
                cell2 = cells.Add(x, 14, dic["cjkg_c9"] + "", cellXF);
                cell2 = cells.Add(x, 15, dic["cjkg_c10"] + "", cellXF);
                cell2 = cells.Add(x, 16, dic["cjkg_c11"] + "", cellXF);

                cell2 = cells.Add(x, 25, dic["cjkg_c12"] + "", cellXF);
                cell2 = cells.Add(x, 26, dic["cjkg_c13"] + "", cellXF);
                cell2 = cells.Add(x, 28, dic["cjkg_c14"] + "", cellXF);
                cell2 = cells.Add(x, 29, dic["cjkg_c15"] + "", cellXF);

                //====================
                x = x + 1;
                //===============================前期储备=============
                System.Data.DataTable dt8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','" + area + "',1)");
                MergeArea meaAqqcb = new MergeArea(x, x, 1, 7);
                sheet.AddMergeArea(meaAqqcb);
                cell2 = cells.Add(x, 1, "四、前期储备（项目共计：" + dt8.Rows.Count + "个；总投资：" + dic["qqcb_total"] + "万元；" + year + "年计划投资：" + dic["qqcb_c11"] + "万元。）", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt8.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt8.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt8.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                //小计========
               // x = x + 1;
                x = dt8.Rows.Count+ x;
                cell2 = cells.Add(x, 1, dt8.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "合计", cellXF);
                cell2 = cells.Add(x, 8, dic["qqcb_c1"] + "", cellXF);
                cell2 = cells.Add(x, 9, dic["qqcb_c4"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["qqcb_c5"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["qqcb_c6"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["qqcb_c7"] + "", cellXF);
                cell2 = cells.Add(x, 13, dic["qqcb_c8"] + "", cellXF);
                cell2 = cells.Add(x, 14, dic["qqcb_c9"] + "", cellXF);
                cell2 = cells.Add(x, 15, dic["qqcb_c10"] + "", cellXF);
                cell2 = cells.Add(x, 16, dic["qqcb_c11"] + "", cellXF);
                cell2 = cells.Add(x, 25, dic["qqcb_c12"] + "", cellXF);
                cell2 = cells.Add(x, 26, dic["qqcb_c13"] + "", cellXF);
                cell2 = cells.Add(x, 28, dic["qqcb_c14"] + "", cellXF);
                cell2 = cells.Add(x, 29, dic["qqcb_c15"] + "", cellXF);

                x = x + 1;

                cell2 = cells.Add(x, 1, dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count + dt8.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "总合计", cellXF);
                cell2 = cells.Add(x, 8, (decimal.Parse(dic["qqcb_c1"]) + decimal.Parse(dic["cjkg_c1"]) + decimal.Parse(dic["jkjs_c1"]) + decimal.Parse(dic["tcdc_c1"])) + "", cellXF);
                cell2 = cells.Add(x, 9, (decimal.Parse(dic["qqcb_c4"]) + decimal.Parse(dic["cjkg_c4"]) + decimal.Parse(dic["jkjs_c4"]) + decimal.Parse(dic["tcdc_c4"])) + "", cellXF);
                cell2 = cells.Add(x, 10, (decimal.Parse(dic["qqcb_c5"]) + decimal.Parse(dic["cjkg_c5"]) + decimal.Parse(dic["jkjs_c5"]) + decimal.Parse(dic["tcdc_c5"])) + "", cellXF);
                cell2 = cells.Add(x, 11, (decimal.Parse(dic["qqcb_c6"]) + decimal.Parse(dic["cjkg_c6"]) + decimal.Parse(dic["jkjs_c6"]) + decimal.Parse(dic["tcdc_c6"])) + "", cellXF);
                cell2 = cells.Add(x, 12, (decimal.Parse(dic["qqcb_c7"]) + decimal.Parse(dic["cjkg_c7"]) + decimal.Parse(dic["jkjs_c7"]) + decimal.Parse(dic["tcdc_c7"])) + "", cellXF);
                cell2 = cells.Add(x, 13, (decimal.Parse(dic["qqcb_c8"]) + decimal.Parse(dic["cjkg_c8"]) + decimal.Parse(dic["jkjs_c8"]) + decimal.Parse(dic["tcdc_c8"])) + "", cellXF);
                cell2 = cells.Add(x, 14, (decimal.Parse(dic["qqcb_c9"]) + decimal.Parse(dic["cjkg_c9"]) + decimal.Parse(dic["jkjs_c9"]) + decimal.Parse(dic["tcdc_c9"])) + "", cellXF);
                cell2 = cells.Add(x, 15, (decimal.Parse(dic["qqcb_c10"]) + decimal.Parse(dic["cjkg_c10"]) + decimal.Parse(dic["jkjs_c10"]) + decimal.Parse(dic["tcdc_c10"])) + "", cellXF);
                cell2 = cells.Add(x, 16, (decimal.Parse(dic["qqcb_c11"]) + decimal.Parse(dic["cjkg_c11"]) + decimal.Parse(dic["jkjs_c11"]) + decimal.Parse(dic["tcdc_c11"])) + "", cellXF);
                cell2 = cells.Add(x, 25, (decimal.Parse(dic["qqcb_c12"]) + decimal.Parse(dic["cjkg_c12"]) + decimal.Parse(dic["jkjs_c12"]) + decimal.Parse(dic["tcdc_c12"])) + "", cellXF);
                cell2 = cells.Add(x, 26, (decimal.Parse(dic["qqcb_c13"]) + decimal.Parse(dic["cjkg_c13"]) + decimal.Parse(dic["jkjs_c13"]) + decimal.Parse(dic["tcdc_c13"])) + "", cellXF);
                cell2 = cells.Add(x, 28, (decimal.Parse(dic["qqcb_c14"]) + decimal.Parse(dic["cjkg_c14"]) + decimal.Parse(dic["jkjs_c14"]) + decimal.Parse(dic["tcdc_c14"])) + "", cellXF);
                cell2 = cells.Add(x, 29, (decimal.Parse(dic["qqcb_c15"]) + decimal.Parse(dic["cjkg_c15"]) + decimal.Parse(dic["jkjs_c15"]) + decimal.Parse(dic["tcdc_c15"])) + "", cellXF);
                //====================
               
                //汇总所有的资金很项目个数
                ///===========================表头
                MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
                sheet.AddMergeArea(meaAttaddre);
                cell2 = cells.Add(3, 2, "填报单位（盖章）");

                MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
                sheet.AddMergeArea(meaAttname);
                cell2 = cells.Add(3, 4, "填报人：");
                MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
                sheet.AddMergeArea(meaAttname1);
                cell2 = cells.Add(3, 6, "审核人：");

                MergeArea meaAtt = new MergeArea(3, 3, 10, 17);
                sheet.AddMergeArea(meaAtt);
                cell2 = cells.Add(3, 10, "此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日        " + "1-" + month + "月总完成额为：" + (decimal.Parse(dic["tcdc_c14"]) + decimal.Parse(dic["cjkg_c14"]) + decimal.Parse(dic["jkjs_c14"]) + decimal.Parse(dic["qqcb_c14"])) + "万元 ", cellXFcont);

                MergeArea meaAttu = new MergeArea(3, 3, 28, 29);
                sheet.AddMergeArea(meaAttu);
                cell2 = cells.Add(3, 28, "单位：万元、亩");



                xls.Save(path);
                string fileName = filename + ".xls";//客户端保存的文件名
                string filePath = path + "/" + filename + ".xls";//路径
                FileInfo fileInfo = new FileInfo(filePath);
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                response.AddHeader("Content-Length", fileInfo.Length.ToString());
                response.AddHeader("Content-Transfer-Encoding", "binary");
                response.ContentType = "application/octet-stream";
                response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                response.WriteFile(fileInfo.FullName);
                response.Flush();
                try
                {
                    //File.Delete(filePath);
                }
                catch (Exception exx)
                {
                    throw new Exception(exx.Message);
                }
                finally
                {
                    response.End();
                }

            
           
           
        }
        #endregion


        #region 景观农业导出Excel报告
        /// <summary>
        /// admin 下载景观农业项目的Excel=====================================
        /// </summary>
        /// <param name="response"></param>
        /// <param name="path"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void downjgExcel(HttpResponse response, string path, int year, int season)
        {
            int month = season * 3;

            
            Dictionary<String, String> admin_dic = getjgMoneyAndCount(year, season, 2);//admin查看表示2
            Dictionary<String, String> lq_dic = getjgMoneyAndCountByAddress(year, season, 2, "lqy");
            Dictionary<String, String> sl_dic = getjgMoneyAndCountByAddress(year, season, 2, "sl");
            Dictionary<String, String> jt_dic = getjgMoneyAndCountByAddress(year, season, 2, "jt");
            Dictionary<String, String> qbj_dic = getjgMoneyAndCountByAddress(year, season, 2, "qbj");
            Dictionary<String, String> xj_dic = getjgMoneyAndCountByAddress(year, season, 2, "xj");


            string filename = "jg_"+System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            XlsDocument xls = new XlsDocument();//新建一个xls文档
            xls.FileName = filename + ".xls";//设定文件名
            //Add some metadata (visible from Excel under File -> Properties)
            //xls.SummaryInformation.Author = "sun"; //填加xls文件作者信息
            //xls.SummaryInformation.Subject = "A wacky display of Excel file generation";//填加文件主题信息
            //xls.DocumentSummaryInformation.Company = "in2bits.org";//填加文件公司信息
            string sheetName = "总表";
            Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
            Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXF.Font.FontName = "宋体";//设定字体
            cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXF.UseBorder = true;//使用边框
            cellXF.TextWrapRight = true;//自动换行
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.RightLineColor = Colors.Black;
            cellXF.RightLineStyle = 1;
            ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
            col1.ColumnIndexStart = 1;//起始列为第1列
            col1.ColumnIndexEnd = 31;//终止列为第1列
            col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
            sheet.AddColumnInfo(col1);//把格式附加到sheet页上

            //===================================设置标题=====================================================//
            MergeArea meaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 20 * 20;
            cellXF.Font.Bold = true;
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
           
            Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表", cellXF);
            //==============================================设置表头===============================================//
            MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA1);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 15 * 15;
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.Font.Bold = true;
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell cell2 = null;
            //设置边框
            for (int i = 1; i < 15; i++)
            {
                for(int j=2;j<100;j++)
                  cell2=cells.Add(j, i, "", cellXF);
            }
             cell2 = cells.Add(4, 1, "序号", cellXF);
            //=============
            cell2.Font.FontName = "Times New Roman";
            MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
            sheet.AddMergeArea(meaA2);
            cell2 = cells.Add(4, 2, "县（区、市）", cellXF);
            MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
            sheet.AddMergeArea(meaA3);
            cell2 = cells.Add(4, 3, "项目名称", cellXF);
            MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
            sheet.AddMergeArea(meaA4);
            cell2 = cells.Add(4, 4, "建设地址", cellXF);
            MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
            sheet.AddMergeArea(meaA5);
            cell2 = cells.Add(4, 5, "建设起止年限", cellXF);
            MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
            sheet.AddMergeArea(meaA6);
            cell2 = cells.Add(4, 6, "项目建设规模", cellXF);
            MergeArea meaAt7 = new MergeArea(4, 4, 7, 9);
            sheet.AddMergeArea(meaAt7);
            cell2 = cells.Add(4, 7, "目标计划", cellXF);
            MergeArea meaA7 = new MergeArea(5, 6, 7, 7);
            sheet.AddMergeArea(meaA7);
            cell2 = cells.Add(5, 7, "计划总投资", cellXF);
            MergeArea meaA8 = new MergeArea(5, 6, 8, 8);
            sheet.AddMergeArea(meaA8);
            cell2 = cells.Add(5, 8, year+"年计划投资", cellXF);
            MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
            sheet.AddMergeArea(meaA9);
            cell2 = cells.Add(5, 9, year+"年底工程应达形象进度", cellXF);
            MergeArea meaAt10 = new MergeArea(4, 4, 10, 13);
            sheet.AddMergeArea(meaAt10);
            cell2 = cells.Add(4, 10, "完成情况", cellXF);
            MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
            sheet.AddMergeArea(meaA10);
            cell2 = cells.Add(5, 10, "至"+(year-1)+"年累计完成投资", cellXF);
            MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
            sheet.AddMergeArea(meaA11);
            cell2 = cells.Add(5, 11, "至"+year+"年"+season+"季完成投资", cellXF);

            MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
            sheet.AddMergeArea(meaA12);
            cell2 = cells.Add(5, 12, year+"年1-"+season+"季完成投资", cellXF);
            MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
            sheet.AddMergeArea(meaA13);
            cell2 = cells.Add(5, 13, "目前形象进度", cellXF);
            MergeArea meaA14 = new MergeArea(4, 6, 14, 14);
            sheet.AddMergeArea(meaA14);
            cell2 = cells.Add(4, 14, "项目业主", cellXF);
            //=============================表头完成======================填入正文开始===================
            XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXFcont.Font.FontName = "宋体";//设定字体
            //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXFcont.TextWrapRight = true;//自动换行
            cellXFcont.BottomLineStyle = 1;
            cellXFcont.BottomLineColor = Colors.Black;
            cellXFcont.RightLineColor = Colors.Black;
            cellXFcont.RightLineStyle = 1;
            //==============导入龙泉驿区项目
            DataBase db = new DataBase();
            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'yc')");
        
            cell2 = cells.Add(7, 1, "一、", cellXF);
            cell2 = cells.Add(7, 2, "已成", cellXF);
            int x = 8;
            //int number = 0;
            //double alltotal = 0;
            //double alltotalX = 0;
            //===============================已成=============
          
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2.Rows.Count + x;
            //===================小计
            cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "小计",cellXF);
            cell2 = cells.Add(x, 7, admin_dic["ycc1"] + "", cellXFcont);
            cell2 = cells.Add(x, 8, admin_dic["ycc2"] + "", cellXFcont);
            cell2 = cells.Add(x, 10, admin_dic["ycc3"] + "", cellXFcont);
            cell2 = cells.Add(x, 11, admin_dic["ycc4"] + "", cellXFcont);
            cell2 = cells.Add(x, 12, admin_dic["ycc5"] + "", cellXFcont);
            //=============
            x =  1 + x;
            //====================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'zj')");
            //MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
            //sheet.AddMergeArea(meaAjkjs);
            cell2 = cells.Add(x, 1, "二、",cellXF );
            cell2 = cells.Add(x, 2, "在建", cellXF);
            x = x + 1;

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4.Rows.Count + x;
            //===================小计

            cell2 = cells.Add(x, 1,dt4.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "小计", cellXF);
            cell2 = cells.Add(x, 7, admin_dic["zjc1"] + "", cellXF);
            cell2 = cells.Add(x, 8, admin_dic["zjc2"] + "", cellXF);
            cell2 = cells.Add(x, 10, admin_dic["zjc3"] + "", cellXF);
            cell2 = cells.Add(x, 11, admin_dic["zjc4"] + "", cellXF);
            cell2 = cells.Add(x, 12, admin_dic["zjc5"] + "", cellXF);
            //=============
            x =1 + x;
            //===============================规划=============
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'gh')");
            //MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
            //sheet.AddMergeArea(meaAcjkg);
            cell2 = cells.Add(x, 1, "三、", cellXF);
            cell2 = cells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6.Rows.Count  + x;
            //===================小计

            cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "小计", cellXF);
            cell2 = cells.Add(x, 7, admin_dic["ghc1"] + "", cellXF);
            cell2 = cells.Add(x, 8, admin_dic["ghc2"] + "", cellXF);
            cell2 = cells.Add(x, 10, admin_dic["ghc3"] + "", cellXF);
            cell2 = cells.Add(x, 11, admin_dic["ghc4"] + "", cellXF);
            cell2 = cells.Add(x, 12, admin_dic["ghc5"] + "", cellXF);
            x = x + 1;
            cell2 = cells.Add(x, 1, dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计", cellXF);
            cell2 = cells.Add(x, 7, (decimal.Parse(admin_dic["ghc1"]) + decimal.Parse(admin_dic["ycc1"]) + decimal.Parse(admin_dic["zjc1"])) + "", cellXF);
            cell2 = cells.Add(x, 8, (decimal.Parse(admin_dic["ghc2"]) + decimal.Parse(admin_dic["ycc2"]) + decimal.Parse(admin_dic["zjc2"])) + "", cellXF);
            cell2 = cells.Add(x, 10, (decimal.Parse(admin_dic["ghc3"]) + decimal.Parse(admin_dic["ycc3"]) + decimal.Parse(admin_dic["zjc3"])) + "", cellXF);
            cell2 = cells.Add(x, 11, (decimal.Parse(admin_dic["ghc4"]) + decimal.Parse(admin_dic["ycc4"]) + decimal.Parse(admin_dic["zjc4"])) + "", cellXF);
            cell2 = cells.Add(x, 12, (decimal.Parse(admin_dic["ghc5"]) + decimal.Parse(admin_dic["ycc5"]) + decimal.Parse(admin_dic["zjc5"])) + "", cellXF);
            //=============
            MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
            sheet.AddMergeArea(meaAttaddre);
            cell2 = cells.Add(3, 2, "填报单位（盖章）：");

            MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
            sheet.AddMergeArea(meaAttname);
            cell2 = cells.Add(3, 4, " 填报人：   ");

            MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
            sheet.AddMergeArea(meaAttname1);
            cell2 = cells.Add(3, 6, " 审核人：   ");

            MergeArea meaAtt = new MergeArea(3, 3, 8, 11);
            sheet.AddMergeArea(meaAtt);
            cell2 = cells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea meunit = new MergeArea(3, 3, 12, 13);
            sheet.AddMergeArea(meunit);
            cell2 = cells.Add(3, 12, "单位：万元、亩");

            //汇总所有的资金很项目个数
            //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
            //sheet.AddMergeArea(meaAtt);
            //cell2 = cells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
            //======================================================================================
            string sheetlqName = "龙泉";
            Worksheet sheetlq = xls.Workbook.Worksheets.Add(sheetlqName);//填加名为"总表"的sheetlq页

            Cells lqcells = sheetlq.Cells;//Cells实例是sheetlq页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF lqcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            lqcellXF.Font.FontName = "宋体";//设定字体
            lqcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            lqcellXF.UseBorder = true;//使用边框
            lqcellXF.TextWrapRight = true;//自动换行
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.RightLineColor = Colors.Black;
            lqcellXF.RightLineStyle = 1;
            //cell = lqcells.AddValueCellXF(2, 2, "震", lqcellXF);//以设定好的格式填加cell
            //lqcellXF.Font.FontName = "宋体";
            //cell = lqcells.AddValueCellXF(3, 2, "救", lqcellXF);//格式可以多次使用
            sheetlq.AddColumnInfo(col1);
            //===================================设置标题=====================================================//
            MergeArea lqmeaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 20 * 20;
            lqcellXF.Font.Bold = true;
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell lqcell = lqcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表 (龙泉驿区)", lqcellXF);
            //==============================================设置表头===============================================//
            MergeArea lqmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA1);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 15 * 15;
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.Font.Bold = true;
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell lqcell2 = null;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 2; j < 100; j++)
                    lqcell2 = lqcells.Add(j, i, "", cellXF);
            }
             lqcell2 = lqcells.Add(4, 1, "序号", lqcellXF);
            //=============
            lqcell2.Font.FontName = "Times New Roman";
            MergeArea lqmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetlq.AddMergeArea(lqmeaA2);
            lqcell2 = lqcells.Add(4, 2, "县（区、市）", lqcellXF);
            MergeArea lqmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetlq.AddMergeArea(lqmeaA3);
            lqcell2 = lqcells.Add(4, 3, "项目名称", lqcellXF);
            MergeArea lqmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetlq.AddMergeArea(lqmeaA4);
            lqcell2 = lqcells.Add(4, 4, "建设地址", lqcellXF);
            MergeArea lqmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetlq.AddMergeArea(lqmeaA5);
            lqcell2 = lqcells.Add(4, 5, "建设起止年限", lqcellXF);
            MergeArea lqmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetlq.AddMergeArea(lqmeaA6);
            lqcell2 = lqcells.Add(4, 6, "项目建设规模", lqcellXF);
            MergeArea lqmeaAt7 = new MergeArea(4, 4, 7, 9);
            sheetlq.AddMergeArea(lqmeaAt7);
            lqcell2 = lqcells.Add(4, 7, "目标计划", lqcellXF);
            MergeArea lqmeaA7 = new MergeArea(5, 6, 7, 7);
            sheetlq.AddMergeArea(lqmeaA7);
            lqcell2 = lqcells.Add(5, 7, "计划总投资", lqcellXF);

            MergeArea lqmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetlq.AddMergeArea(lqmeaA8);
            lqcell2 = lqcells.Add(5, 8, year+"年计划投资", lqcellXF);

            MergeArea lqmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetlq.AddMergeArea(lqmeaA9);
            lqcell2 = lqcells.Add(5, 9, year+"年底工程应达形象进度", lqcellXF);

            MergeArea lqmeaAt10 = new MergeArea(4, 4, 10, 13);
            sheetlq.AddMergeArea(lqmeaAt10);
            lqcell2 = lqcells.Add(4, 10, "完成情况", lqcellXF);

            MergeArea lqmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetlq.AddMergeArea(lqmeaA10);
            lqcell2 = lqcells.Add(5, 10, "至"+(year-1)+"年累计完成投资", lqcellXF);
            MergeArea lqmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetlq.AddMergeArea(lqmeaA11);
            lqcell2 = lqcells.Add(5, 11, "至"+year+"年"+season+"季完成投资", lqcellXF);

            MergeArea lqmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetlq.AddMergeArea(lqmeaA12);
            lqcell2 = lqcells.Add(5, 12, year+"年1-"+season+"季完成投资", lqcellXF);

            MergeArea lqmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetlq.AddMergeArea(lqmeaA13);
            lqcell2 = lqcells.Add(5, 13, "目前形象进度", lqcellXF);

            MergeArea lqmeaA14 = new MergeArea(4, 6, 14, 14);
            sheetlq.AddMergeArea(lqmeaA14);
            lqcell2 = lqcells.Add(4, 14, "项目业主", lqcellXF);


            System.Data.DataTable dt2lq = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','lqy',2)");
            //MergeArea meaAtcdclq = new MergeArea(7, 7, 1, 7);
            //sheetlq.AddMergeArea(meaAtcdclq);
            lqcell2 = lqcells.Add(7, 1, "一、", cellXF);
            lqcell2 = lqcells.Add(7, 2, "已成", cellXF);
            x = 8;

            //===============================已成=============
            
            for (int i = 0; i < dt2lq.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2lq.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt2lq.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2lq.Rows.Count  + x;
            //===================小计

            lqcell2 = lqcells.Add(x, 1, dt2lq.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 7, lq_dic["ycc1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["ycc2"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["ycc3"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["ycc4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["ycc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //====================在建=============
            System.Data.DataTable dt4lq = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','lqy',2)");
            //MergeArea meaAjkjslq = new MergeArea(x, x, 1, 7);
            //sheetlq.AddMergeArea(meaAjkjslq);
            lqcell2 = lqcells.Add(x, 1, "二、", cellXF);
            lqcell2 = lqcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt4lq.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4lq.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt4lq.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4lq.Rows.Count + x;
            //===================小计

            lqcell2 = lqcells.Add(x, 1, dt4lq.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 7, lq_dic["zjc1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["zjc2"] + "", cellXF);
            lqcell2 = lqcells.Add(x,10, lq_dic["zjc3"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["zjc4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["zjc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6lq = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','lqy',2)");
            //MergeArea meaAcjkglq = new MergeArea(x, x, 1, 7);
            //sheetlq.AddMergeArea(meaAcjkglq);
            lqcell2 = lqcells.Add(x, 1, "三、", cellXF);
            lqcell2 = lqcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt6lq.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6lq.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt6lq.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6lq.Rows.Count + x;
            //===================小计
            lqcell2 = lqcells.Add(x, 1, dt6lq.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 7, lq_dic["ghc1"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 8, lq_dic["ghc2"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, lq_dic["ghc3"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, lq_dic["ghc4"] + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, lq_dic["ghc5"] + "", cellXF);
            //=============
            x = x + 1;

            lqcell2 = lqcells.Add(x, 1, dt2lq.Rows.Count + dt4lq.Rows.Count + dt6lq.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计", cellXF);
            lqcell2 = lqcells.Add(x, 7, (decimal.Parse(lq_dic["ghc1"]) + decimal.Parse(lq_dic["ycc1"]) + decimal.Parse(lq_dic["zjc1"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 8, (decimal.Parse(lq_dic["ghc2"]) + decimal.Parse(lq_dic["ycc2"]) + decimal.Parse(lq_dic["zjc2"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 10, (decimal.Parse(lq_dic["ghc3"]) + decimal.Parse(lq_dic["ycc3"]) + decimal.Parse(lq_dic["zjc3"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 11, (decimal.Parse(lq_dic["ghc4"]) + decimal.Parse(lq_dic["ycc4"]) + decimal.Parse(lq_dic["zjc4"])) + "", cellXF);
            lqcell2 = lqcells.Add(x, 12, (decimal.Parse(lq_dic["ghc5"]) + decimal.Parse(lq_dic["ycc5"]) + decimal.Parse(lq_dic["zjc5"])) + "", cellXF);
            //MergeArea meaAttlq = new MergeArea(3, 3, 1, 7);
            //sheetlq.AddMergeArea(meaAttlq);
            //lqcell2 = lqcells.Add(3, 1, "[填报单位（盖章）：  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);

            MergeArea lqmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetlq.AddMergeArea(lqmeaAttaddre);
            lqcell2 = lqcells.Add(3, 2, "填报单位（盖章）");

            MergeArea lqmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetlq.AddMergeArea(lqmeaAttname);
            lqcell2 = lqcells.Add(3, 4, " 填报人：   ");
            MergeArea lqmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetlq.AddMergeArea(lqmeaAttname1);
            lqcell2 = lqcells.Add(3, 6, " 审核人：   ");

            MergeArea lqmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetlq.AddMergeArea(lqmeaAtt);
            lqcell2 = lqcells.Add(3, 8, "  此表统计时间截止：" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea lqmeunit = new MergeArea(3, 3, 12, 13);
            sheetlq.AddMergeArea(lqmeunit);
            lqcell2 = lqcells.Add(3, 12, "单位：万元、亩");


            ////汇总所有的资金很项目个数
            //MergeArea meaAttlq = new MergeArea(3, 3, 1, 7);
            //sheetlq.AddMergeArea(meaAttlq);
            //lqcell2 = lqcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
            //==========================双流========================================
            string sheetslName = "双流";
            Worksheet sheetsl = xls.Workbook.Worksheets.Add(sheetslName);//填加名为"总表"的sheetsl页

            Cells slcells = sheetsl.Cells;//Cells实例是sheetsl页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF slcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            slcellXF.Font.FontName = "宋体";//设定字体
            slcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            slcellXF.UseBorder = true;//使用边框
            slcellXF.TextWrapRight = true;//自动换行
            slcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            slcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            sheetsl.AddColumnInfo(col1);
            //===================================设置标题=====================================================//
            MergeArea slmeaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 20 * 20;
            slcellXF.Font.Bold = true;
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell = slcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(双流县)", slcellXF);
            //==============================================设置表头===============================================//
            MergeArea slmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA1);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 15 * 15;
            slcellXF.BottomLineStyle = 1;
            slcellXF.BottomLineColor = Colors.Black;
            slcellXF.Font.Bold = true;
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell2 = null;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 2; j < 100; j++)
                    slcell2 = slcells.Add(j, i, "", cellXF);
            }

             slcell2 = slcells.Add(4, 1, "序号", slcellXF);
            //=============
            slcell2.Font.FontName = "Times New Roman";
            MergeArea slmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetsl.AddMergeArea(slmeaA2);
            slcell2 = slcells.Add(4, 2, "县（区、市）", slcellXF);
            MergeArea slmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetsl.AddMergeArea(slmeaA3);
            slcell2 = slcells.Add(4, 3, "项目名称", slcellXF);
            MergeArea slmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetsl.AddMergeArea(slmeaA4);
            slcell2 = slcells.Add(4, 4, "建设地址", slcellXF);
            MergeArea slmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetsl.AddMergeArea(slmeaA5);
            slcell2 = slcells.Add(4, 5, "建设起止年限", slcellXF);
            MergeArea slmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetsl.AddMergeArea(slmeaA6);
            slcell2 = slcells.Add(4, 6, "项目建设规模", slcellXF);
            MergeArea slmeaAt7 = new MergeArea(4, 4, 7, 9);
            sheetsl.AddMergeArea(slmeaAt7);
            slcell2 = slcells.Add(4, 7, "目标计划", slcellXF);
            MergeArea slmeaA7 = new MergeArea(5, 6, 7, 7);
            sheetsl.AddMergeArea(slmeaA7);
            slcell2 = slcells.Add(5, 7, "计划总投资", slcellXF);

            MergeArea slmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetsl.AddMergeArea(slmeaA8);
            slcell2 = slcells.Add(5, 8, year+"年计划投资", slcellXF);

            MergeArea slmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetsl.AddMergeArea(slmeaA9);
            slcell2 = slcells.Add(5, 9, year+"年底工程应达形象进度", slcellXF);

            MergeArea slmeaAt10 = new MergeArea(4, 4, 10, 13);
            sheetsl.AddMergeArea(slmeaAt10);
            slcell2 = slcells.Add(4, 10, "完成情况", slcellXF);

            MergeArea slmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetsl.AddMergeArea(slmeaA10);
            slcell2 = slcells.Add(5, 10, "至"+(year-1)+"年累计完成投资", slcellXF);
            MergeArea slmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetsl.AddMergeArea(slmeaA11);
            slcell2 = slcells.Add(5, 11, "至"+year+"年"+season+"季完成投资", slcellXF);

            MergeArea slmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetsl.AddMergeArea(slmeaA12);
            slcell2 = slcells.Add(5, 12, year+"年1-"+season+"季完成投资", slcellXF);

            MergeArea slmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetsl.AddMergeArea(slmeaA13);
            slcell2 = slcells.Add(5, 13, "目前形象进度", slcellXF);

            MergeArea slmeaA14 = new MergeArea(4, 6, 14, 14);
            sheetsl.AddMergeArea(slmeaA14);
            slcell2 = slcells.Add(4, 14, "项目业主", slcellXF);


            System.Data.DataTable dt2sl = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','sl',2)");
            //MergeArea meaAtcdcsl = new MergeArea(7, 7, 1, 7);
            //sheetsl.AddMergeArea(meaAtcdcsl);
            slcell2 = slcells.Add(7, 1, "一、", cellXF);
            slcell2 = slcells.Add(7, 2, "已成", cellXF);
            x = 8;

            //===============================已成=============
            
            for (int i = 0; i < dt2sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dt2sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2sl.Rows.Count+ x;
            //===================小计
            slcell2 = slcells.Add(x, 1, dt2sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 7, sl_dic["ycc1"] + "", cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["ycc2"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["ycc3"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["ycc4"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["ycc5"] + "", cellXF);
            //=============
            x =  1 + x;
            //====================在建=============
            System.Data.DataTable dt4sl = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','sl',2)");
            //MergeArea meaAjkjssl = new MergeArea(x, x, 1, 7);
            //sheetsl.AddMergeArea(meaAjkjssl);
            slcell2 = slcells.Add(x, 1, "二、", cellXF);
            slcell2 = slcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dt4sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4sl.Rows.Count + x;
            //===================小计
            slcell2 = slcells.Add(x, 1, dt4sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 7, sl_dic["zjc1"] + "", cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["zjc2"] + "", cellXF);
            slcell2 = slcells.Add(x, 10, sl_dic["zjc3"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["zjc4"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["zjc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6sl = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','sl',2)");
            //MergeArea meaAcjkgsl = new MergeArea(x, x, 1, 7);
            //sheetsl.AddMergeArea(meaAcjkgsl);
            slcell2 = slcells.Add(x, 1, "三、", cellXF);
            slcell2 = slcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt6sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = lqcells.Add(i + x, j + 2, dt6sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6sl.Rows.Count  + x;
            //===================小计

            slcell2 = slcells.Add(x, 1, dt6sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 7, sl_dic["ghc1"] + "", cellXF);
            slcell2 = slcells.Add(x, 8, sl_dic["ghc2"] + "", cellXF);
            slcell2 = slcells.Add(x,10, sl_dic["ghc3"] + "", cellXF);
            slcell2 = slcells.Add(x, 11, sl_dic["ghc4"] + "", cellXF);
            slcell2 = slcells.Add(x, 12, sl_dic["ghc5"] + "", cellXF);
            x = x + 1;
            slcell2 = slcells.Add(x, 1, dt2sl.Rows.Count + dt4sl.Rows.Count + dt6sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计", cellXF);
            slcell2 = slcells.Add(x, 7, (decimal.Parse(sl_dic["ghc1"]) + decimal.Parse(sl_dic["ycc1"]) + decimal.Parse(sl_dic["zjc1"])) + "", cellXF);
            slcell2 = slcells.Add(x, 8, (decimal.Parse(sl_dic["ghc2"]) + decimal.Parse(sl_dic["ycc2"]) + decimal.Parse(sl_dic["zjc2"])) + "", cellXF);
            slcell2 = slcells.Add(x, 10, (decimal.Parse(sl_dic["ghc3"]) + decimal.Parse(sl_dic["ycc3"]) + decimal.Parse(sl_dic["zjc3"])) + "", cellXF);
            slcell2 = slcells.Add(x, 11, (decimal.Parse(sl_dic["ghc4"]) + decimal.Parse(sl_dic["ycc4"]) + decimal.Parse(sl_dic["zjc4"])) + "", cellXF);
            slcell2 = slcells.Add(x, 12, (decimal.Parse(sl_dic["ghc5"]) + decimal.Parse(sl_dic["ycc5"]) + decimal.Parse(sl_dic["zjc5"])) + "", cellXF);
            //=============
            MergeArea slmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetsl.AddMergeArea(slmeaAttaddre);
            slcell2 = slcells.Add(3, 2, "填报单位（盖章）");

            MergeArea slmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetsl.AddMergeArea(slmeaAttname);
            slcell2 = slcells.Add(3, 4, " 填报人：   ");
            MergeArea slmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetsl.AddMergeArea(slmeaAttname1);
            slcell2 = slcells.Add(3, 6, " 审核人：   ");

            MergeArea slmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetsl.AddMergeArea(slmeaAtt);
            slcell2 = slcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea slmeunit = new MergeArea(3, 3, 12, 13);
            sheetsl.AddMergeArea(slmeunit);
            slcell2 = slcells.Add(3, 12, "单位：万元、亩");


            //MergeArea meaAttsl = new MergeArea(3, 3, 1, 7);
            //sheetsl.AddMergeArea(meaAttsl);
            //slcell2 = slcells.Add(3, 1, "[填报单位（盖章）：  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            ////汇总所有的资金很项目个数
            //MergeArea meaAttsl = new MergeArea(3, 3, 1, 7);
            //sheetsl.AddMergeArea(meaAttsl);
            //slcell2 = lqcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);

            //===============================金堂===========================
            string sheetjtxName = "金堂";
            Worksheet sheetjtx = xls.Workbook.Worksheets.Add(sheetjtxName);//填加名为"总表"的sheetjtx页

            Cells jtxcells = sheetjtx.Cells;//Cells实例是sheetjtx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF jtxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            jtxcellXF.Font.FontName = "宋体";//设定字体
            jtxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            jtxcellXF.UseBorder = true;//使用边框
            jtxcellXF.TextWrapRight = true;//自动换行
            jtxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            jtxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            sheetjtx.AddColumnInfo(col1);
            //===================================设置标题=====================================================//
            MergeArea jtxmeaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 20 * 20;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell jtxcell = jtxcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(金堂县)", jtxcellXF);
            //==============================================设置表头===============================================//
            MergeArea jtxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA1);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 15 * 15;
            jtxcellXF.BottomLineStyle = 1;
            jtxcellXF.BottomLineColor = Colors.Black;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell jtxcell2 = null;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 2; j < 100; j++)
                    jtxcell2 = jtxcells.Add(j, i, "", cellXF);
            }
             jtxcell2 = jtxcells.Add(4, 1, "序号", jtxcellXF);
            //=============
            jtxcell2.Font.FontName = "Times New Roman";
            MergeArea jtxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetjtx.AddMergeArea(jtxmeaA2);
            jtxcell2 = jtxcells.Add(4, 2, "县（区、市）", jtxcellXF);
            MergeArea jtxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetjtx.AddMergeArea(jtxmeaA3);
            jtxcell2 = jtxcells.Add(4, 3, "项目名称", jtxcellXF);
            MergeArea jtxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetjtx.AddMergeArea(slmeaA4);
            jtxcell2 = jtxcells.Add(4, 4, "建设地址", jtxcellXF);
            MergeArea jtxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetjtx.AddMergeArea(jtxmeaA5);
            jtxcell2 = jtxcells.Add(4, 5, "建设起止年限", jtxcellXF);
            MergeArea jtxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetjtx.AddMergeArea(jtxmeaA6);
            jtxcell2 = jtxcells.Add(4, 6, "项目建设规模", jtxcellXF);
            MergeArea jtxmeaAt7 = new MergeArea(4, 4, 7, 9);
            sheetjtx.AddMergeArea(jtxmeaAt7);
            jtxcell2 = jtxcells.Add(4, 7, "目标计划", jtxcellXF);
            MergeArea jtxmeaA7 = new MergeArea(5, 6, 7, 7);
            sheetjtx.AddMergeArea(jtxmeaA7);
            jtxcell2 = jtxcells.Add(4, 7, "计划总投资", jtxcellXF);

            MergeArea jtxmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetjtx.AddMergeArea(jtxmeaA8);
            jtxcell2 = jtxcells.Add(5, 8, year+"年计划投资", jtxcellXF);

            MergeArea jtxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetjtx.AddMergeArea(jtxmeaA9);
            jtxcell2 = jtxcells.Add(5, 9, year+"年底工程应达形象进度", jtxcellXF);

            MergeArea jtxmeaAt10 = new MergeArea(4, 4, 10, 13);
            sheetjtx.AddMergeArea(jtxmeaAt10);
            jtxcell2 = jtxcells.Add(4, 10, "完成情况", jtxcellXF);

            MergeArea jtxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetjtx.AddMergeArea(jtxmeaA10);
            jtxcell2 = jtxcells.Add(5, 10, "至"+(year-1)+"年累计完成投资", jtxcellXF);
            MergeArea jtxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetjtx.AddMergeArea(jtxmeaA11);
            jtxcell2 = jtxcells.Add(5, 11, "至"+year+"年"+season+"季完成投资", jtxcellXF);

            MergeArea jtxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetjtx.AddMergeArea(jtxmeaA12);
            jtxcell2 = jtxcells.Add(5, 12, year+"年1-"+season+"季完成投资", jtxcellXF);

            MergeArea jtxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetjtx.AddMergeArea(jtxmeaA13);
            jtxcell2 = jtxcells.Add(5, 13, "目前形象进度", jtxcellXF);

            MergeArea jtxmeaA14 = new MergeArea(4, 6, 14, 14);
            sheetjtx.AddMergeArea(jtxmeaA14);
            jtxcell2 = jtxcells.Add(4, 14, "项目业主", jtxcellXF);




            System.Data.DataTable dt2jtx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','jt',2)");
            //MergeArea meaAtcdcjtx = new MergeArea(7, 7, 1, 7);
            //sheetjtx.AddMergeArea(meaAtcdcjtx);
            jtxcell2 = jtxcells.Add(7, 1, "一、", cellXF);
            jtxcell2 = jtxcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
            
            for (int i = 0; i < dt2jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt2jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2jtx.Rows.Count  + x;
            //===================小计

            jtxcell2 = jtxcells.Add(x, 1, dt2jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 7, jt_dic["ycc1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["ycc2"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["ycc3"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["ycc4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["ycc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //====================在建=============
            System.Data.DataTable dt4jtx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','jt',2)");
            //MergeArea meaAjkjsjtx = new MergeArea(x, x, 1, 7);
            //sheetjtx.AddMergeArea(meaAjkjsjtx);
            jtxcell2 = jtxcells.Add(x, 1, "二、", cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt4jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4jtx.Rows.Count  + x;
            //===================小计
            jtxcell2 = jtxcells.Add(x, 1, dt4jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 7, jt_dic["zjc1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["zjc2"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["zjc3"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["zjc4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["zjc5"] + "", cellXF);
            //=============
            x =  1 + x;
            //===============================规划=============
            System.Data.DataTable dt6jtx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','jt',2)");
            //MergeArea meaAcjkgjtx = new MergeArea(x, x, 1, 7);
            //sheetjtx.AddMergeArea(meaAcjkgjtx);
            jtxcell2 = jtxcells.Add(x, 1, "三、", cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt6jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt6jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6jtx.Rows.Count  + x;
            //===================小计
            jtxcell2 = jtxcells.Add(x, 1, dt6jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 7, jt_dic["ghc1"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, jt_dic["ghc2"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, jt_dic["ghc3"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, jt_dic["ghc4"] + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, jt_dic["ghc5"] + "", cellXF);
            //=============

            //===================总合计
            x = x + 1;
            jtxcell2 = jtxcells.Add(x, 1, dt2jtx.Rows.Count + dt4jtx.Rows.Count + dt6jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计", cellXF);
            jtxcell2 = jtxcells.Add(x, 7, (decimal.Parse(jt_dic["ghc1"]) + decimal.Parse(jt_dic["ycc1"]) + decimal.Parse(jt_dic["zjc1"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 8, (decimal.Parse(jt_dic["ghc2"]) + decimal.Parse(jt_dic["ycc2"]) + decimal.Parse(jt_dic["zjc2"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 10, (decimal.Parse(jt_dic["ghc3"]) + decimal.Parse(jt_dic["ycc3"]) + decimal.Parse(jt_dic["zjc3"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 11, (decimal.Parse(jt_dic["ghc4"]) + decimal.Parse(jt_dic["ycc4"]) + decimal.Parse(jt_dic["zjc4"])) + "", cellXF);
            jtxcell2 = jtxcells.Add(x, 12, (decimal.Parse(jt_dic["ghc5"]) + decimal.Parse(jt_dic["ycc5"]) + decimal.Parse(jt_dic["zjc5"])) + "", cellXF);
            //=============

            MergeArea jtxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetjtx.AddMergeArea(jtxmeaAttaddre);
            jtxcell2 = jtxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea jtxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetjtx.AddMergeArea(jtxmeaAttname);
            jtxcell2 = jtxcells.Add(3, 4, " 填报人：   ");

            MergeArea jtxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetjtx.AddMergeArea(jtxmeaAttname1);
            jtxcell2 = jtxcells.Add(3, 6, " 审核人：   ");

            MergeArea jtxmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetjtx.AddMergeArea(jtxmeaAtt);
            jtxcell2 = jtxcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea jtmeunit = new MergeArea(3, 3, 12, 13);
            sheetjtx.AddMergeArea(jtmeunit);
            jtxcell2 = jtxcells.Add(3, 12, "单位：万元、亩");

            //MergeArea meaAttjtx = new MergeArea(3, 3, 1, 7);
            //sheetjtx.AddMergeArea(meaAttjtx);
            //jtxcell2 = jtxcells.Add(3, 1, "[填报单位（盖章）：  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            ////汇总所有的资金很项目个数
            //MergeArea meaAttjtx = new MergeArea(3, 3, 1, 7);
            //sheetjtx.AddMergeArea(meaAttjtx);
            //jtxcell2 = jtxcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);

            //============================================青白江=================

            string sheetqbjName = "青白江";
            Worksheet sheetqbj = xls.Workbook.Worksheets.Add(sheetqbjName);//填加名为"总表"的sheetqbj页

            Cells qbjcells = sheetqbj.Cells;//Cells实例是sheetqbj页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbjcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbjcellXF.Font.FontName = "宋体";//设定字体
            qbjcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbjcellXF.UseBorder = true;//使用边框
            qbjcellXF.TextWrapRight = true;//自动换行
            qbjcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbjcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            sheetqbj.AddColumnInfo(col1);
            //===================================设置标题=====================================================//
            MergeArea qbjmeaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 20 * 20;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbjcell = qbjcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(青白江区)", qbjcellXF);
            //==============================================设置表头===============================================//
            MergeArea qbjmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA1);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 15 * 15;
            qbjcellXF.BottomLineStyle = 1;
            qbjcellXF.BottomLineColor = Colors.Black;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbjcell2 = null;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 2; j < 100; j++)
                    qbjcell2 = qbjcells.Add(j, i, "", cellXF);
            }
            qbjcell2 = qbjcells.Add(4, 1, "序号", qbjcellXF);
            //=============
            qbjcell2.Font.FontName = "Times New Roman";
            MergeArea qbjmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbj.AddMergeArea(qbjmeaA2);
            qbjcell2 = qbjcells.Add(4, 2, "县（区、市）", qbjcellXF);
            MergeArea qbjmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbj.AddMergeArea(qbjmeaA3);
            qbjcell2 = qbjcells.Add(4, 3, "项目名称", qbjcellXF);
            MergeArea qbjmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbj.AddMergeArea(qbjmeaA4);
            qbjcell2 = qbjcells.Add(4, 4, "建设地址", qbjcellXF);
            MergeArea qbjmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbj.AddMergeArea(qbjmeaA5);
            qbjcell2 = qbjcells.Add(4, 5, "建设起止年限", qbjcellXF);
            MergeArea qbjmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbj.AddMergeArea(qbjmeaA6);
            qbjcell2 = qbjcells.Add(4, 6, "项目建设规模", qbjcellXF);
            MergeArea qbjmeaAt7 = new MergeArea(4, 4, 7, 9);
            sheetqbj.AddMergeArea(qbjmeaAt7);
            qbjcell2 = qbjcells.Add(4, 7, "目标计划", qbjcellXF);
            MergeArea qbjmeaA7 = new MergeArea(5, 6, 7, 7);
            sheetqbj.AddMergeArea(qbjmeaA7);
            qbjcell2 = qbjcells.Add(5, 7, "计划总投资", qbjcellXF);

            MergeArea qbjmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetqbj.AddMergeArea(qbjmeaA8);
            qbjcell2 = qbjcells.Add(5, 8, year+"年计划投资", qbjcellXF);

            MergeArea qbjmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbj.AddMergeArea(qbjmeaA9);
            qbjcell2 = qbjcells.Add(5, 9, year+"年底工程应达形象进度", qbjcellXF);

            MergeArea qbjmeaAt10 = new MergeArea(4, 4, 10, 13);
            sheetqbj.AddMergeArea(qbjmeaAt10);
            qbjcell2 = qbjcells.Add(4, 10, "完成情况", qbjcellXF);

            MergeArea qbjmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbj.AddMergeArea(qbjmeaA10);
            qbjcell2 = qbjcells.Add(5, 10, "至"+(year-1)+"年累计完成投资", qbjcellXF);
            MergeArea qbjmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbj.AddMergeArea(qbjmeaA11);
            qbjcell2 = qbjcells.Add(5, 11, "至"+year+"年"+season+"季完成投资", qbjcellXF);

            MergeArea qbjmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbj.AddMergeArea(qbjmeaA12);
            qbjcell2 = qbjcells.Add(5, 12, year+"年1-"+season+"季完成投资", qbjcellXF);

            MergeArea qbjmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbj.AddMergeArea(qbjmeaA13);
            qbjcell2 = qbjcells.Add(5, 13, "目前形象进度", qbjcellXF);

            MergeArea qbjmeaA14 = new MergeArea(4, 6, 14, 14);
            sheetqbj.AddMergeArea(qbjmeaA14);
            qbjcell2 = qbjcells.Add(4, 14, "项目业主", qbjcellXF);



            System.Data.DataTable dt2qbj = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','qbj',2)");
            //MergeArea meaAtcdcqbj = new MergeArea(7, 7, 1, 7);
            //sheetqbj.AddMergeArea(meaAtcdcqbj);
            qbjcell2 = qbjcells.Add(7, 1, "一、", cellXF);
            qbjcell2 = qbjcells.Add(7, 2, "已成", cellXF);

            x = 8;

            //===============================已成=============
           
            for (int i = 0; i < dt2qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt2qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2qbj.Rows.Count  + x;
            //===================小计

            qbjcell2 = qbjcells.Add(x, 1, dt2qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 7, qbj_dic["ycc1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["ycc2"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["ycc3"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["ycc4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["ycc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //====================在建=============
            System.Data.DataTable dt4qbj = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','qbj',2)");
            //MergeArea meaAjkjsqbj = new MergeArea(x, x, 1, 7);
            //sheetqbj.AddMergeArea(meaAjkjsqbj);
            qbjcell2 = qbjcells.Add(x, 1, "二、", cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt4qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4qbj.Rows.Count + x;
            //===================小计

            qbjcell2 = qbjcells.Add(x, 1, dt4qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 7, qbj_dic["zjc1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["zjc2"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["zjc3"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["zjc4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["zjc5"] + "", cellXF);
            //=============
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6qbj = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','qbj',2)");
            //MergeArea meaAcjkgqbj = new MergeArea(x, x, 1, 7);
            //sheetqbj.AddMergeArea(meaAcjkgjtx);
            qbjcell2 = qbjcells.Add(x, 1, "三、", cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt6qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt6qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6qbj.Rows.Count  + x;
            //===================小计

            qbjcell2 = qbjcells.Add(x, 1, dt6qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 7, qbj_dic["ghc1"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 8, qbj_dic["ghc2"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, qbj_dic["ghc3"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, qbj_dic["ghc4"] + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, qbj_dic["ghc5"] + "", cellXF);
            //=============
            //===================总合计
            x = x + 1;
            qbjcell2 = qbjcells.Add(x, 1, dt2qbj.Rows.Count + dt4qbj.Rows.Count + dt6qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计", cellXF);
            qbjcell2 = qbjcells.Add(x, 7, (decimal.Parse(qbj_dic["ghc1"]) + decimal.Parse(qbj_dic["ycc1"]) + decimal.Parse(qbj_dic["zjc1"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 8, (decimal.Parse(qbj_dic["ghc2"]) + decimal.Parse(qbj_dic["ycc2"]) + decimal.Parse(qbj_dic["zjc2"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 10, (decimal.Parse(qbj_dic["ghc3"]) + decimal.Parse(qbj_dic["ycc3"]) + decimal.Parse(qbj_dic["zjc3"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 11, (decimal.Parse(qbj_dic["ghc4"]) + decimal.Parse(qbj_dic["ycc4"]) + decimal.Parse(qbj_dic["zjc4"])) + "", cellXF);
            qbjcell2 = qbjcells.Add(x, 12, (decimal.Parse(qbj_dic["ghc5"]) + decimal.Parse(qbj_dic["ycc5"]) + decimal.Parse(qbj_dic["zjc5"])) + "", cellXF);
            //=============

            MergeArea qbjmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbj.AddMergeArea(qbjmeaAttaddre);
            qbjcell2 = qbjcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbjmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbj.AddMergeArea(qbjmeaAttname);
            qbjcell2 = qbjcells.Add(3, 4, " 填报人：   ");
            MergeArea qbjmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbj.AddMergeArea(qbjmeaAttname1);
            qbjcell2 = qbjcells.Add(3, 6, " 审核人：   ");


            MergeArea qbjmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetqbj.AddMergeArea(qbjmeaAtt);
            qbjcell2 = qbjcells.Add(3,8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea qbjmeunit = new MergeArea(3, 3, 12, 13);
            sheetqbj.AddMergeArea(qbjmeunit);
            qbjcell2 = qbjcells.Add(3, 12, "单位：万元、亩");

            //MergeArea meaAttqbj = new MergeArea(3, 3, 1, 7);
            //sheetqbj.AddMergeArea(meaAttqbj);
            //qbjcell2 = qbjcells.Add(3, 1, "[填报单位（盖章）：  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            ////汇总所有的资金很项目个数
            //MergeArea meaAttqbj = new MergeArea(3, 3, 1, 7);
            //sheetqbj.AddMergeArea(meaAttqbj);
            //qbjcell2 = qbjcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
            //=============================新津==================
            string sheetqbxName = "新津";
            Worksheet sheetqbx = xls.Workbook.Worksheets.Add(sheetqbxName);//填加名为"总表"的sheetqbx页

            Cells qbxcells = sheetqbx.Cells;//Cells实例是sheetqbx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbxcellXF.Font.FontName = "宋体";//设定字体
            qbxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbxcellXF.UseBorder = true;//使用边框
            qbxcellXF.TextWrapRight = true;//自动换行
            qbxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            sheetqbx.AddColumnInfo(col1);
            //===================================设置标题=====================================================//
            MergeArea qbxmeaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 20 * 20;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbxcell = qbxcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(新津)", qbxcellXF);
            //==============================================设置表头===============================================//
            MergeArea qbxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA1);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 15 * 15;
            qbxcellXF.BottomLineStyle = 1;
            qbxcellXF.BottomLineColor = Colors.Black;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbxcell2 = null;
            for (int i = 1; i < 15; i++)
            {
                for (int j = 2; j < 100; j++)
                    qbxcell2 = qbxcells.Add(j, i, "", cellXF);
            }
             qbxcell2 = qbxcells.Add(4, 1, "序号", qbxcellXF);
            //=============
            qbxcell2.Font.FontName = "Times New Roman";
            MergeArea qbxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbx.AddMergeArea(qbxmeaA2);
            qbxcell2 = qbxcells.Add(4, 2, "县（区、市）", qbxcellXF);
            MergeArea qbxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbx.AddMergeArea(qbxmeaA3);
            qbxcell2 = qbxcells.Add(4, 3, "项目名称", qbxcellXF);
            MergeArea qbxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbx.AddMergeArea(qbxmeaA4);
            qbxcell2 = qbxcells.Add(4, 4, "建设地址", qbxcellXF);
            MergeArea qbxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbx.AddMergeArea(qbxmeaA5);
            qbxcell2 = qbxcells.Add(4, 5, "建设起止年限", qbxcellXF);
            MergeArea qbxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbx.AddMergeArea(qbxmeaA6);
            qbxcell2 = qbxcells.Add(4, 6, "项目建设规模", qbxcellXF);
            MergeArea qbxmeaAt7 = new MergeArea(4, 4, 7, 9);
            sheetqbx.AddMergeArea(qbxmeaAt7);
            qbxcell2 = qbxcells.Add(4, 7, "目标计划", qbxcellXF);
            MergeArea qbxmeaA7 = new MergeArea(5, 6, 7, 7);
            sheetqbx.AddMergeArea(qbxmeaA7);
            qbxcell2 = qbxcells.Add(5, 7, "计划总投资", qbxcellXF);

            MergeArea qbxmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetqbx.AddMergeArea(qbxmeaA8);
            qbxcell2 = qbxcells.Add(5, 8, year+"年计划投资", qbxcellXF);

            MergeArea qbxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbx.AddMergeArea(qbxmeaA9);
            qbxcell2 = qbxcells.Add(5, 9, year+"年底工程应达形象进度", qbxcellXF);

            MergeArea qbxmeaAt10 = new MergeArea(4, 4, 10, 13);
            sheetqbx.AddMergeArea(qbxmeaAt10);
            qbxcell2 = qbxcells.Add(4, 10, "完成情况", qbxcellXF);

            MergeArea qbxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbx.AddMergeArea(qbxmeaA10);
            qbxcell2 = qbxcells.Add(5, 10, "至"+(year-1)+"年累计完成投资", qbxcellXF);
            MergeArea qbxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbx.AddMergeArea(qbxmeaA11);
            qbxcell2 = qbxcells.Add(5, 11, "至"+year+"年"+season+"季完成投资", qbxcellXF);

            MergeArea qbxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbx.AddMergeArea(qbxmeaA12);
            qbxcell2 = qbxcells.Add(5, 12, year+"年1-"+season+"季完成投资", qbxcellXF);

            MergeArea qbxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbx.AddMergeArea(qbxmeaA13);
            qbxcell2 = qbxcells.Add(5, 13, "目前形象进度", qbxcellXF);

            MergeArea qbxmeaA14 = new MergeArea(4, 6, 14, 14);
            sheetqbx.AddMergeArea(qbxmeaA14);
            qbxcell2 = qbxcells.Add(4, 14, "项目业主", qbxcellXF);

            System.Data.DataTable dt2qbx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','xj',2)");
            //MergeArea meaAtcdcqbx = new MergeArea(7, 7, 1, 7);
            //sheetqbx.AddMergeArea(meaAtcdcqbx);
            qbxcell2 = qbxcells.Add(7, 1, "一、", cellXF);
            qbxcell2 = qbxcells.Add(7, 2, "已成", cellXF);
            x = 8;

            //===============================已成=============
            
            for (int i = 0; i < dt2qbx.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt2qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2qbx.Rows.Count + x;
            //===================小计
            qbxcell2 = qbxcells.Add(x, 1, dt2qbx.Rows.Count , cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 7, xj_dic["ycc1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["ycc2"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["ycc3"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["ycc4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["ycc5"] + "", cellXF);
            //=============
            x =  1 + x;
            //====================在建=============
            System.Data.DataTable dt4qbx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','xj',2)");
            //MergeArea meaAjkjsqbx = new MergeArea(x, x, 1, 7);
            //sheetqbx.AddMergeArea(meaAjkjsqbx);
            qbxcell2 = qbxcells.Add(x, 1, "二、", cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4qbx.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt4qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4qbx.Rows.Count  + x;
            //===================小计

            qbxcell2 = qbxcells.Add(x, 1, dt4qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 7, xj_dic["zjc1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["zjc2"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["zjc3"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["zjc4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["zjc5"] + "", cellXF);
            //=============
            x =  1 + x;
            //===============================规划=============
            System.Data.DataTable dt6qbx = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','xj',2)");
            //MergeArea meaAcjkgqbx = new MergeArea(x, x, 1, 7);
            //sheetqbx.AddMergeArea(meaAcjkgqbx);
            qbxcell2 = qbxcells.Add(x, 1, "三、", cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt6qbj.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt6qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6qbx.Rows.Count  + x;
            //===================小计

            qbxcell2 = qbxcells.Add(x, 1, dt6qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 7, xj_dic["ghc1"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 8, xj_dic["ghc2"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, xj_dic["ghc3"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, xj_dic["ghc4"] + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, xj_dic["ghc5"] + "", cellXF);
            //=============
            //===================总合计
            x = x + 1;
            qbxcell2 = qbxcells.Add(x, 1, dt2qbx.Rows.Count + dt4qbx.Rows.Count + dt6qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计", cellXF);
            qbxcell2 = qbxcells.Add(x, 7, (decimal.Parse(xj_dic["ghc1"]) + decimal.Parse(xj_dic["ycc1"]) + decimal.Parse(xj_dic["zjc1"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 8, (decimal.Parse(xj_dic["ghc2"]) + decimal.Parse(xj_dic["ycc2"]) + decimal.Parse(xj_dic["zjc2"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 10, (decimal.Parse(xj_dic["ghc3"]) + decimal.Parse(xj_dic["ycc3"]) + decimal.Parse(xj_dic["zjc3"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 11, (decimal.Parse(xj_dic["ghc4"]) + decimal.Parse(xj_dic["ycc4"]) + decimal.Parse(xj_dic["zjc4"])) + "", cellXF);
            qbxcell2 = qbxcells.Add(x, 12, (decimal.Parse(xj_dic["ghc5"]) + decimal.Parse(xj_dic["ycc5"]) + decimal.Parse(xj_dic["zjc5"])) + "", cellXF);
            //=============

            MergeArea qbxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbx.AddMergeArea(qbxmeaAttaddre);
            qbxcell2 = qbxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbx.AddMergeArea(qbxmeaAttname);
            qbxcell2 = qbxcells.Add(3, 4, " 填报人：   ");

            MergeArea qbxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbx.AddMergeArea(qbxmeaAttname1);
            qbxcell2 = qbxcells.Add(3, 6, " 审核人：   ");

            MergeArea qbxmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetqbx.AddMergeArea(qbxmeaAtt);
            qbxcell2 = qbxcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea qbxmeunit = new MergeArea(3, 3, 12, 13);
            sheetqbx.AddMergeArea(qbxmeunit);
            qbxcell2 = qbxcells.Add(3, 12, "单位：万元、亩");
            //MergeArea meaAttqbx = new MergeArea(3, 3, 1, 7);
            //sheetqbx.AddMergeArea(meaAttqbx);
            //qbxcell2 = qbxcells.Add(3, 1, "[填报单位（盖章）：  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            //汇总所有的资金很项目个数
            //MergeArea meaAttqbx = new MergeArea(3, 3, 1, 7);
            //sheetqbx.AddMergeArea(meaAttqbx);
            //qbxcell2 = qbxcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
            //=================================
            xls.Save(path);
            string fileName = filename + ".xls";//客户端保存的文件名
            string filePath = (path + "/" + filename + ".xls");//路径
            FileInfo fileInfo = new FileInfo(filePath);
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            response.AddHeader("Content-Length", fileInfo.Length.ToString());
            response.AddHeader("Content-Transfer-Encoding", "binary");
            response.ContentType = "application/octet-stream";
            response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            response.WriteFile(fileInfo.FullName);
            response.Flush();
            try
            {
            //    File.Delete(filePath);
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message);
            }
            finally
            {
                response.End();
            }


        }


       /// <summary>
       /// 一级审核元现在景观农业的Excel
       /// </summary>
       /// <param name="response"></param>
       /// <param name="path"></param>
       /// <param name="year"></param>
       /// <param name="month"></param>
       /// <param name="area"></param>
        public void downjgExcel(HttpResponse response, string path, int year, int season,string area)
        {
            string titleStr = "";
            if (area == "lqy")
            {
                titleStr = "龙泉驿区";
            }
            else if (area == "sl")
            {
                titleStr = "双流县";
            }
            else if (area == "qbj")
            {
                titleStr = "青白江区";
            }
            else if (area == "jt")
            {
                titleStr = "金堂县";
            }
            else if (area == "xj")
            {
                titleStr = "新津县";
            }
            int month = season * 3;
            Dictionary<String, String> dic = getjgMoneyAndCountByAddress(year, season, 2, area);

            

                string filename = "jg_"+area+"_"+System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
                XlsDocument xls = new XlsDocument();//新建一个xls文档
                xls.FileName = filename + ".xls";//设定文件名
                //Add some metadata (visible from Excel under File -> Properties)
                //xls.SummaryInformation.Author = "sun"; //填加xls文件作者信息
                //xls.SummaryInformation.Subject = "A wacky display of Excel file generation";//填加文件主题信息
                //xls.DocumentSummaryInformation.Company = "in2bits.org";//填加文件公司信息
                string sheetName = "总表";
                Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
                Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
                //cell的格式还可以定义在一个xf对象中
                XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXF.Font.FontName = "宋体";//设定字体
                cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXF.UseBorder = true;//使用边框
                cellXF.TextWrapRight = true;//自动换行
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.RightLineColor = Colors.Black;
                cellXF.RightLineStyle = 1;
                ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
                col1.ColumnIndexStart = 1;//起始列为第1列
                col1.ColumnIndexEnd = 31;//终止列为第1列
                col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
                sheet.AddColumnInfo(col1);//把格式附加到sheet页上
                //===================================设置标题=====================================================//
                MergeArea meaA = new MergeArea(1, 2, 1, 14);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 20 * 20;
                cellXF.Font.Bold = true;
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
                Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 景观农业（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表", cellXF);
                //==============================================设置表头===============================================//
                MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA1);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 15 * 15;
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.Font.Bold = true;
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充


                Cell cell2 = null;
                //设置边框
                for (int i = 1; i < 15; i++)
                {
                    for (int j = 2; j < 100; j++)
                        cell2 = cells.Add(j, i, "", cellXF);
                }
                 cell2 = cells.Add(4, 1, "序号", cellXF);
                //=============
                cell2.Font.FontName = "Times New Roman";
                MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
                sheet.AddMergeArea(meaA2);
                cell2 = cells.Add(4, 2, "县（区、市）", cellXF);
                MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
                sheet.AddMergeArea(meaA3);
                cell2 = cells.Add(4, 3, "项目名称", cellXF);
                MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
                sheet.AddMergeArea(meaA4);
                cell2 = cells.Add(4, 4, "建设地址", cellXF);
                MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
                sheet.AddMergeArea(meaA5);
                cell2 = cells.Add(4, 5, "建设起止年限", cellXF);
                MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
                sheet.AddMergeArea(meaA6);
                cell2 = cells.Add(4, 6, "项目建设规模", cellXF);
                MergeArea meaAt7 = new MergeArea(4, 4, 7, 9);
                sheet.AddMergeArea(meaAt7);
                cell2 = cells.Add(4, 7, "目标计划", cellXF);
                MergeArea meaA7 = new MergeArea(5, 6, 7, 7);
                sheet.AddMergeArea(meaA7);
                cell2 = cells.Add(5, 7, "计划总投资", cellXF);
                MergeArea meaA8 = new MergeArea(5, 6, 8, 8);
                sheet.AddMergeArea(meaA8);
                cell2 = cells.Add(5, 8, year+"年计划投资", cellXF);
                MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
                sheet.AddMergeArea(meaA9);
                cell2 = cells.Add(5, 9, year+"年底工程应达形象进度", cellXF);
                MergeArea meaAt10 = new MergeArea(4, 4, 10, 13);
                sheet.AddMergeArea(meaAt10);
                cell2 = cells.Add(4, 10, "完成情况", cellXF);
                MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
                sheet.AddMergeArea(meaA10);
                cell2 = cells.Add(5, 10, "至"+(year-1)+"年累计完成投资", cellXF);
                MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
                sheet.AddMergeArea(meaA11);
                cell2 = cells.Add(5, 11, "至"+year+"年"+season+"季完成投资", cellXF);

                MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
                sheet.AddMergeArea(meaA12);
                cell2 = cells.Add(5, 12, year+"年1-"+season+"季完成投资", cellXF);
                MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
                sheet.AddMergeArea(meaA13);
                cell2 = cells.Add(5, 13, "目前形象进度", cellXF);
                MergeArea meaA14 = new MergeArea(4, 6, 14, 14);
                sheet.AddMergeArea(meaA14);
                cell2 = cells.Add(4, 14, "项目业主", cellXF);
                //=============================表头完成======================填入正文开始===================
                XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXFcont.Font.FontName = "宋体";//设定字体
                //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXFcont.TextWrapRight = true;//自动换行
                cellXFcont.BottomLineStyle = 1;
                cellXFcont.BottomLineColor = Colors.Black;
                cellXFcont.RightLineColor = Colors.Black;
                cellXFcont.RightLineStyle = 1;
                //==============导入龙泉驿区项目
                DataBase db = new DataBase();
                System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','"+area+"',1)");
                //MergeArea meaAtcdc = new MergeArea(7, 7, 1, 7);
                //sheet.AddMergeArea(meaAtcdc);
                cell2 = cells.Add(7, 1, "一、", cellXF);
                cell2 = cells.Add(7, 2, "已成", cellXF);
                int x = 8;
                //int number = 0;
                //double alltotal = 0;
                //double alltotalX = 0;
                //===============================已成=============
                
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt2.Rows.Count  + x;
                //===================小计

                cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 7, dic["ycc1"] + "", cellXF);
                cell2 = cells.Add(x, 8, dic["ycc2"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["ycc3"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["ycc4"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["ycc5"] + "", cellXF);
                //=============
                x = 1 + x;
                //====================在建=============
                System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','" + area + "',1)");
                //MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
                //sheet.AddMergeArea(meaAjkjs);
                cell2 = cells.Add(x, 1, "二、", cellXF);
                cell2 = cells.Add(x, 2, "在建", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt4.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt4.Rows.Count + x;
                //===================小计
                cell2 = cells.Add(x, 1, dt4.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 7, dic["zjc1"] + "", cellXF);
                cell2 = cells.Add(x, 8, dic["zjc2"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["zjc3"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["zjc4"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["zjc5"] + "", cellXF);
                //=============
                x =  1 + x;
                //===============================规划=============
                System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','" + area + "',1)");
                //MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
                //sheet.AddMergeArea(meaAcjkg);
                cell2 = cells.Add(x, 1, "三、", cellXF);
                cell2 = cells.Add(x, 2, "规划", cellXF);
                x = x + 1;
                
                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt6.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt6.Rows.Count + x;
                //===================小计
                cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 7, dic["ghc1"] + "", cellXF);
                cell2 = cells.Add(x, 8, dic["ghc2"] + "", cellXF);
                cell2 = cells.Add(x, 10, dic["ghc3"] + "", cellXF);
                cell2 = cells.Add(x, 11, dic["ghc4"] + "", cellXF);
                cell2 = cells.Add(x, 12, dic["ghc5"] + "", cellXF);

                x = x + 1;
                cell2 = cells.Add(x, 1, (dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count), cellXF);
                cell2 = cells.Add(x, 2, "合计", cellXF);
                cell2 = cells.Add(x, 7, (decimal.Parse(dic["ghc1"]) + decimal.Parse(dic["ycc1"]) + decimal.Parse(dic["zjc1"])) + "", cellXF);
                cell2 = cells.Add(x, 8, (decimal.Parse(dic["ghc2"]) + decimal.Parse(dic["ycc2"]) + decimal.Parse(dic["zjc2"])) + "", cellXF);
                cell2 = cells.Add(x, 10, (decimal.Parse(dic["ghc3"]) + decimal.Parse(dic["ycc3"]) + decimal.Parse(dic["zjc3"])) + "", cellXF);
                cell2 = cells.Add(x, 11, (decimal.Parse(dic["ghc4"]) + decimal.Parse(dic["ycc4"]) + decimal.Parse(dic["zjc4"])) + "", cellXF);
                cell2 = cells.Add(x, 12, (decimal.Parse(dic["ghc5"]) + decimal.Parse(dic["ycc5"]) + decimal.Parse(dic["zjc5"])) + "", cellXF);
                //=============
                
                //汇总所有的资金很项目个数

                MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
                sheet.AddMergeArea(meaAttaddre);
                cell2 = cells.Add(3, 2, "填报单位（盖章）");

                MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
                sheet.AddMergeArea(meaAttname);
                cell2 = cells.Add(3, 4, " 填报人：   ");

                MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
                sheet.AddMergeArea(meaAttname1);
                cell2 = cells.Add(3, 6, " 审核人：   ");

                MergeArea meaAtt = new MergeArea(3, 3, 8, 11);
                sheet.AddMergeArea(meaAtt);
                cell2 = cells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
                MergeArea meunit = new MergeArea(3, 3, 12, 13);
                sheet.AddMergeArea(meunit);
                cell2 = cells.Add(3, 12, "单位：万元、亩");

                //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
                //sheet.AddMergeArea(meaAtt);
                //cell2 = cells.Add(3, 1, "[区县："+titleStr + "  填报人：    此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
                xls.Save(path);
                string fileName = filename + ".xls";//客户端保存的文件名
                string filePath = (path + "/" + filename + ".xls");//路径
                FileInfo fileInfo = new FileInfo(filePath);
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                response.AddHeader("Content-Length", fileInfo.Length.ToString());
                response.AddHeader("Content-Transfer-Encoding", "binary");
                response.ContentType = "application/octet-stream";
                response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                response.WriteFile(fileInfo.FullName);
                response.Flush();
                try
                {
                  //  File.Delete(filePath);
                }
                catch (Exception exx)
                {
                    throw new Exception(exx.Message);
                }
                finally
                {
                    response.End();
                }
            
          
        
        }

        #endregion

        #region 百湖工程
        /// <summary>
        /// admin现在百湖工程的Excel
        /// </summary>
        /// <param name="response"></param>
        /// <param name="path"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        public void downbhExcel(HttpResponse response, string path, int year, int season )
        {
            //=======================
            int month = season * 3;
            Dictionary<String, String> admin_dic = getbhMoneyAndCount(year, season, 2);
            Dictionary<String, String> lq_dic = getbhMoneyAndCountByAddress(year, season, 2, "lqy");
            Dictionary<String, String> sl_dic = getbhMoneyAndCountByAddress(year, season, 2, "sl");
            Dictionary<String, String> jt_dic = getbhMoneyAndCountByAddress(year, season, 2, "jt");
            Dictionary<String, String> qbj_dic = getbhMoneyAndCountByAddress(year, season, 2, "qbj");
            Dictionary<String, String> xj_dic = getbhMoneyAndCountByAddress(year, season, 2, "xj");


            string filename ="bh_"+ System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            XlsDocument xls = new XlsDocument();//新建一个xls文档
            xls.FileName = filename + ".xls";//设定文件名
            string sheetName = "总表";
            Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
            Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXF.Font.FontName = "宋体";//设定字体
            cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXF.UseBorder = true;//使用边框
            cellXF.TextWrapRight = true;//自动换行
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.RightLineColor = Colors.Black;
            cellXF.RightLineStyle = 1;
            ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
            col1.ColumnIndexStart = 1;//起始列为第1列
            col1.ColumnIndexEnd = 31;//终止列为第1列
            col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
            sheet.AddColumnInfo(col1);//把格式附加到sheet页上
            //===================================设置标题=====================================================//
            MergeArea meaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 20 * 20;
            cellXF.Font.Bold = true;
            cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表", cellXF);
            //==============================================设置表头===============================================//
            MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheet.AddMergeArea(meaA1);//填加合并单元格
            cellXF.VerticalAlignment = VerticalAlignments.Centered;
            cellXF.Font.Height = 15 * 15;
            cellXF.BottomLineStyle = 1;
            cellXF.BottomLineColor = Colors.Black;
            cellXF.Font.Bold = true;
            cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            //画边框
            Cell cell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    cell2 = cells.Add(j, i, "", cellXF);
                }
            }
             cell2 = cells.Add(4, 1, "序号", cellXF);
            //=============
            cell2.Font.FontName = "Times New Roman";
            MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
            sheet.AddMergeArea(meaA2);
            cell2 = cells.Add(4, 2, "所属区县", cellXF);
            MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
            sheet.AddMergeArea(meaA3);
            cell2 = cells.Add(4, 3, "项目名称", cellXF);
            MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
            sheet.AddMergeArea(meaA4);
            cell2 = cells.Add(4, 4, "建设地址", cellXF);
            MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
            sheet.AddMergeArea(meaA5);
            cell2 = cells.Add(4, 5, "完工时间", cellXF);
            MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
            sheet.AddMergeArea(meaA6);
            cell2 = cells.Add(4, 6, "水域面积（亩）", cellXF);
            MergeArea meaAt7 = new MergeArea(4, 4, 7, 14);
            sheet.AddMergeArea(meaAt7);
            cell2 = cells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", cellXF);
            MergeArea meaAx7 = new MergeArea(5, 6, 7, 7);
            sheet.AddMergeArea(meaAx7);
            cell2 = cells.Add(5, 7, "小计(万元)", cellXF);
            MergeArea meaA8 = new MergeArea(5, 6, 8, 8);
            sheet.AddMergeArea(meaA8);
            cell2 = cells.Add(5, 8, "省级以上财政", cellXF);
            MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
            sheet.AddMergeArea(meaA9);
            cell2 = cells.Add(5, 9, "市级财政", cellXF);
            MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
            sheet.AddMergeArea(meaA10);
            cell2 = cells.Add(5, 10, "县级财政", cellXF);
            MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
            sheet.AddMergeArea(meaA11);
            cell2 = cells.Add(5, 11, "财政融资", cellXF);
            MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
            sheet.AddMergeArea(meaA12);
            cell2 = cells.Add(5, 12, "社会投入", cellXF);
            MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
            sheet.AddMergeArea(meaA13);
            cell2 = cells.Add(5, 13, "群众投入", cellXF);
            MergeArea meaA14 = new MergeArea(5, 6, 14, 14);
            sheet.AddMergeArea(meaA14);
            cell2 = cells.Add(5, 14, "其他", cellXF);
            MergeArea meaAt15 = new MergeArea(4, 4, 15, 17);
            sheet.AddMergeArea(meaAt15);
            cell2 = cells.Add(4, 15, "建设用地", cellXF);
            MergeArea meaA15 = new MergeArea(5, 6, 15, 15);
            sheet.AddMergeArea(meaA15);
            cell2 = cells.Add(5, 15, "占用土地面积（亩）", cellXF);
            MergeArea meaA16 = new MergeArea(5, 6, 16, 16);
            sheet.AddMergeArea(meaA16);
            cell2 = cells.Add(5, 16, "占用方式（流转、征用等）", cellXF);
            MergeArea meaA17 = new MergeArea(5, 6, 17, 17);
            sheet.AddMergeArea(meaA17);
            cell2 = cells.Add(5, 17, "单价（元/亩*年）", cellXF);
            MergeArea meaA18 = new MergeArea(4, 6, 18, 18);
            sheet.AddMergeArea(meaA18);
            cell2 = cells.Add(4, 18, "目前工程形象进度（涉旅项目）", cellXF);
            MergeArea meaA19 = new MergeArea(4, 6, 19, 19);
            sheet.AddMergeArea(meaA19);
            cell2 = cells.Add(4, 19, "管护主体", cellXF);
            //=============================表头完成======================填入正文开始===================
            XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            cellXFcont.Font.FontName = "宋体";//设定字体
            //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
            cellXFcont.TextWrapRight = true;//自动换行
            cellXFcont.BottomLineStyle = 1;
            cellXFcont.BottomLineColor = Colors.Black;
            cellXFcont.RightLineColor = Colors.Black;
            cellXFcont.RightLineStyle = 1;

            DataBase db = new DataBase();
            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'yc')");
            //MergeArea meaAtcdc = new MergeArea(7, 7, 1, 7);
            //sheet.AddMergeArea(meaAtcdc);
            cell2 = cells.Add(7, 1, "一、", cellXF);
            cell2 = cells.Add(7, 2, "已成", cellXF);
            int x = 8;
            //int number = 0;
            //double alltotal = 0;
            //double alltotalX = 0;
            //===============================已成=============
         
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计======================
            x = dt2.Rows.Count + x;
          //  x=x+1;
            cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "小计", cellXF);
            cell2 = cells.Add(x, 6, "" + admin_dic["ycc1"], cellXF);
            cell2 = cells.Add(x, 7, "" + admin_dic["ycc10"], cellXF);
            cell2 = cells.Add(x, 8, "" + admin_dic["ycc2"], cellXF);
            cell2 = cells.Add(x, 9, "" + admin_dic["ycc3"], cellXF);
            cell2 = cells.Add(x, 10, "" + admin_dic["ycc4"], cellXF);
            cell2 = cells.Add(x, 11, "" + admin_dic["ycc5"], cellXF);
            cell2 = cells.Add(x, 12, "" + admin_dic["ycc6"], cellXF);
            cell2 = cells.Add(x, 13, "" + admin_dic["ycc7"], cellXF);
            cell2 = cells.Add(x, 14, "" + admin_dic["ycc8"], cellXF);
            cell2 = cells.Add(x, 15, "" + admin_dic["ycc9"], cellXF);
            //============================
            x =1 + x;
            //====================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'zj')");
            //MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
            //sheet.AddMergeArea(meaAjkjs);
            cell2 = cells.Add(x, 1, "二、", cellXF);
            cell2 = cells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = x + dt4.Rows.Count;
            //小计======================
            //x = x + 1;
            cell2 = cells.Add(x, 1, dt4.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "小计", cellXF);
            cell2 = cells.Add(x, 6, "" + admin_dic["zjc1"], cellXF);
            cell2 = cells.Add(x, 7, "" + admin_dic["zjc10"], cellXF);
            cell2 = cells.Add(x, 8, "" + admin_dic["zjc2"], cellXF);
            cell2 = cells.Add(x, 9, "" + admin_dic["zjc3"], cellXF);
            cell2 = cells.Add(x, 10, "" + admin_dic["zjc4"], cellXF);
            cell2 = cells.Add(x, 11, "" + admin_dic["zjc5"], cellXF);
            cell2 = cells.Add(x, 12, "" + admin_dic["zjc6"], cellXF);
            cell2 = cells.Add(x, 13, "" + admin_dic["zjc7"], cellXF);
            cell2 = cells.Add(x, 14, "" + admin_dic["zjc8"], cellXF);
            cell2 = cells.Add(x, 15, "" + admin_dic["zjc9"], cellXF);
            //============================
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'gh')");
            //MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
            //sheet.AddMergeArea(meaAcjkg);
            cell2 = cells.Add(x, 1, "三、", cellXF);
            cell2 = cells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    cell2.Font.FontName = "宋体";
                    cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = x + dt6.Rows.Count;
            //小计======================
          //  x = x + 1;
            cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
           
            cell2 = cells.Add(x, 2, "小计", cellXF);
            cell2 = cells.Add(x, 6, "" + admin_dic["ghc1"], cellXF);
            cell2 = cells.Add(x, 7, "" + admin_dic["ghc10"], cellXF);
            cell2 = cells.Add(x, 8, "" + admin_dic["ghc2"], cellXF);
            cell2 = cells.Add(x, 9, "" + admin_dic["ghc3"], cellXF);
            cell2 = cells.Add(x, 10, "" + admin_dic["ghc4"], cellXF);
            cell2 = cells.Add(x, 11, "" + admin_dic["ghc5"], cellXF);
            cell2 = cells.Add(x, 12, "" + admin_dic["ghc6"], cellXF);
            cell2 = cells.Add(x, 13, "" + admin_dic["ghc7"], cellXF);
            cell2 = cells.Add(x, 14, "" + admin_dic["ghc8"], cellXF);
            cell2 = cells.Add(x, 15, "" + admin_dic["ghc9"], cellXF);
            //============================
            x = x + 1;
            cell2 = cells.Add(x, 1, dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count, cellXF);
            cell2 = cells.Add(x, 2, "合计", cellXF);
            cell2 = cells.Add(x, 6, "" + (decimal.Parse(admin_dic["ghc1"]) + decimal.Parse(admin_dic["ycc1"]) + decimal.Parse(admin_dic["zjc1"])), cellXF);
            cell2 = cells.Add(x, 7, "" + (decimal.Parse(admin_dic["ghc10"]) + decimal.Parse(admin_dic["ycc10"]) + decimal.Parse(admin_dic["zjc10"])), cellXF);
            cell2 = cells.Add(x, 8, "" + (decimal.Parse(admin_dic["ghc2"]) + decimal.Parse(admin_dic["ycc2"]) + decimal.Parse(admin_dic["zjc2"])), cellXF);
            cell2 = cells.Add(x, 9, "" + (decimal.Parse(admin_dic["ghc3"]) + decimal.Parse(admin_dic["ycc3"]) + decimal.Parse(admin_dic["zjc3"])), cellXF);
            cell2 = cells.Add(x, 10, "" + (decimal.Parse(admin_dic["ghc4"]) + decimal.Parse(admin_dic["ycc4"]) + decimal.Parse(admin_dic["zjc4"])), cellXF);
            cell2 = cells.Add(x, 11, "" + (decimal.Parse(admin_dic["ghc5"]) + decimal.Parse(admin_dic["ycc5"]) + decimal.Parse(admin_dic["zjc5"])), cellXF);
            cell2 = cells.Add(x, 12, "" + (decimal.Parse(admin_dic["ghc6"]) + decimal.Parse(admin_dic["ycc6"]) + decimal.Parse(admin_dic["zjc6"])), cellXF);
            cell2 = cells.Add(x, 13, "" + (decimal.Parse(admin_dic["ghc7"]) + decimal.Parse(admin_dic["ycc7"]) + decimal.Parse(admin_dic["zjc7"])), cellXF);
            cell2 = cells.Add(x, 14, "" + (decimal.Parse(admin_dic["ghc8"]) + decimal.Parse(admin_dic["ycc8"]) + decimal.Parse(admin_dic["zjc8"])), cellXF);
            cell2 = cells.Add(x, 15, "" + (decimal.Parse(admin_dic["ghc9"]) + decimal.Parse(admin_dic["ycc9"]) + decimal.Parse(admin_dic["zjc9"])), cellXF);
            //============================

            MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
            sheet.AddMergeArea(meaAttaddre);
            cell2 = cells.Add(3, 2, "填报单位（盖章）：");

            MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
            sheet.AddMergeArea(meaAttname);
            cell2 = cells.Add(3, 4, " 填报人：   ");

            MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
            sheet.AddMergeArea(meaAttname1);
            cell2 = cells.Add(3, 6, " 审核人：   ");

            MergeArea meaAtt = new MergeArea(3, 3, 8, 11);
            sheet.AddMergeArea(meaAtt);
            cell2 = cells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea meunit = new MergeArea(3, 3, 18, 19);
            sheet.AddMergeArea(meunit);
            cell2 = cells.Add(3, 18, "单位：万元、亩");


            //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
            //sheet.AddMergeArea(meaAtt);
            //cell2 = cells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            // x = dt6.Rows.Count + 1 + x;
            //汇总所有的资金很项目个数
            //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
            //sheet.AddMergeArea(meaAtt);
            //cell2 = cells.Add(3, 1, "（项目共计：" + number + "个)。", cellXFcont);
            //======================================================================================
            string sheetlqName = "龙泉";
            Worksheet sheetlq = xls.Workbook.Worksheets.Add(sheetlqName);//填加名为"总表"的sheetlq页
            Cells lqcells = sheetlq.Cells;//Cells实例是sheetlq页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF lqcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            lqcellXF.Font.FontName = "宋体";//设定字体
            lqcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            lqcellXF.UseBorder = true;//使用边框
            lqcellXF.TextWrapRight = true;//自动换行
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.RightLineColor = Colors.Black;
            lqcellXF.RightLineStyle = 1;
            //cell = lqcells.AddValueCellXF(2, 2, "震", lqcellXF);//以设定好的格式填加cell
            //lqcellXF.Font.FontName = "宋体";
            //cell = lqcells.AddValueCellXF(3, 2, "救", lqcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea lqmeaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 20 * 20;
            lqcellXF.Font.Bold = true;
            lqcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell lqcell = lqcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(龙泉驿区)", lqcellXF);
            sheetlq.AddColumnInfo(col1);//把格式附加到sheet页上
            //==============================================设置表头===============================================//
            MergeArea lqmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetlq.AddMergeArea(lqmeaA1);//填加合并单元格
            lqcellXF.VerticalAlignment = VerticalAlignments.Centered;
            lqcellXF.Font.Height = 15 * 15;
            lqcellXF.BottomLineStyle = 1;
            lqcellXF.BottomLineColor = Colors.Black;
            lqcellXF.Font.Bold = true;
            lqcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            //画边框
            Cell lqcell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    lqcell2 = lqcells.Add(j, i, "", cellXF);
                }
            }
             lqcell2 = lqcells.Add(4, 1, "序号", lqcellXF);
            //=============
            lqcell2.Font.FontName = "Times New Roman";
            MergeArea lqmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetlq.AddMergeArea(lqmeaA2);
            lqcell2 = lqcells.Add(4, 2, "所属区县", lqcellXF);
            MergeArea lqmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetlq.AddMergeArea(lqmeaA3);
            lqcell2 = lqcells.Add(4, 3, "项目名称", lqcellXF);
            MergeArea lqmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetlq.AddMergeArea(lqmeaA4);
            lqcell2 = lqcells.Add(4, 4, "建设地址", lqcellXF);
            MergeArea lqmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetlq.AddMergeArea(lqmeaA5);
            lqcell2 = lqcells.Add(4, 5, "完工时间", lqcellXF);
            MergeArea lqmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetlq.AddMergeArea(lqmeaA6);
            lqcell2 = lqcells.Add(4, 6, "水域面积（亩）", lqcellXF);
            MergeArea lqmeaAt7 = new MergeArea(4, 4, 7, 14);
            sheetlq.AddMergeArea(lqmeaAt7);
            lqcell2 = lqcells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", lqcellXF);
            MergeArea lqmeaAx7 = new MergeArea(5, 6, 7, 7);
            sheetlq.AddMergeArea(lqmeaAx7);
            lqcell2 = lqcells.Add(5, 7, "小计(万元)", lqcellXF);
            MergeArea lqmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetlq.AddMergeArea(lqmeaA8);
            lqcell2 = lqcells.Add(5, 8, "省级以上财政", lqcellXF);
            MergeArea lqmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetlq.AddMergeArea(lqmeaA9);
            lqcell2 = lqcells.Add(5, 9, "市级财政", lqcellXF);
            MergeArea lqmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetlq.AddMergeArea(lqmeaA10);
            lqcell2 = lqcells.Add(5, 10, "县级财政", lqcellXF);
            MergeArea lqmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetlq.AddMergeArea(lqmeaA11);
            lqcell2 = lqcells.Add(5, 11, "财政融资", lqcellXF);
            MergeArea lqmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetlq.AddMergeArea(lqmeaA12);
            lqcell2 = lqcells.Add(5, 12, "社会投入", lqcellXF);
            MergeArea lqmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetlq.AddMergeArea(lqmeaA13);
            lqcell2 = lqcells.Add(5, 13, "群众投入", lqcellXF);
            MergeArea lqmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetlq.AddMergeArea(lqmeaA14);
            lqcell2 = lqcells.Add(5, 14, "其他", lqcellXF);
            MergeArea lqmeaAt15 = new MergeArea(4, 4, 15, 17);
            sheetlq.AddMergeArea(lqmeaAt15);
            lqcell2 = lqcells.Add(4, 15, "建设用地", lqcellXF);
            MergeArea lqmeaA15 = new MergeArea(5, 6, 15, 15);
            sheetlq.AddMergeArea(lqmeaA15);
            lqcell2 = lqcells.Add(5, 15, "占用土地面积（亩）", lqcellXF);
            MergeArea lqmeaA16 = new MergeArea(5, 6, 16, 16);
            sheetlq.AddMergeArea(lqmeaA16);
            lqcell2 = lqcells.Add(5, 16, "占用方式（流转、征用等）", lqcellXF);
            MergeArea lqmeaA17 = new MergeArea(5, 6, 17, 17);
            sheetlq.AddMergeArea(lqmeaA17);
            lqcell2 = lqcells.Add(5, 17, "单价（元/亩*年）", lqcellXF);
            MergeArea lqmeaA18 = new MergeArea(4, 6, 18, 18);
            sheetlq.AddMergeArea(lqmeaA18);
            lqcell2 = lqcells.Add(4, 18, "目前工程形象进度（涉旅项目）", lqcellXF);
            MergeArea lqmeaA19 = new MergeArea(4, 6, 19, 19);
            sheetlq.AddMergeArea(lqmeaA19);
            lqcell2 = lqcells.Add(4, 19, "管护主体", lqcellXF);
            System.Data.DataTable dt2lqy = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','lqy',2)");
            //MergeArea meaAtcdclqy = new MergeArea(7, 7, 1, 7);
            //sheetlq.AddMergeArea(meaAtcdclqy);
            lqcell2 = lqcells.Add(7, 1, "一、", cellXF);
            lqcell2 = lqcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
            
            for (int i = 0; i < dt2lqy.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2lqy.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt2lqy.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2lqy.Rows.Count  + x;
            //小计======================
          //  x = x + 1;
            lqcell2 = lqcells.Add(x, 1, dt2lqy.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 6, "" + lq_dic["ycc1"], cellXF);
            lqcell2 = lqcells.Add(x, 7, "" + lq_dic["ycc10"], cellXF);
            lqcell2 = lqcells.Add(x, 8, "" + lq_dic["ycc2"], cellXF);
            lqcell2 = lqcells.Add(x, 9, "" + lq_dic["ycc3"], cellXF);
            lqcell2 = lqcells.Add(x, 10, "" + lq_dic["ycc4"], cellXF);
            lqcell2 = lqcells.Add(x, 11, "" + lq_dic["ycc5"], cellXF);
            lqcell2 = lqcells.Add(x, 12, "" + lq_dic["ycc6"], cellXF);
            lqcell2 = lqcells.Add(x, 13, "" + lq_dic["ycc7"], cellXF);
            lqcell2 = lqcells.Add(x, 14, "" + lq_dic["ycc8"], cellXF);
            lqcell2 = lqcells.Add(x, 15, "" + lq_dic["ycc9"], cellXF);
            //============================
            x = x + 1;
            //====================在建=============
            System.Data.DataTable dt4lqy = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','lqy',2)");
            //MergeArea meaAjkjslqy = new MergeArea(x, x, 1, 7);
            //sheetlq.AddMergeArea(meaAjkjslqy);
            lqcell2 = lqcells.Add(x, 1, "二、", cellXF);
            lqcell2 = lqcells.Add(x, 2, "在建", cellXF);
            x = x + 1;

            for (int i = 0; i < dt4lqy.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4lqy.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt4lqy.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4lqy.Rows.Count + x;
            //小计======================
        //    x = x + 1;
            lqcell2 = lqcells.Add(x, 1, dt4lqy.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 6, "" + lq_dic["zjc1"], cellXF);
            lqcell2 = lqcells.Add(x, 7, "" + lq_dic["zjc10"], cellXF);
            lqcell2 = lqcells.Add(x, 8, "" + lq_dic["zjc2"], cellXF);
            lqcell2 = lqcells.Add(x, 9, "" + lq_dic["zjc3"], cellXF);
            lqcell2 = lqcells.Add(x, 10, "" + lq_dic["zjc4"], cellXF);
            lqcell2 = lqcells.Add(x, 11, "" + lq_dic["zjc5"], cellXF);
            lqcell2 = lqcells.Add(x, 12, "" + lq_dic["zjc6"], cellXF);
            lqcell2 = lqcells.Add(x, 13, "" + lq_dic["zjc7"], cellXF);
            lqcell2 = lqcells.Add(x, 14, "" + lq_dic["zjc8"], cellXF);
            lqcell2 = lqcells.Add(x, 15, "" + lq_dic["zjc9"], cellXF);
            //============================
            x = x + 1;
            //===============================规划=============
            System.Data.DataTable dt6lqy = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','lqy',2)");
            //MergeArea meaAcjkglqy = new MergeArea(x, x, 1, 7);
            //sheetlq.AddMergeArea(meaAcjkglqy);
            lqcell2 = lqcells.Add(x, 1, "三、", cellXF);
            lqcell2 = lqcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt6lqy.Rows.Count; i++)
            {
                lqcell2 = lqcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6lqy.Columns.Count; j++)
                {
                    lqcell2.Font.FontName = "宋体";
                    lqcell2 = lqcells.Add(i + x, j + 2, dt6lqy.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = x + dt6lqy.Rows.Count;
            //小计======================
        //    x = x + 1;
            lqcell2 = lqcells.Add(x, 1, dt6lqy.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "小计", cellXF);
            lqcell2 = lqcells.Add(x, 6, "" + lq_dic["ghc1"], cellXF);
            lqcell2 = lqcells.Add(x, 7, "" + lq_dic["ghc10"], cellXF);
            lqcell2 = lqcells.Add(x, 8, "" + lq_dic["ghc2"], cellXF);
            lqcell2 = lqcells.Add(x, 9, "" + lq_dic["ghc3"], cellXF);
            lqcell2 = lqcells.Add(x, 10, "" + lq_dic["ghc4"], cellXF);
            lqcell2 = lqcells.Add(x, 11, "" + lq_dic["ghc5"], cellXF);
            lqcell2 = lqcells.Add(x, 12, "" + lq_dic["ghc6"], cellXF);
            lqcell2 = lqcells.Add(x, 13, "" + lq_dic["ghc7"], cellXF);
            lqcell2 = lqcells.Add(x, 14, "" + lq_dic["ghc8"], cellXF);
            lqcell2 = lqcells.Add(x, 15, "" + lq_dic["ghc9"], cellXF);
            x = x + 1;
            lqcell2 = lqcells.Add(x, 1, dt2lqy.Rows.Count + dt4lqy.Rows.Count + dt6lqy.Rows.Count, cellXF);
            lqcell2 = lqcells.Add(x, 2, "合计", cellXF);
            lqcell2 = lqcells.Add(x, 6, "" + (decimal.Parse(lq_dic["ghc1"]) + decimal.Parse(lq_dic["ycc1"]) + decimal.Parse(lq_dic["zjc1"])), cellXF);
            lqcell2 = lqcells.Add(x, 7, "" + (decimal.Parse(lq_dic["ghc10"]) + decimal.Parse(lq_dic["ycc10"]) + decimal.Parse(lq_dic["zjc10"])), cellXF);
            lqcell2 = lqcells.Add(x, 8, "" + (decimal.Parse(lq_dic["ghc2"]) + decimal.Parse(lq_dic["ycc2"]) + decimal.Parse(lq_dic["zjc2"])), cellXF);
            lqcell2 = lqcells.Add(x, 9, "" + (decimal.Parse(lq_dic["ghc3"]) + decimal.Parse(lq_dic["ycc3"]) + decimal.Parse(lq_dic["zjc3"])), cellXF);
            lqcell2 = lqcells.Add(x, 10, "" + (decimal.Parse(lq_dic["ghc4"]) + decimal.Parse(lq_dic["ycc4"]) + decimal.Parse(lq_dic["zjc4"])), cellXF);
            lqcell2 = lqcells.Add(x, 11, "" + (decimal.Parse(lq_dic["ghc5"]) + decimal.Parse(lq_dic["ycc5"]) + decimal.Parse(lq_dic["zjc5"])), cellXF);
            lqcell2 = lqcells.Add(x, 12, "" + (decimal.Parse(lq_dic["ghc6"]) + decimal.Parse(lq_dic["ycc6"]) + decimal.Parse(lq_dic["zjc6"])), cellXF);
            lqcell2 = lqcells.Add(x, 13, "" + (decimal.Parse(lq_dic["ghc7"]) + decimal.Parse(lq_dic["ycc7"]) + decimal.Parse(lq_dic["zjc7"])), cellXF);
            lqcell2 = lqcells.Add(x, 14, "" + (decimal.Parse(lq_dic["ghc8"]) + decimal.Parse(lq_dic["ycc8"]) + decimal.Parse(lq_dic["zjc8"])), cellXF);
            lqcell2 = lqcells.Add(x, 15, "" + (decimal.Parse(lq_dic["ghc9"]) + decimal.Parse(lq_dic["ycc9"]) + decimal.Parse(lq_dic["zjc9"])), cellXF);
            //============================


            MergeArea lqmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetlq.AddMergeArea(lqmeaAttaddre);
            lqcell2 = lqcells.Add(3, 2, "填报单位（盖章）");

            MergeArea lqmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetlq.AddMergeArea(lqmeaAttname);
            lqcell2 = lqcells.Add(3, 4, " 填报人：   ");

            MergeArea lqmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetlq.AddMergeArea(lqmeaAttname1);
            lqcell2 = lqcells.Add(3, 6, " 审核人：   ");

            MergeArea lqmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetlq.AddMergeArea(lqmeaAtt);
            lqcell2 = lqcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea lqmeunit = new MergeArea(3, 3, 18, 19);
            sheetlq.AddMergeArea(lqmeunit);
            lqcell2 = lqcells.Add(3, 18, "单位：万元、亩");


            //MergeArea meaAttlq = new MergeArea(3, 3, 1, 7);
            //sheetlq.AddMergeArea(meaAttlq);
            //lqcell2 = lqcells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            
            ////汇总所有的资金很项目个数
            //MergeArea meaAttlqy = new MergeArea(3, 3, 1, 7);
            //sheetlq.AddMergeArea(meaAttlqy);
            //lqcell2 = lqcells.Add(3, 1, "（项目共计：" + number + "个）。" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);

            ////==========================双流========================================
            string sheetslName = "双流";
            Worksheet sheetsl = xls.Workbook.Worksheets.Add(sheetslName);//填加名为"总表"的sheetsl页

            Cells slcells = sheetsl.Cells;//Cells实例是sheetsl页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF slcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            slcellXF.Font.FontName = "宋体";//设定字体
            slcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            slcellXF.UseBorder = true;//使用边框
            slcellXF.TextWrapRight = true;//自动换行
            slcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            slcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = slcells.AddValueCellXF(2, 2, "震", slcellXF);//以设定好的格式填加cell
            //slcellXF.Font.FontName = "宋体";
            //cell = slcells.AddValueCellXF(3, 2, "救", slcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea slmeaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 20 * 20;
            slcellXF.Font.Bold = true;
            slcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell = slcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(双流县)", slcellXF);
            sheetsl.AddColumnInfo(col1);//把格式附加到sheet页上
            //==============================================设置表头===============================================//
            MergeArea slmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetsl.AddMergeArea(slmeaA1);//填加合并单元格
            slcellXF.VerticalAlignment = VerticalAlignments.Centered;
            slcellXF.Font.Height = 15 * 15;
            slcellXF.BottomLineStyle = 1;
            slcellXF.BottomLineColor = Colors.Black;
            slcellXF.Font.Bold = true;
            slcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell slcell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    slcell2 = slcells.Add(j, i, "", cellXF);
                }
            }
             slcell2 = slcells.Add(4, 1, "序号", slcellXF);
            //=============
            slcell2.Font.FontName = "Times New Roman";
            MergeArea slmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetsl.AddMergeArea(slmeaA2);
            slcell2 = slcells.Add(4, 2, "所属区县", slcellXF);
            MergeArea slmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetsl.AddMergeArea(slmeaA3);
            slcell2 = slcells.Add(4, 3, "项目名称", slcellXF);
            MergeArea slmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetsl.AddMergeArea(slmeaA4);
            slcell2 = slcells.Add(4, 4, "建设地址", slcellXF);
            MergeArea slmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetsl.AddMergeArea(slmeaA5);
            slcell2 = slcells.Add(4, 5, "完工时间", slcellXF);
            MergeArea slmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetsl.AddMergeArea(slmeaA6);
            slcell2 = slcells.Add(4, 6, "水域面积（亩）", slcellXF);
            MergeArea slmeaAt7 = new MergeArea(4, 4, 7, 14);
            sheetsl.AddMergeArea(slmeaAt7);
            slcell2 = slcells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", slcellXF);
            MergeArea slmeaAx7 = new MergeArea(5, 6, 7, 7);
            sheetsl.AddMergeArea(slmeaAx7);
            slcell2 = slcells.Add(5, 7, "小计(万元)", slcellXF);
            MergeArea slmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetsl.AddMergeArea(slmeaA8);
            slcell2 = slcells.Add(5, 8, "省级以上财政", slcellXF);

            MergeArea slmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetsl.AddMergeArea(slmeaA9);
            slcell2 = slcells.Add(5, 9, "市级财政", slcellXF);

            MergeArea slmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetsl.AddMergeArea(slmeaA10);
            slcell2 = slcells.Add(5, 10, "县级财政", slcellXF);

            MergeArea slmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetsl.AddMergeArea(slmeaA11);
            slcell2 = slcells.Add(5, 11, "财政融资", slcellXF);

            MergeArea slmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetsl.AddMergeArea(slmeaA12);
            slcell2 = slcells.Add(5, 12, "社会投入", slcellXF);

            MergeArea slmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetsl.AddMergeArea(slmeaA13);
            slcell2 = slcells.Add(5, 13, "群众投入", slcellXF);

            MergeArea slmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetsl.AddMergeArea(slmeaA14);
            slcell2 = slcells.Add(5, 14, "其他", slcellXF);

            MergeArea slmeaAt15 = new MergeArea(4, 4, 15, 17);
            sheetsl.AddMergeArea(slmeaAt15);
            slcell2 = slcells.Add(4, 15, "建设用地", slcellXF);
            MergeArea slmeaA15 = new MergeArea(5, 6, 15, 15);
            sheetsl.AddMergeArea(slmeaA15);
            slcell2 = slcells.Add(5, 15, "占用土地面积（亩）", slcellXF);
            MergeArea slmeaA16 = new MergeArea(5, 6, 16, 16);
            sheetsl.AddMergeArea(slmeaA16);
            slcell2 = slcells.Add(5, 16, "占用方式（流转、征用等）", slcellXF);

            MergeArea slmeaA17 = new MergeArea(5, 6, 17, 17);
            sheetsl.AddMergeArea(slmeaA17);
            slcell2 = slcells.Add(5, 17, "单价（元/亩*年）", slcellXF);

            MergeArea slmeaA18 = new MergeArea(4, 6, 18, 18);
            sheetsl.AddMergeArea(slmeaA18);
            slcell2 = slcells.Add(4, 18, "目前工程形象进度（涉旅项目）", slcellXF);
            MergeArea slmeaA19 = new MergeArea(4, 6, 19, 19);
            sheetsl.AddMergeArea(slmeaA19);
            slcell2 = slcells.Add(4, 19, "管护主体", slcellXF);


            System.Data.DataTable dt2sl = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','sl',2)");
            //MergeArea meaAtcdcsl = new MergeArea(7, 7, 1, 7);
            //sheetsl.AddMergeArea(meaAtcdcsl);
            slcell2 = slcells.Add(7, 1, "一、", cellXF);
            slcell2 = slcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
           
            for (int i = 0; i < dt2sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dt2sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2sl.Rows.Count + x;
            //小计======================
        //    x = x + 1;
            slcell2 = slcells.Add(x, 1, dt2sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 6, "" + sl_dic["ycc1"], cellXF);
            slcell2 = slcells.Add(x, 7, "" + sl_dic["ycc10"], cellXF);
            slcell2 = slcells.Add(x, 8, "" + sl_dic["ycc2"], cellXF);
            slcell2 = slcells.Add(x, 9, "" + sl_dic["ycc3"], cellXF);
            slcell2 = slcells.Add(x, 10, "" + sl_dic["ycc4"], cellXF);
            slcell2 = slcells.Add(x, 11, "" + sl_dic["ycc5"], cellXF);
            slcell2 = slcells.Add(x, 12, "" + sl_dic["ycc6"], cellXF);
            slcell2 = slcells.Add(x, 13, "" + sl_dic["ycc7"], cellXF);
            slcell2 = slcells.Add(x, 14, "" + sl_dic["ycc8"], cellXF);
            slcell2 = slcells.Add(x, 15, "" + sl_dic["ycc9"], cellXF);
            //============================
            x = 1 + x;
            //====================在建=============
            System.Data.DataTable dt4sl = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','sl',2)");
            //MergeArea meaAjkjssl = new MergeArea(x, x, 1, 7);
            //sheetsl.AddMergeArea(meaAjkjssl);
            slcell2 = slcells.Add(x, 1, "二、", cellXF);
            slcell2 = slcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dt4sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4sl.Rows.Count  + x;
            //小计======================
         //   x = x + 1;
            slcell2 = slcells.Add(x, 1, dt4sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 6, "" + sl_dic["zjc1"], cellXF);
            slcell2 = slcells.Add(x, 7, "" + sl_dic["zjc10"], cellXF);
            slcell2 = slcells.Add(x, 8, "" + sl_dic["zjc2"], cellXF);
            slcell2 = slcells.Add(x, 9, "" + sl_dic["zjc3"], cellXF);
            slcell2 = slcells.Add(x, 10, "" + sl_dic["zjc4"], cellXF);
            slcell2 = slcells.Add(x, 11, "" + sl_dic["zjc5"], cellXF);
            slcell2 = slcells.Add(x, 12, "" + sl_dic["zjc6"], cellXF);
            slcell2 = slcells.Add(x, 13, "" + sl_dic["zjc7"], cellXF);
            slcell2 = slcells.Add(x, 14, "" + sl_dic["zjc8"], cellXF);
            slcell2 = slcells.Add(x, 15, "" + sl_dic["zjc9"], cellXF);
            //============================
            x =  1 + x;
            //===============================规划=============
            System.Data.DataTable dt6sl = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','sl',2)");
            //MergeArea meaAcjkgsl = new MergeArea(x, x, 1, 7);
            //sheetsl.AddMergeArea(meaAcjkgsl);
            slcell2 = slcells.Add(x, 1, "三、", cellXF);
            slcell2 = slcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            for (int i = 0; i < dt6sl.Rows.Count; i++)
            {
                slcell2 = slcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6sl.Columns.Count; j++)
                {
                    slcell2.Font.FontName = "宋体";
                    slcell2 = slcells.Add(i + x, j + 2, dt6sl.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6sl.Rows.Count  + x;
            //小计======================
        //    x = x + 1;
            slcell2 = slcells.Add(x, 1, dt6sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "小计", cellXF);
            slcell2 = slcells.Add(x, 6, "" + sl_dic["ghc1"], cellXF);
            slcell2 = slcells.Add(x, 7, "" + sl_dic["ghc10"], cellXF);
            slcell2 = slcells.Add(x, 8, "" + sl_dic["ghc2"], cellXF);
            slcell2 = slcells.Add(x, 9, "" + sl_dic["ghc3"], cellXF);
            slcell2 = slcells.Add(x, 10, "" + sl_dic["ghc4"], cellXF);
            slcell2 = slcells.Add(x, 11, "" + sl_dic["ghc5"], cellXF);
            slcell2 = slcells.Add(x, 12, "" + sl_dic["ghc6"], cellXF);
            slcell2 = slcells.Add(x, 13, "" + sl_dic["ghc7"], cellXF);
            slcell2 = slcells.Add(x, 14, "" + sl_dic["ghc8"], cellXF);
            slcell2 = slcells.Add(x, 15, "" + sl_dic["ghc9"], cellXF);
            x = x + 1;

            slcell2 = slcells.Add(x, 1, dt2sl.Rows.Count + dt4sl.Rows.Count + dt6sl.Rows.Count, cellXF);
            slcell2 = slcells.Add(x, 2, "合计", cellXF);
            slcell2 = slcells.Add(x, 6, "" + (decimal.Parse(sl_dic["ghc1"]) + decimal.Parse(sl_dic["ycc1"]) + decimal.Parse(sl_dic["zjc1"])), cellXF);
            slcell2 = slcells.Add(x, 7, "" + (decimal.Parse(sl_dic["ghc10"]) + decimal.Parse(sl_dic["ycc10"]) + decimal.Parse(sl_dic["zjc10"])), cellXF);
            slcell2 = slcells.Add(x, 8, "" + (decimal.Parse(sl_dic["ghc2"]) + decimal.Parse(sl_dic["ycc2"]) + decimal.Parse(sl_dic["zjc2"])), cellXF);
            slcell2 = slcells.Add(x, 9, "" + (decimal.Parse(sl_dic["ghc3"]) + decimal.Parse(sl_dic["ycc3"]) + decimal.Parse(sl_dic["zjc3"])), cellXF);
            slcell2 = slcells.Add(x, 10, "" + (decimal.Parse(sl_dic["ghc4"]) + decimal.Parse(sl_dic["ycc4"]) + decimal.Parse(sl_dic["zjc4"])), cellXF);
            slcell2 = slcells.Add(x, 11, "" + (decimal.Parse(sl_dic["ghc5"]) + decimal.Parse(sl_dic["ycc5"]) + decimal.Parse(sl_dic["zjc5"])), cellXF);
            slcell2 = slcells.Add(x, 12, "" + (decimal.Parse(sl_dic["ghc6"]) + decimal.Parse(sl_dic["ycc6"]) + decimal.Parse(sl_dic["zjc6"])), cellXF);
            slcell2 = slcells.Add(x, 13, "" + (decimal.Parse(sl_dic["ghc7"]) + decimal.Parse(sl_dic["ycc7"]) + decimal.Parse(sl_dic["zjc7"])), cellXF);
            slcell2 = slcells.Add(x, 14, "" + (decimal.Parse(sl_dic["ghc8"]) + decimal.Parse(sl_dic["ycc8"]) + decimal.Parse(sl_dic["zjc8"])), cellXF);
            slcell2 = slcells.Add(x, 15, "" + (decimal.Parse(sl_dic["ghc9"]) + decimal.Parse(sl_dic["ycc9"]) + decimal.Parse(sl_dic["zjc9"])), cellXF);
            //============================

            MergeArea slmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetsl.AddMergeArea(slmeaAttaddre);
            slcell2 = slcells.Add(3, 2, "填报单位（盖章）");

            MergeArea slmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetsl.AddMergeArea(slmeaAttname);
            slcell2 = slcells.Add(3, 4, " 填报人：   ");

            MergeArea slmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetsl.AddMergeArea(slmeaAttname1);
            slcell2 = slcells.Add(3, 6, " 审核人：   ");

            MergeArea slmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetsl.AddMergeArea(slmeaAtt);
            slcell2 = slcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea slmeunit = new MergeArea(3, 3, 18, 19);
            sheetsl.AddMergeArea(slmeunit);
            slcell2 = slcells.Add(3, 18, "单位：万元、亩");



            //MergeArea meaAttsl = new MergeArea(3, 3, 1, 7);
            //sheetsl.AddMergeArea(meaAttsl);
            //slcell2 = slcells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            //汇总所有的资金很项目个数
            //MergeArea meaAttsl = new MergeArea(3, 3, 1, 7);
            //sheetsl.AddMergeArea(meaAttsl);
            //slcell2 = slcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);

            //===============================金堂===========================
            string sheetjtxName = "金堂";
            Worksheet sheetjtx = xls.Workbook.Worksheets.Add(sheetjtxName);//填加名为"总表"的sheetjtx页

            Cells jtxcells = sheetjtx.Cells;//Cells实例是sheetjtx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF jtxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            jtxcellXF.Font.FontName = "宋体";//设定字体
            jtxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            jtxcellXF.UseBorder = true;//使用边框
            jtxcellXF.TextWrapRight = true;//自动换行
            jtxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            jtxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = jtxcells.AddValueCellXF(2, 2, "震", jtxcellXF);//以设定好的格式填加cell
            //jtxcellXF.Font.FontName = "宋体";
            //cell = jtxcells.AddValueCellXF(3, 2, "救", jtxcellXF);//格式可以多次使用\

            sheetjtx.AddColumnInfo(col1);//把格式附加到sheet页上
            //===================================设置标题=====================================================//
            MergeArea jtxmeaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 20 * 20;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell jtxcell = jtxcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(金堂县)", jtxcellXF);
            //==============================================设置表头===============================================//
            MergeArea jtxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetjtx.AddMergeArea(jtxmeaA1);//填加合并单元格
            jtxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            jtxcellXF.Font.Height = 15 * 15;
            jtxcellXF.BottomLineStyle = 1;
            jtxcellXF.BottomLineColor = Colors.Black;
            jtxcellXF.Font.Bold = true;
            jtxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

            Cell jtxcell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    jtxcell2 = jtxcells.Add(j, i, "", cellXF);
                }
            }
             jtxcell2 = jtxcells.Add(4, 1, "序号", jtxcellXF);
            //=============
            jtxcell2.Font.FontName = "Times New Roman";
            MergeArea jtxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetjtx.AddMergeArea(jtxmeaA2);
            jtxcell2 = jtxcells.Add(4, 2, "所属区县", jtxcellXF);
            MergeArea jtxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetjtx.AddMergeArea(jtxmeaA3);
            jtxcell2 = jtxcells.Add(4, 3, "项目名称", jtxcellXF);
            MergeArea jtxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetjtx.AddMergeArea(jtxmeaA4);
            jtxcell2 = jtxcells.Add(4, 4, "建设地址", jtxcellXF);
            MergeArea jtxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetjtx.AddMergeArea(jtxmeaA5);
            jtxcell2 = jtxcells.Add(4, 5, "完工时间", jtxcellXF);


            MergeArea jtxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetjtx.AddMergeArea(jtxmeaA6);
            jtxcell2 = jtxcells.Add(4, 6, "水域面积（亩）", jtxcellXF);

            MergeArea jtxmeaAt7 = new MergeArea(4, 4, 7, 14);
            sheetjtx.AddMergeArea(jtxmeaAt7);
            jtxcell2 = jtxcells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", jtxcellXF);

            MergeArea jtxmeaAx7 = new MergeArea(5, 6, 7, 7);
            sheetjtx.AddMergeArea(jtxmeaAx7);
            jtxcell2 = jtxcells.Add(5, 7, "小计(万元)", jtxcellXF);

            MergeArea jtxmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetjtx.AddMergeArea(jtxmeaA8);
            jtxcell2 = jtxcells.Add(5, 8, "省级以上财政", jtxcellXF);

            MergeArea jtxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetjtx.AddMergeArea(jtxmeaA9);
            jtxcell2 = jtxcells.Add(5, 9, "市级财政", jtxcellXF);

            MergeArea jtxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetjtx.AddMergeArea(jtxmeaA10);
            jtxcell2 = jtxcells.Add(5, 10, "县级财政", jtxcellXF);

            MergeArea jtxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetjtx.AddMergeArea(jtxmeaA11);
            jtxcell2 = jtxcells.Add(5, 11, "财政融资", jtxcellXF);

            MergeArea jtxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetjtx.AddMergeArea(jtxmeaA12);
            jtxcell2 = jtxcells.Add(5, 12, "社会投入", jtxcellXF);

            MergeArea jtxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetjtx.AddMergeArea(jtxmeaA13);
            jtxcell2 = jtxcells.Add(5, 13, "群众投入", jtxcellXF);

            MergeArea jtxmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetjtx.AddMergeArea(jtxmeaA14);
            jtxcell2 = jtxcells.Add(5, 14, "其他", jtxcellXF);

            MergeArea jtxmeaAt15 = new MergeArea(4, 4, 15, 17);
            sheetjtx.AddMergeArea(jtxmeaAt15);
            jtxcell2 = jtxcells.Add(4, 15, "建设用地", jtxcellXF);
            MergeArea jtxmeaA15 = new MergeArea(5, 6, 15, 15);
            sheetjtx.AddMergeArea(jtxmeaA15);
            jtxcell2 = jtxcells.Add(5, 15, "占用土地面积（亩）", jtxcellXF);
            MergeArea jtxmeaA16 = new MergeArea(5, 6, 16, 16);
            sheetjtx.AddMergeArea(jtxmeaA16);
            jtxcell2 = jtxcells.Add(5, 16, "占用方式（流转、征用等）", jtxcellXF);

            MergeArea jtxmeaA17 = new MergeArea(5, 6, 17, 17);
            sheetjtx.AddMergeArea(jtxmeaA17);
            jtxcell2 = jtxcells.Add(5, 17, "单价（元/亩*年）", jtxcellXF);

            MergeArea jtxmeaA18 = new MergeArea(4, 6, 18, 18);
            sheetjtx.AddMergeArea(jtxmeaA18);
            jtxcell2 = jtxcells.Add(4, 18, "目前工程形象进度（涉旅项目）", jtxcellXF);
            MergeArea jtxmeaA19 = new MergeArea(4, 6, 19, 19);
            sheetjtx.AddMergeArea(jtxmeaA19);
            jtxcell2 = jtxcells.Add(4, 19, "管护主体", jtxcellXF);
            System.Data.DataTable dt2jtx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','jt',2)");
            jtxcell2 = jtxcells.Add(7, 1, "一、", cellXF);
            jtxcell2 = jtxcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
           
            for (int i = 0; i < dt2jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt2jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2jtx.Rows.Count + x;
            //小计======================
         //   x = x + 1;
            jtxcell2 = jtxcells.Add(x, 1, dt2jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 6, "" + jt_dic["ycc1"], cellXF);
            jtxcell2 = jtxcells.Add(x, 7, "" + jt_dic["ycc10"], cellXF);
            jtxcell2 = jtxcells.Add(x, 8, "" + jt_dic["ycc2"], cellXF);
            jtxcell2 = jtxcells.Add(x, 9, "" + jt_dic["ycc3"], cellXF);
            jtxcell2 = jtxcells.Add(x, 10, "" + jt_dic["ycc4"], cellXF);
            jtxcell2 = jtxcells.Add(x, 11, "" + jt_dic["ycc5"], cellXF);
            jtxcell2 = jtxcells.Add(x, 12, "" + jt_dic["ycc6"], cellXF);
            jtxcell2 = jtxcells.Add(x, 13, "" + jt_dic["ycc7"], cellXF);
            jtxcell2 = jtxcells.Add(x, 14, "" + jt_dic["ycc8"], cellXF);
            jtxcell2 = jtxcells.Add(x, 15, "" + jt_dic["ycc9"], cellXF);
            //============================
            x =  1 + x;
            //====================在建=============
            System.Data.DataTable dt4jtx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','jt',2)");
            //MergeArea meaAjkjsjtx = new MergeArea(x, x, 1, 7);
            //sheetjtx.AddMergeArea(meaAjkjsjtx);
            jtxcell2 = jtxcells.Add(x, 1, "二、", cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "在建", cellXF);
            x = x + 1;

            for (int i = 0; i < dt4jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt4jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4jtx.Rows.Count + x;
            //小计======================
         //   x = x + 1;
            jtxcell2 = jtxcells.Add(x, 1, dt4jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 6, "" + jt_dic["zjc1"], cellXF);
            jtxcell2 = jtxcells.Add(x, 7, "" + jt_dic["zjc10"], cellXF);
            jtxcell2 = jtxcells.Add(x, 8, "" + jt_dic["zjc2"], cellXF);
            jtxcell2 = jtxcells.Add(x, 9, "" + jt_dic["zjc3"], cellXF);
            jtxcell2 = jtxcells.Add(x, 10, "" + jt_dic["zjc4"], cellXF);
            jtxcell2 = jtxcells.Add(x, 11, "" + jt_dic["zjc5"], cellXF);
            jtxcell2 = jtxcells.Add(x, 12, "" + jt_dic["zjc6"], cellXF);
            jtxcell2 = jtxcells.Add(x, 13, "" + jt_dic["zjc7"], cellXF);
            jtxcell2 = jtxcells.Add(x, 14, "" + jt_dic["zjc8"], cellXF);
            jtxcell2 = jtxcells.Add(x, 15, "" + jt_dic["zjc9"], cellXF);
            //============================
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6jtx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','jt',2)");
            
            jtxcell2 = jtxcells.Add(x, 1, "三、", cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt6jtx.Rows.Count; i++)
            {
                jtxcell2 = jtxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6jtx.Columns.Count; j++)
                {
                    jtxcell2.Font.FontName = "宋体";
                    jtxcell2 = jtxcells.Add(i + x, j + 2, dt6jtx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6jtx.Rows.Count + x;
            //小计======================
       //     x = x + 1;
            jtxcell2 = jtxcells.Add(x, 1, dt6jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "小计", cellXF);
            jtxcell2 = jtxcells.Add(x, 6, "" + jt_dic["ghc1"], cellXF);
            jtxcell2 = jtxcells.Add(x, 7, "" + jt_dic["ghc10"], cellXF);
            jtxcell2 = jtxcells.Add(x, 8, "" + jt_dic["ghc2"], cellXF);
            jtxcell2 = jtxcells.Add(x, 9, "" + jt_dic["ghc3"], cellXF);
            jtxcell2 = jtxcells.Add(x, 10, "" + jt_dic["ghc4"], cellXF);
            jtxcell2 = jtxcells.Add(x, 11, "" + jt_dic["ghc5"], cellXF);
            jtxcell2 = jtxcells.Add(x, 12, "" + jt_dic["ghc6"], cellXF);
            jtxcell2 = jtxcells.Add(x, 13, "" + jt_dic["ghc7"], cellXF);
            jtxcell2 = jtxcells.Add(x, 14, "" + jt_dic["ghc8"], cellXF);
            jtxcell2 = jtxcells.Add(x, 15, "" + jt_dic["ghc9"], cellXF);
            //============================
            x = x + 1;
            jtxcell2 = jtxcells.Add(x, 1, dt2jtx.Rows.Count + dt4jtx.Rows.Count + dt6jtx.Rows.Count, cellXF);
            jtxcell2 = jtxcells.Add(x, 2, "合计", cellXF);
            jtxcell2 = jtxcells.Add(x, 6, "" + (decimal.Parse(jt_dic["ghc1"]) + decimal.Parse(jt_dic["ycc1"]) + decimal.Parse(jt_dic["zjc1"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 7, "" + (decimal.Parse(jt_dic["ghc10"]) + decimal.Parse(jt_dic["ycc10"]) + decimal.Parse(jt_dic["zjc10"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 8, "" + (decimal.Parse(jt_dic["ghc2"]) + decimal.Parse(jt_dic["ycc2"]) + decimal.Parse(jt_dic["zjc2"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 9, "" + (decimal.Parse(jt_dic["ghc3"]) + decimal.Parse(jt_dic["ycc3"]) + decimal.Parse(jt_dic["zjc3"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 10, "" + (decimal.Parse(jt_dic["ghc4"]) + decimal.Parse(jt_dic["ycc4"]) + decimal.Parse(jt_dic["zjc4"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 11, "" + (decimal.Parse(jt_dic["ghc5"]) + decimal.Parse(jt_dic["ycc5"]) + decimal.Parse(jt_dic["zjc5"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 12, "" + (decimal.Parse(jt_dic["ghc6"]) + decimal.Parse(jt_dic["ycc6"]) + decimal.Parse(jt_dic["zjc6"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 13, "" + (decimal.Parse(jt_dic["ghc7"]) + decimal.Parse(jt_dic["ycc7"]) + decimal.Parse(jt_dic["zjc7"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 14, "" + (decimal.Parse(jt_dic["ghc8"]) + decimal.Parse(jt_dic["ycc8"]) + decimal.Parse(jt_dic["zjc8"])), cellXF);
            jtxcell2 = jtxcells.Add(x, 15, "" + (decimal.Parse(jt_dic["ghc9"]) + decimal.Parse(jt_dic["ycc9"]) + decimal.Parse(jt_dic["zjc9"])), cellXF);
            //============================


            MergeArea jtxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetjtx.AddMergeArea(jtxmeaAttaddre);
            jtxcell2 = jtxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea jtxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetjtx.AddMergeArea(jtxmeaAttname);
            jtxcell2 = jtxcells.Add(3, 4, " 填报人：   ");

            MergeArea jtxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetjtx.AddMergeArea(jtxmeaAttname1);
            jtxcell2 = jtxcells.Add(3, 6, " 审核人：   ");

            MergeArea jtxmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetjtx.AddMergeArea(jtxmeaAtt);
            jtxcell2 = jtxcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea jtxmeunit = new MergeArea(3, 3, 18, 19);
            sheetjtx.AddMergeArea(jtxmeunit);
            jtxcell2 = jtxcells.Add(3, 18, "单位：万元、亩");



            //MergeArea meaAttjtx = new MergeArea(3, 3, 1, 7);
            //sheetjtx.AddMergeArea(meaAttjtx);
            //jtxcell2 = jtxcells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            ////汇总所有的资金很项目个数
            //MergeArea meaAttjtx = new MergeArea(3, 3, 1, 7);
            //sheetjtx.AddMergeArea(meaAttjtx);
            //jtxcell2 = jtxcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
            //============================================青白江=================
            string sheetqbjName = "青白江";
            Worksheet sheetqbj = xls.Workbook.Worksheets.Add(sheetqbjName);//填加名为"总表"的sheetqbj页
            Cells qbjcells = sheetqbj.Cells;//Cells实例是sheetqbj页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbjcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbjcellXF.Font.FontName = "宋体";//设定字体
            qbjcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbjcellXF.UseBorder = true;//使用边框
            qbjcellXF.TextWrapRight = true;//自动换行
            qbjcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbjcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = qbjcells.AddValueCellXF(2, 2, "震", qbjcellXF);//以设定好的格式填加cell
            //qbjcellXF.Font.FontName = "宋体";
            //cell = qbjcells.AddValueCellXF(3, 2, "救", qbjcellXF);//格式可以多次使用
            //===================================设置标题=====================================================//
            MergeArea qbjmeaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 20 * 20;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbjcell = qbjcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(青白江区)", qbjcellXF);
            sheetqbj.AddColumnInfo(col1);//把格式附加到sheet页上
            //==============================================设置表头===============================================//
            MergeArea qbjmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbj.AddMergeArea(qbjmeaA1);//填加合并单元格
            qbjcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbjcellXF.Font.Height = 15 * 15;
            qbjcellXF.BottomLineStyle = 1;
            qbjcellXF.BottomLineColor = Colors.Black;
            qbjcellXF.Font.Bold = true;
            qbjcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

            Cell qbjcell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    qbjcell2 = qbjcells.Add(j, i, "", cellXF);
                }
            }
             qbjcell2 = qbjcells.Add(4, 1, "序号", qbjcellXF);
            //=============
            qbjcell2.Font.FontName = "Times New Roman";
            MergeArea qbjmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbj.AddMergeArea(qbjmeaA2);
            qbjcell2 = qbjcells.Add(4, 2, "所属区县", qbjcellXF);
            MergeArea qbjmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbj.AddMergeArea(qbjmeaA3);
            qbjcell2 = qbjcells.Add(4, 3, "项目名称", qbjcellXF);
            MergeArea qbjmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbj.AddMergeArea(qbjmeaA4);
            qbjcell2 = qbjcells.Add(4, 4, "建设地址", qbjcellXF);
            MergeArea qbjmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbj.AddMergeArea(qbjmeaA5);
            qbjcell2 = qbjcells.Add(4, 5, "完工时间", qbjcellXF);
            MergeArea qbjmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbj.AddMergeArea(qbjmeaA6);
            qbjcell2 = qbjcells.Add(4, 6, "水域面积（亩）", qbjcellXF);
            MergeArea qbjmeaAt7 = new MergeArea(4, 4, 7, 14);
            sheetqbj.AddMergeArea(qbjmeaAt7);
            qbjcell2 = qbjcells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", qbjcellXF);

            MergeArea qbjmeaAx7 = new MergeArea(5, 6, 7, 7);
            sheetqbj.AddMergeArea(qbjmeaAx7);
            qbjcell2 = qbjcells.Add(5, 7, "小计(万元)", qbjcellXF);

            MergeArea qbjmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetqbj.AddMergeArea(qbjmeaA8);
            qbjcell2 = qbjcells.Add(5, 8, "省级以上财政", qbjcellXF);

            MergeArea qbjmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbj.AddMergeArea(qbjmeaA9);
            qbjcell2 = qbjcells.Add(5, 9, "市级财政", qbjcellXF);

            MergeArea qbjmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbj.AddMergeArea(qbjmeaA10);
            qbjcell2 = qbjcells.Add(5, 10, "县级财政", qbjcellXF);

            MergeArea qbjmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbj.AddMergeArea(qbjmeaA11);
            qbjcell2 = qbjcells.Add(5, 11, "财政融资", qbjcellXF);

            MergeArea qbjmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbj.AddMergeArea(qbjmeaA12);
            qbjcell2 = qbjcells.Add(5, 12, "社会投入", qbjcellXF);

            MergeArea qbjmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbj.AddMergeArea(qbjmeaA13);
            qbjcell2 = qbjcells.Add(5, 13, "群众投入", qbjcellXF);

            MergeArea qbjmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetqbj.AddMergeArea(qbjmeaA14);
            qbjcell2 = qbjcells.Add(5, 14, "其他", qbjcellXF);

            MergeArea qbjmeaAt15 = new MergeArea(4, 4, 15, 17);
            sheetqbj.AddMergeArea(qbjmeaAt15);
            qbjcell2 = qbjcells.Add(4, 15, "建设用地", qbjcellXF);
            MergeArea qbjmeaA15 = new MergeArea(5, 6, 15, 15);
            sheetqbj.AddMergeArea(qbjmeaA15);
            qbjcell2 = qbjcells.Add(5, 15, "占用土地面积（亩）", qbjcellXF);
            MergeArea qbjmeaA16 = new MergeArea(5, 6, 16, 16);
            sheetqbj.AddMergeArea(qbjmeaA16);
            qbjcell2 = qbjcells.Add(5, 16, "占用方式（流转、征用等）", qbjcellXF);

            MergeArea qbjmeaA17 = new MergeArea(5, 6, 17, 17);
            sheetqbj.AddMergeArea(qbjmeaA17);
            qbjcell2 = qbjcells.Add(5, 17, "单价（元/亩*年）", qbjcellXF);

            MergeArea qbjmeaA18 = new MergeArea(4, 6, 18, 18);
            sheetqbj.AddMergeArea(qbjmeaA18);
            qbjcell2 = qbjcells.Add(4, 18, "目前工程形象进度（涉旅项目）", qbjcellXF);
            MergeArea qbjmeaA19 = new MergeArea(4, 6, 19, 19);
            sheetqbj.AddMergeArea(qbjmeaA19);
            qbjcell2 = qbjcells.Add(4, 19, "管护主体", qbjcellXF);

            System.Data.DataTable dt2qbj = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','qbj',2)");
            //MergeArea meaAtcdcqbj = new MergeArea(7, 7, 1, 7);
            //sheetqbj.AddMergeArea(meaAtcdcqbj);
            qbjcell2 = qbjcells.Add(7, 1, "一、", cellXF);
            qbjcell2 = qbjcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
        
            for (int i = 0; i < dt2qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt2qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt2qbj.Rows.Count  + x;
            //小计======================
        //    x = x + 1;
            qbjcell2 = qbjcells.Add(x, 1, dt2qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 6, "" + qbj_dic["ycc1"], cellXF);
            qbjcell2 = qbjcells.Add(x, 7, "" + qbj_dic["ycc10"], cellXF);
            qbjcell2 = qbjcells.Add(x, 8, "" + qbj_dic["ycc2"], cellXF);
            qbjcell2 = qbjcells.Add(x, 9, "" + qbj_dic["ycc3"], cellXF);
            qbjcell2 = qbjcells.Add(x, 10, "" + qbj_dic["ycc4"], cellXF);
            qbjcell2 = qbjcells.Add(x, 11, "" + qbj_dic["ycc5"], cellXF);
            qbjcell2 = qbjcells.Add(x, 12, "" + qbj_dic["ycc6"], cellXF);
            qbjcell2 = qbjcells.Add(x, 13, "" + qbj_dic["ycc7"], cellXF);
            qbjcell2 = qbjcells.Add(x, 14, "" + qbj_dic["ycc8"], cellXF);
            qbjcell2 = qbjcells.Add(x, 15, "" + qbj_dic["ycc9"], cellXF);
            //============================
            x = 1 + x;
            //====================在建=============
            System.Data.DataTable dt4qbj = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','qbj',2)");
            //MergeArea meaAjkjsqbj = new MergeArea(x, x, 1, 7);
            //sheetqbj.AddMergeArea(meaAjkjsqbj);
            qbjcell2 = qbjcells.Add(x, 1, "二、", cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt4qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4qbj.Rows.Count + x;
            //小计======================
       //     x = x + 1;
            qbjcell2 = qbjcells.Add(x, 1, dt4qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 6, "" + qbj_dic["zjc1"], cellXF);
            qbjcell2 = qbjcells.Add(x, 7, "" + qbj_dic["zjc10"], cellXF);
            qbjcell2 = qbjcells.Add(x, 8, "" + qbj_dic["zjc2"], cellXF);
            qbjcell2 = qbjcells.Add(x, 9, "" + qbj_dic["zjc3"], cellXF);
            qbjcell2 = qbjcells.Add(x, 10, "" + qbj_dic["zjc4"], cellXF);
            qbjcell2 = qbjcells.Add(x, 11, "" + qbj_dic["zjc5"], cellXF);
            qbjcell2 = qbjcells.Add(x, 12, "" + qbj_dic["zjc6"], cellXF);
            qbjcell2 = qbjcells.Add(x, 13, "" + qbj_dic["zjc7"], cellXF);
            qbjcell2 = qbjcells.Add(x, 14, "" + qbj_dic["zjc8"], cellXF);
            qbjcell2 = qbjcells.Add(x, 15, "" + qbj_dic["zjc9"], cellXF);
            //============================
            x =  1 + x;
            //===============================规划=============
            System.Data.DataTable dt6qbj = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','qbj',2)");
            //MergeArea meaAcjkgqbj = new MergeArea(x, x, 1, 7);
            //sheetqbj.AddMergeArea(meaAcjkgqbj);
            qbjcell2 = qbjcells.Add(x, 1, "三、", cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "规划", cellXF);
            x = x + 1;

            for (int i = 0; i < dt6qbj.Rows.Count; i++)
            {
                qbjcell2 = qbjcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6qbj.Columns.Count; j++)
                {
                    qbjcell2.Font.FontName = "宋体";
                    qbjcell2 = qbjcells.Add(i + x, j + 2, dt6qbj.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6qbj.Rows.Count  + x;
            //小计======================
        //    x = x + 1;
            qbjcell2 = qbjcells.Add(x, 1, dt6qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "小计", cellXF);
            qbjcell2 = qbjcells.Add(x, 6, "" + qbj_dic["ghc1"], cellXF);
            qbjcell2 = qbjcells.Add(x, 7, "" + qbj_dic["ghc10"], cellXF);
            qbjcell2 = qbjcells.Add(x, 8, "" + qbj_dic["ghc2"], cellXF);
            qbjcell2 = qbjcells.Add(x, 9, "" + qbj_dic["ghc3"], cellXF);
            qbjcell2 = qbjcells.Add(x, 10, "" + qbj_dic["ghc4"], cellXF);
            qbjcell2 = qbjcells.Add(x, 11, "" + qbj_dic["ghc5"], cellXF);
            qbjcell2 = qbjcells.Add(x, 12, "" + qbj_dic["ghc6"], cellXF);
            qbjcell2 = qbjcells.Add(x, 13, "" + qbj_dic["ghc7"], cellXF);
            qbjcell2 = qbjcells.Add(x, 14, "" + qbj_dic["ghc8"], cellXF);
            qbjcell2 = qbjcells.Add(x, 15, "" + qbj_dic["ghc9"], cellXF);
            x = x + 1;
            qbjcell2 = qbjcells.Add(x, 1, dt2qbj.Rows.Count + dt4qbj.Rows.Count + dt6qbj.Rows.Count, cellXF);
            qbjcell2 = qbjcells.Add(x, 2, "合计", cellXF);
            qbjcell2 = qbjcells.Add(x, 6, "" + (decimal.Parse(qbj_dic["ghc1"]) + decimal.Parse(qbj_dic["ycc1"]) + decimal.Parse(qbj_dic["zjc1"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 7, "" + (decimal.Parse(qbj_dic["ghc10"]) + decimal.Parse(qbj_dic["ycc10"]) + decimal.Parse(qbj_dic["zjc10"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 8, "" + (decimal.Parse(qbj_dic["ghc2"]) + decimal.Parse(qbj_dic["ycc2"]) + decimal.Parse(qbj_dic["zjc2"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 9, "" + (decimal.Parse(qbj_dic["ghc3"]) + decimal.Parse(qbj_dic["ycc3"]) + decimal.Parse(qbj_dic["zjc3"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 10, "" + (decimal.Parse(qbj_dic["ghc4"]) + decimal.Parse(qbj_dic["ycc4"]) + decimal.Parse(qbj_dic["zjc4"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 11, "" + (decimal.Parse(qbj_dic["ghc5"]) + decimal.Parse(qbj_dic["ycc5"]) + decimal.Parse(qbj_dic["zjc5"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 12, "" + (decimal.Parse(qbj_dic["ghc6"]) + decimal.Parse(qbj_dic["ycc6"]) + decimal.Parse(qbj_dic["zjc6"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 13, "" + (decimal.Parse(qbj_dic["ghc7"]) + decimal.Parse(qbj_dic["ycc7"]) + decimal.Parse(qbj_dic["zjc7"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 14, "" + (decimal.Parse(qbj_dic["ghc8"]) + decimal.Parse(qbj_dic["ycc8"]) + decimal.Parse(qbj_dic["zjc8"])), cellXF);
            qbjcell2 = qbjcells.Add(x, 15, "" + (decimal.Parse(qbj_dic["ghc9"]) + decimal.Parse(qbj_dic["ycc9"]) + decimal.Parse(qbj_dic["zjc9"])), cellXF);
            //============================

            MergeArea qbjmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbj.AddMergeArea(qbjmeaAttaddre);
            qbjcell2 = qbjcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbjmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbj.AddMergeArea(qbjmeaAttname);
            qbjcell2 = qbjcells.Add(3, 4, " 填报人：   ");
            MergeArea qbjmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbj.AddMergeArea(qbjmeaAttname1);
            qbjcell2 = qbjcells.Add(3, 6, " 审核人：   ");

            MergeArea qbjmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetqbj.AddMergeArea(qbjmeaAtt);
            qbjcell2 = qbjcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea qbjmeunit = new MergeArea(3, 3, 18, 19);
            sheetqbj.AddMergeArea(qbjmeunit);
            qbjcell2 = qbjcells.Add(3, 18, "单位：万元、亩");




            //MergeArea meaAttqbj = new MergeArea(3, 3, 1, 7);
            //sheetqbj.AddMergeArea(meaAttqbj);
            //qbjcell2 = qbjcells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
            ////汇总所有的资金很项目个数
            //MergeArea meaAttqbj = new MergeArea(3, 3, 1, 7);
            //sheetqbj.AddMergeArea(meaAttqbj);
            //qbjcell2 = qbjcells.Add(3, 1, "（项目共计：" + number + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);



            //=============================新津==================
            string sheetqbxName = "新津";
            Worksheet sheetqbx = xls.Workbook.Worksheets.Add(sheetqbxName);//填加名为"总表"的sheetqbx页

            Cells qbxcells = sheetqbx.Cells;//Cells实例是sheetqbx页中单元格（cell）集合
            //cell的格式还可以定义在一个xf对象中
            XF qbxcellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
            qbxcellXF.Font.FontName = "宋体";//设定字体
            qbxcellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
            qbxcellXF.UseBorder = true;//使用边框
            qbxcellXF.TextWrapRight = true;//自动换行
            qbxcellXF.BottomLineStyle = 2;//设定边框底线为粗线
            qbxcellXF.BottomLineColor = Colors.Black;//设定颜色为暗红
            //cell = qbxcells.AddValueCellXF(2, 2, "震", qbxcellXF);//以设定好的格式填加cell
            //qbxcellXF.Font.FontName = "宋体";
            //cell = qbxcells.AddValueCellXF(3, 2, "救", qbxcellXF);//格式可以多次使用
            sheetqbx.AddColumnInfo(col1);//把格式附加到sheet页上
            //===================================设置标题=====================================================//
            MergeArea qbxmeaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 20 * 20;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbxcell = qbxcells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表(新津)", qbxcellXF);
            //==============================================设置表头===============================================//
            MergeArea qbxmeaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
            sheetqbx.AddMergeArea(qbxmeaA1);//填加合并单元格
            qbxcellXF.VerticalAlignment = VerticalAlignments.Centered;
            qbxcellXF.Font.Height = 15 * 15;
            qbxcellXF.BottomLineStyle = 1;
            qbxcellXF.BottomLineColor = Colors.Black;
            qbxcellXF.Font.Bold = true;
            qbxcellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
            Cell qbxcell2 = null;
            for (int i = 1; i < 20; i++)
            {
                for (int j = 2; j < 200; j++)
                {
                    qbxcell2 = qbxcells.Add(j, i, "", cellXF);
                }
            }
             qbxcell2 = qbxcells.Add(4, 1, "序号", qbxcellXF);
            //=============
            qbxcell2.Font.FontName = "Times New Roman";
            MergeArea qbxmeaA2 = new MergeArea(4, 6, 2, 2);
            sheetqbx.AddMergeArea(qbxmeaA2);
            qbxcell2 = qbxcells.Add(4, 2, "所属区县", qbxcellXF);
            MergeArea qbxmeaA3 = new MergeArea(4, 6, 3, 3);
            sheetqbx.AddMergeArea(qbxmeaA3);
            qbxcell2 = qbxcells.Add(4, 3, "项目名称", qbxcellXF);
            MergeArea qbxmeaA4 = new MergeArea(4, 6, 4, 4);
            sheetqbx.AddMergeArea(qbxmeaA4);
            qbxcell2 = qbxcells.Add(4, 4, "建设地址", qbxcellXF);
            MergeArea qbxmeaA5 = new MergeArea(4, 6, 5, 5);
            sheetqbx.AddMergeArea(qbxmeaA5);
            qbxcell2 = qbxcells.Add(4, 5, "完工时间", qbxcellXF);


            MergeArea qbxmeaA6 = new MergeArea(4, 6, 6, 6);
            sheetqbx.AddMergeArea(qbxmeaA6);
            qbxcell2 = qbxcells.Add(4, 6, "水域面积（亩）", qbxcellXF);

            MergeArea qbxmeaAt7 = new MergeArea(4, 4, 7, 14);
            sheetqbx.AddMergeArea(qbxmeaAt7);
            qbxcell2 = qbxcells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", qbxcellXF);

            MergeArea qbxmeaAx7 = new MergeArea(5, 6, 7, 7);
            sheetqbx.AddMergeArea(qbxmeaAx7);
            qbxcell2 = qbxcells.Add(5, 7, "小计(万元)", qbxcellXF);

            MergeArea qbxmeaA8 = new MergeArea(5, 6, 8, 8);
            sheetqbx.AddMergeArea(qbxmeaA8);
            qbxcell2 = qbxcells.Add(5, 8, "省级以上财政", qbxcellXF);

            MergeArea qbxmeaA9 = new MergeArea(5, 6, 9, 9);
            sheetqbx.AddMergeArea(qbxmeaA9);
            qbxcell2 = qbxcells.Add(5, 9, "市级财政", qbxcellXF);

            MergeArea qbxmeaA10 = new MergeArea(5, 6, 10, 10);
            sheetqbx.AddMergeArea(qbxmeaA10);
            qbxcell2 = qbxcells.Add(5, 10, "县级财政", qbxcellXF);

            MergeArea qbxmeaA11 = new MergeArea(5, 6, 11, 11);
            sheetqbx.AddMergeArea(qbxmeaA11);
            qbxcell2 = qbxcells.Add(5, 11, "财政融资", qbxcellXF);

            MergeArea qbxmeaA12 = new MergeArea(5, 6, 12, 12);
            sheetqbx.AddMergeArea(qbxmeaA12);
            qbxcell2 = qbxcells.Add(5, 12, "社会投入", qbxcellXF);

            MergeArea qbxmeaA13 = new MergeArea(5, 6, 13, 13);
            sheetqbx.AddMergeArea(qbxmeaA13);
            qbxcell2 = qbxcells.Add(5, 13, "群众投入", qbxcellXF);

            MergeArea qbxmeaA14 = new MergeArea(5, 6, 14, 14);
            sheetqbx.AddMergeArea(qbxmeaA14);
            qbxcell2 = qbxcells.Add(5, 14, "其他", qbxcellXF);

            MergeArea qbxmeaAt15 = new MergeArea(4, 4, 15, 17);
            sheetqbx.AddMergeArea(qbxmeaAt15);
            qbxcell2 = qbxcells.Add(4, 15, "建设用地", qbxcellXF);
            MergeArea qbxmeaA15 = new MergeArea(5, 6, 15, 15);
            sheetqbx.AddMergeArea(qbxmeaA15);
            qbxcell2 = qbxcells.Add(5, 15, "占用土地面积（亩）", qbxcellXF);
            MergeArea qbxmeaA16 = new MergeArea(5, 6, 16, 16);
            sheetqbx.AddMergeArea(qbxmeaA16);
            qbxcell2 = qbxcells.Add(5, 16, "占用方式（流转、征用等）", qbxcellXF);

            MergeArea qbxmeaA17 = new MergeArea(5, 6, 17, 17);
            sheetqbx.AddMergeArea(qbxmeaA17);
            qbxcell2 = qbxcells.Add(5, 17, "单价（元/亩*年）", qbxcellXF);

            MergeArea qbxmeaA18 = new MergeArea(4, 6, 18, 18);
            sheetqbx.AddMergeArea(qbxmeaA18);
            qbxcell2 = qbxcells.Add(4, 18, "目前工程形象进度（涉旅项目）", qbxcellXF);
            MergeArea qbxmeaA19 = new MergeArea(4, 6, 19, 19);
            sheetqbx.AddMergeArea(qbxmeaA19);
            qbxcell2 = qbxcells.Add(4, 19, "管护主体", qbxcellXF);


            System.Data.DataTable dt2qbx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','xj',2)");
            //MergeArea meaAtcdcqbx = new MergeArea(7, 7, 1, 7);
            //sheetqbx.AddMergeArea(meaAtcdcqbx);
            qbxcell2 = qbxcells.Add(7, 1, "一、", cellXF);
            qbxcell2 = qbxcells.Add(7, 2, "已成", cellXF);
            x = 8;
            //===============================已成=============
            
            for (int i = 0; i < dt2qbx.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt2qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt2qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            //小计======================
         //   x = x + 1;
            qbxcell2 = qbxcells.Add(x, 1, dt2qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 6, "" + xj_dic["ycc1"], cellXF);
            qbxcell2 = qbxcells.Add(x, 7, "" + xj_dic["ycc10"], cellXF);
            qbxcell2 = qbxcells.Add(x, 8, "" + xj_dic["ycc2"], cellXF);
            qbxcell2 = qbxcells.Add(x, 9, "" + xj_dic["ycc3"], cellXF);
            qbxcell2 = qbxcells.Add(x, 10, "" + xj_dic["ycc4"], cellXF);
            qbxcell2 = qbxcells.Add(x, 11, "" + xj_dic["ycc5"], cellXF);
            qbxcell2 = qbxcells.Add(x, 12, "" + xj_dic["ycc6"], cellXF);
            qbxcell2 = qbxcells.Add(x, 13, "" + xj_dic["ycc7"], cellXF);
            qbxcell2 = qbxcells.Add(x, 14, "" + xj_dic["ycc8"], cellXF);
            qbxcell2 = qbxcells.Add(x, 15, "" + xj_dic["ycc9"], cellXF);
            //============================
            x = dt2qbx.Rows.Count + 1 + x;
            //====================在建=============
            System.Data.DataTable dt4qbx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','xj',2)");
            //MergeArea meaAjkjsqbx = new MergeArea(x, x, 1, 7);
            //sheetqbx.AddMergeArea(meaAjkjsqbx);
            qbxcell2 = qbxcells.Add(x, 1, "二、", cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "在建", cellXF);
            x = x + 1;
            

            for (int i = 0; i < dt4qbx.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt4qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt4qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt4qbx.Rows.Count + x;
            //小计======================
          //  x = x + 1;
            qbxcell2 = qbxcells.Add(x, 1, dt4qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 6, "" + xj_dic["zjc1"], cellXF);
            qbxcell2 = qbxcells.Add(x, 7, "" + xj_dic["zjc10"], cellXF);
            qbxcell2 = qbxcells.Add(x, 8, "" + xj_dic["zjc2"], cellXF);
            qbxcell2 = qbxcells.Add(x, 9, "" + xj_dic["zjc3"], cellXF);
            qbxcell2 = qbxcells.Add(x, 10, "" + xj_dic["zjc4"], cellXF);
            qbxcell2 = qbxcells.Add(x, 11, "" + xj_dic["zjc5"], cellXF);
            qbxcell2 = qbxcells.Add(x, 12, "" + xj_dic["zjc6"], cellXF);
            qbxcell2 = qbxcells.Add(x, 13, "" + xj_dic["zjc7"], cellXF);
            qbxcell2 = qbxcells.Add(x, 14, "" + xj_dic["zjc8"], cellXF);
            qbxcell2 = qbxcells.Add(x, 15, "" + xj_dic["zjc9"], cellXF);
            //============================
            x = 1 + x;
            //===============================规划=============
            System.Data.DataTable dt6qbx = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','xj',2)");
            //MergeArea meaAcjkgqbx = new MergeArea(x, x, 1, 7);
            //sheetqbx.AddMergeArea(meaAcjkgqbx);
            qbxcell2 = qbxcells.Add(x, 1, "三、", cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "规划", cellXF);
            x = x + 1;
           

            for (int i = 0; i < dt6qbx.Rows.Count; i++)
            {
                qbxcell2 = qbxcells.Add(i + x, 1, i + 1, cellXFcont);
                for (int j = 0; j < dt6qbx.Columns.Count; j++)
                {
                    qbxcell2.Font.FontName = "宋体";
                    qbxcell2 = qbxcells.Add(i + x, j + 2, dt6qbx.Rows[i][j].ToString() + " ", cellXFcont);
                }
            }
            x = dt6qbx.Rows.Count + x;
            //小计======================
          //  x = x + 1;
            qbxcell2 = qbxcells.Add(x, 1, dt6qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "小计", cellXF);
            qbxcell2 = qbxcells.Add(x, 6, "" + xj_dic["ghc1"], cellXF);
            qbxcell2 = qbxcells.Add(x, 7, "" + xj_dic["ghc10"], cellXF);
            qbxcell2 = qbxcells.Add(x, 8, "" + xj_dic["ghc2"], cellXF);
            qbxcell2 = qbxcells.Add(x, 9, "" + xj_dic["ghc3"], cellXF);
            qbxcell2 = qbxcells.Add(x, 10, "" + xj_dic["ghc4"], cellXF);
            qbxcell2 = qbxcells.Add(x, 11, "" + xj_dic["ghc5"], cellXF);
            qbxcell2 = qbxcells.Add(x, 12, "" + xj_dic["ghc6"], cellXF);
            qbxcell2 = qbxcells.Add(x, 13, "" + xj_dic["ghc7"], cellXF);
            qbxcell2 = qbxcells.Add(x, 14, "" + xj_dic["ghc8"], cellXF);
            qbxcell2 = qbxcells.Add(x, 15, "" + xj_dic["ghc9"], cellXF);
            x = x + 1;

            qbxcell2 = qbxcells.Add(x, 1, dt2qbx.Rows.Count + dt4qbx.Rows.Count + dt6qbx.Rows.Count, cellXF);
            qbxcell2 = qbxcells.Add(x, 2, "合计", cellXF);
            qbxcell2 = qbxcells.Add(x, 6, "" + (decimal.Parse(xj_dic["ghc1"]) + decimal.Parse(xj_dic["ycc1"]) + decimal.Parse(xj_dic["zjc1"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 7, "" + (decimal.Parse(xj_dic["ghc10"]) + decimal.Parse(xj_dic["ycc10"]) + decimal.Parse(xj_dic["zjc10"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 8, "" + (decimal.Parse(xj_dic["ghc2"]) + decimal.Parse(xj_dic["ycc2"]) + decimal.Parse(xj_dic["zjc2"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 9, "" + (decimal.Parse(xj_dic["ghc3"]) + decimal.Parse(xj_dic["ycc3"]) + decimal.Parse(xj_dic["zjc3"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 10, "" + (decimal.Parse(xj_dic["ghc4"]) + decimal.Parse(xj_dic["ycc4"]) + decimal.Parse(xj_dic["zjc4"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 11, "" + (decimal.Parse(xj_dic["ghc5"]) + decimal.Parse(xj_dic["ycc5"]) + decimal.Parse(xj_dic["zjc5"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 12, "" + (decimal.Parse(xj_dic["ghc6"]) + decimal.Parse(xj_dic["ycc6"]) + decimal.Parse(xj_dic["zjc6"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 13, "" + (decimal.Parse(xj_dic["ghc7"]) + decimal.Parse(xj_dic["ycc7"]) + decimal.Parse(xj_dic["zjc7"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 14, "" + (decimal.Parse(xj_dic["ghc8"]) + decimal.Parse(xj_dic["ycc8"]) + decimal.Parse(xj_dic["zjc8"])), cellXF);
            qbxcell2 = qbxcells.Add(x, 15, "" + (decimal.Parse(xj_dic["ghc9"]) + decimal.Parse(xj_dic["ycc9"]) + decimal.Parse(xj_dic["zjc9"])), cellXF);
            //============================
        
            //汇总所有的资金很项目个数

            MergeArea qbxmeaAttaddre = new MergeArea(3, 3, 2, 3);
            sheetqbx.AddMergeArea(qbxmeaAttaddre);
            qbxcell2 = qbxcells.Add(3, 2, "填报单位（盖章）");

            MergeArea qbxmeaAttname = new MergeArea(3, 3, 4, 5);
            sheetqbx.AddMergeArea(qbxmeaAttname);
            qbxcell2 = qbxcells.Add(3, 4, " 填报人：   ");

            MergeArea qbxmeaAttname1 = new MergeArea(3, 3, 6, 7);
            sheetqbx.AddMergeArea(qbxmeaAttname1);
            qbxcell2 = qbxcells.Add(3, 6, " 审核人：   ");

            MergeArea qbxmeaAtt = new MergeArea(3, 3, 8, 11);
            sheetqbx.AddMergeArea(qbxmeaAtt);
            qbxcell2 = qbxcells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
            MergeArea qbxmeunit = new MergeArea(3, 3, 18, 19);
            sheetqbx.AddMergeArea(qbxmeunit);
            qbxcell2 = qbxcells.Add(3, 18, "单位：万元、亩");


            //MergeArea meaAttqbx = new MergeArea(3, 3, 1, 7);
            //sheetqbx.AddMergeArea(meaAttqbx);
            //qbxcell2 = qbxcells.Add(3, 1, "[填报单位（盖章）： 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);


            //=================================
            xls.Save(path);
            string fileName = filename + ".xls";//客户端保存的文件名
            string filePath = (path + "/" + filename + ".xls");//路径
            FileInfo fileInfo = new FileInfo(filePath);
            response.Clear();
            response.ClearContent();
            response.ClearHeaders();
            response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
            response.AddHeader("Content-Length", fileInfo.Length.ToString());
            response.AddHeader("Content-Transfer-Encoding", "binary");
            response.ContentType = "application/octet-stream";
            response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
            response.WriteFile(fileInfo.FullName);
            response.Flush();
            try
            {
            //    File.Delete(filePath);
            }
            catch (Exception exx)
            {
                throw new Exception(exx.Message);
            }
            finally
            {
                response.End();
            }
        }
        /// <summary>
        ///  一级审核元下载百湖工程的Excel
        /// </summary>
        /// <param name="response"></param>
        /// <param name="path"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="area"></param>
        public void downbhExcel(HttpResponse response, string path, int year, int season, string area)
        {
            string titleStr = "";
            if (area == "lqy")
            {
                titleStr = "龙泉驿区";
            }
            else if (area == "sl")
            {
                titleStr = "双流县";
            }
            else if (area == "qbj")
            {
                titleStr = "青白江区";
            }
            else if (area == "jt")
            {
                titleStr = "金堂县";
            }
            else if (area == "xj")
            {
                titleStr = "新津县";
            }


            Dictionary<String, String> dic = getbhMoneyAndCountByAddress(year, season, 1, area);



            string filename = "bh_" + area + "_" + System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
                XlsDocument xls = new XlsDocument();//新建一个xls文档
                xls.FileName = filename + ".xls";//设定文件名
                string sheetName = "百湖工程汇总表";
                Worksheet sheet = xls.Workbook.Worksheets.Add(sheetName);//填加名为"总表"的sheet页
                Cells cells = sheet.Cells;//Cells实例是sheet页中单元格（cell）集合
                XF cellXF = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXF.Font.FontName = "宋体";//设定字体
                cellXF.Font.Height = 20 * 20;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXF.UseBorder = true;//使用边框
                cellXF.TextWrapRight = true;//自动换行
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.RightLineColor = Colors.Black;
                cellXF.RightLineStyle = 1;
                ColumnInfo col1 = new ColumnInfo(xls, sheet);//生成列格式对象
                col1.ColumnIndexStart = 1;//起始列为第1列
                col1.ColumnIndexEnd = 31;//终止列为第1列
                col1.Width = 16 * 256;//列的宽度计量单位为 1/256 字符宽
                sheet.AddColumnInfo(col1);//把格式附加到sheet页上
                //===================================设置标题=====================================================//
                MergeArea meaA = new MergeArea(1, 2, 1, 19);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 20 * 20;
                cellXF.Font.Bold = true;
                cellXF.HorizontalAlignment = HorizontalAlignments.Centered; // 设定文字居中 
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充
                Cell cell = cells.Add(1, 1, year + "年龙泉山生态旅游综合功能区 百湖工程（" + new ConstantChangeUtil().getBigNum(season) + ")季度推进情况表 (" + titleStr + ")", cellXF);
                //==============================================设置表
                MergeArea meaA1 = new MergeArea(4, 6, 1, 1);//一个合并单元格实例(合并第一行、第三例 到 第二行、第四例)
                sheet.AddMergeArea(meaA1);//填加合并单元格
                cellXF.VerticalAlignment = VerticalAlignments.Centered;
                cellXF.Font.Height = 15 * 15;
                cellXF.BottomLineStyle = 1;
                cellXF.BottomLineColor = Colors.Black;
                cellXF.Font.Bold = true;
                cellXF.Pattern = 0;//设定单元格填充风格。如果设定为0，则是纯色填充

                //画边框
                Cell cell2 = null;
                for (int i = 1; i < 20; i++)
                {
                    for (int j = 2; j < 200; j++)
                    {
                        cell2 = cells.Add(j, i, "", cellXF);
                    }
                }


                 cell2 = cells.Add(4, 1, "序号", cellXF);
                //=============
                cell2.Font.FontName = "Times New Roman";
                MergeArea meaA2 = new MergeArea(4, 6, 2, 2);
                sheet.AddMergeArea(meaA2);
                cell2 = cells.Add(4, 2, "所属区县", cellXF);
                MergeArea meaA3 = new MergeArea(4, 6, 3, 3);
                sheet.AddMergeArea(meaA3);
                cell2 = cells.Add(4, 3, "项目名称", cellXF);
                MergeArea meaA4 = new MergeArea(4, 6, 4, 4);
                sheet.AddMergeArea(meaA4);
                cell2 = cells.Add(4, 4, "建设地址", cellXF);
                MergeArea meaA5 = new MergeArea(4, 6, 5, 5);
                sheet.AddMergeArea(meaA5);
                cell2 = cells.Add(4, 5, "完工时间", cellXF);
                MergeArea meaA6 = new MergeArea(4, 6, 6, 6);
                sheet.AddMergeArea(meaA6);
                cell2 = cells.Add(4, 6, "水域面积（亩）", cellXF);
                MergeArea meaAt7 = new MergeArea(4, 4, 7, 14);
                sheet.AddMergeArea(meaAt7);
                cell2 = cells.Add(4, 7, new ConstantChangeUtil().getBigNum(season) + "季度工程已完成投资(不含建设用地和移民)", cellXF);
                MergeArea meaAx7 = new MergeArea(5, 6, 7, 7);
                sheet.AddMergeArea(meaAx7);
                cell2 = cells.Add(5, 7, "小计(万元)", cellXF);
                MergeArea meaA8 = new MergeArea(5, 6, 8, 8);
                sheet.AddMergeArea(meaA8);
                cell2 = cells.Add(5, 8, "省级以上财政", cellXF);
                MergeArea meaA9 = new MergeArea(5, 6, 9, 9);
                sheet.AddMergeArea(meaA9);
                cell2 = cells.Add(5, 9, "市级财政", cellXF);
                MergeArea meaA10 = new MergeArea(5, 6, 10, 10);
                sheet.AddMergeArea(meaA10);
                cell2 = cells.Add(5, 10, "县级财政", cellXF);
                MergeArea meaA11 = new MergeArea(5, 6, 11, 11);
                sheet.AddMergeArea(meaA11);
                cell2 = cells.Add(5, 11, "财政融资", cellXF);
                MergeArea meaA12 = new MergeArea(5, 6, 12, 12);
                sheet.AddMergeArea(meaA12);
                cell2 = cells.Add(5, 12, "社会投入", cellXF);
                MergeArea meaA13 = new MergeArea(5, 6, 13, 13);
                sheet.AddMergeArea(meaA13);
                cell2 = cells.Add(5, 13, "群众投入", cellXF);
                MergeArea meaA14 = new MergeArea(5, 6, 14, 14);
                sheet.AddMergeArea(meaA14);
                cell2 = cells.Add(5, 14, "其他", cellXF);
                MergeArea meaAt15 = new MergeArea(4, 4, 15, 17);
                sheet.AddMergeArea(meaAt15);
                cell2 = cells.Add(4, 15, "建设用地", cellXF);
                MergeArea meaA15 = new MergeArea(5, 6, 15, 15);
                sheet.AddMergeArea(meaA15);
                cell2 = cells.Add(5, 15, "占用土地面积（亩）", cellXF);
                MergeArea meaA16 = new MergeArea(5, 6, 16, 16);
                sheet.AddMergeArea(meaA16);
                cell2 = cells.Add(5, 16, "占用方式（流转、征用等）", cellXF);
                MergeArea meaA17 = new MergeArea(5, 6, 17, 17);
                sheet.AddMergeArea(meaA17);
                cell2 = cells.Add(5, 17, "单价（元/亩*年）", cellXF);
                MergeArea meaA18 = new MergeArea(4, 6, 18, 18);
                sheet.AddMergeArea(meaA18);
                cell2 = cells.Add(4, 18, "目前工程形象进度（涉旅项目）", cellXF);
                MergeArea meaA19 = new MergeArea(4, 6, 19, 19);
                sheet.AddMergeArea(meaA19);
                cell2 = cells.Add(4, 19, "管护主体", cellXF);
                //=============================表头完成======================填入正文开始===================
                XF cellXFcont = xls.NewXF();//为xls生成一个XF实例（XF是cell格式对象）
                cellXFcont.HorizontalAlignment = HorizontalAlignments.Centered;//设定文字居中
                cellXFcont.Font.FontName = "宋体";//设定字体
                //cellXFcont.Font.Height = 9* 9;//设定字大小（字体大小是以 1/20 point 为单位的）
                cellXFcont.TextWrapRight = true;//自动换行
                cellXFcont.BottomLineStyle = 1;
                cellXFcont.BottomLineColor = Colors.Black;
                cellXFcont.RightLineColor = Colors.Black;
                cellXFcont.RightLineStyle = 1;

                DataBase db = new DataBase();
                System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','" + area + "',1)");
                //MergeArea meaAtcdc = new MergeArea(7, 7, 1, 7);
                //sheet.AddMergeArea(meaAtcdc);
                cell2 = cells.Add(7, 1, "一、", cellXF);
                cell2 = cells.Add(7, 2, "已成", cellXF);
                int x = 8;
                //int number = 0;
                //double alltotal = 0;
                //double alltotalX = 0;
                //===============================已成=============
                
                for (int i = 0; i < dt2.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt2.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt2.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt2.Rows.Count + x;
                //小计======================
              //  x = x + 1;
                cell2 = cells.Add(x, 1, dt2.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 6, "" + dic["ycc1"], cellXF);
                cell2 = cells.Add(x, 7, "" + dic["ycc10"], cellXF);
                cell2 = cells.Add(x, 8, "" + dic["ycc2"], cellXF);
                cell2 = cells.Add(x, 9, "" + dic["ycc3"], cellXF);
                cell2 = cells.Add(x, 10, "" + dic["ycc4"], cellXF);
                cell2 = cells.Add(x, 11, "" + dic["ycc5"], cellXF);
                cell2 = cells.Add(x, 12, "" + dic["ycc6"], cellXF);
                cell2 = cells.Add(x, 13, "" + dic["ycc7"], cellXF);
                cell2 = cells.Add(x, 14, "" + dic["ycc8"], cellXF);
                cell2 = cells.Add(x, 15, "" + dic["ycc9"], cellXF);
                //============================
                x = 1 + x;
                //====================在建=============
                System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','" + area + "',1)");
                //MergeArea meaAjkjs = new MergeArea(x, x, 1, 7);
                //sheet.AddMergeArea(meaAjkjs);
                cell2 = cells.Add(x, 1, "二、", cellXF);
                cell2 = cells.Add(x, 2, "在建", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt4.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt4.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt4.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt4.Rows.Count  + x;
                //小计======================
            //    x = x + 1;
                cell2 = cells.Add(x, 1, dt4.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 6, "" + dic["zjc1"], cellXF);
                cell2 = cells.Add(x, 7, "" + dic["zjc10"], cellXF);
                cell2 = cells.Add(x, 8, "" + dic["zjc2"], cellXF);
                cell2 = cells.Add(x, 9, "" + dic["zjc3"], cellXF);
                cell2 = cells.Add(x, 10, "" + dic["zjc4"], cellXF);
                cell2 = cells.Add(x, 11, "" + dic["zjc5"], cellXF);
                cell2 = cells.Add(x, 12, "" + dic["zjc6"], cellXF);
                cell2 = cells.Add(x, 13, "" + dic["zjc7"], cellXF);
                cell2 = cells.Add(x, 14, "" + dic["zjc8"], cellXF);
                cell2 = cells.Add(x, 15, "" + dic["zjc9"], cellXF);
                //============================
                x =  1 + x;
                //===============================规划=============
                System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','" + area + "',1)");
                //MergeArea meaAcjkg = new MergeArea(x, x, 1, 7);
                //sheet.AddMergeArea(meaAcjkg);
                cell2 = cells.Add(x, 1, "三、", cellXF);
                cell2 = cells.Add(x, 2, "规划", cellXF);
                x = x + 1;
                

                for (int i = 0; i < dt6.Rows.Count; i++)
                {
                    cell2 = cells.Add(i + x, 1, i + 1, cellXFcont);
                    for (int j = 0; j < dt6.Columns.Count; j++)
                    {
                        cell2.Font.FontName = "宋体";
                        cell2 = cells.Add(i + x, j + 2, dt6.Rows[i][j].ToString() + " ", cellXFcont);
                    }
                }
                x = dt6.Rows.Count + x;
                //小计======================
           //     x = x + 1;
                cell2 = cells.Add(x, 1, dt6.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "小计", cellXF);
                cell2 = cells.Add(x, 6, "" + dic["ghc1"], cellXF);
                cell2 = cells.Add(x, 7, "" + dic["ghc10"], cellXF);
                cell2 = cells.Add(x, 8, "" + dic["ghc2"], cellXF);
                cell2 = cells.Add(x, 9, "" + dic["ghc3"], cellXF);
                cell2 = cells.Add(x, 10, "" + dic["ghc4"], cellXF);
                cell2 = cells.Add(x, 11, "" + dic["ghc5"], cellXF);
                cell2 = cells.Add(x, 12, "" + dic["ghc6"], cellXF);
                cell2 = cells.Add(x, 13, "" + dic["ghc7"], cellXF);
                cell2 = cells.Add(x, 14, "" + dic["ghc8"], cellXF);
                cell2 = cells.Add(x, 15, "" + dic["ghc9"], cellXF);
                x = x + 1;
                cell2 = cells.Add(x, 1, dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count, cellXF);
                cell2 = cells.Add(x, 2, "合计", cellXF);
                cell2 = cells.Add(x, 6, "" + (decimal.Parse(dic["ghc1"]) + decimal.Parse(dic["ycc1"]) + decimal.Parse(dic["zjc1"])), cellXF);
                cell2 = cells.Add(x, 7, "" + (decimal.Parse(dic["ghc10"]) + decimal.Parse(dic["ycc10"]) + decimal.Parse(dic["zjc10"])), cellXF);
                cell2 = cells.Add(x, 8, "" + (decimal.Parse(dic["ghc2"]) + decimal.Parse(dic["ycc2"]) + decimal.Parse(dic["zjc2"])), cellXF);
                cell2 = cells.Add(x, 9, "" + (decimal.Parse(dic["ghc3"]) + decimal.Parse(dic["ycc3"]) + decimal.Parse(dic["zjc3"])), cellXF);
                cell2 = cells.Add(x, 10, "" + (decimal.Parse(dic["ghc4"]) + decimal.Parse(dic["ycc4"]) + decimal.Parse(dic["zjc4"])), cellXF);
                cell2 = cells.Add(x, 11, "" + (decimal.Parse(dic["ghc5"]) + decimal.Parse(dic["ycc5"]) + decimal.Parse(dic["zjc5"])), cellXF);
                cell2 = cells.Add(x, 12, "" + (decimal.Parse(dic["ghc6"]) + decimal.Parse(dic["ycc6"]) + decimal.Parse(dic["zjc6"])), cellXF);
                cell2 = cells.Add(x, 13, "" + (decimal.Parse(dic["ghc7"]) + decimal.Parse(dic["ycc7"]) + decimal.Parse(dic["zjc7"])), cellXF);
                cell2 = cells.Add(x, 14, "" + (decimal.Parse(dic["ghc8"]) + decimal.Parse(dic["ycc8"]) + decimal.Parse(dic["zjc8"])), cellXF);
                cell2 = cells.Add(x, 15, "" + (decimal.Parse(dic["ghc9"]) + decimal.Parse(dic["ycc9"]) + decimal.Parse(dic["zjc9"])), cellXF);
                //============================


                MergeArea meaAttaddre = new MergeArea(3, 3, 2, 3);
                sheet.AddMergeArea(meaAttaddre);
                cell2 = cells.Add(3, 2, "填报单位（盖章）");

                MergeArea meaAttname = new MergeArea(3, 3, 4, 5);
                sheet.AddMergeArea(meaAttname);
                cell2 = cells.Add(3, 4, " 填报人：   ");

                MergeArea meaAttname1 = new MergeArea(3, 3, 6, 7);
                sheet.AddMergeArea(meaAttname1);
                cell2 = cells.Add(3, 6, " 审核人：   ");

                MergeArea meaAtt = new MergeArea(3, 3, 8, 11);
                sheet.AddMergeArea(meaAtt);
                cell2 = cells.Add(3, 8, "  此表统计时间截止" + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXF);
                MergeArea meunit = new MergeArea(3, 3, 18, 19);
                sheet.AddMergeArea(meunit);
                cell2 = cells.Add(3, 18, "单位：万元、亩");

                //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
                //sheet.AddMergeArea(meaAtt);
                //cell2 = cells.Add(3, 1, "[区县：" + titleStr + " 	填报人: 	此表统计时间截止 " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日]", cellXF);
                //汇总所有的资金很项目个数
                //MergeArea meaAtt = new MergeArea(3, 3, 1, 7);
                //sheet.AddMergeArea(meaAtt);
                //cell2 = cells.Add(3, 1, "（项目共计：" + (dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count) + "个；总投资：" + alltotal + "万元；" + year + "年计划投资：" + alltotalX + "万元。）" + "     " + System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日", cellXFcont);
                xls.Save(path);
                string fileName = filename + ".xls";//客户端保存的文件名
                string filePath = (path + "/" + filename + ".xls");//路径
                FileInfo fileInfo = new FileInfo(filePath);
                response.Clear();
                response.ClearContent();
                response.ClearHeaders();
                response.AddHeader("Content-Disposition", "attachment;filename=" + fileName);
                response.AddHeader("Content-Length", fileInfo.Length.ToString());
                response.AddHeader("Content-Transfer-Encoding", "binary");
                response.ContentType = "application/octet-stream";
                response.ContentEncoding = System.Text.Encoding.GetEncoding("gb2312");
                response.WriteFile(fileInfo.FullName);
                response.Flush();
                try
                {
                 //   File.Delete(filePath);
                }
                catch (Exception exx)
                {
                    throw new Exception(exx.Message);
                }
                finally
                {
                    response.End();
                }


            
           
        }

        #endregion

        #region  生态旅游重大项目  获得统计数据报告汇总
        /// <summary>
        /// 生态旅游重大项目计算汇总
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="audit"></param>
        /// <returns></returns>
        public Dictionary<String, String> getstMoneyAndCount(int year, int month, int audit)
        {
            DataBase db=new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getstMoneyAndCount_Admin("+year+","+month+","+audit+")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            //计划投资
            decimal tcdc_all_total = 0;
            decimal jkjs_all_total = 0;
            decimal qqcb_all_total = 0;
            decimal cjkg_all_total = 0;
            //计划投资
            //decimal tcdc_all_plan = 0;
            //decimal jkjs_all_plan = 0;
            //decimal qqcb_all_plan = 0;
            //decimal cjkg_all_plan = 0;



            decimal tcdc_c1 = 0;
            decimal tcdc_c2 = 0;
            decimal tcdc_c3 = 0;
            decimal tcdc_c4 = 0;
            decimal tcdc_c5 = 0;
            decimal tcdc_c6 = 0;
            decimal tcdc_c7 = 0;
            decimal tcdc_c8 = 0;
            decimal tcdc_c9 = 0;
            decimal tcdc_c10 = 0;
            decimal tcdc_c11 = 0;
            decimal tcdc_c12 = 0;
            decimal tcdc_c13 = 0;
            decimal tcdc_c14 = 0;
            decimal tcdc_c15 = 0;

            decimal jkjs_c1 = 0;
            decimal jkjs_c2 = 0;
            decimal jkjs_c3 = 0;
            decimal jkjs_c4 = 0;
            decimal jkjs_c5 = 0;
            decimal jkjs_c6 = 0;
            decimal jkjs_c7 = 0;
            decimal jkjs_c8 = 0;
            decimal jkjs_c9 = 0;
            decimal jkjs_c10 = 0;
            decimal jkjs_c11 = 0;
            decimal jkjs_c12 = 0;
            decimal jkjs_c13 = 0;
            decimal jkjs_c14 = 0;
            decimal jkjs_c15 = 0;

            decimal cjkg_c1 = 0;
            decimal cjkg_c2 = 0;
            decimal cjkg_c3 = 0;
            decimal cjkg_c4 = 0;
            decimal cjkg_c5 = 0;
            decimal cjkg_c6 = 0;
            decimal cjkg_c7 = 0;
            decimal cjkg_c8 = 0;
            decimal cjkg_c9 = 0;
            decimal cjkg_c10 = 0;
            decimal cjkg_c11 = 0;
            decimal cjkg_c12 = 0;
            decimal cjkg_c13 = 0;
            decimal cjkg_c14 = 0;
            decimal cjkg_c15 = 0;

            decimal qqcb_c1 = 0;
            decimal qqcb_c2 = 0;
            decimal qqcb_c3 = 0;
            decimal qqcb_c4 = 0;
            decimal qqcb_c5 = 0;
            decimal qqcb_c6 = 0;
            decimal qqcb_c7 = 0;
            decimal qqcb_c8 = 0;
            decimal qqcb_c9 = 0;
            decimal qqcb_c10 = 0;
            decimal qqcb_c11 = 0;
            decimal qqcb_c12 = 0;
            decimal qqcb_c13 = 0;
            decimal qqcb_c14 = 0;
            decimal qqcb_c15 = 0;


            for(int i=0;i<dt.Rows.Count;i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "tcdc")
                {
                    decimal ctype = 0;
                    if(decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        //tcdc_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        tcdc_all_total += ctype;
                    }

                    ////////////////////

                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        tcdc_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        tcdc_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        tcdc_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        tcdc_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        tcdc_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        tcdc_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        tcdc_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        tcdc_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        tcdc_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        tcdc_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        tcdc_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        tcdc_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        tcdc_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        tcdc_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        tcdc_c15 += ctype;
                    }

                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "jkjs")
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                       // jkjs_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        jkjs_all_total += ctype;
                    }

                    ///////////////

                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        jkjs_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        jkjs_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        jkjs_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        jkjs_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        jkjs_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        jkjs_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        jkjs_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        jkjs_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        jkjs_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        jkjs_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        jkjs_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        jkjs_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        jkjs_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        jkjs_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        jkjs_c15 += ctype;
                    }
                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "qqcb")
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                       // qqcb_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        qqcb_all_total += ctype;
                    }
                    ////

                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        qqcb_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        qqcb_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        qqcb_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        qqcb_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        qqcb_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        qqcb_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        qqcb_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        qqcb_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        qqcb_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        qqcb_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        qqcb_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        qqcb_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        qqcb_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        qqcb_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        qqcb_c15 += ctype;
                    }
                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "cjkg")
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                     //   cjkg_c11 += ctype;

                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        cjkg_all_total += ctype;
                    }


                    //

                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        cjkg_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        cjkg_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        cjkg_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        cjkg_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        cjkg_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        cjkg_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        cjkg_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        cjkg_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        cjkg_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        cjkg_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        cjkg_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        cjkg_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        cjkg_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        cjkg_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        cjkg_c15 += ctype;
                    }
                }
            }
            dic.Add("tcdc_all_total", tcdc_all_total.ToString());
            dic.Add("jkjs_all_total", jkjs_all_total.ToString());
            dic.Add("qqcb_all_total",qqcb_all_total.ToString());
            dic.Add("cjkg_all_total",cjkg_all_total.ToString());

     

            dic.Add("tcdc_c1", tcdc_c1.ToString());
            dic.Add("tcdc_c2", tcdc_c2.ToString());
            dic.Add("tcdc_c3", tcdc_c3.ToString());
            dic.Add("tcdc_c4", tcdc_c4.ToString());
            dic.Add("tcdc_c5", tcdc_c5.ToString());
            dic.Add("tcdc_c6", tcdc_c6.ToString());
            dic.Add("tcdc_c7", tcdc_c7.ToString());
            dic.Add("tcdc_c8", tcdc_c8.ToString());
            dic.Add("tcdc_c9", tcdc_c9.ToString());
            dic.Add("tcdc_c10", tcdc_c10.ToString());
            dic.Add("tcdc_c11", tcdc_c11.ToString());
            dic.Add("tcdc_c12", tcdc_c12.ToString());
            dic.Add("tcdc_c13", tcdc_c13.ToString());
            dic.Add("tcdc_c14", tcdc_c14.ToString());
            dic.Add("tcdc_c15", tcdc_c15.ToString());

            dic.Add("jkjs_c1", jkjs_c1.ToString());
            dic.Add("jkjs_c2", jkjs_c2.ToString());
            dic.Add("jkjs_c3", jkjs_c3.ToString());
            dic.Add("jkjs_c4", jkjs_c4.ToString());
            dic.Add("jkjs_c5", jkjs_c5.ToString());
            dic.Add("jkjs_c6", jkjs_c6.ToString());
            dic.Add("jkjs_c7", jkjs_c7.ToString());
            dic.Add("jkjs_c8", jkjs_c8.ToString());
            dic.Add("jkjs_c9", jkjs_c9.ToString());
            dic.Add("jkjs_c10", jkjs_c10.ToString());
            dic.Add("jkjs_c11", jkjs_c11.ToString());
            dic.Add("jkjs_c12", jkjs_c12.ToString());
            dic.Add("jkjs_c13", jkjs_c13.ToString());
            dic.Add("jkjs_c14", jkjs_c14.ToString());
            dic.Add("jkjs_c15", jkjs_c15.ToString());

            dic.Add("qqcb_c1", qqcb_c1.ToString());
            dic.Add("qqcb_c2", qqcb_c2.ToString());
            dic.Add("qqcb_c3", qqcb_c3.ToString());
            dic.Add("qqcb_c4", qqcb_c4.ToString());
            dic.Add("qqcb_c5", qqcb_c5.ToString());
            dic.Add("qqcb_c6", qqcb_c6.ToString());
            dic.Add("qqcb_c7", qqcb_c7.ToString());
            dic.Add("qqcb_c8", qqcb_c8.ToString());
            dic.Add("qqcb_c9", qqcb_c9.ToString());
            dic.Add("qqcb_c10", qqcb_c10.ToString());
            dic.Add("qqcb_c11", qqcb_c11.ToString());
            dic.Add("qqcb_c12", qqcb_c12.ToString());
            dic.Add("qqcb_c13", qqcb_c13.ToString());
            dic.Add("qqcb_c14", qqcb_c14.ToString());
            dic.Add("qqcb_c15", qqcb_c15.ToString());

            dic.Add("cjkg_c1", cjkg_c1.ToString());
            dic.Add("cjkg_c2", cjkg_c2.ToString());
            dic.Add("cjkg_c3", cjkg_c3.ToString());
            dic.Add("cjkg_c4", cjkg_c4.ToString());
            dic.Add("cjkg_c5", cjkg_c5.ToString());
            dic.Add("cjkg_c6", cjkg_c6.ToString());
            dic.Add("cjkg_c7", cjkg_c7.ToString());
            dic.Add("cjkg_c8", cjkg_c8.ToString());
            dic.Add("cjkg_c9", cjkg_c9.ToString());
            dic.Add("cjkg_c10", cjkg_c10.ToString());
            dic.Add("cjkg_c11", cjkg_c11.ToString());
            dic.Add("cjkg_c12", cjkg_c12.ToString());
            dic.Add("cjkg_c13", cjkg_c13.ToString());
            dic.Add("cjkg_c14", cjkg_c14.ToString());
            dic.Add("cjkg_c15", cjkg_c15.ToString());

            return dic;
            
        }
        /// <summary>
        /// 根据不同地区获得不同的统计数据
        /// </summary>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="audit"></param>
        /// <param name="address"></param>
        /// <returns></returns>
        public Dictionary<String, String> getstMoneyAndCountByAddress(int year, int month, int audit, string address)
        {
            DataBase db = new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getstMoneyAndCount_Admin(" + year + "," + month + "," + audit + ")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            //计划投资
            decimal tcdc_total = 0;
            decimal jkjs_total = 0;
            decimal qqcb_total = 0;
            decimal cjkg_total = 0;
            ////计划投资
            //decimal tcdc_plan = 0;
            //decimal jkjs_plan = 0;
            //decimal qqcb_plan = 0;
            //decimal cjkg_plan = 0;

            decimal tcdc_c1 = 0;
            decimal tcdc_c2 = 0;
            decimal tcdc_c3 = 0;
            decimal tcdc_c4 = 0;
            decimal tcdc_c5 = 0;
            decimal tcdc_c6 = 0;
            decimal tcdc_c7 = 0;
            decimal tcdc_c8 = 0;
            decimal tcdc_c9 = 0;
            decimal tcdc_c10 = 0;
            decimal tcdc_c11 = 0;
            decimal tcdc_c12 = 0;
            decimal tcdc_c13 = 0;
            decimal tcdc_c14 = 0;
            decimal tcdc_c15 = 0;

            decimal jkjs_c1 = 0;
            decimal jkjs_c2 = 0;
            decimal jkjs_c3 = 0;
            decimal jkjs_c4 = 0;
            decimal jkjs_c5 = 0;
            decimal jkjs_c6 = 0;
            decimal jkjs_c7 = 0;
            decimal jkjs_c8 = 0;
            decimal jkjs_c9 = 0;
            decimal jkjs_c10 = 0;
            decimal jkjs_c11 = 0;
            decimal jkjs_c12 = 0;
            decimal jkjs_c13 = 0;
            decimal jkjs_c14 = 0;
            decimal jkjs_c15 = 0;

            decimal cjkg_c1 = 0;
            decimal cjkg_c2 = 0;
            decimal cjkg_c3 = 0;
            decimal cjkg_c4 = 0;
            decimal cjkg_c5 = 0;
            decimal cjkg_c6 = 0;
            decimal cjkg_c7 = 0;
            decimal cjkg_c8 = 0;
            decimal cjkg_c9 = 0;
            decimal cjkg_c10 = 0;
            decimal cjkg_c11 = 0;
            decimal cjkg_c12 = 0;
            decimal cjkg_c13 = 0;
            decimal cjkg_c14 = 0;
            decimal cjkg_c15 = 0;

            decimal qqcb_c1 = 0;
            decimal qqcb_c2 = 0;
            decimal qqcb_c3 = 0;
            decimal qqcb_c4 = 0;
            decimal qqcb_c5 = 0;
            decimal qqcb_c6 = 0;
            decimal qqcb_c7 = 0;
            decimal qqcb_c8 = 0;
            decimal qqcb_c9 = 0;
            decimal qqcb_c10 = 0;
            decimal qqcb_c11 = 0;
            decimal qqcb_c12 = 0;
            decimal qqcb_c13 = 0;
            decimal qqcb_c14 = 0;
            decimal qqcb_c15 = 0;




            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "tcdc" && dt.Rows[i]["caddress"].ToString().Trim()==address)
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                      //  tcdc_plan += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        tcdc_total += ctype;
                    } 


                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        tcdc_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        tcdc_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        tcdc_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        tcdc_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        tcdc_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        tcdc_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        tcdc_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        tcdc_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        tcdc_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        tcdc_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        tcdc_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        tcdc_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        tcdc_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        tcdc_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        tcdc_c15 += ctype;
                    }

                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "jkjs" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype = 0;
                    //if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    //{
                    //    jkjs_c1 += ctype;
                    //}
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        jkjs_total += ctype;
                    }

                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        jkjs_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        jkjs_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        jkjs_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        jkjs_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        jkjs_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        jkjs_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        jkjs_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        jkjs_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        jkjs_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        jkjs_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        jkjs_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        jkjs_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        jkjs_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        jkjs_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        jkjs_c15 += ctype;
                    }

                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "qqcb" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        //qqcb_plan += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        qqcb_total += ctype;
                    }


                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        qqcb_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        qqcb_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        qqcb_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        qqcb_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        qqcb_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        qqcb_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        qqcb_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        qqcb_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        qqcb_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        qqcb_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        qqcb_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        qqcb_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        qqcb_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        qqcb_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        qqcb_c15 += ctype;
                    }
                }
                else if (dt.Rows[i]["ctype"].ToString().Trim() == "cjkg" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                       // cjkg_plan += ctype;

                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        cjkg_total += ctype;
                    }



                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype))
                    {
                        cjkg_c1 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype))
                    {
                        cjkg_c2 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype))
                    {
                        cjkg_c3 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype))
                    {
                        cjkg_c4 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype))
                    {
                        cjkg_c5 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype))
                    {
                        cjkg_c6 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype))
                    {
                        cjkg_c7 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype))
                    {
                        cjkg_c8 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype))
                    {
                        cjkg_c9 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype))
                    {
                        cjkg_c10 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c11"].ToString().Trim(), out ctype))
                    {
                        cjkg_c11 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c12"].ToString().Trim(), out ctype))
                    {
                        cjkg_c12 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c13"].ToString().Trim(), out ctype))
                    {
                        cjkg_c13 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c14"].ToString().Trim(), out ctype))
                    {
                        cjkg_c14 += ctype;
                    }
                    ctype = 0;
                    if (decimal.TryParse(dt.Rows[i]["c15"].ToString().Trim(), out ctype))
                    {
                        cjkg_c15 += ctype;
                    }


                }
            }
            dic.Add("tcdc_total", tcdc_total.ToString());
            dic.Add("jkjs_total", jkjs_total.ToString());
            dic.Add("qqcb_total", qqcb_total.ToString());
            dic.Add("cjkg_total", cjkg_total.ToString());

            //dic.Add("tcdc_plan", tcdc_plan.ToString());
            //dic.Add("jkjs_plan", jkjs_plan.ToString());
            //dic.Add("qqcb_plan", qqcb_plan.ToString());
            //dic.Add("cjkg_plan", cjkg_plan.ToString());

            dic.Add("tcdc_c1", tcdc_c1.ToString());
            dic.Add("tcdc_c2", tcdc_c2.ToString());
            dic.Add("tcdc_c3", tcdc_c3.ToString());
            dic.Add("tcdc_c4", tcdc_c4.ToString());
            dic.Add("tcdc_c5", tcdc_c5.ToString());
            dic.Add("tcdc_c6", tcdc_c6.ToString());
            dic.Add("tcdc_c7", tcdc_c7.ToString());
            dic.Add("tcdc_c8", tcdc_c8.ToString());
            dic.Add("tcdc_c9", tcdc_c9.ToString());
            dic.Add("tcdc_c10", tcdc_c10.ToString());
            dic.Add("tcdc_c11", tcdc_c11.ToString());
            dic.Add("tcdc_c12", tcdc_c12.ToString());
            dic.Add("tcdc_c13", tcdc_c13.ToString());
            dic.Add("tcdc_c14", tcdc_c14.ToString());
            dic.Add("tcdc_c15", tcdc_c15.ToString());

            dic.Add("jkjs_c1", jkjs_c1.ToString());
            dic.Add("jkjs_c2", jkjs_c2.ToString());
            dic.Add("jkjs_c3", jkjs_c3.ToString());
            dic.Add("jkjs_c4", jkjs_c4.ToString());
            dic.Add("jkjs_c5", jkjs_c5.ToString());
            dic.Add("jkjs_c6", jkjs_c6.ToString());
            dic.Add("jkjs_c7", jkjs_c7.ToString());
            dic.Add("jkjs_c8", jkjs_c8.ToString());
            dic.Add("jkjs_c9", jkjs_c9.ToString());
            dic.Add("jkjs_c10", jkjs_c10.ToString());
            dic.Add("jkjs_c11", jkjs_c11.ToString());
            dic.Add("jkjs_c12", jkjs_c12.ToString());
            dic.Add("jkjs_c13", jkjs_c13.ToString());
            dic.Add("jkjs_c14", jkjs_c14.ToString());
            dic.Add("jkjs_c15", jkjs_c15.ToString());

            dic.Add("qqcb_c1", qqcb_c1.ToString());
            dic.Add("qqcb_c2", qqcb_c2.ToString());
            dic.Add("qqcb_c3", qqcb_c3.ToString());
            dic.Add("qqcb_c4", qqcb_c4.ToString());
            dic.Add("qqcb_c5", qqcb_c5.ToString());
            dic.Add("qqcb_c6", qqcb_c6.ToString());
            dic.Add("qqcb_c7", qqcb_c7.ToString());
            dic.Add("qqcb_c8", qqcb_c8.ToString());
            dic.Add("qqcb_c9", qqcb_c9.ToString());
            dic.Add("qqcb_c10", qqcb_c10.ToString());
            dic.Add("qqcb_c11", qqcb_c11.ToString());
            dic.Add("qqcb_c12", qqcb_c12.ToString());
            dic.Add("qqcb_c13", qqcb_c13.ToString());
            dic.Add("qqcb_c14", qqcb_c14.ToString());
            dic.Add("qqcb_c15", qqcb_c15.ToString());

            dic.Add("cjkg_c1", cjkg_c1.ToString());
            dic.Add("cjkg_c2", cjkg_c2.ToString());
            dic.Add("cjkg_c3", cjkg_c3.ToString());
            dic.Add("cjkg_c4", cjkg_c4.ToString());
            dic.Add("cjkg_c5", cjkg_c5.ToString());
            dic.Add("cjkg_c6", cjkg_c6.ToString());
            dic.Add("cjkg_c7", cjkg_c7.ToString());
            dic.Add("cjkg_c8", cjkg_c8.ToString());
            dic.Add("cjkg_c9", cjkg_c9.ToString());

            dic.Add("cjkg_c10", cjkg_c10.ToString());
            dic.Add("cjkg_c11", cjkg_c11.ToString());
            dic.Add("cjkg_c12", cjkg_c12.ToString());
            dic.Add("cjkg_c13", cjkg_c13.ToString());
            dic.Add("cjkg_c14", cjkg_c14.ToString());
            dic.Add("cjkg_c15", cjkg_c15.ToString());


            return dic;

        }
        #endregion



        #region 景观农业项目 获得统计数据报告汇总

        public Dictionary<String, String> getjgMoneyAndCountByAddress(int year, int season, int audit, string address)
        {
            DataBase db = new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getjgMoneyAndCount_Admin(" + year + "," + season + "," + audit + ")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            decimal ycc1 = 0;//总投资
            decimal ycc2 = 0;//当年计划投资
            decimal ycc3 = 0;
            decimal ycc4 = 0;
            decimal ycc5 = 0;

            decimal zjc1 = 0;//总投资
            decimal zjc2 = 0;//当年计划投资
            decimal zjc3 = 0;
            decimal zjc4 = 0;
            decimal zjc5 = 0;

            decimal ghc1 = 0;//总投资
            decimal ghc2 = 0;//当年计划投资
            decimal ghc3 = 0;
            decimal ghc4 = 0;
            decimal ghc5 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "yc" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ycc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ycc2+= ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ycc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ycc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ycc5 += ctype5;
                    }

                }

                if (dt.Rows[i]["ctype"].ToString().Trim() == "zj" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        zjc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        zjc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        zjc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        zjc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        zjc5 += ctype5;
                    }

                }
                if (dt.Rows[i]["ctype"].ToString().Trim() == "gh" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ghc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ghc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ghc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ghc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ghc5 += ctype5;
                    }

                }
            }
            dic.Add("ycc1", ycc1+  "");
            dic.Add("ycc2", ycc2 + "");
            dic.Add("ycc3", ycc3 + "");
            dic.Add("ycc4", ycc4 + "");
            dic.Add("ycc5", ycc5 + "");

            dic.Add("zjc1", zjc1 + "");
            dic.Add("zjc2", zjc2 + "");
            dic.Add("zjc3", zjc3 + "");
            dic.Add("zjc4", zjc4 + "");
            dic.Add("zjc5", zjc5 + "");

            dic.Add("ghc1", ghc1 + "");
            dic.Add("ghc2", ghc2 + "");
            dic.Add("ghc3", ghc3 + "");
            dic.Add("ghc4", ghc4 + "");
            dic.Add("ghc5", ghc5 + "");



            return dic;
        }

        

        public Dictionary<String, String> getjgMoneyAndCount(int year, int season, int audit)
        {
            DataBase db = new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getjgMoneyAndCount_Admin(" + year + "," + season + "," + audit + ")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            decimal ycc1 = 0;//总投资
            decimal ycc2 = 0;//当年计划投资
            decimal ycc3 = 0;
            decimal ycc4 = 0;
            decimal ycc5 = 0;

            decimal zjc1 = 0;//总投资
            decimal zjc2 = 0;//当年计划投资
            decimal zjc3 = 0;
            decimal zjc4 = 0;
            decimal zjc5 = 0;

            decimal ghc1 = 0;//总投资
            decimal ghc2 = 0;//当年计划投资
            decimal ghc3 = 0;
            decimal ghc4 = 0;
            decimal ghc5 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "yc" )
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ycc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ycc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ycc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ycc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ycc5 += ctype5;
                    }

                }

                if (dt.Rows[i]["ctype"].ToString().Trim() == "zj" )
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        zjc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        zjc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        zjc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        zjc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        zjc5 += ctype5;
                    }

                }
                if (dt.Rows[i]["ctype"].ToString().Trim() == "gh" )
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ghc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ghc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ghc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ghc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ghc5 += ctype5;
                    }

                }
            }
            dic.Add("ycc1", ycc1 + "");
            dic.Add("ycc2", ycc2 + "");
            dic.Add("ycc3", ycc3 + "");
            dic.Add("ycc4", ycc4 + "");
            dic.Add("ycc5", ycc5 + "");

            dic.Add("zjc1", zjc1 + "");
            dic.Add("zjc2", zjc2 + "");
            dic.Add("zjc3", zjc3 + "");
            dic.Add("zjc4", zjc4 + "");
            dic.Add("zjc5", zjc5 + "");

            dic.Add("ghc1", ghc1 + "");
            dic.Add("ghc2", ghc2 + "");
            dic.Add("ghc3", ghc3 + "");
            dic.Add("ghc4", ghc4 + "");
            dic.Add("ghc5", ghc5 + "");
            return dic;
        }
        #endregion



        #region 百湖工程项目 获得统计数据报告汇总

        public Dictionary<String, String> getbhMoneyAndCountByAddress(int year, int season, int audit, string address)
        {
            DataBase db = new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getbhMoneyAndCount_Admin(" + year + "," + season + "," + audit + ")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            decimal ycc1 = 0;
            decimal ycc2 = 0;
            decimal ycc3 = 0;
            decimal ycc4 = 0;
            decimal ycc5 = 0;
            decimal ycc6 = 0;
            decimal ycc7 = 0;
            decimal ycc8 = 0;
            decimal ycc9 = 0;
            decimal ycc10 = 0;

            decimal zjc1 = 0;//总投资
            decimal zjc2 = 0;//当年计划投资
            decimal zjc3 = 0;
            decimal zjc4 = 0;
            decimal zjc5 = 0;
            decimal zjc6 = 0;
            decimal zjc7 = 0;
            decimal zjc8 = 0;
            decimal zjc9 = 0;
            decimal zjc10 = 0;


            decimal ghc1 = 0;//总投资
            decimal ghc2 = 0;//当年计划投资
            decimal ghc3 = 0;
            decimal ghc4 = 0;
            decimal ghc5 = 0;
            decimal ghc6 = 0;
            decimal ghc7 = 0;
            decimal ghc8 = 0;
            decimal ghc9 = 0;
            decimal ghc10 = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "yc" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ycc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ycc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ycc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ycc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ycc5 += ctype5;
                    }
                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        ycc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        ycc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        ycc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        ycc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        ycc10 += ctype10;
                    }

                }

                if (dt.Rows[i]["ctype"].ToString().Trim() == "zj" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        zjc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        zjc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        zjc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        zjc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        zjc5 += ctype5;
                    }

                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        zjc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        zjc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        zjc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        zjc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        zjc10 += ctype10;
                    }

                }
                if (dt.Rows[i]["ctype"].ToString().Trim() == "gh" && dt.Rows[i]["caddress"].ToString().Trim() == address)
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ghc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ghc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ghc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ghc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ghc5 += ctype5;
                    }

                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        ghc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        ghc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        ghc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        ghc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        ghc10 += ctype10;
                    }

                }
            }
            dic.Add("ycc1", ycc1 + "");
            dic.Add("ycc2", ycc2 + "");
            dic.Add("ycc3", ycc3 + "");
            dic.Add("ycc4", ycc4 + "");
            dic.Add("ycc5", ycc5 + "");
            dic.Add("ycc6", ycc6 + "");
            dic.Add("ycc7", ycc7 + "");
            dic.Add("ycc8", ycc8 + "");
            dic.Add("ycc9", ycc9 + "");
            dic.Add("ycc10", ycc10 + "");

            dic.Add("zjc1", zjc1 + "");
            dic.Add("zjc2", zjc2 + "");
            dic.Add("zjc3", zjc3 + "");
            dic.Add("zjc4", zjc4 + "");
            dic.Add("zjc5", zjc5 + "");
            dic.Add("zjc6", zjc6 + "");
            dic.Add("zjc7", zjc7 + "");
            dic.Add("zjc8", zjc8 + "");
            dic.Add("zjc9", zjc9 + "");
            dic.Add("zjc10", zjc10 + "");

            dic.Add("ghc1", ghc1 + "");
            dic.Add("ghc2", ghc2 + "");
            dic.Add("ghc3", ghc3 + "");
            dic.Add("ghc4", ghc4 + "");
            dic.Add("ghc5", ghc5 + "");
            dic.Add("ghc6", ghc6 + "");
            dic.Add("ghc7", ghc7 + "");
            dic.Add("ghc8", ghc8 + "");
            dic.Add("ghc9", ghc9 + "");
            dic.Add("ghc10", ghc10 + "");



            return dic;
        }



        public Dictionary<String, String> getbhMoneyAndCount(int year, int season, int audit)
        {
            DataBase db = new DataBase();
            DataTable dt = db.GetDataTable("select * from dbo.getbhMoneyAndCount_Admin(" + year + "," + season + "," + audit + ")");
            Dictionary<String, String> dic = new Dictionary<string, string>();
            decimal ycc1 = 0;
            decimal ycc2 = 0;
            decimal ycc3 = 0;
            decimal ycc4 = 0;
            decimal ycc5 = 0;
            decimal ycc6 = 0;
            decimal ycc7 = 0;
            decimal ycc8 = 0;
            decimal ycc9 = 0;
            decimal ycc10 = 0;

            decimal zjc1 = 0;//总投资
            decimal zjc2 = 0;//当年计划投资
            decimal zjc3 = 0;
            decimal zjc4 = 0;
            decimal zjc5 = 0;
            decimal zjc6 = 0;
            decimal zjc7 = 0;
            decimal zjc8 = 0;
            decimal zjc9 = 0;
            decimal zjc10 = 0;


            decimal ghc1 = 0;//总投资
            decimal ghc2 = 0;//当年计划投资
            decimal ghc3 = 0;
            decimal ghc4 = 0;
            decimal ghc5 = 0;
            decimal ghc6 = 0;
            decimal ghc7 = 0;
            decimal ghc8 = 0;
            decimal ghc9 = 0;
            decimal ghc10 = 0;

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["ctype"].ToString().Trim() == "yc" )
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ycc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ycc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ycc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ycc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ycc5 += ctype5;
                    }
                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        ycc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        ycc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        ycc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        ycc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        ycc10 += ctype10;
                    }

                }

                if (dt.Rows[i]["ctype"].ToString().Trim() == "zj")
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        zjc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        zjc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        zjc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        zjc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        zjc5 += ctype5;
                    }

                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        zjc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        zjc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        zjc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        zjc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        zjc10 += ctype10;
                    }

                }
                if (dt.Rows[i]["ctype"].ToString().Trim() == "gh" )
                {
                    decimal ctype1 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c1"].ToString().Trim(), out ctype1))
                    {
                        ghc1 += ctype1;
                    }
                    decimal ctype2 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c2"].ToString().Trim(), out ctype2))
                    {
                        ghc2 += ctype2;
                    }
                    decimal ctype3 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c3"].ToString().Trim(), out ctype3))
                    {
                        ghc3 += ctype3;
                    }
                    decimal ctype4 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c4"].ToString().Trim(), out ctype4))
                    {
                        ghc4 += ctype4;
                    }
                    decimal ctype5 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c5"].ToString().Trim(), out ctype5))
                    {
                        ghc5 += ctype5;
                    }

                    decimal ctype6 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c6"].ToString().Trim(), out ctype6))
                    {
                        ghc6 += ctype6;
                    }
                    decimal ctype7 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c7"].ToString().Trim(), out ctype7))
                    {
                        ghc7 += ctype7;
                    }
                    decimal ctype8 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c8"].ToString().Trim(), out ctype8))
                    {
                        ghc8 += ctype8;
                    }
                    decimal ctype9 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c9"].ToString().Trim(), out ctype9))
                    {
                        ghc9 += ctype9;
                    }
                    decimal ctype10 = 0;
                    if (decimal.TryParse(dt.Rows[i]["c10"].ToString().Trim(), out ctype10))
                    {
                        ghc10 += ctype10;
                    }

                }
            }
            dic.Add("ycc1", ycc1 + "");
            dic.Add("ycc2", ycc2 + "");
            dic.Add("ycc3", ycc3 + "");
            dic.Add("ycc4", ycc4 + "");
            dic.Add("ycc5", ycc5 + "");
            dic.Add("ycc6", ycc6 + "");
            dic.Add("ycc7", ycc7 + "");
            dic.Add("ycc8", ycc8 + "");
            dic.Add("ycc9", ycc9 + "");
            dic.Add("ycc10", ycc10 + "");

            dic.Add("zjc1", zjc1 + "");
            dic.Add("zjc2", zjc2 + "");
            dic.Add("zjc3", zjc3 + "");
            dic.Add("zjc4", zjc4 + "");
            dic.Add("zjc5", zjc5 + "");
            dic.Add("zjc6", zjc6 + "");
            dic.Add("zjc7", zjc7 + "");
            dic.Add("zjc8", zjc8 + "");
            dic.Add("zjc9", zjc9 + "");
            dic.Add("zjc10", zjc10 + "");

            dic.Add("ghc1", ghc1 + "");
            dic.Add("ghc2", ghc2 + "");
            dic.Add("ghc3", ghc3 + "");
            dic.Add("ghc4", ghc4 + "");
            dic.Add("ghc5", ghc5 + "");
            dic.Add("ghc6", ghc6 + "");
            dic.Add("ghc7", ghc7 + "");
            dic.Add("ghc8", ghc8 + "");
            dic.Add("ghc9", ghc9 + "");
            dic.Add("ghc10", ghc10 + "");
            return dic;
        }
        #endregion




        #region  制作生态旅游重大项目表格头
        public void drow_st_title()
        {
        }


        #endregion



    }
}
