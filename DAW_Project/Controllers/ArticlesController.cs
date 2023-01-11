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

        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Index()
        {
           
            var articles = db.Articles.Include("Domain")
             .Include("User").OrderByDescending(a => a.Post_Date);
           
            var search = "";
            // MOTOR DE CAUTARE
            if (Convert.ToString(HttpContext.Request.Query["search"]) != null)
            {
                // eliminam spatiile libere 
                search = Convert.ToString(HttpContext.Request.Query["search"]).Trim();


                // Cautare in articol (Title si Content)
                List<int> articleIds = db.Articles.Where (at =>  at.Editor_Name.Contains(search) || at.Title.Contains(search) || at.Content.Contains(search) || at.Domain.Domain_name.Contains(search)).Select(a => a.Article_Id).ToList();


                List<int> mergedIds = articleIds.ToList();
                // Lista articolelor care contin cuvantul cautat
                // fie in articol -> Title si Content
                // fie in comentarii -> Content
                articles = db.Articles.Where(article =>
               mergedIds.Contains(article.Article_Id))
                .Include("Domain")
                .Include("User")
                .OrderBy(a => a.Post_Date);


            }
            ViewBag.SearchString = search;
         
            ViewBag.Articles = articles;


            return View();
        }


        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Show(int id)
        {
            Article article = db.Articles.Find(id);
            Domain domain = db.Domains.Find(article.Domain_id);
            ViewBag.Article = article;
            ViewBag.Domain = domain;
            return View();
        }

        
         public IEnumerable<SelectListItem> GetAllDomains()
        {
            // generam o lista de tipul SelectListItem fara elemente
            var selectList = new List<SelectListItem>();
            
            // extragem toate categoriile din baza de date
            var categories = from dom in db.Domains
                             select dom;

            // iteram prin categorii
            foreach (var category in categories)
            {
                // adaugam in lista elementele necesare pentru dropdown
                // id-ul categoriei si denumirea acesteia
                selectList.Add(new SelectListItem
                {
                    Value = category.Id.ToString(),
                    Text = category.Domain_name.ToString()
                });
            }
            /* Sau se poate implementa astfel: 
             * 
            foreach (var category in categories)
            {
                var listItem = new SelectListItem();
                listItem.Value = category.Id.ToString();
                listItem.Text = category.CategoryName.ToString();

                selectList.Add(listItem);
             }*/


            // returnam lista de categorii
            return selectList;
        }

        [Authorize(Roles = "Editor,Admin")]
        public IActionResult New()
        {
            Article article = new Article();

            // Se preia lista de categorii din metoda GetAllCategories()
            article.Dom = GetAllDomains();
            

            return View(article);
        }

        // Se adauga articolul in baza de date
        // Doar utilizatorii cu rolul de Editor sau Admin pot adauga articole in platforma

        [Authorize(Roles = "Editor,Admin")]
        [HttpPost]

        public IActionResult New(Article article)
        {
            var sanitizer = new HtmlSanitizer();

            article.Post_Date = DateTime.Now;
            article.UserID = _userManager.GetUserId(User);
            article.Editor_Name = _userManager.GetUserName(User);


            if (ModelState.IsValid)
            {

                article.Content = sanitizer.Sanitize(article.Content);
                db.Articles.Add(article);
                db.SaveChanges();
                TempData["message"] = "Articolul a fost adaugat";
                return RedirectToAction("Index");
            }
            else
            {
                article.Dom = GetAllDomains();
                return View(article);
            }
        }

        [HttpPost]
        [Authorize(Roles = "Editor,Admin")]
       
        public IActionResult Delete(int id)
        {
            Article article = db.Articles.Find(id);
            db.Articles.Remove(article);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Edit(int id)
        {

            Article article = db.Articles.Include("Domain")
                                        .Where(art => art.Article_Id == id)
                                        .First();

            article.Dom = GetAllDomains();

            if (article.UserID == _userManager.GetUserId(User) || User.IsInRole("Admin") || User.IsInRole("Editor")) 
            {
                return View(article);
            }

            else
            {
                TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                return RedirectToAction("Index");
            }

        }

        // Se adauga articolul modificat in baza de date
        [HttpPost]
        [Authorize(Roles = "Editor,Admin")]
        public IActionResult Edit(int id, Article requestArticle)
        {
            var sanitizer = new HtmlSanitizer();

            Article article = db.Articles.Find(id);

            var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });

            if (ModelState.IsValid)
            {
                if (article.UserID == _userManager.GetUserId(User) || User.IsInRole("Admin"))
                {
                    article.Title = requestArticle.Title;

                    requestArticle.Content =sanitizer.Sanitize(requestArticle.Content);
                    article.Content = requestArticle.Content;
                    
                    article.Domain_id = requestArticle.Domain_id;
           
                    TempData["message"] = "Articolul a fost modificat";
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["message"] = "Nu aveti dreptul sa faceti modificari asupra unui articol care nu va apartine";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                requestArticle.Dom = GetAllDomains();
                return View(requestArticle);
            }
        }

    }
    
         
}
