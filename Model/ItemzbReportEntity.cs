using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    /// <summary>
    /// 植被恢复报告
    /// </summary>
    public class ItemzbReportEntity
    {
        private int id;
        /// <summary>
        /// 主键字
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


        private string projectId;
        /// <summary>
        /// 所属项目编号
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
        private string zoneArea;
        /// <summary>
        /// 水域面积
        /// </summary>
        public string ZoneArea
        {
            get { return zoneArea; }
            set { zoneArea = value; }
        }


        private string maintreespecis;
        /// <summary>
        /// 主要树种
        /// </summary>
        public string Maintreespecis
        {
            get { return maintreespecis; }
            set { maintreespecis = value; }
        }
        private string foristLandScape;
        /// <summary>
        /// 景观林木
        /// </summary>
        public string ForistLandScape
        {
            get { return foristLandScape; }
            set { foristLandScape = value; }
        }
        private string tripElement;
        /// <summary>
        /// 涉旅元素
        /// </summary>
        public string TripElement
        {
            get { return tripElement; }
            set { tripElement = value; }
        }

        private string submitTime;
        /// <summary>
        /// 提交时间
        /// </summary>
        public string SubmitTime
        {
            get { return submitTime; }
            set { submitTime = value; }
        }
        private string reportTime;
         /// <summary>
         /// 上报时间
         /// </summary>
        public string ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }

        private int audit;
        /// <summary>
        /// 是否审核通过
        /// </summary>
        public int Audit
        {
            get { return audit; }
            set { audit = value; }
        }
        private int stateChange;
        
        /// <summary>
        /// 状态改变
        /// </summary>
        public int StateChange
        {
            get { return stateChange; }
            set { stateChange = value; }
        }


        private string modifyUser;

        /// <summary>
        /// 修改人信息
        /// </summary>
        public string ModifyUser
        {
            get { return modifyUser; }
            set { modifyUser = value; }
        }
    }
}
