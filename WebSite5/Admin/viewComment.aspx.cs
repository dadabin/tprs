using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using System.Data;
using Bll;

public partial class Admin_viewComment : System.Web.UI.Page
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
          // 获取commentID
            if (Request.QueryString["reportType"] != null && Request.QueryString["reportType"].ToString() != "" && Request.QueryString["reportID"] != null && Request.QueryString["reportID"].ToString() != "")
            {
                reportType = int.Parse(Request.QueryString["reportType"].ToString());
                reportID = int.Parse(Request.QueryString["reportID"].ToString());
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('数据加载失败，无法进行点评操作！')</script>");
            }
            bind(reportType, reportID);

        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        // 获取commentID
        if (Request.QueryString["reportType"] != null && Request.QueryString["reportType"].ToString() != "" && Request.QueryString["reportID"] != null && Request.QueryString["reportID"].ToString() != "")
        {
            reportType = int.Parse(Request.QueryString["reportType"].ToString());
            reportID = int.Parse(Request.QueryString["reportID"].ToString());
            //获取表单内容
            string content = TextBox2.Text.Trim();
            //获取登陆用户名
            string loginName = Session["user_loginName"].ToString();

            CommentBll bll = new CommentBll();

            String result = bll.addReply(reportType, reportID, loginName, content);

            //页面提示结果
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + result + "')</script>");
    
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('数据加载失败，无法进行点评操作！')</script>");
        }

      }

    private void bind(int reportType, int reportID)
    { 
        //获取评论内容
        DataTable tb = new DataTable();
        CommentBll bll = new CommentBll();
        TextBox1.Text = "hhhhhh";
        tb = bll.getCommentByReport(reportType, reportID);

        ////将tb的数据显示在页面
        if (tb.Rows.Count > 0)
        {
            //显示领导点评内容
            string cname = tb.Rows[0]["CNAME"].ToString();//评论人
            string ctime = tb.Rows[0]["CTIME"].ToString();//评论时间
            string comment = tb.Rows[0]["COMMENT"].ToString();
            TextBox1.Text = cname + "在 " + ctime + "评论道：\n\n" + comment;

        }
    }
}