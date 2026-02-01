using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;
using ResumeProjectDemoNight.Entities;

namespace ResumeProjectDemoNight.Controllers
{
    public class TestimonialController : Controller
    {
        private readonly ResumeContext _context;

        public TestimonialController(ResumeContext context)
        {
            _context = context;
        }

        public IActionResult TestimonialList()
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            ViewData["ActiveMenu"] = "TestimonialList";
            ViewData["PageTitle"] = "Referanslar";
            var values=_context.Testimonials.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult CreateTestimonial()
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            return View();
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Add(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }

        [HttpGet]
        public IActionResult UpdateTestimonial(int id)
        {
            ViewBag.TotalProjects = _context.Portfolios.Count();
            ViewBag.UnreadMessages = _context.Messages.Count(x => !x.IsRead);
            var value = _context.Testimonials.Find(id);
            return View(value);
        }
        [HttpPost]
        public IActionResult UpdateTestimonial(Testimonial testimonial)
        {
            _context.Testimonials.Update(testimonial);
            _context.SaveChanges();
            return RedirectToAction("TestimonialList");
        }


    }
}
