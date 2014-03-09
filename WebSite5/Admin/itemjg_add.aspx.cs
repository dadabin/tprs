using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;


public partial class Admin_itemjg_add : System.Web.UI.Page
{
    
    private string timeStr = new StringUtills().getMonth(DateTime.Now.ToString());

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            initPage();
            bind();
        }
    }
    private void initPage()
    {
        //获取当前登陆的业主的信息
        DataTable loginedUser = (DataTable)Session["userEntity_logined"];
        //将业主的所属区县的信息显示到页面
        Label2.Text = new StringUtills().getChineseLocaltion(loginedUser.Rows[0]["AREA"].ToString());
    }
    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {

        StringUtills strUtil = new StringUtills();

        ItemjgEntity en = new ItemjgEntity();
        ItemBll bll = new ItemBll();
        en.LoginName = Session["user_loginName"].ToString();
        en.ProjectName = TextBox2.Text.Trim();//项目名称
        en.Address = TextBox4.Text.Trim();//项目地址
        en.StartEndTime = TextBox7.Text.Trim();//建设起止年限

        en.ContentScale  = TextBox9.Text.Trim();//项目建设规划

        if (strUtil.strLength(TextBox10.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('计划总投资输入的数字不能长于9位！')</script>");
            return;
        }
        float PlanTotalMoney;
        if (!(float.TryParse(TextBox10.Text.Trim(), out PlanTotalMoney)))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('计划总投资格式输入不正确！')</script>");
            return;
        }
       
        en.PlanTotalMoney = PlanTotalMoney.ToString();//计划总投资

        if (strUtil.strLength(TextBox1.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('计划投资输入的数字不能长于9位！')</script>");
            return;
        }
        if(TextBox1.Text!=null&&TextBox1.Text.Trim()!="")
        {
        float xyearplan;
        if (!(float.TryParse(TextBox1.Text.Trim(),out xyearplan)))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('计划投资输入格式不正确！')</script>");
            return;
        }
        en.XYearPlan = xyearplan.ToString();
   
        }else{
             en.XYearPlan = "";
        }
      

        en.EndYear = TextBox3.Text.Trim();

        if (strUtil.strLength(TextBox5.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('去年底已完成累计投资输入的数字不能长于9位！')</script>");
            return;
        }
        if(TextBox5.Text!=null&&TextBox5.Text.Trim()!=""){
          float preyearplan;
        if(!(float.TryParse(TextBox5.Text.Trim(),out preyearplan))){
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('去年底已完成累计投资输入格式不正确！')</script>");
            return;
           }
         en.PreYearPlan = preyearplan.ToString();
        }else{
            en.PreYearPlan = "";
        }

        if (strUtil.strLength(TextBox6.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资输入的数字不能长于9位！')</script>");
            return;
        }
        if(TextBox6.Text!=null&&TextBox6.Text.Trim()!=""){

        float xmonfin;
        if(!float.TryParse( TextBox6.Text.Trim(),out xmonfin)){
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资格式输入不正确！')</script>");
            return;
        }
        en.XMonFin = xmonfin.ToString();
        }else{
            en.XMonFin="";
        }


        en.XProgressNow = TextBox8.Text.Trim();

        en.StartEndTime = TextBox7.Text.Trim();
        en.ProgressCategory = DropDownList1.SelectedValue.Trim();

        //===============图片
        en.Image1 = Lab_Image1_old.Text;
        en.Image2 = Lab_Image2_old.Text;
        en.Image3 = Lab_Image3_old.Text;
        en.Image4 = Lab_Image4_old.Text;
        en.Image5 = Lab_Image5_old.Text;
        if (bll.isAddItem(2, en))
        {
            if (bll.add(2, en))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已经添加，不能添加同名称项目！')</script>");
        }
    }

    public void TxtName_TextChanged(object sender, EventArgs e)
    {
        string inputName = TextBox2.Text.ToString().Trim();
        ItemBll bll = new ItemBll();
        if(bll.isExitProject(3,inputName))
        {
            checkresult.Text = "该项目名称已被使用，请重新输入";
            checkresult.CssClass = "";
        }
        else
        {
            checkresult.Text = "可以使用该项目名称";
            checkresult.CssClass = "";
        }

    }

    protected void calEventDate_SelectionChanged(object sender, EventArgs e)
     {
         TextBox7.Text = calEventDate.SelectedDate.ToString("d");
    }

    protected void TextBox6_TextChanged(object sender, EventArgs e)
    {
         //获取值
        TextBox11.Text = TextBox6.Text.ToString();
    }



    //================================上传图片



    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = e.Item.ItemIndex;
        bind();
    }
    /// <summary>
    /// 修改
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList1_UpdateCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = -1;
        //string id = this.DataList1.DataKeys[e.Item.ItemIndex].ToString();//使用当前需要先设置DataList的DataKeyField=“Uid”
        FileUpload fileUpload = (FileUpload)e.Item.FindControl("FileUpload1");
        Label label = (Label)e.Item.FindControl("Label2");
        int id = 1;//Convert.ToInt32(label.Text.ToString().Trim());
        DataTable my_dt = new DataTable();
        my_dt.Columns.Add("picPath", typeof(string));
        my_dt.Columns.Add("id", typeof(string));
        for (int i = 0; i < 5; i++)
        {
            DataRow r = my_dt.NewRow();
            r["picPath"] = "~/Admin/upload/20121229131257463.gif";
            r["id"] = i + 1;
            my_dt.Rows.Add(r);
        }
        if (fileUpload.HasFile)
        {
            if (IsUpload(fileUpload))
            {
                string picPath = new DateTimeUtil().getNowTimeString() + fileUpload.FileName.Substring(fileUpload.FileName.IndexOf("."));
                fileUpload.SaveAs(Server.MapPath("~/Admin/upload/") + picPath);
                my_dt.Rows[id - 1]["id"] = id;
                my_dt.Rows[id - 1]["picPath"] = "upload/" + picPath;
                switch (e.Item.ItemIndex)
                {
                    case 0: Lab_Image1_new.Text = "upload/" + picPath; break;
                    case 1: Lab_Image2_new.Text = "upload/" + picPath; break;
                    case 2: Lab_Image3_new.Text = "upload/" + picPath; break;
                    case 3: Lab_Image4_new.Text = "upload/" + picPath; break;
                    case 4: Lab_Image5_new.Text = "upload/" + picPath; break;
                }

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('文件格式不正确！')</script>");
            }
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('未选择文件！')</script>");
        }
        bind();
    }
    /// <summary>
    /// 取消修改
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = -1;

        bind();
    }
    /// <summary>
    /// 1.绑定现在传上去的图片
    /// 2.删除以前不要的图片
    /// 3.更新以前
    /// </summary>
    /// <param name="dt"></param>
    public void bind()
    {
        DataTable dt = null;
        if (dt == null)
        {
            dt = new DataTable();
            dt.Columns.Add("picPath", typeof(string));
            dt.Columns.Add("id", typeof(string));
            for (int i = 0; i < 5; i++)
            {
                DataRow r = dt.NewRow();
                switch (i)
                {
                    case 0:
                        if (Lab_Image1_old.Text != Lab_Image1_new.Text)
                        {
                            delete(Lab_Image1_old.Text);
                        }
                        Lab_Image1_old.Text = Lab_Image1_new.Text;
                        r["picPath"] = Lab_Image1_old.Text;
                        break;
                    case 1:
                        if (Lab_Image2_old.Text != Lab_Image2_new.Text)
                        {
                            delete(Lab_Image2_old.Text);
                        }
                        Lab_Image2_old.Text = Lab_Image2_new.Text;
                        r["picPath"] = Lab_Image2_old.Text;
                        break;
                    case 2:
                        if (Lab_Image3_old.Text != Lab_Image3_new.Text)
                        {
                            delete(Lab_Image3_old.Text);
                        }
                        Lab_Image3_old.Text = Lab_Image3_new.Text;
                        r["picPath"] = Lab_Image3_old.Text;
                        break;
                    case 3:
                        if (Lab_Image4_old.Text != Lab_Image4_new.Text)
                        {
                            delete(Lab_Image4_old.Text);
                        }
                        Lab_Image4_old.Text = Lab_Image4_new.Text;
                        r["picPath"] = Lab_Image4_old.Text;
                        break;
                    case 4:
                        if (Lab_Image5_old.Text != Lab_Image5_new.Text)
                        {
                            delete(Lab_Image5_old.Text);
                        }
                        Lab_Image5_old.Text = Lab_Image5_new.Text;
                        r["picPath"] = Lab_Image5_old.Text;
                        break;
                }
                r["id"] = i + 1;
                dt.Rows.Add(r);
            }
        }
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    public bool IsUpload(FileUpload fileUpload)
    {
        string[] extensions = new string[4];
        extensions[0] = ".jpg";
        extensions[1] = ".png";
        extensions[2] = ".jpng";
        extensions[3] = ".gif";

        string fileExt = System.IO.Path.GetExtension(fileUpload.FileName);
        for (int i = 0; i < extensions.Length; i++)
        {
            if (fileExt.ToLower() == extensions[i])
            {
                return true;
            }
        }
        return false;
    }


    public void delete(string picPath)
    {
        if (System.IO.File.Exists(Server.MapPath("~/Admin/") + picPath))
        {
            System.IO.File.Delete(Server.MapPath("~/Admin/") + picPath);
        }
    }



}