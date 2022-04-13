using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bt2.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        public ActionResult Register1()
        {
            return View();
        }
        public ActionResult Register2()
        {
            return View();
        }
        [HttpPost]
        
        public ActionResult Register2(FormCollection field)
        {
            ViewBag.Id = field["Id"];
            ViewBag.Name = field["Name"];
            ViewBag.Marks = field["Marks"];
            return View(ViewBag);
        }

    }
}