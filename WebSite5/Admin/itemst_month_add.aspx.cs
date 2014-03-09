using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;

using Dal;
using System.Globalization;

public partial class Admin_itemst_month_add : System.Web.UI.Page
{


    public string timeStr = new StringUtills().getMonth(DateTime.Now.ToString());//
    /// <summary>
    /// -------------页面家在之前执行，，初始页面数据，如果是从修改，查看指令过来，则可以看到相应的细节数据
    /// 传递参数为：   projectNumber
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
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
    /// ------------------添加新项目页面
    /// 传递参数为：   projNum
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
            itemst.LoginName = Session["user_loginName"].ToString().Trim();
            itemst.ProgressNow = TextBox21.Text.Trim();
            itemst.ProgressCategory = DropDownList1.SelectedValue.Trim();
            itemst.Problems = DevelopDirectionText.Text.Trim();
            itemst.Remark = TextBox16.Text.Trim();
            itemst.Image1 = Lab_Image1_old.Text;
            itemst.Image2 = Lab_Image2_old.Text;
            itemst.Image3 = Lab_Image3_old.Text;
            itemst.Image4 = Lab_Image4_old.Text;
            itemst.Image5 = Lab_Image5_old.Text;
            StringUtills strUtil = new StringUtills();
            if (strUtil.strLength(TextBox22.Text, 9))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('资金输入的数字不能长于9位！')</script>");
                return;
            }
            float invest;
            if (float.TryParse(TextBox22.Text.Trim(), out invest))
            {
                itemst.InvestmentPosition = invest;
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('资金格式输入错误！')</script>");
                return;
            }

            ///先判断是否已经存在该类型项目在本月或本季度报告
            //if (bll.isExitReport(1, itemst.ProjectId, DateTime.Now.ToString()))
            //{
            //    Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('您已经填报了该类本季度的报告，只能修改相关报告！')</script>");
            //}
            //else
            {
                if (bll.isAdd(1, itemst))
                {
                    if (bll.add(1, itemst))
                    {
                        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('添加成功！')</script>");
                        Response.Redirect("itemst_month_manage.aspx?projectID=" + itemst.ProjectId);
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
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('无法获取到项目标号，无法执行创建报告的操作！')</script>");
        }
      
    

     
        


    }


    public void bind()
    {


        if (Request.QueryString["projectID"] != null && Request.QueryString["projectID"].ToString() != "")
        {
            //ItemBll bll = new ItemBll();
            //DataTable dt = bll.selectByID(1, Convert.ToInt32(Request.QueryString["projectID"]));
            ItemReportBll bll = new ItemReportBll();
            DataTable dt = bll.getDataWhenAddReport(1, Convert.ToInt32(Request.QueryString["projectID"]), DateTime.Now);

            if (dt.Rows.Count > 0)
            {
                Label1.Text = new StringUtills().getChineseLocaltion(dt.Rows[0]["area"].ToString().Trim());//所属区县

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
               
                DropDownList1.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();//四个一批统筹
                
                Label18.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已取得土地指标
                Label19.Text = dt.Rows[0]["PLANLANDTARGETS"].ToString();//拟申请土地指标
                Label20.Text = dt.Rows[0]["GOVERNMENTPROJE"].ToString().Trim()=="1"?"是":"否";//是否政府投资项目

                TextBox22.Text = dt.Rows[0]["thismonth_investment"].ToString();//7月累计完成投资
                DevelopDirectionText.Text = dt.Rows[0]["PROBLEMS"].ToString();//需协调解决的问题
                TextBox16.Text = dt.Rows[0]["REMARK"].ToString();//备注
                if (dt.Rows[0]["premonthes_investment"].ToString().Trim() != null && dt.Rows[0]["premonthes_investment"].ToString().Trim() != "")
                    TextBox1.Text = decimal.Parse(dt.Rows[0]["premonthes_investment"].ToString().Trim(), NumberStyles.Any)+ "";
                else
                    TextBox1.Text = 0+"";

                //timeStr = new StringUtills().getMonth(dt.Rows[0]["REPORTTIME"].ToString());//
            }

        }
    }

    /// <summary>
    /// -----------------更新数据页面，，在此页面可以保存，可以提交数据
    /// 传递参数为：   projectNumber
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    //protected void Button2_Click(object sender, EventArgs e)
    //{
    //    //判断是新增还是修改 
    //    if ((Request.QueryString["ProjNum"] != null) && (Request.QueryString["ProjNum"].ToString() != ""))
    //    {
    //        // 新增一直数据
    //        projNum = Request.QueryString["ProjNum"].ToString();
    //    }
    //    else
    //    {
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('无法获取到项目标号，无法执行创建报告的操作！')</script>");
    //    }
    //    //提交数据-----修改
    //    string submit = "2"; //表示已经提交的季报
    //    ItemstMonthReportEntity itemst = new ItemstMonthReportEntity();
    //    ItemReportBll bll = new ItemReportBll();
    //    //获取当前时间
    //    DateTime dataTime = System.DateTime.Now;



    //    itemst.Address = AddressText.Text.Trim();               //所属区县
    //    itemst.Area = AREATEXT.Text.Trim();                     //建设地址
    //    itemst.Investmentposition = InvestmentPositionText.Text.Trim();  //投资zhuangt
    //    itemst.Name = ProjectNameRext.Text.Trim();                   //项目名字
    //    itemst.Projectowners = ProjectOwnersText.Text.Trim();     //业主
    //    itemst.DevelopDirection = DevelopDirectionText.Text.Trim();//发展方向
    //    itemst.ProjectFormate = ProjectFormatText.Text.Trim();//形象进度


    //    //非页面输入
    //    itemst.ProjectNum = projNum;
    //    itemst.Audit = "1";
    //    itemst.FinishStatus = "1";
    //    itemst.Image1 = "";
    //    itemst.Image2 = "";
    //    itemst.Image3 = "";
    //    itemst.Image4 = "";
    //    itemst.Image5 = "";
    //    itemst.ModifiState = "1";
    //    itemst.Remark = "";
    //    itemst.Submitstatus = submit;
    //    itemst.ReportTime = dataTime.ToString();
    //    itemst.ProjectNum = projNum;//  ========

    //    int id = int.Parse(HiddenField1.Value);

    //    if (bll.update(1, itemst,id))
    //    {
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('提交成功！')</script>");
    //    }
    //    else
    //    {
    //        Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('提交失败，请重新提交！')</script>");
    //    }


    protected void TextBox22_TextChanged(object sender, EventArgs e)
    {
            ItemBll bll = new ItemBll();
            DataTable dt=bll.selectByID(1,Convert.ToInt32(Request.QueryString["projectID"]));
            if (dt.Rows.Count > 0)
            {
                if (dt.Rows[0]["premonthes_investment"].ToString().Trim() != null && dt.Rows[0]["premonthes_investment"].ToString().Trim()!="")
                    TextBox1.Text = (decimal.Parse(TextBox22.Text.ToString().Trim()) + decimal.Parse(dt.Rows[0]["premonthes_investment"].ToString().Trim(), NumberStyles.Any)) + "";  
                else
                    TextBox1.Text = (float.Parse(TextBox22.Text.ToString().Trim()))+ "";  

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