using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Pkcs;
using System.Web;
using System.Web.Mvc;
using proteinocn.Models;

namespace proteinocn.Controllers
{
    public class BurakController : Controller
    {
        // GET: Burak
        proteinocnDBEntities4 db = new proteinocnDBEntities4(); 
        // proteinocnDBEntitiesEv db = new proteinocnDBEntitiesEv();
        public void urunsayisibul()
        {
            if (Session["id"] != null)
            {
                int id = Convert.ToInt16(Session["id"]);
                var sayi = db.sepetTable.Count(a => a.uye_id == id);
                Session["urunsayisi"] = sayi;
            }
        }

        public ActionResult Arama(string kelime)
        {
            ViewBag.Kelime = kelime;
            if (string.IsNullOrEmpty(kelime))
            {
                return RedirectToAction("Index");
            }

            var sonuclar = db.urunTable.Where(x => x.urun_ad.Contains(kelime)
                                             || x.urun_aroma.Contains(kelime)
                                             || x.urun_aciklama1.Contains(kelime)).ToList();
            return View(sonuclar);
        }
        public ActionResult Index()
        {
            
            urunsayisibul();
            return View();
        }
        public ActionResult hakkimizda()
        {
            urunsayisibul();
            var degerler = db.urunTable.ToList();
            return View(degerler);
        }
        public ActionResult iletisim()
        {
            urunsayisibul();
            var degerler = db.urunTable.ToList();
            return View(degerler);
        }
        public ActionResult tumurunler()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.ToList();
            return View(degerler);
        }
        public ActionResult protein()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'proteinler' or  urun_kategori = 'proteinliurunler'");
            return View(degerler);
        }
        public ActionResult proteinler()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'proteinler'");
            return View(degerler);
        }
        public ActionResult proteinliurunler()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'proteinliurunler'");
            return View(degerler);
        }
        public ActionResult aminoasit()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'aminoasitler'");
            return View(degerler);
        }
        public ActionResult preworkout()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'pre-workout'");
            return View(degerler);
        }
        public ActionResult karbonhidrat()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'karbonhidratlar'");
            return View(degerler);
        }
        public ActionResult sporgida()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'karbonhidratlar' or urun_kategori = 'pre-workout' or urun_kategori = 'aminoasitler'");
            return View(degerler);
        }
        public ActionResult formulurun()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'formulurunler'");
            return View(degerler);
        }
        public ActionResult poptakviye()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'populertakviyeler'");
            return View(degerler);
        }
        public ActionResult mineral()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'mineral'");
            return View(degerler);
        }
        public ActionResult vitamin()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'formulurunler' or urun_kategori = 'populertakviyeler' or urun_kategori = 'mineral'");
            return View(degerler);
        }
        public ActionResult fonkgida()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'fonkgida'");
            return View(degerler);
        }
        public ActionResult bitkitozu()
        {
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'bitkitozu'");
            return View(degerler);
        }
        public ActionResult zayiflama()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'zayiflama'");
            return View(degerler);
        }
        public ActionResult saglik()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'fonkgida' or urun_kategori = 'bitkitozu' or urun_kategori = 'zayiflama'");
            return View(degerler);
        }
        public ActionResult gida()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'gida'");
            return View(degerler);
        }
        public ActionResult aksesuar()
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_kategori = 'aksesuar'");
            return View(degerler);
        }
        public ActionResult urunozel(int gonderilenid)
        {
            
            urunsayisibul();
            var degerler = db.urunTable.SqlQuery("Select * from urunTable where urun_id="+gonderilenid);
            return View(degerler);
        }
        public ActionResult uyeol()
        {
 
            return View();
        }
        [HttpPost]
        public ActionResult uyeol(FormCollection veriler)
        {
            uyeTable uye = new uyeTable();
            uye.uye_ad = veriler["ad"];
            uye.uye_sifre = veriler["sifre"];
            uye.uye_eposta = veriler["eposta"];
            uye.uye_adres = veriler["adres"];
            uye.uye_telno = veriler["telno"];
            
            var deger = db.uyeTable.FirstOrDefault(a=> a.uye_ad == uye.uye_ad);

            if (deger == null)
            {
                if (veriler["sifre"] != veriler["sifre2"])
                {
                    ViewBag.mesaj = "Şifreler Aynı Olmak Zorundadır...";
                    return View();
                }
                else
                {
                    db.uyeTable.Add(uye);
                    db.SaveChanges();
                    Session["kullanici"] = uye.uye_ad;
                    Session["id"] = uye.uye_id;
                    return RedirectToAction("index");
                }
            }
            else
            {
                ViewBag.mesaj = "Bu Kullanıcı Adı Zaten Mevcut...";
                return View();
            }

        }
        public ActionResult cikis()
        {
            Session.Abandon();
            return RedirectToAction("index");
        }
        public ActionResult girisyap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult girisyap(FormCollection fc)
        {
            uyeTable uye = new uyeTable();
            uye.uye_ad = fc["kad"];
            uye.uye_sifre = fc["sifre"];
            var deger1 = db.uyeTable.FirstOrDefault(a => a.uye_ad == a.uye_ad);
            if (deger1 == null)
            {
                ViewBag.hata2 = "Böyle Bir Kullanıcı Adı Yok...";
                return View();
            }
            else
            {
                var deger2 = db.uyeTable.FirstOrDefault(a => a.uye_ad == uye.uye_ad  && a.uye_sifre == uye.uye_sifre);
                if (deger2 == null)
                {
                    ViewBag.hata2 = "Şifre Veya Kullanıcı Adı Hatalı...";
                    return View();
                }
                else
                {
                    var deger3 = db.uyeTable.Where(a => a.uye_ad == uye.uye_ad).ToList();
                    Session["kullanici"] = uye.uye_ad;
                    Session["id"] = deger3.First().uye_id;
                    Session.Timeout = 1;
                    return RedirectToAction("index");
                }
            }
        }
        public ActionResult sepeteekle(int id)
        {
            if (Session["kullanici"]==null)
            {
                return RedirectToAction("girisyap", "Burak", new { mesaj = "sepete eklemek için önce oturum açın" });
            }
            else
            {
                sepetTable sp = new sepetTable();
                sp.uye_id = Convert.ToInt16(Session["id"]);
                sp.urun_id = Convert.ToInt16(id);

                if (db.sepetTable.Any(a => a.uye_id == sp.uye_id && a.urun_id == sp.urun_id))
                {
                    return RedirectToAction("index");
                }
                else
                {
                    db.sepetTable.Add(sp);
                    db.SaveChanges();
                    return RedirectToAction("");
                }
            }
        }
        public ActionResult sepet()
        {
            if (Session["id"]==null)
            {
                return RedirectToAction("girisyap");
            }
            int uid = Convert.ToInt32(Session["id"]);
            
            var deger = db.sepetTable.Include("urunTable").Where(a=> a.uye_id == uid).ToList();

            urunsayisibul();
            return View(deger);
        }
        public ActionResult sepettencikar(int id)
        {
            int uyeid = Convert.ToInt32(Session["id"].ToString());
            var deger2 = db.sepetTable.FirstOrDefault(a => a.urun_id == id && a.uye_id == uyeid);
            db.sepetTable.Remove(deger2);
            db.SaveChanges();
            return RedirectToAction("sepet");
        }
        public ActionResult adminana()
        {
            if (Session["admin_kullanici_adi"]==null)
            {
                return RedirectToAction("index", "Burak"); 
            }
            var degerler = db.urunTable.ToList();
            return View(degerler);
        }
        public ActionResult admingiris1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult admingiris1(FormCollection veri)
        {
            adminTable adminT = new adminTable();
            adminT.admin_ad = veri["admin_kullanici_adi"];
            adminT.admin_sifre = veri["admin_kullanici_sifre"];

            var bilgi = db.adminTable.FirstOrDefault(a=> a.admin_ad == adminT.admin_ad);
            if (bilgi == null)
            {
                ViewBag.adminHata = "Böyle Bir Kullanıcı Yok";
                return View();
            }
            else
            {
                var bilgi2 = db.adminTable.FirstOrDefault(a=> a.admin_ad == adminT.admin_ad && a.admin_sifre == adminT.admin_sifre);
                if (bilgi2 == null)
                {
                    ViewBag.adminHata = "Kullanıcı adı veya şifre yanlış";
                    return View();
                }
                Session["admin_kullanici_adi"] = adminT.admin_ad;
                return RedirectToAction("adminana");
            }
        }
        public ActionResult adminsil(int id)
        {
            if (Session["admin_kullanici_adi"] == null)
            {
                return RedirectToAction("index");
            }
            else
            {
                var urun = db.urunTable.Find(id);
                db.urunTable.Remove(urun);
                db.SaveChanges();

                return RedirectToAction("adminana");
            }
        }

        public ActionResult adminguncelle(int id)
        {
            if (Session["admin_kullanici_adi"] == null)
            {
                return RedirectToAction("index");
            }
            var deger = db.urunTable.Where(a=>a.urun_id == id).ToList();
            return View(deger);
        }
        [HttpPost]
        public ActionResult adminguncelle(FormCollection fc)
        {
            if (Session["admin_kullanici_adi"] == null)
            {
                return RedirectToAction("index");
            }
            int id = Convert.ToInt16(fc["urunid"]);
            urunTable u = db.urunTable.Find(id);
            u.urun_ad = fc["ad"];
            u.urun_aroma = fc["aroma1"];
            u.urun_boyut = fc["boyut1"];
            u.urun_fiyat = Convert.ToInt32(fc["fiyat"]);
            u.urun_aciklama1 = fc["aciklama1"];
            u.urun_aciklama2 = fc["aciklama2"];
            u.urun_foto1 = fc["foto1"];
            u.urun_foto2 = fc["foto2"];
            u.urun_kategori = fc["kategori"];
            u.urun_aroma2 = fc["aroma2"];
            u.urun_aroma3 = fc["aroma3"];
            u.urun_aroma4 = fc["aroma4"];
            u.urun_aroma5 = fc["aroma5"];
            u.urun_boyut2 = fc["boyut2"];
            u.urun_boyut3 = fc["boyut3"];
            u.urun_ozellikler = fc["ozellikler"];
            db.SaveChanges();
            return RedirectToAction("adminana");




        }

    }
}