using DAW_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proiect_DAW.Models;

namespace DAW_Project.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ApplicationDbContext db;
        public ArticlesController(ApplicationDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
           
            var articles = db.Articles;
            ViewBag.Articles = articles;
            
            
            return View();
        }

        public IActionResult Show(int id)
        {
            Article article = db.Articles.Find(id);
            ViewBag.Article = article;
            return View();
        }

        public IActionResult New()
        {
            return View();
        }
        [HttpPost]
        public IActionResult New(Article s)
        {
            try
            {
                db.Articles.Add(s);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }
        }





    }

}
