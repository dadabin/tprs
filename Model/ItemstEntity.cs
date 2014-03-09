using System;
using System.Collections.Generic;

using System.Text;

namespace Model
{
    /// <summary>
    /// 生态旅游重大项目
    /// </summary>
   public  class ItemstEntity
    {
       
        private int id;
        /// <summary>
        /// 项目ID 
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


      
     private string loginName;
     /// <summary>
     ///   业主
     /// </summary>
     public string LoginName
     {
         get { return loginName; }
         set { loginName = value; }
     }

     
      private string  projectNumber;
      /// <summary>
      /// 项目编号
      /// </summary>
      public string ProjectNumber
       {
         get { return projectNumber; }
         set { projectNumber = value; }
       }

     
      private string projectName;
      /// <summary>
      /// 项目名称
      /// </summary>
      public string ProjectName
      {
          get { return projectName; }
          set { projectName = value; }
      }
  
      private string country;
      /// <summary>
      /// 项目所属区县
      /// </summary>
      public string Country
      {
          get { return country; }
          set { country = value; }
      }

      
      private string address;
      /// <summary>
      /// 项目地址
      /// </summary>
      public string Address
      {
          get { return address; }
          set { address = value; }
      }

     
      
      private string progressCategory;
      /// <summary>
      /// 进展类别
      /// </summary>
      public string ProgressCategory
      {
          get { return progressCategory; }
          set { progressCategory = value; }
      }

    
     
      private string constructionType;
      /// <summary>
      /// 建设性质
      /// </summary>
      public string ConstructionType
      {
          get { return constructionType; }
          set { constructionType = value; }
      }
     
      private string constructionAge;
      /// <summary>
      /// 建设年限
      /// </summary>
      public string ConstructionAge
      {
          get { return constructionAge; }
          set { constructionAge = value; }
      }
      
      private string contentScale;
      /// <summary>
      /// 建设内容及规模
      /// </summary>
      public string ContentScale
      {
          get { return contentScale; }
          set { contentScale = value; }
      }
     
      private string governmentProje;
      /// <summary>
      /// 是否为政府投资项目
      /// </summary>
      public string GovernmentProje
      {
          get { return governmentProje; }
          set { governmentProje = value; }
      }
       
      private int projectNature;
      /// <summary>
      /// 项目性质
      /// </summary>
      public int ProjectNature
      {
          get { return projectNature; }
          set { projectNature = value; }
      }
      
      private float totleMoney;
       /// <summary>
       /// 总投资
       /// </summary>
      public float TotleMoney
      {
          get { return totleMoney; }
          set { totleMoney = value; }
      }
      
      private float centralMoney;
      /// <summary>
      /// 中央资金
      /// </summary>
      public float CentralMoney
      {
          get { return centralMoney; }
          set { centralMoney = value; }
      }
      
      private float provincialMoney;
      /// <summary>
      /// 省级资金
      /// </summary>
      public float ProvincialMoney
      {
          get { return provincialMoney; }
          set { provincialMoney = value; }
      }
      
      private float municipalMoney;
      /// <summary>
      /// 市级资金
      /// </summary>
      public float MunicipalMoney
      {
          get { return municipalMoney; }
          set { municipalMoney = value; }
      }
      
      private float districtMoney;
      /// <summary>
      /// 区县资金
      /// </summary>
      public float DistrictMoney
      {
          get { return districtMoney; }
          set { districtMoney = value; }
      }
  
      private float bankLoan;
      /// <summary>
      /// 银行贷款
      /// </summary>
      public float BankLoan
      {
          get { return bankLoan; }
          set { bankLoan = value; }
      }
       
      private float useProgress;
      /// <summary>
      /// 资金市级使用进度
      /// </summary>
      public float UseProgress
      {
          get { return useProgress; }
          set { useProgress = value; }
      }
      
      private float companySelf;
      /// <summary>
      ///  企业自筹
      /// </summary>
      public float CompanySelf
      {
          get { return companySelf; }
          set { companySelf = value; }
      }
      
      private float planLandTargets;
      /// <summary>
      /// 拟申请土地指标
      /// </summary>
      public float PlanLandTargets
      {
          get { return planLandTargets; }
          set { planLandTargets = value; }
      }
     
      private float getLandTargets;
      /// <summary>
      /// 已取得土地指标
      /// </summary>
      public float GetLandTargets
      {
          get { return getLandTargets; }
          set { getLandTargets = value; }
      }
       
      private float useLandTargets;
      /// <summary>
      /// 已使用土地指标
      /// </summary>
      public float UseLandTargets
      {
          get { return useLandTargets; }
          set { useLandTargets = value; }
      }
      
      private float actualUseLand;
      /// <summary>
      /// 项目实际使用土地指标
      /// </summary>
      public float ActualUseLand
      {
          get { return actualUseLand; }
          set { actualUseLand = value; }
      }
      
      private string landWay;
      /// <summary>
      /// 占用土地方式
      /// </summary>
      public string LandWay
      {
          get { return landWay; }
          set { landWay = value; }
      }
      
      private string predictStartTime;
      /// <summary>
      /// 预计开工时间
      /// </summary>
      public string PredictStartTime
      {
          get { return predictStartTime; }
          set { predictStartTime = value; }
      }
       
      private string predictFinishTime;
      /// <summary>
      /// 预计竣工时间
      /// </summary>
      public string PredictFinishTime
      {
          get { return predictFinishTime; }
          set { predictFinishTime = value; }
      }
      
      private string startTime;
      /// <summary>
      ///  实际开工时间
      /// </summary>
      public string StartTime
      {
          get { return startTime; }
          set { startTime = value; }
      }
      
      private string finishTime;
      /// <summary>
      /// 实际竣工时间
      /// </summary>
      public string FinishTime
      {
          get { return finishTime; }
          set { finishTime = value; }
      }
      
      private string progressNow;
      /// <summary>
      /// 目前形象进度
      /// </summary>
      public string ProgressNow
      {
          get { return progressNow; }
          set { progressNow = value; }
      }
      
      private string problems;
      /// <summary>
      ///  需要协调的问题------只有生态项目才有
      /// </summary>
      public string Problems
      {
          get { return problems; }
          set { problems = value; }
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
       /// <summary>
       /// 
       /// </summary>
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
      
      private int stateChange;
      /// <summary>
      /// 是否处于修改状态
      /// </summary>
      public int StateChange
      {
          get { return stateChange; }
          set { stateChange = value; }
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
      
      private int submitStatus;
      /// <summary>
      /// 是否为提交状态
      /// </summary>
      public int SubmitStatus
      {
          get { return submitStatus; }
          set { submitStatus = value; }
      }
      
      private int endState;
      /// <summary>
      /// 是否为结束状态
      /// </summary>
      public int EndState
      {
          get { return endState; }
          set { endState = value; }
      }

     
      
      private string remark;
      /// <summary>
      /// 备注
      /// </summary>
      public string Remark
      {
          get { return remark; }
          set { remark = value; }
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


      private string thisyear_investment;  //至**年底累计完成投资
       /// <summary>
      /// 至**年底累计完成投资
       /// </summary>
      public string Thisyear_investment
      {
          get { return thisyear_investment; }
          set { thisyear_investment = value; }
      }
      private string plane_investment;//***年计划投资

      /// <summary>
      /// ***年计划投资
      /// </summary>
      public string Plane_investment
      {
          get { return plane_investment; }
          set { plane_investment = value; }
      }

      private string thismonth_investment;//月底累计完成投资

       /// <summary>
      /// 月底累计完成投资
       /// </summary>
      public string Thismonth_investment
      {
          get { return thismonth_investment; }
          set { thismonth_investment = value; }
      }
      private string premonthes_investment;//1-**月底累计完成投资
      /// <summary>
      /// 1-**月底累计完成投资
      /// </summary>
      public string Premonthes_investment
      {
          get { return premonthes_investment; }
          set { premonthes_investment = value; }
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

      private float caInvestement;

      /// <summary>
      /// 截止**年累计完成投资
      /// </summary>
      public float CaInvestement
      {
          get { return caInvestement; }
          set { caInvestement = value; }
      }
      private float planInvestement;

       /// <summary>
       /// 计划投资
       /// </summary>
      public float PlanInvestement
      {
          get { return planInvestement; }
          set { planInvestement = value; }
      }

    }
}
