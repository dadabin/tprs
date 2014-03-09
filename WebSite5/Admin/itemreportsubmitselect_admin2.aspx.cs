using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

using System.Text;
using System.Data;
using Bll;
using Model;
using org.in2bits.MyXls;
using Cells = org.in2bits.MyXls.Cells;
using Cell = org.in2bits.MyXls.Cell;

public partial class Admin_itemselect_admin2 : System.Web.UI.Page
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
        ItemBll bll = new ItemBll();
        String whereStr = "";
        bll.adminBindItem(GridView1, AspNetPager1, whereStr,0);


    }
    /// <summary>
    /// 分页
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        ItemBll bll=new ItemBll();
        String whereStr="";
        UserBll userBll = new UserBll();
        UserEntity en = new UserEntity();
        bll.adminBindItem(GridView1, AspNetPager1, whereStr,0);
        
    }

   




    /// <summary>
    /// 条件查询
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button5_Click(object sender, EventArgs e)
    {

    }


    protected void Button6_Click(object sender, EventArgs e)
    {
        //在此处添加提交意见得逻辑
        CommentBll bll = new CommentBll();
       
        //1、获取表单
        String opinionContent = TextBox1.Text.Trim();
        string title = "";
        //获取钱20个字符存到title中
        if (opinionContent!=null)
        {
            if (opinionContent.Length > 15)
            {
                if (opinionContent.Length < 2000)
                {
                    title = opinionContent.Substring(0, 15) + ".....";
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('字符长度不应超过2000，请修改！')</script>");
                }
            }
            else
            {
                title = opinionContent + "....";
            }
        }
        
         
        //获取当前登录用户
        string loginName = Session["user_loginName"].ToString();

        //2、插入数据到数据库
        String result = bll.addOpinion(loginName,title,opinionContent);
        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('" + result + "')</script>");

    }
}