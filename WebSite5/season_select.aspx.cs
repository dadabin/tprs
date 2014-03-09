using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Dal;

public partial class season_select : System.Web.UI.Page
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

   
    //导出word
    protected void Button1_Click(object sender, EventArgs e)
    {
        new WordDown().downLoadWord(Label1.Text, Label2.Text.Replace("<br/>", Convert.ToChar(10).ToString()).Replace("&nbsp;", Convert.ToChar(32).ToString()), Response);
    }

    public void bind()
    {
        if (Request.QueryString["reportid"] != null && Request.QueryString["reportid"].ToString() != "")
        {
            SeasonBll bll = new SeasonBll();
           DataTable dt= bll.queryById(Convert.ToInt32(Request.QueryString["reportid"]));
           if (dt.Rows.Count > 0)
           {
               Label1.Text = new ConstantChangeUtil().areaChange(dt.Rows[0]["AREA"].ToString()) + new ConstantChangeUtil().itemType(dt.Rows[0]["ITEMTYPE"].ToString()) + "第" + new DateTimeUtil().getStringByMoth(Convert.ToInt32(dt.Rows[0]["month"])) + "季度季报";
               Label2.Text = dt.Rows[0]["SEASONCOMMENT"].ToString().Replace(Convert.ToChar(10).ToString(), "<br/>").Replace(Convert.ToChar(32).ToString(), "&nbsp;");

               if (dt.Rows[0]["AREA"].ToString() == "cd")
               {
                   bindlist();
               }
           }
        }

    }

    public void bindlist()
    {
        if (((DataTable)Session["userEntity_logined"]).Rows[0]["roleID"].ToString() == "2")
        {
            string reportlist = "区县已提交的当期季报：";
            SeasonBll bll = new SeasonBll();
            DataTable dt = bll.selectadminByType(Convert.ToInt32(System.DateTime.Now.Year),int.Parse( Request.QueryString["reportid"].ToString()), new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month)));
            for (int i = 0; i < dt.Rows.Count; i++)
                reportlist += ("" + "<input type='button'  style=\"font-size: 13px; color: #f7f8fb; background-color: #2480F1;\" value='" + new ConstantChangeUtil().areaChange(dt.Rows[i]["area"].ToString())  +"'\"  onclick=\" openwin('" + dt.Rows[i]["id"] + "')\"/>" + "&nbsp;&nbsp;");
            Label3.Text = reportlist;

           
        }
    }
}