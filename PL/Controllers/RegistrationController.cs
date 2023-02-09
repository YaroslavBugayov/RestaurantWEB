using BLL.DTO;
using BLL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PL.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class RegistrationController : Controller
    {
        IUserService _userService;
        public RegistrationController(IUserService userService) 
        { 
            _userService = userService;
        }
        private ApplicationUserManager userManager
        {
            get => HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
        }
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Registration(RegisterModel registerModel)
        {
            try
            {
                var userDTO = MapperService.RegModelToUserDTOMapper.Map<UserDTO>(registerModel);
                _userService.CreateUser(userDTO);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View(registerModel);
            }

            ApplicationUser user = new ApplicationUser { UserName = registerModel.Username, Email = registerModel.Email };
            IdentityResult result = await userManager.CreateAsync(user, registerModel.Password);

            if (result.Succeeded)
            { 
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (string error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error);
                }
            }

            return View(registerModel);
        }
    }
}