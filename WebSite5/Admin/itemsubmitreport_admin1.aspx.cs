using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;

public partial class Admin_itemsubmitreport_admin1 : System.Web.UI.Page
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
        ItemReportBll bll = new ItemReportBll();
        String whereStr = "";

        bll.bindReportAdmin1(GridView1, AspNetPager1, "lq", 0, whereStr);
    }
    //分页
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
       
       
    }
}