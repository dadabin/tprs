using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;

public partial class Admin_itemselect_admin1 : System.Web.UI.Page
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
        String whereStr = Session["user_loginName"].ToString();
        bll.admin1BindItem2(GridView1, AspNetPager1, whereStr,0);


    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //ItemBll bll=new ItemBll();
        //String whereStr = Session["user_loginName"].ToString();
        //bll.admin1BindItem2(GridView1, AspNetPager1, whereStr);
        bind();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        ItemBll bll = new ItemBll();
        String whereStr = Session["user_loginName"].ToString();
       
        bll.admin1BindItem2(GridView1, AspNetPager1, whereStr,int.Parse(DropDownList1.SelectedValue.Trim()) );

    }
}