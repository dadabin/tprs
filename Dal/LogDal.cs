using System;
using System.Collections.Generic;
using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;

namespace Dal
{
    public class LogDal
    {
        /// <summary>
        /// 增加日志
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool addLog(LogEntity entity)
        {
            DataBase db = new DataBase();

            //TODO,如果时间是自动获取，则不需在此做插入
            String sql = "insert into t_log (LOGINNAME,USERNAME,OPTIME,LOGCONTENT)  VALUES  (@LOGINNAME,@USERNAME,@OPTIME,@LOGCONTENT)";
            SqlParameter[] param = new SqlParameter[4];

            param[0] = new SqlParameter("@LOGINNAME",SqlDbType.VarChar);
            param[0].Value = entity.LoginName;
            param[1] = new SqlParameter("@USERNAME", SqlDbType.VarChar);
            param[1].Value = entity.UserName == null ? "" : entity.UserName;//允许插入空值
            param[2] = new SqlParameter("@OPTIME", SqlDbType.VarChar);
            param[2].Value = DateTime.Now;                            //插入当前时间
            param[3] = new SqlParameter("@LOGCONTENT", SqlDbType.VarChar);
            param[3].Value = entity.LogContent;

            if(db.ExecuteSql(sql,param) == 1)
            {
                return true;
            }
            return false; 
        }


        /// <summary>
        /// 获取日志
        /// </summary>
        /// <param name="whereStr"></param>限制条件
        /// <returns></returns>
        public DataTable getLogs(string whereStr)
        {
            DataBase db = new DataBase();
            DataTable dt = new DataTable();
            String sql = "select * from t_log " + whereStr;
            dt = db.GetDataTable(sql);

            //TODO： LPM  尚待补全！！！！
            
            return dt;
        }

    }
}
