﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BT2.Controllers
{
    public class SinhVien_61133631Controller : Controller
    {
        // GET: SinhVien_61133631
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Index2(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
            
        }
    }
}