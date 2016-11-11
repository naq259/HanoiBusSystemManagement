using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;
using System.Data.Entity;

namespace HanoiBusSystemManagement.Controllers
{
    public class BusRouteController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Buses/
        public ActionResult Index()
        {
            ViewBag.XeBuyt = db.XeBuyts.ToList();
            return View(db.TuyenXes.ToList());
        }

        public ActionResult Print()
        {
            return View(db.TuyenXes.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(TuyenXe e)
        {
            db.TuyenXes.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, TuyenXe e)
        {
            var entity = db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id);
            entity.TenTuyenXe = e.TenTuyenXe;
            entity.GioBatDau = e.GioBatDau;
            entity.GioKetThuc = e.GioKetThuc;
            entity.DiemCuoi = e.DiemCuoi;
            entity.DiemDau = e.DiemDau;
            entity.ChiTietTram = e.ChiTietTram;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.TuyenXes.SingleOrDefault(x => x.MaTuyenXe == id);
            db.TuyenXes.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}