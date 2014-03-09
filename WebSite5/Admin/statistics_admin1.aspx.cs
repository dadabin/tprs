using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Bll;

public partial class Admin_statistics : System.Web.UI.Page
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

    private void bindview()
    {
        DataTable dt = (DataTable)Session["userEntity_logined"];
        if(dt.Rows.Count > 0)
        {
            string area = dt.Rows[0]["area"].ToString();
            ItemReportBll bll = new ItemReportBll();
            bll.staticsforadmin1(GridView1, AspNetPager1,area);
        
        }
    
    }
}