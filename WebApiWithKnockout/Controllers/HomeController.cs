﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApiWithKnockout.Models;

namespace WebApiWithKnockout.Controllers
{
    public class HomeController : Controller
    {
        private ReservationRepository repo = new ReservationRepository();

        public ViewResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Add(Reservation item)
        {
            if (ModelState.IsValid)
            {
                repo.Add(item);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }

        public ActionResult Remove(int id)
        {
            repo.Remove(id);
            return RedirectToAction("Index");
        }

        public ActionResult Update(Reservation item)
        {
            if (ModelState.IsValid&&repo.Update(item))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index");
            }
        }
    }
}