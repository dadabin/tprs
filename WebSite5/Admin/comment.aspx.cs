using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;

public partial class Admin_comment : System.Web.UI.Page
{

    //获取项目类型
    int reportType = 0;
    //获取项目编号---主键ID号
    int reportID = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
        }
        // <a href='comment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>点击评论</a>
        if (Request.QueryString["reportType"] != null && Request.QueryString["reportType"].ToString() != "" && Request.QueryString["reportID"] != null && Request.QueryString["reportID"].ToString() != "")
        {
            reportType = int.Parse(Request.QueryString["reportType"].ToString());
            reportID = int.Parse(Request.QueryString["reportID"].ToString());
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('数据加载失败，无法进行点评操作！')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        CommentBll bll = new CommentBll();
        //获取表单输入
        String content = TextBox1.Text.Trim();
        //获取当前用户登录名
        String LoginName = Session["user_loginName"].ToString();

        //////////以下二参用于定位报告详情

        ////获取项目类型
        char type = char.Parse(""+reportType);
        ////获取项目编号---主键ID号
        //int reportID = int.Parse("12");

        //Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + reportType + "==" + reportID + "')</script>");

        String result = bll.addComment(reportID, reportType, LoginName, content);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + result + "')</script>");
        




    }
}