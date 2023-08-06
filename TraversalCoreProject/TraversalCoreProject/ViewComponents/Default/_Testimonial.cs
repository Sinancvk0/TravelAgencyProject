using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default
{
    public class _Testimonial:ViewComponent
    {
        TestimonialManager _testimonial = new TestimonialManager(new EfTestimonialDal());
        public IViewComponentResult Invoke()
        {
          
            var values=_testimonial.TGetList();
            return View(values);
        }
    }
}
