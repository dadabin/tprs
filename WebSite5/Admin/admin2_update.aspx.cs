using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Model;
using Dal;

public partial class Admin_admin2_update : System.Web.UI.Page
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

    /// <summary>
    /// 修改信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserBll bll = new UserBll();
        UserEntity en = new UserEntity();
        en.LoginName = TextBox2.Text.Trim();
        en.UserName = TextBox1.Text.Trim();
        en.Password = TextBox3.Text.Trim();
        en.Phone = TextBox4.Text.Trim();
        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(TextBox2.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(TextBox3.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }


        if (strUtil.strLength(TextBox1.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
            return;
        }
        if (TextBox5.Text != null)
        {
            en.Email = TextBox5.Text.Trim();
        }
        else
        {
            en.Email = "";
        }
        if (bll.updateUser(2, en))
        {
            DataTable sessionUser = (DataTable)Session["userEntity_logined"]; //获取当前登录的用户
            LogBll logBll = new LogBll();
            LogEntity log = new LogEntity();
            log.LoginName = sessionUser.Rows[0]["LOGINNAME"].ToString();
            log.UserName = sessionUser.Rows[0]["USERNAME"].ToString();
            log.LogContent = logBll.user_builtUpdateStr(en, sessionUser);
            logBll.addLog(log);

            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！');</script>");
            Response.Redirect("admin2_manage.aspx");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！');</script>");
        }
    }

    public void bind()
    {
        if (Request.QueryString["adminID"] != null && Request.QueryString["adminID"].ToString() != "")
        {

            UserBll bll = new UserBll();
            DataTable dt = bll.selectByLoginName(2,Request.QueryString["adminID"].ToString());
            if (dt.Rows.Count > 0)
            {
                TextBox1.Text = dt.Rows[0]["USERNAME"].ToString();
                TextBox2.Text = dt.Rows[0]["LOGINNAME"].ToString();
                TextBox3.Text = dt.Rows[0]["PASSWORD"].ToString();
                TextBox4.Text = dt.Rows[0]["PHONE"].ToString();
                TextBox5.Text = dt.Rows[0]["EMAIL"].ToString();
            }

        }
    }
}