using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    /// <summary>
    /// 评论实体
    /// </summary>
    public class Comment
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private int reportID; //报告标号

        public int ReportID
        {
            get { return reportID; }
            set { reportID = value; }
        }
        private int cid;  ///评论人id

        public int Cid
        {
            get { return cid; }
            set { cid = value; }
        }
        private int rid;  //回复人id

        public int Rid
        {
            get { return rid; }
            set { rid = value; }
        }

        private string comment;//点评内容

        public string Comment1
        {
            get { return comment; }
            set { comment = value; }
        }
        private string reply; //回复内容

        public string Reply
        {
            get { return reply; }
            set { reply = value; }
        }
        private string ctime;//点评时间

        public string Ctime
        {
            get { return ctime; }
            set { ctime = value; }
        }
        private string rtime;  //回复时间

        public string Rtime
        {
            get { return rtime; }
            set { rtime = value; }
        }

        private char iscomment;//是否可以点评

        public char Iscomment
        {
            get { return iscomment; }
            set { iscomment = value; }
        }
        private char isreply;  //是否可以回复

        public char Isreply
        {
            get { return isreply; }
            set { isreply = value; }
        }

    }
}
