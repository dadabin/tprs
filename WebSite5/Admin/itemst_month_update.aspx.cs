using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_itemst_month_update : System.Web.UI.Page
{
    public DateTime reportTime = DateTime.Now;
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

    /// <summary>
    /// 保存
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_svae(object sender, EventArgs e)
    {

        //判断是新增还是修改 
        if ((Request.QueryString["projectID"] != null) && (Request.QueryString["projectID"].ToString() != ""))
        {
            ItemstMonthReportEntity itemst = new ItemstMonthReportEntity();
            ItemReportBll bll = new ItemReportBll();
            itemst.ProjectId = Convert.ToInt32(Request.QueryString["projectID"]);
           
            itemst.ProgressNow = TextBox21.Text.Trim();
            itemst.ProgressCategory = DropDownList1.SelectedValue.Trim();
            itemst.Problems = DevelopDirectionText.Text.Trim();
            itemst.Remark = TextBox16.Text.Trim();
            StringUtills strUtil = new StringUtills();
            if (strUtil.strLength(Label21.Text, 9))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('资金输入的数字不能长于9位！')</script>");
                return;
            }
            float invest;
            if (float.TryParse(Label21.Text.Trim(), out invest))
            {
                itemst.InvestmentPosition = invest;

            }

            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('资金格式输入错误！')</script>");
                return;
            }

            itemst.Image1 = Lab_Image1_old.Text;
            itemst.Image2 = Lab_Image2_old.Text;
            itemst.Image3 = Lab_Image3_old.Text;
            itemst.Image4 = Lab_Image4_old.Text;
            itemst.Image5 = Lab_Image5_old.Text;
            itemst.Id = Convert.ToInt32(Request.QueryString["id"]);

            if (bll.update(1, itemst, int.Parse(Request.QueryString["ID"].ToString()), Session["user_loginName"].ToString().Trim()))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！')</script>");
                if (Request.QueryString["back"] != null)
                {
                    Response.Redirect("itemselect_admin2_report.aspx");
                }
                Response.Redirect("itemst_month_manage.aspx?projectID=" + itemst.ProjectId);
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！')</script>");
                Response.Redirect("itemst_month_manage.aspx?projectID=" + itemst.ProjectId);
            }

        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('无法获取到项目标号，无法执行创建报告的操作！')</script>");
        }

    }


    public void bind()
    {


        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
           
            ItemReportBll rb = new ItemReportBll();
            DataTable dt = rb.selectReportById(1, Convert.ToInt32(Request.QueryString["ID"]));


            if (dt.Rows.Count > 0)
            {
                Label1.Text = dt.Rows[0]["qx"].ToString();//所属区县
                Label2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                Label3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                Label4.Text = dt.Rows[0]["CONSTRUCTIONAGE"].ToString();//建设年限
                Label5.Text = dt.Rows[0]["CONSTRUCTIONTYPE"].ToString().Trim()=="1"?"新建":"续建";//建设性质

                Label6.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//建设内容及规模
                Label7.Text = dt.Rows[0]["TOTLEMONEY"].ToString();//总投资
                Label8.Text = dt.Rows[0]["CENTRALMONEY"].ToString();//中央资金
                Label9.Text = dt.Rows[0]["PROVINCIALMONEY"].ToString();//省级资金
                Label10.Text = dt.Rows[0]["MUNICIPALMONEY"].ToString();//市级资金
                Label11.Text = dt.Rows[0]["DISTRICTMONEY"].ToString();//区县资金
                Label12.Text = dt.Rows[0]["BANKLOAN"].ToString();//银行贷款
                Label13.Text = dt.Rows[0]["COMPANYSELF"].ToString();//企业自筹

                Label14.Text = dt.Rows[0]["thisyear_investment"].ToString();//至2011年累计完成投资
                Label15.Text = dt.Rows[0]["plane_investment"].ToString();//2012年计划投资
                
                TextBox21.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前为止项目形象进度
                Label16.Text = dt.Rows[0]["PREDICTSTARTTIME"].ToString();//开工（计划开工）时间
                Label17.Text = dt.Rows[0]["PREDICTFINISHTIME"].ToString();//计划竣工时间
                //DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批统筹
                Label18.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已取得土地指标
                Label19.Text = dt.Rows[0]["PLANLANDTARGETS"].ToString();//拟申请土地指标
                Label20.Text = dt.Rows[0]["GOVERNMENTPROJE"].ToString().Trim()=="1"?"是":"否";//是否政府投资项目

                //Label21.Text = dt.Rows[0]["thismonth_investment"].ToString();//7月累计完成投资
                //TextBox1.Text = dt.Rows[0]["premonthes_investment"].ToString();//1-7月累计完成投资
                //DevelopDirectionText.Text = dt.Rows[0]["PROBLEMS"].ToString();//需协调解决的问题
                //TextBox16.Text = dt.Rows[0]["REMARK"].ToString();//备注

                TextBox21.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前为止形象进度
                DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批范畴
                DevelopDirectionText.Text = dt.Rows[0]["PROBLEMS"].ToString();//需要协调解决的问题
                TextBox16.Text = dt.Rows[0]["REMARK"].ToString();//备注
                Label21.Text = dt.Rows[0]["InvestmentPosition"].ToString();//7月累计完成投资
                total.Text = dt.Rows[0]["total"].ToString();//1-当前月累计投资

                Lab_Image1_new.Text = dt.Rows[0]["IMAGE1"].ToString();
                Lab_Image2_new.Text = dt.Rows[0]["IMAGE2"].ToString();
                Lab_Image3_new.Text = dt.Rows[0]["IMAGE3"].ToString();
                Lab_Image4_new.Text = dt.Rows[0]["IMAGE4"].ToString();
                Lab_Image5_new.Text = dt.Rows[0]["IMAGE5"].ToString();


                reportTime = Convert.ToDateTime(dt.Rows[0]["REPORTTIME"].ToString().Trim());
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