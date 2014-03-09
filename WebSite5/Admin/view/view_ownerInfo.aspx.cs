using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using System.Data;

public partial class Admin_view_view_ownerInfo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if(Request.QueryString["LOGINNAME"] != null && Request.QueryString["LOGINNAME"].ToString()!="")
            {
               //获取参数
                string loginName = Request.QueryString["LOGINNAME"];
                UserBll bll = new UserBll();
                DataTable dt =  bll.selectByLoginName(4,loginName);
                if(dt.Rows.Count > 0)
                {
                    //输出到页面
                    Label10.Text = dt.Rows[0]["USERNAME"].ToString(); //姓名
                    Label1.Text = dt.Rows[0]["UNITNAME"].ToString(); //单位
                    Label2.Text = dt.Rows[0]["LEGALREPRE"].ToString(); //法人
                    Label3.Text = dt.Rows[0]["BUSINESSCONTACT"].ToString(); //业务联系人
                    Label4.Text = dt.Rows[0]["PHONE"].ToString(); //电话
                    if(dt.Rows[0]["AREA"].ToString()=="lqy"){
                         Label5.Text = "龙泉驿区";
                    }else if(dt.Rows[0]["AREA"].ToString()=="jt"){
                         Label5.Text = "金堂县";
                    }else if(dt.Rows[0]["AREA"].ToString()=="xj"){
                         Label5.Text = "新津县";
                    }else if(dt.Rows[0]["AREA"].ToString()=="sl"){
                         Label5.Text = "双流县";
                    }else if(dt.Rows[0]["AREA"].ToString()=="qbj"){
                         Label5.Text ="青白江区" ;
                    }
                    //所属区县
                    Label6.Text = dt.Rows[0]["REGISTMONEY"].ToString(); //注册资金
                    Label7.Text = dt.Rows[0]["REGISTAREA"].ToString(); //注册地址
                    Label8.Text = dt.Rows[0]["EMAIL"].ToString(); //电子邮箱
                    Label9.Text = dt.Rows[0]["OFFICEPHONE"].ToString();  //营业范围


                
                }

            }

        }
    }
}