using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI.WebControls;
using Dal;
using Model;
using System.Data;

namespace Bll
{
  public   class SeasonBll
    {

      public DataTable select(int year, string area, string itemtype)
      {
          SeasonDal dal = new SeasonDal();
          return dal.select(year, area, itemtype);
          

      }

      public bool add(SeasonReportForWordEntity en)
      {
          SeasonDal dal = new SeasonDal();
          if (dal.add(en))
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
          return new SeasonDal().isAddSeasonRep(en);
      }
      public DataTable queryById(int id)
      {
          return new SeasonDal().queryById(id);
      }

      public bool update(SeasonReportForWordEntity en)
      {
          return new SeasonDal().update(en);
      }

      public bool submit(SeasonReportForWordEntity en)
      {
          return new SeasonDal().submit(en);
      }

      public DataTable selectadmin(int year,string itemtype,int season)
      {
          return new SeasonDal().selectadmin(year,itemtype,season);
      }

      public DataTable selectadminByType(int year, int parentid, int season)
      {
          return new SeasonDal().selectadminByType(year, parentid, season);
      }
    }
}
