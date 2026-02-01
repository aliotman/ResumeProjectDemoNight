using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ResumeContext _context;

        public ServiceController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult ServiceList()
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "Service";
            ViewData["PageTitle"] = "Hizmetler";
            var values=_context.Services.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateService()
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "Service";
            ViewData["PageTitle"] = "Hizmet Listesi";
            return View();
        }

        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }
        [HttpGet]
        public IActionResult UpdateService(int id)
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "Service";
            ViewData["PageTitle"] = "Hizmet Düzenle";
            var value = _context.Services.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return RedirectToAction("ServiceList");
        }


    }
}
