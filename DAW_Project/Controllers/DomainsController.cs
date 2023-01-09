using DAW_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DAW_Project.Models;
using System.Drawing.Printing;
using System.Collections.Specialized;
using Microsoft.EntityFrameworkCore;

namespace DAW_Project.Controllers
{
    [Authorize(Roles = "Editor,Admin")]
    public class DomainsController : Controller
    {
        private readonly ApplicationDbContext db;

        public DomainsController(ApplicationDbContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            if (TempData.ContainsKey("message"))
            {
                ViewBag.message = TempData["message"].ToString();
            }

            var domains = from domain in db.Domains
                             orderby domain.Domain_name
                             select domain;
            ViewBag.Domains = domains;
            return View();
        }

        [Authorize(Roles = "Editor,Admin")]
        public ActionResult Show(int id)
        {
            
             Domain domain = db.Domains.Find(id);
            var articles = db.Articles.Include("Domain")
            .Include("User").OrderByDescending(a => a.Post_Date);

            List<int> articleIds = db.Articles.Where(at =>  at.Domain_id == id ).Select(a => a.Article_Id).ToList();

            ///lista cu articolele care au domeniul respectiv

            List<int> mergedIds = articleIds.ToList();
            articles = db.Articles.Where(article =>
            mergedIds.Contains(article.Article_Id))
            .Include("Domain")
            .Include("User")
            .OrderBy(a => a.Post_Date);

            ViewBag.Articles = articles;

            return View(domain);
        }
        [Authorize(Roles = "Admin")]
        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult New(Domain dom)
        {
            try
            {
                db.Domains.Add(dom);
                db.SaveChanges();
                TempData["message"] = "Domeniul a fost adaugat";
                return RedirectToAction("Index");
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(dom);
            
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            Domain domain = db.Domains.Find(id);
            return View(domain);
        }

        [HttpPost]
        public ActionResult Edit(int id, Domain requestDomain)
        {
            Domain domain = db.Domains.Find(id);
            var errors = ModelState.Where(x => x.Value.Errors.Any())
                .Select(x => new { x.Key, x.Value.Errors });
            if (ModelState.IsValid)
            {
                domain.Domain_name = requestDomain.Domain_name;
                domain.Domain_description = requestDomain.Domain_description;
                db.SaveChanges();
                TempData["message"] = "Domeniul a fost modificat!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(requestDomain);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public ActionResult Delete(int id)
        {
            Domain domain = db.Domains.Find(id);
            db.Domains.Remove(domain);
            TempData["message"] = "Domeniul a fost sters";
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
