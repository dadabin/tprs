using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_index : System.Web.UI.Page
{
    public string currentPage = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (Session["userEntity_logined"] == null)
                Response.Redirect("~/login.aspx");

        }

    }

    /// <summary>
    /// 加载菜单
    /// </summary>
    /// <returns></returns>
    public string loadMenu()
    {
        string re = "";
        if (Session["RoleID"] != null && Session["RoleID"].ToString() != "")
        {
            String roleStr = Session["RoleID"].ToString();
            int roleID;
            if (int.TryParse(roleStr, out roleID))
            {
                switch (roleID)
                {

                    case 1://市级领导
                        {
                            currentPage = "Admin/itemselect_admin_allProject.aspx";
                            re = " ";
                            re += "   <div class=\"unit current\">" +
  "<h5>项目管理</h5>" +
    "<ul class=\"rr\">" +
    "<li><a href=\"javascript:div_load('Admin/itemselect_admin_allProject.aspx','》项目管理》已申报项目');\">已申报项目</a></li>" +
     "<li><a href=\"javascript:div_load('Admin/itemselect_admin_allReport.aspx','》项目管理》报告点评');\">报告点评</a></li>" +
      //  "<li> <a href=\"javascript:div_load('Admin/report_admin2.aspx');\" > 二级审核员报告列表 </a></li>" +
  "</ul>" + "</div>";
                       
                            re += "<div class=\"unit\">" +
                             "<h5>统计报表</h5>" +
                             "<ul class=\"rr\">" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=st','》统计报表》重大项目月报');\" > 重大项目月报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=jg','》统计报表》景观农业季报');\" > 景观农业季报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=bh','》统计报表》百湖工程季报');\" > 百湖工程季报 </a></li>" +
                             "</ul>" +
                            "</div>";

                            re += "<div class=\"unit\">" +
                        "<h5>报告审查</h5>" +
                        "<ul class=\"rr\">" +
                             "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=st','》报告审查》重大项目季报');\" > 重大项目季报</a></li>" +
                              "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=jg','》报告审查》景观农业季报');\" >  景观农业季报</a></li>" +
                              "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=bh','》报告审查》百湖工程季报');\" > 百湖工程季报</a></li>" +
                              "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=zb','》报告审查》植被恢复季报');\" > 植被恢复季报</a></li>" +
                              "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=ts','》报告审查》特色旅游村季报');\" > 特色旅游村季报</a></li>" +
                              "<li> <a href=\"javascript:div_load('Admin/season_report_admin.aspx?itemtype=xc','》报告审查》乡村旅游度假区或A级景区季报');\" > 乡村旅游度假区或A级景区季报</a></li>" +
                        "</ul>" +
                       "</div>";


                            re += "<div class=\"unit\">" +
"<h5>个人设置</h5>" +
"<ul class=\"rr\">" +
   "<li> <a href=\"javascript:div_load('Admin/updateInformation.aspx','》个人设置》个人资料');\" > 个人资料</a></li>" +
  "<li> <a href=\"javascript:div_load('Admin/updatePassword.aspx','》个人设置》修改密码');\" > 修改密码</a></li>" +
"</ul>" +
"</div>";
                        } break;
                    case 2://二级审核员
                        {
                            currentPage = "Admin/itemselect_admin2.aspx";
                            re = "";
                            re += " <div class=\"unit current\">" +
"<h5>项目管理</h5>" +
"<ul class=\"rr\">" +
"<li><a href=\"javascript:div_load('Admin/itemselect_admin2.aspx','》项目管理》报表项目');\" > 报表项目</a></li>" +
"<li><a href=\"javascript:div_load('Admin/itemselect_admin2_report.aspx','》项目管理》季报月报');\" >季报月报</a></li>" +
//"<li><a href=\"javascript:div_load('Admin/itemreportselect_admin2.aspx');\" >统计报表</a></li>" +
"</ul>" +
"</div>";
                            re += "<div class=\"unit\">" +
"<h5>季报填写</h5>" +
"<ul class=\"rr\">" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=st','》季报填写》重大项目季报');\" > 重大项目季报</a></li>" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=jg','》季报填写》景观农业季报');\" >  景观农业季报</a></li>" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=bh','》季报填写》百湖工程季报');\" > 百湖工程季报</a></li>" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=zb','》季报填写》植被恢复季报');\" > 植被恢复季报</a></li>" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=ts','》季报填写》特色旅游村季报');\" > 特色旅游村季报</a></li>" +
"<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=xc','》季报填写》乡村旅游度假区或A级景区季报');\" > 乡村旅游度假区或A级景区季报</a></li>" +
"</ul>" +
"</div>";
                            re += " <div class=\"unit\">" +
  "<h5>统计报表</h5>" +
  "<ul class=\"rr\">" +
                                //"<li><a href=\"javascript:div_load('Admin/itemreportsubmitselect_admin2.aspx','');\" > 填写报告 </a></li>" +
                                // "<li><a href=\"javascript:div_load('Admin/report_admin2.aspx','');\" >历史报告</a></li>" +
   "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=st','》统计报表》重大项目月报');\" > 重大项目月报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=jg','》统计报表》景观农业季报');\" > 景观农业季报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=bh','》统计报表》百湖工程季报');\" > 百湖工程季报 </a></li>" +
  "</ul>" +
 "</div>";
                            re +="  <div class=\"unit\">"+
  "<h5>账户管理</h5>"+
  "<ul class=\"rr\">"+

    "<li> <a href=\"javascript:div_load('Admin/admin_manage.aspx','》账号管理》市级领导列表');\" > 市级领导列表</a></li>" +
    "<li><a href=\"javascript:div_load('Admin/admin1_manage.aspx','》账号管理》区县审核员列表');\" > 区县审核员列表</a></li>" +
   "<li><a href=\"javascript:div_load('Admin/admin2_manage.aspx','》账号管理》二级审核员列表');\" > 二级审核员列表</a></li>" +
  "</ul>"+
 "</div>";
                            re += "<div class=\"unit\">" +
"<h5>个人设置</h5>" +
"<ul class=\"rr\">" +
   "<li> <a href=\"javascript:div_load('Admin/updateInformation.aspx','》个人设置》个人资料');\" > 个人资料</a></li>" +
  "<li> <a href=\"javascript:div_load('Admin/updatePassword.aspx','》个人设置》修改密码');\" > 修改密码</a></li>" +
"</ul>" +
"</div>";

                            re += "<div class=\"unit\">" +
"<h5>系统日志</h5>" +
"<ul class=\"rr\">" +
 "<li> <a href=\"javascript:div_load('Admin/log.aspx','》系统日志》查看日志');\" >查看日志</a></li>" +
"</ul>" +
"</div>";
                        } break;
                    case 3://一级审核员
                        {
                            currentPage = "Admin/itemselect_admin1.aspx";
                            re = "";
                            re += " <div class=\"unit current\">" +
"<h5>项目管理</h5>" +
"<ul class=\"rr\">" +
"<li><a href=\"javascript:div_load('Admin/itemselect_admin1.aspx','》项目管理》报表项目');\" > 报表项目 </a></li>" +
"<li><a href=\"javascript:div_load('Admin/itemreportselect_admin1.aspx','》项目管理》季报月报');\" > 季报月报 </a></li>" +
"<li><a href=\"javascript:div_load('Admin/itemsubmitselect_admin1.aspx','》项目管理》新建项目审批');\" > 新建项目审批 </a></li>" +
"<li><a href=\"javascript:div_load('Admin/itemstateselect_admin1.aspx','》项目管理》项目状态设置');\" > 项目状态设置 </a></li>" +
"<li><a href=\"javascript:div_load('Admin/statistics_admin1.aspx','》项目管理》漏项统计');\" > 漏项统计 </a></li>" +
"</ul>" +
"</div>";
                            re += "<div class=\"unit\">" +
"<h5>季报填写</h5>" +
"<ul class=\"rr\">" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=st','》季报填写》重大项目季报');\" > 重大项目季报</a></li>" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=jg','》季报填写》景观农业季报');\" >  景观农业季报</a></li>" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=bh','》季报填写》百湖工程季报');\" > 百湖工程季报</a></li>" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=zb','》季报填写》植被恢复季报');\" > 植被恢复季报</a></li>" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=ts','》季报填写》特色旅游村季报');\" > 特色旅游村季报</a></li>" +
 "<li> <a href=\"javascript:div_load('Admin/season_list.aspx?itemtype=xc','》季报填写》乡村旅游度假区或A级景区季报');\" > 乡村旅游度假区或A级景区季报</a></li>" +
"</ul>" +
"</div>";
                            re += "<div class=\"unit\">" +
                            "<h5>统计报表</h5>" +
"<ul class=\"rr\">" +
                                // "<li> <a href=\"javascript:div_load('Admin/excel_report_admin1.aspx?itemtype=st');\" > 重大项目月报</a></li>" +
                                //"<li> <a href=\"javascript:div_load('Admin/excel_report_admin1.aspx?itemtype=jg');\" >  景观农业季报</a></li>" +
                                //"<li> <a href=\"javascript:div_load('Admin/excel_report_admin1.aspx?itemtype=bh');\" > 百湖工程季报</a></li>" +
                                //"<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=st');\" > 重大项目月报 </a></li>" +
                                //"<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=jg');\" > 景观农业季报 </a></li>" +
                                //"<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=bh');\" > 百湖工程季报 </a></li>" +
       "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=st','》统计报表》重大项目月报');\" > 重大项目月报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=jg','》统计报表》景观农业季报');\" > 景观农业季报 </a></li>" +
                                "<li> <a href=\"javascript:div_load('Admin/excel_report_admin2.aspx?itemtype=bh','》统计报表》百湖工程季报');\" > 百湖工程季报 </a></li>" +
"</ul>" +
"</div>";
                            re += "<div class=\"unit\">" +
  "<h5>账户管理</h5>" +
  "<ul class=\"rr\">" +
       "<li><a href=\"javascript:div_load('Admin/user_manage.aspx','》账户管理》业主列表');\" > 业主列表 </a></li>" +
  "</ul>" +
 "</div>";



                            re += "<div class=\"unit\">" +
  "<h5>个人设置</h5>" +
  "<ul class=\"rr\">" +
     "<li> <a href=\"javascript:div_load('Admin/updateInformation.aspx','》个人设置》个人资料');\" > 个人资料</a></li>" +
    "<li> <a href=\"javascript:div_load('Admin/updatePassword.aspx','》个人设置》修改密码');\" > 修改密码</a></li>" +
  "</ul>" +
 "</div>";
                          
                            

                        } break;
                    case 4://业主
                        {
                            /****
                             *   "<li><a href=\"javascript:div_load('Admin/itemzb_add.aspx','');\" > 生态植被与恢复 </a></li>" +
                             *   "<li><a href=\"javascript:div_load('Admin/itemts_add.aspx','');\" > 特色旅游村 </a></li>" +
                             *    "<li><a href=\"javascript:div_load('Admin/itemxc_add.aspx','');\" > 乡村旅游度假区或A级景区度假区或A级景区 </a></li>" +
                             ****/

                            currentPage = "Admin/itemselect_user.aspx";
                            re = " <div class=\"unit\">" +
 "<h5>申报项目</h5>" +
 "<ul class=\"rr\">" +
   "<li><a href=\"javascript:div_load('Admin/itemst_add.aspx','》申报项目》重大项目');\"> 重大项目 </a></li>" +
   "<li><a href=\"javascript:div_load('Admin/itemjg_add.aspx','》申报项目》景观农业');\" > 景观农业 </a></li>" +
   "<li><a href=\"javascript:div_load('Admin/itembh_add.aspx','》申报项目》百湖工程');\" > 百湖工程 </a></li>" +
 "</ul>" +
"</div>";
                            re += "   <div class=\"unit current\">" +
  "<h5>项目管理</h5>" +
    "<ul class=\"rr\">" +
    "<li><a href=\"javascript:div_load('Admin/itemselect_user.aspx','》项目管理》申报项目管理');\">申报项目管理</a></li>" +
     "<li><a href=\"javascript:div_load('Admin/itemreport_user.aspx','》项目管理》季报月报');\">季报月报</a></li>" +
  "</ul>" + "</div>";
                            re += "<div class=\"unit\">" +
  "<h5>个人设置</h5>" +
  "<ul class=\"rr\">" +
     "<li> <a href=\"javascript:div_load('Admin/updateInformation.aspx','》个人设置》个人资料');\" > 个人资料</a></li>" +
    "<li> <a href=\"javascript:div_load('Admin/updatePassword.aspx','》个人设置》修改密码');\" > 修改密码</a></li>" +
  "</ul>" +
 "</div>";
                        } break;
                }
            }
            else
            {
                Response.Redirect("login.aspx");
            }
        }
        else
        {
            Response.Redirect("login.aspx");
        }


        Response.Write(re);
        return re;

    }
    /// <summary>
    /// 安全退出系统
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //1.清空Session
        //2.退出到登陆界面
        Session.Clear();
        Response.Redirect("login.aspx");
    }
}