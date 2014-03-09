using System;
using System.Collections.Generic;
using System.Text;
using Dal;
using System.Data;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Bll
{
    public class CommentBll
    {
        /// <summary>
        /// 添加评论 
        /// </summary>
        /// <param name="reportID"></param>报告编号
        /// <param name="reportType"></param>报告类型
        /// <param name="loginName"></param>登陆用户名
        /// <param name="comment"></param>点评内容
        /// <returns></returns>
        public string addComment(int reportID,int reportType,string loginName,string comment) 
        {
            String returnStr = "";
            CommentDal dal = new CommentDal();
            UserDal u = new UserDal();

            //判断用户是否权限足够
            DataTable dt = u.selectByLoginName(1, loginName);
            if (dt.Rows.Count > 0)
            {
                //说明权限足够

                if (dal.isComment(reportID, reportType))
                {
                    //开始执行插入点评的操作 
                    if (dal.addComment(loginName, comment, reportID, reportType))
                    {
                        returnStr = "点评成功";
                    }
                    else
                    {
                        returnStr = "点评失败";
                    }
                }
                else
                {
                    returnStr = "点评时间已过，过期的操作"; 
                }
            }
            else
            {
                returnStr = "当前用户权限不够";
            }

            return returnStr;
        }

        /// <summary>
        /// 给评论添加回复
        /// </summary>
        /// <param name="commentID"></param>
        /// <param name="loginName"></param>
        /// <param name="reply"></param>
        /// <returns></returns>
        public string addReply(int commentID, string loginName, string reply)
        {
            String returnStr = "";
            CommentDal dal = new CommentDal();
            UserDal u = new UserDal();

            //判断用户是否权限足够
            if (u.hasReplyPower(loginName))
            {
                //说明权限足够
                //判断是否可以添加回复
                if (dal.isReply(commentID))
                {
                    //开始执行插入点评的操作 
                    if (dal.addReply(loginName, reply, commentID))
                    {
                        returnStr = "回复成功";
                    }
                    else
                    {
                        returnStr = "回复失败";
                    }
                }
                else
                {
                    returnStr = "过期的回复动作";
                }
            }
            else
            {
                returnStr = "当前用户权限不够";
            }

            return returnStr;
        }
        public string addReply(int reportType,int reportID, string loginName, string reply)
        {
            String returnStr = "";
            CommentDal dal = new CommentDal();
            UserDal u = new UserDal();

            //判断用户是否权限足够
            if (u.hasReplyPower(loginName))
            {
                //说明权限足够
                //判断是否可以添加回复
                if (dal.isReply(reportID,reportType))
                {
                    //开始执行插入点评的操作 
                    if (dal.addReply(loginName, reply, reportID, reportType))
                    {
                        returnStr = "回复成功";
                    }
                    else
                    {
                        returnStr = "回复失败";
                    }
                }
                else
                {
                    returnStr = "过期的回复动作";
                }
            }
            else
            {
                returnStr = "当前用户权限不够";
            }

            return returnStr;
        }

        //////////////////////////二级审核员意见报送////////////////////////////
        
        /// <summary>
        /// 二级审核员发表意见，（对月份、季度报表的观后感）
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="title"></param>
        /// <param name="opinionContent"></param>
        /// <returns></returns>
        public string addOpinion(string LoginName,string title,string opinionContent)
        {
            CommentDal dal = new CommentDal();
            UserDal u = new UserDal();

            //判断权限  ,,,是否是二级审核员
            if (u.getRoleByLoginName(LoginName) == "2")
            {
                //权限通过
                //插入数据
                if (dal.addOpinion(LoginName, title, opinionContent))
                {
                    //添加成
                    return "您的意见已经成功报送！";
                }
                else
                {
                    return "您的意见报送失败！";
                }

            }
            else
            {
                return "只有二级审核员才有权限进行意见发表！";
            }
        }

        /// <summary>
        /// 所有意见列表
        /// </summary>
        /// <returns></returns>
        public DataTable getAllOpinions()
        {
            //TODO （LPM）是否需要再次判断权限，然后再让其查看？？？？
            CommentDal dal = new CommentDal();
            return dal.getAllOpinions();
        }

        /// <summary>
        /// 绑定意见表数据到view
        /// 
        /// </summary>
        /// <param name="gv"></param>窗格控件
        /// <param name="pager"></param> 分页控件
        public void bindOpinionView(GridView gv, AspNetPager pager)
        { 
            //显示框图
            CommentDal dal = new CommentDal();
            dal.bindOpinionView(gv, pager);
        }

        /// <summary>
        /// 获取评论
        /// 
        /// </summary>
        /// <param name="commentID"></param>评论编号
        /// <returns></returns>
        public DataTable getCommentByID(int commentID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取评论---- 细节
        /// 
        /// </summary>
        /// <param name="reportType"></param>报告类型
        /// <param name="reportID"></param> 报告编号
        /// <returns></returns>
        public DataTable getCommentByReport(int reportType, int reportID)
        {
            //显示框图
            CommentDal dal = new CommentDal();
            return dal.getCommentByReport(reportType, reportID);
        }

        /// <summary>
        /// 根据ID获取意见详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getOpinionByID(int id)
        { 

            return new CommentDal().getOpinionByID(id);
        }

    }

     





}
