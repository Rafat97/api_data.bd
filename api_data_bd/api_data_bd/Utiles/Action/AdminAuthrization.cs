using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace api_data_bd.Utiles.Action
{
    public class AdminAuthrization : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            System.Diagnostics.Debug.WriteLine(HttpContext.Current.Session["AdminUserID"]);
            if (HttpContext.Current.Session["AdminUserID"] == null)
            {
                System.Diagnostics.Debug.WriteLine("AdminUserID null");
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                                       {
                                       { "action", "Error" },
                                       { "controller", "Home" }
                                       }

                    );
                filterContext.HttpContext.Response.StatusCode = 404;
                //filterContext.HttpContext.Response.End();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("AdminUserID not null");
                //Code HERE for page level authorization  

            }
           
        }




    }
}