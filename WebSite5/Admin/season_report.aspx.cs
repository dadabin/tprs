using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dal;
using Model;
using System.Data;
using Bll;

public partial class Admin_season_report : System.Web.UI.Page
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



    protected void Button1_Click(object sender, EventArgs e)
    {
        if (!(Request.QueryString["year"]!=null&&Request.QueryString["eason"] != null && Request.QueryString["eason"].ToString() != null&&Request.QueryString["year"].ToString()!=""))
            return;
        Label1.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString()) + "第" + new ConstantChangeUtil().getBigNum(int.Parse(Request.QueryString["eason"].ToString())) + "季度";
        if (Request.QueryString["reportid"] != null && Request.QueryString["reportid"].ToString() != "")
        {
            //更新则加载数据
            SeasonBll bll = new SeasonBll();
            SeasonReportForWordEntity en = new SeasonReportForWordEntity();
            en.SeasonComment = TextBox1.Text;
            en.Id = Convert.ToInt32(Request.QueryString["reportid"]);
            if (bll.update(en))
            {
                Response.Redirect("season_list.aspx?itemtype=" + Request.QueryString["itemtype"]);
            }

        }
        else if (Request.QueryString["itemtype"] != null  && Request.QueryString["itemtype"].ToString() != "")
        {
            //填报数据
            //判断季度报告是否填写
            SeasonReportForWordEntity en = new SeasonReportForWordEntity();
            en.Area = ((DataTable)Session["userEntity_logined"]).Rows[0]["area"].ToString();
            en.SeasonComment = TextBox1.Text;
            en.LoginName = ((DataTable)Session["userEntity_logined"]).Rows[0]["loginname"].ToString();
            en.ItemType = Request.QueryString["itemtype"].Trim().ToString();
            SeasonBll bll = new SeasonBll();
            if (bll.isAddSeasonRep(en))
            {
                if (bll.add(en))
                {
                    Response.Redirect("season_list.aspx?itemtype=" + Request.QueryString["itemtype"]);
                }
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已经填写不能重复提交！')</script>");
            }
        }

      
    }

    public void bind()
    {
        if (!(Request.QueryString["year"] != null && Request.QueryString["eason"] != null && Request.QueryString["eason"].ToString() != null && Request.QueryString["year"].ToString() != ""))
            return;
        Label1.Text = new ConstantChangeUtil().itemType(Request.QueryString["itemtype"].ToString()) + "第" + new ConstantChangeUtil().getBigNum(int.Parse(Request.QueryString["eason"].ToString())) + "季度";
        if (Request.QueryString["reportid"] != null && Request.QueryString["reportid"].ToString() != "")
        {
            //更新则加载数据
            SeasonBll bll = new SeasonBll();
           DataTable dt= bll.queryById(Convert.ToInt32(Request.QueryString["reportid"]));
           if (dt.Rows.Count > 0)
           {
               TextBox1.Text = dt.Rows[0]["SEASONCOMMENT"].ToString();
           }

        }
        else if (Request.QueryString["itemtype"] != null && Request.QueryString["itemtype"].ToString() != "")
        {
            //填报数据
            //判断季度报告是否填写

        }
        
    }

    public void bindlist()
    {
        if (((DataTable)Session["userEntity_logined"]).Rows[0]["roleID"].ToString() == "2")
        {
            SeasonBll bll=new SeasonBll();
         
          DataTable dt=  bll.selectadmin(Convert.ToInt32(System.DateTime.Now.Year ),Request.QueryString["itemtype"].ToString(),new DateTimeUtil().getSeasonByMonty(Convert.ToInt32(System.DateTime.Now.Month)));
          Response.Write("区县已提交的当期季报：");
            for(int i=0;i<dt.Rows.Count;i++)
                //Response.Write("" + new ConstantChangeUtil().areaChange(dt.Rows[i]["area"].ToString())  + "<input type='button'  style=\"font-size: 13px; color: #f7f8fb; background-color: #2480F1;\" value='"+ new ConstantChangeUtil().itemType(dt.Rows[i]["itemtype"].ToString())+"'\"  onclick=\" openwin('" + dt.Rows[i]["id"] + "')\"/>" + "&nbsp;&nbsp;");
                Response.Write("" + "<input type='button'  style=\"font-size: 13px; color: #f7f8fb; background-color: #2480F1;\" value='" + new ConstantChangeUtil().areaChange(dt.Rows[i]["area"].ToString()) + "'\"  onclick=\" openwin('" + dt.Rows[i]["id"] + "')\"/>" + "&nbsp;&nbsp;");
            
            //<li>龙泉:</li>
            //<li>双流:</li>
            //<li>金堂:</li>
            //<li>青白江:</li>
            //<li>新津:</li>
        }
    }
}