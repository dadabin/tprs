using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

using Bll;

public partial class Admin_itemselect_admin_allProject : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       if(!IsPostBack)
       {
           if (Session["userEntity_logined"] == null)
               Response.Redirect("~/login.aspx");
           bindGridView(GridView1,AspNetPager1);
       }
    }
    public void bindGridView(GridView gv, AspNetPager pager)
    {
            ItemBll bll = new ItemBll();
            string whereStr = "   ";
            bll.adminBindItem(gv, pager, whereStr, int.Parse(DropDownList1.SelectedValue.Trim()));
            
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //bindGridView(GridView1, AspNetPager1);
        ItemBll bll = new ItemBll();

        string whereStr = "";
        //获取下拉列表的值：

        string address = DropDownList3.SelectedValue.Trim();  //t_user.AREA = 'jt'

        if (address != null && address != "" && address != "0")
        {
            whereStr += " and t_user.AREA='" + address + "'";
        }

        bll.adminBindItem(GridView1, AspNetPager1, whereStr, int.Parse(DropDownList1.SelectedValue.Trim()));
    }

    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
        ItemBll bll = new ItemBll();
    
        string whereStr = "";
        //获取下拉列表的值：

        string address = DropDownList3.SelectedValue.Trim();  //t_user.AREA = 'jt'

        if (address != null && address != "" && address != "0")
        {
            whereStr += " and t_user.AREA='" + address + "'";
        }

        bll.adminBindItem(GridView1, AspNetPager1, whereStr,int.Parse(DropDownList1.SelectedValue.Trim()));
    }

   
}