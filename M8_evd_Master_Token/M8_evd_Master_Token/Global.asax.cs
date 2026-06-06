using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Newtonsoft.Json;

namespace M8_evd_Master_Token
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configuration.Formatters
      .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
      = ReferenceLoopHandling.Ignore;
        }
    }
}
