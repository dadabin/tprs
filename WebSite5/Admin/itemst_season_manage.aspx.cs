using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Bll;

public partial class Admin_itemst_season_manage : System.Web.UI.Page
{
    public string newReportUrl = "";//定义全局访问参数，用于传递项目编号到新建季度报表页面
    protected void Page_Load(object sender, EventArgs e)
    {
        bindGridView(GridView1, AspNetPager1);
    }

    public void bindGridView(GridView gv, AspNetPager pager)
    {
        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
            ItemReportBll bll = new ItemReportBll();
            string projectID = Request.QueryString["projectID"].ToString();
            int type = 2;
            int roleID = int.Parse(Session["RoleID"].ToString());
            bll.bindItem(gv, pager, projectID, type, roleID);

           
            if (Session["ROLEID"].ToString() == "4")
            {
                newReportUrl = "itemst_season_add.aspx?projectID=";
                newReportUrl = "<a href='" + newReportUrl + Request.QueryString["projectID"].ToString() + "'>点击添加该项目的进度报告</a>";

            }
        }
        else
        {
            //没有获取到项目编号
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('获取项目编号失败！！！！')</script>");
        }
    }
}