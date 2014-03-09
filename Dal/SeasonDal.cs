using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Model;
using System.Data.SqlClient;
using System.Data;

namespace Dal
{
  public   class SeasonDal
    {
      public DataTable select(int year, string area, string itemtype)
      {
          DataBase db = new DataBase();
          return db.GetDataTable("select *,MONTH(SUBMITTIME) as [month] from dbo.t_seasonreportforword where YEAR(SUBMITTIME) =" + year + " and itemtype='" + itemtype + "' and area='" + area + "' ");
      }

      public bool add(SeasonReportForWordEntity en)
      {
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[4];
          param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
          param[0].Value = en.LoginName;
          param[1] = new SqlParameter("@SEASONCOMMENT", SqlDbType.VarChar, -1);
          param[1].Value = en.SeasonComment;
          param[2] = new SqlParameter("@ITEMTYPE", SqlDbType.VarChar, 10);
          param[2].Value = en.ItemType;
          param[3] = new SqlParameter("@AREA", SqlDbType.VarChar, 50);
          param[3].Value = en.Area;

          if (db.ExecuteSql("insert into t_seasonreportforword(loginname,seasoncomment,itemtype,[area]) values(@LOGINNAME,@SEASONCOMMENT,@ITEMTYPE,@AREA)",param) == 1)
          {
              return true;
          }
          else
          {
              return false;
          }
      }

      public bool isAddSeasonRep(SeasonReportForWordEntity en)
      {
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[2];
     
          param[0] = new SqlParameter("@ITEMTYPE", SqlDbType.VarChar, 10);
          param[0].Value = en.ItemType;
          param[1] = new SqlParameter("@AREA", SqlDbType.VarChar, 50);
          param[1].Value = en.Area;

          if (1 <= int.Parse(db.ExecuteValue(@"select count(*) from t_seasonreportforword where [area]=@AREA and itemtype=@ITEMTYPE and  SUBMITTIME>=
(select cast(cast(myBeginYear as varchar)+'/'+
cast(myBeginMonth as varchar)+'/'+cast(myBeginDay as varchar) as datetime) as begt  from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + "))  and SUBMITTIME< (select cast(cast(myEndYear as varchar)+'/'+cast(myEndMonth as varchar)+'/'+cast(myEndDay as varchar) as datetime) as endt from dbo.getTimeBySeason(" + System.DateTime.Now.Year + "," + new DateTimeUtil().getSeasonByMonty(System.DateTime.Now.Month, System.DateTime.Now.Day) + ")) ", param)))
          {
              return false;
          }
          else
          {
              return true;
          }
      }

      public DataTable queryById(int id)
      {
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[1];
          param[0] = new SqlParameter("@ID", SqlDbType.Int);
          param[0].Value = id;

          return db.GetDataTable("select *,MONTH(SUBMITTIME) as[month] from t_seasonreportforword where id=@ID", param);

      }

      public bool update(SeasonReportForWordEntity en)
      {
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[2];
          param[0] = new SqlParameter("@ID", SqlDbType.Int);
          param[0].Value = en.Id;
          param[1] = new SqlParameter("@SEASONCOMMENT", SqlDbType.VarChar, -1);
          param[1].Value = en.SeasonComment;
          if (db.ExecuteSql("update t_seasonreportforword set SEASONCOMMENT=@SEASONCOMMENT,SUBMITTIME=getdate() where ID=@ID", param) == 1)
          {
              return true;
          }
          else
          {
              return false;
          }
          
      }

      public bool submit(SeasonReportForWordEntity en)
      {
          DataBase db = new DataBase();
          SqlParameter[] param = new SqlParameter[2];
          param[0] = new SqlParameter("@ID", SqlDbType.Int);
          param[0].Value = en.Id;
          param[1] = new SqlParameter("@SUBMITSTATE", SqlDbType.VarChar, 300);
          param[1].Value = en.SubmitState ;
          if (db.ExecuteSql("update t_seasonreportforword set SUBMITSTATE=@SUBMITSTATE where ID=@ID", param) == 1)
          {
              return true;
          }
          else
          {
              return false;
          }
      }

      public DataTable selectadmin(int year,string itemtype,int season)
      {
          DataBase db = new DataBase();
          return db.GetDataTable(" select *,MONTH(SUBMITTIME) as [month] from dbo.t_seasonreportforword where YEAR(SUBMITTIME) =" + year + " and itemtype='" + itemtype + "' and MONTH(SUBMITTIME)<=" + (season * 3) + " and MONTH(SUBMITTIME)>="+ ((season-1) * 3)+" and area !='cd' and submitstate=1 " );
      }

      public DataTable selectadminByType(int year, int parentid, int season)
      {
          DataBase db = new DataBase();
          return db.GetDataTable(" select *,MONTH(SUBMITTIME) as [month] from dbo.t_seasonreportforword where YEAR(SUBMITTIME) =" + year + " and itemtype=(select f.ITEMTYPE  from t_seasonreportforword f where id="+parentid+") and MONTH(SUBMITTIME)<=" + (season * 3) + " and MONTH(SUBMITTIME)>=" + ((season - 1) * 3) + " and area !='cd' and submitstate=1");
      }
    }
}
