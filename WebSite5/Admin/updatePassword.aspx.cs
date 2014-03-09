using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;

public partial class Admin_updatePassword : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            
        }
    }


    public void bind()
    {
        if (Session["user_loginName"] != null && Session["user_loginName"].ToString() != "")
        {
            UserEntity en = new UserEntity();
            UserBll bll = new UserBll();
            int roleID;
            if (int.TryParse(Session["RoleID"].ToString(), out roleID)){
              
                
            }
        }

    }
    //修改密码
    protected void Button1_Click(object sender, EventArgs e)
    {
        string oldpassword=TextBox1.Text.Trim();
        string password = TextBox2.Text.Trim();
        if (Session["user_loginName"] != null && Session["user_loginName"].ToString() != "")
        {
            
            UserBll bll = new UserBll();
            if (bll.updatePassword(Session["user_loginName"].ToString().Trim(), oldpassword, password))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！')</script>");
            }
           
        }

    }
}