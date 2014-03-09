using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
  public   class LogEntity
    {
        private int logId;

        public int LogId
        {
            get { return logId; }
            set { logId = value; }
        }
        private string loginName;
        /// <summary>
        /// 操作人登陆名  -----  人员唯一标示
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string userName;
        /// <summary>
        /// 操作人用户名
        /// </summary>
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        private DateTime opTime;
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime OpTime
        {
            get { return opTime; }
            set { opTime = value; }
        }
        private string logContent;
        /// <summary>
        /// 日志内容
        /// </summary>
        public string LogContent
        {
            get { return logContent; }
            set { logContent = value; }
        }
    }
}
