using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{   

    /// <summary>
    /// 生态旅游重大项目季度报表
    /// </summary>
    public class ItemstSeasonReportEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private int projectId;

        public int ProjectId
        {
            get { return projectId; }
            set { projectId = value; }
        }


        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string progressCategory;

        public string ProgressCategory
        {
            get { return progressCategory; }
            set { progressCategory = value; }
        }
        private string progressNow;

        public string ProgressNow
        {
            get { return progressNow; }
            set { progressNow = value; }
        }


        private float investmentPosition;

        public float InvestmentPosition
        {
            get { return investmentPosition; }
            set { investmentPosition = value; }
        }
        private string problems;

        public string Problems
        {
            get { return problems; }
            set { problems = value; }
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


       
        private string reportTime;

        public string ReportTime
        {
            get { return reportTime; }
            set { reportTime = value; }
        }


        private string audit;

        public string Audit
        {
            get { return audit; }
            set { audit = value; }
        }
        private string submitState;

        public string SubmitState
        {
            get { return submitState; }
            set { submitState = value; }
        }
        private string remark;

        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
        private string stateChange;

        public string StateChange
        {
            get { return stateChange; }
            set { stateChange = value; }
        }
        
    }
}
