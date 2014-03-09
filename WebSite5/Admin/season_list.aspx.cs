using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Dal;
using System.Data;
using Model;

public partial class Admin_season_list : System.Web.UI.Page
{
    public int myNowyear = Convert.ToInt32(System.DateTime.Now.Year);
    public int myNowMonth = Convert.ToInt32(System.DateTime.Now.Month);
    public int myNowSeason = new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month),Convert.ToInt32(System.DateTime.Now.Day));

    public Admin_season_list()
    {
        if (System.DateTime.Now.Month>1&&System.DateTime.Now.Day < 6)
        {
            myNowMonth = myNowMonth - 1;
        }
        if (System.DateTime.Now.Month == 1 && System.DateTime.Now.Day < 6)
        {
            myNowyear = myNowyear - 1;
            myNowMonth = 12;
        }
      
    }
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
        if (Request.QueryString["itemtype"] != null && Request.QueryString["itemtype"].ToString() != null)
        {
            SeasonBll bll = new SeasonBll();
            int year = myNowyear;
            //string area = Request.QueryString["area"].ToString();
            string itemtype = Request.QueryString["itemtype"].ToString();
           // bll.select( year,area, itemtype);
            Label5.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString());
            Label6.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString());
            Label7.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString());
            Label8.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString());
            Button3.Enabled = false;
            Button2.Enabled = false;
            Button1.Enabled = false;
            Button4.Enabled = false;
            switch (myNowSeason)
            {
                case 1:
                    Button1.Enabled = true;
                    break;
                case 2:
                    Button2.Enabled = true;
                    break;
                case 3:
                    Button3.Enabled = true;
                    break;
                case 4:
                    Button4.Enabled = true;
                    break;
                default:
                    break;
            }
        }
        else
        {
        }
        bindSelect();

    }


    public void bindSelect()
    {
        SeasonBll bll = new SeasonBll();
        DataTable dt = bll.select(myNowyear, ((DataTable)Session["userEntity_logined"]).Rows[0]["area"].ToString(), Request.QueryString["itemtype"].ToString());
       DateTimeUtil util = new DateTimeUtil();

       Button9.Enabled = false;
       Button10.Enabled = false;
       Button11.Enabled = false;
       Button12.Enabled = false;

       Button5.Enabled = false;
       Button6.Enabled = false;
       Button7.Enabled = false;
       Button8.Enabled = false;
      

       for (int i = 0; i < dt.Rows.Count; i++)
       {

           switch (myNowSeason)
           {
               case 1:
                   Button9.CommandName = dt.Rows[i]["ID"].ToString();
                   Label1.Text = dt.Rows[i]["submittime"].ToString();
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "0")
                   {
                       Button5.Enabled = true;
                       Button5.CommandName = dt.Rows[i]["ID"].ToString();
                   }
                   Button9.Enabled = true;
                   Button1.CommandName = dt.Rows[i]["ID"].ToString();
                   Button1.Text = "修改";
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1")
                       Button1.Enabled = false;
                   break;
               case 2:
                   Button10.CommandName = dt.Rows[i]["ID"].ToString();
                   Label2.Text = dt.Rows[i]["submittime"].ToString();
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "0")
                   {
                       Button6.Enabled = true;
                       Button6.CommandName = dt.Rows[i]["ID"].ToString();
                   }
                   Button10.Enabled = true;
                   Button2.CommandName = dt.Rows[i]["ID"].ToString();
                   Button2.Text = "修改";
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1")
                       Button2.Enabled = false;
                   break;
               case 3:
                   Button11.CommandName = dt.Rows[i]["ID"].ToString();
                   Label3.Text = dt.Rows[i]["submittime"].ToString();
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "0")
                   {
                       Button7.Enabled = true;
                       Button7.CommandName = dt.Rows[i]["ID"].ToString();
                   }
                   Button11.Enabled = true;
                   Button3.CommandName = dt.Rows[i]["ID"].ToString();
                   Button3.Text = "修改";
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1")
                       Button3.Enabled = false;
                   break;
               case 4:
                   Button12.CommandName = dt.Rows[i]["ID"].ToString();
                   Label4.Text = dt.Rows[i]["submittime"].ToString();
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "0")
                   {
                       Button8.Enabled = true;
                       Button8.CommandName = dt.Rows[i]["ID"].ToString();
                   }
                   Button12.Enabled = true;
                   Button4.CommandName = dt.Rows[i]["ID"].ToString();
                   Button4.Text = "修改";
                   if (dt.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1")
                       Button4.Enabled = false;
                   break;
               default: break;
           }
       }
    } 
    /// <summary>
    /// 第一季度提交
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {
       
    }
   
  /// <summary>
  /// 查看
  /// </summary>
  /// <param name="sender"></param>
  /// <param name="e"></param>
    protected void Button9_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
    }

    /// <summary>
    /// 查看
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button10_Command(object sender, CommandEventArgs e)
    {
       Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
    }
    /// <summary>
    /// 查看
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button11_Command(object sender, CommandEventArgs e)
    {
       Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
    }
    /// <summary>
    /// 查看
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button12_Command(object sender, CommandEventArgs e)
    {
       Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
       
    }


    protected void Button1_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("season_report.aspx?itemtype=" + Request.QueryString["itemtype"] + "&year=" + System.DateTime.Now.Year + "&eason=" + new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month))+"&reportid="+e.CommandName);
    }
    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("season_report.aspx?itemtype=" + Request.QueryString["itemtype"] + "&year=" + System.DateTime.Now.Year + "&eason=" + new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month)) + "&reportid=" + e.CommandName);
    }
    protected void Button3_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("season_report.aspx?itemtype=" + Request.QueryString["itemtype"] + "&year=" + System.DateTime.Now.Year + "&eason=" + new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month)) + "&reportid=" + e.CommandName);
    }

    protected void Button4_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("season_report.aspx?itemtype=" + Request.QueryString["itemtype"] + "&year=" + System.DateTime.Now.Year + "&eason=" + new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month)) + "&reportid=" + e.CommandName);
    }


    protected void Button6_Command(object sender, CommandEventArgs e)
    {
        SeasonBll bll = new SeasonBll();
        SeasonReportForWordEntity en=new SeasonReportForWordEntity();
        en.Id=Convert.ToInt32(e.CommandName);
        en.SubmitState="1";
        bll.submit(en);
        bind();

    }
    protected void Button5_Command(object sender, CommandEventArgs e)
    {
        SeasonBll bll = new SeasonBll();
        SeasonReportForWordEntity en = new SeasonReportForWordEntity();
        en.Id = Convert.ToInt32(e.CommandName);
        en.SubmitState = "1";
        bll.submit(en);
        bind();
    }
    protected void Button7_Command(object sender, CommandEventArgs e)
    {
        SeasonBll bll = new SeasonBll();
        SeasonReportForWordEntity en = new SeasonReportForWordEntity();
        en.Id = Convert.ToInt32(e.CommandName);
        en.SubmitState = "1";
        bll.submit(en);
        bind();
    }
    protected void Button8_Command(object sender, CommandEventArgs e)
    {
        SeasonBll bll = new SeasonBll();
        SeasonReportForWordEntity en = new SeasonReportForWordEntity();
        en.Id = Convert.ToInt32(e.CommandName);
        en.SubmitState = "1";
        bll.submit(en);
        bind();
    }
  
}