using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;

public partial class Admin_excel_report_admin2 : System.Web.UI.Page
{
    public Admin_excel_report_admin2()
    {
        if (System.DateTime.Now.Month==1&&System.DateTime.Now.Day <= 6)
        {
            myNowYear = myNowYear - 1;
            myPreYear = myPreYear - 1;
        }
    }

    public int myNowYear = int.Parse(new DateTimeUtil().getNowYear());
    public int myPreYear = new DateTimeUtil().getPreYear();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
           // initTime();
             bind();
           
        }

    }
    /// <summary>
    /// 绑定
    /// </summary>
    public void bind()
    {
        season.Visible = false;
        month.Visible = false;
        DateTimeUtil dateTimeUtil=new DateTimeUtil();
        int preYear = dateTimeUtil.getPreYear();
        int nowYear = myNowYear;
        if (Request.QueryString["itemtype"] != null)
        {
            string role= Session["RoleID"].ToString().Trim() ;
            if (Request.QueryString["itemtype"].ToString().Trim() == "st")
            {
                //控制是否可以使用的控件
                month.Visible = true;
                Button5.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=1&role=" + role + "');";
                Button6.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=2&role=" + role + "');";
                Button7.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=3&role=" + role + "');";
                Button8.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=4&role=" + role + "');";
                Button9.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=5&role=" + role + "');";
                Button10.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=6&role=" + role + "');";
                Button11.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=7&role=" + role + "');";
                Button12.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=8&role=" + role + "');";
                Button13.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=9&role=" + role + "');";
                Button14.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=10&role=" + role + "');";
                Button15.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=11&role=" + role + "');";
                Button16.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=st&year=" + nowYear + "&month=12&role=" + role + "');";
            }
            else if (Request.QueryString["itemtype"].ToString().Trim() == "jg")
            {
                season.Visible = true;

                //控制是否可使用的控件
                Label1.Text = "龙泉办景观农业项目（" + nowYear + "年第一季度）季报";
                Label2.Text = "龙泉办景观农业项目（" + nowYear + "年第二季度）季报";
                Label3.Text = "龙泉办景观农业项目（" + nowYear + "年第三季度）季报";
                Label4.Text = "龙泉办景观农业项目（" + nowYear + "年第四季度）季报";
                Button1.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=jg&year=" + nowYear + "&season=1&role=" + role + "');";
                Button2.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=jg&year=" + nowYear + "&season=2&role=" + role + "');";
                Button3.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=jg&year=" + nowYear + "&season=3&role=" + role + "');";
                Button4.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=jg&year=" + nowYear + "&season=4&role=" + role + "');";
                Button1.CommandName = "";
            }
            else if (Request.QueryString["itemtype"].ToString().Trim() == "bh")
            {
                season.Visible = true;
                Label1.Text = "龙泉办百湖工程项目（" + nowYear + "年第一季度）季报";
                Label2.Text = "龙泉办百湖工程项目（" + nowYear + "年第二季度）季报";
                Label3.Text = "龙泉办百湖工程项目（" + nowYear + "年第三季度）季报";
                Label4.Text = "龙泉办百湖工程项目（" + nowYear + "年第四季度）季报";
                Button1.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=bh&year=" + nowYear + "&season=1&role=" + role + "');";
                Button2.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=bh&year=" + nowYear + "&season=2&role=" + role + "');";
                Button3.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=bh&year=" + nowYear + "&season=3&role=" + role + "');";
                Button4.OnClientClick = "javascript:openExcelLoad('excel_load.aspx?itemtype=bh&year=" + nowYear + "&season=4&role=" + role + "');";
            }
        }

    }
    /// <summary>
    /// 季度报告Excel
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    
}