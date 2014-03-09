using System;
using System.Collections.Generic;
using System.Text;

using Dal;
using Model;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Bll
{
    public class LogBll
    {
        /// <summary>
        /// 添加日志数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool addLog(LogEntity entity)
        { 
            LogDal dal = new LogDal();
            return dal.addLog(entity);
        }

        /// <summary>
        /// 获取日志列表
        /// </summary>
        /// <param name="whereStr"></param>约束条件（注：为sql表达式）
        /// <returns></returns>
        public DataTable getLogs(string whereStr)
        {
            LogDal dal = new LogDal();
            return dal.getLogs(whereStr);
        }




        /// <summary>
        /// 绑定日志UI
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="pager"></param>
        /// <param name="where"></param>
        public void bindView(GridView gv, AspNetPager pager, string where)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("logID", typeof(string));
            dt.Columns.Add("content", typeof(string));
            dt.Columns.Add("logTime", typeof(string));
            
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("logID", typeof(string));
            dt1.Columns.Add("content", typeof(string));
            dt1.Columns.Add("logTime", typeof(string));

            DataTable data = this.getLogs(where);
            if (data.Rows.Count > 0)
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    DataRow r = dt.NewRow();
                    r["logID"] = data.Rows[i]["LOGID"];
                    r["content"] = data.Rows[i]["LOGCONTENT"];
                    r["logTime"] = data.Rows[i]["OPTIME"];
                    dt.Rows.Add(r);
                }
            }
            ///////////分页//////////
            int dtcount = dt.Rows.Count;
            pager.RecordCount = dtcount;

            for (int i = 0; i < dtcount; i++)
            {
                if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
                {
                    DataRow r = dt1.NewRow();
                    r["logID"] = dt.Rows[i]["logID"];
                    r["content"] = dt.Rows[i]["content"];
                    r["logTime"] = dt.Rows[i]["logTime"];
                    dt1.Rows.Add(r);
                }
            }
            gv.DataSource = dt1;

            gv.DataBind();
        }





        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        /////////////////////////日志相关字符串拼接/////////////////////////////
        ////////////////////////////////////////////////////////////////////////
        ////////////////////////////////////////////////////////////////////////



        #region 用户(4类)----日志记录字符串拼接 TODO：LPM   2012-12-29

        /// <summary>
        /// 拼接添加的字符串
        /// </summary>
        /// <param name="user"></param>
        /// <param name="roleType"></param>
        /// <param name="sessionUser"></param> 注：操作人的登录名
        /// <returns></returns>
        public String user_builtAddStr(UserEntity user, int roleType,DataTable sessionUser)
        {
            StringUtills utils = new StringUtills();
            String returnStr = "";
            returnStr += sessionUser.Rows[0]["LOGINNAME"] + "(" + sessionUser.Rows[0]["USERNAME"] + ")";
            if(roleType == 4)
            {
                returnStr += "在：" + utils.getChineseLocaltion(user.Area) + "添加了一个权限为：业主";
            }
            if (roleType == 3)
            {
                returnStr += "在：" + utils.getChineseLocaltion(user.Area) + "添加了一个权限为：一级管理员";
            }
            if (roleType == 2)
            {
                returnStr += "添加了一个权限为：二级管理员";
            }
            if (roleType == 1)
            {
                returnStr += "添加了一个权限为：市级领导";
            }

            returnStr += "，登陆名为："+user.LoginName+"的用户。";
            return returnStr;
        }

        //TODO ：参数待定  ？？？这样简单可以不？？
        public String user_builtUpdateStr(UserEntity user, DataTable sessionUser)
        {
            //StringUtills utils = new StringUtills();
            String returnStr = "";
            returnStr += sessionUser.Rows[0]["LOGINNAME"] + "(" + sessionUser.Rows[0]["USERNAME"] + ")";
            returnStr += "更新了了一个登陆名为：" + user.LoginName + "的用户数据";
            return returnStr;
        }

        //TODO ：参数待定 ？？？这样简单可以不？？
        public String user_builtDeletStr(UserEntity user, DataTable sessionUser)
        {
            //StringUtills utils = new StringUtills();
            String returnStr = "";
            returnStr += sessionUser.Rows[0]["LOGINNAME"] + "(" + sessionUser.Rows[0]["USERNAME"] + ")";
            returnStr += "删除了一个登陆名为：" + user.LoginName + "的用户。";
            return returnStr;
        }

        #endregion



        #region 项目(3类)----日志记录字符串拼接 TODO：LPM   2012-12-29
        /// <summary>
        /// 拼接添加的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="sessionUser"></param>注：操作人的登录名
        /// <returns></returns>
        public String project_builtAddStr(Object obj, int type, DataTable sessionUser)
        {
            String returnStr = "";
            return returnStr;
        }

        //TODO ：参数待定
        public String project_builtUpdateStr()
        {
            String returnStr = "";
            return returnStr;
        }

        //TODO ：参数待定
        public String project_builtDeletStr()
        {
            String returnStr = "";
            return returnStr;
        }

        #endregion



        #region 报告(3类)----日志记录字符串拼接 TODO：LPM   2012-12-29
        /// <summary>
        /// 拼接添加的字符串
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="type"></param>
        /// <param name="sessionUser"></param>注：操作人的登录名
        /// <returns></returns>
        public String report_builtAddStr(Object obj, int type, DataTable sessionUser)
        {
            String returnStr = "";
            return returnStr;
        }

        //TODO ：参数待定
        public String report_builtUpdateStr()
        {
            String returnStr = "";
            return returnStr;
        }

        //TODO ：参数待定
        public String report_builtDeletStr()
        {
            String returnStr = "";
            return returnStr;
        }

        #endregion

    }
}
