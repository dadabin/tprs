using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;


using System.Text;
using System.Data;
using Bll;
using Model;
using org.in2bits.MyXls;
using Cells = org.in2bits.MyXls.Cells;
using Cell = org.in2bits.MyXls.Cell;

public partial class itemreportselect_admin1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bind();     
        }
    }

    public void bind()
    {
        ItemBll bll = new ItemBll();
        System.Data.DataTable dt = (System.Data.DataTable)Session["userEntity_logined"];
        String whereStr1 = "  and a.AUDIT=0  and b.loginName in (select u.loginName from t_user u where u.area='"+dt.Rows[0]["area"]+"')";
        String whereStr2 = "  and a.AUDIT in (1,2) and b.loginName in (select u.loginName from t_user u where u.area='" + dt.Rows[0]["area"] + "')";
        bll.admin2ReportBindItem(GridView1, AspNetPager1, whereStr1);  //只是业主申报,还未一级未通过
        bll.admin2ReportBindItem(GridView2, AspNetPager2, whereStr2);  //一级已通过

    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //ItemBll bll = new ItemBll();
        //String whereStr1 = "  where a.AUDIT = 0";
        //bll.admin2ReportBindItem(GridView1, AspNetPager1, whereStr1);  //未通过
        bind();
      
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        //ItemBll bll = new ItemBll();
        //String whereStr1 = "  where a.AUDIT in (1,2)";
        //bll.admin2ReportBindItem(GridView2, AspNetPager2, whereStr1);  //已通过
        bind();
    }
    
    /// <summary>
    /// 一级审核事件！！
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        
        //获取参数
        int reportID = int.Parse(e.CommandName.Trim());
        int type = int.Parse(e.CommandArgument.ToString());
        ItemReportBll bll = new ItemReportBll();

        if (bll.updateAudit2(type, reportID,1))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核成功通过！')</script>");
            bind();     
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核失败！')</script>");
        }

    }
}