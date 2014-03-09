using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Dal;
using System.Data;

public partial class Admin_season_report_admin : System.Web.UI.Page
{
    public Admin_season_report_admin()
    {
        if (System.DateTime.Now.Month==1&&System.DateTime.Now.Day > 7)
        {
            myNowyear = myNowyear - 1;
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


    public int myNowyear = Convert.ToInt32(System.DateTime.Now.Year);

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
        }
        else
        {
        }

        bindSelect();

    }
    public void bindSelect()
    {
        SeasonBll bll = new SeasonBll();
        DataTable dt = bll.select(Convert.ToInt32(System.DateTime.Now.Year), ((DataTable)Session["userEntity_logined"]).Rows[0]["area"].ToString(), Request.QueryString["itemtype"].ToString());
        DateTimeUtil util = new DateTimeUtil();

        Button9.Enabled = false;
        Button10.Enabled = false;
        Button11.Enabled = false;
        Button12.Enabled = false;

        for (int i = 0; i < dt.Rows.Count; i++)
        {
            int x = util.getSeasonByMonty(Convert.ToInt32(dt.Rows[i]["month"]));
            switch (x)
            {
                case 1:
                    Button9.CommandName = dt.Rows[i]["ID"].ToString();
                    Label1.Text = dt.Rows[i]["submittime"].ToString();
                    if (dt.Rows[i]["submitstate"].ToString().Trim() == "1")
                    Button9.Enabled = true;
                    break;
                case 2:
                    Button10.CommandName = dt.Rows[i]["ID"].ToString();
                    Label2.Text = dt.Rows[i]["submittime"].ToString();
                    if (dt.Rows[i]["submitstate"].ToString().Trim() == "1")
                    Button10.Enabled = true;
                    
                    break;
                case 3:
                    Button11.CommandName = dt.Rows[i]["ID"].ToString();
                    Label3.Text = dt.Rows[i]["submittime"].ToString();
                    if (dt.Rows[i]["submitstate"].ToString().Trim() == "1")
                    Button11.Enabled = true;
                    
                    break;
                case 4:
                    Button12.CommandName = dt.Rows[i]["ID"].ToString();
                    Label4.Text = dt.Rows[i]["submittime"].ToString();
                    if(dt.Rows[i]["submitstate"].ToString().Trim()=="1")
                    Button12.Enabled = true;
                    break;
                default: break;
            }
        }
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
    protected void Button11_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
    }
    
    protected void Button12_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("../season_select.aspx?reportid=" + e.CommandName);
    }
}