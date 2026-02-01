using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class DefaultController : Controller
    {
        private readonly ResumeContext _context;

        public DefaultController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SendMessage(Message messages)
        {
            if (ModelState.IsValid) 
            {
                messages.SendDate= DateTime.Now;
                _context.Add(messages);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Index",messages);
        }
    }
}
