using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Dal;
public partial class Admin_view_itemst_view_project : System.Web.UI.Page
{
    public DateTime submitTime;


    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!IsPostBack)
        {
            bind();
           
        }
    }

    public void bind()
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {

            StringUtills utils = new StringUtills();
            ItemBll bll = new ItemBll();
            DataTable dt = bll.selectByID(1,int.Parse(Request.QueryString["id"].ToString().Trim()));
            if (dt.Rows.Count > 0) {
                Label1.Text = utils.getChineseLocaltion(dt.Rows[0]["area"].ToString());//区县
                Label2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                Label3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址


                Label4.Text = dt.Rows[0]["CONSTRUCTIONAGE"].ToString();//建设年限
                Label5.Text = (dt.Rows[0]["CONSTRUCTIONTYPE"].ToString().Trim() == ("1")) ? "新建" : "续建";//建设性质

                Label6.Text  = dt.Rows[0]["CONTENTSCALE"].ToString();//建设内容及规模
                Label12.Text = dt.Rows[0]["TOTLEMONEY"].ToString();//总投资
                Label13.Text = dt.Rows[0]["CENTRALMONEY"].ToString();//中央资金
                Label14.Text = dt.Rows[0]["PROVINCIALMONEY"].ToString();//省级资金
                Label15.Text = dt.Rows[0]["MUNICIPALMONEY"].ToString();//市级资金
                Label16.Text = dt.Rows[0]["DISTRICTMONEY"].ToString();//区县资金
                Label17.Text = dt.Rows[0]["BANKLOAN"].ToString();//银行贷款
                Label18.Text = dt.Rows[0]["COMPANYSELF"].ToString();//企业自筹


                Label19.Text = dt.Rows[0]["thisyear_investment"].ToString();//至2011年底累计完成投资
                Label20.Text = dt.Rows[0]["plane_investment"].ToString();//2012年计划投资
               
                Label21.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前为止形象进度
                Label22.Text = dt.Rows[0]["PREDICTSTARTTIME"].ToString();//开工（计划开工）时间
                Label23.Text = dt.Rows[0]["PREDICTFINISHTIME"].ToString();//计划竣工
                Label24.Text = utils.getChineseProgress(dt.Rows[0]["PROGRESSCATEGORY"].ToString().Trim());//四个一批范畴
                Label25.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已取得土地指标
                Label26.Text = dt.Rows[0]["PLANLANDTARGETS"].ToString();//拟申请土地指标
                Label27.Text = dt.Rows[0]["GOVERNMENTPROJE"].ToString().Trim()=="1"?"是":"否";//是否政府投资项目

                Label28.Text = dt.Rows[0]["premonthes_investment"].ToString();//1-7月累计完成投资
               Label29.Text = dt.Rows[0]["thismonth_investment"].ToString();//7月累计完成投资额

                Label30.Text = dt.Rows[0]["PROBLEMS"].ToString();//需要协调解决的问题
                Label31.Text = dt.Rows[0]["REMARK"].ToString();//备注

                submitTime = DateTime.Parse(dt.Rows[0]["SUBMITTIME"].ToString().Trim());//年份时间

                DataTable dtpic = new DataTable();
                dtpic.Columns.Add("path", typeof(string));
                for (int i = 0; i < 5; i++)
                {
                    DataRow r1 = dtpic.NewRow();
                    r1["path"] = dt.Rows[0]["IMAGE" + (i + 1)];
                    dtpic.Rows.Add(r1);
                }
                DataList1.DataSource = dtpic;
                DataList1.DataBind();
            }
        }
    }
}