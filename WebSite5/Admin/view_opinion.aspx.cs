using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;

public partial class Admin_view_opinion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
           if (Session["userEntity_logined"] == null)
               Response.Redirect("~/login.aspx");
           //获取参数
           int itemtype = int.Parse(Request.QueryString["itemType"].ToString());
           int itemid = int.Parse(Request.QueryString["itemID"].ToString());
           //查询数据
           CommentBll bll = new CommentBll();
           DataTable dt = bll.getCommentByReport(itemtype, itemid);
           //展示数据
           if (dt.Rows.Count > 0)
           {
               Label1.Text = dt.Rows[0]["CNAME"].ToString() == "" || dt.Rows[0]["CNAME"].ToString() == null ? "暂无" : dt.Rows[0]["CNAME"].ToString();
               Label2.Text = dt.Rows[0]["CTIME"].ToString() == "" || dt.Rows[0]["CTIME"].ToString() == null ? "暂无" : dt.Rows[0]["CTIME"].ToString();
               Label3.Text = dt.Rows[0]["COMMENT"].ToString() == "" || dt.Rows[0]["COMMENT"].ToString() == null ? "暂无" : dt.Rows[0]["COMMENT"].ToString();

               Label4.Text = dt.Rows[0]["RNAME"].ToString() == "" || dt.Rows[0]["RNAME"].ToString() == null ? "暂无" : dt.Rows[0]["RNAME"].ToString();
               Label5.Text = dt.Rows[0]["RTIME"].ToString() == "" || dt.Rows[0]["RTIME"].ToString() == null ? "暂无" : dt.Rows[0]["RTIME"].ToString();
               Label6.Text = dt.Rows[0]["REPLY"].ToString() == "" || dt.Rows[0]["REPLY"].ToString() == null ? "暂无" : dt.Rows[0]["REPLY"].ToString();

           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('项报告尚未被点评！！')</script>");
           }
       
       }
    }
}