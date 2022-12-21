using DAW_Project.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using DAW_Project.Models;

namespace DAW_Project.Controllers
{
    [Authorize(Roles = "Admin")]
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

        public ActionResult Show(int id)
        {
            Domain domain = db.Domains.Find(id);
            return View(domain);
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
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

        public ActionResult Edit(int id)
        {
            Domain domain = db.Domains.Find(id);
            return View(domain);
        }

        [HttpPost]
        public ActionResult Edit(int id, Domain requestDomain)
        {
            Domain domain = db.Domains.Find(id);

            if (ModelState.IsValid)
            {

                domain.Domain_name = requestDomain.Domain_name;
                db.SaveChanges();
                TempData["message"] = "Domeniul a fost modificat!";
                return RedirectToAction("Index");
            }
            else
            {
                return View(requestDomain);
            }
        }

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
