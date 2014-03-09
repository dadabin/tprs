using System;
using System.Collections.Generic;
using System.Text;

namespace Dal
{
    /// <summary>
    ///  时间字符串处理
    ///  
    /// @author：LPM
    /// @TODO 未测试
    /// </summary>
    public class StringUtills
    {
        /// <summary>
        /// 根据时间字符串获取到季度
        /// 
        /// 
        /// 返回结果如：2012年第一季度
        /// </summary>
        /// <param name="time"></param>
        /// 
        /// 时间格式为：2012/12/5 11:54:58
        /// 
        /// 
        /// 2、时间限定
        ///月报：当月的6号（含6号）-下个月的5号（含5号）
        /// 比如12月的月报：12月6号（含6号）-下年度的1月5号（含5号）
        ///
        /// 季报：
        /// 1季度：1月6号（含6号）-4月5号（含5号）；
        /// 2季度：4月6号（含6号）-7月5号（含5号）；
        /// 3季度：7月6号（含6号）-10月5号（含5号）；
        /// 3季度：10月6号（含6号）-下年的1月5号（含5号）
        /// <returns></returns>
        public String getSeason(String time)
        {
            String resultStr = "";

            if (time != "" && time != null)
            {
                //转换成时间类型
                DateTime dt = DateTime.Parse(time);
                //获取年份
                int year = dt.Year;
                //获取月份
                int month = dt.Month;
                //获取日期
                int day = dt.Day;
                string season = "";
                //if (month >= 1 && month <= 3)
                //{
                //    season = "一季度";
                //}
                //if (month >= 4 && month <= 6)
                //{
                //    season = "二季度";
                //}
                //if (month >= 7 && month <= 9)
                //{
                //    season = "三季度";
                //}
                //if (month >= 10 && month <= 12)
                //{
                //    season = "四季度";
                //}

                /////////////////////////////////////
                DateTime dt1_1 = DateTime.Parse(year + "-1-6");
                DateTime dt1_2 = DateTime.Parse(year + "-4-5");

                DateTime dt2_1 = DateTime.Parse(year + "-4-6");
                DateTime dt2_2 = DateTime.Parse(year + "-7-5");
                
                DateTime dt3_1 = DateTime.Parse(year + "-7-6");
                DateTime dt3_2 = DateTime.Parse(year + "-10-5");
                
                DateTime dt4_1 = DateTime.Parse(year + "-10-6");
                DateTime dt4_2 = DateTime.Parse((year+1) + "-1-5");
                if (dt.CompareTo(dt1_1) > 0 && dt.CompareTo(dt1_2) <= 0)
                {
                    season = "一季度";
                }
                if (dt.CompareTo(dt2_1) > 0 && dt.CompareTo(dt2_2) <= 0)
                {
                    season = "二季度";
                }
                if (dt.CompareTo(dt3_1) > 0 && dt.CompareTo(dt3_2) <= 0)
                {
                    season = "三季度";
                }
                if (dt.CompareTo(dt4_1) > 0 && dt.CompareTo(dt4_2) <= 0)
                {
                    season = "四季度";
                }

                resultStr = resultStr + year + "年第" + season;
            }
            else
            {
                resultStr = "--";
            }

            return resultStr;
        }

        /// <summary>
        ///  根据时间字符串获取到月份
        ///  
        /// 返回结果如：2012年12月份
        /// </summary>
        /// <param name="time"></param>
        /// 
        /// 时间格式为：2012/12/5 11:54:58
        /// <returns></returns>
        public String getMonth(String time)
        {
            String resultStr = "";

            if (time != "" && time != null)
            {
                //转换成时间类型
                DateTime dt = DateTime.Parse(time);
                //获取年份
                int year = dt.Year;
                //获取月份
                int month = dt.Month;

                if (month == 12)
                {
                    DateTime dt1 = DateTime.Parse(year + "-" + month + "-6");
                    DateTime dt2 = DateTime.Parse((year+1) + "-1-5");

                    if (dt.CompareTo(dt1) >= 0 && dt.CompareTo(dt2) <= 0)
                    {
                        resultStr = resultStr + year + "年第" + month + "月份";
                    }
                    else
                    {
                        resultStr = resultStr + year + "年第" + (month-1) + "月份";    
                    }
                }
                else
                {
                    DateTime dt1 = DateTime.Parse(year + "-" + month + "-6");
                    DateTime dt2 = DateTime.Parse(year + "-" + (month + 1) + "-5");
                    if (dt.CompareTo(dt1) >= 0 && dt.CompareTo(dt2) <= 0)
                    {
                        resultStr = resultStr + year + "年第" + month + "月份";
                    }
                    else
                    {
                        //1-4等特殊对待
                        if(month==1)
                        {
                            resultStr = resultStr + (year-1) + "年第12月份";
                        }

                    }
                }
            }
            else
            {
                resultStr = "--";
            }


            return resultStr;
        }

        /// <summary>
        /// 构建项目的编号，，，项目由业主提交后，经以及审核员通过后生成，
        /// 
        /// 项目编号遵循规律为：
        /// 
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string builtProjectNUM(int type, int ID)
        {
            string num = "";
            switch (type)
            {
                case 1:
                    //生态旅游
                    num = "ST0" + String.Format("{0:D4}",""+ID);
                    break;
                case 2:
                    //景观
                    num = "JG0" + String.Format("{0:D4}", "" + ID);
                    break;
                case 3:
                    //百湖
                    num = "BH0" + String.Format("{0:D4}", "" + ID);
                    break;
                case 4:
                    //植被
                    num = "ZB0" + String.Format("{0:D4}", "" + ID);
                    break;
                case 5:
                    //特色
                    num = "TS0" + String.Format("{0:D4}", "" + ID);
                    break;
                    
                case 6:
                    //乡村
                    num = "XC0" + String.Format("{0:D4}", "" + ID);
                    break;
                default:
                    break;
            }
            return num;
        }

        public  string getChineseLocaltion(string english)
        {
            string resultStr = "";
            if(english == "lqy")
            {
                resultStr = "龙泉驿";
            }
            else if (english == "jt")
            {
                resultStr = "金堂";
            }
            else if (english == "sl")
            {
                resultStr = "双流";
            }
            else if (english == "qbj")
            {
                resultStr = "青百江";
            }
            else if (english == "xj")
            {
                resultStr = "新津";
            }
            return resultStr;
        }

        /// <summary>
        /// 获取进度的中文
        /// </summary>
        /// <param name="english"></param>
        /// <returns></returns>
        public string getChineseProgress(string english)
        {
            string resultStr = "";
            if (english == "tcdc")
            {
                resultStr = "投产达产";
            }
            else if (english == "jkjs")
            {
                resultStr = "加快建设";
            }
            else if (english == "qqcb")
            {
                resultStr = "前期储备";
            }
            else if (english == "cjkg")
            {
                resultStr = "促进开工";
            }
            else
            {
                resultStr = english;
            }
           
            return resultStr;
        }

        /// <summary>
        /// 获取当前时间的季度值
        /// 
        /// 
        /// 返回结果：2012年第一季度
        /// </summary>
        /// <returns></returns>
        public string getcurrentSeason()
        { 
            string season="";
            DateTime date = DateTime.Today;
            switch (date.Month)
            {
              case  2: case  3: case  4: season = "第一季度"; break;
              case  5: case  6: case  7: season = "第二季度"; break;
              case  8: case  9: case 10: season = "第三季度"; break;
              case 11: case 12: case  1: season = "第四季度"; break;
            }
            return date.Year+"年"+season;
        }

        /// <summary>
        /// 获取当前月份
        /// </summary>
        /// <returns></returns>
        public string getCurrrentMonth()
        {
            string monthStr = "";
            DateTime date = DateTime.Today;
            return monthStr;
        }


        public string 占用方式(String english)
        {
            String returnStr = "";
            if(english.Trim() == "lz" )
            {
                returnStr = "流转";
            }
            if (english.Trim() == "zy")
            {
                returnStr = "征用";
            }
            if (english.Trim() == "lz&amp;zy")
            {
                returnStr = "流转及征用";
            }
            return returnStr;
        }

        public DateTime[] getCurrentTimeZone()
        {
            DateTime[] zone = new DateTime[2];
            DateTime now = DateTime.Now;
            int year = now.Year;
            int month = now.Month;
            int day = now.Day;

            //本月区间
            DateTime dt00 = DateTime.Parse(year + "-" + month + "-6");
            DateTime dt01 = ( (month == 12) ? DateTime.Parse((year+1) + "-1-5") : DateTime.Parse((year + "-" + (month + 1) + "-5")) );
            //上月区间
            DateTime dt10 = (month==1)? DateTime.Parse((year-1) + "-12-6") : DateTime.Parse(year + "-" + (month-1) + "-6");
            DateTime dt11 = DateTime.Parse((year + "-" + month + "-5"));

            //if (month == 12)
            //{
            //    //DateTime dt1 = DateTime.Parse(year + "-" + month + "-6");
            //    //DateTime dt2 = DateTime.Parse((year + 1) + "-1-5");
                if (now.CompareTo(dt00) >= 0 && now.CompareTo(dt01) <= 0)
                {
                    //本月
                    zone[0] = dt00;
                    zone[1] = dt01;
                }
                else
                {
                    //上月    
                    zone[0] = dt10;
                    zone[1] = dt11;
                }
            //}
            //else
            //{
            //    if (now.CompareTo(dt00) >= 0 && now.CompareTo(dt01) >= 0)
            //    {
            //        //在此区间
            //        zone[0] = dt00;
            //        zone[1] = dt01;
            //    }
            //    else 
            //    {
            //        if (month == 1)
            //        {
            //            zone[0] = DateTime.Parse((year-1) + "-12-6");
            //            zone[1] = DateTime.Parse(year + "-" + month + "-5");
            //        }
            //        else
            //        {
            //            zone[0] = dt10;
            //            zone[1] = dt10;
            //        }
            //    }
            //}


            return zone;
        }

        public DateTime[] getSeasonZone()
        {
            DateTime[] zone = new DateTime[2];
            DateTime dt = DateTime.Now;
            int year = dt.Year;
            int month = dt.Month;

            DateTime dt1_1 = DateTime.Parse(year + "-1-6");
            DateTime dt1_2 = DateTime.Parse(year + "-4-5");

            DateTime dt2_1 = DateTime.Parse(year + "-4-6");
            DateTime dt2_2 = DateTime.Parse(year + "-7-5");

            DateTime dt3_1 = DateTime.Parse(year + "-7-6");
            DateTime dt3_2 = DateTime.Parse(year + "-10-5");

            DateTime dt4_1 = DateTime.Parse(year + "-10-6");
            DateTime dt4_2 = DateTime.Parse((year + 1) + "-1-5");

            if (dt.CompareTo(dt1_1) >= 0 && dt.CompareTo(dt1_2) <= 0)
            {
                zone[0] = dt1_1;
                zone[1] = dt1_2;
            }
            if (dt.CompareTo(dt2_1) >= 0 && dt.CompareTo(dt2_2) <= 0)
            {
                zone[0] = dt2_1;
                zone[1] = dt2_2;
            }
            if (dt.CompareTo(dt3_1) >= 0 && dt.CompareTo(dt3_2) <= 0)
            {
                zone[0] = dt3_1;
                zone[1] = dt3_2;
            }
            if (dt.CompareTo(dt4_1) >= 0 && dt.CompareTo(dt4_2) <= 0)
            {
                zone[0] = dt4_1;
                zone[1] = dt4_2;
            }
            if (dt.CompareTo(dt1_1) < 0)
            {
                zone[0] = DateTime.Parse((year-1) + "-10-6");
                zone[1] = DateTime.Parse(year + "-1-5");
            }


            return zone;
        }


        public bool strLength(string str,int len)
        {

            if(str.Trim().Length>=len){
                return true;
            }else{
                return false;
            }
        }

    }
}
