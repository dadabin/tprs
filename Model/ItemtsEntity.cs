using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    /// <summary>
    /// 特色旅游
    /// </summary>
   public  class ItemtsEntity
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        
        /// <summary>
        /// 项目地址
        /// </summary>
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }


        /// <summary>
        /// 业主姓名
        /// </summary>
        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
       /// <summary>
       /// 项目编号
       /// </summary>
        private string projectNumber;

        public string ProjectNumber
        {
            get { return projectNumber; }
            set { projectNumber = value; }
        }

       /// <summary>
       /// 项目名称
       /// </summary>
        private string projectName;

        public string ProjectName
        {
            get { return projectName; }
            set { projectName = value; }
        }
        /// <summary>
        /// 基本状态
        /// </summary>
        private string basicSituation;

        public string BasicSituation
        {
            get { return basicSituation; }
            set { basicSituation = value; }
        }
         /// <summary>
         /// 规划情况
         /// </summary>
        private string projectPlan;

        public string ProjectPlan
        {
            get { return projectPlan; }
            set { projectPlan = value; }
        }

        /// <summary>
        /// 涉旅元素
        /// </summary>
        private string tripElement;

        public string TripElement
        {
            get { return tripElement; }
            set { tripElement = value; }
        }
       /// <summary>
       /// 发展特色
       /// </summary>
        private string developCharac;

        public string DevelopCharac
        {
            get { return developCharac; }
            set { developCharac = value; }
        }
       /// <summary>
       /// 存在差距
       /// </summary>
        private string gap;

        public string Gap
        {
            get { return gap; }
            set { gap = value; }
        }


        private string image1;

        public string Image1
        {
            get { return image1; }
            set { image1 = value; }
        }
        private string image2;

        public string Image2
        {
            get { return image2; }
            set { image2 = value; }
        }
        private string image3;

        public string Image3
        {
            get { return image3; }
            set { image3 = value; }
        }
        private string image4;

        public string Image4
        {
            get { return image4; }
            set { image4 = value; }
        }
        private string image5;

        public string Image5
        {
            get { return image5; }
            set { image5 = value; }
        }

       /// <summary>
       /// 是否处于修改状态
       /// </summary>
        private string stateChange;

        public string StateChange
        {
            get { return stateChange; }
            set { stateChange = value; }
        }
        
       /// <summary>
       /// 是否处于提交状态
       /// </summary>
       private int submitState;

        public int SubmitState
        {
            get { return submitState; }
            set { submitState = value; }
        }

       /// <summary>
       /// 是否竣工
       /// </summary>
        private int endState;

        public int EndState
        {
            get { return endState; }
            set { endState = value; }
        }

         /// <summary>
         /// 提交时间
         /// </summary>
        private string submitTime;

        public string SubmitTime
        {
            get { return submitTime; }
            set { submitTime = value; }
        }


        /// <summary>
        /// 修改人信息
        /// </summary>
        private string modifyUser;

        public string ModifyUser
        {
            get { return modifyUser; }
            set { modifyUser = value; }
        }

    }
}
