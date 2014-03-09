using System;
using System.Collections.Generic;

using System.Text;
using Dal;

namespace Bll
{
  public   class ResourcesBll
    {
      public void initResource()
      {
          ResourcesDal dal = new ResourcesDal();
          dal.initResource();
      
      }
    }
}
