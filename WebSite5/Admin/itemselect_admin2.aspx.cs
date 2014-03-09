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
            bind(builStr());
        }
    }

    public void bind(string whereStr)
    {
        ItemBll bll = new ItemBll();
       // String whereStr = " ";   //表示一级审核员通过的项目。where AUDIT = 1
        
        bll.adminBindItem(GridView1, AspNetPager1, whereStr,int.Parse(DropDownList1.SelectedValue.Trim()));


    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        //ItemBll bll=new ItemBll();
        //String whereStr = "  "; //where AUDIT = 1
        //UserBll userBll = new UserBll();
        //UserEntity en = new UserEntity();
        //bll.adminBindItem(GridView1, AspNetPager1, whereStr);
        bind(builStr());
    }

   


    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {



        bind(builStr());


    }

    private string builStr()
    {
        string whereStr = "";
        //获取下拉列表的值：

        string address = DropDownList3.SelectedValue.Trim();  //t_user.AREA = 'jt'

        if (address != null && address != "" && address != "0")
        {
            whereStr += " and t_user.AREA='" + address + "'";
        }
        return whereStr;
    }

   
}