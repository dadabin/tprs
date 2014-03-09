using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Dal;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Bll
{
   public  class ItemReportBll
    {
       public bool add(int type, object en)
       {
           ItemReportDal bll = new ItemReportDal();
           if (bll.add(type, en))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool delete(int type, int id)
       {
           ItemReportDal bll = new ItemReportDal();
           if (bll.delete(type, id))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool update(int type, object en,int id,string loginname)
       {
           ItemReportDal bll = new ItemReportDal();
           if (bll.update(type, en,id,loginname))
           {
               return true;
           }
           else 
           {
               return false;
           }
       
       }
       public DataTable select(int type, int id)
       {
           ItemReportDal bll = new ItemReportDal();
           return bll.select(type,id);
       }


       public DataTable select(int type, String projectNumber)
       {
           ItemReportDal bll = new ItemReportDal();
           return bll.select(type, projectNumber);
       }

       public DataTable selectAll(int type, String projectNumber)
       {
           ItemReportDal bll = new ItemReportDal();
           return bll.selectAll(type, projectNumber);
       }

      

       /// <summary>
       /// 
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="projectNum"></param>
       /// <param name="type"></param>
       /// <param name="roleID"></param>    ------4、指业主 3、指一级审核员 2、指2级审核员 1、指领导
       public void bindItem(GridView gv, AspNetPager pager, string projectID, int type, int roleID)
       {
           // 调用Dal层的binding方法
           ItemReportDal dal = new ItemReportDal();
           dal.bindItem(gv, pager, projectID, type, roleID);
       }



       public void bindReportAdmin1(GridView gv, AspNetPager pager, string loginName, int type, String whereStr)
       {
           ItemReportDal dal = new ItemReportDal();

           dal.bindReportAdmin1(gv, pager, loginName, type, whereStr);
       }

       /// <summary>
       ///  一级审核通过，AUDIT修改为1
       /// </summary>
       /// <returns></returns>
       public bool updateAudit(int reportType,int reportID)
       { 
           ItemReportDal dal = new ItemReportDal();
           int audit = 1;
           return  dal.updateAudit(reportType,reportID,audit);
       }

       /// <summary>
       ///  二级审核通过，AUDIT修改为2
       /// </summary>
       /// <returns></returns>
       public bool updateAudit2(int reportType, int reportID, int audit)
       {
           ItemReportDal dal = new ItemReportDal();
           return dal.updateAudit(reportType, reportID, audit);
       }

       public DataTable getReportByID(int reportType,int reportID)
       {
           ItemReportDal dal = new ItemReportDal();
           return dal.getReportByID(reportType, reportID);
       }

       public DataTable selectReportById(int type, int id)
       {
           ItemReportDal dal = new ItemReportDal();
           return dal.selectReportById(type, id);
       }

       /// <summary>
       /// 以及审核员漏项统计
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="loginName"></param>
       /// <param name="role"></param>
       /// <param name="whereStr"></param>
       public void staticsforadmin1(GridView gv, AspNetPager pager, string area) 
       {
           ItemReportDal dal = new ItemReportDal();
           dal.staticsforadmin1(gv, pager, area);
       }

       /// <summary>
       /// 二级审核员漏项统计
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="whereStr"></param>
       public void staticsforadmin2(GridView gv, AspNetPager pager,  String whereStr)
       {
           ItemReportDal dal = new ItemReportDal();
           dal.staticsforadmin2(gv, pager, whereStr);
       }
       /// <summary>
       /// 判断是否存在 某个时间的进度报告-----
       /// 返回真说明已经存在
       /// </summary>
       /// <param name="type"></param>
       /// <param name="reportTime"></param>
       /// <returns></returns>
       public bool isExitReport(int type,int projectID,string reportTime)
       { 
          ItemReportDal dal = new ItemReportDal();
          return dal.isExitReport(type,projectID, reportTime);
       }

       /// <summary>
       /// 当业主添加报告时添加初始数据到页面
       /// 
       /// 
       /// </summary>
       /// <param name="type"></param>
       /// <param name="projectID"></param>
       /// <param name="reportTime"></param>
       /// <returns></returns>
       public DataTable getDataWhenAddReport(int type, int projectID, DateTime reportTime)
       {
           ItemReportDal dal = new ItemReportDal();
           return dal.getDataWhenAddReport(type, projectID, reportTime);

       }

       public void bindReportManage(GridView gv, AspNetPager pager, string projectID, int type, string loginName, string whereStr)
       {
           new ItemReportDal().bindReportManage( gv,  pager,projectID,  type,loginName,whereStr);
       }
       public bool isAdd(int type, object en)
       {
           return new ItemReportDal().isAdd(type, en);
       }
    }
}
