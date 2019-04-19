using jqueryAjax02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace jqueryAjax02.Controllers
{
    public class HomeController : Controller
    {
        private static DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var ogrenciler = db.Ogrenciler.ToList();
            return View(ogrenciler);
        }
        [HttpPost]
        public JsonResult OgrenciEkle(Ogrenci model)
        {
            var ogr = db.Ogrenciler.Where(x => x.Ad.Equals(model.Ad)).FirstOrDefault();

            if (ogr == null)
            {
                db.Ogrenciler.Add(model);
                db.SaveChanges();
                return Json(model, JsonRequestBehavior.AllowGet);
            }

            return Json(false,JsonRequestBehavior.AllowGet);

        }
        [HttpPost]
        public JsonResult GetOgrenci()
        {
            var ogrenciler = db.Ogrenciler.ToList();

            return Json(ogrenciler, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult GetNewOgrenci(int id)
        {
            var ogrenciYeni = db.Ogrenciler.Find(id);
            return Json(ogrenciYeni, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult OgrenciAra(string kelime)
        {
            var ogrenciler = db.Ogrenciler.Where(x => x.Ad.Contains(kelime)).ToList();

            return Json(ogrenciler, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult OgrenciDetay(int id)
        {
            var ogrenci = db.Ogrenciler.Where(x => x.Id == id).FirstOrDefault();
            return Json(ogrenci, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult OgrenciSil(int id)
        {
            var ogrenci = db.Ogrenciler.Find(id);
            db.Ogrenciler.Remove(ogrenci);
            db.SaveChanges();
            return Json(ogrenci, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult OgrenciGuncelle(int id, string ad)
        {
            var ogrenciler = db.Ogrenciler.Find(id);
            ogrenciler.Ad = ad;
            db.SaveChanges();
            return Json(ogrenciler, JsonRequestBehavior.AllowGet);
        }
        //olmadı burası
        [HttpPost]
        public JsonResult OgrenciKontrol(string Ad1)
        {
            var sonuc = db.Ogrenciler.Select(x => x.Ad == Ad1).FirstOrDefault();
            if (sonuc == true)
            {
                return Json(true, JsonRequestBehavior.AllowGet);

            }

            return Json(false, JsonRequestBehavior.AllowGet);

        }

    }
}