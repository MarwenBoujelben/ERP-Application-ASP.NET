using EntrepriseRessourcesPlanning.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EntrepriseRessourcesPlanning.Controllers
{
    public class AccountController : Controller
    {
        private readonly ContextDB _context;

        public AccountController()
        {
            _context = new ContextDB();
        }
        
        public ActionResult SignIn()
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            return View();
        }
        
        public ActionResult SigningIn(string Username,string Password)
        {
            
            if (Username != null && Password != null)
            {
                
                var user = _context.Users.FirstOrDefault(u => u.Username == Username);
                if (user!=null)
                {
                    if (user.Password==Password)
                    {
                        
                        Response.Cookies.Add(new HttpCookie("AuthCookie", "true"));
                        string sessionId = Guid.NewGuid().ToString();
                        Session["SessionId"] = sessionId;
                        var userDB = _context.Users.FirstOrDefault(u => (u.Username == Username) && (u.Password == Password));
                        if(userDB != null)
                        {
                            Session["UserCIN"] = userDB.UserCIN;
                            Session["Username"] = Username;
                        }
                        return RedirectToAction("AllProductsData", "Home");
                    }
                }
               
            }
            return View("SignIn");

        }
        
            public ActionResult SignOut()
            {
            // Remove the authentication cookie
            /*if (Request.Cookies["AuthCookie"] != null)
            {
                Response.Cookies["AuthCookie"].Expires = DateTime.Now.AddDays(-1);
            }*/
            Session["UserCIN"] = null;
            Session.Clear();
            Session.Abandon();
           
            return RedirectToAction("SignIn","Account");
            }
        
    }
}