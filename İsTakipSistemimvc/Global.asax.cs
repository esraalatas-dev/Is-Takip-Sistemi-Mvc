using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using IsTakipSistemiMvc; // <-- BU SATIR ÇOK ÖNEMLİ (RouteConfig'i bulması için)

namespace IsTakipSistemiMvc
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

           
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}