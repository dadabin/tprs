using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public  class SeasonReportForWordEntity
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string loginName;

        public string LoginName
        {
            get { return loginName; }
            set { loginName = value; }
        }
        private string seasonComment;

        public string SeasonComment
        {
            get { return seasonComment; }
            set { seasonComment = value; }
        }
        private DateTime submitTime;

        public DateTime SubmitTime
        {
            get { return submitTime; }
            set { submitTime = value; }
        }
        private string itemType;

        public string ItemType
        {
            get { return itemType; }
            set { itemType = value; }
        }
        private string submitState;

        public string SubmitState
        {
            get { return submitState; }
            set { submitState = value; }
        }
        private string area;

        public string Area
        {
            get { return area; }
            set { area = value; }
        }
    }
}
