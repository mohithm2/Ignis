using Ignis.DAL;
using Ignis.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignis.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        // GET: Users
        [HttpGet]
        public ActionResult SelectRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);


            ViewBag.RoleId = new SelectList(roleManager.Roles.ToList(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SelectRole(SelectRoleViewModel userInput)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleManager = new RoleManager<IdentityRole>(roleStore);
            CreateUserViewModel model = new CreateUserViewModel();

            IgnisModel db = new IgnisModel();

            if (userInput.RoleId == Guid.Parse(roleManager.FindByName("admin").Id))
            {
                model.UserType = "admin";
            }
            else if (userInput.RoleId == Guid.Parse(roleManager.FindByName("ig").Id))
            {
                model.UserType = "ig";
            }
            else if(userInput.RoleId == Guid.Parse(roleManager.FindByName("cfo").Id))
            {
                model.UserType = "cfo";
                ViewBag.InfrastructureId = new SelectList(db.FireStations, "Id", "Name");
            }
            else if (userInput.RoleId == Guid.Parse(roleManager.FindByName("dfo").Id))
            {
                model.UserType = "dfo";
                ViewBag.InfrastructureId = new SelectList(db.Districts, "Id", "Name");
            }
            else if (userInput.RoleId == Guid.Parse(roleManager.FindByName("rfo").Id))
            {
                model.UserType = "rfo";
                ViewBag.InfrastructureId = new SelectList(db.Ranges, "Id", "Name");
            }
            else if (userInput.RoleId == Guid.Parse(roleManager.FindByName("zfo").Id))
            {
                model.UserType = "zfo";
                ViewBag.InfrastructureId = new SelectList(db.Zones, "Id", "Name");
            }


            return View("CreateUser", model);
        }

        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> CreateUser(CreateUserViewModel model)
        {
            ApplicationUserManager userManager = HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            IgnisModel db = new IgnisModel();
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    db.Users.Add(new User
                    {
                        UserId = Guid.Parse(user.Id),
                        InfrastructureId = model.InfrastructureId
                    });
                    db.SaveChanges();
                    userManager.AddToRole(user.Id, model.UserType);
                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            return View(model);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}
