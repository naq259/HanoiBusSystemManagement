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
    public class StatisticController : BaseController
    {
        private db_busEntities db = new db_busEntities();
        //
        // GET: /Statistic/
        public ActionResult Index(int? year)
        {
            var dsvengay = new List<int>();
            var dsvethang = new List<int>();
            var day = db.BanVeNgays.Include(x => x.VeNgay).Where(x => x.Ngay.Year == year).ToList();
            var month = db.BanVeThangs.Include(x => x.VeThang).Where(x => x.Ngay.Year == year).ToList();
            for(int i = 1; i <= 12; i++)
            {
                int countday = 0;
                int countmonth = 0;
                foreach(var item in day)
                {
                    if(item.Ngay.Month==i)
                    {
                        countday += (item.SoVePhatRa - item.SoVeThuVe);
                    }
                }
                dsvengay.Add(countday);
                foreach(var item in month)
                {
                    if(item.Ngay.Month==i)
                    {
                        countmonth += (item.SoVePhatRa - item.SoVeThuVe);
                    }
                }
                dsvethang.Add(countmonth);
            }
            string str1 = "";
            foreach(var item in dsvengay)
            {
                str1 += "," + item;
            }
            ViewBag.str1 = str1.Substring(1);
            string str2 = "";
            foreach (var item in dsvethang)
            {
                str2 += "," + item;
            }
            ViewBag.str2 = str2.Substring(1);
            return View();
        }

        public ActionResult Time(DateTime? start, DateTime? end)
        {
            if(start.HasValue && end.HasValue)
            {
                List<BanVeNgay> list1 = new List<BanVeNgay>();
                var day = db.BanVeNgays.Include(x => x.PhuXe).ToList();
                foreach (var item in day)
                {
                    if (item.Ngay.CompareTo(start) == 1 && item.Ngay.CompareTo(end) == -1)
                    {
                        list1.Add(item);
                    }
                }
                ViewBag.list1 = list1;
                List<BanVeThang> list2 = new List<BanVeThang>();
                var month = db.BanVeThangs.Include(x => x.NhanVienBanVeThang).ToList();
                foreach (var item in month)
                {
                    if (item.Ngay.CompareTo(start) == 1 && item.Ngay.CompareTo(end) == -1)
                    {
                        list2.Add(item);
                    }
                }
                ViewBag.list2 = list2;
            }
            else
            {
                ViewBag.list1 = db.BanVeNgays.Include(x => x.PhuXe).ToList();
                ViewBag.list2 = db.BanVeThangs.Include(x => x.NhanVienBanVeThang).ToList();
            }
            return View();
        }
        public JsonResult RealTime1(DateTime start, DateTime end)
        {
            List<BanVeNgay> list1 = new List<BanVeNgay>();
            var day = db.BanVeNgays.ToList();
            foreach(var item in day)
            {
                if(item.Ngay.CompareTo(start) > 1 && item.Ngay.CompareTo(end) < 1)
                {
                    list1.Add(item);
                }
            }
            return Json(list1, JsonRequestBehavior.AllowGet);
        }

        public JsonResult RealTime2(DateTime start, DateTime end)
        {
            List<BanVeThang> list2 = new List<BanVeThang>();
            var month = db.BanVeThangs.ToList();
            foreach (var item in month)
            {
                if (item.Ngay.CompareTo(start) > 1 && item.Ngay.CompareTo(end) < 1)
                {
                    list2.Add(item);
                }
            }
            return Json(list2, JsonRequestBehavior.AllowGet);
        }
	}
}