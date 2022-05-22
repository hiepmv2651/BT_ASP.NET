using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KT0720hiep_61133631.Models;

namespace KT0720hiep_61133631.Controllers
{
    public class SinhVien0720_61133631Controller : Controller
    {
        // GET: SinhVien0720_61133631
        private KT0720_61133631Entities db = new KT0720_61133631Entities();

        public ActionResult GioiThieu()
        {
            return View();
        }

        public ActionResult TimKiem(string maSV = "", string HoTen = "")
        {
            ViewBag.MASV = maSV;
            ViewBag.HOTEN = HoTen;

            var sINHVIENs = db.SINHVIENs.SqlQuery("SinhVien_TimKiem'" + maSV + "','" + HoTen + "'");
            if (sINHVIENs.Count() == 0)
                ViewBag.TB = "Không có thông tin tìm kiếm.";
            return View(sINHVIENs.ToList());

        }
        public ActionResult Index()
        {
            var sinhViens = db.SINHVIENs.Include(s => s.LOP);
            return View(sinhViens.ToList());
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        public ActionResult Create()
        {
            ViewBag.MaLop = new SelectList(db.LOPs, "MALOP", "TENLOP");
            return View();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MASV, HOSV, TENSV, GIOITINH, NGAYSINH, ANHSV, DIACHI, MALOP")] SINHVIEN sinhVien)
        {
            //System.Web.HttpPostedFileBase Avatar;
            var imgSV = Request.Files["Avatar"];
            //L?y thông tin t? input type=file có tên Avatar
            string postedFileName = System.IO.Path.GetFileName(imgSV.FileName);
            //L?u hình ??i di?n v? Server
            var path = Server.MapPath("/Images/" + postedFileName);
            imgSV.SaveAs(path);
            if (ModelState.IsValid)
            {
                sinhVien.ANHSV = postedFileName;
                db.SINHVIENs.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLop = new SelectList(db.LOPs, "MALOP", "TENLOP", sinhVien.MALOP);
            return View(sinhVien);
        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MALOP", "TENLOP", sinhVien.MALOP);
            return View(sinhVien);
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MASV, HOSV, TENSV, GIOITINH, NGAYSINH, ANHSV, DIACHI, MALOP")] SINHVIEN sinhVien)
        {
            var imgNV = Request.Files["Avatar"];
            try
            {
                //Lấy thông tin từ input type=file có tên Avatar
                string postedFileName = System.IO.Path.GetFileName(imgNV.FileName);
                //Lưu hình đại diện về Server
                var path = Server.MapPath("/Images/" + postedFileName);
                imgNV.SaveAs(path);
            }
            catch
            { }
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLop = new SelectList(db.LOPs, "MALOP", "TENLOP", sinhVien.MALOP);
            return View(sinhVien);
        }

        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SINHVIEN sinhVien = db.SINHVIENs.Find(id);
            db.SINHVIENs.Remove(sinhVien);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}