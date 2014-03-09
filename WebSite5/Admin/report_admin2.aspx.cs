using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using Wuqi.Webdiyer;


public partial class report_admin2: System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindView(GridView1, AspNetPager1);
        }
    }
    private void bindView(GridView gv, AspNetPager pager)
    {   
        //获取当前登录用户
        string loginName = Session["user_loginName"].ToString();
        CommentBll bll = new CommentBll();
        bll.bindOpinionView(gv, pager);
    
    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindView(GridView1, AspNetPager1);
    }
}