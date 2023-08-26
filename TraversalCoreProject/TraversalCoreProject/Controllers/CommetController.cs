﻿using BussinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

public class CommetController : Controller
{
    CommentManager _commentManager = new CommentManager(new EfCommentDal());
    private readonly UserManager<AppUser> _userManager;

    public CommetController(UserManager<AppUser> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    public  PartialViewResult AddComment()
    {
        //ViewBag.DestID = id;
        //var value = await _userManager.FindByNameAsync(User.Identity.Name);
        //ViewBag.UserID = value.Id;
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
