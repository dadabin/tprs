using System;
using System.Collections.Generic;

using System.Text;
using Model;
using Dal;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Data;

namespace Bll
{
   public  class ItemBll
    {
       public bool add(int type,object en)
       {
           ItemDal dal = new ItemDal();
           if (dal.add(type, en))
           {
               return true;
           }
           else
           {
               return false;
           }
       }
       public bool isAddItem(int type, object item)
       {
           return new ItemDal().isAddItem(type, item);
       }

       public bool update(int type, object en,string loginName)
       {
           ItemDal dal = new ItemDal();
           if(dal.update(type,en,loginName)){
            return true;
           }
           return false;
       }


       public bool submit(int type, int itemid,string state)
       {
           ItemDal dal = new ItemDal();
           if (dal.submit(type, itemid,state))
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       public bool delete(int type, int projectid)
       {
           ItemDal dal = new ItemDal();
           if (dal.delete(type, projectid))
           {
               return true;
           }
           else
           {
               return false;
           }

       }

       /// <summary>
       /// 根据业主的登陆名 获取与其相关的项目列表
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="loginName"></param>
       public void userBindItem(GridView gv, AspNetPager pager,string loginName,string whereStr)
       {
           ItemDal dal = new ItemDal();
           dal.userBindItem(gv, pager, loginName, whereStr);
       }



       public DataTable selectByID(int type, int id)
       {
           ItemDal dal = new ItemDal();
           return dal.selectByID(type,id);
       }


    

       public void adminBindItem(GridView gv, AspNetPager pager,  string whereStr,int itemtype)
       {
           ItemDal dal = new ItemDal();
           dal.adminBindItem(gv, pager, whereStr,itemtype);
       }

       public void leaderBindItem(GridView gv, AspNetPager pager, string whereStr)
       {
           ItemDal dal = new ItemDal();
           dal.leaderBindItem(gv, pager, whereStr);
       }

       /// <summary>
       /// 绑定新建项目审批
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="loginName"></param>
       public void admin1BindItem(GridView gv, AspNetPager pager, string loginName)
       {
           ItemDal dal = new ItemDal();
           dal.admin1BindItem(gv, pager, loginName);
       }


       public bool adminsubmit(int type, int itemid, string state)
       {
           ItemDal dal = new ItemDal();
           return dal.adminsubmit(type, itemid, state);
       }

       public void leaderReportBindItem(GridView gv, AspNetPager pager, string whereStr)
       {
           ItemDal dal = new ItemDal();
           dal.leaderReportBindItem(gv, pager, whereStr);
       }


       /// <summary>
       /// 二级审核员查看报告列表
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="whereStr"></param>
       public void admin2ReportBindItem(GridView gv, AspNetPager pager, string whereStr)
       {
           ItemDal dal = new ItemDal();
           dal.admin2ReportBindItem(gv, pager, whereStr);
       }

       public void admin1BindItem2(GridView gv, AspNetPager pager, string loginName,int itemtype)
       {
           ItemDal dal = new ItemDal();
           dal.admin1BindItem2(gv, pager, loginName,itemtype);
       }

       public void admin1BindItem(GridView gv, AspNetPager pager, string whereStr, string loginName)
       {
           ItemDal dal = new ItemDal();
           dal.admin1BindItem(gv, pager, whereStr, loginName);
       }
       /// <summary>
       /// 以及审核员打回申报项目
       /// </summary>
       /// <param name="type"></param>   项目类型
       /// <param name="projectid"></param>  项目编号
       /// <param name="reback"></param>     打回标记
       /// <param name="submitstate"></param> 提交状态
       /// <param name="reason"></param>打回原因
       /// <returns></returns>
       public bool reback(int type, int projectid, int reback, int submitstate, string reason)
       {
           ItemDal dal = new ItemDal();
           return dal.reback(type, projectid,reback,submitstate , reason);
       }

       public DataTable viewReback(int type, int projectid, string whereStr)
       {
           ItemDal dal = new ItemDal();
           return dal.viewReback(type, projectid, whereStr);
       }

       /// <summary>
       /// 一级审核员手动设置项目为竣工状态
       /// </summary>
       /// <param name="type"></param>
       /// <param name="projectId"></param>
       /// <returns></returns>
       public bool endProject(int type,int projectId,string whereStr)
       {
           ItemDal dal = new ItemDal();
           return dal.endProject(type, projectId, whereStr);
       }


       /// <summary>
       /// 判断当前是否可填某类型项目的报告（指excel报告想干的报告）
       /// 
       /// </summary>
       /// <param name="projectType"></param>
       /// <param name="projectID"></param>
       /// <returns></returns>
       public bool isFillTime(int projectType,int projectID,string whereStr)
       {
           ItemDal dal = new ItemDal();
           return dal.isFillTime(projectType, projectID, whereStr);
       }

       /// <summary>
       /// 返回该 业主下项目数量
       /// </summary>
       /// <param name="loginName"></param>
       /// <param name="whereStr"></param>
       /// <returns></returns>
       public int getProjectNumInUser(string loginName)
       {
           ItemDal dal = new ItemDal();
           return dal.getProjectNumInUser(loginName);
       }

       /// <summary>
       /// 判断项目名称是否存在，，如存在返回真
       /// 
       /// </summary>
       /// <param name="type"></param>
       /// <param name="projectName"></param>
       /// <returns></returns>
       public bool isExitProject(int type, String projectName)
       {
           ItemDal dal = new ItemDal();
           return dal.isExitProject(type,projectName); 
       }

    }
}
