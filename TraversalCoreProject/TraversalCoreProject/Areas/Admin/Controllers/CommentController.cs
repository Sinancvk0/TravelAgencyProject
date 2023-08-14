using BussinessLayer.Abstract;
using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values=_commentService.TGetCommentWithDestination();
            return View(values);
        }

        public IActionResult Delete( int id)
        {
            var values=_commentService.TGetByID(id);
             _commentService.TDelete(values);

            return RedirectToAction("Index");
        }
    }
}
