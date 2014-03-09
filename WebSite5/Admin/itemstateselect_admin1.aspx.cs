using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Text;
using System.Data;
using Bll;
using Model;
using org.in2bits.MyXls;
using Cells = org.in2bits.MyXls.Cells;
using Cell = org.in2bits.MyXls.Cell;

public partial class Admin_itemselect_admin2 : System.Web.UI.Page
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

    public void bind()
    {
        ItemBll bll = new ItemBll();
        String whereStr = "";
        bll.admin1BindItem(GridView1, AspNetPager1, whereStr,Session["user_loginName"].ToString().Trim());


    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bind(); 
    }

    /// <summary>
    /// 点击审核通过
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>

    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        string type = e.CommandName;
        int itemID = int.Parse(e.CommandArgument.ToString().Trim());

        int typeInt = 0;
        if (e.CommandName.Trim() == "生态旅游重大项目")
        {
            typeInt = 1;
        }
        else if (e.CommandName.Trim() == "景观农业")
        {
            typeInt = 2;
        }
        else if (e.CommandName.Trim() == "百湖工程")
        {
            typeInt = 3;
        }
       

        ItemBll bll = new ItemBll();
        if (bll.endProject(typeInt, itemID,""))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('设置成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('设置未通过！')</script>");
        }
        bind(); 
    }
}