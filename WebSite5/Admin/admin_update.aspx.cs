using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_admin_update : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindInformation();
        }
    }


    public void bindInformation()
    {
        if (Request.QueryString["adminID"] != null && Request.QueryString["adminID"].ToString() != "")
        {
            UserEntity en = new UserEntity();
            UserBll userBll = new UserBll();
            DataTable dt=userBll.selectByLoginName(1, Request.QueryString["adminID"].ToString());
            if (dt.Rows.Count > 0)
            {
                username.Text = dt.Rows[0]["USERNAME"].ToString();
                loginusername.Text = dt.Rows[0]["LOGINNAME"].ToString();
                TextBox1.Text = dt.Rows[0]["PASSWORD"].ToString();
                tel.Text = dt.Rows[0]["OFFICEPHONE"].ToString();
            }
            else
            {
                Response.Redirect("admin_manage.aspx");
            }
        }
        else
        {
            Response.Redirect("admin_manage.aspx");
        }

    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void update_admin_but_Click(object sender, EventArgs e)
    {
        UserEntity en = new UserEntity();
        UserBll bll = new UserBll();
        en.LoginName = loginusername.Text.Trim();
        en.UserName = username.Text.Trim();
        en.Password = TextBox1.Text.Trim();

        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(loginusername.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
            return;
        }


        if (strUtil.strLength(username.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(TextBox1.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }
        if (tel.Text != null)
        {
            en.OfficePhone = tel.Text.Trim();
        }
        else
        {
            en.OfficePhone = "";
        }
        if (bll.updateUser(1, en))
        {
            DataTable sessionUser = (DataTable)Session["userEntity_logined"]; //获取当前登录的用户
            LogBll logBll = new LogBll();
            LogEntity log = new LogEntity();
            log.LoginName = sessionUser.Rows[0]["LOGINNAME"].ToString();
            log.UserName = sessionUser.Rows[0]["USERNAME"].ToString();
            log.LogContent = logBll.user_builtUpdateStr(en,sessionUser);
            logBll.addLog(log);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！')</script>");
            Response.Redirect("admin_manage.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！')</script>");
        }


    }
}