using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using Model;

using System.Web.UI.WebControls;
using Wuqi.Webdiyer;
using System.Data.SqlClient;
using DataTable = System.Data.DataTable;



namespace Dal
{
   public  class ItemReportDal
   {

       #region 月报季报添加
       /// <summary>
        /// 1、生态旅游月报 2、生态旅游季度报 
       /// 2、景观农业
       /// 3、百湖工程
       /// 4、生态植被
       /// 5、乡村旅游度假区
       /// 6、A级景区
       /// 
       /// 
       /// 添加报告时。。。初始化reporttime
       /// </summary>
       /// <param name="type"></param>
       /// <param name="en"></param>
       /// <returns></returns>
       public bool add(int type, object en)
       {
           DataBase db = new DataBase();
           bool re = false;

           switch (type)
           {
               case 1:
                   {
                       ItemstMonthReportEntity stItem = (ItemstMonthReportEntity)en;

                       String sql = "INSERT INTO t_itemst_month (PROJECTID,LOGINNAME,PROGRESSCATEGORY,PROGRESSNOW,PROBLEMS,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5,REMARK,REPORTTIME,InvestmentPosition) VALUES (@PROJECTID,@LOGINNAME,@PROGRESSCATEGORY,@PROGRESSNOW,@PROBLEMS,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5,@REMARK,@REPORTTIME,@InvestmentPosition)";
                       SqlParameter[] param = new SqlParameter[13];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 200);
                       param[0].Value = stItem.ProjectId ;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = stItem.LoginName;
                       param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[2].Value = stItem.ProgressCategory ;
                       param[3] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 3000);
                       param[3].Value = stItem.ProgressNow ;

                       param[4] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, 3000);
                       param[4].Value = stItem.Problems ; ;
                      
                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = stItem.Image1;
                      
                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = stItem.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = stItem.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = stItem.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = stItem.Image5;
                       param[10] = new SqlParameter("@REMARK", SqlDbType.VarChar, 3000);
                       param[10].Value = stItem.Remark ;
                       param[11] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar, 200);
                       param[11].Value = DateTime.Now;
                       param[12] = new SqlParameter("@InvestmentPosition", SqlDbType.Float);
                       param[12].Value = stItem.InvestmentPosition;
                       
                  
                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }

                   } break;

               case 2:
                   {

                       ItemstSeasonReportEntity stItem = (ItemstSeasonReportEntity)en;

                       String sql = "INSERT INTO t_itemst_season (PROJECTID,LOGINNAME,PROGRESSCATEGORY,PROGRESSNOW,PROBLEMS,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5,REMARK,REPORTTIME,InvestmentPosition) VALUES (@PROJECTID,@LOGINNAME,@PROGRESSCATEGORY,@PROGRESSNOW,@PROBLEMS,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5,@REMARK,@REPORTTIME,@InvestmentPosition)";
                       SqlParameter[] param = new SqlParameter[13];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 200);
                       param[0].Value = stItem.ProjectId ;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = stItem.LoginName;
                       param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[2].Value = stItem.ProgressCategory;
                       param[3] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 3000);
                       param[3].Value = stItem.ProgressNow;

                       param[4] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, 4000);
                       param[4].Value = stItem.Problems; ;

                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = stItem.Image1;

                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = stItem.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = stItem.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = stItem.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = stItem.Image5;
                       param[10] = new SqlParameter("@REMARK", SqlDbType.VarChar, 4000);
                       param[10].Value = stItem.Remark;

                       param[11] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar);
                       param[11].Value = DateTime.Now;
                       param[12] = new SqlParameter("@InvestmentPosition", SqlDbType.Float);
                       param[12].Value = stItem.InvestmentPosition;

                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }
                   
                   } break;
               case 3:
                   {
                       ItembhReportEntity bh = (ItembhReportEntity)en;
                       String sql = "INSERT INTO t_itembh_season (PROJECTID,LOGINNAME,FINISHTIME,SUBTOTAL,IMAGEPROGRESS,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5,PROGRESSCATEGORY,REPORTTIME) values (@PROJECTID,@LOGINNAME,@FINISHTIME,@SUBTOTAL,@IMAGEPROGRESS,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5,@PROGRESSCATEGORY,@REPORTTIME)";
                       SqlParameter[] param = new SqlParameter[12];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
                       param[0].Value = bh.ProjectID;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar,50);
                       param[1].Value = bh.LoginName  ;
                       param[2] = new SqlParameter("@FINISHTIME", SqlDbType.VarChar,20);
                       param[2].Value = bh.FinishTime  ;
                       param[3] = new SqlParameter("@SUBTOTAL", SqlDbType.VarChar,500);
                       param[3].Value = bh.SubTotal ;
                       param[4] = new SqlParameter("@IMAGEPROGRESS", SqlDbType.VarChar,3000);
                       param[4].Value = bh.Imageprogress  ;
                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = bh.Image1;
                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = bh.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = bh.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = bh.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = bh.Image5;
                       param[10] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[10].Value = bh.ProgressCategory;
                       param[11] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar, 200);
                       param[11].Value = DateTime.Now;                                       


                      
                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }

                   } break;
               case 4:
                   {
                       ItemjgReportEntity jg = (ItemjgReportEntity)en;
                       String sql = "INSERT INTO t_itemjg_season (PROJECTID,LOGINNAME,XYEAEPLAN,XMONFIN,PROGRESSNOW,IMAGE1,IMAGE2,IMAGE3,IMAGE4,IMAGE5,REPORTTIME,PROGRESSCATEGORY) values (@PROJECTID,@LOGINNAME,@XYEAEPLAN,@XMONFIN,@PROGRESSNOW,@IMAGE1,@IMAGE2,@IMAGE3,@IMAGE4,@IMAGE5,@REPORTTIME,@PROGRESSCATEGORY)";
                       SqlParameter[] param = new SqlParameter[12];
                       //PROJECTNUMBER,COUNTIES,PROJECTNAME,CONSTRUCTIONADDRESS,
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
                       param[0].Value = jg.ProjectID;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar,100);
                       param[1].Value = jg.LoginName ;
                       param[2] = new SqlParameter("@XYEAEPLAN", SqlDbType.VarChar, 2000);
                       param[2].Value = jg.XYeqePlan ;
                       //param[3] = new SqlParameter("@ENDYEAR", SqlDbType.VarChar, 50);
                       //param[3].Value = jg.EndYear ;
                       //param[4] = new SqlParameter("@PREYEARPLAN", SqlDbType.VarChar, 3000);
                       //param[4].Value = jg.PreyearPlan ;
                       param[3] = new SqlParameter("@XMONFIN", SqlDbType.VarChar, 1000);
                       param[3].Value = jg.XMonFin ;
                       param[4] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 5000);
                       param[4].Value = jg.ProgressNow ;
                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = jg.Image1;
                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = jg.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = jg.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = jg.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = jg.Image5;
                       param[10] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar, 200);
                       param[10].Value = DateTime.Now;
                       param[11] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[11].Value = jg.ProgressCategory; 

                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }
                   } break;
               //case 5:
               //    {
               //        //特色月报
               //        ItemtsReportEntity ts = (ItemtsReportEntity)en;
               //        string sql = "INSERT INTO t_itemts_month(PROJECTID,PROJECTDESCRIPT,BRIEF,LOGINNAME,REPORTTIME) values (@PROJECTID,@PROJECTDESCRIPT,@BRIEF,@LOGINNAME,@REPORTTIME)";
               //        SqlParameter[] param = new SqlParameter[5];
               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar,50);
               //        param[0].Value = ts.ProjectId;
               //        param[1] = new SqlParameter("@PROJECTDESCRIPT", SqlDbType.VarChar,4000);
               //        param[1].Value = ts.ProjectDesc;
               //        param[2] = new SqlParameter("@BRIEF", SqlDbType.VarChar,4000);
               //        param[2].Value = ts.Brief;
               //        param[3] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar,50);
               //        param[3].Value = ts.LoginName;
               //        param[4] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar,20);
               //        param[4].Value = DateTime.Now;

               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }


               //    } break;
               //case 6:
               //    {
               //        ItemzbReportEntity zb = (ItemzbReportEntity)en;
               //        string sql = "INSERT INTO t_itemzb_season(PROJECTID,LOGINNAME,ZONEAREA,MAINTREESPECIES,FORESTLANDSCAPE,TRIPELEMENT,REPORTTIME) values (@PROJECTID,@LOGINNAME,@ZONEAREA,@MAINTREESPECIES,@FORESTLANDSCAPE,@TRIPELEMENT,@REPORTTIME)";
               //        SqlParameter[] param = new SqlParameter[7];

               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 50);
               //        param[0].Value = zb.ProjectId;
               //        param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 64);
               //        param[1].Value = zb.LoginName;
               //        param[2] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar, 64);
               //        param[2].Value = zb.ZoneArea;
               //        param[3] = new SqlParameter("@MAINTREESPECIES", SqlDbType.VarChar, 3000);
               //        param[3].Value = zb.Maintreespecis;
               //        param[4] = new SqlParameter("@FORESTLANDSCAPE", SqlDbType.VarChar, 3000);
               //        param[4].Value = zb.ForistLandScape;
               //        param[5] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, 3000);
               //        param[5].Value = zb.TripElement;
               //        param[6] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar, 64);
               //        param[6].Value = DateTime.Now.ToShortTimeString();

               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }
                   
               //    } break;
               //case 7:
               //    {
               //        //乡村月报
               //        ItemxcReportEntity xc = (ItemxcReportEntity)en;
               //        string sql = "INSERT INTO t_itemxc_month(PROJECTID,PROJECTDESCRIPT,BRIEF,LOGINNAME,REPORTTIME) values (@PROJECTID,@PROJECTDESCRIPT,@BRIEF,@LOGINNAME,@REPORTTIME)";
               //        SqlParameter[] param = new SqlParameter[5];
               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar,20);
               //        param[0].Value = xc.ProjectId;
               //        param[1] = new SqlParameter("@PROJECTDESCRIPT", SqlDbType.VarChar,4000);
               //        param[1].Value = xc.ProjectDesc;
               //        param[2] = new SqlParameter("@BRIEF", SqlDbType.VarChar,4000);
               //        param[2].Value = xc.Brief;
               //        param[3] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar,50);
               //        param[3].Value = xc.LoginName;
               //        param[4] = new SqlParameter("@REPORTTIME", SqlDbType.VarChar,20);
               //        param[4].Value = DateTime.Now;

               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }


               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }
               //    } break;
               default: break;
           }


           return re;
           
       }

       #endregion

       #region 月报季报删除
       /// <summary>
       ///  1、生态旅游月报 2、生态旅游季度报 
       /// 2、景观农业
       /// 3、百湖工程
       /// 4、生态植被
       /// 5、乡村旅游度假区
       /// 6、A级景区
      /// </summary>
      /// <param name="type"></param>
      /// <param name="id"></param>
      /// <returns></returns>
       public bool delete(int type, int id)
       {
           bool re = false;
           DataBase db = new DataBase();

           switch (type)
           {
               case 1:
                   {
                       String sql = "DELETE FROME t_itemst_month WHERE ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   } break;
               case 2:
                   {
                       String sql = "DELETE FROME t_itemst_season WHERE ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   } break;
               case 3:
                   {

                   } break;
               case 4:
                   {


                   } break;
               case 5:
                   {


                   } break;
               case 6:
                   {
                       String sql = "DELETE FROME t_itemzb_season WHERE ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
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

       #region 修改月报季报数据
       /// <summary>
       /// 更新一则数据
       /// </summary>
       /// <param name="type"></param>
       /// <param name="en"></param>
       /// <returns></returns>
       public bool update(int type, object en,int ID,string loginname)
       {
           DataBase db = new DataBase();
           bool re = false;
           switch (type)
           {
               case 1:
                   {
                       ItemstMonthReportEntity stItem = (ItemstMonthReportEntity)en;

                       string sql = "update t_itemst_month set PROGRESSCATEGORY=@PROGRESSCATEGORY,PROGRESSNOW=@PROGRESSNOW,PROBLEMS=@PROBLEMS,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5,REMARK=@REMARK ,InvestmentPosition=@InvestmentPosition where ID=@ID";

                       SqlParameter[] param = new SqlParameter[11];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = ID;
                       param[1] = new SqlParameter("@REMARK", SqlDbType.VarChar, 200);
                       param[1].Value = stItem.Remark;
                       param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[2].Value = stItem.ProgressCategory;
                       param[3] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 3000);
                       param[3].Value = stItem.ProgressNow;
                       param[4] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, 200);
                       param[4].Value = stItem.Problems;

                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = stItem.Image1;
                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = stItem.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = stItem.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = stItem.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = stItem.Image5;
                       param[10] = new SqlParameter("@InvestmentPosition", SqlDbType.VarChar, 200);
                       param[10].Value = stItem.InvestmentPosition;        
                       

                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }
                   } break;
               case 2:
                   {
                       ItemstSeasonReportEntity stItem = (ItemstSeasonReportEntity)en;
                       string sql = "update t_itemst_season SET PROGRESSCATEGORY=@PROGRESSCATEGORY,PROGRESSNOW=@PROGRESSNOW,PROBLEMS=@PROBLEMS,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5,REMARK=@REMARK where ID=@ID";

                       SqlParameter[] param = new SqlParameter[10];

                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = ID;
                       param[1] = new SqlParameter("@REMARK", SqlDbType.VarChar, 200);
                       param[1].Value = stItem.Remark;
                       param[2] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 200);
                       param[2].Value = stItem.ProgressCategory;
                       param[3] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 3000);
                       param[3].Value = stItem.ProgressNow;

                       param[4] = new SqlParameter("@PROBLEMS", SqlDbType.VarChar, 200);
                       param[4].Value = stItem.Problems; ;

                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = stItem.Image1;

                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = stItem.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = stItem.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = stItem.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = stItem.Image5;

                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }

                   } break;
               case 3:
                   {
                       ItembhReportEntity bh = (ItembhReportEntity)en;
                       String sql = "update t_itembh_season  SET FINISHTIME=@FINISHTIME,SUBTOTAL=@SUBTOTAL,IMAGEPROGRESS=@IMAGEPROGRESS,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5,PROGRESSCATEGORY=@PROGRESSCATEGORY where ID=@ID";
                       SqlParameter[] param = new SqlParameter[12];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
                       param[0].Value = bh.ProjectID;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                       param[1].Value = bh.LoginName;
                       param[2] = new SqlParameter("@FINISHTIME", SqlDbType.VarChar, 20);
                       param[2].Value = bh.FinishTime;
                       param[3] = new SqlParameter("@SUBTOTAL", SqlDbType.VarChar, 500);
                       param[3].Value = bh.SubTotal;
                       param[4] = new SqlParameter("@IMAGEPROGRESS", SqlDbType.VarChar, 3000);
                       param[4].Value = bh.Imageprogress ;
                       param[5] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[5].Value = bh.Image1;
                       param[6] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[6].Value = bh.Image2;
                       param[7] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[7].Value = bh.Image3;
                       param[8] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[8].Value = bh.Image4;
                       param[9] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[9].Value = bh.Image5;
                       param[10] = new SqlParameter("@ID", SqlDbType.Int);
                       param[10].Value = bh.ID;
                       param[11] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 50);
                       param[11].Value = bh.ProgressCategory;

                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }
                   } break;
               case 4:
                   {
                       ItemjgReportEntity jg = (ItemjgReportEntity) en;
                       String sql = "update t_itemjg_season SET XMONFIN=@XMONFIN,PROGRESSNOW=@PROGRESSNOW,PROGRESSCATEGORY=@PROGRESSCATEGORY,IMAGE1=@IMAGE1,IMAGE2=@IMAGE2,IMAGE3=@IMAGE3,IMAGE4=@IMAGE4,IMAGE5=@IMAGE5 WHERE ID=@ID";
                       SqlParameter[] param = new SqlParameter[9];
                       //PROJECTNUMBER,COUNTIES,PROJECTNAME,CONSTRUCTIONADDRESS,
                       param[0] = new SqlParameter("@XMONFIN", SqlDbType.VarChar, 50);
                       param[0].Value = jg.XMonFin;
                       param[1] = new SqlParameter("@PROGRESSNOW", SqlDbType.VarChar, 4000);
                       param[1].Value = jg.ProgressNow;
                       param[2] = new SqlParameter("@ID", SqlDbType.Int);
                       param[2].Value = jg.Id;
                       param[3] = new SqlParameter("@PROGRESSCATEGORY", SqlDbType.VarChar, 2000);
                       param[3].Value = jg.ProgressCategory;
                       param[4] = new SqlParameter("@IMAGE1", SqlDbType.VarChar, 200);
                       param[4].Value = jg.Image1;
                       param[5] = new SqlParameter("@IMAGE2", SqlDbType.VarChar, 200);
                       param[5].Value = jg.Image2;
                       param[6] = new SqlParameter("@IMAGE3", SqlDbType.VarChar, 200);
                       param[6].Value = jg.Image3;
                       param[7] = new SqlParameter("@IMAGE4", SqlDbType.VarChar, 200);
                       param[7].Value = jg.Image4;
                       param[8] = new SqlParameter("@IMAGE5", SqlDbType.VarChar, 200);
                       param[8].Value = jg.Image5;
                       
                       if (1 == db.ExecuteSql(sql, param))
                       {
                           re = true;
                       }

                   } break;
               //case 5:
               //    {
               //        //特色月报
               //        ItemtsReportEntity ts = (ItemtsReportEntity)en;
               //        string sql = "UPDATE t_itemts_month  SET PROJECTID@PROJECTID,PROJECTDESCRIPT=@PROJECTDESCRIPT,BRIEF=@BRIEF WHERE ID=@ID";
               //        SqlParameter[] param = new SqlParameter[4];
                      
               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar,50);
               //        param[0].Value = ts.ProjectId;
               //        param[1] = new SqlParameter("@PROJECTDESCRIPT", SqlDbType.VarChar,3000);
               //        param[1].Value = ts.ProjectDesc;
               //        param[2] = new SqlParameter("@BRIEF", SqlDbType.VarChar,3000);
               //        param[2].Value = ts.Brief;
               //        //param[3] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar,);
               //        //param[3].Value = ts.ModifyUser;
               //        param[3] = new SqlParameter("@ID", SqlDbType.VarChar,20);
               //        param[3].Value = ts.Id;



               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }


               //    } break;
               //case 6:
               //    {
               //        ItemzbReportEntity zb = (ItemzbReportEntity)en;
               //        string sql = "update t_itemzb_season SET PROJECTID=@PROJECTID,ZONEAREA=@ZONEAREA,MAINTREESPECIES=@MAINTREESPECIES,FORESTLANDSCAPE=@FORESTLANDSCAPE,TRIPELEMENT=@TRIPELEMENT where ID=@ID";
               //        SqlParameter[] param = new SqlParameter[6];

               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 50);
               //        param[0].Value = zb.ProjectId;
               //        param[2] = new SqlParameter("@ZONEAREA", SqlDbType.VarChar, 64);
               //        param[2].Value = zb.ZoneArea;
               //        param[3] = new SqlParameter("@MAINTREESPECIES", SqlDbType.VarChar, 4000);
               //        param[3].Value = zb.Maintreespecis;
               //        param[4] = new SqlParameter("@FORESTLANDSCAPE", SqlDbType.VarChar, 3000);
               //        param[4].Value = zb.ForistLandScape;
               //        param[5] = new SqlParameter("@TRIPELEMENT", SqlDbType.VarChar, 3000);
               //        param[5].Value = zb.TripElement;
               //        param[1] = new SqlParameter("@ID", SqlDbType.Int);
               //        param[1].Value = zb.Id;

               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }

               //    } break;
               //case 7:
               //    {
               //        //乡村月报
               //        ItemxcReportEntity xc = (ItemxcReportEntity)en;
               //        string sql = "UPDATE t_itemxc_month SET   PROJECTID=@PROJECTID,PROJECTDESCRIPT=@PROJECTDESCRIPT,BRIEF=@BRIEF WHERE ID=@ID";
               //        SqlParameter[] param = new SqlParameter[4];

               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar);
               //        param[0].Value = xc.ProjectId;
               //        param[1] = new SqlParameter("@PROJECTDESCRIPT", SqlDbType.VarChar);
               //        param[1].Value = xc.ProjectDesc;
               //        param[2] = new SqlParameter("@BRIEF", SqlDbType.VarChar);
               //        param[2].Value = xc.Brief;
               //        //param[3] = new SqlParameter("@MODIFYUSER", SqlDbType.VarChar);
               //        //param[3].Value = ts.ModifyUser;
               //        param[3] = new SqlParameter("@ID", SqlDbType.VarChar);
               //        param[3].Value = xc.Id;



               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = true;
               //        }
               //    } break;
               default: break;
           }


           return re;
       }

       #endregion


       public DataTable select(int type, int id)
       {
           DataTable dt = new DataTable();
           DataBase db = new DataBase();
           switch (type)
           {
               case 1:
                   {
                       string sql = "select * from t_itemst_month where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 2:
                   {
                       string sql = "select * from t_itemst_season where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 3:
                   {
                       string sql = "select * from t_itembh_season where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 4:
                   {
                       string sql = "select * from t_itemjg_season where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 5:
                   {
                       string sql = "select * from t_itemts_month where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 6:
                   {
                       string sql = "select * from t_itemzb_season where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);

                   } break;

               case 7:
                   {
                       string sql = "select * from t_itemxc_month where ID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.Int);
                       param[0].Value = id;
                       dt = db.GetDataTable(sql, param);
                   } break;
               default: break;
           }


           return dt;
       }


       public DataTable select(int type, String projectNumber)
       {
           DataTable dt = new DataTable();
           DataBase db = new DataBase();

           switch (type)
           {
               case 1:
                   {
                       //ID,PROJECTNUMBER,ADDRESS,AUDIT,REPORTTIME
                       string sql = "select * from t_itemst_month where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql,param);

                   } break;
               case 2:
                   {
                       //ID,PROJECTNUMBER,ADDRESS,AUDIT,REPORTTIME
                       string sql = "select * from t_itemst_season where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 3:
                   {
                       //ID,PROJECTNUMBER,PROJECTADDRESS,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select * from t_itembh_season where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 4:
                   {
                       //ID,PROJECTNUMBER,COUNTIES,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select * from t_itemjg_season where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 5:
                   {
                       string sql = "select * from t_itemts_month where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                      
                   } break;
               case 6:
                   {
                       //ID,PROJECTNUMBER，ADDRESS,NAME,AREA,MANAGESUBJECT,PROJECTEXPLAIN
                       //ID,PROJECTNUMBER,ADDRESS,NAME,AREA,MANAGESUBJECT,PROJECTEXPLAIN
                       string sql = "select * from t_itemzb_season where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 7:
                   {
                       //ID,PROJECTNUMBER,AREA,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select * from t_itemxc_month where PROJECTID=@ID";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               default: break;
           }


           return dt;
       
       }


       //sun
       /// <summary>
       /// 
       /// </summary>
       /// <param name="type"></param>
       /// <param name="projectNumber"></param>
       /// <param name="roleid"></param>------4、指业主 3、指一级审核员 2、指2级审核员 1、指领导
       /// <returns></returns>
       public DataTable select(int type, String projectNumber,int roleid)
       {
           DataTable dt = new DataTable();
           DataBase db = new DataBase();
           string auditStr = "(2)";
           //int.Parse(rw["AUDIT"].ToString().Trim()) == 0
           switch (roleid)
           {
               case 1:
                   auditStr = "(2)";
                   break;
               case 2:
                   auditStr = "(1,2)";
                   break;
               case 3:
                   auditStr = "(1,2,0)";
                   break;
               case 4:
                   auditStr = "(1,2,0)";
                   break;
               default: break;

           }
           switch (type)
           {
               case 1:
                   {
                       //ID,PROJECTNUMBER,ADDRESS,AUDIT,REPORTTIME
                       string sql = "select s.*,t.PROJECTNUMBER from t_itemst_month s,t_itemst t  where s.PROJECTID=t.ID and  s.PROJECTID=@ID and s.AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 2:
                   {
                       //ID,PROJECTNUMBER,ADDRESS,AUDIT,REPORTTIME
                       string sql = "select s.*,t.PROJECTNUMBER from t_itemst_month s,t_itemst t  where s.PROJECTID=t.ID and  s.PROJECTID=@ID and s.AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 3:
                   {
                       //ID,PROJECTNUMBER,PROJECTADDRESS,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select s.*,t.PROJECTNUMBER from t_itembh_season s,t_itembh t  where s.PROJECTID=t.ID and  s.PROJECTID=@ID and s.AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 4:
                   {
                       //ID,PROJECTNUMBER,COUNTIES,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select s.*,t.PROJECTNUMBER from t_itemjg_season s,t_itemjg t  where s.PROJECTID=t.ID and  s.PROJECTID=@ID and s.AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 5:
                   {
                       string sql = "select * from t_itemts_month where PROJECTID=@ID and AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 6:
                   {
                       //ID,PROJECTNUMBER，ADDRESS,NAME,AREA,MANAGESUBJECT,PROJECTEXPLAIN
                       //ID,PROJECTNUMBER,ADDRESS,NAME,AREA,MANAGESUBJECT,PROJECTEXPLAIN
                       string sql = "select * from t_itemzb_season where PROJECTID=@ID and AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 7:
                   {
                       //ID,PROJECTNUMBER,AREA,AUDIT,REPORTTIME,SAVETIME
                       string sql = "select * from t_itemxc_month where PROJECTID=@ID and AUDIT in " + auditStr;
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@ID", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               default: break;
           }


           return dt;

       }

       public DataTable selectAll(int type, String projectNumber)
       {
           DataTable dt = new DataTable();
           DataBase db = new DataBase();

           switch (type)
           {
               case 1:
                   {
                       string sql = "select * from t_itemst_month where PROJECTNUMBER=@PROJECTNUMBER";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 2:
                   {
                       string sql = "select * from t_itemst_season where PROJECTNUMBER=@PROJECTNUMBER";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 3:
                   {
                       string sql = "select * from t_itembh_season where PROJECTNUMBER=@PROJECTNUMBER";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 4:
                   {


                   } break;
               case 5:
                   {
                      

                   } break;
               case 6:
                   {
                       string sql = "select * from t_itemzb_season where PROJECTNUMBER=@PROJECTNUMBER";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       dt = db.GetDataTable(sql, param);

                   } break;
               default: break;
           }


           return dt;

       }

       public DataTable selectAll(int type, String projectNumber,string loginName,string whereStr)
       {
           DataTable dt = new DataTable();
           DataBase db = new DataBase();

           switch (type)
           {
               case 1:
                   {
                       string sql = "select * from t_itemst_month where PROJECTNUMBER=@PROJECTNUMBER and LOGINNAME=@LOGINNAME " + whereStr;
                       SqlParameter[] param = new SqlParameter[2];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = loginName;

                       dt = db.GetDataTable(sql, param);

                   } break;
               case 2:
                   {
                       string sql = "select * from t_itemjg_season where PROJECTNUMBER=@PROJECTNUMBER and LOGINNAME=@LOGINNAME" + whereStr;
                       SqlParameter[] param = new SqlParameter[2];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = loginName;

                       dt = db.GetDataTable(sql, param);
                   } break;
               case 3:
                   {
                       string sql = "select * from t_itembh_season where PROJECTNUMBER=@PROJECTNUMBER and LOGINNAME=@LOGINNAME" + whereStr;
                       SqlParameter[] param = new SqlParameter[2];
                       param[0] = new SqlParameter("@PROJECTNUMBER", SqlDbType.VarChar, 200);
                       param[0].Value = projectNumber;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = loginName;

                       dt = db.GetDataTable(sql, param);
                   } break;
            
               default: break;
           }


           return dt;

       }

       /// <summary>
       ///  主要服务于根据项目id查出的报告列表。。
       ///  
       /// 适用于所有报告（根据报告编号得到的报告列表）
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="projectNum"></param>
       /// <param name="type"></param>
       /// <param name="roleID"></param>------4、指业主 3、指一级审核员 2、指2级审核员 1、指领导
       public void bindItem(GridView gv, AspNetPager pager, string projectID, int type, int roleID)
       {
           StringUtills utils = new StringUtills();
           //根据项目编号查询数据数据集
          // DataTable tb = select(type, projectID);//sun
           DataTable tb = select(type, projectID, roleID);
           //if(roleID==4)
           //{
           //    tb = selectAll(type, projectID, loginName, "");
           //}
           
           //将查询结果定制成适合页面显示的数据     
           //增加一列名为DETAIL的列
 

           DataColumn column2 = new DataColumn("PASS", typeof(string)); //是否通过
           //把该列添加到数据集中
           tb.Columns.Add(column2);

           DataColumn c1 = new DataColumn("reportTim", typeof(string)); //上报时间
           //把该列添加到数据集中
           tb.Columns.Add(c1);

           DataColumn column3 = new DataColumn("Detail", typeof(string)); //查看详情
           //把该列添加到数据集中
           tb.Columns.Add(column3);
           DataColumn column4 = new DataColumn("MODIFY", typeof(string)); //修改
           //把该列添加到数据集中
           tb.Columns.Add(column4);


           foreach (DataRow rw in tb.Rows)
           {

               switch (type)
               {
                   case 1:
                       {

                           rw["reportTim"] = utils.getMonth(rw["REPORTTIME"].ToString());

                           rw["Detail"] = "<a href='view/itemst_view_month.aspx?id=" + rw["ID"] + "'>查看</a>";
                           rw["MODIFY"] = "<a href='itemst_month_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";

                       } break;
                   //case 2:
                   //    {

                   //        rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                   //        rw["Detail"] = "<a href='view/itemst_view_season.aspx?id=" + rw["ID"] + "'>查看</a>";
                   //        rw["MODIFY"] = "<a href='itemst_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                   //    } break;
                   case 3:
                       {

                           rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                           rw["Detail"] = "<a href='view/itembh_view_season.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>查看</a>";
                           rw["MODIFY"] = "<a href='itembh_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                       } break;
                   case 4:
                       {

                           rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                           rw["Detail"] = "<a href='view/itemjg_view_season.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>查看</a>";
                           rw["MODIFY"] = "<a href='itemjg_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                       } break;
                   //case 5:
                   //    {

                   //        rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                   //        rw["Detail"] = "<a href='view/itemts_view_month.aspx?id=" + rw["ID"] + "'>查看</a>";
                   //        rw["MODIFY"] = "<a href='itemts_month_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                   //    } break;
                   //case 6:
                   //    {

                   //        rw["reportTim"] = utils.getMonth(rw["REPORTTIME"].ToString());

                   //        rw["Detail"] = "<a href='view/itemzb_view_season.aspx?id=" + rw["ID"] + "'>查看</a>";
                   //        rw["MODIFY"] = "<a href='itemzb_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                   //    } break;
                   //case 7:
                   //    {

                   //        rw["reportTim"] = utils.getMonth(rw["REPORTTIME"].ToString());

                   //        rw["Detail"] = "<a href='view/itemxc_view_month.aspx?id=" + rw["ID"] + "'>查看</a>";
                   //        rw["MODIFY"] = "<a href='itemxc_month_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                   //    } break;
                   default: break;
               }


               switch (roleID)
               {
                   case 4:
                       {
                           //业主
                           rw["PASS"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 0 ? "审核未通过" : "审核通过";
                           rw["MODIFY"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 0 ? rw["MODIFY"] : "不能修改";
                       } break;
                   case 3:
                       {
                           //一级审核员
                          
                          // rw["PASS"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 2 ? "审核通过" : "还未审核";
                           if (int.Parse(rw["AUDIT"].ToString().Trim()) == 2)
                           {
                               rw["PASS"] = "上级审核通过";
                           }
                           else if (int.Parse(rw["AUDIT"].ToString().Trim()) == 1)
                           {
                               rw["PASS"] = "一级审核通过，等待上级审核";
                           }
                           else if (int.Parse(rw["AUDIT"].ToString().Trim()) == 0)
                           {
                               rw["PASS"] = "一级未审核";
                           }
                           

                       } break;
                   case 2:
                       {
                           //二级审核员
                           rw["PASS"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 2 ? "审核通过" : "还未审核";

                       } break;
                   case 1:
                       {
                           //领导
                           rw["PASS"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 2 ? "审核通过" : "还未审核";
                       } break;
                   default: break;
               }


           }

           //把数据绑定在UI
           gv.DataSource = tb;
           gv.DataBind();
       }

       #region 所有月报季报查询分页  sun
       /// <summary>
       /// 报告列表多功能查询
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager">分页控件</param>
       /// <param name="type">0:标示所有的；1表示生态季报;3.表示生态月报；4表示景观季报；5：表示百湖季报；6表示植被季报；7：表示特色月报；8表示乡村月报</param>
       /// <param name="whereStr"></param>
       public void bindGridView(GridView gv, AspNetPager pager,int type, String whereStr,int roleID)
       {
           DataBase db = new DataBase();
           DataTable dtRestM = new DataTable();
           DataTable dtRestE = new DataTable();
           DataTable dtRejg = new DataTable();
           DataTable dtRebh = new DataTable();
           DataTable dtRezb = new DataTable();
           DataTable dtRets = new DataTable();
           DataTable dtRexc = new DataTable();
           String sqlStM = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName "+whereStr;
           String sqlStE = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName " + whereStr;
           String sqlJg = "select * from t_itemjg_season s,t_itemjg t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName " + whereStr;
           String sqlBh = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName " + whereStr;
           String sqlZb = "select * from t_itemzb_season s,t_itemzb t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName  " + whereStr;
           String sqlTs = "select * from t_itemts_month s,t_itemts t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName  " + whereStr;
           String sqlXc = "select * from t_itemxc_month s,t_itemxc t,t_user u where t.ProjectNumber=s.ProjectNumber and u.LOGINNAME=t.loginName  " + whereStr;
           switch (type)
           {
               case 0:
                   {
                      dtRestM = db.GetDataTable(sqlStM);
                       dtRestE = db.GetDataTable(sqlStE);
                       dtRejg = db.GetDataTable(sqlJg);
                       dtRebh = db.GetDataTable(sqlBh);
                       dtRezb = db.GetDataTable(sqlZb);
                       dtRets = db.GetDataTable(sqlTs);
                       dtRexc = db.GetDataTable(sqlXc);
                   } break;
               case 1:
                   {
                     dtRestM = db.GetDataTable(sqlStM);
                   } break;
               case 2:
                   {
                       dtRestE = db.GetDataTable(sqlStE);
                   } break;
               case 3:
                   {
                       dtRestM = db.GetDataTable(sqlStM);
                       dtRestE = db.GetDataTable(sqlStE);
                   } break;
               case 4:
                   {
                       dtRejg = db.GetDataTable(sqlJg);
                   } break;
               case 5:
                   {
                       dtRebh = db.GetDataTable(sqlBh);
                   
                   } break;
               case 6:
                   {
                       dtRezb = db.GetDataTable(sqlZb);
                   
                   } break;
               case 7:
                   {
                       dtRets = db.GetDataTable(sqlTs);
                   
                   } break;
               case 8:
                   {
                       dtRexc = db.GetDataTable(sqlXc);
                   } break;
               default: break;
           }
           DataTable dt = new DataTable();
           dt.Columns.Add("username",typeof(string));
           dt.Columns.Add("projectname", typeof(string));
           dt.Columns.Add("projectnumber", typeof(string));
           dt.Columns.Add("submittime", typeof(string));
           dt.Columns.Add("address", typeof(string));
           DataTable dt1 = new DataTable();
           dt1.Columns.Add("username", typeof(string));
           dt1.Columns.Add("projectname", typeof(string));
           dt1.Columns.Add("projectnumber", typeof(string));
           dt1.Columns.Add("submittime", typeof(string));
           dt1.Columns.Add("address", typeof(string));
           if (dtRestM != null && dtRestM.Rows.Count > 0)
           {
               for(int i=0;i<dtRestM.Rows.Count;i++)
               {
               DataRow r = dt.NewRow();
               }
           }
           if (dtRestE != null && dtRestE.Rows.Count > 0)
           {
               for(int i=0;i<dtRestE.Rows.Count;i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           if (dtRejg != null && dtRejg.Rows.Count > 0)
           {
               for (int i = 0; i < dtRejg.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           if (dtRebh != null && dtRebh.Rows.Count > 0)
           {
               for (int i = 0; i < dtRebh.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           if (dtRezb != null && dtRezb.Rows.Count > 0)
           {
               for (int i = 0; i < dtRezb.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           dtRets = db.GetDataTable(sqlTs);
           if (dtRets != null && dtRets.Rows.Count>0)
           {
               for (int i = 0; i < dtRets.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           dtRexc = db.GetDataTable(sqlXc);
           if (dtRexc != null && dtRexc.Rows.Count > 0)
           {
               for (int i = 0; i < dtRexc.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
               }
           }
           int count = dt.Rows.Count;
           pager.RecordCount = count;
           for (int i = 0; i < count; i++)
           {
               if (i > (pager.CurrentPageIndex - 1) * pager.PageSize && i < pager.CurrentPageIndex * pager.PageSize)
               {
                   DataRow r = dt1.NewRow();
                   r[i] = dt.Rows[i];
                   dt1.Rows.Add(r);
               }
           }
           gv.DataSource = dt1;
           gv.DataBind();
       }

       #endregion

       /// <summary>
       /// 更新审核状态
       /// </summary>
       /// <param name="reportType"></param>
       /// <param name="reportID"></param>
       /// <returns></returns>
       public bool updateAudit(int reportType, int reportID,int audit)
       {
           
           string tableName = "";
           switch(reportType){
               case 1:
                   {
                       tableName = " t_itemst_month ";  
                   } break;
               case 2:
                   {
                       tableName = "t_itemst_season";  
                   } break;
               case 3:
                   {
                       tableName = "t_itemjg_season";  
                   } break;
               case 4:
                   {
                       tableName = "t_itembh_season"; 
                   } break;
               case 5:
                   {
                       tableName = "t_itemzb_season"; 
                   } break;
               case 6:
                   {
                       tableName = "t_itemts_month"; 
                   } break;
               case 7:
                   {
                       tableName = "t_itemxc_month"; 
                   } break;
               default: break;

           };

           String sql = "update " + tableName + " set AUDIT=@AUDIT WHERE ID=@ID";
           SqlParameter[] param = new SqlParameter[2];

           param[0] = new SqlParameter("@AUDIT", SqlDbType.VarChar);
           param[0].Value = audit;
           param[1] = new SqlParameter("@ID", SqlDbType.VarChar);
           param[1].Value = reportID;
           DataBase db = new DataBase();
           if(db.ExecuteSql(sql,param) == 1)
           {
               return true;
           }

           return false;
       }

       



       #region  一级审核员管理报告 孙武斌

       /// <summary>
       /// 一级审核员审核报告
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="loginName"></param>
       /// <param name="type"></param>
       /// <param name="whereStr"></param>
       public void bindReportAdmin1(GridView gv, AspNetPager pager,string loginName, int type, String whereStr)
       {


           DataBase db = new DataBase();
           DataTable dtRestM = new DataTable();
           DataTable dtRestE = new DataTable();
           DataTable dtRejg = new DataTable();
           DataTable dtRebh = new DataTable();
           DataTable dtRezb = new DataTable();
           DataTable dtRets = new DataTable();
           DataTable dtRexc = new DataTable();
           String sqlStM = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME ) " + whereStr;
           String sqlStE = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME ) " + whereStr;
           String sqlJg = "select * from t_itemjg_season s,t_itemjg t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME ) " + whereStr;
           String sqlBh = "select * from t_itembh_season s,t_itembh t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME ) " + whereStr;
           String sqlZb = "select * from t_itemzb_season s,t_itemzb t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  " + whereStr;
           String sqlTs = "select * from t_itemts_month s,t_itemts t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  " + whereStr;
           String sqlXc = "select * from t_itemxc_month s,t_itemxc t,t_user u where t.ProjectNumber=s.ProjectNumber and u.AREA = (select u1.area from t_user u1 where  u1.LOGINNAME=@LOGINNAME )  " + whereStr;
           switch (type)
           {

               case 0:
                   {
                       dtRestM = db.GetDataTable(sqlStM);
                       dtRestE = db.GetDataTable(sqlStE);
                       dtRejg = db.GetDataTable(sqlJg);
                       dtRebh = db.GetDataTable(sqlBh);
                       dtRezb = db.GetDataTable(sqlZb);
                       dtRets = db.GetDataTable(sqlTs);
                       dtRexc = db.GetDataTable(sqlXc);
                   } break;
               case 1:
                   {
                       dtRestM = db.GetDataTable(sqlStM);
                   } break;
               case 2:
                   {
                       dtRestE = db.GetDataTable(sqlStE);
                   } break;
               case 3:
                   {
                       dtRestM = db.GetDataTable(sqlStM);
                       dtRestE = db.GetDataTable(sqlStE);
                   } break;
               case 4:
                   {
                       dtRejg = db.GetDataTable(sqlJg);
                   } break;
               case 5:
                   {
                       dtRebh = db.GetDataTable(sqlBh);

                   } break;
               case 6:
                   {
                       dtRezb = db.GetDataTable(sqlZb);

                   } break;
               case 7:
                   {
                       dtRets = db.GetDataTable(sqlTs);

                   } break;
               case 8:
                   {
                       dtRexc = db.GetDataTable(sqlXc);
                   } break;
               default: break;
           }
           DataTable dt = new DataTable();
           dt.Columns.Add("username", typeof(string));
           dt.Columns.Add("projectname", typeof(string));
           dt.Columns.Add("projectnumber", typeof(string));
           dt.Columns.Add("submittime", typeof(string));
           dt.Columns.Add("address", typeof(string));
           DataTable dt1 = new DataTable();
           dt1.Columns.Add("username", typeof(string));
           dt1.Columns.Add("projectname", typeof(string));
           dt1.Columns.Add("projectnumber", typeof(string));
           dt1.Columns.Add("submittime", typeof(string));
           dt1.Columns.Add("address", typeof(string));
           if (dtRestM != null && dtRestM.Rows.Count > 0)
           {
               for (int i = 0; i < dtRestM.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();

                   dt.Rows.Add(r);
               }
           }
           if (dtRestE != null && dtRestE.Rows.Count > 0)
           {
               for (int i = 0; i < dtRestE.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           if (dtRejg != null && dtRejg.Rows.Count > 0)
           {
               for (int i = 0; i < dtRejg.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           if (dtRebh != null && dtRebh.Rows.Count > 0)
           {
               for (int i = 0; i < dtRebh.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           if (dtRezb != null && dtRezb.Rows.Count > 0)
           {
               for (int i = 0; i < dtRezb.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           dtRets = db.GetDataTable(sqlTs);
           if (dtRets != null && dtRets.Rows.Count > 0)
           {
               for (int i = 0; i < dtRets.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           dtRexc = db.GetDataTable(sqlXc);
           if (dtRexc != null && dtRexc.Rows.Count > 0)
           {
               for (int i = 0; i < dtRexc.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   dt.Rows.Add(r);
               }
           }
           int count = dt.Rows.Count;
           pager.RecordCount = count;
           for (int i = 0; i < count; i++)
           {
               if (i > (pager.CurrentPageIndex - 1) * pager.PageSize && i < pager.CurrentPageIndex * pager.PageSize)
               {
                   DataRow r = dt1.NewRow();
                   r[i] = dt.Rows[i];
                   dt1.Rows.Add(r);
               }
           }
           gv.DataSource = dt1;
           gv.DataBind();

       }

       #endregion

       /// <summary>
       /// 根据报告类型以及ID获取实体
       /// </summary>
       /// <param name="reportType"></param>
       /// <param name="reportID"></param>
       /// <returns></returns>
       public DataTable getReportByID(int reportType, int reportID)
       {
           string sql = "";
           switch (reportType)
           {
               case 1:
                   //生态月报
                   //sql = "select a.*,b.* from t_itemst_month a left join t_itemst b on a.PROJECTID = b.ID";
                   //break;
                   //生态月报
                   sql = @"select u.area ,m.*,t.* ,
dbo.getstmonth_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total from t_user u,t_itemst_month m, t_itemst t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME and ";
                   break;
               //case 2:
               //    //生态季度报
               //    sql = "select a.*,b.* from t_itemst_season a left join t_itemst b on a.PROJECTID = b.ID";
               //    break;
               case 3:
                   //百湖生态月报
                   //sql = "select a.*,b.* from t_itembh_season a left join t_itembh b on a.PROJECTID = b.ID";
                   //break;
                   sql = @"select u.area, m.*,t.*,dbo.getbhseason_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total from t_user u,t_itembh_season m, t_itembh t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME  and";
                   break;
               case 2:
                   //景观月报
                   //sql = "select a.*,b.* from t_itemjg_season a left join t_itemjg b on a.PROJECTID = b.ID";
                   //break;
                   sql = @"select u.area, m.*,t.*,dbo.getjgseason_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total from t_user u,t_itemjg_season m, t_itemjg t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME  and";
                   break;
           
               default:
                   break;
           }
           sql = sql + "  m.ID = @ID";
           DataBase db = new DataBase();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@ID", SqlDbType.Int);
           param[0].Value = reportID;
           DataTable dt = db.GetDataTable(sql,param);
           return dt;
       }


       public DataTable selectReportById(int type, int id)
       {
           String sql = "";

           switch (type)
           {
               case 1:
                   //生态月报
                   sql = @"select (case when u.area='lqy' then '龙泉驿' when u.area='jt' then '金堂县' when u.area='qbj' then '青百江区' when u.area='sl' then '双流县' when u.area='xj' then '新津县'  end) as 'qx',m.*,t.*,
 dbo.getstmonth_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total  from t_user u,t_itemst_month m, t_itemst t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME and ";
                   break;
//               case 2:
//                   //生态季度报
//                   sql = @"select (case when u.area='lqy' then '龙泉驿' when u.area='jt' then '金堂县' when u.area='qbj' then '青百江区' when u.area='sl' then '双流县' when u.area='xj' then '新津县'  end) as 'qx',t.projectName,t.address, t.constructionage ,constructiontype,t.contentscale,t.totlemoney,t.centralmoney,t.provincialmoney,t.municipalmoney,t.districtmoney,t.bankloan,t.companyself,t.CAINVESTMENT ,t.planinvestment,m.progressNow,t.predictstarttime,t.predictfinishtime,t.progresscategory ,t.getlandtargets,t.planlandtargets,governmentproje, governmentproje,t.thisyear_investment,t.plane_investment,
//dbo.getstseason_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total,m.InvestmentPosition,m.problems,m.remark  from t_user u,t_itemst_season m, t_itemst t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME and ";
//                   break;
               case 3:
                   //百湖生态月报select a.*,b.* from t_itembh_season a left join t_itembh b on a.PROJECTID = b.ID
                   sql = @"select (case when u.area='lqy' then '龙泉驿' when u.area='jt' then '金堂县' when u.area='qbj' then '青百江区' when u.area='sl' then '双流县' when u.area='xj' then '新津县'  end) as 'qx',m.*,t.*,dbo.getbhseason_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total from t_user u,t_itembh_season m, t_itembh t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME  and";
                   break;
               case 4:
                   //景观月报select a.*,b.* from t_itemjg_season a left join t_itemjg b on a.PROJECTID = b.ID
                   sql = @"select (case when u.area='lqy' then '龙泉驿' when u.area='jt' then '金堂县' when u.area='qbj' then '青百江区' when u.area='sl' then '双流县' when u.area='xj' then '新津县'  end) as 'qx',m.*,t.*,dbo.getjgseason_sum(convert(int,MONTH(m.REPORTTIME)),m.PROJECTID ,CONVERT(int,YEAR(m.REPORTTIME))) as total from t_user u,t_itemjg_season m, t_itemjg t where t.ID=m.ProjectID and u.LOGINNAME=t.LOGINNAME  and ";
                   break;
     
               default:
                   break;

           }
           sql += " m.id=@ID ";
           DataBase db = new DataBase();
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@ID", SqlDbType.Int);
           param[0].Value = id;
           return db.GetDataTable(sql,param);

       }


       /// <summary>
       /// 一级审核员漏项统计
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="loginName"></param>
       /// <param name="role"></param>
       /// <param name="whereStr"></param>
       public void staticsforadmin1(GridView gv, AspNetPager pager, string area)
       {

          DataTable dt = new DataTable();
          dt.Columns.Add("num", typeof(string));
          dt.Columns.Add("name", typeof(string));
          dt.Columns.Add("reporttime", typeof(string));
          dt.Columns.Add("address", typeof(string));
          dt.Columns.Add("area", typeof(string));
          dt.Columns.Add("onwer", typeof(string));

          DataTable dt1 = new DataTable();
          dt1.Columns.Add("num", typeof(string));
          dt1.Columns.Add("name", typeof(string));
          dt1.Columns.Add("reporttime", typeof(string));
          dt1.Columns.Add("address", typeof(string));
          dt1.Columns.Add("area", typeof(string));
          dt1.Columns.Add("onwer", typeof(string));
   

          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@AREA", SqlDbType.VarChar, 200);
          param[0].Value = area;
          DataBase db = new DataBase();
          DataTable dtsts = new DataTable();
          DataTable dtstm = new DataTable();
          DataTable dtjg = new DataTable();
          DataTable dtbh = new DataTable();
          DataTable dtzb = new DataTable();
          DataTable dtts = new DataTable();
          DataTable dtxc = new DataTable();
           //百湖
          String sqlbh = "SELECT t_itembh.LOGINNAME as USERNAME,  t_itembh.*,t_user.LOGINNAME,t_user.AREA FROM t_itembh , t_user where t_itembh.ID NOT IN (SELECT t_itembh_season.PROJECTID FROM t_itembh_season WHERE year(REPORTTIME)=year(GETDATE()) and  dbo.fun_getSeason(month(REPORTTIME))=dbo.fun_getCurrentSeason()) and t_itembh.LOGINNAME = t_user.LOGINNAME and t_user.LOGINNAME IN (SELECT t_user.LOGINNAME FROM t_user WHERE t_user.AREA =@AREA) and t_itembh.SUBMITSTATE=1 and t_itembh.audit=1";
          dtbh = db.GetDataTable(sqlbh,param) ;
          //景观
          string sqljg = "SELECT t_itemjg.LOGINNAME as USERNAME,  t_itemjg.*,t_user.LOGINNAME,t_user.AREA FROM t_itemjg , t_user where t_itemjg.ID NOT IN (SELECT t_itemjg_season.PROJECTID FROM t_itemjg_season WHERE year(REPORTTIME)=year(GETDATE()) and  dbo.fun_getCurrentSeason()=dbo.fun_getSeason(MONTH(REPORTTIME))) and t_itemjg.LOGINNAME = t_user.LOGINNAME and t_user.LOGINNAME IN (SELECT t_user.LOGINNAME FROM t_user WHERE t_user.AREA =@AREA) and t_itemjg.SUBMITSTATE=1 and t_itemjg.audit=1";
          dtjg = db.GetDataTable(sqljg,param) ;       
          //生态 月报
          string sqlst_month = "SELECT t_itemst.LOGINNAME as USERNAME,  t_itemst.*,t_user.LOGINNAME,t_user.AREA FROM t_itemst , t_user where t_itemst.ID NOT IN (SELECT t_itemst_month.PROJECTID FROM t_itemst_month WHERE year(REPORTTIME)=year(GETDATE()) and  month(REPORTTIME)=month(GETDATE())) and t_itemst.LOGINNAME = t_user.LOGINNAME and t_user.LOGINNAME IN (SELECT t_user.LOGINNAME FROM t_user WHERE t_user.AREA =@AREA) and t_itemst.SUBMITSTATE=1 and t_itemst.audit=1";
           dtstm = db.GetDataTable(sqlst_month,param);
   
           StringUtills utils = new StringUtills();
           if(dtstm.Rows.Count>0)
           {
               for (int i = 0; i < dtstm.Rows.Count;i++ )
               {
                   DataRow r = dt.NewRow();
                   r["num"] = dtstm.Rows[i]["PROJECTNUMBER"];
                   r["name"] = dtstm.Rows[i]["PROJECTNAME"];
                   r["address"] = dtstm.Rows[i]["ADDRESS"];
                   r["reporttime"] = utils.getMonth(dtstm.Rows[i]["SUBMITTIME"].ToString().Trim());
                   r["onwer"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtstm.Rows[i]["USERNAME"] + "'>" + dtstm.Rows[i]["USERNAME"] + "</a>";
                   r["area"] = dtstm.Rows[i]["AREA"];
                   dt.Rows.Add(r);
               }
           }
     
           if (dtjg.Rows.Count > 0)
           {
               for (int i = 0; i < dtjg.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   r["num"] = dtjg.Rows[i]["PROJECTNUMBER"];
                   r["name"] = dtjg.Rows[i]["PROJECTNAME"];
                   r["address"] = dtjg.Rows[i]["ADDRESS"];
                   r["reporttime"] = utils.getSeason(dtjg.Rows[i]["SUBMITTIME"].ToString().Trim());
                   r["onwer"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtjg.Rows[i]["USERNAME"] + "'>" + dtjg.Rows[i]["USERNAME"] + "</a>";
                   r["area"] = dtjg.Rows[i]["AREA"];
                   dt.Rows.Add(r);
               }
           }
           if (dtbh.Rows.Count > 0)
           {
               for (int i = 0; i < dtbh.Rows.Count; i++)
               {
                   DataRow r = dt.NewRow();
                   r["num"] = dtbh.Rows[i]["PROJECTNUMBER"];
                   r["name"] = dtbh.Rows[i]["PROJECTNAME"];
                   r["address"] = dtbh.Rows[i]["ADDRESS"];
                   r["reporttime"] = utils.getSeason(dtbh.Rows[i]["SUBMITTIME"].ToString().Trim());
                   r["onwer"] = "<a href='view/view_ownerInfo.aspx?LOGINNAME=" + dtbh.Rows[i]["USERNAME"] + "'>" + dtbh.Rows[i]["USERNAME"] + "</a>";
                   r["area"] = dtbh.Rows[i]["AREA"];
                   dt.Rows.Add(r);
               }
           }
        

           gv.DataSource = dt;
           gv.DataBind();

       }

       /// <summary>
       /// 二级审核员漏项统计
       /// </summary>
       /// <param name="gv"></param>
       /// <param name="pager"></param>
       /// <param name="whereStr"></param>
       public void staticsforadmin2(GridView gv, AspNetPager pager, String whereStr)
       { 
       
       }

       /// <summary>
       /// 判断是否存在以及存在某月的进度报告？
       /// 
       /// 存在返回  真
       /// 
       /// reportTime-----------有问题----2012、12、22------lpm
       /// </summary>
       /// <param name="type"></param>
       /// <param name="reportTime"></param>
       /// <returns></returns>
       public bool isExitReport(int type, int projectID, string reportTime)
       {
           
       


           String sql = "";
           switch (type)
           {
               case 1:
                   { sql = "SELECT count(*)  from t_itemst t,t_itemst_month m WHERE m.PROJECTID=t.ID and t.ID=" + projectID + " AND YEAR(M.REPORTTIME)=YEAR('" + reportTime + "') AND MONTH(M.REPORTTIME)=( MONTH('" + reportTime + "') ) "; }
                   break;
               case 3:
                   { sql = "SELECT count(*)  from t_itembh t,t_itembh_season m WHERE m.PROJECTID=t.ID and t.ID=" + projectID + " AND YEAR(M.REPORTTIME)=YEAR('" + reportTime + "') AND dbo.fun_getSeason(MONTH(M.REPORTTIME))=dbo.fun_getSeason( MONTH('" + reportTime + "'))  "; }
                   break;
               case 2:
                   { sql = "SELECT count(*)  from t_itemjg t,t_itemjg_season m WHERE m.PROJECTID=t.ID and t.ID=" + projectID + " AND YEAR(M.REPORTTIME)=YEAR('" + reportTime + "') AND dbo.fun_getSeason(MONTH(M.REPORTTIME))=dbo.fun_getSeason( MONTH('" + reportTime + "'))  "; }
                   break;
               default:
                   break;
           }
          
           DataBase db = new DataBase();
           SqlParameter[] param = new SqlParameter[1];
           //param[0] = new SqlParameter("@reportTime", SqlDbType.VarChar, 500);
           //param[0].Value = DateTime.Now;
           param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
           param[0].Value = projectID;

 
           if (db.ExecuteValue(sql, param).ToString().Trim() != "0")
           {
               return true;
           }
           return false;
       }

      /// <summary>
      /// 当业主添加报告时加载数据
      /// 
      /// </summary>
      /// <param name="type"></param>
      /// <param name="projectID"></param>
      /// <param name="reportTime"></param>
      /// <returns></returns>
       public DataTable getDataWhenAddReport(int type, int projectID, DateTime reportTime)
       {
           ItemDal dal = new ItemDal();
           DataTable dt = new DataTable();
           DataBase db = new DataBase();
           String sql = "SELECT  dbo.getLastReportIdWhenAdd('" + reportTime + "'," + projectID + "," + type + ")";
           String reportID = db.ExecuteValue(sql);

           //先判断是否存在上一个月的报告，是的话返回报告id,否则返回null
           if (reportID != null && reportID.Trim() != "" && int.Parse(reportID.Trim()) != 0)
           {
               //如果存在则读取上一月的数据
               dt = this.getReportByID(type, int.Parse(reportID.Trim()));

           }
           else
           {
               dt = dal.selectByID(type, projectID);
           }
           return dt;
       }

       public void bindReportManage(GridView gv, AspNetPager pager, string projectID, int type, string loginName,string whereStr)
       { 
           DataTable dt = selectAll(type,projectID,loginName,"");
           StringUtills utils = new StringUtills();
           
           DataColumn c1 = new DataColumn("reportTim", typeof(string)); //上报时间
           //把该列添加到数据集中
           dt.Columns.Add(c1);

           DataColumn column3 = new DataColumn("Detail", typeof(string)); //查看详情
           //把该列添加到数据集中
           dt.Columns.Add(column3);
           DataColumn column4 = new DataColumn("MODIFY", typeof(string)); //修改
           //把该列添加到数据集中
           dt.Columns.Add(column4);


           foreach (DataRow rw in dt.Rows)
           {
             switch(type)
             {
                 case 1:
                     {

                         rw["reportTim"] = utils.getMonth(rw["REPORTTIME"].ToString());

                         rw["Detail"] = "<a href='view/itemst_view_month.aspx?id=" + rw["ID"] + "'>查看</a>";
                         rw["MODIFY"] = "<a href='itemst_month_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                      
                     } break;
                 case 3:
                     {

                         rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                         rw["Detail"] = "<a href='view/itembh_view_season.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>查看</a>";
                         rw["MODIFY"] = "<a href='itembh_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                     } break;
                 case 2:
                     {

                         rw["reportTim"] = utils.getSeason(rw["REPORTTIME"].ToString());

                         rw["Detail"] = "<a href='view/itemjg_view_season.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>查看</a>";
                         rw["MODIFY"] = "<a href='itemjg_season_update.aspx?projectID=" + rw["PROJECTID"] + "&id=" + rw["ID"] + "'>修改</a>";
                     } break;
             }

             rw["MODIFY"] = int.Parse(rw["AUDIT"].ToString().Trim()) == 0 ? rw["MODIFY"] : "不能修改";

           }

           gv.DataSource = dt;
           gv.DataBind();
       }


       public bool isAdd(int type, object en)
       {
            DataBase db = new DataBase();
           bool re = true;

           switch (type)
           {
               case 1:
                   {
                       ItemstMonthReportEntity stItem = (ItemstMonthReportEntity)en;
                       //String sql = "select count(*) from t_itemst_month where PROJECTID=@PROJECTID and LOGINNAME=@LOGINNAME and dbo.getTimeByMonth("+System.DateTime.Now.Year +","+System.DateTime.Now.Month+") ";
                       String sql = @"select count(*) from t_itemst_month where PROJECTID=@PROJECTID and LOGINNAME=@LOGINNAME and REPORTTIME>=
(select cast(cast(myBeginYear as varchar)+'/'+cast(myBeginMonth as varchar)+'/'+cast(myBeginDay as varchar) as datetime) as begt
 from dbo.getTimeByMonth(" + System.DateTime.Now.Year + "," + System.DateTime.Now.Month + "))  and REPORTTIME< (select cast(cast(myEndYear as varchar)+'/'+cast(myEndMonth as varchar)+'/'+cast(myEndDay as varchar) as datetime) as endt from dbo.getTimeByMonth(" + System.DateTime.Now.Year + "," + System.DateTime.Now.Month + ")) ";
                       SqlParameter[] param = new SqlParameter[2];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 200);
                       param[0].Value = stItem.ProjectId;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[1].Value = stItem.LoginName;
                       if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                       {
                           re = false;
                       }

                   } break;

               //case 2:
               //    {

               //        ItemstSeasonReportEntity stItem = (ItemstSeasonReportEntity)en;

               //        String sql = "select  count(*) from t_itemst_season ";
               //        SqlParameter[] param = new SqlParameter[2];
               //        param[0] = new SqlParameter("@PROJECTID", SqlDbType.VarChar, 200);
               //        param[0].Value = stItem.ProjectId;
               //        param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
               //        param[1].Value = stItem.LoginName;
               //        if (1 == db.ExecuteSql(sql, param))
               //        {
               //            re = false;
               //        }

               //    } break;
               case 3:
                   {
                       ItembhReportEntity bh = (ItembhReportEntity)en;
                      // String sql = "select count(*) from t_itembh_season ";
                       String sql = @"select count(*) from t_itembh_season where PROJECTID=@PROJECTID and LOGINNAME=@LOGINNAME and SAVETIME>=
(select cast(cast(myBeginYear as varchar)+'/'+cast(myBeginMonth as varchar)+'/'+cast(myBeginDay as varchar) as datetime) as begt
 from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + "))  and SAVETIME< (select cast(cast(myEndYear as varchar)+'/'+cast(myEndMonth as varchar)+'/'+cast(myEndDay as varchar) as datetime) as endt from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + ")) ";
                       SqlParameter[] param = new SqlParameter[2];
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
                       param[0].Value = bh.ProjectID;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                       param[1].Value = bh.LoginName;
                       if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                       {
                           re = false;
                       }

                   } break;
               case 4:
                   {
                       ItemjgReportEntity jg = (ItemjgReportEntity)en;
                       //String sql = "select  count(*) from t_itemjg_season ";
                       String sql = @"select count(*) from t_itemjg_season where PROJECTID=@PROJECTID and LOGINNAME=@LOGINNAME and SAVETIME>=
(select cast(cast(myBeginYear as varchar)+'/'+cast(myBeginMonth as varchar)+'/'+cast(myBeginDay as varchar) as datetime) as begt
 from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + "))  and SAVETIME< (select cast(cast(myEndYear as varchar)+'/'+cast(myEndMonth as varchar)+'/'+cast(myEndDay as varchar) as datetime) as endt from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + ")) ";
                       SqlParameter[] param = new SqlParameter[2];
                       //PROJECTNUMBER,COUNTIES,PROJECTNAME,CONSTRUCTIONADDRESS,
                       param[0] = new SqlParameter("@PROJECTID", SqlDbType.Int);
                       param[0].Value = jg.ProjectID;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 100);
                       param[1].Value = jg.LoginName;


                       if (1 <= int.Parse(db.ExecuteValue(sql, param)))
                       {
                           re = false;
                       }
                   } break;
               default: break;
           }
           return re;
       }
    }
}
