using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Model;

public partial class Admin_updateInformation : System.Web.UI.Page
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

    public void bind()
    {
        table1.Visible = false;
        table2.Visible = false;
        table3.Visible = false;
        table4.Visible = false;

        if (Session["RoleID"] != null && Session["RoleID"].ToString() != "" && Session["user_loginName"] != null && Session["user_loginName"].ToString()!="")
        {
            UserBll bll = new UserBll();
            string loginName = Session["user_loginName"].ToString();
            switch (int.Parse(Session["RoleID"].ToString()))
            {
                case 1://市级领导
                    {
                        DataTable dt = bll.selectByLoginName(1, loginName);
                        if (dt.Rows.Count > 0)
                        {
                            Label2.Text = Session["user_loginName"].ToString();
                            TextBox1.Text = dt.Rows[0]["USERNAME"].ToString();//姓名
                            TextBox2.Text = dt.Rows[0]["OFFICEPHONE"].ToString();//办公室电话
                        }
                        table1.Visible = true;
                    } break;
                case 2://二级审核员
                    {
                        DataTable dt = bll.selectByLoginName(2, loginName);
                        if (dt.Rows.Count > 0)
                        {
                            Label3.Text = Session["user_loginName"].ToString();
                            TextBox3.Text = dt.Rows[0]["USERNAME"].ToString();//姓名
                            TextBox4.Text = dt.Rows[0]["PHONE"].ToString();
                            TextBox5.Text = dt.Rows[0]["EMAIL"].ToString();
                        }
                        table2.Visible = true;
                    } break;
                case 3://一级审核员
                    {
                        DataTable dt = bll.selectByLoginName(3, loginName);
                        if (dt.Rows.Count > 0)
                        {
                            TextBox14.Text = dt.Rows[0]["USERNAME"].ToString();//姓名
                            Label5.Text = Session["user_loginName"].ToString().Trim();//登陆账号
                            //Label4.Text = dt.Rows[0]["AREA"].ToString();//所属区县
                            if (dt.Rows[0]["AREA"].ToString() == "lqy")
                            {
                                Label4.Text = "龙泉驿区";
                            }
                            else if (dt.Rows[0]["AREA"].ToString() == "sl")
                            {
                                Label4.Text = "双流县";
                            }
                            else if (dt.Rows[0]["AREA"].ToString() == "qbj")
                            {
                                Label4.Text = "青白江区";
                            }
                            else if (dt.Rows[0]["AREA"].ToString() == "xj")
                            {
                                Label4.Text = "新津县";
                            }
                            else if (dt.Rows[0]["AREA"].ToString() == "jt")
                            {
                                Label4.Text = "金堂县";
                            }
                            TextBox15.Text = dt.Rows[0]["PHONE"].ToString();//电话号码
                            TextBox16.Text = dt.Rows[0]["EMAIL"].ToString();//邮箱
                        }
                        table3.Visible = true;
                    } break;
                case 4://业主
                    {
                        DataTable dt = bll.selectByLoginName(4, loginName);
                        if (dt.Rows.Count > 0)
                        {
                            
                            TextBox6.Text = dt.Rows[0]["USERNAME"].ToString();//姓名
                            TextBox17.Text = Session["user_loginName"].ToString().Trim();//登陆账号
                            if(dt.Rows[0]["AREA"].ToString()=="lqy"){
                                 Label1.Text = "龙泉驿区";
                            }else if(dt.Rows[0]["AREA"].ToString()=="sl"){
                                Label1.Text = "双流县";
                            }else if(dt.Rows[0]["AREA"].ToString()=="qbj"){
                                Label1.Text = "青白江区";
                            }else if(dt.Rows[0]["AREA"].ToString()=="xj"){
                                Label1.Text = "新津县";
                            }else if(dt.Rows[0]["AREA"].ToString()=="jt"){
                                Label1.Text = "金堂县";
                            }
                           //所属区县
                            TextBox7.Text = dt.Rows[0]["UNITNAME"].ToString();//单位名称
                            TextBox8.Text = dt.Rows[0]["LEGALREPRE"].ToString();//法人代表
                            TextBox9.Text = dt.Rows[0]["BUSINESSCONTACT"].ToString();//业务联系人
                            TextBox10.Text = dt.Rows[0]["REGISTMONEY"].ToString();//注册资金
                            TextBox11.Text = dt.Rows[0]["REGISTAREA"].ToString();//注册地址
                            TextBox12.Text = dt.Rows[0]["EMAIL"].ToString();//电子邮件
                            TextBox13.Text = dt.Rows[0]["BUSINESSAREA"].ToString();//营业范围

                        }
                        table4.Visible = true;
                    } break;
                default: break;
            }
        }
    }
    /// <summary>
    /// 市级领导
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        UserEntity user = new UserEntity();
        UserBll bll = new UserBll();
        user.LoginName = Session["user_loginName"].ToString().Trim();
        if (TextBox1.Text != null)
        {
            user.UserName = TextBox1.Text.Trim();
        }
        else
        {
            user.UserName = "";
        }
        if (TextBox2.Text != null)
        {
            user.OfficePhone = TextBox2.Text.Trim();
        }
        else
        {
            user.OfficePhone = "";
        }

        if (bll.updateUser(1, user))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
        }

    }
    /// <summary>
    /// 二级审核员
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button2_Click(object sender, EventArgs e)
    {
        UserEntity user = new UserEntity();
        UserBll bll = new UserBll();
        user.LoginName = Session["user_loginName"].ToString().Trim();
        if (TextBox3.Text != null)
        {
            user.UserName = TextBox3.Text.Trim();
        }
        else
        {
            user.UserName = "";
        }
        if (TextBox4.Text != null)
        {
            user.Phone = TextBox4.Text.Trim();
        }
        else
        {
            user.Phone = "";
        }
        if (TextBox5.Text != null)
        {
            user.Email = TextBox5.Text.Trim();
        }
        else
        {
            user.Email = "";
        }

        if (bll.updateUser(2, user))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
        }

            

    }

   //业主

    protected void Button3_Click(object sender, EventArgs e)
    {
        UserBll bll = new UserBll();
        UserEntity en = new UserEntity();
        en.LoginName = Session["user_loginName"].ToString().Trim();
        en.UserName = TextBox6.Text.Trim();
        //TextBox6.Text = dt.Rows[0]["USERNAME"].ToString();//姓名
        //TextBox17.Text = dt.Rows[0]["LOGINNAME"].ToString();//登陆账号
        if (TextBox7.Text != null)
        {
            en.UnitName = TextBox7.Text.Trim();
        }
        else
        {
            en.UnitName = "";
        }
      //  TextBox7.Text = dt.Rows[0]["UNITNAME"].ToString();//单位名称
        if (TextBox8.Text != null)
        {
            en.LegalRepre = TextBox8.Text.Trim();
        }
        else
        {
            en.LegalRepre = "";
        }
        if (TextBox9.Text != null)
        {
            en.BusinessContact = TextBox9.Text.Trim();
        }
        else
        {
            en.BusinessContact = "";
        }

      //  TextBox10.Text = dt.Rows[0]["REGISTMONEY"].ToString();//注册资金
        float money;
        if (TextBox10.Text != null&&TextBox10.Text!="")
        {
            if (!float.TryParse(TextBox10.Text.Trim(), out money))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('注册资金输入的格式不正确！')</script>");
                return;
            }
            else
            {
                en.RegistMoney = TextBox10.Text.Trim();
            }
        }
        else
        {
            en.RegistMoney = "";
        }
      
       
        if (TextBox11.Text != null)
        {
            en.RegistArea = TextBox11.Text.Trim();
        }
        else
        {
            en.RegistArea = "";
        }
        if (TextBox12.Text != null)
        {
            en.Email = TextBox12.Text.Trim();

        }
        else
        {
            en.Email = "";
        }
        //TextBox13.Text = dt.Rows[0]["BUSINESSAREA"].ToString();//营业范围
        if (TextBox13.Text != null)
        {
            en.BusinessArea = TextBox13.Text.Trim();
        }
        else
        {
            en.BusinessArea = "";
        }
        if (TextBox18.Text != null)
        {
            en.Phone = TextBox18.Text.Trim();
        }
        else
        {

            en.Phone="";
        }


        if (bll.updateUser(4, en))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
        }

    }
    /// <summary>
    /// 一级审核员
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button4_Click(object sender, EventArgs e)
    {

        UserEntity user = new UserEntity();
        UserBll bll = new UserBll();
        user.LoginName = Session["user_loginName"].ToString().Trim();
        if (TextBox14.Text != null)
        {
            user.UserName = TextBox14.Text.Trim();
        }
        else
        {
            user.UserName = "";
        }
        if (TextBox15.Text != null)
        {
            user.Phone = TextBox15.Text.Trim();
        }
        else
        {
            user.Phone = "";
        }
        if (TextBox16.Text != null)
        {
            user.Email = TextBox16.Text.Trim();
        }
        else
        {
            user.Email = "";
        }

        if (bll.updateUser(3, user))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
        }

    }
}