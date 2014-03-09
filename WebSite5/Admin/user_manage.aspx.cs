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
        UserEntity en = new UserEntity();
        DataTable dt = userBll.selectByLoginName(3, Session["user_loginName"].ToString());
        userBll.bindGridView(gv, pager,4," WHERE ROLEID=4 AND AREA='"+dt.Rows[0]["AREA"]+"'");
    }

    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindGridView(GridView1, AspNetPager1);

    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        if (e.CommandArgument != null && e.CommandArgument.ToString() != null)
        {
            Response.Redirect("user_update.aspx?adminID=" + e.CommandArgument);

        }
    }
    protected void LinkButton2_Command(object sender, CommandEventArgs e)
    {
        ItemBll bll = new ItemBll();
        if (e.CommandArgument != null && e.CommandArgument.ToString() != null)
        {
            string loginName = e.CommandArgument.ToString();
            //判断该业主用户下是否存在项目，如不存在，允许其删除之，如存在不能删除
            int userProjects = bll.getProjectNumInUser(loginName);
            UserBll ub = new UserBll();
            UserEntity en=new UserEntity();
            en.LoginName = loginName;

            if (userProjects == 0)
            {
                //执行删除的逻辑
                if (ub.deleteUser(en))
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除成功！')</script>");
                    bindGridView(GridView1, AspNetPager1);

                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除失败！')</script>");
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('该业主下还有" + userProjects + "个项目，不能执行删除操作，详情请登录该业主界面查看详情！！')</script>");
            }

            //页面刷新
            bindGridView(GridView1, AspNetPager1);
        }
    }

}