using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bll;
using Model;
using System.Data;
using Dal;

public partial class Admin_itemjg_season_update : System.Web.UI.Page
{
    public DateTime submitTime;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
            {
                //int projectId = int.Parse(Request.QueryString["projectID"].ToString());
                //ItemBll bll = new ItemBll();
                //DataTable dt = bll.selectByID(2, projectId);
                ItemReportBll rb = new ItemReportBll();
                DataTable dt = rb.selectReportById(4, Convert.ToInt32(Request.QueryString["id"]));


                if (dt.Rows.Count > 0)
                {
                    Label1.Text = dt.Rows[0]["qx"].ToString();//项目地址
                    ProjectNameText.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                    ConstructionAddressText.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                    StartConstructionTimeText.Text = dt.Rows[0]["ADDRESS"].ToString();//建设起止年限
                    ContentScaleText.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//项目建设规模
                    PlanTotalMoneyText.Text = dt.Rows[0]["PLANTOTALMONEY"].ToString();//计划总投资
                    
                    xyYearMoney.Text = dt.Rows[0]["XYEARPLAN"].ToString();//2012年计划投资
                    EndTimeText.Text = dt.Rows[0]["ENDYEAR"].ToString();//应达到的形象进度
                    FinishTotalInvestmentText.Text = dt.Rows[0]["PREYEARPLAN"].ToString();//2012年计划投资 


                    DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批
                    FinishInvestmentText.Text = dt.Rows[0]["XMONFIN"].ToString();//6月完成投资
                    ImageProgressText.Text = dt.Rows[0]["PROGRESSNOW"].ToString();

                    submitTime = DateTime.Parse(dt.Rows[0]["REPORTTIME"].ToString().Trim());
                    TextBox1.Text = dt.Rows[0]["total"].ToString().Trim();
                    Lab_Image1_new.Text = dt.Rows[0]["IMAGE1"].ToString();
                    Lab_Image2_new.Text = dt.Rows[0]["IMAGE2"].ToString();
                    Lab_Image3_new.Text = dt.Rows[0]["IMAGE3"].ToString();
                    Lab_Image4_new.Text = dt.Rows[0]["IMAGE4"].ToString();
                    Lab_Image5_new.Text = dt.Rows[0]["IMAGE5"].ToString();
                }
                bindPic();

            }

            ////补充要修改的内容
            //if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
            //{
            //    ItemReportBll rebll = new ItemReportBll();
            //    DataTable redt = rebll.select(4, Convert.ToInt32(Request.QueryString["id"]));
            //    if (redt.Rows.Count > 0)
            //    {
            //        FinishInvestmentText.Text = redt.Rows[0]["XMONFIN"].ToString();//6月完成投资
            //        ImageProgressText.Text = redt.Rows[0]["PROGRESSNOW"].ToString();
                   
            //        submitTime = DateTime.Parse(redt.Rows[0]["REPORTTIME"].ToString().Trim());
            //        TextBox1.Text = redt.Rows[0]["XMONFIN"].ToString().Trim();
            //    }
            //}
        }
    }

    //保存
    protected void Button1_Click(object sender, EventArgs e)
    {
        ItemReportBll bll = new ItemReportBll();
        ItemjgReportEntity en = new ItemjgReportEntity();
        en.Id = Convert.ToInt32(Request.QueryString["id"]);
        en.ProgressNow = ImageProgressText.Text.Trim();
        StringUtills strUtil = new StringUtills();
        if (strUtil.strLength(FinishInvestmentText.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资输入的数字不能长于9位！')</script>");
            return;
        }
        if (FinishInvestmentText.Text != null && FinishInvestmentText.Text.Trim() != "")
        {
            float fin=0;
            if(float.TryParse(FinishInvestmentText.Text.Trim(),out fin)){
            en.XMonFin = FinishInvestmentText.Text.Trim();
            }else{
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资输入格式有误！')</script>");

            }
        }
        else
        {
            en.XMonFin = "";
        }

        en.ProgressCategory = DropDownList1.SelectedValue.ToString().Trim();
        en.Image1 = Lab_Image1_old.Text;
        en.Image2 = Lab_Image2_old.Text;
        en.Image3 = Lab_Image3_old.Text;
        en.Image4 = Lab_Image4_old.Text;
        en.Image5 = Lab_Image5_old.Text;
        if (bll.update(4, en, Convert.ToInt32(Request.QueryString["id"]), Session["user_loginName"].ToString().Trim()))
        {

            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存成功！')</script>");
            if (Request.QueryString["back"] != null)
            {
                Response.Redirect("itemselect_admin2_report.aspx");
            }
            //页面跳转到列表！！！！！
            Response.Redirect("itemjg_season_manage.aspx?projectID=" + int.Parse(Request.QueryString["projectID"].ToString()));
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('保存失败！')</script>");
        }
    }


    protected void FinishInvestmentText_TextChanged(object sender, EventArgs e)
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            ItemReportBll rebll = new ItemReportBll();
            DataTable redt = rebll.select(4, Convert.ToInt32(Request.QueryString["id"]));
            if (redt.Rows.Count > 0)
            {
                TextBox1.Text = (int.Parse(TextBox1.Text)+int.Parse(FinishInvestmentText.Text)-int.Parse(redt.Rows[0]["XMONFIN"].ToString().Trim())) + "";//???
                submitTime = DateTime.Parse(redt.Rows[0]["REPORTTIME"].ToString().Trim());
            }
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