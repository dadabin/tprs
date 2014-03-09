using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;

public partial class Admin_view_itembh_view_project : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bind();
    }

    public void bind()
    {
        if (Request.QueryString["id"] != null&&Request.QueryString["id"].ToString()!="")
        {
            ItemBll bll = new ItemBll();
            DataTable dt = bll.selectByID(3, int.Parse(Request.QueryString["id"].ToString().Trim()));
           
            if(dt.Rows.Count > 0)
            {
                Label2.Text = dt.Rows[0]["area"].ToString();//区县

                if (dt.Rows[0]["AREA"].ToString() == "lqy")
                {
                    Label2.Text = "龙泉驿区";
                }
                else if (dt.Rows[0]["AREA"].ToString() == "jt")
                {
                    Label2.Text = "金堂县";
                }
                else if (dt.Rows[0]["AREA"].ToString() == "xj")
                {
                    Label2.Text = "新津县";
                }
                else if (dt.Rows[0]["AREA"].ToString() == "sl")
                {
                    Label2.Text = "双流县";
                }
                else if (dt.Rows[0]["AREA"].ToString() == "qbj")
                {
                    Label2.Text = "青白江区";
                }
                Label3.Text = dt.Rows[0]["PROJECTNAME"].ToString();//工程名称
                Label4.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址

                Label5.Text = dt.Rows[0]["FINISHTIME"].ToString();//完工时间
                Label6.Text = dt.Rows[0]["ZONEAREA"].ToString();//水域面积
                Label7.Text = dt.Rows[0]["PROVINCIALEVELFISCAL"].ToString();//省级以上财政
                Label8.Text = dt.Rows[0]["MUNICIPALFINANCE"].ToString();//市级财政
                Label9.Text = dt.Rows[0]["COUNTYFINANCE"].ToString();//县级财政
                Label10.Text = dt.Rows[0]["FINANCEFINANCE"].ToString();//财政融资
                Label11.Text = dt.Rows[0]["SOCIALINVESTMENT"].ToString();//社会投入
                Label12.Text = dt.Rows[0]["PUBLICINVESTMENT"].ToString();//群众投入
                Label13.Text = dt.Rows[0]["OTHER"].ToString();//其他
                Label14.Text = dt.Rows[0]["OCCUPIEDAREA"].ToString();//占用土地面积

                Label15.Text = (dt.Rows[0]["OCCUPIEDTYPE"].ToString());//占用方式
                if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "lz")
                {
                    Label15.Text = "流转";
                }
                else if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "zy")
                {
                    Label15.Text = "征用";
                }
                else if (dt.Rows[0]["OCCUPIEDTYPE"].ToString().Trim() == "lz&zy")
                {
                    Label15.Text = "流转及征用";
                }
                else
                {
                    Label15.Text = "";
                }
                Label16.Text = dt.Rows[0]["UNITPRICE"].ToString();//单价
                Label17.Text = dt.Rows[0]["IMAGEPROGRESS"].ToString();//目前工程的形象进度
                Label18.Text = dt.Rows[0]["MANAGESUBJECT"].ToString();//管护主体

               
                String pro = dt.Rows[0]["PROGRESSCATEGORY"].ToString();
                if (pro.Trim() == "yc")
                {
                    Label19.Text = "已成";//四个一批范畴
                }
                else if (pro.Trim() == "zj")
                {
                    Label19.Text = "在建";
                }
                else if (pro.Trim() == "gh")
                {
                    Label19.Text = "规划";
                }
                DataTable dtpic = new DataTable();
                dtpic.Columns.Add("path", typeof(string));
                for (int i = 0; i < 5; i++)
                {
                    DataRow r1 = dtpic.NewRow();
                    r1["path"] = dt.Rows[0]["IMAGE"+(i+1)];
                    dtpic.Rows.Add(r1);
                }
                DataList1.DataSource = dtpic;
                DataList1.DataBind();

            
            }

          

           



        }


    }
}