using DAW_Project.Data;
using DAW_Project.Models;
using DAW_Project.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Linq;
using Ganss.Xss;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace DAW_Project.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;

            _userManager = userManager;

            _roleManager = roleManager;
        }
    
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            /// var user_roles = db.UserRoles;
            var users = db.Users;
            ViewBag.Users = users;
            /// ViewBag.UserRoles = user_roles;
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(string id)
        {

            var user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }
        /*
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult ChangeRole(string id)
        {
            var editorRole_id = "3f81d37a-57d8-4b84-a007-151284bc5019";
            var userRole_id = "9070d330-24fb-47eb-8acd-7b4f78f53675";
            var user = db.UserRoles.Where(u => u.UserId == id).FirstOrDefault();
            if(user.RoleId == editorRole_id)
            {
                user.RoleId = userRole_id;
            }
            else if(user.RoleId == userRole_id)
            {
                user.RoleId = editorRole_id;
            }
            db.SaveChanges();
            return RedirectToAction("Index");

        }
        */

    }
}
