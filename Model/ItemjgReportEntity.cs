using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ItemjgReportEntity
    {
        //景观季度报告


        private int id;
        /// <summary>
        /// 主键值
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }
       
        private string projectID;

        public string ProjectID
        {
            get { return projectID; }
            set { projectID = value; }
        }


        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }

        private string xYeqePlan;

        public string XYeqePlan
        {
            get { return xYeqePlan; }
            set { xYeqePlan = value; }
        }

        private string endYear;

        public string EndYear
        {
            get { return endYear; }
            set { endYear = value; }
        }
        private string preyearPlan;

        public string PreyearPlan
        {
            get { return preyearPlan; }
            set { preyearPlan = value; }
        }
        private string xMonFin;

        public string XMonFin
        {
            get { return xMonFin; }
            set { xMonFin = value; }
        }

        private string progressNow;

        public string ProgressNow
        {
            get { return progressNow; }
            set { progressNow = value; }
        }




        private string image1;
        /// <summary>
        /// 图片1
        /// </summary>
        public string Image1
        {
            get { return image1; }
            set { image1 = value; }
        }
        private string image2;
        /// <summary>
        /// 图片2
        /// </summary>
        public string Image2
        {
            get { return image2; }
            set { image2 = value; }
        }
        private string image3;
        /// <summary>
        /// 图片3
        /// </summary>
        public string Image3
        {
            get { return image3; }
            set { image3 = value; }
        }
        private string image4;
        /// <summary>
        /// 图片4
        /// </summary>
        public string Image4
        {
            get { return image4; }
            set { image4 = value; }
        }
        private string image5;
        /// <summary>
        /// 图片5
        /// </summary>
        public string Image5
        {
            get { return image5; }
            set { image5 = value; }
        }
      
        private int audit;
        /// <summary>
        /// 是否通过审核
        /// </summary>
        public int Audit
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

        private string endState;

        public string EndState
        {
            get { return endState; }
            set { endState = value; }
        }

        private string savetime;

        public string Savetime
        {
            get { return savetime; }
            set { savetime = value; }
        }
        private string reporttime;

        public string Reporttime
        {
            get { return reporttime; }
            set { reporttime = value; }
        }

        private string progressCategory;

        public string ProgressCategory
        {
            get { return progressCategory; }
            set { progressCategory = value; }
        } 

    }
}
