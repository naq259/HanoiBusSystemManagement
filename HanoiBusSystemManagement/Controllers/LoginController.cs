using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HanoiBusSystemManagement.Common;
using HanoiBusSystemManagement.Models;

namespace HanoiBusSystemManagement.Controllers
{
    public class LoginController : Controller
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Login/
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            string pw = Encryptor.MD5Hash(model.Password);
            var e = db.NhanVienVanPhongs.SingleOrDefault(x => x.TaiKhoan.Equals(model.Username) && x.MatKhau.Equals(pw) && x.MaPhongBan == model.DeptID);
            if (e != null)
            {
                var user = db.NhanVienVanPhongs.SingleOrDefault(x => x.TaiKhoan.Equals(model.Username));
                var session = new Login();
                session.ID = user.ID;
                session.Username = user.TaiKhoan;
                session.Password = user.MatKhau;
                session.DeptID = user.MaPhongBan;
                session.DiaChi = user.DiaChi;
                session.DienThoai = user.DienThoai;
                session.SoCMTND = user.SoCMTND;
                session.AnhCaNhan = user.AnhCaNhan;
                session.Name = user.HoTen;
                Session.Add(CommonConstants.SESSION, session);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Tài khoản hoặc mật khẩu không đúng!");
            }
            return View("Index");
        }

        public ActionResult Logout()
        {
            Session[CommonConstants.SESSION] = null;
            return RedirectToAction("Index");
        }
    }
}