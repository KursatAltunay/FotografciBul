using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FotografciBul.MVC.UI.CustomFilter
{
    public class CustomFilterAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //kullanici girişi varken nasıl davranacağını belirlediğimiz kısım
            if (HttpContext.Current.Session["kullanici"] != null)
            {
                return true;
            }
            return false;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //kullanıcı girişinin olmadığı durumu burada belirtiriz.
            filterContext.Result = new RedirectResult("/User/UserLogin");
        }
    }
}