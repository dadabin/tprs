using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_user_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            if (Request.QueryString["adminID"] != null && Request.QueryString["adminID"].ToString() != "")
            {
                //获取参数
                string loginName = Request.QueryString["adminID"];
                UserBll bll = new UserBll();
                DataTable dt = bll.selectByLoginName (4,Request.QueryString["adminID"].ToString().Trim());
                if (dt.Rows.Count > 0)
                {
                    //输出到页面
                    TextBox3.Text = dt.Rows[0]["PASSWORD"].ToString();
                    TextBox1.Text = dt.Rows[0]["USERNAME"].ToString();
                    TextBox4.Text = dt.Rows[0]["UNITNAME"].ToString(); //单位
                    TextBox5.Text = dt.Rows[0]["LEGALREPRE"].ToString(); //法人
                    TextBox6.Text = dt.Rows[0]["BUSINESSCONTACT"].ToString(); //业务联系人
                    TextBox7.Text = dt.Rows[0]["PHONE"].ToString(); //电话
                    if (dt.Rows[0]["AREA"].ToString() == "lqy")
                    {
                        Label1.Text = "龙泉驿区";
                    }
                    else if (dt.Rows[0]["AREA"].ToString() == "jt")
                    {
                        Label1.Text = "金堂县";
                    }
                    else if (dt.Rows[0]["AREA"].ToString() == "xj")
                    {
                        Label1.Text = "新津县";
                    }
                    else if (dt.Rows[0]["AREA"].ToString() == "sl")
                    {
                        Label1.Text = "双流县";
                    }
                    else if (dt.Rows[0]["AREA"].ToString() == "qbj")
                    {
                        Label1.Text = "青白江区";
                    }
                    //所属区县
                    TextBox9.Text = dt.Rows[0]["REGISTMONEY"].ToString(); //注册资金
                    TextBox10.Text = dt.Rows[0]["REGISTAREA"].ToString(); //注册地址
                    TextBox11.Text = dt.Rows[0]["EMAIL"].ToString(); //电子邮箱
                    TextBox12.Text = dt.Rows[0]["BUSINESSAREA"].ToString();  //营业范围
                    Label2.Text = dt.Rows[0]["LOGINNAME"].ToString();

                }

            }
        }

    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        /// <summary>
        /// 从页面上获取属性
        /// </summary>
        String userName = TextBox1.Text.Trim();// 用户姓名
        String loginName = Label2.Text.Trim();// TextBox2.Text.Trim();// 用户登陆名
        String password = TextBox3.Text.Trim();// 用户密码
        String unitName = TextBox4.Text.Trim();// 单位名称
        String legalRepre = TextBox5.Text.Trim();// 法人联系人
        String businessContact = TextBox6.Text.Trim();// 业务联系人
        String phone = TextBox7.Text.Trim();// 电话
        String area = "";//DropDownList1.SelectedValue;//区县
        float registMoney;//注册资金
        if (!float.TryParse(TextBox9.Text.Trim().ToString(), out registMoney))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('注册资金输入有误！');</script>");
        }
        else
        {
            registMoney = 0;//注册资金
        }
        String registArea = TextBox10.Text.Trim();//注册地址
        String email = TextBox11.Text.Trim();//邮箱
        String businessArea = TextBox12.Text.Trim();//营业范围
        StringUtills strUtil = new StringUtills();
        //if (strUtil.strLength(TextBox2.Text, 50))
        //{
        //    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
        //    return;
        //}


        if (strUtil.strLength(TextBox1.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(TextBox3.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }

        /// <summary>
        /// 判断是否用户名、用户登录名、用户密码是否为空
        /// </summary>
        if (userName == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('请输入姓名！');</script>");
        }
        else if (loginName == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('请输入登录名！');</script>");
        }
        else if (password == "")
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('请输入密码！');</script>");
        }
        else
        {
            /// <summary>
            /// 定义实体
            /// </summary>
            UserEntity en = new UserEntity();
            en.UserName = userName;// 用户姓名
            en.LoginName = loginName;//用户登陆名
            en.Password = password;//用户密码
            en.UnitName = unitName;//单位名称
            en.LegalRepre = legalRepre;//法人联系人
            en.BusinessContact = businessContact;//业务联系人
            en.Phone = phone;//电话
            en.Area = area;//区县
            en.RegistMoney = registMoney.ToString();//注册资金
            en.RegistArea = registArea;//注册地址
            en.Email = email;//邮箱
            en.BusinessArea = businessArea;//营业范围
            en.RoleID = 4;
            /// <summary>
            /// 添加实体
            /// </summary>

            UserBll userbll = new UserBll();
            bool flag = userbll.updateUser(4,en);
            if (flag == true)
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！');</script>");
                Response.Redirect("user_manage.aspx");

            }else
            {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！');</script>");
            }
          }

    }
}