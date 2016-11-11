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
    public class SingleTicketController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /SingleTicket/
        public ActionResult Index()
        {
            return View(db.VeNgays.Include(x => x.TuyenXe).ToList());
        }

        public ActionResult Print()
        {
            return View(db.VeNgays.Include(x => x.TuyenXe).ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            var busroute = db.TuyenXes.ToList();
            ViewBag.MaTuyenXe = new SelectList(busroute, "MaTuyenXe", "TenTuyenXe");
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeNgay e)
        {
            db.VeNgays.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            ViewBag.TuyenXe = db.TuyenXes.ToList();
            return View(db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, VeNgay st)
        {
            var e = db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id);
            e.TenVeNgay = st.TenVeNgay;
            e.DonGia = st.DonGia;
            e.MaTuyenXe = st.MaTuyenXe;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.VeNgays.SingleOrDefault(x => x.MaVeNgay == id);
            db.VeNgays.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}