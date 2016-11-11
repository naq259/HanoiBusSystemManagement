using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Models;
using System.Data;
using System.Data.Entity;
using HanoiBusSystemManagement.Common;

namespace HanoiBusSystemManagement.Controllers
{
    public class ProfileController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Profile/
        public ActionResult Index()
        {
            ViewBag.PhongBan = db.PhongBans.ToList();
            return View();
        }

        [HttpGet]
        public ActionResult EditPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditPassword(HanoiBusSystemManagement.Models.ChangePassword model)
        {
            if (ModelState.IsValid)
            {
                var session = (Login)Session["SESSION"];
                if (session != null)
                {
                    if (session.Password.Equals(Encryptor.MD5Hash(model.ExPassword)))
                    {
                        var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.ID == session.ID);
                        e.MatKhau = Encryptor.MD5Hash(model.Password.ToString());
                        db.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Nhập sai mật khẩu");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản này");
                }
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult EditImage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EditImage(HanoiBusSystemManagement.Models.ChangeImage model)
        {
            if (ModelState.IsValid)
            {
                var session = (Login)Session["SESSION"];
                if (session != null)
                {
                    var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.ID == session.ID);
                    e.AnhCaNhan = model.Img;
                    db.SaveChanges();
                    session.AnhCaNhan = e.AnhCaNhan;
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Không tồn tại tài khoản này");
                }
            }
            return View(model);
        }
	}
}