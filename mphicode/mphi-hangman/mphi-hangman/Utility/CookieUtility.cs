using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mphi_hangman.Utility
{
    public class CookieUtility
    {
        // adds a cookie
        public static void AddCookie(System.Web.HttpContextBase httpContext, string cookieName, string value)
        {
            HttpCookie cookie = new HttpCookie(cookieName);
            cookie.Value = value;
            cookie.Expires = DateTime.Now.AddDays(7); //expires in 7 days
            httpContext.Response.Cookies.Add(cookie);
        }

        // deletes a cookie
        public static void DeleteCookie(System.Web.HttpContextBase httpContext, string cookieName)
        {
            if (httpContext.Request.Cookies.AllKeys.Contains(cookieName))
            {
                HttpCookie cookie = httpContext.Request.Cookies[cookieName];
                cookie.Expires = DateTime.Now.AddDays(-1);
                httpContext.Response.Cookies.Add(cookie);
            }
        }

        // get a cookie
        public static string GetCookie(System.Web.HttpContextBase httpContext, string cookieName)
        {
            if (httpContext.Request.Cookies.AllKeys.Contains(cookieName))
            {
                return httpContext.Request.Cookies[cookieName].Value;
            }
            
            throw new Exception("Cookie does not exist for name:" + cookieName);
        }
    }
}