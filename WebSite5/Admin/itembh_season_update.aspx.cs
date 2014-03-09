using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using System.Data;
using Model;
using Dal;

public partial class Admin_itembh_season_update : System.Web.UI.Page
{
    public string projectnum = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bind();
            bindPic();
        }
    }


    public void bind()
    {
        if ((Request.QueryString["projectID"] != null) && (Request.QueryString["projectID"].ToString() != ""))
        {
            //ItemBll bll = new ItemBll();
            //DataTable dt = bll.selectByID(3, Convert.ToInt32(Request.QueryString["projectID"]));
            ItemReportBll rb = new ItemReportBll();
            DataTable dt = rb.selectReportById(3, Convert.ToInt32(Request.QueryString["id"]));
            StringUtills utils = new StringUtills();
            
            if (dt.Rows.Count > 0)
            {
                ProjectNameText.Text = dt.Rows[0]["PROJECTNAME"].ToString();//工程名称
                ProjectAddressText.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                FinishTimeText.Text = dt.Rows[0]["FINISHTIME"].ToString();//完工时间
                warterAreaText.Text = dt.Rows[0]["ZONEAREA"].ToString();//水域面积
                ProvinciaLevelFiscalText.Text = dt.Rows[0]["PROVINCIALEVELFISCAL"].ToString();//省级以上财政
                MunicipalFinanceText.Text = dt.Rows[0]["MUNICIPALFINANCE"].ToString();//市级以上财政
                CountyFinanceText.Text = dt.Rows[0]["COUNTYFINANCE"].ToString();//县级财政
                FinanceFinanceText.Text = dt.Rows[0]["FINANCEFINANCE"].ToString();//财政融资
                SocialInvestmentText.Text = dt.Rows[0]["SOCIALINVESTMENT"].ToString();//社会投入
                PublicInvestmentText.Text = dt.Rows[0]["PUBLICINVESTMENT"].ToString();//群众投入
                OtherText.Text = dt.Rows[0]["OTHER"].ToString();//其他
                occupiedAreaText.Text = dt.Rows[0]["OCCUPIEDAREA"].ToString();//占用土地面积
                occupiedTypeText.Text = utils.占用方式(dt.Rows[0]["OCCUPIEDTYPE"].ToString().ToString());//占用方式


                UnitPriceText.Text = dt.Rows[0]["UNITPRICE"].ToString();//单价
                ManageSubjectText.Text = dt.Rows[0]["MANAGESUBJECT"].ToString();//管护主体
                //DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批范畴
                //ImageProgressText.Text = dt.Rows[0]["IMAGEPROGRESS"].ToString();//目前工程形象进度

                TextBox1.Text = dt.Rows[0]["SUBTOTAL"].ToString();
                DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();
                ImageProgressText.Text = dt.Rows[0]["IMAGEPROGRESS"].ToString();
                Lab_Image1_new.Text = dt.Rows[0]["IMAGE1"].ToString();
                Lab_Image2_new.Text = dt.Rows[0]["IMAGE2"].ToString();
                Lab_Image3_new.Text = dt.Rows[0]["IMAGE3"].ToString();
                Lab_Image4_new.Text = dt.Rows[0]["IMAGE4"].ToString();
                Lab_Image5_new.Text = dt.Rows[0]["IMAGE5"].ToString();
                Label1.Text = dt.Rows[0]["qx"].ToString();
              
                
            }
        }
        //补充要修改的内容
        //if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        //{
        //    ItemReportBll rebll = new ItemReportBll();
        //    DataTable redt = rebll.select(3, Convert.ToInt32(Request.QueryString["id"]));
        //    if (redt.Rows.Count > 0)
        //    {
               

        //    }
        //}

    }


    protected void Button4_Click(object sender, EventArgs e)
    {

        StringUtills strUtil = new StringUtills();
        //判断是新增还是修改 
        if ((Request.QueryString["projectID"] != null) && (Request.QueryString["projectID"].ToString() != ""))
        {
            projectnum = Request.QueryString["projectID"].ToString();
            ItembhReportEntity bh = new ItembhReportEntity();
            bh.ProjectID = Convert.ToInt32(Request.QueryString["projectID"]);
            DateTime dataTime = System.DateTime.Now;
            bh.Savetime = dataTime.ToString();
            bh.FinishTime = FinishTimeText.Text.Trim();
            bh.ProgressCategory = DropDownList1.SelectedValue;
            bh.Imageprogress = ImageProgressText.Text.Trim();
            bh.LoginName = Session["user_loginName"].ToString().Trim();
         //   bh.SubTotal = TextBox1.Text.Trim();//总投资

            if (strUtil.strLength(TextBox1.Text, 9))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资输入的数字不能长于9位！')</script>");
                return;
            }
            float subtotal = 0;
            if (TextBox1.Text != null&&TextBox1.Text.Trim()!="")
            {
                if (float.TryParse(TextBox1.Text.Trim(), out subtotal))
                {
                    bh.SubTotal = subtotal.ToString();//总投资
                }
                else
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资输入格式不正确！')</script>");
                    return;
                }
            }
            else
            {
                bh.SubTotal = "";
            }


            bh.Image1 = Lab_Image1_old.Text;
            bh.Image2 = Lab_Image2_old.Text;
            bh.Image3 = Lab_Image3_old.Text;
            bh.Image4 = Lab_Image4_old.Text;
            bh.Image5 = Lab_Image5_old.Text;
            bh.ID = Convert.ToInt32(Request.QueryString["id"]);
            ItemReportBll bll = new ItemReportBll();
            if (bll.update(3, bh, int.Parse(Request.QueryString["ID"].ToString()), Session["user_loginName"].ToString().Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
                if (Request.QueryString["back"] != null)
                {
                    Response.Redirect("itemselect_admin2_report.aspx");
                }
                Response.Redirect("itembh_season_manage.aspx?projectID=" + projectnum);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
              //  Response.Redirect("itembh_season_manage.aspx?projectID=" + projectnum);
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('无法获取到项目标号，无法执行创建报告的操作！')</script>");
        }
    }

    //================================上传图片



    protected void DataList1_EditCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = e.Item.ItemIndex;
        bindPic();
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
        bindPic();
    }
    /// <summary>
    /// 取消修改
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    protected void DataList1_CancelCommand(object source, DataListCommandEventArgs e)
    {
        this.DataList1.EditItemIndex = -1;

        bindPic();
    }
    /// <summary>
    /// 1.绑定现在传上去的图片
    /// 2.删除以前不要的图片
    /// 3.更新以前
    /// </summary>
    /// <param name="dt"></param>
    public void bindPic()
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