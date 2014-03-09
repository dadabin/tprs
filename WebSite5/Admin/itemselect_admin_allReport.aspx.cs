using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;

public partial class Admin_itemselect_admin_allReport : System.Web.UI.Page
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
        String whereStr1 = " and a.AUDIT=2";
        bll.leaderReportBindItem(GridView1, AspNetPager1, whereStr1);  //未通过
        //bll.admin2ReportBindItem(GridView1, AspNetPager1, whereStr1);
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind();
    }


    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        ItemBll bll = new ItemBll();

        string whereStr = " and a.AUDIT=2 ";
        //获取下拉列表的值：

        string address = DropDownList3.SelectedValue.Trim();  //t_user.AREA = 'jt'

        if (address != null && address != "" && address != "0")
        {
            whereStr += " and t_user.AREA='" + address + "' ";
        }

        bll.leaderReportBindItem(GridView1, AspNetPager1, whereStr);
    }

}