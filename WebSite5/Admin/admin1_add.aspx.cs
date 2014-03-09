using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_admin1_add : System.Web.UI.Page
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
    /// 添加一级审核员
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserEntity en = new UserEntity();
        UserBll bll = new UserBll();
        en.UserName = TextBox1.Text.Trim();
        en.LoginName = TextBox2.Text.Trim();
        en.Password = TextBox3.Text.Trim();
        en.Phone = TextBox4.Text.Trim();
        en.Email = TextBox5.Text.Trim();
        en.RoleID = 3;

        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(TextBox2.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
            return;
        }


        if (strUtil.strLength(TextBox1.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(TextBox3.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }

        en.Area = DropDownList1.SelectedValue.Trim();
        if (bll.isUse(en))
        {
            if (bll.addUser(en, 3))
            {
                DataTable sessionUser = (DataTable)Session["userEntity_logined"]; //获取当前登录的用户
                LogBll logBll = new LogBll();
                LogEntity log = new LogEntity();
                log.LoginName = sessionUser.Rows[0]["LOGINNAME"].ToString();
                log.UserName = sessionUser.Rows[0]["USERNAME"].ToString();
                log.LogContent = logBll.user_builtAddStr(en, 3, sessionUser);
                logBll.addLog(log);

                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！')</script>");
                Response.Redirect("admin1_manage.aspx");

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('用户名已存在！')</script>");
        
        
        }
        

    }
}