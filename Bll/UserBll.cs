using System;
using System.Collections.Generic;

using System.Text;
using Model;
using Dal;
using Wuqi.Webdiyer;
using System.Web.UI.WebControls;
using System.Data;

namespace Bll
{
   public class UserBll
    {

       public bool addUser(UserEntity en,int type)
       {
           UserDal userDal = new UserDal();
           if (userDal.addUser(en, type))
           {
               return true;
           }
           return false;
       }
       //=================删除用户
       public bool deleteUser(UserEntity en)
       {
           UserDal dal = new UserDal();
           if (dal.delete(en))
           {return true;
           }
           return false;
       }


       //===================验证用户名是否可用
       public bool isUse(UserEntity en)
       {
           UserDal userDal = new UserDal();
           if (userDal.isUse(en))
           {
               return true;
           }
           return false;
       }

       public bool updateUser(int type, UserEntity en)
       {
           UserDal userDal = new UserDal();
           if(userDal.update(type,en))
           {
               return true;
           }

           return false;
       }

   


       public void bindGridView(GridView gv, AspNetPager pager,int type,String whereStr)
       {
           UserDal userDal = new UserDal();
           userDal.bindGridView(gv, pager, type, whereStr);

       }



       public DataTable selectByLoginName(int type,string  loginName )
       {
           UserDal userDal = new UserDal();
           return userDal.selectByLoginName(type, loginName);
       }

       public DataTable login(UserEntity user)
       {
           UserDal userDal = new UserDal();
           return userDal.login(user);
       }


       public bool updatePassword(string loginName, string oldPassword, string password)
       {
           UserDal userDal = new UserDal();
           if(userDal.updatePassword(loginName,oldPassword,password)){
               return true;
           }
           return false;
       }

       public DataTable selectByID(int type, int userID)
       {
           UserDal dal = new UserDal();
           return dal.selectByID(type, userID);
       }


       public DataTable getUserByLogiNname(String loginName)
       {
           UserDal userDal = new UserDal();
           return userDal.getUserByLogiNname(loginName);
       }

    }
}
