using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bll;
using Model;
using System.Data;
using Dal;

public partial class Admin_itemjg_season_add : System.Web.UI.Page
{
    public DateTime submitTime;
    protected void Page_Load(object sender, EventArgs e)
    {

         if(!IsPostBack)
         {
             if (Session["userEntity_logined"] == null)
                 Response.Redirect("~/login.aspx");
             if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
             {
                 int projectId = int.Parse(Request.QueryString["projectID"].ToString());
                 //ItemBll bll = new ItemBll();
                 //DataTable dt = bll.selectByID(2, projectId);
                 ItemReportBll bll = new ItemReportBll();
                 DataTable dt = bll.getDataWhenAddReport(2, Convert.ToInt32(Request.QueryString["projectID"]), DateTime.Now);
                 StringUtills utils = new StringUtills();

                 if (dt.Rows.Count > 0)
                 {
                     Label1.Text = utils.getChineseLocaltion(dt.Rows[0]["AREA"].ToString());//区县

                     ProjectNameText.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                     ConstructionAddressText.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                     StartConstructionTimeText.Text = dt.Rows[0]["ADDRESS"].ToString();//建设起止年限
                     ContentScaleText.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//项目建设规模
                     PlanTotalMoneyText.Text = dt.Rows[0]["PLANTOTALMONEY"].ToString();//计划总投资
                     PlannedTimeText.Text = dt.Rows[0]["XYEARPLAN"].ToString();//2012年计划投资

                     EndTimeText.Text = dt.Rows[0]["ENDYEAR"].ToString();//2012年底工程应达形象进度
                     FinishTotalInvestmentText.Text = dt.Rows[0]["PREYEARPLAN"].ToString();//至2011年已累计完成投资
                     //TextBox6.Text = dt.Rows[0]["XMONFIN"].ToString();//2012年6月完成投资
                     //TextBox8.Text = dt.Rows[0]["PROGRESSNOW"].ToString();//目前形象进度

                     submitTime = DateTime.Parse(dt.Rows[0]["SUBMITTIME"].ToString().Trim());
                 }

             }
             bind();
         }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        StringUtills strUtil = new StringUtills();
           
                int projectId = int.Parse(Request.QueryString["projectID"].ToString());
                    ItemjgReportEntity jg = new ItemjgReportEntity();


                 //   jg.XMonFin = FinishInvestmentText.Text.Trim();//当年当月完成投资 ==至2011年已累计完成投资

                    if (strUtil.strLength(FinishInvestmentText.Text, 9))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当年当月完成投资输入的数字不能长于9位！')</script>");
                        return;
                    }


                    if (FinishInvestmentText.Text != null && FinishInvestmentText.Text.Trim() != "")
                    {
                        float xye = 0;
                        if (float.TryParse(FinishInvestmentText.Text.Trim(), out xye))
                        {
                            jg.XMonFin = FinishInvestmentText.Text.Trim();//当年当月完成投资 ==至2011年已累计完成投资
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当年当月完成投资格式输入有误！')</script>");

                        }
                    }
                    else
                    {
                        jg.XMonFin = "";
                    }
      



                    jg.PreyearPlan = EndTimeText.Text.Trim();//今年底工程应达形象进度

                    jg.ProgressNow = ImageProgressText.Text.Trim();//目前形象进度
                    jg.ProgressCategory = DropDownList1.SelectedValue;

                    if (strUtil.strLength(XFINISHINVESTMENT.Text, 9))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至当月完成投资输入的数字不能长于9位！')</script>");
                        return;
                    }


                    if (XFINISHINVESTMENT.Text != null&&XFINISHINVESTMENT.Text.Trim()!="")
                    {
                        float xye = 0;
                        if (float.TryParse(XFINISHINVESTMENT.Text.Trim(), out xye))
                        {
                            jg.XYeqePlan = XFINISHINVESTMENT.Text.Trim();
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至当月完成投资格式输入有误！')</script>");

                        }
                    }
                    else
                    {
                        jg.XYeqePlan = "";
                    }

                    
                    //jg.EndYear = "";

                    jg.Image1 = ""; jg.Image2 = ""; jg.Image3 = ""; jg.Image4 = ""; jg.Image5 = "";
                    //业主
                    jg.LoginName = Session["user_loginName"].ToString();
                    jg.ProjectID = projectId + "";
                    jg.Image1 = Lab_Image1_old.Text;
                    jg.Image2 = Lab_Image2_old.Text;
                    jg.Image3 = Lab_Image3_old.Text;
                    jg.Image4 = Lab_Image4_old.Text;
                    jg.Image5 = Lab_Image5_old.Text;
                    ItemReportBll br = new ItemReportBll();

                    //if (br.isExitReport(2, projectId, DateTime.Now.ToString()))
                    //{
                    //    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('您已经填报了该类本季度的报告，只能修改相关报告！')</script>");
                    //}
                    //else
                    {
                        if (br.isAdd(4, jg))
                        {

                            if (br.add(4, jg))
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！')</script>");
                                Response.Redirect("itemjg_season_manage.aspx?projectID=" + jg.ProjectID);
                            }
                            else
                            {
                                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加失败！')</script>");
                            }
                        }
                        else
                        {
                            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已经添加，不能继续添加！')</script>");
                        }
               }      
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