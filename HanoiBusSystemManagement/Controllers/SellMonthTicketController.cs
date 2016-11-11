using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;
using System.Data;
using System.Data.Entity;

namespace HanoiBusSystemManagement.Controllers
{
    public class SellMonthTicketController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /SellMonthTicket/
        public ActionResult Index()
        {
            return View(db.BanVeThangs.Include(x => x.NhanVienBanVeThang).Include(x => x.VeThang).ToList());
        }

        public ActionResult Print()
        {
            return View(db.BanVeThangs.Include(x => x.NhanVienBanVeThang).Include(x => x.VeThang).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var ts = db.NhanVienBanVeThangs.ToList();
            ViewBag.MaNhanVienBanVeThang = new SelectList(ts, "MaNhanVienBanVeThang", "HoTen");
            var st = db.VeThangs.ToList();
            ViewBag.MaVeThang = new SelectList(st, "MaVeThang", "TenVeThang");
            return View();
        }
        [HttpPost]
        public ActionResult Create(BanVeThang e)
        {
            db.BanVeThangs.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.NhanVienBanVeThang = db.NhanVienBanVeThangs.ToList();
            ViewBag.VeThang = db.VeThangs.ToList();
            return View(db.BanVeThangs.SingleOrDefault(x => x.MaGiaoDich == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, BanVeThang sst)
        {
            var e = db.BanVeThangs.SingleOrDefault(x => x.MaGiaoDich == id);
            e.Ngay = sst.Ngay;
            e.MaNhanVienBanVeThang = sst.MaNhanVienBanVeThang;
            e.MaVeThang = sst.MaVeThang;
            e.SoVePhatRa = sst.SoVePhatRa;
            e.SoVeThuVe = sst.SoVeThuVe;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.BanVeThangs.SingleOrDefault(x => x.MaGiaoDich == id);
            db.BanVeThangs.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}