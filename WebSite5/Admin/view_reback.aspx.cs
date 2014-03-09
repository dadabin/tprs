using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;

public partial class Admin_view_reback : System.Web.UI.Page
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

    private void bind()
    {
        int typeInt = 0;
        int id = int.Parse(Request.QueryString["id"].ToString().Trim());
        if (Request.QueryString["type"].ToString().Trim() == "生态旅游重大项目")
        {
            typeInt = 1;
        }
        else if (Request.QueryString["type"].ToString().Trim() == "景观农业")
        {
            typeInt = 2;
        }
        else if (Request.QueryString["type"].ToString().Trim() == "百湖工程")
        {
            typeInt = 3;
        }
        
        //显示信息
        ItemBll bll = new ItemBll();
        DataTable dt = new DataTable();
        string whereStr = "";
        dt = bll.viewReback(typeInt, id,whereStr);
        if(dt.Rows.Count > 0)
        {
            Reback_Reason.Text = dt.Rows[0]["REASON"].ToString();
        }                                                        
        


    }

}