using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Dal
{
    /// <summary>
    /// 2012-12-7
    /// 用于处理点评的数据处理逻辑
    /// </summary>
    public class CommentDal
    {
        //获取系统时间
        public DateTime now = System.DateTime.Now;
        public bool addComment(string cname,string comment,int reportID,int reportType) 
        {
            DataBase db = new DataBase();
            bool re = false;
            //添加一则记录包括，评论人，评论内容，评论时间，
            //并且设置成不可评论状态，可恢复状态
            char iscomment = '1'; //不可再评论（即以评论）
            char isreply = '0';//可回复
            string sql = "insert into comment (REPORTID,COMMENT,CNAME,CTIME,ISCOMMENT,ISREPLY,REPORTTYPE) values (@REPORTID,@COMMENT,@CNAME,@CTIME,@ISCOMMENT,@ISREPLY,@REPORTTYPE)";

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@REPORTID", SqlDbType.Int);
            param[0].Value = reportID;

            param[1] = new SqlParameter("@COMMENT", SqlDbType.VarChar);
            param[1].Value = comment;
            param[2] = new SqlParameter("@CNAME", SqlDbType.VarChar);
            param[2].Value = cname;
            param[3] = new SqlParameter("@CTIME", SqlDbType.VarChar);
            param[3].Value = now;
            param[4] = new SqlParameter("@ISCOMMENT", SqlDbType.Char);
            param[4].Value = iscomment;
            param[5] = new SqlParameter("@ISREPLY", SqlDbType.Char);
            param[5].Value = isreply;
            param[6] = new SqlParameter("@REPORTTYPE", SqlDbType.Char);
            param[6].Value = reportType;

            if(1 == db.ExecuteSql(sql,param))
            {
                re = true;
            }

            return re;
        }

        public bool addReply(string rname, string reply, int commentID) 
        {

            DataBase db = new DataBase();
            bool re = false;
            //添加一则回复包括，回复人，回复容，回复时间，
            //并且设置成不可评论状态，可恢复状态
            char iscomment = '1'; //不可再评论（即以评论）
            char isreply = '1';//不可再回复
            string sql = "update comment set RNAME=@RNAME,RTIME=@RTIME,ISCOMMENT=@ISCOMMENT,ISREPLY=@ISREPLY,REPLY=@REPLY where ID=@ID";

            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@RNAME", SqlDbType.VarChar);
            param[0].Value = rname;
            param[1] = new SqlParameter("@RTIME", SqlDbType.VarChar);
            param[1].Value = now;
            param[2] = new SqlParameter("@ISCOMMENT", SqlDbType.VarChar);
            param[2].Value = iscomment;
            param[3] = new SqlParameter("@ISREPLY", SqlDbType.VarChar);
            param[3].Value = isreply;
            param[4] = new SqlParameter("@REPLY", SqlDbType.VarChar);
            param[4].Value = reply;
            param[5] = new SqlParameter("@ID", SqlDbType.Int);
            param[5].Value = commentID;

            if (1 == db.ExecuteSql(sql, param))
            {
                re = true;
            }

            return re;    
        }

       /// <summary>
       /// 添加回复！！
       /// </summary>
       /// <param name="rname"></param>
       /// <param name="reply"></param>
       /// <param name="reportID"></param>
       /// <param name="reportType"></param>
       /// <returns></returns>
        public bool addReply(string rname, string reply, int reportID, int reportType)
        {

            DataBase db = new DataBase();
            bool re = false;
            //添加一则回复包括，回复人，回复容，回复时间，
            //并且设置成不可评论状态，可恢复状态
            char iscomment = '1'; //不可再评论（即以评论）
            char isreply = '1';//不可再回复
            string sql = "update comment set RNAME=@RNAME,RTIME=@RTIME,ISCOMMENT=@ISCOMMENT,ISREPLY=@ISREPLY,REPLY=@REPLY WHERE REPORTID=@REPORTID and REPORTTYPE=@REPORTTYPE";

            SqlParameter[] param = new SqlParameter[7];
            param[0] = new SqlParameter("@RNAME", SqlDbType.VarChar);
            param[0].Value = rname;
            param[1] = new SqlParameter("@RTIME", SqlDbType.VarChar);
            param[1].Value = now;
            param[2] = new SqlParameter("@ISCOMMENT", SqlDbType.VarChar);
            param[2].Value = iscomment;
            param[3] = new SqlParameter("@ISREPLY", SqlDbType.VarChar);
            param[3].Value = isreply;
            param[4] = new SqlParameter("@REPLY", SqlDbType.VarChar);
            param[4].Value = reply;
            param[5] = new SqlParameter("@REPORTID", SqlDbType.Int);
            param[5].Value = reportID;
            param[6] = new SqlParameter("@REPORTTYPE", SqlDbType.Int);
            param[6].Value = reportType;

            if (1 == db.ExecuteSql(sql, param))
            {
                re = true;
            }

            return re;
        }
        /// <summary>
        /// 根据CommentID获取当前的comment对象
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public DataTable getCommentByID(int commentID)
        {
            DataTable dt = new DataTable();
            

            return dt;
        }

        /// <summary>
        ///     判断报告是否以评论，如果未评论，返回真，则可以对其进行评论
        /// </summary>
        /// <param name="reportID"></param>报告编号
        /// <returns></returns>
        public bool isComment(int reportID, int reportType) 
        {
            String sql = "SELECT count(*) FROM comment WHERE REPORTID=@REPORTID and REPORTTYPE=@REPORTTYPE";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@REPORTID", SqlDbType.VarChar, 200);
            param[0].Value = reportID;
            param[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Char, 200);
            param[1].Value = reportType;

            DataBase db = new DataBase();
            if (db.ExecuteValue(sql, param) == "0")
            {
                  //说明还没有记录，则返回真
                  return true;
            }
            
            return false;
        
        }

        /// <summary>
        /// 判断是否可以进行评论回复
        /// </summary>
        /// <param name="reportID"></param>
        /// <returns></returns>
        public bool isReply(int reportID, int reportType)
        {
            String sql = "SELECT count(*) FROM comment WHERE REPORTID=@REPORTID and REPORTTYPE=@REPORTTYPE and ISCOMMENT=1 and ISREPLY=0";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@REPORTID", SqlDbType.VarChar, 200);
            param[0].Value = reportID;
            param[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Char, 200);
            param[1].Value = reportType;

            DataBase db = new DataBase();
            if (db.ExecuteValue(sql, param) == "1")
            {
                return true;
            }

            return false;

        }

        public bool isShow(int reportID, int reportType)
        {
            String sql = "SELECT count(*) FROM comment WHERE REPORTID=@REPORTID and REPORTTYPE=@REPORTTYPE ";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@REPORTID", SqlDbType.VarChar, 200);
            param[0].Value = reportID;
            param[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Char, 200);
            param[1].Value = reportType;

            DataBase db = new DataBase();
            if (db.ExecuteValue(sql, param) == "0")
            {
                return false;
            }
            return true;
        }

       


        /// <summary>
        /// 判断是否回复
        /// </summary>
        /// <param name="commentID"></param>
        /// <returns></returns>
        public bool isReply(int commentID)
        {
            String sql = "SELECT count(*) FROM comment WHERE ID=@ID and ISCOMMENT=1 and ISREPLY=0";
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("@ID", SqlDbType.Int);
            param[0].Value = commentID;


            DataBase db = new DataBase();
            if (db.ExecuteValue(sql, param) == "1")
            {
                return true;
            }
            return false;

        }

        public DataTable getAllComments() 
        {
            DataTable dt = new DataTable();

            return dt;
        }

        /// <summary>
        /// 添加一则意见
        /// </summary>
        /// <param name="LoginName"></param>
        /// <param name="title"></param>
        /// <param name="opinionContent"></param>
        /// <returns></returns>
        public bool addOpinion(string LoginName, string title, string opinionContent)
        {
            DataBase db = new DataBase();
            bool re = false;
            

            string sql = "insert into OPINION (ONAME,TITLE,CONTENT,OTIME) values (@ONAME,@TITLE,@CONTENT,@OTIME)";

            SqlParameter[] param = new SqlParameter[4];
            param[0] = new SqlParameter("@ONAME", SqlDbType.VarChar,50);
            param[0].Value = LoginName;
            param[1] = new SqlParameter("@TITLE", SqlDbType.VarChar,50);
            param[1].Value = title;
            param[2] = new SqlParameter("@CONTENT", SqlDbType.VarChar,2000);
            param[2].Value = opinionContent;
            param[3] = new SqlParameter("@OTIME", SqlDbType.VarChar,50);
            param[3].Value = now;


            if (1 == db.ExecuteSql(sql, param))
            {
                re = true;
            }

            return re;
        }

        /// <summary>
        /// ==============获取所有意见
        /// </summary>
        /// <returns></returns>
        public DataTable getAllOpinions()
        {
            //DataTable dt = new DataTable();
            DataBase db = new DataBase();
            String sql = "select * from opinion";
            return db.GetDataTable(sql);
        }

        /// <summary>
        /// 利用组件，将数据绑定到页面组件（可分页）
        /// </summary>
        /// <param name="gv"></param>
        /// <param name="pager"></param>
        public void bindOpinionView(GridView gv, AspNetPager pager)
        {
            DataBase db = new DataBase();
            DataTable dtgv = new DataTable();
            DataTable pagerView = new DataTable();
            StringUtills utils = new StringUtills();

            dtgv.Columns.Add("ID", typeof(string)); //项目编号
            dtgv.Columns.Add("RTIME", typeof(string));//上报时间
            dtgv.Columns.Add("LOGINNAME", typeof(string)); //上报人
            dtgv.Columns.Add("CONTENT", typeof(string)); //上报内容
            dtgv.Columns.Add("DETAIL", typeof(string)); //上报详情


            pagerView.Columns.Add("ID", typeof(string)); //项目编号
            pagerView.Columns.Add("RTIME", typeof(string));//上报时间
            pagerView.Columns.Add("LOGINNAME", typeof(string)); //上报人
            pagerView.Columns.Add("CONTENT", typeof(string)); //上报内容
            pagerView.Columns.Add("DETAIL", typeof(string)); //上报详情

            DataTable dt = new DataTable();
            string sql = "select * from OPINION ";
            
            dt = db.GetDataTable(sql);

            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow r = dtgv.NewRow();

                    r["ID"] = dt.Rows[i]["ID"];
                    r["RTIME"] = utils.getMonth(dt.Rows[i]["OTIME"].ToString());
                    r["LOGINNAME"] = dt.Rows[i]["ONAME"];
                    r["CONTENT"] = dt.Rows[i]["TITLE"];

                    r["DETAIL"] = "<a href='#' onclick='openwin(" + dt.Rows[i]["ID"] + ")'>查看详情</a>";
                    dtgv.Rows.Add(r);

                }
            }

            /////////分页绑定//////////
            int dtcount = dtgv.Rows.Count;
            pager.RecordCount = dtcount;

            for (int i = 0; i < dtcount; i++)
            {
                if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
                {
                    DataRow r = pagerView.NewRow();
                    r["ID"] = dtgv.Rows[i]["ID"];
                    r["RTIME"] = dtgv.Rows[i]["RTIME"];
                    r["LOGINNAME"] = dtgv.Rows[i]["LOGINNAME"];
                    r["CONTENT"] = dtgv.Rows[i]["CONTENT"];
                    r["DETAIL"] = dtgv.Rows[i]["DETAIL"];
                    pagerView.Rows.Add(r);
                }
            }
            gv.DataSource = pagerView;

            gv.DataBind();


        }

        /// <summary>
        /// 根据报告类型以及报告ID获取该报告的评论
        /// 
        /// </summary>
        /// <param name="reportType"></param>报告类型
        /// <param name="reportID"></param>报告编号
        /// <returns></returns>
        public DataTable getCommentByReport(int reportType, int reportID)
        {
            //获取数据
            string sql = "SELECT * FROM comment WHERE REPORTID=@REPORTID and REPORTTYPE=@REPORTTYPE";
            SqlParameter[] param = new SqlParameter[2];
            param[0] = new SqlParameter("@REPORTID", SqlDbType.VarChar, 200);
            param[0].Value = reportID;
            param[1] = new SqlParameter("@REPORTTYPE", SqlDbType.Char, 200);
            param[1].Value = reportType;
            DataBase db = new DataBase();
            return db.GetDataTable(sql,param);
        }


        /// <summary>
        /// 根据ID获取意见详情
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public DataTable getOpinionByID(int id)
        {
            DataBase db = new DataBase();
            string sql = "select * from OPINION where ID=@ID";
            SqlParameter[] paeram = new SqlParameter[1];
            paeram[0] = new SqlParameter("@ID",SqlDbType.Int);
            paeram[0].Value = id;
            return db.GetDataTable(sql, paeram);
        
        }

         /// <summary>
         /// 获取评论
         /// </summary>
         /// <param name="itemtype"></param>
         /// <param name="itemID"></param>
         /// <returns></returns>
        public DataTable getComment(int itemtype, int itemID)
        {
            DataBase db = new DataBase();
            string sql = "select * from comment where REPORTID=@REPORTID AND REPOTTYPE=@REPOTTYPE";
            SqlParameter[] paeram = new SqlParameter[1];
            paeram[0] = new SqlParameter("@REPORTID", SqlDbType.Int);
            paeram[0].Value = itemID;
            paeram[1] = new SqlParameter("@REPOTTYPE", SqlDbType.Int);
            paeram[1].Value = itemID;

            return db.GetDataTable(sql, paeram); 
        }

    }
}
