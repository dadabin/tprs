using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    public class ItemxcReportEntity
    {

        /// <summary>
        /// 乡村度假区报告
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string projectId;
        /// <summary>
        /// 所属项目id
        /// </summary>
        public string ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }

        private string loginName;
        /// <summary>
        /// 业主姓名
        /// </summary>
        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        
       
        private int modifiedState;
        /// <summary>
        /// 修改状态
        /// </summary>
        public int ModifiedState
        {
            get { return modifiedState; }
            set { modifiedState = value; }
        }
        private int audit;
         /// <summary>
         /// 是否通过审核，，初始为0，一级通过为1，二级通过为2
         /// </summary>
        public int Audit
        {
            get { return audit; }
            set { audit = value; }
        }
        private int submitStatus;

        /// <summary>
        /// 提交状态为1表示提交成功
        /// </summary>
        public int SubmitStatus
        {
            get { return submitStatus; }
            set { submitStatus = value; }
        }
        private int finishStatus;
        /// <summary>
        /// 是否完成
        /// </summary>
        public int FinishStatus
        {
            get { return finishStatus; }
            set { finishStatus = value; }
        }

        private string brief;
        /// <summary>
        /// 简介项目
        /// </summary>
        public string Brief
        {
            get { return brief; }
            set { brief = value; }
        }
        private string projectDesc;
        /// <summary>
        /// 项目说明
        /// </summary>
        public string ProjectDesc
        {
            get { return projectDesc; }
            set { projectDesc = value; }
        }

    }
}
