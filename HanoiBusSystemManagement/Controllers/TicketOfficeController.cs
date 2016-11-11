using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;

namespace HanoiBusSystemManagement.Controllers
{
    public class TicketOfficeController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /TicketOffice/
        public ActionResult Index()
        {
            return View(db.DiemBanVeThangs.ToList());
        }

        public ActionResult Print()
        {
            return View(db.DiemBanVeThangs.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DiemBanVeThang tkof)
        {
            db.DiemBanVeThangs.Add(tkof);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, DiemBanVeThang tkof)
        {
            var e = db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id);
            e.DiaChi = tkof.DiaChi;
            e.SoDienThoai = tkof.SoDienThoai;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var e = db.DiemBanVeThangs.SingleOrDefault(x => x.MaDiemBanVeThang == id);
            db.DiemBanVeThangs.Remove(e);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}