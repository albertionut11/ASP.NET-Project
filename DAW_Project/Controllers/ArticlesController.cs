using DAW_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


    }
    
}
