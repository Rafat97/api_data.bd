using api_data_bd.Utiles.Static;
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
            if (!AuthAdminUser.isAdminLogIn())
            {
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                                       {
                                       { "action", "Error" },
                                       { "controller", "Home" }
                                       }

                    );
                filterContext.HttpContext.Response.StatusCode = 404;
            }
           
        }

    }
    public class AdminAuthrizationRedirect : AuthorizeAttribute
    {
        private string Action;
        private string Controller;
        public AdminAuthrizationRedirect(string action , string controller)
        {
            this.Action = action;
            this.Controller = controller;
        }
    

        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            if (AuthAdminUser.isAdminLogIn())
            {
                filterContext.Result = new RedirectToRouteResult(

                    new RouteValueDictionary
                                       {
                                       { "action", this.Action },
                                       { "controller", this.Controller }
                                       }

                    );
            }

        }

    }
}