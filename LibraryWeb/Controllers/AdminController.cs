using LibraryWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LibraryWeb.Controllers
{
    public class AdminController : Controller
    {

        #region Login Actions
        // GET: /Admin/index 
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }


        // GET: /Admin/login 
        [AllowAnonymous]
        public ActionResult Login()
        {
            LoginViewModel model = new LoginViewModel();
            return View(model);
        }

        // POST: /Account/Login 
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl)
        {
            if (IsValidUser(model))
            {
                FormsAuthentication.SetAuthCookie(model.UserName, true);
                if (this.Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                else
                {
                    return RedirectToAction("Index", "BookList");
                }
            }

            // If we got this far, something failed, redisplay form 
            this.ModelState.AddModelError("", "Incorrect username or password.");
            return View(model);
        }

        // GET: /Admin/Logout 
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
        #endregion

        #region Reusable Methods
        private bool IsValidUser(LoginViewModel model)
        {
            return this.ModelState.IsValid && FormsAuthentication.Authenticate(model.UserName, model.Password);
        }
        #endregion
    }
}