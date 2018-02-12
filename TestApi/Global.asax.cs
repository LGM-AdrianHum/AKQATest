using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using NLog;


namespace TestApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        protected void Application_Start()
        {
            logger.Info("web application starting");
            GlobalConfiguration.Configure(WebApiConfig.Register);
           
        }
    }
}
