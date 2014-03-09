using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ItembhReportEntity
    {
        //百湖工程
        private int iD;
        /// <summary>
        /// id
        /// </summary>
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private int projectID;

        public int ProjectID
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

        private string finishTime;

        public string FinishTime
        {
            get { return finishTime; }
            set { finishTime = value; }
        }
        private string subTotal;

        public string SubTotal
        {
            get { return subTotal; }
            set { subTotal = value; }
        }

        private string progressCategory;

        public string ProgressCategory
        {
            get { return progressCategory; }
            set { progressCategory = value; }
        }

        private string imageprogress;

        public string Imageprogress
        {
            get { return imageprogress; }
            set { imageprogress = value; }
        }
        private string image1;
        /// <summary>
        ///图片1
        /// </summary>
        public string Image1
        {
            get { return image1; }
            set { image1 = value; }
        }
        private string image2;
        /// <summary>
        ///图片2
        /// </summary>
        public string Image2
        {
            get { return image2; }
            set { image2 = value; }
        }
        private string image3;
        /// <summary>
        ///图片3
        /// </summary>
        public string Image3
        {
            get { return image3; }
            set { image3 = value; }
        }
        private string image4;
        /// <summary>
        ///图片4
        /// </summary>
        public string Image4
        {
            get { return image4; }
            set { image4 = value; }
        }
        private string image5;
        /// <summary>
        ///图片5
        /// </summary>
        public string Image5
        {
            get { return image5; }
            set { image5 = value; }
        }
        private string  audit;
        /// <summary>
        /// 是否通过审核
        /// </summary>
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
        private string reporttime;

        public string Reporttime
        {
          get { return reporttime; }
          set { reporttime = value; }
        }
        private string savetime;

        public string Savetime
        {
            get { return savetime; }
            set { savetime = value; }
        }
    }
}
