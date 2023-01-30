using BLL.Interfaces;
using BLL.Services;
using PL.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;

namespace PL.Controllers
{
    public class AuthController : Controller
    {
        IUserService _userService;
        public AuthController(IUserService userService) 
        {
            _userService = userService;
        }
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            UserModel userModel = new UserModel();
            try
            {
                var userDTO = _userService.Authenticate(username, password);
                userModel = MapperService.UserDTOtoModelMapper.Map<UserModel>(userDTO);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View();
            }
            FormsAuthentication.SetAuthCookie(userModel.UserName, true);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}