using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;
using System.Data.Entity;

namespace HanoiBusSystemManagement.Controllers
{
    public class DriverController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Driver/
        public ActionResult Index()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.TaiXes.ToList());
        }

        public ActionResult Print()
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.TaiXes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var busroute = db.TuyenXes.ToList();
            ViewBag.MaTuyenXe = new SelectList(busroute, "MaTuyenXe", "TenTuyenXe");
            return View();
        }
        [HttpPost]
        public ActionResult Create(TaiXe e, bool gender)
        {
            e.GioiTinh = gender;
            db.TaiXes.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.TaiXes.SingleOrDefault(x => x.MaTaiXe == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, TaiXe driver)
        {
            var e = db.TaiXes.SingleOrDefault(x => x.MaTaiXe == id);
            e.HoTen = driver.HoTen;
            e.NgaySinh = driver.NgaySinh;
            e.GioiTinh = driver.GioiTinh;
            e.DiaChi = driver.DiaChi;
            e.DienThoai = driver.DienThoai;
            e.SoCMTND = driver.SoCMTND;
            e.LoaiBang = driver.LoaiBang;
            e.MaTuyenXe = driver.MaTuyenXe;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.TaiXes.SingleOrDefault(x => x.MaTaiXe == id);
            db.TaiXes.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}