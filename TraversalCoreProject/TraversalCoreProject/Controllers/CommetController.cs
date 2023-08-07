using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System;

public class CommetController : Controller
{
    CommentManager _commentManager = new CommentManager(new EfCommentDal());

    [HttpGet]
    public PartialViewResult AddComment()
    {
        return PartialView();
    }

    [HttpPost]
    public IActionResult AddComment(Comment p)
    {
        p.CommentDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
        p.CommentState = true;
        _commentManager.TAdd(p);

        return RedirectToAction("Index", "Destination");
    }
}
