using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.ViewComponents.Default.Comment
{
    public class _AddComment:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
