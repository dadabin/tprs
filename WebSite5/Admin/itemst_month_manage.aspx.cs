using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Wuqi.Webdiyer;

using Dal;

public partial class Admin_itemst_month_manage : System.Web.UI.Page
{
    public string newReportUrl = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindGridView(GridView1, AspNetPager1);
        }
        
    }

    public void bindGridView(GridView gv, AspNetPager pager) 
    {
        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
            ItemReportBll bll = new ItemReportBll();
            string projectID = Request.QueryString["projectID"].ToString();
            int type = 1;

            int roleID = int.Parse(Session["RoleID"].ToString());
            bll.bindItem(gv, pager, projectID, type, roleID);

            ///业主=========
            if (Session["ROLEID"].ToString() == "4")
            {
                ItemBll itembll = new ItemBll();
                if (!itembll.isFillTime(1, int.Parse(Request.QueryString["projectID"].ToString().Trim()), ""))
                {
                    newReportUrl = "itemst_month_add.aspx?projectID=";
                    newReportUrl = "<a href='" + newReportUrl + Request.QueryString["projectID"].ToString() + "'>点击添加该项目本月分的进度报告</a>";
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('现在不是报告填写时间，如果您只可以查看既往的报告！')</script>");
                }
            }
            ///一二级审核员======
            

        }
        else 
        {
            //没有获取到项目编号
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('获取项目编号失败！！！！')</script>");
        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindGridView(GridView1, AspNetPager1);
    }
}