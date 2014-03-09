using System;
using System.Collections.Generic;

using System.Text;
using Model;
using System.Data;
using System.Data.SqlClient;
using Wuqi.Webdiyer;
using System.Web.UI.WebControls;

namespace Dal
{
   public  class UserDal
    {
       public bool addUser(UserEntity en,int type)
       {
           bool re = false;
           switch (type)
           {
               case 1://市级领导
                   {
                       String sql = "INSERT INTO t_user(ROLEID,LOGINNAME,PASSWORD,USERNAME,OFFICEPHONE) VALUES (@ROLEID,@LOGINNAME,@PASSWORD,@USERNAME,@OFFICEPHONE)";
                       SqlParameter[] param = new SqlParameter[5];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = en.LoginName;
                       param[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 200);
                       param[1].Value = en.Password;
                       param[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[2].Value = en.UserName;
                       param[3] = new SqlParameter("@OFFICEPHONE", SqlDbType.VarChar, 50);
                       param[3].Value = en.OfficePhone;
                       param[4] = new SqlParameter("@ROLEID", SqlDbType.Int);
                       param[4].Value = en.RoleID;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   } break;
               case 2://二级审核员
                   {
                       String sql = "INSERT INTO t_user(ROLEID,LOGINNAME,PASSWORD,USERNAME,PHONE) VALUES (@ROLEID,@LOGINNAME,@PASSWORD,@USERNAME,@PHONE)";
                       SqlParameter[] param = new SqlParameter[5];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = en.LoginName;
                       param[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 200);
                       param[1].Value = en.Password;
                       param[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[2].Value = en.UserName;
                       param[3] = new SqlParameter("@PHONE", SqlDbType.VarChar, 50);
                       param[3].Value = en.Phone;
                       param[4] = new SqlParameter("@ROLEID", SqlDbType.Int);
                       param[4].Value = en.RoleID;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   
                   
                   } break;
               case 3://一级审核员
                   {
                       String sql = "INSERT INTO t_user(ROLEID,LOGINNAME,PASSWORD,USERNAME,PHONE,AREA) VALUES (@ROLEID,@LOGINNAME,@PASSWORD,@USERNAME,@PHONE,@AREA)";
                       SqlParameter[] param = new SqlParameter[6];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = en.LoginName;
                       param[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 200);
                       param[1].Value = en.Password;
                       param[2] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[2].Value = en.UserName;
                       param[3] = new SqlParameter("@PHONE", SqlDbType.VarChar, 50);
                       param[3].Value = en.Phone;
                       param[4] = new SqlParameter("@ROLEID", SqlDbType.Int);
                       param[4].Value = en.RoleID;
                       param[5] = new SqlParameter("@AREA", SqlDbType.VarChar, 16);
                       param[5].Value = en.Area;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   } break;
               case 4://业主
                   {
                       String sql = "INSERT INTO t_user(USERNAME,LOGINNAME,PASSWORD,ROLEID,ADMIN,AREA)"
                       + "VALUES (@USERNAME,@LOGINNAME,@PASSWORD,@ROLEID,@ADMIN,@AREA)";
                       SqlParameter []param=new SqlParameter[6];
                       DataBase db = new DataBase();
                       param[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 100);
                       param[0].Value = en.UserName;
                       param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 100);
                       param[1].Value = en.LoginName;
                       param[2] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 100);
                       param[2].Value = en.Password;
                       param[3] = new SqlParameter("@ADMIN", SqlDbType.VarChar, 50);
                       param[3].Value = en.Admin ;
                       param[4] = new SqlParameter("AREA", SqlDbType.VarChar, 4);
                       param[4].Value = db.ExecuteValue("select AREA FROM t_user WHERE LOGINNAME='" + en.Admin + "'");
                       param[5] = new SqlParameter("@ROLEID", SqlDbType.Int);
                       param[5].Value = en.RoleID;
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }
                   } break;
           }
    
           return re;
       }
      







       /// <summary>
       /// 
       /// </summary>
       /// <param name="type"></param>
       /// <param name="loginName"></param>
       /// <returns></returns>
       public DataTable selectByLoginName(int type, string loginName)
       {
           DataTable dt = new DataTable();
           switch (type)
           {
               case 1:
                   {
                       string sql = "SELECT * from t_user where ROLEID=1 and LOGINNAME=@LOGINNAME";
                       SqlParameter[] param=new SqlParameter[1];
                       param[0]=new SqlParameter("@LOGINNAME",SqlDbType.VarChar,200);
                       param[0].Value=loginName;
                       DataBase db = new DataBase();
                       dt=db.GetDataTable(sql, param);
                   } break;
               case 2:
                   {
                       string sql = "SELECT * from t_user where ROLEID=2 and LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = loginName;
                       DataBase db = new DataBase();
                       dt = db.GetDataTable(sql, param);

                   } break;
               case 3:
                   {
                       string sql = "SELECT * FROM t_user where ROLEID=3 AND LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = loginName;
                       DataBase db = new DataBase();
                       dt = db.GetDataTable(sql, param);
                   } break;
               case 4:
                   {
                       string sql = "SELECT * FROM t_user where ROLEID=4 AND LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[1];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = loginName;
                       DataBase db = new DataBase();
                       dt = db.GetDataTable(sql, param);

                   } break;
               default: break;
           }
          



           return dt;
       }



       public DataTable selectByID(int type, int userID)
       {
           string sql = "SELECT * FROM t_user where ROLEID=4 AND USERID=@USERID";
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@USERID", SqlDbType.Int);
           param[0].Value = userID;
           DataBase db = new DataBase();
          return  db.GetDataTable(sql, param);
       }
       /// <summary>
       /// 修改用户资料
       /// 1:表示领导
       /// 2：表示二级管理员
       /// 3：表示一级管理员
       /// 4：表示业主
       /// </summary>
       /// <param name="type"></param>
       /// <param name="user"></param>
       /// <returns></returns>
       public bool update(int type, UserEntity user) {
           bool re = false;
           switch (type)
           {
               case 1://市领导
                   {

                       string sql = "UPDATE t_user SET USERNAME=@USERNAME,OFFICEPHONE=@OFFICEPHONE WHERE LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[3];
                       param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[0].Value = user.LoginName;
                       param[1] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[1].Value = user.UserName;
                       param[2] = new SqlParameter("@OFFICEPHONE", SqlDbType.VarChar, 30);
                       param[2].Value = user.OfficePhone;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param)==1)
                       {
                           re = true;
                       }
                   } break;

               case 2://二级审核员
                   {
                       string sql = "update t_user set USERNAME=@USERNAME,PHONE=@PHONE,EMAIL=@EMAIL where LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[4];
                       param[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[0].Value = user.UserName;
                       param[1] = new SqlParameter("@PHONE", SqlDbType.VarChar, 30);
                       param[1].Value = user.Phone;
                       param[2] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                       param[2].Value = user.LoginName;
                       param[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 40);
                       param[3].Value = user.Email;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }


                   } break;
               case 3://一级审核员
                   {
                       string sql = "update t_user set USERNAME=@USERNAME,PHONE=@PHONE,EMAIL=@EMAIL where LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[4];
                       param[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[0].Value = user.UserName;
                       param[1] = new SqlParameter("@PHONE", SqlDbType.VarChar, 200);
                       param[1].Value = user.Phone;
                       param[2] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
                       param[2].Value = user.LoginName;
                       param[3] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 40);
                       param[3].Value = user.Email;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }

                   } break;
               case 4://业主
                   {
                       string sql = "update t_user set USERNAME=@USERNAME,UNITNAME=@UNITNAME,LEGALREPRE=@LEGALREPRE,BUSINESSCONTACT=@BUSINESSCONTACT,PHONE=@PHONE,REGISTMONEY=@REGISTMONEY,REGISTAREA=@REGISTAREA,BUSINESSAREA=@BUSINESSAREA,EMAIL=@EMAIL where LOGINNAME=@LOGINNAME";
                       SqlParameter[] param = new SqlParameter[10];
                       param[0] = new SqlParameter("@USERNAME", SqlDbType.VarChar, 200);
                       param[0].Value = user.UserName;
                       param[1] = new SqlParameter("@UNITNAME", SqlDbType.VarChar, 200);
                       param[1].Value = user.UnitName ;
                       param[2] = new SqlParameter("@LEGALREPRE", SqlDbType.VarChar, 200);
                       param[2].Value = user.LegalRepre ;
                       param[3] = new SqlParameter("@BUSINESSCONTACT", SqlDbType.VarChar, 200);
                       param[3].Value = user.BusinessContact ;
                       param[4] = new SqlParameter("@PHONE", SqlDbType.VarChar, 200);
                       param[4].Value = user.Phone ;
                       param[5] = new SqlParameter("@REGISTMONEY", SqlDbType.VarChar, 200);
                       param[5].Value = user.RegistMoney ;
                       param[6] = new SqlParameter("@REGISTAREA", SqlDbType.VarChar, 200);
                       param[6].Value = user.RegistArea ;
                       param[7] = new SqlParameter("@BUSINESSAREA", SqlDbType.VarChar, 200);
                       param[7].Value = user.BusinessArea ;
                       param[8] = new SqlParameter("@EMAIL", SqlDbType.VarChar, 200);
                       param[8].Value = user.Email ;
                       param[9] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
                       param[9].Value = user.LoginName ;
                       DataBase db = new DataBase();
                       if (db.ExecuteSql(sql, param) == 1)
                       {
                           re = true;
                       }

                   }
                   break;
           }
           return re;
       }

       /// <summary>
       /// 登陆验证如果成功返回的DataTable得到的值存在
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
       public DataTable login(UserEntity user)
       {
           String sql = "SELECT * FROM t_user WHERE LOGINNAME=@LOGINNAME AND PASSWORD=@PASSWORD";
           SqlParameter[] param = new SqlParameter[2];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param[0].Value = user.LoginName;
           param[1] = new SqlParameter("@PASSWORD", SqlDbType.VarChar, 50);
           param[1].Value = user.Password;
           DataBase db = new DataBase();
           return db.GetDataTable(sql, param);
       }
       /// <summary>
       /// 验证登陆名是否可用
       /// </summary>
       /// <param name="user"></param>
       /// <returns></returns>
       public bool isUse(UserEntity user)
       {
           String sql = "SELECT count(*) FROM t_user WHERE LOGINNAME=@LOGINNAME";
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
           param[0].Value = user.LoginName;
           DataBase db = new DataBase();
           if (db.ExecuteValue(sql, param) == "1")
           {
               return false;
           }
           return true;
       }

       public void bindGridView(GridView gv, AspNetPager pager, int type, String whereStr)
       {
           switch (type)
           {
               case 1:
                   {
                       string sqlCount = "select count(*) from t_user WHERE ROLEID=1";
                       string sql = "with TUSER as (SELECT USERNAME,LOGINNAME,PHONE,Row_Number() over(order by ID) as row_number FROM t_user WHERE ROLEID=1) select * FROM TUSER where row_number>{0} and row_number<={1}";
                       sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
                       DataBase db = new DataBase();
                       string countStr = db.ExecuteValue(sqlCount);
                       pager.RecordCount = Convert.ToInt32(countStr);
                       gv.DataSource = db.GetDataTable(sql);
                       gv.DataBind();
                   } break;
               case 2:
                   {
                       string sqlCount = "select count(*) from t_user WHERE ROLEID=2";
                       string sql = "with TUSER as (SELECT (case when AREA='jt' then '金堂县' when  AREA='sl' then '双流县' when AREA='xj' then '新津县' when AREA='qbj' then '青百江区' when AREA='lqy' then '龙泉驿区' end) as ADDRESS,USERNAME,LOGINNAME,PHONE,Row_Number() over(order by ID desc) as row_number FROM t_user WHERE ROLEID=2) select * FROM TUSER where row_number>{0} and row_number<={1}  ";
                       sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
                       DataBase db = new DataBase();
                       string countStr = db.ExecuteValue(sqlCount);
                       pager.RecordCount = Convert.ToInt32(countStr);
                       gv.DataSource = db.GetDataTable(sql);
                       gv.DataBind();
                   } break;
               case 3:
                   {
                       string sqlCount = "select count(*) from t_user WHERE ROLEID=3";
                       string sql = "with TUSER as (SELECT (case when AREA='jt' then '金堂县' when  AREA='sl' then '双流县' when AREA='xj' then '新津县' when AREA='qbj' then '青百江区' when AREA='lqy' then '龙泉驿区' end) as ADDRESS,USERNAME,LOGINNAME,PHONE,Row_Number() over(order by ID desc) as row_number FROM t_user WHERE ROLEID=3) select * FROM TUSER where row_number>{0} and row_number<={1}  ";
                       sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
                       DataBase db = new DataBase();
                       string countStr = db.ExecuteValue(sqlCount);
                       pager.RecordCount = Convert.ToInt32(countStr);
                       gv.DataSource = db.GetDataTable(sql);
                       gv.DataBind();
                   } break;
               case 4:
                   {
                       string sqlCount = "select count(*) from t_user "+whereStr ;
                       string sql = "with TUSER as (SELECT (case when AREA='jt' then '金堂县' when  AREA='sl' then '双流县' when AREA='xj' then '新津县' when AREA='qbj' then '青百江区' when AREA='lqy' then '龙泉驿区' end) as ADDRESS,USERNAME,LOGINNAME,PHONE,UNITNAME,Row_Number() over(order by ID desc) as row_number FROM t_user " + whereStr + ") select * FROM TUSER where row_number>{0} and row_number<={1}  ";
                       sql = string.Format(sql, (pager.CurrentPageIndex - 1) * pager.PageSize, pager.CurrentPageIndex * pager.PageSize);
                       
                       DataBase db = new DataBase();
                       string countStr = db.ExecuteValue(sqlCount);
                       pager.RecordCount = Convert.ToInt32(countStr);
                       gv.DataSource = db.GetDataTable(sql);
                       gv.DataBind();
                   } break;
               default: break;
           }
         
       }

       public bool updatePassword(string loginName, string oldPassword, string password)
       {
           string sql = "select   count(*) from t_user where LOGINNAME=@LOGINNAME AND PASSWORD=@OLDPASSWORD";
           SqlParameter[] param=new SqlParameter[2];
           
           param[0] = new SqlParameter("@OLDPASSWORD", SqlDbType.VarChar, 50);
           param[0].Value = oldPassword;
           param[1] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param[1].Value = loginName;

           DataBase db = new DataBase();
           if (db.ExecuteValue(sql, param) == "1")
           {
               SqlParameter[] param1=new SqlParameter[3];
               param1[0] = new SqlParameter("@password", SqlDbType.VarChar, 50);
           param1[0].Value = password ;
                  param1[1] = new SqlParameter("@OLDPASSWORD", SqlDbType.VarChar, 50);
           param1[1].Value = oldPassword;
           param1[2] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param1[2].Value = loginName;
              
               if(db.ExecuteSql("update t_user set PASSWORD=@password where LOGINNAME=@LOGINNAME AND PASSWORD=@OLDPASSWORD",param1)==1)
               return true;
           }


           return false;

       }


       /// <summary>
       /// 判断是否具有回复评论的权限
       /// </summary>
       /// <param name="loginName"></param>
       /// <returns></returns>
       public bool hasReplyPower(string loginName)
       {
           String sql = "select count(*) from t_user where LOGINNAME=@LOGINNAME and ROLEID in (2,3)";
           DataBase db = new DataBase();

           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param[0].Value = loginName;

           if(db.ExecuteValue(sql,param) == "1")
           {
               return true;
           }
           return false;
                              
       }

       /// <summary>
       /// 根据用户登录名获取用户权限
       /// </summary>
       /// <returns></returns>
       public string getRoleByLoginName(string loginName)
       {
           string role = "";
           String sql = "select ROLEID from t_user where LOGINNAME=@LOGINNAME";
           DataBase db = new DataBase();

           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param[0].Value = loginName;
           
           role = db.ExecuteValue(sql,param);
           return role;
       }


       public bool delete(UserEntity en)
       {
           string sql = "delete from t_user where loginName=@LOGINNAME";
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 50);
           param[0].Value = en.LoginName;
           DataBase db = new DataBase();
           if (db.ExecuteSql(sql, param)==1)
           {
               return true;
           }
           return false;

       }


       public DataTable getUserByLogiNname(String loginName)
       {
           DataTable dt = new DataTable();
           string sql = "SELECT * from t_user where LOGINNAME=@LOGINNAME";
           SqlParameter[] param = new SqlParameter[1];
           param[0] = new SqlParameter("@LOGINNAME", SqlDbType.VarChar, 200);
           param[0].Value = loginName;
           DataBase db = new DataBase();
           dt = db.GetDataTable(sql, param);
           return dt;
       }         
          
    }

}
