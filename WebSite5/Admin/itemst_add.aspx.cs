using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_itemst_add : System.Web.UI.Page
{

    //public string timeStr = new StringUtills().getMonth(DateTime.Now.ToString());//

    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            initPage();
            bind();
        }
    }
    /// <summary>
    /// 保存信息
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringUtills strUtil = new StringUtills();
        ItemstEntity en = new ItemstEntity();
        ItemBll bll = new ItemBll();
        en.LoginName = Session["user_loginName"].ToString();
        //所属区县不存入数据
        en.ProjectName = TextBox1.Text.Trim();//项目名称
        en.Address = TextBox2.Text.Trim();//项目地址
        en.ConstructionAge = TextBox11.Text.Trim() == null ? " " : TextBox11.Text.Trim();//建设年限
        en.ConstructionType = DropDownList6.SelectedValue;//建设性质

      // en.Thisyear_investment =  TextBox21.Text.Trim();//到**年底累计完成投资
       float thisyear_investment = 0;
       if (strUtil.strLength(TextBox21.Text, 9))
       {
           Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('到上年底累计完成投资输入的数字不能长于9位！')</script>");
           return;
       }

       if (TextBox21.Text.Trim() != null && TextBox21.Text.Trim() != "")
       {
           if (float.TryParse(TextBox21.Text.Trim(), out thisyear_investment))
           {
               en.Thisyear_investment = thisyear_investment.ToString();
           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('到上年底累计完成投资格式输入有误！')</script>");
               return;

           }
       }
       else
       {
           en.Thisyear_investment = "";
       }
     
      // en.Plane_investment = TextBox7.Text.Trim();//**年计划投资
       if (strUtil.strLength(TextBox7.Text, 9))
       {
           Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('年计划投资输入的数字不能长于9位！')</script>");
           return;
       }

       float plane_investement=0;
       if (TextBox7.Text.Trim() != null && TextBox7.Text.Trim() != "")
       {
           if (float.TryParse(TextBox7.Text.Trim(), out plane_investement))
           {
               en.Plane_investment = plane_investement.ToString();
           }
           else
           {
               Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('年计划投资格式输入有误！')</script>");
               return;

           }
       }
       else
       {
           en.Plane_investment = "";
       }

        en.ProgressCategory = DropDownList2.SelectedValue;//进展类别 ----- 四个一批范畴！！！！
        if (strUtil.strLength(TextBox4.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资输入的数字不能长于9位！')</script>");
            return;
        }
        float TotalMoney;
        if(!(float.TryParse(TextBox4.Text.Trim(),out TotalMoney)))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资格式输入有误！')</script>");
            return;
        }
        en.TotleMoney = TotalMoney;//总投资

        if (strUtil.strLength(TextBox9.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('中央资金输入的数字不能长于9位！')</script>");
            return;
        }
        float CenterMoney;
        if (TextBox9.Text.Trim() != null && TextBox9.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox9.Text.Trim(), out CenterMoney)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('中央资金格式输入有误！')</script>");
                return;
            }
            en.CentralMoney = CenterMoney;//中央资金
        }
        else
        {
            en.CentralMoney = 0;//中央资金
        }

        if (strUtil.strLength(TextBox5.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级资金输入的数字不能长于9位！')</script>");
            return;
        }
        float ProvincialMoney;
        if (TextBox5.Text.Trim() != null && TextBox5.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox5.Text.Trim(), out ProvincialMoney)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级资金格式输入有误！')</script>");
                return;
            }
            en.ProvincialMoney = ProvincialMoney;//省级资金
        }
        else
        {
            en.ProvincialMoney = 0;//省级资金
        }


        if (strUtil.strLength(TextBox19.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级资金输入的数字不能长于9位！')</script>");
            return;
        }
        float MunicipalMoney;

        if (TextBox19.Text.Trim() != null && TextBox19.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox19.Text.Trim(), out MunicipalMoney)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级资金格式输入有误！')</script>");
                return;
            }
            en.MunicipalMoney = MunicipalMoney;//市级资金
        }
        else
        {
            en.MunicipalMoney = 0;//市级资金
        }


        if (strUtil.strLength(TextBox6.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县资金输入的数字不能长于9位！')</script>");
            return;
        }
        float DistrictMoney;

        if (TextBox6.Text.Trim() != null && TextBox6.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox6.Text.Trim(), out DistrictMoney)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县资金格式输入有误！')</script>");
                return;
            }
            en.DistrictMoney = DistrictMoney;//区县资金
        }
        else
        {
            en.DistrictMoney = 0;//区县资金
        }

        if (strUtil.strLength(TextBox20.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('银行贷款输入的数字不能长于9位！')</script>");
            return;
        }

        float BankLoan;

        if (TextBox20.Text.Trim() != null && TextBox20.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox20.Text.Trim(), out BankLoan)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('银行贷款格式输入有误！')</script>");
                return;
            }
            en.BankLoan = BankLoan;//银行贷款
        }
        else 
        {
            en.BankLoan = 0;//银行贷款
        }

        if (strUtil.strLength(TextBox8.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('企业自筹输入的数字不能长于9位！')</script>");
            return;
        }
        float CompanySelf;

        if (TextBox8.Text.Trim() != null && TextBox8.Text.Trim()!= "")
        {
            if (!(float.TryParse(TextBox8.Text.Trim(), out CompanySelf)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('企业自筹格式输入有误！')</script>");
                return;
            }
            en.CompanySelf = CompanySelf;//企业自筹
        }
        else
        {
            en.CompanySelf = 0;//企业自筹
        }

        String progressNow = TextBox3.Text.Trim();//目前为止形象进度
        if(progressNow.Length > 2000)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('字符长度不得超过2000！')</script>");
            return;
        }
        en.ProgressNow = progressNow;

        en.PredictStartTime = TextBox13.Text.Trim();//开工(计划开工)时间
        en.PredictFinishTime = TextBox16.Text.Trim();//计划竣工时间

        en.Problems = TextBox18.Text.Trim();//需协调解决的问题
        en.Remark = TextBox14.Text.Trim();//备注
        en.LandWay = "";
        if (strUtil.strLength(TextBox10.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已取得土地指标输入的数字不能长于9位！')</script>");
            return;
        }
        float GetLandTargets=0;
        if (TextBox10.Text.Trim() != null && TextBox10.Text.Trim()!="")
        {
            if (!(float.TryParse(TextBox10.Text.Trim(), out GetLandTargets)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已取得土地指标格式输入有误！')</script>");
                return;
            }
        }
        en.GetLandTargets = GetLandTargets;//已取得土地指标
        float PlanLandTargets = 0;

        if (strUtil.strLength(TextBox22.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('拟申请土地指标输入的数字不能长于9位！')</script>");
            return;
        }
        if (TextBox22.Text.Trim() != null && TextBox22.Text.Trim()!="")
        {
               if (!(float.TryParse(TextBox22.Text.Trim(), out PlanLandTargets)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('拟申请土地指标格式输入有误！')</script>");
                return;
            }
        }
        en.PlanLandTargets = PlanLandTargets;                               //拟申请土地指标

        if (strUtil.strLength(TextBox12.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资额输入的数字不能长于9位！')</script>");
            return;
        }
        float this_month;
        if (TextBox12.Text.Trim() != null && TextBox12.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox12.Text.Trim(), out this_month)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月完成投资额格式输入有误！')</script>");
                return;
            }
            en.Thismonth_investment = this_month+"";//当月完成投资  
            }
        else 
        {
            en.UseLandTargets = 0;//当月完成投资 
        }

        if (strUtil.strLength(TextBox17.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至当月完成投资额输入的数字不能长于9位！')</script>");
            return;
        }
        float preMonthes_investment;

        if (TextBox17.Text.Trim() != null && TextBox17.Text.Trim() != "")
        {
            if (!(float.TryParse(TextBox17.Text.Trim(), out preMonthes_investment)))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至当月完成投资额格式输入有误！')</script>");
                return;
            }
            en.Premonthes_investment = preMonthes_investment + "";//当月完成投资  
        }
        else
        {
            en.Premonthes_investment = "";//当月完成投资 
        }
        if (DropDownList3.SelectedValue == "1")
        {
            en.GovernmentProje = "1";//是否政府投资项
        }
        else
        {
            en.GovernmentProje = "0";//是否政府投资项
        }
        if (TextBox15.Text.Trim().Length > 2000)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('字符长度过长，应保持在2000以内！')</script>");
            return;
        }
        en.ContentScale = TextBox15.Text.Trim();  
    
        //=========图片
        en.Image1 = Lab_Image1_old.Text;
        en.Image2 = Lab_Image2_old.Text;
        en.Image3 = Lab_Image3_old.Text;
        en.Image4 = Lab_Image4_old.Text;
        en.Image5 = Lab_Image5_old.Text;
        ///////////添加数据到数据库///////////////
        if (bll.isAddItem(1, en))
        {
            if (bll.add(1, en))
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
    private void initPage()
    {
        //获取当前登陆的业主的信息
        DataTable loginedUser = (DataTable)Session["userEntity_logined"];
        //将业主的所属区县的信息显示到页面
        Label1.Text = new StringUtills().getChineseLocaltion(loginedUser.Rows[0]["AREA"].ToString());
    }
    public void TxtName_TextChanged(object sender, EventArgs e)
    {
        string inputName = TextBox1.Text.ToString().Trim();
        ItemBll bll = new ItemBll();
        if (bll.isExitProject(1, inputName))
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
                string picPath =  new DateTimeUtil().getNowTimeString() + fileUpload.FileName.Substring(fileUpload.FileName.IndexOf("."));
                fileUpload.SaveAs(Server.MapPath("~/Admin/upload/") + picPath);
                my_dt.Rows[id-1]["id"] = id;
                my_dt.Rows[id-1]["picPath"] ="upload/"+ picPath;
                switch(e.Item.ItemIndex){
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
                        if(Lab_Image2_old.Text != Lab_Image2_new.Text){
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
        if(System.IO.File.Exists(Server.MapPath("~/Admin/")+picPath))
        {
            System.IO.File.Delete(Server.MapPath("~/Admin/") + picPath);
        }
    }

}