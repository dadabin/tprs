using System;
using System.Collections.Generic;

using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;


namespace Dal
{
  public  class ItemDal
  {



      #region 业主添加项目
      /// <summary>
      /// 
      /// </summary>
      /// <param name="type">1:表示生态；2：景观农业项目 ；3：百湖工程 ； 4：生态植被与恢复 5：特色旅游村 6：乡村旅游度假</param>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool add(int type, object item)
      {
          DataBase db = new DataBase();
          bool re = false;
          switch(type)
          {
              case 1://生态
                  {      
                      ItemstEntity itemst = (ItemstEntity)item;
                      String sql = "INSERT INTO t_itemst (PROJECTNAME,ADDRESS,PROGRESSCATEGORY,CONSTRUCTIONTYPE,CONSTRUCTIONAGE,CONTENTSCALE,GOVERNMENTPROJE,PROJECTNATURE,TOTLEMONEY,CENTRALMONEY,PROVINCIALMONEY,MUNICIPALMONEY,DISTRICTMONEY,BANKLOAN,USEPROGRESS,COMPANYSELF,PLANLANDTARGETS,GETLANDTARGETS,USELANDTARGETS,ACTUALUSELAND,LANDWAY,PREDICTSTARTTIME,PREDICTFINISHTIME,PROGRESSNOW,PROBLEMS,LOGINNAME,REMARK,thisyear_investment,plane_investment,thismonth_investment,premonthes_investment,SUBMITTIME,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) VALUES (@PROJECTNAME,@ADDRESS,@PROGRESSCATEGORY,@CONSTRUCTIONTYPE,@CONSTRUCTIONAGE,@CONTENTSCALE,@GOVERNMENTPROJE,@PROJECTNATURE,@TOTLEMONEY,@CENTRALMONEY,@PROVINCIALMONEY,@MUNICIPALMONEY,@DISTRICTMONEY,@BANKLOAN,@USEPROGRESS,@COMPANYSELF,@PLANLANDTARGETS,@GETLANDTARGETS,@USELANDTARGETS,@ACTUALUSELAND,@LANDWAY,@PREDICTSTARTTIME,@PREDICTFINISHTIME,@PROGRESSNOW,@PROBLEMS,@LOGINNAME,@REMARK,@thisyear_investment,@plane_investment,@thismonth_investment,@premonthes_investment,@SUBMITTIME,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5)";
                      SqlParameter[] param = new SqlParameter[37];
                      
                      param[0] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar,50);
                      param[0].Value = itemst.ProjectName;
                      param[1] = new SqlParameter("@ADDRESS", SqlDbType.VarChar,500);
                      param[1].Value = itemst.Address;
                      param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 500);
                      param[2].Value = itemst.ProgressCategory;//itemst.Progre
                      param[3] = new SqlParameter("@CONSTRUCTIONTYPE", SqlDbType.VarChar, 500);
                      param[3].Value = itemst.ConstructionType;
                      param[4] = new SqlParameter("@CONSTRUCTIONAGE", SqlDbType.VarChar, 500);
                      param[4].Value = itemst.ConstructionAge;//itemst.ConstructionAge;
                      param[5] = new SqlParameter("@CONTENTSCALE", SqlDbType.VarChar, 500);
                      param[5].Value = itemst.ContentScale;
                      param[6] = new SqlParameter("@GOVERNMENTPROJE", SqlDbType.VarChar, 500);
                      param[6].Value = itemst.GovernmentProje;
                      param[7] = new SqlParameter("@PROJECTNATURE", SqlDbType.VarChar, 500);
                      param[7].Value = itemst.ProjectNature;
                      param[8] = new SqlParameter("@TOTLEMONEY", SqlDbType.Float);
                      param[8].Value = itemst.TotleMoney;
                      param[9] = new SqlParameter("@CENTRALMONEY", SqlDbType.Float);
                      param[9].Value = itemst.CentralMoney;

                      param[10] = new SqlParameter("@PROVINCIALMONEY", SqlDbType.Float);
                      param[10].Value = itemst.ProvincialMoney;
                      param[11] = new SqlParameter("@MUNICIPALMONEY", SqlDbType.Float);
                      param[11].Value = itemst.MunicipalMoney;
                      param[12] = new SqlParameter("@DISTRICTMONEY", SqlDbType.Float);
                      param[12].Value = itemst.DistrictMoney;
                      param[13] = new SqlParameter("@BANKLOAN", SqlDbType.Float);
                      param[13].Value = itemst.BankLoan;
                      param[14] = new SqlParameter("@USEPROGRESS", SqlDbType.Float);
                      param[14].Value = itemst.UseProgress;
                      param[15] = new SqlParameter("@COMPANYSELF", SqlDbType.Float);
                      param[15].Value = itemst.CompanySelf;
                      param[16] = new SqlParameter("@PLANLANDTARGETS", SqlDbType.Float);
                      param[16].Value = itemst.PlanLandTargets;
                      param[17] = new SqlParameter("@GETLANDTARGETS", SqlDbType.Float);
                      param[17].Value = itemst.GetLandTargets;
                      param[18] = new SqlParameter("@USELANDTARGETS", SqlDbType.Float);
                      param[18].Value = itemst.UseLandTargets;
                      param[19] = new SqlParameter("@ACTUALUSELAND", SqlDbType.Float);
                      param[19].Value = itemst.ActualUseLand ;
                      param[20] = new SqlParameter("@LANDWAY", SqlDbType.VarChar, 2000);
                      param[20].Value = itemst.LandWay;
                      param[21] = new SqlParameter("@PREDICTSTARTTIME", SqlDbType.VarChar, 500);
                      param[21].Value = itemst.PredictStartTime;
                      param[22] = new SqlParameter("@PREDICTFINISHTIME", SqlDbType.VarChar, 500);
                      param[22].Value = itemst.PredictFinishTime;
                      param[23] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar,500);
                      param[23].Value = itemst.ProgressNow;
                      param[24] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, -1);
                      param[24].Value = itemst.Problems;
                      param[25] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[25].Value = itemst.LoginName;
                      param[26] = new SqlParameter("@REMARK", SqlDbType.VarChar, -1);
                      param[26].Value = itemst.Remark;

                      param[27] = new SqlParameter("@thisyear_investment", SqlDbType.VarChar, 50);
                      param[27].Value = itemst.Thisyear_investment;
                      param[28] = new SqlParameter("@plane_investment", SqlDbType.VarChar, 50);
                      param[28].Value = itemst.Plane_investment;
                      param[29] = new SqlParameter("@thismonth_investment", SqlDbType.VarChar, 50);
                      param[29].Value = itemst.Thismonth_investment;
                      param[30] = new SqlParameter("@premonthes_investment", SqlDbType.VarChar, 50);
                      param[30].Value = itemst.Premonthes_investment;

                      param[31] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar, 50);
                      param[31].Value = DateTime.Now;

                      param[32] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[32].Value = itemst.Image1;
                      param[33] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[33].Value = itemst.Image2;
                      param[34] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[34].Value = itemst.Image3;

                      param[35] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[35].Value = itemst.Image4;
                      param[36] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                      param[36].Value = itemst.Image5;

                        

                      if (1 == db.ExecuteSql(sql, param))
                      {
                          re = true ;
                      }


                  }break;
              case 2://景观农业
                  {
                      ItemjgEntity itemjg = (ItemjgEntity)item;
                      String sql = "INSERT INTO t_itemjg (LOGINNAME,PROJECTNAME,ADDRESS,CONTENTSCALE,PLANTOTALMONEY,XYEARPLAN,ENDYEAR,PREYEARPLAN,XMONFIN,PROGRESSNOW,STARTENDTIME,ProgressCategory,SUBMITTIME,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) VALUES (@LOGINNAME,@PROJECTNAME,@ADDRESS,@CONTENTSCALE,@PLANTOTALMONEY,@XYEARPLAN,@ENDYEAR,@PREYEARPLAN,@XMONFIN,@PROGRESSNOW,@STARTENDTIME,@ProgressCategory,@SUBMITTIME,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5)";
                      SqlParameter[] param = new SqlParameter[18];
                      param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[0].Value = itemjg.LoginName;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
                      param[1].Value = itemjg.ProjectName;
                      param[2] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
                      param[2].Value = itemjg.Address;

                      param[3] = new SqlParameter("@CONTENTSCALE", SqlDbType.VarChar, 4000);
                      param[3].Value = itemjg.ContentScale;
                      param[4] = new SqlParameter("@PLANTOTALMONEY", SqlDbType.VarChar, 10);
                      param[4].Value = itemjg.PlanTotalMoney;
                      param[5] = new SqlParameter("@XYEARPLAN", SqlDbType.VarChar, 10);
                      param[5].Value = itemjg.XYearPlan;
                      param[6] = new SqlParameter("@ENDYEAR", SqlDbType.VarChar, 10);
                      param[6].Value = itemjg.EndYear ;

                      param[7] = new SqlParameter("@PREYEARPLAN", SqlDbType.VarChar, 10);
                      param[7].Value = itemjg.PreYearPlan ;

                      param[8] = new SqlParameter("@XMONFIN", SqlDbType.VarChar, 10);
                      param[8].Value = itemjg.XMonFin ;

                      param[9] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 3000);
                      param[9].Value = itemjg.XProgressNow ;
                      param[10] = new SqlParameter("@STARTENDTIME", SqlDbType.VarChar, 10);
                      param[10].Value = itemjg.StartEndTime;


                      param[11] = new SqlParameter("@ProgressCategory", SqlDbType.VarChar, 30);
                      param[11].Value = itemjg.ProgressCategory;
                      param[12] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar, 30);
                      param[12].Value = DateTime.Now;

                      param[13] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[13].Value = itemjg.Image1;
                      param[14] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[14].Value = itemjg.Image2;
                      param[15] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[15].Value = itemjg.Image3;
                      param[16] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[16].Value = itemjg.Image4;
                      param[17] = new SqlParameter("IMAGE5", SqlDbType.VarChar, 200);
                      param[17].Value = itemjg.Image5;

                      if (1 == db.ExecuteSql(sql, param))
                      {
                          re = true;
                      }
                  } break;
              case 3: //百湖工程
                  {
                      ItembhEntity itembh = (ItembhEntity)item;
                      String sql = "INSERT INTO t_itembh (LOGINNAME,PROJECTNAME,ADDRESS,FINISHTIME,PROGRESSCATEGORY,ZONEAREA,PROVINCIALEVELFISCAL,MUNICIPALFINANCE,COUNTYFINANCE,FINANCEFINANCE,SOCIALINVESTMENT,PUBLICINVESTMENT,OTHER,OCCUPIEDAREA,OCCUPIEDTYPE,UNITPRICE,IMAGEPROGRESS,MANAGESUBJECT,SUBMITTIME,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5)values(@LOGINNAME,@PROJECTNAME,@ADDRESS,@FINISHTIME,@PROGRESSCATEGORY,@ZONEAREA,@PROVINCIALEVELFISCAL,@MUNICIPALFINANCE,@COUNTYFINANCE,@FINANCEFINANCE,@SOCIALINVESTMENT,@PUBLICINVESTMENT,@OTHER,@OCCUPIEDAREA,@OCCUPIEDTYPE,@UNITPRICE,@IMAGEPROGRESS,@MANAGESUBJECT,@SUBMITTIME,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5)";
                      SqlParameter[] param = new SqlParameter[24];

                      param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[0].Value = itembh.LoginName;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 500);
                      param[1].Value = itembh.ProjectName;
                      param[2] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 500);
                      param[2].Value = itembh.Address;
                      param[3] = new SqlParameter("@FINISHTIME", SqlDbType.VarChar, 20);
                      param[3].Value = itembh.FinishTime;
                      param[4] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 10);
                      param[4].Value = itembh.ProgressCategory;
                      param[5] = new SqlParameter("@PROVINCIALEVELFISCAL", SqlDbType.VarChar,10);
                      param[5].Value = itembh.ProvinciaLevelFiscal;
                      param[6] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar, 10);
                      param[6].Value = itembh.ZoneArea;
                      param[7] = new SqlParameter("@MUNICIPALFINANCE", SqlDbType.VarChar, 10);
                      param[7].Value = itembh.MunicipalFinance;
                      param[8] = new SqlParameter("@COUNTYFINANCE", SqlDbType.VarChar, 10);
                      param[8].Value = itembh.CountyFinance;
                      param[9] = new SqlParameter("@FINANCEFINANCE", SqlDbType.VarChar, 10);
                      param[9].Value = itembh.FinanceFinance;
                      param[10] = new SqlParameter("@SOCIALINVESTMENT", SqlDbType.VarChar, 10);
                      param[10].Value = itembh.SocialInvestment;
                      param[11] = new SqlParameter("@PUBLICINVESTMENT", SqlDbType.VarChar, 10);
                      param[11].Value = itembh.PublicInvestment;
                      param[12] = new SqlParameter("@OTHER", SqlDbType.VarChar,10);
                      param[12].Value = itembh.Other;
                      param[13] = new SqlParameter("@OCCUPIEDAREA", SqlDbType.VarChar, 10);
                      param[13].Value = itembh.OccupiedArea;
                      param[14] = new SqlParameter("@OCCUPIEDTYPE", SqlDbType.VarChar, 10);
                      param[14].Value = itembh.OccupiedType;
                      param[15] = new SqlParameter("@UNITPRICE", SqlDbType.VarChar, 10);
                      param[15].Value = itembh.UnitPrice;
                      param[16] = new SqlParameter("@IMAGEPROGRESS", SqlDbType.VarChar, 3000);
                      param[16].Value = itembh.ImageProgress;
                      param[17] = new SqlParameter("@MANAGESUBJECT", SqlDbType.VarChar, 200);
                      param[17].Value = itembh.ManageSubject;

                      param[18] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar, 200);
                      param[18].Value = DateTime.Now;
                      param[19] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[19].Value = itembh.Image1;
                      param[20] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[20].Value = itembh.Image2;
                      param[21] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[21].Value = itembh.Image3;
                      param[22] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[22].Value = itembh.Image4;
                      param[23] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                      param[23].Value = itembh.Image5;

                      if (1 == db.ExecuteSql(sql, param))
                      {
                          re = true;
                      }
                  } break;
              //case 4: //生态植被与恢复
              //    {
              //       ItemzbEntity itemzbEntity = (ItemzbEntity)item;
              //        String sql = "INSERT INTO t_itemzb(ADDRESS,PROJECTNAME,ZONEAREA,MAINTREESPECIES,FORESTLANDSCAPE,MANAGESUBJECT,TRIPELEMENT,LOGINNAME) values(@ADDRESS,@PROJECTNAME,@ZONEAREA,@MAINTREESPECIES,@FORESTLANDSCAPE,@MANAGESUBJECT,@TRIPELEMENT,@LOGINNAME)";
              //        SqlParameter[] param = new SqlParameter[8];
              //        param[0] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //        param[0].Value = itemzbEntity.Address;
              //        param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //        param[1].Value = itemzbEntity.ProjectName;
              //        param[2] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar);
              //        param[2].Value = itemzbEntity.ZoneArea;
              //        param[3] = new SqlParameter("@MAINTREESPECIES", SqlDbType.VarChar, 2000);
              //        param[3].Value = itemzbEntity.MainTreeSpecies;
              //        param[4] = new SqlParameter("@FORESTLANDSCAPE", SqlDbType.VarChar, 2000);
              //        param[4].Value = itemzbEntity.ForestLandscape;
              //        param[5] = new SqlParameter("@MANAGESUBJECT", SqlDbType.VarChar, 2000);
              //        param[5].Value = itemzbEntity.ManageSubject;
              //        param[6] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar);
              //        param[6].Value = itemzbEntity.TripElement;
              //        param[7] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
              //        param[7].Value = itemzbEntity.LoginName;

              //        if (1 == db.ExecuteSql(sql, param))
              //        {
              //            re = true;
              //        }
              //    } break;
              //case 5://特色旅游村
              //    {
              //        ItemtsEntity itemtsEntity = (ItemtsEntity)item;
              //        String sql = "INSERT INTO t_itemts (ADDRESS,PROJECTNAME,BASICSITUATION,PROJECTPLAN,TRIPELEMENT,DEVELOPCHARAC,GAP,LOGINNAME) VALUES (@ADDRESS,@PROJECTNAME,@BASICSITUATION,@PROJECTPLAN,@TRIPELEMENT,@DEVELOPCHARAC,@GAP,@LOGINNAME)";

              //        SqlParameter[] param = new SqlParameter[8];
              //        param[0] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //        param[0].Value = itemtsEntity.Address;
              //        param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //        param[1].Value = itemtsEntity.ProjectName ;
              //        param[2] = new SqlParameter("@BASICSITUATION", SqlDbType.VarChar, 2000);
              //        param[2].Value = itemtsEntity.BasicSituation;
              //        param[3] = new SqlParameter("@PROJECTPLAN", SqlDbType.VarChar, 2000);
              //        param[3].Value = itemtsEntity.ProjectPlan;
              //        param[4] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, 2000);
              //        param[4].Value = itemtsEntity.TripElement;
              //        param[5] = new SqlParameter("@DEVELOPCHARAC", SqlDbType.VarChar, 1000);
              //        param[5].Value = itemtsEntity.DevelopCharac;
              //        param[6] = new SqlParameter("@GAP", SqlDbType.VarChar, 2000);
              //        param[6].Value = itemtsEntity.Gap;
              //        param[7] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
              //        param[7].Value = itemtsEntity.LoginName;

              //        if (1 == db.ExecuteSql(sql, param))
              //        {
              //            re = true;
              //        }
                  
              //    } break;
              //case 6://乡村旅游度假
              //    {
              //        ItemxcEntity itemxc = (ItemxcEntity)item;
              //        String sql = "INSERT INTO t_itemxc (LOGINNAME,ADDRESS,PROJECTNAME,BASICSITUATION,PROJECTPLAN,TRIPELEMENT,DEVELOPCHARAC,GAP) values (@LOGINNAME,@ADDRESS,@PROJECTNAME,@BASICSITUATION,@PROJECTPLAN,@TRIPELEMENT,@DEVELOPCHARAC,@GAP)";
              //        SqlParameter[] param = new SqlParameter[8];
              //        param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
              //        param[0].Value = itemxc.LoginName;
              //        param[1] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //        param[1].Value = itemxc.Address;
              //        param[2] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //        param[2].Value = itemxc.ProjectName;
              //        param[3] = new SqlParameter("@BASICSITUATION", SqlDbType.VarChar, -1);
              //        param[3].Value = itemxc.BasicSituation;
              //        param[4] = new SqlParameter("@PROJECTPLAN", SqlDbType.VarChar, -1);
              //        param[4].Value = itemxc.ProjectPlan;
              //        param[5] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, -1);
              //        param[5].Value = itemxc.TripElement;
              //        param[6] = new SqlParameter("@DEVELOPCHARAC", SqlDbType.VarChar, -1);
              //        param[6].Value = itemxc.DevelopCharac ;
              //        param[7] = new SqlParameter("@GAP", SqlDbType.VarChar, -1);
              //        param[7].Value = itemxc.Gap ;
              //        if (1 == db.ExecuteSql(sql, param))
              //        {
              //            re = true;
              //        }
              //    } break;
              default: break;
          }
          return re;
      }

      //sun
      public bool isAddItem(int type, object item)
      {
          DataBase db = new DataBase();
          bool re = true;
          switch (type)
          {
              case 1://生态
                  {
                      ItemstEntity itemst = (ItemstEntity)item;
                      String sql = "select count(*) from t_itemst where PROJECTNAME=@PROJECTNAME and LOGINNAME=@LOGINNAME";
                      SqlParameter[] param = new SqlParameter[2];
                      param[0] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 50);
                      param[0].Value = itemst.ProjectName;
                      param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[1].Value = itemst.LoginName;
                      if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                      {
                          re = false;
                      }


                  } break;
              case 2://景观农业
                  {
                      ItemjgEntity itemjg = (ItemjgEntity)item;
                      String sql = "select count(*) from t_itemjg where LOGINNAME=@LOGINNAME and PROJECTNAME=@PROJECTNAME ";
                      SqlParameter[] param = new SqlParameter[2];
                      param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[0].Value = itemjg.LoginName;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
                      param[1].Value = itemjg.ProjectName;


                      if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                      {
                          re = false;
                      }
                  } break;
              case 3: //百湖工程
                  {
                      ItembhEntity itembh = (ItembhEntity)item;
                      String sql = "select count(*) from t_itembh where LOGINNAME=@LOGINNAME and PROJECTNAME=@PROJECTNAME";
                      SqlParameter[] param = new SqlParameter[2];

                      param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                      param[0].Value = itembh.LoginName;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 500);
                      param[1].Value = itembh.ProjectName;

                      if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                      {
                          re = false;
                      }
                  } break;
             }
          return re;
      }

      #endregion

      #region 删除项目
      /// <summary>
      /// 删除项目
      /// </summary>
      /// <param name="type"></param>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool delete(int type, int projectid)
      {
          DataBase db = new DataBase();
          bool re = false;
          switch (type)
          {
              case 1:
                  {
                      String sql = "DELETE FROM t_itemst WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 2:
                  {

                      String sql = "DELETE from t_itemjg WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;                  
                      }
                  } break;
              case 3:
                  {
                      String sql = "DELETE from t_itembh WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }


                  } break;
              case 4:
                  {
                      String sql = "DELETE FROM t_itemzb WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID",SqlDbType.Int);
                      param[0].Value = projectid;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }


                  } break;
              case 5:
                  {
                      String sql = "DELETE FROM t_itemts WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 6:
                  {
                      String sql = "DELETE FROM t_itemxc WHERE WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;

                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }


                  } break;
              default: break;


          }

          return re;

      }
      #endregion

      #region 修改项目

      /// <summary>
      /// 修改项目
      /// </summary>
      /// <param name="type"></param>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool update(int type, object item,string loginName)
      {
          bool re = false;

          switch (type)
          {
              case 1://生态旅游重大项目
                  {
                     ItemstEntity itemst = (ItemstEntity)item;
                     String sql = "UPDATE t_itemst set PROJECTNAME=@PROJECTNAME,ADDRESS=@ADDRESS,PROGRESSCATEGORY=@PROGRESSCATEGORY,CONSTRUCTIONTYPE=@CONSTRUCTIONTYPE,CONSTRUCTIONAGE=@CONSTRUCTIONAGE,CONTENTSCALE=@CONTENTSCALE,GOVERNMENTPROJE=@GOVERNMENTPROJE,PROJECTNATURE=@PROJECTNATURE,TOTLEMONEY=@TOTLEMONEY,CENTRALMONEY=@CENTRALMONEY,PROVINCIALMONEY=@PROVINCIALMONEY,MUNICIPALMONEY=@MUNICIPALMONEY,DISTRICTMONEY=@DISTRICTMONEY,BANKLOAN=@BANKLOAN,USEPROGRESS=@USEPROGRESS,COMPANYSELF=@COMPANYSELF,PLANLANDTARGETS=@PLANLANDTARGETS,GETLANDTARGETS=@GETLANDTARGETS,USELANDTARGETS=@USELANDTARGETS,ACTUALUSELAND=@ACTUALUSELAND,LANDWAY=@LANDWAY,PREDICTSTARTTIME=@PREDICTSTARTTIME,PREDICTFINISHTIME=@PREDICTFINISHTIME,PROGRESSNOW=@PROGRESSNOW,PROBLEMS=@PROBLEMS,MODIFYUSER=@MODIFYUSER ,REMARK=@REMARK,thisyear_investment=@thisyear_investment,plane_investment=@plane_investment,thismonth_investment=@thismonth_investment,premonthes_investment=@premonthes_investment,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5 WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[37];

                      //PROJECTNAME,ADDRESS,PROGRESSCATEGORY,CONSTRUCTIONTYPE,CONSTRUCTIONAGE,
                      //CONTENTSCALE,GOVERNMENTPROJE,PROJECTNATURE,TOTLEMONEY,CENTRALMONEY,
                      //PROVINCIALMONEY,MUNICIPALMONEY,DISTRICTMONEY,BANKLOAN,USEPROGRESS,
                      //COMPANYSELF,PLANLANDTARGETS,GETLANDTARGETS,USELANDTARGETS,ACTUALUSELAND,
                      //LANDWAY,PREDICTSTARTTIME,PREDICTFINISHTIME,PROGRESSNOW,PROBLEMS,LOGINNAME
                    
                      param[0] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
                      param[0].Value = itemst.ProjectName;
                      param[1] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
                      param[1].Value = itemst.Address;
                      param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                      param[2].Value = itemst.ProgressCategory;//itemst.Progre
                      param[3] = new SqlParameter("@CONSTRUCTIONTYPE", SqlDbType.VarChar, 200);
                      param[3].Value = itemst.ConstructionType;
                      param[4] = new SqlParameter("@CONSTRUCTIONAGE", SqlDbType.VarChar, 50);
                      param[4].Value = itemst.ConstructionAge;//itemst.ConstructionAge;
                      param[5] = new SqlParameter("@CONTENTSCALE", SqlDbType.VarChar, 200);
                      param[5].Value = itemst.ContentScale;
                      param[6] = new SqlParameter("@GOVERNMENTPROJE", SqlDbType.VarChar, 300);
                      param[6].Value = itemst.GovernmentProje;
                      param[7] = new SqlParameter("@PROJECTNATURE", SqlDbType.VarChar, 500);
                      param[7].Value = itemst.ProjectNature;
                      param[8] = new SqlParameter("@TOTLEMONEY", SqlDbType.Float);
                      param[8].Value = itemst.TotleMoney;
                      param[9] = new SqlParameter("@CENTRALMONEY", SqlDbType.Float);
                      param[9].Value = itemst.CentralMoney;

                      param[10] = new SqlParameter("@PROVINCIALMONEY", SqlDbType.Float);
                      param[10].Value = itemst.ProvincialMoney;
                      param[11] = new SqlParameter("@MUNICIPALMONEY", SqlDbType.Float);
                      param[11].Value = itemst.MunicipalMoney;
                      param[12] = new SqlParameter("@DISTRICTMONEY", SqlDbType.Float);
                      param[12].Value = itemst.DistrictMoney;
                      param[13] = new SqlParameter("@BANKLOAN", SqlDbType.Float);
                      param[13].Value = itemst.BankLoan;
                      param[14] = new SqlParameter("@USEPROGRESS", SqlDbType.Float);
                      param[14].Value = itemst.UseProgress;
                      param[15] = new SqlParameter("@COMPANYSELF", SqlDbType.Float);
                      param[15].Value = itemst.CompanySelf;
                      param[16] = new SqlParameter("@PLANLANDTARGETS", SqlDbType.Float);
                      param[16].Value = itemst.PlanLandTargets;
                      param[17] = new SqlParameter("@GETLANDTARGETS", SqlDbType.Float);
                      param[17].Value = itemst.GetLandTargets;
                      param[18] = new SqlParameter("@USELANDTARGETS", SqlDbType.Float);
                      param[18].Value = itemst.UseLandTargets;
                      param[19] = new SqlParameter("@ACTUALUSELAND", SqlDbType.Float);
                      param[19].Value = itemst.ActualUseLand;

                      //@LANDWAY,@PREDICTSTARTTIME,@PREDICTFINISHTIME,@STARTTIME,@FINISHTIME,@PROGRESSNOW,@PROBLEMS
                      param[20] = new SqlParameter("@LANDWAY", SqlDbType.VarChar, -1);
                      param[20].Value = itemst.LandWay;
                      param[21] = new SqlParameter("@PREDICTSTARTTIME", SqlDbType.VarChar, 500);
                      param[21].Value = itemst.PredictStartTime;
                      param[22] = new SqlParameter("@PREDICTFINISHTIME", SqlDbType.VarChar, 500);
                      param[22].Value = itemst.PredictFinishTime;
                      param[23] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, -1);
                      param[23].Value = itemst.ProgressNow;
                      param[24] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, -1);
                      param[24].Value = itemst.Problems;
                      param[25] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
                      param[25].Value = itemst.ModifyUser;
                      param[26] = new SqlParameter("@REMARK", SqlDbType.VarChar,-1);
                      param[26].Value = itemst.Remark;
                      param[27] = new SqlParameter("@ID", SqlDbType.Int);
                      param[27].Value = itemst.Id;

                      //,thisyear_investment,plane_investment,thismonth_investment,premonthes_investment

                      param[28] = new SqlParameter("@thisyear_investment", SqlDbType.VarChar,100);
                      param[28].Value = itemst.Thisyear_investment;

                      param[29] = new SqlParameter("@plane_investment", SqlDbType.VarChar, 100);
                      param[29].Value = itemst.Plane_investment;

                      param[30] = new SqlParameter("@thismonth_investment", SqlDbType.VarChar, 100);
                      param[30].Value = itemst.Thismonth_investment;
                      param[31] = new SqlParameter("@premonthes_investment", SqlDbType.VarChar, 100);
                      param[31].Value = itemst.Premonthes_investment;

                      param[32] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[32].Value = itemst.Image1;
                      param[33] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[33].Value = itemst.Image2;
                      param[34] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[34].Value = itemst.Image3;

                      param[35] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[35].Value = itemst.Image4;
                      param[36] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                      param[36].Value = itemst.Image5;



                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }


                  } break;
              case 2://景观农业
                  {
                      ItemjgEntity itemjg = (ItemjgEntity)item;
                      String sql = "UPDATE  t_itemjg SET MODIFYUSER=@MODIFYUSER,PROJECTNAME=@PROJECTNAME,ADDRESS=@ADDRESS,CONTENTSCALE=@CONTENTSCALE,PLANTOTALMONEY=@PLANTOTALMONEY,XYEARPLAN=@XYEARPLAN,ENDYEAR=@ENDYEAR,PREYEARPLAN=@PREYEARPLAN,XMONFIN=@XMONFIN,PROGRESSNOW=@PROGRESSNOW,STARTENDTIME=@STARTENDTIME,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5,PROGRESSCATEGORY=@PROGRESSCATEGORY  WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[18];
                      param[0] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
                      param[0].Value = itemjg.ModifyUser;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
                      param[1].Value = itemjg.ProjectName;
                      param[2] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
                      param[2].Value = itemjg.Address;

                      param[3] = new SqlParameter("@CONTENTSCALE", SqlDbType.VarChar, 4000);
                      param[3].Value = itemjg.ContentScale;
                      param[4] = new SqlParameter("@PLANTOTALMONEY", SqlDbType.VarChar, 10);
                      param[4].Value = itemjg.PlanTotalMoney;
                      param[5] = new SqlParameter("@XYEARPLAN", SqlDbType.VarChar, 10);
                      param[5].Value = itemjg.XYearPlan;
                      param[6] = new SqlParameter("@ENDYEAR", SqlDbType.VarChar, 10);
                      param[6].Value = itemjg.EndYear;

                      param[7] = new SqlParameter("@PREYEARPLAN", SqlDbType.VarChar, 10);
                      param[7].Value = itemjg.XYearPlan;

                      param[8] = new SqlParameter("@XMONFIN", SqlDbType.VarChar, 10);
                      param[8].Value = itemjg.XMonFin;

                      param[9] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, -1);
                      param[9].Value = itemjg.XProgressNow;
                      param[10] = new SqlParameter("@STARTENDTIME", SqlDbType.VarChar, -1);
                      param[10].Value = itemjg.StartEndTime;
                      param[11] = new SqlParameter("@ID", SqlDbType.VarChar, 10);
                      param[11].Value = itemjg.ID;
                      param[12] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[12].Value = itemjg.Image1;
                      param[13] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[13].Value = itemjg.Image2;
                      param[14] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[14].Value = itemjg.Image3;
                      param[15] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[15].Value = itemjg.Image4;
                      param[16] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                      param[16].Value = itemjg.Image5;
                      param[17] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 4);
                      param[17].Value = itemjg.ProgressCategory;

                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 3://百湖工程
                  {
                      ItembhEntity itembh = (ItembhEntity)item;
                      String sql = "UPDATE t_itembh SET MODIFYUSER=@MODIFYUSER,PROJECTNAME=@PROJECTNAME,ADDRESS=@ADDRESS,FINISHTIME=@FINISHTIME,PROGRESSCATEGORY=@PROGRESSCATEGORY,ZONEAREA=@ZONEAREA,PROVINCIALEVELFISCAL=@PROVINCIALEVELFISCAL,MUNICIPALFINANCE=@MUNICIPALFINANCE,COUNTYFINANCE=@COUNTYFINANCE,FINANCEFINANCE=@FINANCEFINANCE,SOCIALINVESTMENT=@SOCIALINVESTMENT,PUBLICINVESTMENT=@PUBLICINVESTMENT,OTHER=@OTHER,OCCUPIEDAREA=@OCCUPIEDAREA,OCCUPIEDTYPE=@OCCUPIEDTYPE,UNITPRICE=@UNITPRICE,IMAGEPROGRESS=@IMAGEPROGRESS,MANAGESUBJECT=@MANAGESUBJECT,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5  WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[24];
                      param[0] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
                      param[0].Value = itembh.ModifyUser;
                      param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 500);
                      param[1].Value = itembh.ProjectName;
                      param[2] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 500);
                      param[2].Value = itembh.Address;
                      param[3] = new SqlParameter("@FINISHTIME", SqlDbType.VarChar, 20);
                      param[3].Value = itembh.FinishTime;
                      param[4] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 10);
                      param[4].Value = itembh.ProgressCategory;
                      param[5] = new SqlParameter("@PROVINCIALEVELFISCAL", SqlDbType.VarChar, 10);
                      param[5].Value = itembh.ProvinciaLevelFiscal;
                      param[6] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar, 10);
                      param[6].Value = itembh.ZoneArea;
                      param[7] = new SqlParameter("@MUNICIPALFINANCE", SqlDbType.VarChar, 10);
                      param[7].Value = itembh.MunicipalFinance;
                      param[8] = new SqlParameter("@COUNTYFINANCE", SqlDbType.VarChar, 10);
                      param[8].Value = itembh.CountyFinance;
                      param[9] = new SqlParameter("@FINANCEFINANCE", SqlDbType.VarChar, 10);
                      param[9].Value = itembh.FinanceFinance;
                      param[10] = new SqlParameter("@SOCIALINVESTMENT", SqlDbType.VarChar, 10);
                      param[10].Value = itembh.SocialInvestment;
                      param[11] = new SqlParameter("@PUBLICINVESTMENT", SqlDbType.VarChar, 10);
                      param[11].Value = itembh.PublicInvestment;
                      param[12] = new SqlParameter("@OTHER", SqlDbType.VarChar, 10);
                      param[12].Value = itembh.Other;
                      param[13] = new SqlParameter("@OCCUPIEDAREA", SqlDbType.VarChar, 10);
                      param[13].Value = itembh.OccupiedArea;
                      param[14] = new SqlParameter("@OCCUPIEDTYPE", SqlDbType.VarChar, 10);
                      param[14].Value = itembh.OccupiedType;
                      param[15] = new SqlParameter("@UNITPRICE", SqlDbType.VarChar, 10);
                      param[15].Value = itembh.UnitPrice;
                      param[16] = new SqlParameter("@IMAGEPROGRESS", SqlDbType.VarChar, 3000);
                      param[16].Value = itembh.ImageProgress;
                      param[17] = new SqlParameter("@MANAGESUBJECT", SqlDbType.VarChar, 2000);
                      param[17].Value = itembh.ManageSubject;
                      param[18] = new SqlParameter("@ID", SqlDbType.VarChar, 20);
                      param[18].Value = itembh.ID;
                      param[19] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                      param[19].Value = itembh.Image1;
                      param[20] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                      param[20].Value = itembh.Image2;
                      param[21] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                      param[21].Value = itembh.Image3;
                      param[22] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                      param[22].Value = itembh.Image4;
                      param[23] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                      param[23].Value = itembh.Image5;


                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              //case 4://植被恢复
              //    {
              //        ItemzbEntity itemzbEntity = (ItemzbEntity)item;
              //        String sql = "UPDATE t_itemzb SET ADDRESS=@ADDRESS,PROJECTNAME=@PROJECTNAME,ZONEAREA=@ZONEAREA,MAINTREESPECIES=@MAINTREESPECIES,FORESTLANDSCAPE=@FORESTLANDSCAPE,MANAGESUBJECT=@MANAGESUBJECT,TRIPELEMENT=@TRIPELEMENT,MODIFYUSER=@MODIFYUSER WHERE ID=@ID";
              //         SqlParameter[] param = new SqlParameter[9];
              //         param[0] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //         param[0].Value = itemzbEntity.Address;
              //         param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //         param[1].Value = itemzbEntity.ProjectName;
              //         param[2] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar,2000);
              //         param[2].Value = itemzbEntity.ZoneArea;
              //         param[3] = new SqlParameter("@MAINTREESPECIES", SqlDbType.VarChar, 2000);
              //         param[3].Value = itemzbEntity.MainTreeSpecies;
              //         param[4] = new SqlParameter("@FORESTLANDSCAPE", SqlDbType.VarChar, 2000);
              //         param[4].Value = itemzbEntity.ForestLandscape;
              //         param[5] = new SqlParameter("@MANAGESUBJECT", SqlDbType.VarChar, 2000);
              //         param[5].Value = itemzbEntity.ManageSubject;
              //         param[6] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar,4000);
              //         param[6].Value = itemzbEntity.TripElement;
              //         param[7] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
              //         param[7].Value = itemzbEntity.ModifyUser;
              //         param[8] = new SqlParameter("@ID",SqlDbType.Int);
              //         param[8].Value = itemzbEntity.Id;


              //        DataBase db = new DataBase();
              //        if (db.ExecuteSql(sql, param) == 1)
              //        {
              //            re = true;
              //        }

              //    } break;
              //case 5://特色旅游
              //    {
              //        ItemtsEntity itemtsEntity = (ItemtsEntity)item;
              //        String sql = "UPDATE t_itemts SET ADDRESS=@ADDRESS,PROJECTNAME=@PROJECTNAME,BASICSITUATION=@BASICSITUATION,PROJECTPLAN=@PROJECTPLAN,TRIPELEMENT=@TRIPELEMENT,DEVELOPCHARAC=@DEVELOPCHARAC,GAP=@GAP,MODIFYUSER=@MODIFYUSER WHERE ID=@ID";
              //        SqlParameter[] param = new SqlParameter[9];
              //        param[0] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //        param[0].Value = itemtsEntity.Address;
              //        param[1] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //        param[1].Value = itemtsEntity.ProjectName;
              //        param[2] = new SqlParameter("@BASICSITUATION", SqlDbType.VarChar, -1);
              //        param[2].Value = itemtsEntity.BasicSituation;
              //        param[3] = new SqlParameter("@PROJECTPLAN", SqlDbType.VarChar, -1);
              //        param[3].Value = itemtsEntity.ProjectPlan;
              //        param[4] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, -1);
              //        param[4].Value = itemtsEntity.TripElement;
              //        param[5] = new SqlParameter("@DEVELOPCHARAC", SqlDbType.VarChar, -1);
              //        param[5].Value = itemtsEntity.DevelopCharac;
              //        param[6] = new SqlParameter("@GAP", SqlDbType.VarChar, -1);
              //        param[6].Value = itemtsEntity.Gap;
              //        param[7] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
              //        param[7].Value = itemtsEntity.ModifyUser;
              //        param[8] = new SqlParameter("@ID", SqlDbType.Int);
              //        param[8].Value = itemtsEntity.Id;

              //        DataBase db = new DataBase();
              //        if (db.ExecuteSql(sql, param) == 1)
              //        {
              //            re = true;
              //        }
              //    } break;
              //case 6:// 乡村
              //    {
              //        ItemxcEntity itemxc = (ItemxcEntity)item;
              //        String sql = "UPDATE t_itemxc SET MODIFYUSER=@MODIFYUSER,ADDRESS=@ADDRESS,PROJECTNAME=@PROJECTNAME,BASICSITUATION=@BASICSITUATION,PROJECTPLAN=@PROJECTPLAN,TRIPELEMENT=@TRIPELEMENT,DEVELOPCHARAC=@DEVELOPCHARAC,GAP=@GAP WHERE ID=@ID";
              //        SqlParameter[] param = new SqlParameter[9];
              //        param[0] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar, 50);
              //        param[0].Value = itemxc.ModifyUser;
              //        param[1] = new SqlParameter("@ADDRESS", SqlDbType.VarChar, 200);
              //        param[1].Value = itemxc.Address;
              //        param[2] = new SqlParameter("@PROJECTNAME", SqlDbType.VarChar, 200);
              //        param[2].Value = itemxc.ProjectName;
              //        param[3] = new SqlParameter("@BASICSITUATION", SqlDbType.VarChar, -1);
              //        param[3].Value = itemxc.BasicSituation;
              //        param[4] = new SqlParameter("@PROJECTPLAN", SqlDbType.VarChar, -1);
              //        param[4].Value = itemxc.ProjectPlan;
              //        param[5] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, -1);
              //        param[5].Value = itemxc.TripElement;
              //        param[6] = new SqlParameter("@DEVELOPCHARAC", SqlDbType.VarChar, -1);
              //        param[6].Value = itemxc.DevelopCharac;
              //        param[7] = new SqlParameter("@GAP", SqlDbType.VarChar, -1);
              //        param[7].Value = itemxc.Gap;
              //        param[8] = new SqlParameter("@ID", SqlDbType.Int);
              //        param[8].Value = itemxc.ID;
                     
                      
              //        DataBase db = new DataBase();
              //        if (db.ExecuteSql(sql, param) == 1)
              //        {
              //            re = true;
              //        }
              //    } break;
              default: break;


          }

          return re;
      }

      #endregion



      #region 业主提交申报
      /// <summary>
      /// 业主提交申报=========================
      /// </summary>
      /// <param name="type"></param>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool submit(int type, int item,string state)
      {
          bool re = false;
          switch (type)
          {
              case 1:
                  {

                      String sql = "UPDATE t_itemst SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;
                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 2:
                  {

                      String sql = "UPDATE t_itemjg SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;

                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 3:
                  {
                      String sql = "UPDATE t_itembh SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;

                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 4:
                  {

                      String sql = "UPDATE t_itemzb SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;

                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 5:
                  {

                      String sql = "UPDATE t_itemts SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;

                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 6:
                  {

                      String sql = "UPDATE t_itemxc SET SUBMITSTATE =@SUBMITSTATE, SUBMITTIME=@SUBMITTIME WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = item;
                      param[1] = new SqlParameter("@SUBMITTIME", SqlDbType.VarChar);
                      param[1].Value = DateTime.Now;

                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.Int);
                      param[2].Value = state;

                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }



                  } break;
              default: break;


          }

          return re;
      }


   
      #endregion 


      /// <summary>
      /// 业主绑定
      /// 根据业主的登陆名 获取与其相关的项目列表
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="loginName"></param>
      public void userBindItem(GridView gv, AspNetPager pager,string loginName,string whereStr)
      {
          StringUtills utils = new StringUtills();
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("submit", typeof(string));
          dt.Columns.Add("pass",typeof(string));//TODO lpm
          dt.Columns.Add("projectid", typeof(string));
          dt.Columns.Add("reporturl", typeof(string));//季报报送入口
          dt.Columns.Add("reportpass", typeof(string));
          //dt.Columns.Add("delete",typeof(string));//删除

          DataTable dt1 = new DataTable();
          dt1.Columns.Add("itemNumber", typeof(string));
          dt1.Columns.Add("itemName", typeof(string));
          dt1.Columns.Add("submitTime", typeof(string));
          dt1.Columns.Add("itemType", typeof(string));
          dt1.Columns.Add("season", typeof(string));
          dt1.Columns.Add("month", typeof(string));
          dt1.Columns.Add("itemid", typeof(string));
          dt1.Columns.Add("submit", typeof(string));
          dt1.Columns.Add("pass", typeof(string));//TODO lpm
          dt1.Columns.Add("projectid", typeof(string));
          dt1.Columns.Add("reporturl", typeof(string));
          dt1.Columns.Add("reportpass", typeof(string));
          //dt1.Columns.Add("delete", typeof(string));//删除

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
          param[0].Value = loginName;
          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          DataTable dtzb = new DataTable();
          DataTable dtts = new DataTable();
          DataTable dtxc = new DataTable();

          string sqlst = "SELECT * FROM t_itemst " + whereStr;
          dtst = db.GetDataTable(sqlst, param);
          string sqljg = "SELECT * FROM t_itemjg " + whereStr;
          dtjg = db.GetDataTable(sqljg, param);
          string sqlbh = "SELECT * FROM t_itembh " + whereStr;
          dtbh = db.GetDataTable(sqlbh, param);
          //string sqlzb = "SELECT * FROM t_itemzb " + whereStr;
          //dtzb = db.GetDataTable(sqlzb, param);
          //string sqlts = "SELECT * FROM t_itemts " + whereStr;
          //dtts = db.GetDataTable(sqlts, param);
          //string sqlxc = "SELECT * FROM t_itemxc " + whereStr;
          //dtxc = db.GetDataTable(sqlxc,param);

          int month = System.DateTime.Now.Month;
          int year = System.DateTime.Now.Year;
          int day = System.DateTime.Now.Day;

          if (day < 6)
          {
              if (month - 1 == 0)
              {
                  month = 12;
                  year = year - 1;
              }
          }


          int season = 1;
          int syear = System.DateTime.Now.Year;

          if (day < 6)
          {
              if (System.DateTime.Now.Month == 1)
              {
                  syear = syear - 1;
                  season = 4;
              }
              else if (System.DateTime.Now.Month == 4)
              {
                  season = 1;
              }
              else if (System.DateTime.Now.Month == 7)
              {
                  season = 2;
              }
              else if (System.DateTime.Now.Month == 10)
              {
                  season = 3;
              }

          }
          else
          {
              switch (month)
              {
                  case 1:
                  case 2:
                  case 3:
                      season = 1;break;
                  case 4:
                  case 5:
                  case 6:
                      season = 2;break;
                  case 7:
                  case 8:
                  case 9:
                      season = 3;break;
                  case 10:
                  case 11:
                  case 12: 
                      season = 4; break;
                  default: break;
              }
          }

          if (dtst.Rows.Count > 0)
          {
              for (int i = 0; i < dtst.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = (dtst.Rows[i]["PROJECTNUMBER"].ToString().Trim() == null) ? "--" : dtst.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";

                  r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                  r["itemType"] = "重大项目";
                  r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                  r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtst.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtst.Rows[i]["SUBMITSTATE"].ToString().Trim()== "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtst.Rows[i]["ID"];
                  //

                  //m.REPORTTIME>cast(cast(@myBeginYear as varchar)+'/'+cast(@myBeginMonth as varchar)+'/'+cast(@myBeginDay as varchar) as datetime) and m.REPORTTIME<=cast(cast(@myEndYear as varchar)+'/'+cast(@myEndMonth as varchar)+'/'+cast(@myEndDay as varchar) as datetime)

                  DataTable datetimedt = db.GetDataTable("select * from dbo.getTimeByMonth("+year+","+month+")");

                  DataTable dtreport = db.GetDataTable("select * from t_itemst_month where PROJECTID=" + dtst.Rows[i]["ID"] + " and  REPORTTIME>cast(cast(" + datetimedt.Rows[0]["myBeginYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginDay"] + " as varchar) as datetime) and REPORTTIME<=cast(cast(" + datetimedt.Rows[0]["myEndYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndDay"] + " as varchar) as datetime) ");

                  if (dtreport.Rows.Count > 0)
                  {
                      r["reportpass"] = int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0 ? "未审核或审核未通过" : "审核通过";

                         if (int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0)
                         {
                             r["reporturl"] = "<a href='itemst_month_update.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";
                         }
                         else
                         {
                             r["reporturl"] = "不能修改";
                         }

                  }else{
                      r["reporturl"] = "<a href='itemst_month_add.aspx?projectID="+dtst.Rows[i]["ID"]+"'>点击填写</a>";
                      r["reportpass"] = "未填写";

                  }

                  dt.Rows.Add(r);
              }
          }
          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = (dtjg.Rows[i]["PROJECTNUMBER"].ToString().Trim() == null) ? "--" : dtjg.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                  
                  r["submitTime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString());
                  r["itemType"] = "景观农业";
                  r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtjg.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtjg.Rows[i]["ID"];

                  DataTable datetimedt = db.GetDataTable("select * from dbo.getTimeBySeason(" + syear + "," + season + ")");

                  DataTable dtreport = db.GetDataTable("select * from t_itemjg_season where PROJECTID=" + dtjg.Rows[i]["ID"] + " and  REPORTTIME>cast(cast(" + datetimedt.Rows[0]["myBeginYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginDay"] + " as varchar) as datetime) and REPORTTIME<=cast(cast(" + datetimedt.Rows[0]["myEndYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndDay"] + " as varchar) as datetime) ");

                  if (dtreport.Rows.Count > 0)
                  {
                      r["reportpass"] = int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0 ? "未审核或审核未通过" : "审核通过";

                      if (int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0)
                      {
                          r["reporturl"] = "<a href='itemjg_season_update.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";
                      }
                      else
                      {
                          r["reporturl"] = "不能修改";
                      }

                  }
                  else
                  {
                      r["reporturl"] = "<a href='itemjg_season_add.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>点击填写</a>";
                      r["reportpass"] = "未填写";

                  }


                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = (dtbh.Rows[i]["PROJECTNUMBER"].ToString().Trim() == null) ? "--" : dtbh.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                  
                  r["submitTime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString());
                 
                  r["itemType"] = "百湖工程";
                  r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtbh.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtbh.Rows[i]["ID"];
                  DataTable datetimedt = db.GetDataTable("select * from dbo.getTimeBySeason(" + syear + "," + season + ")");

                  DataTable dtreport = db.GetDataTable("select * from t_itembh_season where PROJECTID=" + dtbh.Rows[i]["ID"] + " and  REPORTTIME>cast(cast(" + datetimedt.Rows[0]["myBeginYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myBeginDay"] + " as varchar) as datetime) and REPORTTIME<=cast(cast(" + datetimedt.Rows[0]["myEndYear"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndMonth"] + " as varchar)+'/'+cast(" + datetimedt.Rows[0]["myEndDay"] + " as varchar) as datetime) ");

                  if (dtreport.Rows.Count > 0)
                  {
                      r["reportpass"] = int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0 ? "未审核或审核未通过" : "审核通过";

                      if (int.Parse(dtreport.Rows[0]["AUDIT"].ToString().Trim()) == 0)
                      {
                          r["reporturl"] = "<a href='itembh_season_update.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";
                      }
                      else
                      {
                          r["reporturl"] = "不能修改";
                      }

                  }
                  else
                  {
                      r["reporturl"] = "<a href='itembh_season_add.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>点击填写</a>";
                      r["reportpass"] = "未填写";

                  }
                  dt.Rows.Add(r);
              }
          }
        

          ///////////分页//////////
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();

                  r["itemNumber"] = dt.Rows[i]["itemNumber"];
                  r["itemName"] = dt.Rows[i]["itemName"];
                  r["submitTime"] = dt.Rows[i]["submitTime"];
                  r["itemType"] = dt.Rows[i]["itemType"];
                  r["season"] = dt.Rows[i]["season"];
                  r["month"] = dt.Rows[i]["month"];
                  r["itemid"] = dt.Rows[i]["itemid"];
                  r["pass"] = dt.Rows[i]["pass"];
                  r["submit"] = dt.Rows[i]["submit"];
                  r["projectid"] = dt.Rows[i]["projectid"];
                  r["reporturl"] = dt.Rows[i]["reporturl"];
                  r["reportpass"] = dt.Rows[i]["reportpass"];

                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;
          gv.DataBind();
      }

      #region  二级审核员查看项目 ------------领导查看项目（二者共用此方法！！！）！！！
      /// <summary>
      /// 查询
      /// 
      /// 注： whereStr 的格式为 and 加上条件！！！！！
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="loginName"></param>
      /// <param name="whereStr"></param>
      public void adminBindItem(GridView gv, AspNetPager pager, string whereStr,int itemtype)
      {
          StringUtills utils = new StringUtills();
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("loginusername", typeof(string));


          DataTable dt1 = new DataTable();
          dt1.Columns.Add("itemNumber", typeof(string));
          dt1.Columns.Add("itemName", typeof(string));
          dt1.Columns.Add("submitTime", typeof(string));
          dt1.Columns.Add("itemType", typeof(string));
          dt1.Columns.Add("season", typeof(string));
          dt1.Columns.Add("month", typeof(string));
          dt1.Columns.Add("itemid", typeof(string));
          dt1.Columns.Add("loginusername", typeof(string));
        
          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          //DataTable dtzb = new DataTable();
          //DataTable dtts = new DataTable();
          //DataTable dtxc = new DataTable();

          //SELECT t_itemst.*,t_user.username FROM t_itemst,t_user  WHERE t_user.LOGINNAME=t_itemst.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 
          // SELECT t_itemjg.*,t_user.username FROM t_itemjg,t_user   WHERE  t_user.LOGINNAME=t_itemjg.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 
          //  SELECT t_itembh.*,t_user.username FROM t_itembh,t_user   WHERE t_user.LOGINNAME=t_itembh.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 

          string sqlst = "SELECT t_itemst.*,t_user.username FROM t_itemst,t_user  WHERE t_user.LOGINNAME=t_itemst.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1  " + whereStr;
          dtst = db.GetDataTable(sqlst);
          string sqljg = "SELECT t_itemjg.*,t_user.username FROM t_itemjg,t_user   WHERE  t_user.LOGINNAME=t_itemjg.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 " + whereStr;
          dtjg = db.GetDataTable(sqljg);
          string sqlbh = "SELECT t_itembh.*,t_user.username FROM t_itembh,t_user   WHERE t_user.LOGINNAME=t_itembh.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1  " + whereStr;
          dtbh = db.GetDataTable(sqlbh);
          //string sqlzb = "SELECT t_itemzb.*,t_user.username FROM t_itemzb,t_user   WHERE t_user.LOGINNAME=t_itemzb.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 " + whereStr;
          //dtzb = db.GetDataTable(sqlzb);
          //string sqlts = "SELECT t_itemts.*,t_user.username FROM t_itemts,t_user   WHERE t_user.LOGINNAME=t_itemts.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 " + whereStr;
          //dtts = db.GetDataTable(sqlts);
          //string sqlxc = "SELECT t_itemxc.*,t_user.username FROM t_itemxc,t_user   WHERE t_user.LOGINNAME=t_itemxc.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 " + whereStr;
          //dtxc = db.GetDataTable(sqlxc);
          switch (itemtype)
          {
              case 0: {
                  if (dtst.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtst.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"] == null ? "--" : dtst.Rows[i]["PROJECTNUMBER"];

                          r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                          r["itemType"] = "重大项目";
                          r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                          r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";

                          r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                          dt.Rows.Add(r);
                      }
                  }
                  if (dtjg.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtjg.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                          r["itemType"] = "景观农业";
                          r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";


                          dt.Rows.Add(r);
                      }
                  }

                  if (dtbh.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtbh.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                          r["itemType"] = "百湖工程";
                          r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                          dt.Rows.Add(r);
                      }
                  }
          
              
              } break;
              case 1: {
                  if (dtst.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtst.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"] == null ? "--" : dtst.Rows[i]["PROJECTNUMBER"];

                          r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                          r["itemType"] = "重大项目";
                          r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                          r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";

                          r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              case 2: {
                  if (dtjg.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtjg.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                          r["itemType"] = "景观农业";
                          r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";


                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              case 3: {
                  if (dtbh.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtbh.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                          r["itemType"] = "百湖工程";
                          r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              default:
                  {
                      if (dtst.Rows.Count > 0)
                      {
                          for (int i = 0; i < dtst.Rows.Count; i++)
                          {
                              DataRow r = dt.NewRow();
                              r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"] == null ? "--" : dtst.Rows[i]["PROJECTNUMBER"];

                              r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                              r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                              r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                              r["itemType"] = "重大项目";
                              r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                              r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";

                              r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                              dt.Rows.Add(r);
                          }
                      }
                      if (dtjg.Rows.Count > 0)
                      {
                          for (int i = 0; i < dtjg.Rows.Count; i++)
                          {
                              DataRow r = dt.NewRow();
                              r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                              r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                              r["submitTime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString());
                              r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                              r["itemType"] = "景观农业";
                              r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                              r["month"] = "--";
                              r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";


                              dt.Rows.Add(r);
                          }
                      }

                      if (dtbh.Rows.Count > 0)
                      {
                          for (int i = 0; i < dtbh.Rows.Count; i++)
                          {
                              DataRow r = dt.NewRow();
                              r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                              r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                              r["submitTime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString());
                              r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                              r["itemType"] = "百湖工程";
                              r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                              r["month"] = "--";
                              r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                              dt.Rows.Add(r);
                          }
                      }
          
                  
                  } break;
          }
          //if (dtst.Rows.Count > 0)
          //{
          //    for (int i = 0; i < dtst.Rows.Count; i++)
          //    {
          //        DataRow r = dt.NewRow();
          //        r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"] == null ? "--" : dtst.Rows[i]["PROJECTNUMBER"];
                  
          //        r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
          //        r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
          //        r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

          //        r["itemType"] = "生态旅游重大项目";
          //        r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
          //        r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                  
          //        r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";
                  
          //        dt.Rows.Add(r);
          //    }
          //}
          //if (dtjg.Rows.Count > 0)
          //{
          //    for (int i = 0; i < dtjg.Rows.Count; i++)
          //    {
          //        DataRow r = dt.NewRow();
          //        r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
          //        r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
          //        r["submitTime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString());
          //        r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

          //        r["itemType"] = "景观农业";
          //        r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>报告管理</a>";
          //        r["month"] = "--";
          //        r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";
                  

          //        dt.Rows.Add(r);
          //    }
          //}

          //if (dtbh.Rows.Count > 0)
          //{
          //    for (int i = 0; i < dtbh.Rows.Count; i++)
          //    {
          //        DataRow r = dt.NewRow();
          //        r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
          //        r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
          //        r["submitTime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString());
          //        r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";
                 
          //        r["itemType"] = "百湖工程";
          //        r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>报告管理</a>";
          //        r["month"] = "--";
          //        r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

          //        dt.Rows.Add(r);
          //    }
          //}
          
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;
          
          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize*(pager.CurrentPageIndex-1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();
                  r["itemNumber"] = dt.Rows[i]["itemNumber"];
                  r["itemName"] = dt.Rows[i]["itemName"];
                  r["submitTime"] = dt.Rows[i]["submitTime"];
                  r["loginusername"] = dt.Rows[i]["loginusername"];

                  r["itemType"] = dt.Rows[i]["itemType"];
                  r["season"] = dt.Rows[i]["season"];
                  r["month"] = dt.Rows[i]["month"];
                  r["itemid"] = dt.Rows[i]["itemid"];
                 

                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;
          
          gv.DataBind();

      }



      #endregion



      /// 二级审核员查看报表列表
      /// 
      /// @author LPM
      /// 2012-12-9-15:58
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="loginName"></param>
      /// <param name="whereStr"></param>
      public void admin2ReportBindItem(GridView gv, AspNetPager pager, string whereStr)
      {

          DataTable dt = new DataTable();
          CommentDal comment = new CommentDal();  //申明报告类
          StringUtills utils = new StringUtills();


          dt.Columns.Add("projectName", typeof(string)); //项目名称
          dt.Columns.Add("zone", typeof(string));//所属地区
          dt.Columns.Add("owner", typeof(string)); //业主
          dt.Columns.Add("reportTime", typeof(string)); //报送时间，如：2010年12月份报告
          dt.Columns.Add("audit", typeof(string));  //是否通过审核，如未则可以点击
          dt.Columns.Add("comment", typeof(string));//是否点评，如已经点评则可以点击
          dt.Columns.Add("modify", typeof(string)); //修改
          dt.Columns.Add("projectType", typeof(string)); //项目类型
          
          dt.Columns.Add("reportType", typeof(string)); //报告类型
          dt.Columns.Add("ID", typeof(string)); //报告标号


          DataTable dt1 = new DataTable();
          dt1.Columns.Add("projectName", typeof(string)); //项目名称
          dt1.Columns.Add("zone", typeof(string));//所属地区
          dt1.Columns.Add("owner", typeof(string)); //业主
          dt1.Columns.Add("reportTime", typeof(string)); //报送时间，如：2010年12月份报告
          dt1.Columns.Add("audit", typeof(string));  //是否通过审核，如未则可以点击
          dt1.Columns.Add("comment", typeof(string));//是否点评，如已经点评则可以点击
          dt1.Columns.Add("modify", typeof(string)); //修改
          dt1.Columns.Add("projectType", typeof(string)); //项目类型
         
          dt1.Columns.Add("reportType", typeof(string)); //报告类型
          dt1.Columns.Add("ID", typeof(string)); //报告标号
          

          DataBase db = new DataBase();
          DataTable dtst_month = new DataTable();
          DataTable dtst_season = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          DataTable dtzb = new DataTable();
          DataTable dtts = new DataTable();
          DataTable dtxc = new DataTable();

        


          string sqlst_month = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME  FROM t_itemst as b,t_user,t_itemst_month as a  WHERE t_user.LOGINNAME=b.LOGINNAME and a.PROJECTID=b.ID AND b.SUBMITSTATE='1' AND b.AUDIT=1 " + whereStr;
          dtst_month = db.GetDataTable(sqlst_month);
          //string sqlst_season = "select a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME from t_itemst_season a left join t_itemst b on a.PROJECTID = b.ID " + whereStr;
          //dtst_season = db.GetDataTable(sqlst_season);
          string sqljg = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME FROM t_itemjg as b,t_user,t_itemjg_season as a WHERE  t_user.LOGINNAME=b.LOGINNAME and a.PROJECTID =b.ID AND b.SUBMITSTATE='1'  AND  b.AUDIT=1 " + whereStr;
          dtjg = db.GetDataTable(sqljg);
          string sqlbh = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME FROM t_itembh as b,t_user,t_itembh_season as a WHERE  t_user.LOGINNAME=b.LOGINNAME  and a.PROJECTID =b.ID AND b.SUBMITSTATE='1'  AND  b.AUDIT=1 " + whereStr;
          dtbh = db.GetDataTable(sqlbh);
          


          if (dtst_month.Rows.Count > 0)
          {
              for (int i = 0; i < dtst_month.Rows.Count; i++)
              {   //
                  DataRow r = dt.NewRow();
                  r["projectName"] = "<a href='./view/itemst_view_project.aspx?id=" + dtst_month.Rows[i]["PROJECTID"] + "'>" + dtst_month.Rows[i]["PROJECTNAME"] + "</a>";                   //项目名称
                  r["zone"] = dtst_month.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtst_month.Rows[i]["LOGINNAME"] + "'>" + dtst_month.Rows[i]["LOGINNAME"] + "</a>";//业主

                  r["reportTime"] = utils.getMonth(dtst_month.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtst_month.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "点击审核通过";           //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtst_month.Rows[i]["ID"].ToString().Trim());
                  int reportType = 1;
                  r["comment"] = comment.isReply(reportID, reportType) ? "<a href='viewComment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>回复</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>领导批示</a>";          //是否点评，如已经点评则可以点击
                  if (!comment.isShow(reportID, reportType))
                  {
                      r["comment"] = "领导未批示";
                  }
                  r["modify"] = "<a href='itemst_month_update.aspx?projectID=" + dtst_month.Rows[i]["PROJECTID"] + "&id=" + dtst_month.Rows[i]["ID"] + "&back=1'>点击修改</a>";          //修改

                  r["projectType"] = "重大项目月报";//项目类型
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号

                  dt.Rows.Add(r);
              }
          }

         


          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["projectName"] = "<a href='./view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["PROJECTID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称
                  r["zone"] = dtjg.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["LOGINNAME"] + "'>" + dtjg.Rows[i]["LOGINNAME"] + "</a>";//业主
                  r["reportTime"] = utils.getSeason(dtjg.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtjg.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "点击审核通过";           //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtjg.Rows[i]["ID"].ToString().Trim());
                  int reportType = 3;
                  r["comment"] = comment.isReply(reportID, reportType) ? "<a href='viewComment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>需回复</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>领导批示</a>";          //是否点评，如已经点评则可以点击
                  if (!comment.isShow(reportID, reportType))
                  {
                      r["comment"] = "领导未批示";
                  }
                  r["modify"] = "<a href='itemjg_season_update.aspx?projectID=" + dtjg.Rows[i]["PROJECTID"] + "&id=" + dtjg.Rows[i]["ID"] + "&back=1'>点击修改</a>";          //修改
                  r["projectType"] = "景观农业季度报";//项目类型
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号
                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["projectName"] = "<a href='./view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["PROJECTID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称
                  r["zone"] = dtbh.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["LOGINNAME"] + "'>" + dtbh.Rows[i]["LOGINNAME"] + "</a>";//业主
                  r["reportTime"] = utils.getSeason(dtbh.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtbh.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "点击审核通过";          //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtbh.Rows[i]["ID"].ToString().Trim());
                  int reportType = 4;
                  r["comment"] = comment.isReply(reportID, reportType) ? "<a href='viewComment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>需回复</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>领导批示</a>";          //是否点评，如已经点评则可以点击
                  if (!comment.isShow(reportID, reportType))
                  {
                      r["comment"] = "领导未批示";
                  }
                  r["modify"] = "<a href='itembh_season_update.aspx?projectID=" + dtbh.Rows[i]["PROJECTID"] + "&id=" + dtbh.Rows[i]["ID"] + "&back=1'>点击修改</a>";          //修改
                  r["projectType"] = "百湖工程月报";//9
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号
                  dt.Rows.Add(r);
              }
          }
          


          ///////////分页//////////
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();
                  r["projectName"] = dt.Rows[i]["projectName"];
                  r["zone"] = dt.Rows[i]["zone"];
                  r["owner"] = dt.Rows[i]["owner"];

                  r["reportTime"] = dt.Rows[i]["reportTime"];
                  r["audit"] = dt.Rows[i]["audit"];
                  r["comment"] = dt.Rows[i]["comment"];
                  r["modify"] = dt.Rows[i]["modify"];
                  r["projectType"] = dt.Rows[i]["projectType"];
                  r["reportType"] = dt.Rows[i]["reportType"]; ;//项目类型
                  r["ID"] = dt.Rows[i]["ID"]; ;//报告编号
                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;

          gv.DataBind();

      }

      /// <summary>
      /// 领导进入查看季度月报并 点评相关报告---------
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="whereStr"></param>
      public void leaderReportBindItem(GridView gv, AspNetPager pager, string whereStr)
      {

          DataTable dt = new DataTable();
          CommentDal comment = new CommentDal();  //申明报告类
          StringUtills utils = new StringUtills();


          dt.Columns.Add("projectName", typeof(string)); //项目名称
          dt.Columns.Add("zone", typeof(string));//所属地区
          dt.Columns.Add("owner", typeof(string)); //业主
          dt.Columns.Add("reportTime", typeof(string)); //报送时间，如：2010年12月份报告
          dt.Columns.Add("audit", typeof(string));  //是否通过审核，如未则可以点击
          dt.Columns.Add("comment", typeof(string));//是否点评，如已经点评则可以点击
          dt.Columns.Add("modify", typeof(string)); //修改
          dt.Columns.Add("projectType", typeof(string)); //项目类型

          dt.Columns.Add("reportType", typeof(string)); //报告类型
          dt.Columns.Add("ID", typeof(string)); //报告标号

          dt.Columns.Add("projectNum",typeof(string));//项目编号


          DataTable dt1 = new DataTable();
          dt1.Columns.Add("projectName", typeof(string)); //项目名称
          dt1.Columns.Add("zone", typeof(string));//所属地区
          dt1.Columns.Add("owner", typeof(string)); //业主
          dt1.Columns.Add("reportTime", typeof(string)); //报送时间，如：2010年12月份报告
          dt1.Columns.Add("audit", typeof(string));  //是否通过审核，如未则可以点击
          dt1.Columns.Add("comment", typeof(string));//是否点评，如已经点评则可以点击
          dt1.Columns.Add("modify", typeof(string)); //修改
          dt1.Columns.Add("projectType", typeof(string)); //项目类型

          dt1.Columns.Add("reportType", typeof(string)); //报告类型
          dt1.Columns.Add("ID", typeof(string)); //报告标号
          dt1.Columns.Add("projectNum", typeof(string));//项目编号

          DataBase db = new DataBase();
          DataTable dtst_month = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();


          string sqlst_month = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME,b.PROJECTNUMBER  FROM t_itemst as b,t_user,t_itemst_month as a  WHERE t_user.LOGINNAME=b.LOGINNAME and a.PROJECTID=b.ID AND b.SUBMITSTATE='1' AND b.AUDIT=1 " + whereStr;
          dtst_month = db.GetDataTable(sqlst_month);
          string sqljg = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME,b.PROJECTNUMBER FROM t_itemjg as b,t_user,t_itemjg_season as a WHERE  t_user.LOGINNAME=b.LOGINNAME and a.PROJECTID =b.ID AND b.SUBMITSTATE='1'  AND  b.AUDIT=1 " + whereStr;
          dtjg = db.GetDataTable(sqljg);
          string sqlbh = "SELECT a.*,b.ADDRESS,b.PROJECTNAME,b.LOGINNAME,b.PROJECTNUMBER FROM t_itembh as b,t_user,t_itembh_season as a WHERE  t_user.LOGINNAME=b.LOGINNAME  and a.PROJECTID =b.ID AND b.SUBMITSTATE='1'  AND  b.AUDIT=1 " + whereStr;
          dtbh = db.GetDataTable(sqlbh);
          

          if (dtst_month.Rows.Count > 0)
          {
              for (int i = 0; i < dtst_month.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  string proDetail = "view/itemst_view_project.aspx?id=" + dtst_month.Rows[i]["PROJECTID"];

                  r["projectName"] = "<a href='#' onclick='openwin(\"" + proDetail + "\")'>" + dtst_month.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称
                  r["zone"] = dtst_month.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtst_month.Rows[i]["LOGINNAME"] + "'>" + dtst_month.Rows[i]["LOGINNAME"] + "</a>";//业主


                  r["reportTime"] = utils.getMonth(dtst_month.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtst_month.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "未通过";           //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtst_month.Rows[i]["ID"].ToString());
                  int reportType = 1;
                  r["comment"] = comment.isComment(reportID, reportType) ? "<a href='comment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>点击评论</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>查看详情</a>";          //是否点评，如已经点评则可以点击
                  r["modify"] = "<a href='itemst_month_update.aspx?id=" + dtst_month.Rows[i]["ID"] + "'>点击修改</a>";          //修改

                  r["projectType"] = "重大项目月报";//项目类型
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号
                  r["projectNum"] = dtst_month.Rows[i]["PROJECTNUMBER"];//项目编号

                  dt.Rows.Add(r);
              }
          }

       

          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  String proDetail = "view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["PROJECTID"];
                  r["projectName"] = "<a href='#' onclick='openwin(\"" + proDetail + "\")'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称
                  r["zone"] = dtjg.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["LOGINNAME"] + "'>" + dtjg.Rows[i]["LOGINNAME"] + "</a>";//业主
                  r["reportTime"] = utils.getSeason(dtjg.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtjg.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "点击通过";           //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtjg.Rows[i]["ID"].ToString());
                  int reportType = 3;
                  r["comment"] = comment.isComment(reportID, reportType) ? "<a href='comment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>点击评论</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>查看详情</a>";          //是否点评，如已经点评则可以点击
                  r["modify"] = "<a href='itemjg_season_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";          //修改
                  r["projectType"] = "景观农业季度报";//项目类型
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号
                  r["projectNum"] = dtjg.Rows[i]["PROJECTNUMBER"];//项目编号
                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  String proDetail = "view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["PROJECTID"] ;
                  r["projectName"] = "<a href='#' onclick='openwin(\"" + proDetail + "\")'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称
                  r["zone"] = dtbh.Rows[i]["ADDRESS"];          //所属地区
                  r["owner"] = "<a href='./view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["LOGINNAME"] + "'>" + dtbh.Rows[i]["LOGINNAME"] + "</a>";//业主
                  r["reportTime"] = utils.getSeason(dtbh.Rows[i]["REPORTTIME"].ToString());          //报送时间，如：2010年12月份报告
                  r["audit"] = dtbh.Rows[i]["AUDIT"].ToString() == "1" ? "已通过" : "点击通过";          //是否通过审核，如未则可以点击

                  int reportID = int.Parse(dtbh.Rows[i]["ID"].ToString());
                  int reportType = 4;
                  r["comment"] = comment.isComment(reportID, reportType) ? "<a href='comment.aspx?reportType=" + reportType + "&reportID=" + reportID + "'>点击评论</a>" : "<a href='view_opinion.aspx?itemType=" + reportType + "&itemID=" + reportID + "'>查看详情</a>";          //是否点评，如已经点评则可以点击
                  r["modify"] = "<a href='itembh_season_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";          //修改
                  r["projectType"] = "百湖工程月报";//9
                  r["reportType"] = reportType;//项目类型
                  r["ID"] = reportID;//报告编号
                  r["projectNum"] = dtbh.Rows[i]["PROJECTNUMBER"];//项目编号
                  dt.Rows.Add(r);
              }
          }
         

          ///////////分页//////////
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();
                  r["projectName"] = dt.Rows[i]["projectName"];
                  r["zone"] = dt.Rows[i]["zone"];
                  r["owner"] = dt.Rows[i]["owner"];
                  r["reportTime"] = dt.Rows[i]["reportTime"];
                  r["audit"] = dt.Rows[i]["audit"];
                  r["comment"] = dt.Rows[i]["comment"];
                  r["modify"] = dt.Rows[i]["modify"];
                  r["projectType"] = dt.Rows[i]["projectType"];

                  r["reportType"] = dt.Rows[i]["reportType"];//项目类型
                  r["ID"] = dt.Rows[i]["ID"] ;//报告编号
                  r["projectNum"] = dt.Rows[i]["projectNum"];//项目编号
                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;

          gv.DataBind();
      
      }


      /// <summary>
      /// 领导查看项目！！
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="whereStr"></param>
      public void leaderBindItem(GridView gv, AspNetPager pager, string whereStr)
      {
          StringUtills utils = new StringUtills();
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("submit", typeof(string));
          dt.Columns.Add("pass", typeof(string));//TODO lpm
          dt.Columns.Add("projectid", typeof(string));

          DataTable dt1 = new DataTable();
          dt1.Columns.Add("itemNumber", typeof(string));
          dt1.Columns.Add("itemName", typeof(string));
          dt1.Columns.Add("submitTime", typeof(string));
          dt1.Columns.Add("itemType", typeof(string));
          dt1.Columns.Add("season", typeof(string));
          dt1.Columns.Add("month", typeof(string));
          dt1.Columns.Add("itemid", typeof(string));
          dt1.Columns.Add("submit", typeof(string));
          dt1.Columns.Add("pass", typeof(string));//TODO lpm
          dt1.Columns.Add("projectid", typeof(string));


          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          //DataTable dtzb = new DataTable();
          //DataTable dtts = new DataTable();
          //DataTable dtxc = new DataTable();

          string sqlst = "SELECT * FROM t_itemst " + whereStr;
          dtst = db.GetDataTable(sqlst);
          string sqljg = "SELECT * FROM t_itemjg " + whereStr;
          dtjg = db.GetDataTable(sqljg);
          string sqlbh = "SELECT * FROM t_itembh " + whereStr;
          dtbh = db.GetDataTable(sqlbh);
         


          if (dtst.Rows.Count > 0)
          {
              for (int i = 0; i < dtst.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];

                  r["itemName"] = "<a href='./view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称 

                  r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                  r["itemType"] = "重大项目";
                  r["season"] = "<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                  r["itemid"] = "<a href='./view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>查看</a>";

                  r["pass"] = dtst.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtst.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtst.Rows[i]["ID"];

                  dt.Rows.Add(r);
              }
          }
          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='./view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称 
                  r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                  r["itemType"] = "景观农业";
                  r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='./view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>查看</a>";

                  r["pass"] = dtjg.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtjg.Rows[i]["ID"];
                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='./view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";  //项目名称 
                  r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                  r["itemType"] = "百湖工程";
                  r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='./view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>查看</a>";

                  r["pass"] = dtbh.Rows[i]["AUDIT"].ToString().Trim() == "1" ? "通过" : "未通过";
                  r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString().Trim() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtbh.Rows[i]["ID"];
                  dt.Rows.Add(r);
              }
          }
        

          ///////////分页//////////
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();
                  r["itemNumber"] = dt.Rows[i]["itemNumber"];
                  r["itemName"] = dt.Rows[i]["itemName"];
                  r["submitTime"] = dt.Rows[i]["submitTime"];
                  r["itemType"] = dt.Rows[i]["itemType"];
                  r["season"] = dt.Rows[i]["season"];
                  r["month"] = dt.Rows[i]["month"];
                  r["itemid"] = dt.Rows[i]["itemid"];

                  r["pass"] = dt.Rows[i]["pass"];
                  r["submit"] = dt.Rows[i]["submit"];
                  r["projectid"] = dt.Rows[i]["projectid"];
                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;
          gv.DataBind();
          

      }

      /// <summary>
      /// 查询
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="loginName"></param>
      /// <param name="whereStr"></param>
      public void userBindItem(GridView gv, string loginName,string whereStr)
      {
          

      }

      /// <summary>
      /// 业主修改查询
      /// </summary>
      /// <param name="type"></param>
      /// <param name="id"></param>
      /// <returns></returns>
      public DataTable selectByID(int type, int id)
      {
          DataTable dt = new DataTable();
          switch (type)
          {
              case 1://生态旅游重大项目
                  {
                      //PROJECTNAME,ADDRESS,PROGRESSCATEGORY,CONSTRUCTIONTYPE,CONSTRUCTIONAGE,CONTENTSCALE,GOVERNMENTPROJE,PROJECTNATURE,TOTLEMONEY,CENTRALMONEY,PROVINCIALMONEY,MUNICIPALMONEY,DISTRICTMONEY,BANKLOAN,USEPROGRESS,COMPANYSELF,PLANLANDTARGETS,GETLANDTARGETS,USELANDTARGETS,ACTUALUSELAND,LANDWAY,PREDICTSTARTTIME,PREDICTFINISHTIME,PROGRESSNOW,PROBLEMS,LOGINNAME
                      string sql = "SELECT * FROM t_itemst, t_user WHERE t_itemst.ID =@ID and t_itemst.LOGINNAME=t_user.LOGINNAME";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  } break;
              case 2:// 景观农业
                  {
                      //LOGINNAME,PROJECTNAME,ADDRESS,CONTENTSCALE,PLANTOTALMONEY,XYEARPLAN,ENDYEAR,PREYEARPLAN,XMONFIN,PROGRESSNOW,STARTENDTIME
                      string sql = "SELECT t.*,u.area FROM t_itemjg t,t_user u WHERE t.ID=@ID and t.LOGINNAME=u.LOGINNAME";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  
                  } break;
              case 3:// 百湖工程
                  {
                      //LOGINNAME,PROJECTNAME,ADDRESS,FINISHTIME,PROGRESSCATEGORY,ZONEAREA,PROVINCIALEVELFISCAL,MUNICIPALFINANCE,COUNTYFINANCE,FINANCEFINANCE,SOCIALINVESTMENT,PUBLICINVESTMENT,OTHER,OCCUPIEDAREA,OCCUPIEDTYPE,UNITPRICE,IMAGEPROGRESS,MANAGESUBJECT 
                      string sql = "SELECT t.*,u.area FROM t_itembh t,t_user u WHERE t.ID=@ID and t.LOGINNAME=u.LOGINNAME";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  
                  } break;
              case 4://植被恢复
                  {
                      //ADDRESS,PROJECTNAME,ZONEAREA,MAINTREESPECIES,FORESTLANDSCAPE,MANAGESUBJECT,TRIPELEMENT,LOGINNAME
                      string sql = "SELECT * FROM t_itemzb, t_user WHERE t_itemzb.ID =2 and t_itemzb.LOGINNAME=t_user.LOGINNAME";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  
                  } break;
              case 5://特色
                  {
                      //ADDRESS,PROJECTNAME,BASICSITUATION,PROJECTPLAN,TRIPELEMENT,DEVELOPCHARAC,GAP,LOGINNAME
                      string sql = "SELECT * FROM t_itemts WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  
                  } break;
              case 6:
                  {
                      //LOGINNAME,ADDRESS,PROJECTNAME,BASICSITUATION,PROJECTPLAN,TRIPELEMENT,DEVELOPCHARAC,GAP
                      string sql = "SELECT * FROM t_itemxc WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[1];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = id;
                      DataBase db = new DataBase();
                      dt = db.GetDataTable(sql, param);
                  
                  } break;
              default: break;
          }


          return dt;
      }



      /// <summary>
      /// 添加修改日志
      /// </summary>
      /// <param name="type"></param>
      /// <param name="loginName"></param>
      /// <param name="id"></param>
      /// <returns></returns>
      public bool updatenote(int type, string loginName,int id)
      {
          bool re = false;
          switch (type)
          {
              case 1:
                  {
                      String sql = "INSERT INTO(PROJECTNUMBER,PROJECTNAME,PROJECTAREA,PROJECTADDRESS,PROGRESSCATEGORY,CONSTRUCTIONTYPE,CONSTRUCTIONAGE,CONTENTSCALE,GOVERNMENTPROJE,PROJECTNATURE,TOTLEMONEY,CENTRALMONEY,PROVINCIALMONEY,MUNICIPALMONEY,DISTRICTMONEY,BANKLOAN,USEPROGRESS,COMPANYSELF,PLANLANDTARGETS,GETLANDTARGETS,USELANDTARGETS,ACTUALUSELAND,LANDWAY,PREDICTSTARTTIME,PREDICTFINISHTIME,STARTTIME,FINISHTIME,PROGRESSNOW,PROBLEMS,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5,REMARK )(SELECT PROJECTNUMBER,PROJECTNAME,PROJECTAREA,PROJECTADDRESS,PROGRESSCATEGORY,CONSTRUCTIONTYPE,CONSTRUCTIONAGE,CONTENTSCALE,GOVERNMENTPROJE,PROJECTNATURE,TOTLEMONEY,CENTRALMONEY,PROVINCIALMONEY,MUNICIPALMONEY,DISTRICTMONEY,BANKLOAN,USEPROGRESS,COMPANYSELF,PLANLANDTARGETS,GETLANDTARGETS,USELANDTARGETS,ACTUALUSELAND,LANDWAY,PREDICTSTARTTIME,PREDICTFINISHTIME,STARTTIME,FINISHTIME,PROGRESSNOW,PROBLEMS,LOGINNAME FROM t_itemst WHERE ID=@ID)";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param)==1)
                      {
                          re = true;
                      }
                  } break;
              case 2:
                  {
                      String sql = "INSERT INTO t_itemjg_note (PROJECTNUMBER,MODIFICATIONTIME,MODIFYPERSON,PROJECTCOUNTIES,PROJECTNAME,PROJECTADDRESS,PROJECTOWNERS,CONTENTSCALE,,PLANTOTALMONEY,STARTADDRESS,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) SELECT FROM";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  
                  } break;
              case 3:
                  {
                      String sql = "INSERT INTO t_itembh_note(PROJECTNUMBER,MODIFYTIME,MODIFYPERSON,PROJECTCOUNTIES,PROJECTNAME,PROJECTADDRESS,FINISHTIME,WATERAREA,PROVINCIALEVELFISCAL,MUNICIPALFINANCE,COUNTYFINANCE,FINANCEFINANCE,SOCIALINVESTMENT,PUBLICINVESTMENT,OTHER,OCCUPIEDAREA,OCCUPIEDTYPE,UNITPRICE,IMAGEPROGRESS,MANAGESUBJECT,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) SELECT FROM t_itembh";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  
                  } break;
              case 4: 
                  {
                      String sql = "INSERT INTO t_itemzb_note (MODIFYTIME,MODIFYPERSON,AREA,NAME,BASICSITUATION,PLAN,TRIPELEMENT,DEVELOPCHARAC,GAP,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) select";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  
                  } break;
              case 5:
                  {
                      String sql = "INSERT INTO t_itemts_note (MODIFYTIME,MODIFYPERSON,AREA,NAME,BASICSITUATION,PLAN,TRIPELEMENT,DEVELOPCHARAC,GAP,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5)select ";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 6:
                  {
                      String sql = "INSERT INTO t_itemxc_note (PROJECTNUMBER,MODIFYPERSON,TIME,ADDRESS,NAME,BASICSITUATION,PLAN,TRIPELEMENT,DEVELOPCHARAC,GAP,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5) select";
                      SqlParameter[] param = new SqlParameter[2];
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              default: break;
          }
          return re;
      }





      #region  一级审核员处理报告


      /// <summary>
      /// 一级审核员绑定
      /// 新建项目审批
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="loginName"></param>
      public void admin1BindItem(GridView gv, AspNetPager pager, string loginName)
      {
          StringUtills utils = new StringUtills();
               
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("submit", typeof(string));
          dt.Columns.Add("pass", typeof(string));//TODO lpm
          dt.Columns.Add("projectid", typeof(string));
          dt.Columns.Add("loginusername", typeof(string));
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
          param[0].Value = loginName;
          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
         
          string sqlst = "select t.*,u.USERNAME from t_itemst t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=0 ";
          dtst = db.GetDataTable(sqlst, param);
          string sqljg = "select t.*,u.USERNAME from t_itemjg t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=0 ";
          dtjg = db.GetDataTable(sqljg, param);
          string sqlbh = "select t.*,u.USERNAME from t_itembh t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=0 ";
          dtbh = db.GetDataTable(sqlbh, param);
        
          if (dtst.Rows.Count > 0)
          {
              for (int i = 0; i < dtst.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["LOGINNAME"] + "'>" + dtst.Rows[i]["username"] + "</a>";

               
                  r["itemType"] = "重大项目";
                  r["season"] = "<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                  r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                  r["submit"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "点击通过" : "已通过";
                  r["projectid"] = dtst.Rows[i]["ID"].ToString();
                 
                  dt.Rows.Add(r);
              }
          }
          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["LOGINNAME"] + "'>" + dtjg.Rows[i]["username"] + "</a>";
                  
                  r["itemType"] = "景观农业";
                  r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtjg.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                  r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtjg.Rows[i]["ID"];
                
                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["LOGINNAME"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                  r["itemType"] = "百湖工程";
                  r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                  r["pass"] = dtbh.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                  r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                  r["projectid"] = dtbh.Rows[i]["ID"];
                  
                  dt.Rows.Add(r);
              }
          }
         
          gv.DataSource = dt;
          gv.DataBind();
      }


      /// <summary>
      /// 一级审核员绑定
      /// 项目季度月度审批
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="loginName"></param>itemtype 0所有项目 1生态旅游重大项目 2.景观农业3.百湖工程
      public void admin1BindItem2(GridView gv, AspNetPager pager, string loginName,int itemtype)
      {
          StringUtills utils = new StringUtills();
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("submit", typeof(string));
          dt.Columns.Add("pass", typeof(string));//TODO lpm
          dt.Columns.Add("projectid", typeof(string));
          dt.Columns.Add("loginusername", typeof(string));

          DataTable dt1 = new DataTable();
          dt1.Columns.Add("itemNumber", typeof(string));
          dt1.Columns.Add("itemName", typeof(string));
          dt1.Columns.Add("submitTime", typeof(string));
          dt1.Columns.Add("itemType", typeof(string));
          dt1.Columns.Add("season", typeof(string));
          dt1.Columns.Add("month", typeof(string));
          dt1.Columns.Add("itemid", typeof(string));
          dt1.Columns.Add("submit", typeof(string));
          dt1.Columns.Add("pass", typeof(string));//TODO lpm
          dt1.Columns.Add("projectid", typeof(string));
          dt1.Columns.Add("loginusername", typeof(string));


          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
          param[0].Value = loginName;
          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          DataTable dtzb = new DataTable();
          DataTable dtts = new DataTable();
          DataTable dtxc = new DataTable();

          string sqlst = "select t.*,u.USERNAME from t_itemst t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=1 ";
          dtst = db.GetDataTable(sqlst, param);
          string sqljg = "select t.*,u.USERNAME from t_itemjg t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=1 ";
          dtjg = db.GetDataTable(sqljg, param);
          string sqlbh = "select t.*,u.USERNAME from t_itembh t,t_user u where u.LOGINNAME=t.LOGINNAME and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  AND SUBMITSTATE='1' AND AUDIT=1 ";
          dtbh = db.GetDataTable(sqlbh, param);

          switch (itemtype)
          {
              case 0: {
                  if (dtst.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtst.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                          r["itemType"] = "重大项目";
                          r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                          r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                          r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "点击通过" : "已通过";
                          r["projectid"] = dtst.Rows[i]["ID"].ToString();
                          dt.Rows.Add(r);
                      }
                  }
                  if (dtjg.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtjg.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                          r["itemType"] = "景观农业";
                          r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtjg.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtjg.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }

                  if (dtbh.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtbh.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                          r["itemType"] = "百湖工程";
                          r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtbh.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtbh.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }
          
              
              } break;
              case 1: {

                  if (dtst.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtst.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                          r["itemType"] = "重大项目";
                          r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                          r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                          r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "点击通过" : "已通过";
                          r["projectid"] = dtst.Rows[i]["ID"].ToString();
                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              case 2: {
                  if (dtjg.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtjg.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                          r["itemType"] = "景观农业";
                          r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtjg.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtjg.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              case 3: {

                  if (dtbh.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtbh.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                          r["itemType"] = "百湖工程";
                          r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtbh.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtbh.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }
              
              } break;
              default: {
                  if (dtst.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtst.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                          r["itemType"] = "重大项目";
                          r["season"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>历史报告管理</a>";//"<a href='itemst_season_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                          r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                          r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtst.Rows[i]["AUDIT"].ToString() == "0" ? "点击通过" : "已通过";
                          r["projectid"] = dtst.Rows[i]["ID"].ToString();
                          dt.Rows.Add(r);
                      }
                  }
                  if (dtjg.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtjg.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                          r["itemType"] = "景观农业";
                          r["season"] = "<a href='itemjg_season_manage.aspx?projectID=" + dtjg.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtjg.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtjg.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtjg.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }

                  if (dtbh.Rows.Count > 0)
                  {
                      for (int i = 0; i < dtbh.Rows.Count; i++)
                      {
                          DataRow r = dt.NewRow();
                          r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                          r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                          r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                          r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                          r["itemType"] = "百湖工程";
                          r["season"] = "<a href='itembh_season_manage.aspx?projectID=" + dtbh.Rows[i]["ID"] + "'>历史报告管理</a>";
                          r["month"] = "--";
                          r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";

                          r["pass"] = dtbh.Rows[i]["AUDIT"].ToString() == "0" ? "已通过" : "点击通过";
                          r["submit"] = dtbh.Rows[i]["SUBMITSTATE"].ToString() == "1" ? "提交成功" : "点击提交";
                          r["projectid"] = dtbh.Rows[i]["ID"];
                          dt.Rows.Add(r);
                      }
                  }
          
              
              
              } break;
          }
          
         


          ///////////分页//////////
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();

                  r["itemNumber"] = dt.Rows[i]["itemNumber"];
                  r["itemName"] = dt.Rows[i]["itemName"];
                  r["submitTime"] = dt.Rows[i]["submitTime"];
                  r["itemType"] = dt.Rows[i]["itemType"];
                  r["season"] = dt.Rows[i]["season"];

                  r["month"] = dt.Rows[i]["month"];
                  r["itemid"] = dt.Rows[i]["itemid"];
                  r["submit"] = dt.Rows[i]["submit"];
                  r["pass"] = dt.Rows[i]["pass"];
                  r["projectid"] = dt.Rows[i]["projectid"];
                  r["loginusername"] = dt.Rows[i]["loginusername"]; 
                 
                  dt1.Rows.Add(r);
              }
          }

          gv.DataSource = dt1;
          gv.DataBind();
      }


      /// <summary>
      /// 一级审核提交申报=========================
      /// </summary>
      /// <param name="type"></param>
      /// <param name="item"></param>
      /// <returns></returns>
      public bool adminsubmit(int type, int itemid,string state)
      {
          bool re = false;
          StringUtills utils = new StringUtills();

          switch (type)
          {
              case 1:
                  {

                      String sql = "UPDATE t_itemst SET AUDIT =@AUDIT, PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;
                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type,itemid);
  
                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 2:
                  {

                      String sql = "UPDATE t_itemjg SET AUDIT =@AUDIT,PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;

                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type, itemid);

                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 3:
                  {

                      String sql = "UPDATE t_itembh SET AUDIT =@AUDIT,PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;

                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type, itemid);


                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 4:
                  {

                      String sql = "UPDATE t_itemzb SET AUDIT =@AUDIT,PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;

                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type, itemid);


                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 5:
                  {

                      String sql = "UPDATE t_itemts SET AUDIT =@AUDIT, PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;

                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type, itemid);


                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;
                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }

                  } break;
              case 6:
                  {

                      String sql = "UPDATE t_itemxc SET AUDIT =@AUDIT, PROJECTNUMBER=@PROJECTNUMBER WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[3];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = itemid;
                      param[1] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar);
                      param[1].Value = utils.builtProjectNUM(type, itemid);

                      param[2] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
                      param[2].Value = state;

                      DataBase db = new DataBase();
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }



                  } break;
              default: break;
          }

          return re;
      }



      /// <summary>
      /// 一级审核员项目状态设置
      /// </summary>
      /// <param name="gv"></param>
      /// <param name="pager"></param>
      /// <param name="whereStr"></param>
      /// <param name="loginName"></param>
      public void admin1BindItem(GridView gv, AspNetPager pager, string whereStr,string loginName)
      {
          StringUtills utils = new StringUtills();
          DataTable dt = new DataTable();
          dt.Columns.Add("itemNumber", typeof(string));
          dt.Columns.Add("itemName", typeof(string));
          dt.Columns.Add("submitTime", typeof(string));
          dt.Columns.Add("itemType", typeof(string));
          dt.Columns.Add("season", typeof(string));
          dt.Columns.Add("month", typeof(string));
          dt.Columns.Add("itemid", typeof(string));
          dt.Columns.Add("loginusername", typeof(string));
          dt.Columns.Add("projectid", typeof(string));

          DataTable dt1 = new DataTable();
          dt1.Columns.Add("itemNumber", typeof(string));
          dt1.Columns.Add("itemName", typeof(string));
          dt1.Columns.Add("submitTime", typeof(string));
          dt1.Columns.Add("itemType", typeof(string));
          dt1.Columns.Add("season", typeof(string));
          dt1.Columns.Add("month", typeof(string));
          dt1.Columns.Add("itemid", typeof(string));
          dt1.Columns.Add("loginusername", typeof(string));
          dt1.Columns.Add("projectid", typeof(string));

          DataBase db = new DataBase();
          DataTable dtst = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          
          string sqlst = "SELECT t_itemst.*,t_user.username FROM t_itemst,t_user  WHERE t_user.LOGINNAME=t_itemst.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 and t_user.area in (select u.area from t_user u where u.loginName = '" + loginName + "')";
          dtst = db.GetDataTable(sqlst);
          string sqljg = "SELECT t_itemjg.*,t_user.username FROM t_itemjg,t_user   WHERE  t_user.LOGINNAME=t_itemjg.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 and t_user.area in (select u.area from t_user u where u.loginName = '" + loginName + "')";
          dtjg = db.GetDataTable(sqljg);
          string sqlbh = "SELECT t_itembh.*,t_user.username FROM t_itembh,t_user   WHERE t_user.LOGINNAME=t_itembh.LOGINNAME AND SUBMITSTATE='1' AND AUDIT=1 and t_user.area in (select u.area from t_user u where u.loginName = '" + loginName + "')";
          dtbh = db.GetDataTable(sqlbh);
        
          if (dtst.Rows.Count > 0)
          {
              for (int i = 0; i < dtst.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtst.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemst_view_project.aspx?id=" + dtst.Rows[i]["ID"] + "'>" + dtst.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtst.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtst.Rows[i]["username"] + "'>" + dtst.Rows[i]["username"] + "</a>";

                  r["itemType"] = "重大项目";
                  r["season"] = "<a href='itemst_season_manage.aspx?id=" + dtst.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "<a href='itemst_month_manage.aspx?projectID=" + dtst.Rows[i]["ID"] + "'>月报告</a>";
                  r["itemid"] = "<a href='itemst_update.aspx?id=" + dtst.Rows[i]["ID"] + "'>点击修改</a>";

                  r["projectid"]=dtst.Rows[0]["ID"];

                  dt.Rows.Add(r);
              }
          }
          if (dtjg.Rows.Count > 0)
          {
              for (int i = 0; i < dtjg.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtjg.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itemjg_view_project.aspx?id=" + dtjg.Rows[i]["ID"] + "'>" + dtjg.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtjg.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["username"] + "'>" + dtjg.Rows[i]["username"] + "</a>";

                  r["itemType"] = "景观农业";
                  r["season"] = "<a href='itemjg_season_manage.aspx?id=" + dtjg.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itemjg_update.aspx?id=" + dtjg.Rows[i]["ID"] + "'>点击修改</a>";
                  r["projectid"] = dtjg.Rows[0]["ID"];
                  dt.Rows.Add(r);
              }
          }

          if (dtbh.Rows.Count > 0)
          {
              for (int i = 0; i < dtbh.Rows.Count; i++)
              {
                  DataRow r = dt.NewRow();
                  r["itemNumber"] = dtbh.Rows[i]["PROJECTNUMBER"];
                  r["itemName"] = "<a href='view/itembh_view_project.aspx?id=" + dtbh.Rows[i]["ID"] + "'>" + dtbh.Rows[i]["PROJECTNAME"] + "</a>";
                  r["submitTime"] = utils.getMonth(dtbh.Rows[i]["SUBMITTIME"].ToString());
                  r["loginusername"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["username"] + "'>" + dtbh.Rows[i]["username"] + "</a>";

                  r["itemType"] = "百湖工程";
                  r["season"] = "<a href='itembh_season_manage.aspx?id=" + dtbh.Rows[i]["ID"] + "'>季度报告</a>";
                  r["month"] = "--";
                  r["itemid"] = "<a href='itembh_update.aspx?id=" + dtbh.Rows[i]["ID"] + "'>点击修改</a>";
                  r["projectid"] = dtbh.Rows[0]["ID"];

                  dt.Rows.Add(r);
              }
          }
       
          int dtcount = dt.Rows.Count;
          pager.RecordCount = dtcount;

          for (int i = 0; i < dtcount; i++)
          {
              if (i >= pager.PageSize * (pager.CurrentPageIndex - 1) && i <= pager.CurrentPageIndex * pager.PageSize)
              {
                  DataRow r = dt1.NewRow();
                  r["itemNumber"] = dt.Rows[i]["itemNumber"];
                  r["itemName"] = dt.Rows[i]["itemName"];
                  r["submitTime"] = dt.Rows[i]["submitTime"];
                  r["itemType"] = dt.Rows[i]["itemType"];
                  r["season"] = dt.Rows[i]["season"];
                  r["month"] = dt.Rows[i]["month"];
                  r["itemid"] = dt.Rows[i]["itemid"];
                  r["loginusername"] = dt.Rows[i]["loginusername"];
                  r["projectid"] = dt.Rows[0]["projectid"];

                  dt1.Rows.Add(r);
              }
          }
          gv.DataSource = dt1;

          gv.DataBind();

      }
      #endregion


      public bool reback(int type, int projectid,int reback,int submitstate, string reason)
      {
          DataBase db = new DataBase();
          bool re = false;
          switch (type)
          {
              case 1:
                  {
                      String sql = "update t_itemst set REBACK=@REBACK,SUBMITSTATE=@SUBMITSTATE, REASON=@REASON WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[4];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      param[1] = new SqlParameter("@REBACK", SqlDbType.VarChar,10);
                      param[1].Value = reback;
                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.VarChar,100);
                      param[2].Value = submitstate;
                      param[3] = new SqlParameter("@REASON", SqlDbType.VarChar,2000);
                      param[3].Value = reason; 

                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 2:
                  {

                      String sql = "UPDATE t_itemjg SET REBACK=@REBACK,SUBMITSTATE=@SUBMITSTATE, REASON=@REASON WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[4];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      param[1] = new SqlParameter("@REBACK", SqlDbType.VarChar, 10);
                      param[1].Value = reback;
                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.VarChar, 100);
                      param[2].Value = submitstate;
                      param[3] = new SqlParameter("@REASON", SqlDbType.VarChar, 2000);
                      param[3].Value = reason;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }
                  } break;
              case 3:
                  {
                      String sql = "UPDATE t_itembh SET REBACK=@REBACK,SUBMITSTATE=@SUBMITSTATE, REASON=@REASON WHERE ID=@ID";
                      SqlParameter[] param = new SqlParameter[4];
                      param[0] = new SqlParameter("@ID", SqlDbType.Int);
                      param[0].Value = projectid;
                      param[1] = new SqlParameter("@REBACK", SqlDbType.VarChar, 10);
                      param[1].Value = reback;
                      param[2] = new SqlParameter("@SUBMITSTATE", SqlDbType.VarChar, 100);
                      param[2].Value = submitstate;
                      param[3] = new SqlParameter("@REASON", SqlDbType.VarChar, 2000);
                      param[3].Value = reason;
                      if (db.ExecuteSql(sql, param) == 1)
                      {
                          re = true;
                      }


                  } break;
            
              default: break;


          }

          return re;
      
      }

      public DataTable viewReback(int type, int projectid,string whereStr)
      {
          String sql = "";
          switch (type)
          {
              case 1:
                  {
                      sql = "SELECT * from t_itemst WHERE ID=@ID " + whereStr;
                  } break;
              case 2:
                  {
                      sql = "SELECT * from t_itemjg WHERE ID=@ID  " + whereStr;
                  } break;
              case 3:
                  {
                      sql = "SELECT * from t_itembh WHERE ID=@ID  " + whereStr;
                  } break;

              default: break;
          }
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@ID",SqlDbType.Int);
          param[0].Value = projectid;

          return db.GetDataTable(sql,param);
      }

      /// <summary>
      /// 一级审核员设置项目为竣工状态
      /// </summary>
      /// <param name="type"></param>
      /// <param name="projectId"></param>
      /// <param name="whereStr"></param>
      /// <returns></returns>
      public bool endProject(int type, int projectId, string whereStr)
      {
          String sql = "";
          switch (type)
          {
              case 1:
                  {
                      sql = "update t_itemst set ENDSTATE=1 , SUBMITSTATE='11' , AUDIT=11 WHERE ID=@ID " + whereStr;
                  } break;
              case 2:
                  {
                      sql = "update t_itemjg set ENDSTATE=1, SUBMITSTATE='11' , AUDIT=11  WHERE ID=@ID  " + whereStr;
                  } break;
              case 3:
                  {
                      sql = "update t_itembh set ENDSTATE=1 ,SUBMITSTATE='11' , AUDIT=11  WHERE ID=@ID  " + whereStr;
                  } break;

              default: break;
          }
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@ID", SqlDbType.Int);
          param[0].Value = projectId;
          if(db.ExecuteSql(sql,param) == 1)
          {
              return true;
          }
          return false;
      }


      /// <summary>
      /// 判断是否可填项目报告（不处理是否权限足够问题）
      /// 
      /// 返回真，，，，说明本月或者本季度的报告已经填写！！！！就不能再填写！！！
      /// 
      /// 也就是说，目前的逻辑是：只有业主才能上报关于excel的进度报告
      /// 
      /// </summary>
      /// <param name="projectType"></param>
      /// <param name="projectID"></param>
      /// <param name="whereStr"></param>
      /// <returns></returns>
      public bool   isFillTime(int projectType, int projectID, string whereStr)
      {
          StringUtills utils = new StringUtills();  
          String sql = "";
          switch (projectType)
          {
              case 1:
                  {
                      sql += "select  * from t_itemst_month as a  where  a.PROJECTID=@projectID and a.REPORTTIME BETWEEN cast('" + utils.getCurrentTimeZone()[0] + "' as datetime) AND cast('" + utils.getCurrentTimeZone()[1] + "' as datetime)  order by cast(a.REPORTTIME as datetime) DESC";
                  }
                  break;
              case 2:
                  {
                      sql += "select * from t_itemjg_season as a  where  a.PROJECTID=@projectID and a.REPORTTIME BETWEEN  cast('" + utils.getSeasonZone()[0] + "' as datetime) AND cast('" + utils.getSeasonZone()[1] + "' as datetime)  order by cast(a.REPORTTIME as datetime) DESC";
                  }
                  break;
              case 3:
                  {
                      sql += "select  * from t_itembh_season as a  where  a.PROJECTID=@projectID and a.REPORTTIME BETWEEN  cast('" + utils.getSeasonZone()[0] + "' as datetime) AND cast('" + utils.getSeasonZone()[1] + "' as datetime)  order by cast(a.REPORTTIME as datetime) DESC";
                  }
                  break;
              default:
                  break;
          
          }
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@projectID", SqlDbType.Int);
          param[0].Value = projectID;

          DataTable dt = new DataTable();
          dt = db.GetDataTable(sql,param);
          

          if(dt.Rows.Count > 0)
          {
              return true;
              ////取到该项目的最后一次上报时间
              //string reportTime = dt.Rows[0]["REPORTTIME"].ToString().Trim();
              //DateTime lastTime = Convert.ToDateTime(reportTime);
              //if(projectType==1)
              //{
              //  //说明是生态月报
              //    if (utils.getMonth(DateTime.Now.ToString()) == utils.getMonth(lastTime.ToString()))
              //    {
              //        return true;
              //    }
              //}
              //if (projectType == 2 || projectType == 3)
              //{
              //    //说明是季报
              //    if (utils.getSeason(DateTime.Now.ToString()).Trim() == utils.getSeason(reportTime).Trim())
              //    {
              //        return true;
              //    }
              //}

          }
          return false;
      }

     /// <summary>
     /// =================
     /// </summary>
     /// <param name="projectType"></param>
     /// <param name="projectID"></param>
     /// <returns></returns>
      public bool isFillTime(int projectType, int projectID)
      {
          String sql = "";
          switch (projectType)
          {
              case 1:
                  {
                      sql += "select * from t_itemst_month as a where  a.PROJECTID=@projectID and MONTH(a.REPORTTIME)=MONTH(GETDATE()) order by a.REPORTTIME DESC ";
                  }
                  break;
              case 2:
                  {
                      sql += "select * from t_itemjg_season as a where  a.PROJECTID=@projectID and dbo.fun_getSeason(MONTH(a.REPORTTIME))=dbo.fun_getSeason(MONTH(GETDATE())) order by a.REPORTTIME DESC ";
                  }
                  break;
              case 3:
                  {
                      sql += "select * from t_itembh_season as a where  a.PROJECTID=@projectID and dbo.fun_getSeason(MONTH(a.REPORTTIME))=dbo.fun_getSeason(MONTH(GETDATE())) order by a.REPORTTIME DESC ";
                  }
                  break;
              default:
                  break;

          }
          DataBase db = new DataBase();
          StringUtills utils = new StringUtills();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@projectID", SqlDbType.Int);
          param[0].Value = projectID;

          DataTable dt = new DataTable();
          dt = db.GetDataTable(sql, param);


          if (dt.Rows.Count > 0)
          {
              //说明在历史数据中找到了当前月份以及季度的数据


          }
          return false;
      }



      /// <summary>
      /// 判断 给定业主下是否有项目，，如果该业主下面有项目，返回真，否则为假
      /// </summary>
      /// <param name="loginName"></param>
      /// <param name="whereStr"></param>
      /// <returns></returns>
      public int getProjectNumInUser(string loginName)
      {
          String sql = "SELECT dbo.fun_userProjectNum('"+loginName+"')";
          DataBase db = new DataBase();
          String result = db.ExecuteValue(sql);
          return int.Parse(result.Trim());
      }

      /// <summary>
      /// 判断项目名称是否存在，，如存在返回真
      /// 
      /// </summary>
      /// <param name="type"></param>
      /// <param name="projectName"></param>
      /// <returns></returns>
      public bool isExitProject(int type,String projectName)
      {
          String tableName = "";
          switch(type)
          {
              case 1:
                  { tableName = "t_itemst"; }
                  break;
              case 2:
                  { tableName = "t_itembh"; }
                  break;
              case 3:
                  { tableName = "t_itemjg"; }
                  break;
              default:
                  break;
          }
          string sql = "select count(*) from " + tableName + " where PROJECTNAME=@PROJECTNAME";
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@PROJECTNAME",SqlDbType.VarChar,500);
          param[0].Value = projectName;
          if (db.ExecuteValue(sql,param).ToString().Trim() != "0") 
          {
              return true;
          }
          return false;
      }

    }
}
