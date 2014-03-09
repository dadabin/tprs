using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using System.Data;

public partial class Admin_excel_load : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            if (Request.QueryString["role"] != null)
            {
                Button3.Visible = false;
                if (!(Request.QueryString["role"].ToString().Trim() == "1" || Request.QueryString["role"].ToString().Trim() == "2"))
                {
                    Button1.Visible = false;
                    Button2.Visible = false;
                    DropDownList1.Visible = false;
                    Button3.CommandName = ((DataTable)Session["userEntity_logined"]).Rows[0]["area"].ToString().Trim();
                    Button3.Visible = true;
                    bindByAddress(((DataTable)Session["userEntity_logined"]).Rows[0]["area"].ToString().Trim(),1);
                }
                else
                {
                    bind();
                }
            }
          
        }
    }

    public void bind()
    {
        string fullTime = System.DateTime.Now.Year + "年" + System.DateTime.Now.Month + "月" + System.DateTime.Now.Day + "日";
        //===============设置时间===============
        DateTimeUtil dateTimeUtil=new DateTimeUtil();
        string proYear = dateTimeUtil.getPreYear().ToString();
        string nowYear = dateTimeUtil.getNowYear();
        string proMonth = dateTimeUtil.getPreMonth().ToString();
        string nowMonth = dateTimeUtil.getNowMonth();
        //======================绑定数据===============
        string itemtype = "";
        if (!(Request.QueryString["itemtype"] != null&&Request.QueryString["role"]!=null))
        {
            return;
        }
        itemtype = Request.QueryString["itemtype"].ToString().Trim();

        if (itemtype == "st")
        {
            if (!(Request.QueryString["month"] != null && Request.QueryString["month"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }



            int month =Convert.ToInt32( Request.QueryString["month"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());



            //=========得到汇总数据===========
            ExcelDown exceldown = new ExcelDown();
            Dictionary<String, String> admin_dic = exceldown.getstMoneyAndCount(year, month, 2);
            DataBase db = new DataBase();
            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'tcdc')");
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'jkjs')");
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'cjkg')");
            System.Data.DataTable dt8 = db.GetDataTable("select * from [dbo].getstReport(" + year + "," + month + ",'qqcb')");

            string monthStr = new ConstantChangeUtil().getBigNum(month);
         

            string stTableStr = ("");
            stTableStr += @"<table width='2500px' style='border-collapse:collapse;' >
    <tr>
        <td colspan='32' align='center' style='font-weight: bold; font-size: 20px;'>" + year + @"年龙泉山生态旅游功能区重大项目表</td>
    </tr>
    <tr>
         <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center' >填报单位（盖章）：</td>
         <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center' >填报人：</td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center' >审核人：</td>
        <td  colspan='5' style='font-weight: bold; font-size: 13px;' align='center'> 此表统计时间截止	" + fullTime + @"</td>
        <td  colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>1-" + month + @"月总完成额为" + (decimal.Parse(admin_dic["tcdc_c14"]) + decimal.Parse(admin_dic["jkjs_c14"]) + decimal.Parse(admin_dic["qqcb_c14"]) + decimal.Parse(admin_dic["cjkg_c14"])) + @"万元</td>
        <td  colspan='12' style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>所属区县</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>项目名称</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设年限</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设性质</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设内容及规模</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>总投资</td>
        <td align='center'colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>资金构成</td>              
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>截至" + (year -1)+ @"年底完成投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>" +year+@"年计划投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>目前为止项目形象进度</td>
        <td align='center' colspan='4' style='font-weight: bold; font-size: 13px;' align='center'>项目业主</td>             
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>计划开工时间</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>计划竣工时间</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>四个一批范畴</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>已取得土地指标（亩）</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>拟申请土地指标（亩）</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>是否政府投资项目</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>1-"+(month) +@"月完成投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>" + month + @"月完成的投资额</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>需协调解决问题</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>备注</td>
    </tr>
    <tr>
         <td style='font-weight: bold; font-size: 13px;' align='center'>中央资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>省级资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>市级资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>区县资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>银行贷款</td><td style='font-weight: bold; font-size: 13px;' align='center'>企业自筹</td>
         <td style='font-weight: bold; font-size: 13px;' align='center'>单位名称</td><td style='font-weight: bold; font-size: 13px;' align='center'>法人代表</td><td style='font-weight: bold; font-size: 13px;' align='center'>业主联系人</td><td style='font-weight: bold; font-size: 13px;' align='center'>联系电话</td>
    </tr>

";





            stTableStr += ("<tr><td>一、</td><td colspan='30'>" + "投产达产（项目共计：" + dt2.Rows.Count + "个；总投资：" + admin_dic["tcdc_all_total"] + "万元；" + year + "年计划投资：" + admin_dic["tcdc_c11"] + "万元。）" + "</td></tr>");
            //===============================投产达产=============
            
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i+1) + "</td>");
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt2.Rows[i][j].ToString() + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+dt2.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["tcdc_all_total"] + "</td><td>" + admin_dic["tcdc_c4"] + "</td><td>" + admin_dic["tcdc_c5"] + "</td><td>" + admin_dic["tcdc_c6"] + "</td><td>" + admin_dic["tcdc_c7"] + "</td><td>" + admin_dic["tcdc_c8"] + "</td><td>" + admin_dic["tcdc_c9"] + "</td><td>" + admin_dic["tcdc_c10"] + "</td><td>" + admin_dic["tcdc_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["tcdc_c12"] + "</td><td>" + admin_dic["tcdc_c13"] + "</td><td></td><td>" + admin_dic["tcdc_c14"] + "</td><td>" + admin_dic["tcdc_c15"] + "</td><td></td><td></td></tr>";
            //===============================加快建设=============


            stTableStr += ("<tr><td>二、</td><td colspan='30'>" + "加快建设（项目共计：" + dt4.Rows.Count + "个；总投资：" + admin_dic["jkjs_all_total"] + "万元；" + year + "年计划投资：" + admin_dic["jkjs_c11"] + "万元。）" + "</td></tr>");
           
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt4.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>" + dt4.Rows.Count + "</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["jkjs_all_total"] + "</td><td>" + admin_dic["jkjs_c4"] + "</td><td>" + admin_dic["jkjs_c5"] + "</td><td>" + admin_dic["jkjs_c6"] + "</td><td>" + admin_dic["jkjs_c7"] + "</td><td>" + admin_dic["jkjs_c8"] + "</td><td>" + admin_dic["jkjs_c9"] + "</td><td>" + admin_dic["jkjs_c10"] + "</td><td>" + admin_dic["jkjs_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["jkjs_c12"] + "</td><td>" + admin_dic["jkjs_c13"] + "</td><td></td><td>" + admin_dic["jkjs_c14"] + "</td><td>" + admin_dic["jkjs_c15"] + "</td><td></td><td></td></tr>";
            //===============================促进开工=============


            stTableStr += ("<tr><td>三、</td><td colspan='30'>" + "促进开工（项目共计：" + dt6.Rows.Count + "个；总投资：" + admin_dic["cjkg_all_total"] + "万元；" + year + "年计划投资：" + admin_dic["cjkg_c11"] + "万元。）" + "</td></tr>");
            
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt6.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+dt6.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["cjkg_all_total"] + "</td><td>" + admin_dic["cjkg_c4"] + "</td><td>" + admin_dic["cjkg_c5"] + "</td><td>" + admin_dic["cjkg_c6"] + "</td><td>" + admin_dic["cjkg_c7"] + "</td><td>" + admin_dic["cjkg_c8"] + "</td><td>" + admin_dic["cjkg_c9"] + "</td><td>" + admin_dic["cjkg_c10"] + "</td><td>" + admin_dic["cjkg_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>"+admin_dic["cjkg_c12"]+"</td><td>"+admin_dic["cjkg_c13"]+"</td><td></td><td>"+admin_dic["cjkg_c14"]+"</td><td>"+admin_dic["cjkg_c15"]+"</td><td></td><td></td></tr>";
            //===============================前期储备============


            stTableStr += ("<tr><td>四、</td><td colspan='30'>" + "前期储备（项目共计：" + dt8.Rows.Count + "个；总投资：" + admin_dic["qqcb_all_total"] + "万元；" + year + "年计划投资：" + admin_dic["qqcb_c11"] + "万元。）" + "</td></tr>");
            
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt8.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt8.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+(dt8.Rows.Count)+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + admin_dic["qqcb_all_total"] + "</td><td>" + admin_dic["qqcb_c4"] + "</td><td>" + admin_dic["qqcb_c5"] + "</td><td>" + admin_dic["qqcb_c6"] + "</td><td>" + admin_dic["qqcb_c7"] + "</td><td>" + admin_dic["qqcb_c8"] + "</td><td>" + admin_dic["qqcb_c9"] + "</td><td>" + admin_dic["qqcb_c10"] + "</td><td>" + admin_dic["qqcb_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>"+admin_dic["qqcb_c12"]+"</td><td>"+admin_dic["qqcb_c13"]+"</td><td></td><td>"+admin_dic["qqcb_c14"]+"</td><td>"+admin_dic["qqcb_c15"]+"</td><td></td><td></td></tr>";

            stTableStr += "<tr><td>" + (dt2.Rows.Count + dt4.Rows.Count + dt6.Rows.Count + dt8.Rows.Count) + "</td><td>总合计</td><td></td><td></td><td></td><td></td><td></td><td>" + 
                (decimal.Parse(admin_dic["qqcb_all_total"])+decimal.Parse(admin_dic["cjkg_all_total"])+decimal.Parse(admin_dic["jkjs_all_total"])+decimal.Parse(admin_dic["tcdc_all_total"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c4"])+decimal.Parse(admin_dic["cjkg_c4"])+decimal.Parse(admin_dic["jkjs_c4"])+decimal.Parse(admin_dic["tcdc_c4"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c5"])+decimal.Parse(admin_dic["cjkg_c5"])+decimal.Parse(admin_dic["jkjs_c5"])+decimal.Parse(admin_dic["tcdc_c5"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c6"])+decimal.Parse(admin_dic["cjkg_c6"])+decimal.Parse(admin_dic["jkjs_c6"])+decimal.Parse(admin_dic["tcdc_c6"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c7"])+decimal.Parse(admin_dic["cjkg_c7"])+decimal.Parse(admin_dic["jkjs_c7"])+decimal.Parse(admin_dic["tcdc_c7"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c8"])+decimal.Parse(admin_dic["cjkg_c8"])+decimal.Parse(admin_dic["jkjs_c8"])+decimal.Parse(admin_dic["tcdc_c8"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c9"])+decimal.Parse(admin_dic["cjkg_c9"])+decimal.Parse(admin_dic["jkjs_c9"])+decimal.Parse(admin_dic["tcdc_c9"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c10"])+decimal.Parse(admin_dic["cjkg_c10"])+decimal.Parse(admin_dic["jkjs_c10"])+decimal.Parse(admin_dic["tcdc_c10"])) + "</td><td>" +
                (decimal.Parse(admin_dic["qqcb_c11"]) + decimal.Parse(admin_dic["cjkg_c11"]) + decimal.Parse(admin_dic["jkjs_c11"]) + decimal.Parse(admin_dic["tcdc_c11"])) + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" +
                (decimal.Parse(admin_dic["qqcb_c12"])+decimal.Parse(admin_dic["cjkg_c12"])+decimal.Parse(admin_dic["jkjs_c12"])+decimal.Parse(admin_dic["tcdc_c12"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c13"])+decimal.Parse(admin_dic["cjkg_c13"])+decimal.Parse(admin_dic["jkjs_c13"])+decimal.Parse(admin_dic["tcdc_c13"])) + "</td><td></td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c14"])+decimal.Parse(admin_dic["cjkg_c14"])+decimal.Parse(admin_dic["jkjs_c14"])+decimal.Parse(admin_dic["tcdc_c14"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["qqcb_c15"])+decimal.Parse(admin_dic["cjkg_c15"])+decimal.Parse(admin_dic["jkjs_c15"])+decimal.Parse(admin_dic["tcdc_c15"])) + "</td><td></td><td></td></tr>";
            stTableStr += ("<table>");
          //  Response.Write(stTableStr);
            Label1.Text = stTableStr;
        }
        //================================================百湖季度报告======================================
        else if (itemtype == "bh")
        {
            if (!(Request.QueryString["season"] != null && Request.QueryString["season"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }
            int season = Convert.ToInt32(Request.QueryString["season"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());
            string seasonStr = new ConstantChangeUtil().getBigNum(season);

            ExcelDown exceldown = new ExcelDown();
            Dictionary<String, String> admin_dic = exceldown.getbhMoneyAndCount(year, season, 2);



            DataBase db = new DataBase();

            string bhTableStr = @"<table style='border-collapse:collapse;'>
    <tr>
        <td colspan='19' align='center' style='font-weight: bold; font-size: 20px;'>" + year + "年龙泉山生态旅游综合功能区“百湖”工程（" + seasonStr + @"）季度情况统计表</td>
    </tr>
    <tr>
         <td colspan='4' style='font-weight: bold; font-size: 13px;' align='center'>填报单位（盖章）： </td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报人： </td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>审核人： </td>
        <td colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>填报时间：	" + fullTime + @"</td>
        <td colspan='3'style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>所属区县</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>工程名称</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>完工时间</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>水域面积</td>
        <td  colspan='8' style='font-weight: bold; font-size: 13px;' align='center'>" + seasonStr + @"季度工程已完成投资(不含建设用地和移民)</td>
        <td   style='font-weight: bold; font-size: 13px;' align='center'>建设用地</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>占用方式(流转、征用等)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>单价(元/亩•年)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>目前工程形象进度 （涉旅项目)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>管护主体</td>
    </tr>
    <tr>
        <td style='font-weight: bold; font-size: 13px;' align='center'>小计（万元）</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>省级以上财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>市级财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>县级财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>财政融资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>社会投入</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>群众投入</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>其它</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>占用土地面积(亩)</td>
    </tr>
";
            //=========================已成===============
            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'yc')");
            bhTableStr += "<tr><td>" + "一、" + "</td><td colspan='18'  >  " + "已成</td></tr>";
           
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>"+(i+1)+"</td>";
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt2.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt2.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td>" + admin_dic["ycc1"] + "</td><td>" + admin_dic["ycc10"] + "</td><td>" + admin_dic["ycc2"] + "</td><td>" + admin_dic["ycc3"] + "</td><td>" + admin_dic["ycc4"] + "</td><td>" + admin_dic["ycc5"] + "</td><td>" + admin_dic["ycc6"] + "</td><td>" + admin_dic["ycc7"] + "</td><td>" + admin_dic["ycc8"] + "</td><td>" + admin_dic["ycc9"] + "</td><td></td><td></td><td></td><td></td></tr>";
            //===========================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'zj')");

            bhTableStr += "<tr><td>" + "二、" + "</td><td colspan='18' >" + "在建" + "</td></tr>";
           
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt4.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt4.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td>" + admin_dic["zjc1"] + "</td><td>" + admin_dic["zjc10"] + "</td><td>" + admin_dic["zjc2"] + "</td><td>" + admin_dic["zjc3"] + "</td><td>" + admin_dic["zjc4"] + "</td><td>" + admin_dic["zjc5"] + "</td><td>" + admin_dic["zjc6"] + "</td><td>" + admin_dic["zjc7"] + "</td><td>" + admin_dic["zjc8"] + "</td><td>" + admin_dic["zjc9"] + "</td><td></td><td></td><td></td><td></td></tr>";
            //===============================规划=============
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itembhReTotal(" + year + "," + season + ",'gh')");
            bhTableStr += "<tr><td>三、</td><td colspan='18' >" + "规划" + "</td></tr>";
           
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt6.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt6.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td>" + admin_dic["ghc1"] + "</td><td>" + admin_dic["ghc10"] + "</td><td>" + admin_dic["ghc2"] + "</td><td>" + admin_dic["ghc3"] + "</td><td>" + admin_dic["ghc4"] + "</td><td>" + admin_dic["ghc5"] + "</td><td>" + admin_dic["ghc6"] + "</td><td>" + admin_dic["ghc7"] + "</td><td>" + admin_dic["ghc8"] + "</td><td>" + admin_dic["ghc9"] + "</td><td></td><td></td><td></td><td></td></tr>";

            bhTableStr += "<tr><td>"+(dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count)+"</td><td>合计</td><td></td><td></td><td></td><td>" + 
                (decimal.Parse(admin_dic["ghc1"])+decimal.Parse(admin_dic["ycc1"])+decimal.Parse(admin_dic["zjc1"])) + "</td><td>" + (decimal.Parse(admin_dic["ghc10"])+decimal.Parse(admin_dic["ycc10"])+decimal.Parse(admin_dic["zjc10"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc2"])+decimal.Parse(admin_dic["ycc2"])+decimal.Parse(admin_dic["zjc2"])) + "</td><td>" + (decimal.Parse(admin_dic["ghc3"])+decimal.Parse(admin_dic["ycc3"])+decimal.Parse(admin_dic["zjc3"])) + "</td><td>" +( decimal.Parse(admin_dic["ghc4"])+decimal.Parse(admin_dic["ycc4"])+decimal.Parse(admin_dic["zjc4"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc5"])+decimal.Parse(admin_dic["ycc5"])+decimal.Parse(admin_dic["zjc5"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc6"])+decimal.Parse(admin_dic["ycc6"])+decimal.Parse(admin_dic["zjc6"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc7"])+decimal.Parse(admin_dic["ycc7"])+decimal.Parse(admin_dic["zjc7"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc8"])+decimal.Parse(admin_dic["ycc8"])+decimal.Parse(admin_dic["zjc8"])) + "</td><td>" + 
                (decimal.Parse(admin_dic["ghc9"])+decimal.Parse(admin_dic["ycc9"])+decimal.Parse(admin_dic["zjc9"])) + "</td><td></td><td></td><td></td><td></td></tr>";
            

            bhTableStr += "</table>";
           // Response.Write(bhTableStr);
            Label1.Text = bhTableStr;
        }

        //=============================================景观农业季度报告=================================
        else if (itemtype == "jg")
        {
            if (!(Request.QueryString["season"] != null && Request.QueryString["season"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }
            int season = Convert.ToInt32(Request.QueryString["season"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());
            ExcelDown exceldown = new ExcelDown();
            string seasonStr = new ConstantChangeUtil().getBigNum(season);
            Dictionary<String, String> admin_dic = exceldown.getjgMoneyAndCount(year, season, 2);//admin查看表示2


            string jgTableStr = @"<table style='border-collapse:collapse;'>
     <tr>
        <td colspan='14' align='center' style='font-weight: bold; font-size: 20px;'>" + year + "年龙泉山生态旅游综合功能区景观农业项目(" + seasonStr + @")季度推进情况统计表</td>
    </tr>
    <tr>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报单位（盖章）：</td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报人：</td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>审核人：</td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'> 填报时间：	" + fullTime + @"</td>
        <td colspan='2'style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>县（区、市)</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目名称</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>建设起止年限</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目建设规模</td>
        <td  colspan='3'  style='font-weight: bold; font-size: 13px;' align='center'>目标计划</td>
        <td  colspan='4'  style='font-weight: bold; font-size: 13px;' align='center'>完成情况</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目业主</td>
    </tr>
    <tr>
        <td style='font-weight: bold; font-size: 13px;' align='center'>计划总投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>" + year  +@"年计划投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>"+year +@"年底工程应达形象进度</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>至"+(year-1) +@"年已累计完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>" + year + @"年" + season+ @"季完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>" + year + "年1-" + season  + @"季完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>目前形象进度</td>
    </tr>
";
            //=========================已成===============
            DataBase db = new DataBase();

            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'yc')");

            jgTableStr += "<tr><td>一、</td><td colspan='13'  >  " + "已成" + "</td></tr>";
            
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt2.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt2.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + admin_dic["ycc1"] + "</td><td>" + admin_dic["ycc2"] + "</td><td></td><td>" + admin_dic["ycc3"] + "</td><td>" + admin_dic["ycc4"] + "</td><td>" + admin_dic["ycc5"] + "</td><td></td><td></td></tr>";
            //===========================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'zj')");
            jgTableStr += "<tr><td>二、</td><td colspan='13' >" + "在建" + "</td></tr>";
            

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt4.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt4.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + admin_dic["zjc1"] + "</td><td>" + admin_dic["zjc2"] + "</td><td></td><td>" + admin_dic["zjc3"] + "</td><td>" + admin_dic["zjc4"] + "</td><td>" + admin_dic["zjc5"] + "</td><td></td><td></td></tr>";
            //===============================规划=============
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itemjgReTotal(" + year + "," + season + ",'gh')");
            jgTableStr += "<tr><td>三、</td><td colspan='13' >" + "规划" + "</td></tr>";
            
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
               jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt6.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt6.Rows.Count +"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + admin_dic["ghc1"] + "</td><td>" + admin_dic["ghc2"] + "</td><td></td><td>" + admin_dic["ghc3"] + "</td><td>" + admin_dic["ghc4"] + "</td><td>" + admin_dic["ghc5"] + "</td><td></td><td></td></tr>";

            jgTableStr += "<tr><td>"+(dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count)+"</td><td>合计</td><td></td><td></td><td></td><td></td><td>" +
            (decimal.Parse(admin_dic["ghc1"])+decimal.Parse(admin_dic["ycc1"])+decimal.Parse(admin_dic["zjc1"]))+ "</td><td>" +
            (decimal.Parse(admin_dic["ghc2"]) + decimal.Parse(admin_dic["ycc2"]) + decimal.Parse(admin_dic["zjc2"])) + "</td><td></td><td>" +
            (decimal.Parse(admin_dic["ghc3"]) + decimal.Parse(admin_dic["ycc3"]) + decimal.Parse(admin_dic["zjc3"])) + "</td><td>" + 
            (decimal.Parse(admin_dic["ghc4"])+decimal.Parse(admin_dic["ycc4"])+decimal.Parse(admin_dic["zjc4"])) + "</td><td>" + 
            (decimal.Parse(admin_dic["ghc5"])+decimal.Parse(admin_dic["ycc5"])+decimal.Parse(admin_dic["zjc5"])) + "</td><td></td><td></td></tr>";

            jgTableStr += "</table>";
            //Response.Write(jgTableStr);
            Label1.Text = jgTableStr;
        }
    }
    /// <summary>
    /// 导出Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        ExcelDown excelDown = new ExcelDown();
        string itemtype=Request.QueryString["itemtype"].ToString().Trim();
        if (itemtype == "st")
        {
            excelDown.downstExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["month"]));
            //Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode("Excel导出联系", System.Text.Encoding.UTF8) + ".xls\""); //添加excel的头
            //Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置字符集
            //Response.ContentType = "application/ms-excel";//输出类型为excel

            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //Response.Write(Label1.Text.ToString());
        }
        else if (itemtype == "bh")
        {
            excelDown.downbhExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["season"]));
        }
        else if (itemtype == "jg")
        {
            excelDown.downjgExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["season"]));
        }
    }
    /// <summary>
    /// 点击查看
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        String itemtype=DropDownList1.SelectedValue.ToString().Trim();
        if (itemtype == "0")
        {
            bind();
        }
        else if (itemtype == "lqy")
        {
            bindByAddress("lqy",2);
        }
        else if (itemtype == "sl")
        {
            bindByAddress("sl",2);
        }
        else if (itemtype == "jt")
        {
            bindByAddress("jt",2);
        }
        else if (itemtype == "qbj")
        {
            bindByAddress("qbj",2);
        }
        else if (itemtype == "xj")
        {
            bindByAddress("xj",2);
        }
    }
    //==================================================================根据地区得到Excel==================================

    /// <summary>
    /// 
    /// </summary>
    /// <param name="address"></param>
    /// <param name="audit"></param>
    public void bindByAddress(string address,int audit)
    {
        string addressName = "";
        if (address == "lqy")
        {
            addressName = "龙泉驿区";
        }
        else if (address == "sl")
        {
            addressName = "双流县";
        }
        else if (address == "jt")
        {
            addressName = "金堂县";
        }
        else if (address == "qbj")
        {
            addressName = "青白江区";
        }
        else if (address == "xj")
        {
            addressName = "新津县";
        }
        string fullTime = System.DateTime.Now.Year+"年"+System.DateTime.Now.Month+"月"+System.DateTime.Now.Day+"日";



        //===============设置时间===============
        DateTimeUtil dateTimeUtil = new DateTimeUtil();
        string proYear = dateTimeUtil.getPreYear().ToString();
        string nowYear = dateTimeUtil.getNowYear();
        string proMonth = dateTimeUtil.getPreMonth().ToString();
        string nowMonth = dateTimeUtil.getNowMonth();
        //================统计综合数据==================
        string itemtype = "";
        if (!(Request.QueryString["itemtype"] != null && Request.QueryString["role"] != null))
        {
            return;
        }
        itemtype = Request.QueryString["itemtype"].ToString().Trim();

        if (itemtype == "st")
        {
            if (!(Request.QueryString["month"] != null && Request.QueryString["month"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }

            int month =Convert.ToInt32( Request.QueryString["month"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());

            ExcelDown exceldown = new ExcelDown();
            DataBase db = new DataBase();

            Dictionary<String, String> dic = exceldown.getstMoneyAndCountByAddress(year, month, audit, address);

            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'tcdc','" + address + "'," + audit + ")");
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'jkjs','" + address + "'," + audit + ")");
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'cjkg','" + address + "'," + audit + ")");
            System.Data.DataTable dt8 = db.GetDataTable("select * from [dbo].getstReportByAddress(" + year + "," + month + ",'qqcb','" + address + "'," + audit + ")");

            string monthStr = new ConstantChangeUtil().getBigNum(month);
           
            
            string stTableStr = ("");
            stTableStr += @"<table width='2500px' style='border-collapse:collapse;' >
    <tr>
        <td colspan='32' align='center' style='font-weight: bold; font-size: 20px;'>" + year + @"年龙泉山生态旅游功能区重大项目表</td>
    </tr>
    <tr>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报单位（盖章）：</td>
      <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报人：</td>
      <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>审核人：</td>
        <td  colspan='5' style='font-weight: bold; font-size: 13px;' align='center'>此表统计时间截止 " + fullTime + @"	</td>
        <td  colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>1-" + month + @"月总完成额为" + (decimal.Parse(dic["tcdc_c14"]) + decimal.Parse(dic["jkjs_c14"]) + decimal.Parse(dic["qqcb_c14"]) + decimal.Parse(dic["cjkg_c14"])) + @"万元  </td>
        <td  colspan='12' style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>所属区县</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>项目名称</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设年限</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设性质</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设内容及规模</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>总投资</td>
        <td align='center'colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>资金构成</td>              
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>截至" +(year-1) +@"年底完成投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>"+year+@"年计划投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>目前为止项目形象进度</td>
        <td align='center' colspan='4' style='font-weight: bold; font-size: 13px;' align='center'>项目业主</td>             
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>计划开工时间</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>计划竣工时间</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>四个一批范畴</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>已取得土地指标（亩）</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>拟申请土地指标（亩）</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>是否政府投资项目</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>1-"+month +@"月完成投资</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>"+month +@"月完成的投资额</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>需协调解决问题</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>备注</td>
    </tr>
    <tr>
         <td style='font-weight: bold; font-size: 13px;' align='center'>中央资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>省级资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>市级资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>区县资金</td><td style='font-weight: bold; font-size: 13px;' align='center'>银行贷款</td><td style='font-weight: bold; font-size: 13px;' align='center'>企业自筹</td>
         <td style='font-weight: bold; font-size: 13px;' align='center'>单位名称</td><td style='font-weight: bold; font-size: 13px;' align='center'>法人代表</td><td style='font-weight: bold; font-size: 13px;' align='center'>业主联系人</td><td style='font-weight: bold; font-size: 13px;' align='center'>联系电话</td>
    </tr>

";
            stTableStr += ("<tr><td>一、</td><td colspan='30'>" + "投产达产（项目共计：" + dt2.Rows.Count + "个；总投资：" + dic["tcdc_total"] + "万元；" + year + "年计划投资：" + dic["tcdc_c11"] + "万元。）" + "</td></tr>");
            //===============================投产达产=============
           
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt2.Rows[i][j].ToString() + "</td>");
                }
                stTableStr += ("</tr>");
            }

            stTableStr += "<tr><td>"+dt2.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + dic["tcdc_total"] + "</td><td>" + dic["tcdc_c4"] + "</td><td>" + dic["tcdc_c5"] + "</td><td>" + dic["tcdc_c6"] + "</td><td>" + dic["tcdc_c7"] + "</td><td>" + dic["tcdc_c8"] + "</td><td>" + dic["tcdc_c9"] + "</td><td>" + dic["tcdc_c10"] + "</td><td>" + dic["tcdc_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + dic["tcdc_c12"] + "</td><td>" + dic["tcdc_c13"] + "</td><td></td><td>" + dic["tcdc_c14"] + "</td><td>" + dic["tcdc_c15"] + "</td><td></td><td></td></tr>";
            //===============================加快建设=============

            stTableStr += ("<tr><td>二、</td><td colspan='30'>" + "加快建设（项目共计：" + dt4.Rows.Count + "个；总投资：" + dic["jkjs_total"] + "万元；" + year + "年计划投资：" + dic["jkjs_c11"] + "万元。）" + "</td></tr>");
            
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt4.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+dt4.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + dic["jkjs_total"] + "</td><td>" + dic["jkjs_c4"] + "</td><td>" + dic["jkjs_c5"] + "</td><td>" + dic["jkjs_c6"] + "</td><td>" + dic["jkjs_c7"] + "</td><td>" + dic["jkjs_c8"] + "</td><td>" + dic["jkjs_c9"] + "</td><td>" + dic["jkjs_c10"] + "</td><td>" + dic["jkjs_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + dic["jkjs_c12"] + "</td><td>" + dic["jkjs_c13"] + "</td><td></td><td>" + dic["jkjs_c14"] + "</td><td>" + dic["jkjs_c15"] + "</td><td></td><td></td></tr>";
            //===============================促进开工=============

            stTableStr += ("<tr><td>三、</td><td colspan='30'>" + "促进开工（项目共计：" + dt6.Rows.Count + "个；总投资：" + dic["cjkg_total"] + "万元；" + year + "年计划投资：" + dic["cjkg_c11"] + "万元。）" + "</td></tr>");
           
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt6.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+dt6.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + dic["cjkg_total"] + "</td><td>" + dic["cjkg_c4"] + "</td><td>" + dic["cjkg_c5"] + "</td><td>" + dic["cjkg_c6"] + "</td><td>" + dic["cjkg_c7"] + "</td><td>" + dic["cjkg_c8"] + "</td><td>" + dic["cjkg_c9"] + "</td><td>" + dic["cjkg_c10"] + "</td><td>" + dic["cjkg_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" + dic["cjkg_c12"] + "</td><td>" + dic["cjkg_c13"] + "</td><td></td><td>" + dic["cjkg_c14"] + "</td><td>" + dic["cjkg_c15"] + "</td><td></td><td></td></tr>";
            //===============================前期储备============

            stTableStr += ("<tr><td>四、</td><td colspan='30'>" + "前期储备（项目共计：" + dt8.Rows.Count + "个；总投资：" + dic["qqcb_total"] + "万元；" + year + "年计划投资：" + dic["qqcb_c11"] + "万元。）" + "</td></tr>");

           
            for (int i = 0; i < dt8.Rows.Count; i++)
            {
                stTableStr += ("<tr>");
                stTableStr += ("<td>" + (i + 1) + "</td>");
                for (int j = 0; j < dt8.Columns.Count; j++)
                {
                    stTableStr += ("<td>" + dt8.Rows[i][j].ToString() + " " + "</td>");
                }
                stTableStr += ("</tr>");
            }
            stTableStr += "<tr><td>"+dt8.Rows.Count+"</td><td>合计</td><td></td><td></td><td></td><td></td><td></td><td>" + dic["qqcb_total"] + "</td><td>" + dic["qqcb_c4"] + "</td><td>" + dic["qqcb_c5"] + "</td><td>" + dic["qqcb_c6"] + "</td><td>" + dic["qqcb_c7"] + "</td><td>" + dic["qqcb_c8"] + "</td><td>" + dic["qqcb_c9"] + "</td><td>" + dic["qqcb_c10"] + "</td><td>" + dic["qqcb_c11"] + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>"+dic["qqcb_c12"]+"</td><td>"+dic["qqcb_c13"]+"</td><td></td><td>"+dic["qqcb_c14"]+"</td><td>"+dic["qqcb_c15"]+"</td><td></td><td></td></tr>";

            stTableStr += "<tr><td>"+(dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count+dt8.Rows.Count )+"</td><td>总合计</td><td></td><td></td><td></td><td></td><td></td><td>" + 
                (decimal.Parse(dic["qqcb_total"])+decimal.Parse(dic["jkjs_total"])+decimal.Parse(dic["cjkg_total"])+decimal.Parse(dic["tcdc_total"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c4"]) + decimal.Parse(dic["jkjs_c4"]) + decimal.Parse(dic["cjkg_c4"]) + decimal.Parse(dic["tcdc_c4"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c5"]) + decimal.Parse(dic["jkjs_c5"]) + decimal.Parse(dic["cjkg_c5"]) + decimal.Parse(dic["tcdc_c5"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c6"]) + decimal.Parse(dic["jkjs_c6"]) + decimal.Parse(dic["cjkg_c6"]) + decimal.Parse(dic["tcdc_c6"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c7"]) + decimal.Parse(dic["jkjs_c7"]) + decimal.Parse(dic["cjkg_c7"]) + decimal.Parse(dic["tcdc_c7"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c8"]) + decimal.Parse(dic["jkjs_c8"]) + decimal.Parse(dic["cjkg_c8"]) + decimal.Parse(dic["tcdc_c8"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c9"]) + decimal.Parse(dic["jkjs_c9"]) + decimal.Parse(dic["cjkg_c9"]) + decimal.Parse(dic["tcdc_c9"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c10"]) + decimal.Parse(dic["jkjs_c10"]) + decimal.Parse(dic["cjkg_c10"]) + decimal.Parse(dic["tcdc_c10"])) + "</td><td>" +
                (decimal.Parse(dic["qqcb_c11"]) + decimal.Parse(dic["jkjs_c11"]) + decimal.Parse(dic["cjkg_c11"]) + decimal.Parse(dic["tcdc_c11"])) + "</td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td></td><td>" +
                (decimal.Parse(dic["qqcb_c12"])+decimal.Parse(dic["jkjs_c12"])+decimal.Parse(dic["cjkg_c12"])+decimal.Parse(dic["tcdc_c12"]))+"</td><td>"+
                (decimal.Parse(dic["qqcb_c13"])+decimal.Parse(dic["jkjs_c13"])+decimal.Parse(dic["cjkg_c13"])+decimal.Parse(dic["tcdc_c13"]))+"</td><td></td><td>"+
                (decimal.Parse(dic["qqcb_c14"])+decimal.Parse(dic["jkjs_c14"])+decimal.Parse(dic["cjkg_c14"])+decimal.Parse(dic["tcdc_c14"]))+"</td><td>"+
                (decimal.Parse(dic["qqcb_c15"])+decimal.Parse(dic["jkjs_c15"])+decimal.Parse(dic["cjkg_c15"])+decimal.Parse(dic["tcdc_c15"]))+"</td><td></td><td></td></tr>";

            stTableStr += ("<table>");
            //  Response.Write(stTableStr);
            Label1.Text = stTableStr;
        }
        //================================================百湖季度报告======================================
        else if (itemtype == "bh")
        {

            if (!(Request.QueryString["season"] != null && Request.QueryString["season"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }


            int season = Convert.ToInt32(Request.QueryString["season"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());


             ExcelDown exceldown = new ExcelDown();
            Dictionary<String, String> dic = exceldown.getbhMoneyAndCountByAddress(year, season, audit, address);

            string seasonStr = new ConstantChangeUtil().getBigNum(season);
            DataBase db = new DataBase();

            string bhTableStr = @"<table style='border-collapse:collapse;'>
    <tr>
        <td colspan='19' align='center' style='font-weight: bold; font-size: 20px;'>"+year+"年龙泉山生态旅游综合功能区“百湖”工程（"+seasonStr+ @"）季度情况统计表</td>
    </tr>
    <tr>
         <td colspan='4' style='font-weight: bold; font-size: 13px;' align='center'>填报单位（盖章）：</td>
 <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报人：</td>
 <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>审核人：</td>
        <td colspan='6' style='font-weight: bold; font-size: 13px;' align='center'>	填报时间：" + fullTime + @"	</td>
        <td colspan='9'style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>所属区县</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>工程名称</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>完工时间</td>
        <td  rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>水域面积</td>
        <td  colspan='8' style='font-weight: bold; font-size: 13px;' align='center'>" + seasonStr + @"季度工程已完成投资(不含建设用地和移民)</td>
        <td clospan='3' style='font-weight: bold; font-size: 13px;' align='center'>建设用地</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>占用方式(流转、征用等)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>单价(元/亩•年)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>目前工程形象进度 （涉旅项目)</td>
        <td rowspan='2' style='font-weight: bold; font-size: 13px;' align='center'>管护主体</td>
    </tr>
    <tr>
        <td style='font-weight: bold; font-size: 13px;' align='center'>小计（万元）</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>省级以上财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>市级财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>县级财政</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>财政融资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>社会投入</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>群众投入</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>其它</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>占用土地面积(亩)</td>
    </tr>
";
            //=========================已成===============

            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'yc','" + address + "'," + audit + ")");
            bhTableStr += "<tr><td>一、</td><td colspan='18'  >  " + "已成" + "</td></tr>";
          
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt2.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt2.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td>" + dic["ycc1"] + "</td><td>" + dic["ycc10"] + "</td><td>" + dic["ycc2"] + "</td><td>" + dic["ycc3"] + "</td><td>" + dic["ycc4"] + "</td><td>" + dic["ycc5"] + "</td><td>" + dic["ycc6"] + "</td><td>" + dic["ycc7"] + "</td><td>" + dic["ycc8"] + "</td><td>" + dic["ycc9"] + "</td><td></td><td></td><td></td><td></td></tr>";
            //===========================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'zj','" + address + "'," + audit + ")");
            bhTableStr += "<tr><td>二、</td><td colspan='18' >" + "在建" + "</td></tr>";
           
            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt4.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt4.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td>" + dic["zjc1"] + "</td><td>" + dic["zjc10"] + "</td><td>" + dic["zjc2"] + "</td><td>" + dic["zjc3"] + "</td><td>" + dic["zjc4"] + "</td><td>" + dic["zjc5"] + "</td><td>" + dic["zjc6"] + "</td><td>" + dic["zjc7"] + "</td><td>" + dic["zjc8"] + "</td><td>" + dic["zjc9"] + "</td><td></td><td></td><td></td><td></td></tr>";
            //===============================规划=============
            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itembhReByAddress(" + year + "," + season + ",'gh','" + address + "'," + audit + ")");
            bhTableStr += "<tr><td>三、</td><td colspan='18' >" + "规划" + "</td></tr>";
            
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                bhTableStr += "<tr>";
                bhTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    bhTableStr += "<td>" + dt6.Rows[i][j].ToString() + " " + "</td>";
                }
                bhTableStr += "</tr>";
            }
            bhTableStr += "<tr><td>"+dt6.Rows.Count  +"</td><td>小计</td><td></td><td></td><td></td><td>" + dic["ghc1"] + "</td><td>" + dic["ghc10"] + "</td><td>" + dic["ghc2"] + "</td><td>" + dic["ghc3"] + "</td><td>" + dic["ghc4"] + "</td><td>" + dic["ghc5"] + "</td><td>" + dic["ghc6"] + "</td><td>" + dic["ghc7"] + "</td><td>" + dic["ghc8"] + "</td><td>" + dic["ghc9"] + "</td><td></td><td></td><td></td><td></td></tr>";



            bhTableStr += "<tr><td>"+(dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count)+"</td><td>合计</td><td></td><td></td><td></td><td>" +
                ( decimal.Parse( dic["ghc1"])+decimal.Parse(dic["ycc1"])+decimal.Parse(dic["zjc1"])) 
                + "</td><td>" +(decimal.Parse( dic["ghc10"])+decimal.Parse(dic["ycc10"])+decimal.Parse(dic["zjc10"])) + "</td><td>" + ( decimal.Parse( dic["ghc2"])+decimal.Parse(dic["ycc2"])+decimal.Parse(dic["zjc2"])) + "</td><td>" + (decimal.Parse(dic["ghc3"])+decimal.Parse(dic["ycc3"])+decimal.Parse(dic["zjc3"]) )+ "</td><td>" + (decimal.Parse(dic["ghc4"])+decimal.Parse(dic["ycc4"])+decimal.Parse(dic["zjc4"])) + "</td><td>" + (decimal.Parse(dic["ghc5"])+decimal.Parse(dic["ycc5"])+decimal.Parse(dic["zjc5"])) + "</td><td>" + (decimal.Parse(dic["ghc6"])+decimal.Parse(dic["ycc6"])+decimal.Parse(dic["zjc6"])) + "</td><td>" + (decimal.Parse(dic["ghc7"])+decimal.Parse(dic["ycc7"])+decimal.Parse(dic["zjc7"])) + "</td><td>" +( decimal.Parse(dic["ghc8"])+decimal.Parse(dic["ycc8"])+decimal.Parse(dic["zjc8"])) + "</td><td>" +( decimal.Parse(dic["ghc9"])+decimal.Parse(dic["ycc9"])+decimal.Parse(dic["zjc9"])) + "</td><td></td><td></td><td></td><td></td></tr>";
            bhTableStr += "</table>";
            // Response.Write(bhTableStr);
            Label1.Text = bhTableStr;
        }
        //=============================================景观农业季度报告=================================
        else if (itemtype == "jg"){
       
            if (!(Request.QueryString["season"] != null && Request.QueryString["season"].ToString().Trim() != "" && Request.QueryString["year"] != null && Request.QueryString["year"].ToString().Trim() != ""))
            {
                return;
            }



            int season = Convert.ToInt32(Request.QueryString["season"].ToString().Trim());
            int year = Convert.ToInt32(Request.QueryString["year"].ToString().Trim());
            ExcelDown exceldown = new ExcelDown();
            Dictionary<String, String> dic = exceldown.getjgMoneyAndCountByAddress(year, season, audit, address);
            string seasonStr = new ConstantChangeUtil().getBigNum(season);


            string jgTableStr = @"<table style='border-collapse:collapse;'>
     <tr>
        <td colspan='14' align='center' style='font-weight: bold; font-size: 20px;'>"+year+"年龙泉山生态旅游综合功能区景观农业项目("+seasonStr+ @")季度推进情况表</td>
    </tr>
    <tr>
         <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报单位（盖章）：</td>
<td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>填报人：</td>
<td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>审核人：</td>
        <td colspan='3' style='font-weight: bold; font-size: 13px;' align='center'>	填报时间：" + fullTime + @"	</td>
        <td colspan='2'style='font-weight: bold; font-size: 13px;' align='right'>单位：万元、亩</td>
    </tr>
    <tr>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>序号</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>县（区、市）</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目名称</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>建设地址</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>建设起止年限</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目建设规模</td>
        <td  colspan='3'  style='font-weight: bold; font-size: 13px;' align='center'>目标计划</td>
        <td  colspan='4'  style='font-weight: bold; font-size: 13px;' align='center'>完成情况</td>
        <td  rowspan='2'  style='font-weight: bold; font-size: 13px;' align='center'>项目业主</td>
    </tr>
    <tr>
        <td style='font-weight: bold; font-size: 13px;' align='center'>计划总投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>" + year  +@"年计划投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>"+year  +@"年底工程应达形象进度</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>至"+(year-1) +@"年已累计完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>"+year +"年"+season +@"季完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>" + nowYear  + "年1-" + season  + @"季完成投资</td>
        <td style='font-weight: bold; font-size: 13px;' align='center'>目前形象进度</td>
    </tr>
";
            //=========================已成===============
            DataBase db = new DataBase();
           
            System.Data.DataTable dt2 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'yc','" + address + "'," + audit + ")");
            jgTableStr += "<tr><td>一、</td><td colspan='13'  >  " + "已成" + "</td></tr>";
            
            for (int i = 0; i < dt2.Rows.Count; i++)
            {
                jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt2.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt2.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt2.Rows.Count +"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + dic["ycc1"] + "</td><td>" + dic["ycc2"] + "</td><td></td><td>" + dic["ycc3"] + "</td><td>" + dic["ycc4"] + "</td><td>" + dic["ycc5"] + "</td><td></td><td></td></tr>";
            //===========================在建=============
            System.Data.DataTable dt4 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'zj','" + address + "'," + audit + ")");
            jgTableStr += "<tr><td>二、</td><td colspan='13' >" + "在建" + "</td></tr>";
            

            for (int i = 0; i < dt4.Rows.Count; i++)
            {
                jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt4.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt4.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt4.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + dic["zjc1"] + "</td><td>" + dic["zjc2"] + "</td><td></td><td>" + dic["zjc3"] + "</td><td>" + dic["zjc4"] + "</td><td>" + dic["zjc5"] + "</td><td></td><td></td></tr>";
            //===============================规划=============

            System.Data.DataTable dt6 = db.GetDataTable("select * from [dbo].itemjgReByAddress(" + year + "," + season + ",'gh','" + address + "'," + audit + ")");
            jgTableStr += "<tr><td>三、</td><td colspan='13' >" + "规划" + "</td></tr>";
           
            for (int i = 0; i < dt6.Rows.Count; i++)
            {
                jgTableStr += "<tr>";
                jgTableStr += "<td>" + (i + 1) + "</td>";
                for (int j = 0; j < dt6.Columns.Count; j++)
                {
                    jgTableStr += "<td>" + dt6.Rows[i][j].ToString() + " " + "</td>";
                }
                jgTableStr += "</tr>";
            }
            jgTableStr += "<tr><td>"+dt6.Rows.Count+"</td><td>小计</td><td></td><td></td><td></td><td></td><td>" + dic["ghc1"] + "</td><td>" + dic["ghc2"] + "</td><td></td><td>" + dic["ghc3"] + "</td><td>" + dic["ghc4"] + "</td><td>" + dic["ghc5"] + "</td><td></td><td></td></tr>";
            jgTableStr += "<tr><td>"+(dt2.Rows.Count+dt4.Rows.Count+dt6.Rows.Count )+"</td><td>合计</td><td></td><td></td><td></td><td></td><td>" + (decimal.Parse(dic["ghc1"]) + decimal.Parse(dic["ycc1"]) + decimal.Parse(dic["zjc1"])) + "</td><td>" + (decimal.Parse(dic["ghc2"]) + decimal.Parse(dic["ycc2"]) + decimal.Parse(dic["zjc2"])) + "</td><td></td><td>" + (decimal.Parse(dic["ghc3"]) + decimal.Parse(dic["ycc3"]) + decimal.Parse(dic["zjc3"])) + "</td><td>" + (decimal.Parse(dic["ghc4"]) + decimal.Parse(dic["ycc4"]) + decimal.Parse(dic["zjc4"])) + "</td><td>" + (decimal.Parse(dic["ghc5"]) + decimal.Parse(dic["ycc5"]) + decimal.Parse(dic["zjc5"])) + "</td><td></td><td></td></tr>";
            jgTableStr += "</table>";
            //Response.Write(jgTableStr);
            Label1.Text = jgTableStr;
        }
    }
    /// <summary>
    /// 一级导出Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button3_Command(object sender, CommandEventArgs e)
    {
        ExcelDown excelDown = new ExcelDown();
        string itemtype = Request.QueryString["itemtype"].ToString().Trim();
        if (itemtype == "st")
        {
            excelDown.downstExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["month"]), e.CommandName.ToString().Trim());
           //Response.AppendHeader("content-disposition", "attachment;filename=\"" + System.Web.HttpUtility.UrlEncode("Excel导出联系", System.Text.Encoding.UTF8) + ".xls\""); //添加excel的头
           // Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");//设置字符集
           // Response.ContentType = "application/ms-excel";//输出类型为excel
        
           // System.Text.StringBuilder sb = new System.Text.StringBuilder();
           // Response.Write(Label1.Text.ToString());
        }
        else if (itemtype == "jg")
        {
            excelDown.downjgExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["season"]), e.CommandName.ToString().Trim());
        }
        else if (itemtype == "bh")
        {
            excelDown.downbhExcel(Response, Server.MapPath("~/Admin/Excel"), Convert.ToInt32(Request.QueryString["year"]), Convert.ToInt32(Request.QueryString["season"]), e.CommandName.ToString().Trim());
        }

    }
}