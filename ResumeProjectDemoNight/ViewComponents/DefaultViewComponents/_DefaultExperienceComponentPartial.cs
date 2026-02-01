using Microsoft.AspNetCore.Mvc;
using ResumeProjectDemoNight.Context;

namespace ResumeProjectDemoNight.ViewComponents.DefaultViewComponents
{
    public class _DefaultExperienceComponentPartial:ViewComponent
    {
        private readonly ResumeContext _context;

        public _DefaultExperienceComponentPartial(ResumeContext context)
        {
            _context = context;
        }

        public IViewComponentResult Invoke()
        {
            var values=_context.Experiences.ToList();
            return View(values);
        }
    }
}
