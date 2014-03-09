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

public partial class Admin_itemselect_admin2_report : System.Web.UI.Page
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
        String whereStr1 = builtwhereStr()+"  and a.AUDIT=1 ";
        String whereStr2 = builtwhereStr()+"  and a.AUDIT=2 ";


        bll.admin2ReportBindItem(GridView1, AspNetPager1, whereStr1);  //未通过
        bll.admin2ReportBindItem(GridView2, AspNetPager2, whereStr2);  //已通过

    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        ItemBll bll = new ItemBll();
        String whereStr1 = builtwhereStr()+" and  a.AUDIT = 1";
        bll.admin2ReportBindItem(GridView1, AspNetPager1, whereStr1);  //未通过
      
    }

    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        String whereStr2 = builtwhereStr()+" and a.AUDIT = 2 ";
        ItemBll bll = new ItemBll();
        bll.admin2ReportBindItem(GridView2, AspNetPager2, whereStr2);  //已通过

    }

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + e.CommandName.Trim() + "======"+e.CommandArgument.ToString()+"')</script>");
        

        int reportID = int.Parse(e.CommandName.Trim());
        int type = int.Parse(e.CommandArgument.ToString());

        ItemReportBll bll = new ItemReportBll();

        if (bll.updateAudit2(type, reportID,2))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核成功通过！')</script>");
            bind();
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核失败！')</script>");
        }

        bind();
    }

    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        bind();
    }

    private string builtwhereStr()
    {
        string whereStr = "";
        //获取下拉列表的值：
        string address = DropDownList3.SelectedValue.Trim();  //t_user.AREA = 'jt'
        if (address != null && address != "" && address != "0")
        {
            whereStr += " and t_user.AREA='" + address + "'";
        }
        return whereStr;

    }

    


    
}