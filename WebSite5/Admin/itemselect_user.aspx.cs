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
            bindGridView();
        }

    }


    public void bindGridView()
    {
        if(Session["user_loginName"]!=null&&Session["user_loginName"].ToString()!=""){
            string loginName = Session["user_loginName"].ToString();
            ItemBll bll = new ItemBll();

            //还未提交的项目
            string where2 = " WHERE LOGINNAME=@LOGINNAME  AND SUBMITSTATE='0' and REBACK='0' AND AUDIT='0' ";
            bll.userBindItem(GridView2, AspNetPager2, loginName, where2);

            //已经提交的项目 ,等待审核的项目
            string where1 = " WHERE LOGINNAME=@LOGINNAME AND SUBMITSTATE='1' and AUDIT='0'";
            bll.userBindItem(GridView1, AspNetPager1,loginName, where1);
           
            //被打回的项目
            String where3 = "where  LOGINNAME=@LOGINNAME  AND SUBMITSTATE='0' and REBACK='1' AND AUDIT='0'";
            bll.userBindItem(GridView3, AspNetPager3, loginName, where3);

        }
    }

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        bindGridView();
    }
    protected void AspNetPager2_PageChanged(object sender, EventArgs e)
    {
        bindGridView();
    }
    protected void AspNetPager3_PageChanged(object sender, EventArgs e)
    {
        bindGridView();
    }


    /// <summary>
    /// 点击申报
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
      protected void LinkButton1_Command(object sender, CommandEventArgs e)
      {

          string type = e.CommandName;
          string itemID = e.CommandArgument.ToString();
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

          if (bll.submit(typeInt, int.Parse(itemID), "1"))
          {
              //
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('项目提交成功，请等待审核！')</script>");
          }
          else
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('项目提交失败！')</script>");
          }
          bindGridView();
      }

      /// <summary>
      /// 一级审核员删除未提交的项目
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      protected void LinkButton2_Command(object sender, CommandEventArgs e)
      {
          string type = e.CommandName;
          string itemID = e.CommandArgument.ToString();
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
          if (bll.delete(typeInt, int.Parse(itemID)))
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除成功！')</script>");

          }
          else
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('删除失败！')</script>");
          }
          bindGridView();
      }

      protected void LinkButton3_Command(object sender, CommandEventArgs e)
      {

          string type = e.CommandName;
          string itemID = e.CommandArgument.ToString();
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

          if (bll.submit(typeInt, int.Parse(itemID), "1"))
          {
              //
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('项目提交成功，请等待审核！')</script>");
          }
          else
          {
              Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('项目提交失败！')</script>");
          }
          bindGridView();
      }
    
}