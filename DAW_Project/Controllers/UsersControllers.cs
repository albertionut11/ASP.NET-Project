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

            var users = db.Users;
            ViewBag.Users = users;
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

    }
}
