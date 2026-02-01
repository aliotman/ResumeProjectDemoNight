using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class AboutController : Controller
    {
        private readonly ResumeContext _context;

        public AboutController(ResumeContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult UpdateAbout(int id)
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "About";
            ViewData["PageTitle"] = "Hakkımda";
            var value = _context.Abouts.Find(id);
            return View(value);
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about)
        {
            _context.Abouts.Update(about);
            _context.SaveChanges();
            return RedirectToAction("Dashboard","Dashboard");
        }
    }
}
