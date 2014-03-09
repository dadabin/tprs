using System;
using System.Collections.Generic;

using System.Text;

namespace Dal
{
   public class ResourcesDal
    {

       public void initResource()
       {
           String sql = "begin update t_itemst set STATECHANGE = null;update t_itemjg set STATECHANGE = null;    end";
           DataBase db = new DataBase();
           db.ExecuteSql(sql);
       }

       
    }
}
