using HanoiBusSystemManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HanoiBusSystemManagement.Controllers
{
    public class DepartmentController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Department/
        public ActionResult Index()
        {
            return View(db.PhongBans.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PhongBan dept)
        {
            db.PhongBans.Add(dept);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.PhongBans.SingleOrDefault(x => x.MaPhongBan == id));
        }

        [HttpPost]
        public ActionResult Edit(int id, PhongBan dept)
        {
            var e = db.PhongBans.Where(x => x.MaPhongBan == id).SingleOrDefault();
            e.TenPhongBan = dept.TenPhongBan;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
	}
}