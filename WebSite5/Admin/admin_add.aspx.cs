using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_admin_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");

        }

    }

    /// <summary>
    /// 添加市级领导
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void add_admin_but_Click(object sender, EventArgs e)
    {
        UserEntity user = new UserEntity();
        user.LoginName = loginusername.Text.Trim();
        user.Password = login_password.Text.Trim();
        user.UserName = username.Text.Trim();
        user.OfficePhone = tel.Text.Trim();
        user.RoleID = 1;
        user.OperateUser = Session["user_loginName"].ToString();

        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(loginusername.Text,26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
            return;
        }

        
        if (strUtil.strLength(username.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(login_password.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }

        UserBll userBll = new UserBll();
       
        if (userBll.isUse(user))
        {
            if (userBll.addUser(user,1))
            {
                DataTable sessionUser = (DataTable)Session["userEntity_logined"]; //获取当前登录的用户
                LogBll logBll = new LogBll();
                LogEntity log = new LogEntity();
                log.LoginName = sessionUser.Rows[0]["LOGINNAME"].ToString();
                log.UserName = sessionUser.Rows[0]["USERNAME"].ToString();
                log.LogContent = logBll.user_builtAddStr(user, 1, sessionUser);
                logBll.addLog(log);
                
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加用户成功！')</script>");
                Response.Redirect("admin_manage.aspx");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('用户名已经存在！')</script>");
        }

    }
}