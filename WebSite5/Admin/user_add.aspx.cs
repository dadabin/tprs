using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Model;
using Bll;
using Dal;

public partial class Admin_user_add : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
        }

    }
    
    protected void Button1_Click1(object sender, EventArgs e)
    {
        /// <summary>
        /// 从页面上获取属性
        /// </summary>
        String userName = TextBox1.Text.Trim();// 用户姓名
        String loginName = TextBox2.Text.Trim();// 用户登陆名
        String password = TextBox3.Text.Trim();// 用户密码

        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(TextBox2.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('账号不能长于25！')</script>");
            return;
        }
        if (strUtil.strLength(TextBox3.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('密码名不能长于25！')</script>");
            return;
        }


        if (strUtil.strLength(TextBox1.Text, 26))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('姓名不能长于25！')</script>");
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
            en.RoleID = 4;
            if (Session["user_loginName"] != null && Session["user_loginName"].ToString() != "")
            {
                /// <summary>
                /// 添加实体
                /// </summary>
                en.Admin = Session["user_loginName"].ToString();
                UserBll userbll = new UserBll();
                if (userbll.isUse(en))
                {
                    bool flag = userbll.addUser(en, 4);
                    if (flag == true)
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！');</script>");
                        Response.Redirect("user_manage.aspx");
                    }
                    else
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！');</script>");
                    }
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('用户名已存在！')</script>");
        
                }
            }

          }

    }
}