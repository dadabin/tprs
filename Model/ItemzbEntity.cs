using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    /// <summary>
    /// 植被恢复
    /// </summary>
   public  class ItemzbEntity
    {  
       
       /// <summary>
       /// 主键id
       /// </summary>
       private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
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
        /// 项目地址
        /// </summary>
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
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
       /// 项目编号
       /// </summary>
        private string projectNumber;

        public string ProjectNumber
        {
            get { return projectNumber; }
            set { projectNumber = value; }
        }

        /// <summary>
        /// 区域面积
        /// </summary>
        private float zoneArea;

        public float ZoneArea
        {
            get { return zoneArea; }
            set { zoneArea = value; }
        }
        /// <summary>
        /// 主要树种
        /// </summary>
        private string mainTreeSpecies;

        public string MainTreeSpecies
        {
            get { return mainTreeSpecies; }
            set { mainTreeSpecies = value; }
        }
       /// <summary>
       /// 景观林木
       /// </summary>
        private string forestLandscape;

        public string ForestLandscape
        {
            get { return forestLandscape; }
            set { forestLandscape = value; }
        }
       /// <summary>
       /// 管护主体
       /// </summary>
        private string manageSubject;

        public string ManageSubject
        {
            get { return manageSubject; }
            set { manageSubject = value; }
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
       /// 修改状态
       /// </summary>
        private int stateChange;

        public int StateChange
        {
            get { return stateChange; }
            set { stateChange = value; }
        }
       
       /// <summary>
       /// 提交状态
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
        /// 审核状态
        /// </summary>
        private int audit;

        public int Audit
        {
            get { return audit; }
            set { audit = value; }
        }

         /// <summary>
         /// 备注
         /// </summary>
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
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
