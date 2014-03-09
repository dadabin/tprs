using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using Bll;
using System.IO;
using System.Text;

public partial class Admin_itemselect1 : System.Web.UI.Page
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
        if(Session["user_loginName"]!=null&&Session["user_loginName"].ToString()!=""){
            string loginName = Session["user_loginName"].ToString();
            ItemBll bll = new ItemBll();
            bll.admin1BindItem(gv, pager,loginName);
        }
    }

    /// <summary>
    ///  绑定数据分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
      protected void  AspNetPager1_PageChanged(object sender, EventArgs e)
     {
         bindGridView(GridView1, AspNetPager1);
     }






   /// <summary>
   /// 点击审核通过
   /// </summary>
   /// <param name="sender"></param>
   /// <param name="e"></param>

      protected void LinkButton1_Command(object sender, CommandEventArgs e)
      {
          string type = e.CommandName;
          string itemID = e.CommandArgument.ToString();
          int typeInt=0;
          if(e.CommandName.Trim()=="生态旅游重大项目"){
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
          else if (e.CommandName.Trim() == "生态植被与恢复")
          {
              typeInt = 4;
          }
          else if (e.CommandName.Trim() == "特色旅游旅游村")
          {
              typeInt = 5;
          }
          else if (e.CommandName.Trim() == "乡村旅游度假区或A级景区")
          {
              typeInt = 6;
          }

          ItemBll bll = new ItemBll();
          if (bll.adminsubmit(typeInt,int.Parse(itemID),"1"))
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核通过！')</script>");
          }
          else
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('审核未通过！')</script>");
          }
          bindGridView(GridView1, AspNetPager1);
      }


}