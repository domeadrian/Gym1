using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gym2.Controllers
{
    [Authorize]
    public class ControllerBase : Controller
    {

        protected const string Key = "gym";

        public Library.Database Db
        {
            get
            {
                var httpContext = System.Web.HttpContext.Current;

                if (httpContext != null)
                {
                    var key = Key + "Db";
                    var value = httpContext.Items[key] as Library.Database;
                    if (value == null)
                    {
                        value = new Library.Database();
                        value.Database.CommandTimeout = 60;
                        httpContext.Items[key] = value;
                        httpContext.AddOnRequestCompleted(cx =>
                        {
                            cx.Items.Remove(key);
                            value.Dispose();
                        });
                    }
                    return value;
                }
                else throw new Exception("Current HttpContext Not Found!");
            }
        }

        // public virtual new CustomPrincipal User
        //{
        //    get
        //    {
        //        return (CustomPrincipal)base.User;
        //    }
        //}

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
        }
        public ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        public IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}