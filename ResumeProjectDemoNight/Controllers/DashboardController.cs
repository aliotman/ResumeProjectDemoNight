using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.Controllers
{
    public class DashboardController : Controller
    {
        private readonly ResumeContext _context;

        public DashboardController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Dashboard()
        {
            ViewData["ActiveMenu"] = "Dashboard";
            ViewData["PageTitle"] = "Kontrol Paneli";
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.TotalServices = _context.Services.Count();
            ViewBag.TotalExperiences = _context.Experiences.Count();
            ViewBag.TotalMessages = _context.Messages.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => x.IsRead == false);
            ViewBag.About = _context.Abouts.FirstOrDefault();
            return View();
        }
    }
}
