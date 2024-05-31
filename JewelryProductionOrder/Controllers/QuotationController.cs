﻿using JewelryProductionOrder.Data;
using JewelryProductionOrder.Models;
using Microsoft.AspNetCore.Mvc;

namespace SWP391.Controllers
{
    public class QuotationController : Controller

    {
        private readonly ApplicationDbContext _db;
        public QuotationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            //List<QuotationRequest> requests = _db.QuotationRequests.ToList();
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }
        //[HttpPost]
        //public IActionResult Create(QuotationRequest quotationobj)
        //{
        //if (quotationobj.Id > 0)
        //{
        //ModelState.AddModelError("")
        //}
        //if(ModelState.IsValid)
        //{

        //}
        // return View();
        //}
        [HttpPost,ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            QuotationRequest quorequest = _db.QuotationRequests.Find(id);
            if (quorequest == null) {
                return NotFound();
             }
            _db.QuotationRequests.Remove(quorequest);
            _db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}