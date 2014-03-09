using System;
using System.Collections.Generic;
using Bll;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Wuqi.Webdiyer;
using Dal;


public partial class Admin_itemjg_season_manage : System.Web.UI.Page
{

    public string newReportUrl = "";//定义全局访问参数，用于传递项目编号到新建季度报表页面

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            season_bind(GridView1, AspNetPager1);
        }
    }
  
    public void season_bind(GridView gv, AspNetPager pager)
    {

        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
            //绑定数据到UI
            ItemReportBll bll = new ItemReportBll();
            string projectID = Request.QueryString["projectID"].ToString();
            int type = 4;
            
            int roleID = int.Parse(Session["RoleID"].ToString());
            bll.bindItem(gv, pager, projectID, type, roleID);

            //bll.bindReportManage(gv, pager, projectID, 2, Session["user_loginName"].ToString(), "");

            if (Session["ROLEID"].ToString() == "4")
            {
                ItemBll itembll = new ItemBll();
                if (!itembll.isFillTime(2, int.Parse(Request.QueryString["projectID"].ToString().Trim()), ""))
                {
                    newReportUrl = "itemjg_season_add.aspx?projectID=";
                    newReportUrl = "<a href='" + newReportUrl + Request.QueryString["projectID"].ToString() + "'>点击添加该项目在当前季度的报告</a>";
                }
                else
                {
                    //Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('现在不是报告填写时间，如果您只可以查看既往的报告！')</script>");
                }

            }  
        }


    }

}