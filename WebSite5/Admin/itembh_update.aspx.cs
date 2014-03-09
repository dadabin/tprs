using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Model;
using Bll;
using System.Data;
using Dal;

public partial class Admin_itembh_add : System.Web.UI.Page
{
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        StringUtills strUtil = new StringUtills();

        ItembhEntity en = new ItembhEntity();
        ItemBll bll = new ItemBll();

        en.ModifyUser = Session["user_loginName"].ToString();//修改人信息

        en.ID = int.Parse(Request.QueryString["id"].ToString());//ID 

        en.ProjectName = TextBox2.Text.Trim();//工程名称
        en.Address = TextBox3.Text.Trim();//建设地址
        en.FinishTime = TextBox4.Text.Trim();//完工时间
        en.SubmitTime = System.DateTime.Now.ToString();

        if (strUtil.strLength(TextBox5.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('水域面积输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox5.Text != null && TextBox5.Text.Trim() != "")
        {
            float waterArea;
            if (!float.TryParse(TextBox5.Text.Trim(), out waterArea))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('水域面积格式输入不正确！')</script>");
                return;
            }
            en.ZoneArea = waterArea.ToString();//水域面积
        }
        else
        {
            en.ZoneArea="";
        }


        if (strUtil.strLength(TextBox6.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级以上财政输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox6.Text != null && TextBox6.Text.Trim() != "")
        {
            float profiscal;
            if (!float.TryParse(TextBox6.Text.Trim(), out profiscal))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('省级以上财政格式输入不正确！')</script>");
                return;
            }
            en.ProvinciaLevelFiscal = profiscal.ToString();//省级以上财政
        }
        else
        {
            en.ProvinciaLevelFiscal = "";
        }


        if (strUtil.strLength(TextBox7.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级财政输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox7.Text != null && TextBox7.Text.Trim() != "")
        {
            float MunicipalFinance;
            if (!float.TryParse(TextBox7.Text.Trim(), out MunicipalFinance))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('市级财政格式输入不正确！')</script>");
                return;
            }
            en.MunicipalFinance = MunicipalFinance.ToString();//市级财政
        }
        else
        {
            en.MunicipalFinance = "";
        }

        if (strUtil.strLength(TextBox8.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县财政输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox8.Text != null && TextBox8.Text.Trim() != "")
        {
            float CountyFinance;
            if (!float.TryParse(TextBox8.Text.Trim(), out CountyFinance))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('区县财政格式输入不正确！')</script>");
                return;
            }
            en.CountyFinance = CountyFinance.ToString();//区县财政
        }
        else
        {
            en.CountyFinance = "";
        }

        if (strUtil.strLength(TextBox9.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('财政融资输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox9.Text != null && TextBox9.Text.Trim() != "")
        {
            float FinanceFinance;
            if (!float.TryParse(TextBox9.Text.Trim(), out FinanceFinance))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('财政融资格式输入不正确！')</script>");
                return;
            }
            en.FinanceFinance = FinanceFinance.ToString();//财政融资
        }
        else
        {
            en.FinanceFinance = "";
        }

        if (strUtil.strLength(TextBox10.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('社会投入输入的数字不能长于9位！')</script>");
            return;
        }
        if (TextBox10.Text != null && TextBox10.Text.Trim() != "")
        {
            float SocialInvestment;
            if (!float.TryParse(TextBox10.Text.Trim(), out SocialInvestment))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('社会投入格式输入不正确！')</script>");
                return;
            }
            en.SocialInvestment = SocialInvestment.ToString();//社会投入
        }
        else
        {
            en.SocialInvestment = "";
        }

        if (strUtil.strLength(TextBox11.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('群众投入输入的数字不能长于9位！')</script>");
            return;
        }
        if (TextBox11.Text != null && TextBox11.Text.Trim() != "")
        {
            float PublicInvestment;
            if (!float.TryParse(TextBox11.Text.Trim(), out PublicInvestment))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('群众投入格式输入不正确！')</script>");
                return;
            }
            en.PublicInvestment = PublicInvestment.ToString();//群众投入
        }
        else
        {
            en.PublicInvestment = "";
        }

        if (strUtil.strLength(TextBox12.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('其他输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox12.Text != null && TextBox12.Text.Trim() != "")
        {
            float Other;
            if (!float.TryParse(TextBox12.Text.Trim(), out Other))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('其他格式输入不正确！')</script>");
                return;
            }
            en.Other = Other.ToString(); ;//其他
        }
        else
        {
            en.Other = "";
        }

        if (strUtil.strLength(TextBox13.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('占用土地面积输入的数字不能长于9位！')</script>");
            return;
        }

        if (TextBox13.Text != null && TextBox13.Text.Trim() != "")
        {
            float OccupiedArea;
            if (!float.TryParse(TextBox13.Text.Trim(), out OccupiedArea))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('占用土地面积格式输入不正确！')</script>");
                return;
            }
            en.OccupiedArea = OccupiedArea.ToString();//占用土地面积
        }
        else
        {
            en.OccupiedArea = "";
        }
        en.OccupiedType = DropDownList4.SelectedValue;//占用土地方式

        if (strUtil.strLength(TextBox15.Text, 9))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('单价输入的数字不能长于9位！')</script>");
            return;
        }
        if (TextBox15.Text != null && TextBox15.Text.Trim() != "")
        {

            float UnitPrice;
            if (!float.TryParse(TextBox15.Text.Trim(), out UnitPrice))
            {
                Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('单价格式输入不正确！')</script>");
                return;
            }
            en.UnitPrice = UnitPrice.ToString();//单价（元/年、亩）
        }
        else
        {
            en.UnitPrice = "";
        }
        en.ImageProgress = TextBox16.Text.Trim();//目前为止形象进度
        en.ManageSubject = TextBox17.Text.Trim();//管护主体
        en.ProgressCategory = DropDownList1.SelectedValue;

        en.Image1 = Lab_Image1_old.Text;
        en.Image2 = Lab_Image2_old.Text;
        en.Image3 = Lab_Image3_old.Text;
        en.Image4 = Lab_Image4_old.Text;
        en.Image5 = Lab_Image5_old.Text;


        if (bll.update(3,en,Session["user_loginName"].ToString().Trim()))
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改成功！')</script>");
        }
        else
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "msg", "<script>alert('修改失败！')</script>");
        }



        }



    public void bind()
    {
        if (Request.QueryString["id"] != null && Request.QueryString["id"].ToString() != "")
        {

            StringUtills utils = new StringUtills();
            ItemBll bll=new ItemBll();
            DataTable dt=bll.selectByID(3,Convert.ToInt32(Request.QueryString["id"]));
            
            if (dt.Rows.Count>0)
            {
                Label2.Text = utils.getChineseLocaltion(dt.Rows[0]["AREA"].ToString().Trim());
                TextBox2.Text = dt.Rows[0]["PROJECTNAME"].ToString();//工程名称
                TextBox3.Text = dt.Rows[0]["ADDRESS"].ToString();//建设地址
                TextBox4.Text = dt.Rows[0]["FINISHTIME"].ToString();//完工时间
                TextBox5.Text = dt.Rows[0]["ZoneArea"].ToString();//水域面积
                TextBox6.Text = dt.Rows[0]["ProvinciaLevelFiscal"].ToString();//省级以上财政
                TextBox7.Text = dt.Rows[0]["MUNICIPALFINANCE"].ToString();// 市级以上财政
                TextBox8.Text = dt.Rows[0]["CountyFinance"].ToString();//县级以上财政
                TextBox9.Text = dt.Rows[0]["FinanceFinance"].ToString();//财政融资
                TextBox10.Text = dt.Rows[0]["SocialInvestment"].ToString();//社会投入
                TextBox11.Text = dt.Rows[0]["PublicInvestment"].ToString();//群众投入
                TextBox12.Text = dt.Rows[0]["Other"].ToString();//其他
                TextBox13.Text = dt.Rows[0]["OccupiedArea"].ToString();//占用土地面积
                DropDownList4.SelectedValue = dt.Rows[0]["OccupiedType"].ToString();//占用土地方式
                TextBox15.Text = dt.Rows[0]["UnitPrice"].ToString();//单价
                TextBox16.Text = dt.Rows[0]["ImageProgress"].ToString();//目前为止形象进度
                TextBox17.Text = dt.Rows[0]["ManageSubject"].ToString();//管护主体
                DropDownList1.SelectedValue = dt.Rows[0]["ProgressCategory"].ToString();

                Lab_Image1_new.Text = dt.Rows[0]["IMAGE1"].ToString();
                Lab_Image2_new.Text = dt.Rows[0]["IMAGE2"].ToString();
                Lab_Image3_new.Text = dt.Rows[0]["IMAGE3"].ToString();
                Lab_Image4_new.Text = dt.Rows[0]["IMAGE4"].ToString();
                Lab_Image5_new.Text = dt.Rows[0]["IMAGE5"].ToString();
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