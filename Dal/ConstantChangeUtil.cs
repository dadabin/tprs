using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
  public  class ConstantChangeUtil
    {
      public string areaChange(string areatype)
      {
          string re = "";
          if (areatype.Trim() == "lqy")
          {
              re = "龙泉驿区";
          }
          else if (areatype.Trim() == "qbj")
          {
              re = "青白江区";
          }
          else if (areatype.Trim() == "xj")
          {
              re = "新津县";
          }
          else if (areatype.Trim() == "sl")
          {
              re = "双流县";
          }
          else if (areatype.Trim() == "jt")
          {
              re = "金堂县";
          }
          else if (areatype.Trim() == "cd")
          {
              re = "";
          }

          return re;
      }


      public string itemType(string itemtype)
      {
          string re="";
          if (itemtype.Trim() == "st")
          {
              re = "重大项目";
          }else if(itemtype.Trim()=="jg")
          {
              re = "景观农业";
          }
          else if (itemtype.Trim() == "bh")
          {
              re = "百湖工程";
          }
          else if (itemtype.Trim() == "xc")
          {
              re = "乡村旅游度假区或A级景区";
          }
          else if (itemtype.Trim() == "zb")
          {
              re = "植被恢复";
          }
          else if (itemtype.Trim() == "ts")
          {
              re = "特色旅游村";
          }

          return re;
      }
      public bool stringLength(string str, int lengthX)
      {
          if (str.Length <= lengthX)
              return true;
          return false;
      }

      public string getBigNum(int literNum)
      {
          string re = "";
          switch (literNum)
          {
              case 1: re = "一"; break;
              case 2: re = "二"; break;
              case 3: re = "三"; break;
              case 4: re = "四"; break;
              case 5: re = "五"; break;
              case 6: re = "六"; break;
              case 7: re = "七"; break;
              case 8: re = "八"; break;
              case 9: re = "九"; break;
              case 10: re = "十"; break;
              case 11: re = "十一"; break;
              case 12: re = "十二"; break;
              default: break;
          }
          return re;
      }
    }
}
