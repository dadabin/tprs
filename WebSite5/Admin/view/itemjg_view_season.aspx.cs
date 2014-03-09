using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;

public partial class Admin_view_itemjg_view_season : System.Web.UI.Page
{
    public DateTime reportTime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            bind();
        }
    }

    public void bind()
    {

        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {

            //ItemBll bll = new ItemBll();
            // DataTable dt = bll.selectByID(2, int.Parse(Request.QueryString["projectID"].ToString().Trim()));
            ItemReportBll bll = new ItemReportBll();
            DataTable dt = bll.selectReportById(4, int.Parse(Request.QueryString["id"]));


             if (dt.Rows.Count > 0)
             {
                 Label1.Text = dt.Rows[0]["qx"].ToString();//区县
                 //if (dt.Rows[0]["qx"].ToString() == "lqy")
                 //{
                 //    Label1.Text = "龙泉驿区";
                 //}
                 //else if (dt.Rows[0]["AREA"].ToString() == "jt")
                 //{
                 //    Label1.Text = "金堂县";
                 //}
                 //else if (dt.Rows[0]["AREA"].ToString() == "xj")
                 //{
                 //    Label1.Text = "新津县";
                 //}
                 //else if (dt.Rows[0]["AREA"].ToString() == "sl")
                 //{
                 //    Label1.Text = "双流县";
                 //}
                 //else if (dt.Rows[0]["AREA"].ToString() == "qbj")
                 //{
                 //    Label1.Text = "青白江区";
                 //}
                 Label2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                 Label3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                 
                 Label4.Text = dt.Rows[0]["STARTENDTIME"].ToString();//项目建设年限
                 Label5.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//项目建设规模
                 Label6.Text = dt.Rows[0]["PLANTOTALMONEY"].ToString();//计划总投资
                 Label7.Text = dt.Rows[0]["XYEARPLAN"].ToString();//2012年计划投资
                 
                 Label8.Text = dt.Rows[0]["ENDYEAR"].ToString();//2012年底工程应达形象进度
                 Label9.Text = dt.Rows[0]["PREYEARPLAN"].ToString();//至2011年已累计完成投资
                 //Label10.Text = dt.Rows[0]["XMONFIN"].ToString();//2012年6月完成投资
                
                // Label12.Text = dt.Rows[0]["PROJECTNAME"].ToString();//2012年1-6月完成投资
                 
                 Label12.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前形象进度

                 if (dt.Rows[0]["PROGRESSCATEGORY"].ToString().Trim() == "yc")
                 {
                     DropDownList1.Text = "已成";
                 }
                 else if (dt.Rows[0]["PROGRESSCATEGORY"].ToString().Trim() == "zj")
                 {
                     DropDownList1.Text = "在建";
                 }
                 else if (dt.Rows[0]["PROGRESSCATEGORY"].ToString().Trim() == "gh")
                 {
                     DropDownList1.Text = "规划";
                 }


                 //Label1.Text = dt.Rows[0]["qx"].ToString();//所属区县
                 //Label2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                 //Label3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址

                 // Label6.Text = redt.Rows[0]["PLANTOTALMONEY"].ToString();//计划总投资
                 //  Label7.Text = redt.Rows[0]["XYEARPLAN"].ToString();//2012年计划投资
                 // Label8.Text = redt.Rows[0]["ENDYEAR"].ToString();//2012年底工程应达形象进度
                 //Label9.Text = redt.Rows[0]["PREYEARPLAN"].ToString();//至2011年已累计完成投资

                 Label10.Text = dt.Rows[0]["XMONFIN"].ToString();//2012年6月完成投资
                 Label11.Text = dt.Rows[0]["total"].ToString();//2012年1-6月完成投资==========????

                 Label12.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前形象进度
                 Label13.Text = dt.Rows[0]["LOGINNAME"].ToString();//项目业主

                 reportTime = DateTime.Parse(dt.Rows[0]["REPORTTIME"].ToString());


                 DataTable dtpic = new DataTable();
                 dtpic.Columns.Add("path", typeof(string));
                 for (int i = 0; i < 5; i++)
                 {
                     DataRow r1 = dtpic.NewRow();
                     r1["path"] = dt.Rows[0]["IMAGE" + (i + 1) + "1"];
                     dtpic.Rows.Add(r1);
                 }
                 DataList1.DataSource = dtpic;
                 DataList1.DataBind();

             }
            
        }
      

    }
}