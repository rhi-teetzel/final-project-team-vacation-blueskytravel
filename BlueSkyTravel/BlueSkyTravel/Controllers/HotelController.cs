﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlueSkyTravel.Models;
using BlueSkyTravel.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace BlueSkyTravel.Controllers
{
    public class HotelController : Controller
    {
        IRepository<Hotel> hotelRepo;

        public HotelController(IRepository<Hotel> hotelRepo)
        {
            this.hotelRepo = hotelRepo;
        }
        // GET: Hotel
        [Authorize]
        public ViewResult Index()
        {
            var model = hotelRepo.GetAll();
            return View(model);
        }

        // GET: Hotel/Details/5
        [Authorize]
        public ViewResult Details(int id)
        {
            var model = hotelRepo.GetById(id);
            return View(model);
        }

        // GET: Hotel/Create
        [HttpGet]
        [Authorize]
        public ActionResult CreateByItineraryId(int id)
        {
            ViewBag.ItineraryId = id;
            return View();
        }

        // POST: Hotel/Create
        [HttpPost]
        [Authorize]
        public IActionResult Create(Hotel hotel)
        {
            hotelRepo.Create(hotel);
            return RedirectToAction("Details", "Itinerary", new { id = hotel.ItineraryId });
        }

        // GET: Hotel/Edit/5
        [HttpGet]
        [Authorize]
        public ViewResult Update(int id)
        {
            Hotel model = hotelRepo.GetById(id);
            return View(model);
        }

        // POST: Hotel/Edit/5
        [HttpPost]
        [Authorize]
        public IActionResult Update(Hotel hotel)
        {
            hotelRepo.Update(hotel);
            return RedirectToAction("Details", "Itinerary", new { id = hotel.ItineraryId });
        }

        // GET: Hotel/Delete/5
        [HttpGet]
        [Authorize]
        public ActionResult Delete(int id)
        {
            Hotel model = hotelRepo.GetById(id);
            return View(model);
        }

        // POST: Hotel/Delete/5
        [HttpPost]
        [Authorize]
        public IActionResult Delete(Hotel hotel)
        {
            var tempId = hotel.ItineraryId;
            hotelRepo.Delete(hotel);
            return RedirectToAction("Details", "Itinerary", new { id = tempId });
        }
    }
}