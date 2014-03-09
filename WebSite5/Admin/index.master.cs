using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_index : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            if (Session["user_loginName"] != null && Session["user_loginName"].ToString() != "")
            {
                string user = Session["user_loginName"].ToString();
               
            }
            else
            {
                Response.Redirect("../login.aspx");
              
            }
        }

    }

}
