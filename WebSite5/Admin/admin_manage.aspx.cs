using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Bll;
using Model;
using System.Data;

public partial class Admin_admin_manage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bindGridView(GridView1, AspNetPager1);

        }
    }
    public void bindGridView(GridView gv,AspNetPager pager)
    {

        UserBll userBll = new UserBll();
        userBll.bindGridView(gv, pager,1,"");
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        UserBll userBll = new UserBll();
        userBll.bindGridView(GridView1, AspNetPager1, 1, "");

    }

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null && e.CommandArgument.ToString() != null)
        {
            Response.Redirect("admin_update.aspx?adminID=" + e.CommandArgument);
        }
    }

    /// <summary>
    /// 删除
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null && e.CommandArgument.ToString() != "")
        {
            UserBll bll = new UserBll();
            UserEntity en = new UserEntity();
            en.LoginName = e.CommandArgument.ToString().Trim();
            if (bll.deleteUser(en))
            {
                DataTable sessionUser = (DataTable)Session["userEntity_logined"]; //获取当前登录的用户
                LogBll logBll = new LogBll();
                LogEntity log = new LogEntity();
                log.LoginName = sessionUser.Rows[0]["LOGINNAME"].ToString();
                log.UserName = sessionUser.Rows[0]["USERNAME"].ToString();
                log.LogContent = logBll.user_builtDeletStr(en, sessionUser);
                logBll.addLog(log);


                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除成功！')</script>");
                bindGridView(GridView1, AspNetPager1);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除失败！')</script>");
            }
            
        }
    }
}