using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;


public partial class Admin_itemst_season_add : System.Web.UI.Page
{
    public string projNum = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack){
            bind();
        }
    }
   


    

    public void bind()
    {


        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
            ItemBll bll = new ItemBll();
            DataTable dt = bll.selectByID(1, Convert.ToInt32(Request.QueryString["projectID"]));
            if (dt.Rows.Count > 0)
            {
                Label1.Text = dt.Rows[0]["area"].ToString();//所属区县
                Label2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                Label3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                Label4.Text = dt.Rows[0]["CONSTRUCTIONAGE"].ToString();//建设年限
                Label5.Text = dt.Rows[0]["CONSTRUCTIONTYPE"].ToString().Trim()=="1"?"新建":"续建";//建设性质
                Label6.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//建设内容及规模
                Label7.Text = dt.Rows[0]["TOTLEMONEY"].ToString();//总投资
                Label8.Text = dt.Rows[0]["CENTRALMONEY"].ToString();//中央资金
                Label9.Text = dt.Rows[0]["PROVINCIALMONEY"].ToString();//省级资金
                Label10.Text = dt.Rows[0]["MUNICIPALMONEY"].ToString();//市级资金
                Label11.Text = dt.Rows[0]["DISTRICTMONEY"].ToString();//区县资金
                Label12.Text = dt.Rows[0]["BANKLOAN"].ToString();//银行贷款
                Label13.Text = dt.Rows[0]["COMPANYSELF"].ToString();//企业自筹
                Label14.Text = dt.Rows[0]["CAINVESTMENT"].ToString();//至2011年累计完成投资
                Label15.Text = dt.Rows[0]["PLANINVESTMENT"].ToString();//2012年计划投资
                TextBox21.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前为止项目形象进度
                Label16.Text = dt.Rows[0]["PREDICTSTARTTIME"].ToString();//开工（计划开工）时间
                Label17.Text = dt.Rows[0]["PREDICTFINISHTIME"].ToString();//计划竣工时间
                DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批统筹
                Label18.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已取得土地指标
                Label19.Text = dt.Rows[0]["PLANLANDTARGETS"].ToString();//拟申请土地指标
                Label20.Text = dt.Rows[0]["GOVERNMENTPROJE"].ToString()=="0"?"是":"否";//是否政府投资项目

                TextBox22.Text = dt.Rows[0]["thismonth_investment"].ToString();//7月累计完成投资
                DevelopDirectionText.Text = dt.Rows[0]["PROBLEMS"].ToString();//需协调解决的问题
                TextBox16.Text = dt.Rows[0]["REMARK"].ToString();//备注


            }

        }
    }
    protected void Button1_svae(object sender, EventArgs e)
    {
        //判断是新增还是修改 
        if ((Request.QueryString["projectID"] != null) && (Request.QueryString["projectID"].ToString() != ""))
        {
            ItemstSeasonReportEntity itemst = new ItemstSeasonReportEntity();
            ItemReportBll bll = new ItemReportBll();
            itemst.ProjectId = Convert.ToInt32(Request.QueryString["projectID"]);
            itemst.LoginName = Session["user_loginName"].ToString().Trim();
            itemst.ProgressNow = TextBox21.Text.Trim();
            itemst.ProgressCategory = DropDownList1.SelectedValue.Trim();
            itemst.Problems = DevelopDirectionText.Text.Trim();
            itemst.Remark = TextBox16.Text.Trim();


            float invest;
            if(float.TryParse(TextBox22.Text.Trim(),out invest)){
            itemst.InvestmentPosition = invest;

            }else{
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('资金格式输入错误！')</script>");
                return;
            }
            itemst.Image1 = "";
            itemst.Image2 = "";
            itemst.Image3 = "";
            itemst.Image4 = "";
            itemst.Image5 = "";

            if (bll.add(2, itemst))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！')</script>");
                Response.Redirect("itemst_season_manage.aspx?projectID=" + itemst.ProjectId);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！')</script>");
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('无法获取到项目标号，无法执行创建报告的操作！')</script>");
        }
      
    }
}