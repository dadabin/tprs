<%@ Application Language="C#" %>

<script runat="server">

    void Application_Start(object sender, EventArgs e) 
    {
        // 在应用程序启动时运行的代码
        InitDataBase initDataBase = new InitDataBase();
        initDataBase.initDataBase();
        
    }
    
    void Application_End(object sender, EventArgs e) 
    {
        //  在应用程序关闭时运行的代码

    }
        
    void Application_Error(object sender, EventArgs e) 
    { 
        // 在出现未处理的错误时运行的代码
        ErrorLogin errorLogin = new ErrorLogin();
        

    }

    void Session_Start(object sender, EventArgs e) 
    {
        // 在新会话启动时运行的代码

    }

    void Session_End(object sender, EventArgs e) 
    {
        // 在会话结束时运行的代码。 
        // 注意: 只有在 Web.config 文件中的 sessionstate 模式设置为 InProc 时，才会引发 Session_End 事件。
        // 如果会话模式设置为 StateServer 
        // 或 SQLServer，则不会引发该事件。
        //处理绑定的数据
        SessionEnd sessionEnd = new SessionEnd();
        sessionEnd.resourcesDispose();
    }
    
    /// <summary>
    /// 处理访问url
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void Application_BeginRequest(object sender, EventArgs e)
    {
        string strfilepath = base.Request.FilePath; //Request.Url.ToString();
        string names = strfilepath.Substring(strfilepath.LastIndexOf(@"/")+1 );
       // Response.Write("||"+names);
        if (strfilepath == "/WebSite5/Admin"||strfilepath=="/WebSite5/Admin/")
        {
           base.Response.Redirect("/WebSite5/login.aspx");
        }
       
   
    }
       
</script>
