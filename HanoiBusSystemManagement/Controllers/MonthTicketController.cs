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
    public class MonthTicketController : BaseController
    {
        db_busEntities db = new db_busEntities();
        //
        // GET: /MonthTicket/
        public ActionResult Index()
        {
            return View(db.VeThangs.ToList());
        }

        public ActionResult Print()
        {
            return View(db.VeThangs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(VeThang e)
        {
            db.VeThangs.Add(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.VeThangs.SingleOrDefault(x => x.MaVeThang == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, VeThang st)
        {
            var e = db.VeThangs.SingleOrDefault(x => x.MaVeThang == id);
            e.TenVeThang = st.TenVeThang;
            e.DonGia = st.DonGia;
            e.GhiChu = st.GhiChu;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.VeThangs.SingleOrDefault(x => x.MaVeThang == id);
            db.VeThangs.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}