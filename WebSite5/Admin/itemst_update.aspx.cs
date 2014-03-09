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
    public DateTime submitTime;
    public int nowYear=System.DateTime.Now.Year-1  ;
    public int nowMonth = System.DateTime.Now.Month-1;
    public int preYear = System.DateTime.Now.Year;
    public int preMonth = System.DateTime.Now.Month;
    public Admin_itemst_add()
    {
        nowMonth = System.DateTime.Now.Month-1;
        if (nowMonth == 0)
        {
            nowMonth = 1;
        }
    }



    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");
            bind();
            initPage();
            bindPic();
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
        en.ModifyUser = Session["user_loginName"].ToString();
        en.Id = int.Parse(Request.QueryString["id"].ToString());


        en.ProjectName = TextBox1.Text ;//项目名称
        en.Address = TextBox2.Text ;//项目地址
        en.ConstructionAge = TextBox11.Text ;//建设年限
        en.ConstructionType =  DropDownList6.Text ;//建设性质
        en.ContentScale = TextBox15.Text;//建设内容及规模
        en.ProjectNature = int.Parse(DropDownList6.SelectedValue);//项目性质 *******弃用

        if (strUtil.strLength(TextBox4.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资输入的数字不能长于9位！')</script>");
            return;
        }
        

        if (TextBox4.Text != null && TextBox4.Text.Trim() != "")
        {
            float totlemoney = 0;
            if (float.TryParse(TextBox4.Text.Trim(), out totlemoney))
            {
                en.TotleMoney = float.Parse(TextBox4.Text.Trim());//总投资
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('总投资输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.TotleMoney = 0;
        }
        


        //en.ProvincialMoney = float.Parse(TextBox5.Text.Trim());//省级资金

        if (strUtil.strLength(TextBox5.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级资金输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox5.Text != null && TextBox5.Text.Trim() != "")
        {
            float provincialMoney = 0;
            if (float.TryParse(TextBox5.Text.Trim(), out provincialMoney))
            {
                en.ProvincialMoney = float.Parse(TextBox5.Text.Trim());//省级资金
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级资金输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.ProvincialMoney = 0;
        }


       // en.DistrictMoney = float.Parse(TextBox6.Text.Trim());//区县资金

        if (strUtil.strLength(TextBox6.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县资金输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox6.Text != null && TextBox6.Text.Trim() != "")
        {
            float districtMoney = 0;
            if (float.TryParse(TextBox6.Text.Trim(), out districtMoney))
            {
                en.DistrictMoney = float.Parse(TextBox6.Text.Trim());//区县资金
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县资金输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.DistrictMoney = 0;
        }


        //en.Plane_investment = TextBox7.Text;// **年计划投资

        if (strUtil.strLength(TextBox7.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当年计划投资输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox7.Text != null && TextBox7.Text.Trim() != "")
        {
            float plane_investment = 0;
            if (float.TryParse(TextBox7.Text.Trim(), out plane_investment))
            {
                en.Plane_investment = TextBox7.Text.Trim();//区县资金
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县资金输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.Plane_investment = "";
        }




      //  en.CompanySelf = float.Parse(TextBox8.Text.Trim());//企业自筹

        if (strUtil.strLength(TextBox8.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('企业自筹输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox8.Text != null && TextBox8.Text.Trim() != "")
        {
            float companySelf = 0;
            if (float.TryParse(TextBox8.Text.Trim(), out companySelf))
            {
                en.CompanySelf = float.Parse(TextBox8.Text.Trim());//企业自筹
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('企业自筹输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.CompanySelf = 0;
        }


        //TextBox7.Text = dt.Rows[0]["COMPANYSELF"].ToString();//年度计划投资

        //en.CentralMoney = float.Parse(TextBox9.Text.Trim());//中央资金S

        if (strUtil.strLength(TextBox9.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('中央资金输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox9.Text != null && TextBox9.Text.Trim() != "")
        {
            float centralMoney = 0;
            if (float.TryParse(TextBox9.Text.Trim(), out centralMoney))
            {
                en.CentralMoney = float.Parse(TextBox9.Text.Trim());//中央资金S
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('中央资金输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.CentralMoney = 0;
        }


       // en.MunicipalMoney = float.Parse(TextBox19.Text.Trim());//市级资金

        if (strUtil.strLength(TextBox19.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级资金输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox19.Text != null && TextBox19.Text.Trim() != "")
        {
            float municipalMoney = 0;
            if (float.TryParse(TextBox19.Text.Trim(), out municipalMoney))
            {
                en.MunicipalMoney = float.Parse(TextBox19.Text.Trim());//市级资金
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级资金输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.MunicipalMoney = 0;
        }




       // en.BankLoan = float.Parse(TextBox20.Text.Trim());//银行贷款
        if (strUtil.strLength(TextBox20.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('银行贷款输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox20.Text != null && TextBox20.Text.Trim() != "")
        {
            float bankLoan = 0;
            if (float.TryParse(TextBox20.Text.Trim(), out bankLoan))
            {
                en.BankLoan = float.Parse(TextBox20.Text.Trim());//银行贷款
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('银行贷款输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.BankLoan = 0;
        }


       // en.Thisyear_investment = TextBox21.Text;//至**年年底累计完成投资

        if (strUtil.strLength(TextBox21.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('至去年年底累计完成投资输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox21.Text != null && TextBox21.Text.Trim() != "")
        {
            float thisyear_investment = 0;
            if (float.TryParse(TextBox21.Text.Trim(), out thisyear_investment))
            {
                en.Thisyear_investment = TextBox21.Text;//至**年年底累计完成投资
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('至去年年底累计完成投资输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.Thisyear_investment = "";
        }

        en.ProgressNow = TextBox3.Text; //目前形象进度

        en.PredictStartTime=TextBox13.Text ;//预计开工时间

        en.PredictFinishTime=TextBox16.Text ;//预计竣工时间

       // en.GetLandTargets = float.Parse(TextBox22.Text.Trim());//已取得土地指标
        if (strUtil.strLength(TextBox22.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已取得土地指标输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox22.Text != null && TextBox22.Text.Trim() != "")
        {
            float getLandTargets = 0;
            if (float.TryParse(TextBox22.Text.Trim(), out getLandTargets))
            {
                 en.GetLandTargets = float.Parse(TextBox22.Text.Trim());//已取得土地指标
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已取得土地指标输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.GetLandTargets = 0;
        }



       // en.Premonthes_investment = TextBox12.Text;//1-月累计完成投资额

        if (strUtil.strLength(TextBox12.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至上月累计完成投资额输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox12.Text != null && TextBox12.Text.Trim() != "")
        {
            float premonthes_investment = 0;
            if (float.TryParse(TextBox12.Text.Trim(), out premonthes_investment))
            {
                en.Premonthes_investment = TextBox12.Text;//1-月累计完成投资额
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('1至上月累计完成投资额输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.Premonthes_investment = "";
        }


        //en.Thismonth_investment = this_month_finish.Text;//月累计完成投资额
        if (strUtil.strLength(this_month_finish.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月累计完成投资额输入的数字不能长于9位！')</script>");
            return;
        }


        if (this_month_finish.Text != null && this_month_finish.Text.Trim() != "")
        {
            float thismonth_investment = 0;
            if (float.TryParse(this_month_finish.Text.Trim(), out thismonth_investment))
            {
                en.Thismonth_investment = this_month_finish.Text;//月累计完成投资额
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('当月累计完成投资额输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.Thismonth_investment = "";
        }


        en.Problems = TextBox18.Text;//需协调解决的问题
        en.ProgressCategory = DropDownList2.SelectedValue;// 四个一批范畴

        //en.PlanLandTargets =  float.Parse(TextBox22.Text.Trim()) ;//拟申请土地指标
        if (strUtil.strLength(TextBox22.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('拟申请土地指标输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox22.Text != null && TextBox22.Text.Trim() != "")
        {
            float planLandTargets = 0;
            if (float.TryParse(TextBox22.Text.Trim(), out planLandTargets))
            {
                en.PlanLandTargets = float.Parse(TextBox22.Text.Trim());//拟申请土地指标
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('拟申请土地指标输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.PlanLandTargets = 0;
        }


        //en.GetLandTargets = float.Parse(TextBox10.Text.Trim()) ;//已使用土地指标
        if (strUtil.strLength(TextBox10.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已使用土地指标输入的数字不能长于9位！')</script>");
            return;
        }


        if (TextBox10.Text != null && TextBox10.Text.Trim() != "")
        {
            float getLandTargets = 0;
            if (float.TryParse(TextBox10.Text.Trim(), out getLandTargets))
            {
                en.GetLandTargets = float.Parse(TextBox10.Text.Trim());//已使用土地指标
            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('已使用土地指标输入的格式不正确！')</script>");
                return;
            }
        }
        else
        {
            en.GetLandTargets = 0;
        }

       en.Remark= TextBox14.Text;//备注
        en.Problems = TextBox18.Text;//需要协调的问题

        en.GovernmentProje = DropDownList3.SelectedValue;//是否是政府项目

        en.LandWay = "";//弃用的字段=========！！！
        en.Image1 = Lab_Image1_old.Text;
        en.Image2 = Lab_Image2_old.Text;
        en.Image3 = Lab_Image3_old.Text;
        en.Image4 = Lab_Image4_old.Text;
        en.Image5 = Lab_Image5_old.Text;

        if (bll.update(1, en, Session["user_loginName"].ToString()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！')</script>");
        }



    }

    private void initPage()
    {
        //获取当前登陆的业主的信息
        DataTable loginedUser = (DataTable)Session["userEntity_logined"];
        //将业主的所属区县的信息显示到页面
        Label1.Text = new StringUtills().getChineseLocaltion(loginedUser.Rows[0]["AREA"].ToString()); //loginedUser.Rows[0]["AREA"].ToString();
    }

    public void bind()
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {
            ItemBll bll = new ItemBll();
            int id = int.Parse(Request.QueryString["id"]);
            int type = 1;
            DataTable dt = bll.selectByID(type, id);
            StringUtills utils = new StringUtills();

            if (dt.Rows.Count > 0)
            {
                Label1.Text = utils.getChineseLocaltion(dt.Rows[0]["AREA"].ToString().Trim());
                TextBox1.Text = dt.Rows[0]["PROJECTNAME"].ToString();//项目名称
                TextBox2.Text = dt.Rows[0]["ADDRESS"].ToString();//项目地址
                TextBox11.Text = dt.Rows[0]["CONSTRUCTIONAGE"].ToString();//建设年限
                DropDownList6.Text = dt.Rows[0]["CONSTRUCTIONTYPE"].ToString();//建设性质
                TextBox15.Text = dt.Rows[0]["CONTENTSCALE"].ToString();//建设内容及规模
                DropDownList6.SelectedValue = dt.Rows[0]["PROJECTNATURE"].ToString();//项目性质 *******弃用
               
                TextBox4.Text = dt.Rows[0]["TOTLEMONEY"].ToString();//总投资
                TextBox5.Text = dt.Rows[0]["PROVINCIALMONEY"].ToString();//省级资金
                TextBox6.Text = dt.Rows[0]["DISTRICTMONEY"].ToString();//区县资金
                TextBox7.Text = dt.Rows[0]["plane_investment"].ToString();// **年计划投资

                TextBox8.Text = dt.Rows[0]["COMPANYSELF"].ToString();//企业自筹
                //TextBox7.Text = dt.Rows[0]["COMPANYSELF"].ToString();//年度计划投资

                TextBox9.Text = dt.Rows[0]["CENTRALMONEY"].ToString();//中央资金S
                TextBox19.Text = dt.Rows[0]["MUNICIPALMONEY"].ToString();//市级资金
                TextBox20.Text = dt.Rows[0]["BANKLOAN"].ToString();//银行贷款
                TextBox21.Text = dt.Rows[0]["thisyear_investment"].ToString();//至**年累计完成投资

                TextBox3.Text = dt.Rows[0]["PROGRESSNOW"].ToString(); //目前形象进度

                TextBox13.Text = dt.Rows[0]["PREDICTSTARTTIME"].ToString();//预计开工时间

                TextBox16.Text = dt.Rows[0]["PREDICTFINISHTIME"].ToString();//预计竣工时间

                TextBox22.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已取得土地指标


                this_month_finish.Text = dt.Rows[0]["thismonth_investment"].ToString();//月累计完成投资额
                TextBox12.Text = dt.Rows[0]["premonthes_investment"].ToString();//1-月累计完成投资额
               

                TextBox18.Text = dt.Rows[0]["PROBLEMS"].ToString();//需协调解决的问题
                DropDownList2.SelectedValue = dt.Rows[0]["PROGRESSCATEGORY"].ToString();// 四个一批范畴

                TextBox22.Text = dt.Rows[0]["PLANLANDTARGETS"].ToString();//拟申请土地指标
                TextBox10.Text = dt.Rows[0]["GETLANDTARGETS"].ToString();//已使用土地指标


                TextBox14.Text = dt.Rows[0]["REMARK"].ToString();//备注
                TextBox18.Text = dt.Rows[0]["PROBLEMS"].ToString();//需要协调的问题


                DropDownList3.SelectedValue = dt.Rows[0]["GOVERNMENTPROJE"].ToString().Trim();//是否是政府项目
                //TextBox23.Text = dt.Rows[0]["ACTUALUSELAND"].ToString();//项目实际使用土地指标

                submitTime = DateTime.Parse(dt.Rows[0]["SUBMITTIME"].ToString().Trim());//年份时间
                Lab_Image1_new.Text = dt.Rows[0]["IMAGE1"].ToString().Trim();
                Lab_Image2_new.Text = dt.Rows[0]["IMAGE2"].ToString().Trim();
                Lab_Image3_new.Text = dt.Rows[0]["IMAGE3"].ToString().Trim();
                Lab_Image4_new.Text = dt.Rows[0]["IMAGE4"].ToString().Trim();
                Lab_Image5_new.Text = dt.Rows[0]["IMAGE5"].ToString().Trim();

            }
            else
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('未查出数据！')</script>");
            }

            

            //下面给出所有项的前台ID
            //所属区县  Label1
            //项目名称  TextBox1
            //建设地址   TextBox2
            //建设年限    TextBox11

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