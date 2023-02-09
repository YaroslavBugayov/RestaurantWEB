using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PL.Models;
using System;
using System.Diagnostics;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace PL.Controllers
{
    public class AuthController : Controller
    {
        IUserService _userService;
        public AuthController(IUserService userService) 
        {
            _userService = userService;
        }
        private ApplicationUserManager UserManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        public ApplicationSignInManager SignInManager
        {
            get => HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
        }
        private IAuthenticationManager AuthenticationManager 
        {
            get => HttpContext.GetOwinContext().Authentication; 
        }
        public ActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await UserManager.FindByEmailAsync(loginModel.Email);

                if (user != null && await UserManager.CheckPasswordAsync(user, loginModel.Password))
                {
                    ClaimsIdentity claim = await UserManager.CreateIdentityAsync(user,
                        DefaultAuthenticationTypes.ApplicationCookie);
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true,
                    }, claim);
                    if (string.IsNullOrEmpty(returnUrl))
                    {
                        return RedirectToAction("Index", "Home");
                    };
                    return Redirect(returnUrl);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login or password");
                }
            }
            ViewBag.ReturnUrl = returnUrl;
            return View(loginModel);

            //UserModel userModel = new UserModel();
            //try
            //{
            //    var userDTO = _userService.Authenticate(loginModel.Email, loginModel.Password);
            //    userModel = MapperService.UserDTOtoModelMapper.Map<UserModel>(userDTO);
            //}
            //catch (Exception ex)
            //{
            //    ViewBag.ErrorMessage = ex.Message;
            //    return View();
            //}
            //FormsAuthentication.SetAuthCookie(userModel.UserName, true);
            //return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }
    }
}