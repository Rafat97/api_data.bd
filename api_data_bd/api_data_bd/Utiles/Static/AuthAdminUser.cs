using api_data_bd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace api_data_bd.Utiles.Static
{
    public class AuthAdminUser
    {

        private static string AUTH_ADMIN_COOKIE_NAME = "AdminUserId";
        private static ApplicationDbContext db = AppDatabase.getInstence().getDatabase();

        //
        // Summary:
        //     Set User login Cookie paramiter `userId`
        //
        // Returns:
        //     The HttpCookie object.
        public static HttpCookie setUserInCookie(string userId)
        {
            HttpCookie AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_NAME);
            AdminLoginCookie.Value = userId;
            AdminLoginCookie.Expires = DateTime.Now.AddDays(30);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);
            return AdminLoginCookie;
        }

        public static AdminUsers getAdminUser()
        {
            var userId = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_NAME);
            int id = Convert.ToInt32(userId.Value);
            AdminUsers adminUsers = db.AdminUsers.Find(id);
            return adminUsers;
        }
        public static HttpCookie signOutAdminUser()
        {
            HttpCookie AdminLoginCookie = new HttpCookie(AUTH_ADMIN_COOKIE_NAME);
            AdminLoginCookie.Value = "";
            AdminLoginCookie.Expires = DateTime.Now.AddDays(-1);
            AdminLoginCookie.HttpOnly = true;
            HttpContext.Current.Response.Cookies.Add(AdminLoginCookie);
            return AdminLoginCookie;
        }
        public static bool isAdminLogIn()
        {
            HttpCookie userId = HttpContext.Current.Request.Cookies.Get(AUTH_ADMIN_COOKIE_NAME);
            if (userId != null)
                return true;
            else
                return false;
        }
    }
}