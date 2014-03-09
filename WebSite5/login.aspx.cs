using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
using System.Data;

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    /// <summary>
    /// 登陆事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        string username="";
        string password="";
        username = LoginName.Text.Trim();
        password = Password.Text.Trim();
        string xxx = Session["CheckCode"].ToString();
        xxx = xxx.ToLower();

        if (Session["CheckCode"] != null && Session["CheckCode"].ToString() != "")
        {
            if (TextBox1.Text!=null&&TextBox1.Text.Trim()!=""&&Session["CheckCode"].ToString().Trim().ToLower() == TextBox1.Text.Trim().ToLower())
            {
                if (username != null && password != null && username != "" && password != "")
                {
                    if (user_login(username, password))
                    {
                        //登陆成功，将用户名放到session
                        Session["user_loginName"] = username;
                        Response.Redirect("index.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('用户名或密码错误！')</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('用户名或密码不能为空！')</script>");
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('验证码输入错误！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('验证码出错了！')</script>");
        }        
    }

    private bool user_login(string username, string password)
    {
        UserBll bll=new UserBll();
        UserEntity en = new UserEntity();
        en.LoginName = username;
        en.Password = password;
        DataTable dt = bll.login(en);
        if (dt.Rows.Count > 0)
        {
            Session["RoleID"] = dt.Rows[0]["ROLEID"].ToString();
            Session["userEntity_logined"] = dt;   //将登陆成功的用户信息放置到session

            return true;
        }
        return false;
    }
}