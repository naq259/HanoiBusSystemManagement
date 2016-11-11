using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;
using System.Data.Entity;

namespace HanoiBusSystemManagement.Controllers
{
    public class TicketSellerController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /TicketSeller/
        public ActionResult Index()
        {
            ViewBag.DiemBanVe = db.DiemBanVeThangs.ToList();
            return View(db.NhanVienBanVeThangs.ToList());
        }

        public ActionResult Print()
        {
            ViewBag.DiemBanVe = db.DiemBanVeThangs.ToList();
            return View(db.NhanVienBanVeThangs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var tkof = db.DiemBanVeThangs.ToList();
            ViewBag.MaDiemBanVeThang = new SelectList(tkof, "MaDiemBanVeThang", "DiaChi");
            return View();
        }
        [HttpPost]
        public ActionResult Create(NhanVienBanVeThang e, bool gender)
        {
            e.GioiTinh = gender;
            db.NhanVienBanVeThangs.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.DiemBanVe = db.DiemBanVeThangs.ToList();
            return View(db.NhanVienBanVeThangs.SingleOrDefault(x => x.MaNhanVienBanVeThang == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, NhanVienBanVeThang tksl)
        {
            var e = db.NhanVienBanVeThangs.SingleOrDefault(x => x.MaNhanVienBanVeThang == id);
            e.HoTen = tksl.HoTen;
            e.NgaySinh = tksl.NgaySinh;
            e.GioiTinh = tksl.GioiTinh;
            e.DiaChi = tksl.DiaChi;
            e.DienThoai = tksl.DienThoai;
            e.SoCMTND = tksl.SoCMTND;
            e.MaDiemBanVeThang = tksl.MaDiemBanVeThang;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.NhanVienBanVeThangs.SingleOrDefault(x => x.MaNhanVienBanVeThang == id);
            db.NhanVienBanVeThangs.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}