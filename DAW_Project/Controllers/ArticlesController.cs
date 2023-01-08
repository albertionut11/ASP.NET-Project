using DAW_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DAW_Project.Models;
using System.Data;
using Microsoft.AspNetCore.Identity;

namespace DAW_Project.Controllers
{
    public class ArticlesController : Controller
    {


        private readonly ApplicationDbContext _context;
        private readonly ApplicationDbContext db;

        private readonly UserManager<ApplicationUser> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public ArticlesController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager
            )
        {
            db = context;

            _userManager = userManager;

            _roleManager = roleManager;
        }

        [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Index()
        {

            var articles = db.Articles;
            ViewBag.Articles = articles;


            return View();
        }


        [Authorize(Roles = "User,Editor,Admin")]
        public IActionResult Show(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            return View();
        }

        [Authorize(Roles = "Editor,Admin")]
        public IActionResult New()
        {
            Article article = new Article();

           

            return View(article);
        }

        // Se adauga articolul in baza de date
        // Doar utilizatorii cu rolul de Editor sau Admin pot adauga articole in platforma

        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]
        public IActionResult New(Article article)
        {
            article.Post_Date = DateTime.Now;
            article.UserID = _userManager.GetUserId(User);
            article.Editor_Name = _userManager.GetUserName(User);
         
            try
            {
                db.Articles.Add(article);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(article);
            
        }


        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Edit(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            return View();
        }
        [HttpPost]
        [Authorize(Roles = "Editor,Admin")]
        public ActionResult Edit(int id, Article requestArticle)
        {
            Article article = db.Articles.Find(id);
            try
            {
                article.Title = requestArticle.Title;
                article.Editor_Name = requestArticle.Editor_Name;
                article.Content = requestArticle.Content;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Edit", article.Article_Id);
            }
        }

        public IActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
    
         
}
