using AutoMapper;
using BussinessLayer.Abstract;
using DTOLayer.DTOs.AnnouscementDTOs;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TraversalCoreProject.Areas.Admin.Models;

namespace TraversalCoreProject.Areas.Admin.Controllers
{
    [Area("Admin")]

    [AllowAnonymous]
    public class AnnouncementController : Controller
    {
        private readonly IAnnouncementService _announcementService;
        private readonly IMapper _mapper;

        public AnnouncementController(IAnnouncementService announcementService, IMapper mapper)
        {
            _announcementService = announcementService;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            var values = _mapper.Map<List<AnnouncementListDto>>(_announcementService.TGetList());
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAnnouncement()
        {

            return View();

        }
        [HttpPost]
        public IActionResult AddAnnouncement(AddAnnouscementDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TAdd(new Announcement()
                {
                    Content = model.Content,
                    Title = model.Title,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())

                });
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var values = _announcementService.TGetByID(id);
            _announcementService.TDelete(values);

            return RedirectToAction("Index");


        }
        [HttpGet]
        public IActionResult Update(int id)

        {
            var values = _mapper.Map<AnnounscementUpdateDto>(_announcementService.TGetByID(id));

            return View(values);

        }
        [HttpPost]

        public IActionResult Update(AnnounscementUpdateDto model)
        {
            if (ModelState.IsValid)
            {
                _announcementService.TUpdate(new Announcement
                {
                    AnnouncemntID = model.AnnouncemntID,
                    Title = model.Title,
                    Content = model.Content,
                    Date = Convert.ToDateTime(DateTime.Now.ToShortDateString())



                }); ;
                 
                return RedirectToAction("Index");
            }
            return View(model);


        }
    }
}
