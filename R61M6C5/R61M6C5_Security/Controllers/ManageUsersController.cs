using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using R61M6C5_Security.Models;
using R61M6C5_Security.ViewModels;

namespace R61M6C5_Security.Controllers
{
    public class ManageUsersController : Controller
    {
        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        public ManageUsersController()
        {

        }
        public ManageUsersController(ApplicationUserManager userManager)
        {
            this.UserManager = userManager;
        }
        // GET: ManageUsers
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult MyProfile()
        {
           var user= UserManager.FindByName(User.Identity.Name);
            var profile = new ProfileVM
            {
                 Name=user.Name,
                 Email=user.Email,
                 PhoneNumber=user.PhoneNumber,
                 ProfilePicPath=user.ProfilePicPath
            };
            return View(profile);
        }
        [Authorize]
        public ActionResult AddProfile()
        {
            return View();
        }
        [HttpPost]
        [Authorize]
        public async Task<ActionResult> AddProfile(ProfileVM profileVM)
        {
            var u=User.Identity.Name;
            var uid= User.Identity.GetUserId();
            var user = UserManager.Users.Where(i=>i.Email.Equals(u)).FirstOrDefault();
            if (ModelState.IsValid)
            {
                string ext = Path.GetExtension(profileVM.ProfilePic.FileName);
                if (ext == ".jpg" || ext == ".png" || ext == ".jpeg")
                {
                    string root = Server.MapPath("~/");
                    string dir = Path.Combine(root, "ProfilePic");
                    if (!Directory.Exists(dir))
                    {
                        Directory.CreateDirectory(dir);
                    }
                    string fileTosave = Path.Combine(dir, profileVM.Name + ext);

                    profileVM.ProfilePic.SaveAs(fileTosave);
                    profileVM.ProfilePicPath = "~/ProfilePic/" + profileVM.Name + ext;
                    
                    user.Name=profileVM.Name;
                    user.ProfilePicPath=profileVM.ProfilePicPath;
                    user.PhoneNumber = profileVM.PhoneNumber;
                IdentityResult result=  await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("MyProfile");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Please Provide valid pic .jpg|.png|.jpeg");
                    return View(profileVM);
                }
            }
            else
            {
                return View(profileVM);
            }
            return View();
        }
    }
}