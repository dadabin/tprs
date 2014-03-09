using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
  public    class DateTimeUtil
    {
      /// <summary>
      /// 根据月份得到季度
      /// </summary>
      /// <param name="month"></param>
      /// <returns></returns>
      public int getSeasonByMonty(int month)
      {
          int re=-1;
          switch (month)
          {
              case 1:
              case 2:
              case 3:
                  re = 1;
                  break;
              case 4:
              case 5:
              case 6:
                  re = 2;
                  break;
              case 7:
              case 8:
              case 9:
                  re = 3;
                  break;
              case 10:
              case 11:
              case 12:
                  re = 4;
                  break;
              default: break;
          }
          return re;
      }
      public int getSeasonByMonty(int month,int day)
      {
          int re = -1;
          int xmonth=month;
          if (day < 6)
          {
              xmonth = month - 1;
          }
          if (month == 1 && day < 6)
          {
              xmonth = 12;
          }
          
          switch (xmonth)
          {
              case 1:
              case 2:
              case 3:
                  re = 1;
                  break;
              case 4:
              case 5:
              case 6:
                  re = 2;
                  break;
              case 7:
              case 8:
              case 9:
                  re = 3;
                  break;
              case 10:
              case 11:
              case 12:
                  re = 4;
                  break;
              default: break;
          }
          return re;
      }

      public string getStringByMoth(int month)
      {
          string re ="";
          switch (month)
          {
              case 1:
              case 2:
              case 3:
                  re = "一";
                  break;
              case 4:
              case 5:
              case 6:
                  re = "二";
                  break;
              case 7:
              case 8:
              case 9:
                  re = "三";
                  break;
              case 10:
              case 11:
              case 12:
                  re = "四";
                  break;
              default: break;
          }
          return re;
      }

      /// <summary>
      /// 得到当前时间的前一年
      /// </summary>
      /// <returns></returns>
      public int getPreYear()
      {
          int re = -1;
          int nowYear = int.Parse(System.DateTime.Now.Year.ToString().Trim());
          re = nowYear - 1;
          return re;
      }

      /// <summary>
      /// 得到当前时间的前一月
      /// </summary>
      /// <returns></returns>
      public int getPreMonth()
      {
          int re = -1;
          int nowMonth = int.Parse(System.DateTime.Now.Month.ToString().Trim());
          if (nowMonth == 1)
          {
              re = 12;
          }
          else
          {
              re = nowMonth - 1;
          }
          return re;

      }

      /// <summary>
      /// 得到当前时间的前一季度
      /// </summary>
      /// <returns></returns>

      public int getPreSeason()
      {
          int re = -1;
          int nowMonth = int.Parse(System.DateTime.Now.Month.ToString().Trim());

          
          switch (nowMonth)
          {
              case 1:
              case 2:
              case 3:
                  re = 4;
                  break;
              case 4:
              case 5:
              case 6:
                  re = 1;
                  break;
              case 7:
              case 8:
              case 9:
                  re = 2;
                  break;
              case 10:
              case 11:
              case 12:
                  re = 3;
                  break;
              default: break;
          }
          return re;
      }

      /// <summary>
      /// 得到当前年
      /// </summary>
      /// <returns></returns>
      public string  getNowYear()
      {
          return System.DateTime.Now.Year.ToString().Trim();
      }
      public string getNowDay()
      {
          return System.DateTime.Now.Year.ToString().Trim();
      }

      /// <summary>
      /// 得到当前月
      /// </summary>
      /// <returns></returns>
      public string getNowMonth()
      {
          return System.DateTime.Now.Month.ToString().Trim();
      }


      public string getNowTimeString()
      {
          return System.DateTime.Now.Year.ToString() + System.DateTime.Now.Month.ToString() + System.DateTime.Now.Day.ToString() + System.DateTime.Now.Hour.ToString() + System.DateTime.Now.Minute.ToString() + System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
      }


     
  }
}
