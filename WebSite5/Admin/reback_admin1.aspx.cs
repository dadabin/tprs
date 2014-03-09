using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;

public partial class Admin_reback_admin1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        //获取项目编号
        int id = int.Parse(Request.QueryString["id"].ToString().Trim());
        //获取项目类型
        int  typeInt = 0;
        if (Request.QueryString["type"].ToString().Trim() == "生态旅游重大项目")
        {
            typeInt = 1;
        }
        else if (Request.QueryString["type"].ToString().Trim() == "景观农业")
        {
            typeInt = 2;
        }
        else if (Request.QueryString["type"].ToString().Trim() == "百湖工程")
        {
            typeInt = 3;
        }
       
        //打回操作
        ItemBll bll = new ItemBll();
        int reback = 1;
        int submitstate = 0;
        string content = reason.Text.Trim();

        if (bll.reback(typeInt, id, reback, submitstate, content))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('回复成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('回复失败！')</script>");  
        }

    }
    protected void Btn_Close_Click(object sender, EventArgs e)
    {
        //Response.Redirect("itemsubmitselect_admin1.aspx");
    }
}