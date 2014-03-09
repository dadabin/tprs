using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;
using Dal;

public partial class Admin_view_itembh_view_season : System.Web.UI.Page
{
    public DateTime reportTime;
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
            //ItemReportBll bll = new ItemReportBll();
            //DataTable dt = bll.getReportByID(3, int.Parse(Request.QueryString["id"]));
            StringUtills utils = new StringUtills();
            ItemReportBll bll = new ItemReportBll();
            DataTable dt = bll.selectReportById(3, int.Parse(Request.QueryString["id"]));



            if (dt.Rows.Count > 0)
            {
                Label23.Text = dt.Rows[0]["qx"].ToString();//
                Label1.Text = dt.Rows[0]["PROJECTNAME"].ToString();//工程名称
                Label2.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                Label3.Text = dt.Rows[0]["FINISHTIME1"].ToString();//完工时间
                Label4.Text = dt.Rows[0]["ZONEAREA"].ToString();//水域面积
                Label5.Text = dt.Rows[0]["PROVINCIALEVELFISCAL"].ToString();//省级以上财政
                Label6.Text = dt.Rows[0]["MUNICIPALFINANCE"].ToString();//市级以上财政
                Label7.Text = dt.Rows[0]["COUNTYFINANCE"].ToString();//县级财政
                Label8.Text = dt.Rows[0]["FINANCEFINANCE"].ToString();//财政融资
                Label9.Text = dt.Rows[0]["SOCIALINVESTMENT"].ToString();//社会投入
                Label10.Text = dt.Rows[0]["PUBLICINVESTMENT"].ToString();//群众投入
                Label11.Text = dt.Rows[0]["OTHER"].ToString();//其他
                Label12.Text = dt.Rows[0]["OCCUPIEDAREA"].ToString();//占用土地面积
                Label13.Text = dt.Rows[0]["OCCUPIEDTYPE"].ToString();//占用方式
                if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "lz")
                {
                    Label13.Text = "流转";
                }
                else if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "zy")
                {
                    Label13.Text = "征用";
                }
                else if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "lz&zy")
                {
                    Label13.Text = "流转及征用";
                }
                else
                {
                    Label13.Text = "";
                }
              
                Label14.Text = dt.Rows[0]["UNITPRICE"].ToString();//单价
                Label15.Text = dt.Rows[0]["MANAGESUBJECT"].ToString();//管护主体

                String pro = dt.Rows[0]["PROGRESSCATEGORY"].ToString();
                if(pro.Trim()=="yc"){
                   Label16.Text ="已成";//四个一批范畴
                }
                else if (pro.Trim() == "zj")
                {
                    Label16.Text = "在建";
                }
                else if (pro.Trim() == "gh")
                {
                    Label16.Text = "规划";
                }
                Label17.Text = dt.Rows[0]["IMAGEPROGRESS"].ToString();


                reportTime = DateTime.Parse(dt.Rows[0]["REPORTTIME"].ToString());
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


        //补充要修改的内容
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            ItemReportBll rebll = new ItemReportBll();
            DataTable redt = rebll.select(3, Convert.ToInt32(Request.QueryString["id"]));
            if (redt.Rows.Count > 0)
            {
                
                ////    .Text = redt.Rows[0]["SUBTOTAL"].ToString();
                //Label16.Text = redt.Rows[0]["PROGRESSCATEGORY"].ToString();
                //String pro = redt.Rows[0]["PROGRESSCATEGORY"].ToString();
                //if (pro.Trim() == "yc")
                //{
                //    Label16.Text = "已成";//四个一批范畴
                //}
                //else if (pro.Trim() == "zj")
                //{
                //    Label16.Text = "在建";
                //}
                //else if (pro.Trim() == "gh")
                //{
                //    Label16.Text = "规划";
                //}
                //Label17.Text = redt.Rows[0]["IMAGEPROGRESS"].ToString();


            }
        }
    }
}