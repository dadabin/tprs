using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;

public partial class Admin_log : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindview();
        }

    }
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {

        bindview();
    }

    protected void bindview()
    { 
        //获取下拉
        //构建whereStr
        String whereStr = "";
        //绑定
        LogBll bll = new LogBll();
        bll.bindView(GridView1,AspNetPager1, whereStr);
    }

}