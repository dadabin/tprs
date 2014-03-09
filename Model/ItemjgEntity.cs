using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    /// <summary>
    /// 景观农业项目
    /// </summary>
   public  class ItemjgEntity
    {
       /// <summary>
       /// 项目ID
       /// </summary>
        private int iD;

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }



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
       /// 建设地址
       /// </summary>
        private string address;

        public string Address
        {
            get { return address; }
            set { address = value; }
        }
       /// <summary>
       /// 建设内容及规模
       /// </summary>
        private string contentScale;

        public string ContentScale
        {
            get { return contentScale; }
            set { contentScale = value; }
        }
       /// <summary>
       /// 计划总投资
       /// </summary>
        private string  planTotalMoney;

        public string PlanTotalMoney
        {
            get { return planTotalMoney; }
            set { planTotalMoney = value; }
        }

        private string xYearPlan;

        public string XYearPlan
        {
            get { return xYearPlan; }
            set { xYearPlan = value; }
        }

        private string endYear;

        public string EndYear
        {
            get { return endYear; }
            set { endYear = value; }
        }

        private string preYearPlan;

        public string PreYearPlan
        {
            get { return preYearPlan; }
            set { preYearPlan = value; }
        }

        private string xMonFin;

        public string XMonFin
        {
            get { return xMonFin; }
            set { xMonFin = value; }
        }
        private string xProgressNow;

        public string XProgressNow
        {
            get { return xProgressNow; }
            set { xProgressNow = value; }
        }
       /// <summary>
       /// 建设起止时间
       /// </summary>
        private string startEndTime;

        public string StartEndTime
        {
            get { return startEndTime; }
            set { startEndTime = value; }
        }

       

      
       /// <summary>
       /// 
       /// </summary>
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
       /// 是否为通过审核
       /// </summary>
        private string audit;

        public string Audit
        {
            get { return audit; }
            set { audit = value; }
        }
       /// <summary>
       /// 是否为提交状态
       /// </summary>
        private string submitstate;

        public string Submitstate
        {
            get { return submitstate; }
            set { submitstate = value; }
        }
        private string endState;

        public string EndState
        {
            get { return endState; }
            set { endState = value; }
        }

        private string stateChange;

        public string StateChange
        {
            get { return stateChange; }
            set { stateChange = value; }
        }


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

        private string progressCategory;

        public string ProgressCategory
        {
            get { return progressCategory; }
            set { progressCategory = value; }
        } 


    }
}
