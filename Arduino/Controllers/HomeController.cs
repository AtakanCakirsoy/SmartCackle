using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FireSharp.Config;
using FireSharp.Response;
using FireSharp.Interfaces;
using Arduino.Models;
using Arduino.ViewModels;

namespace Arduino.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            FirebaseCekilenVeriler veri = new FirebaseCekilenVeriler();
            var sicaklik = client.Get(@"Sicaklik/");
            veri.GelenSicaklik = sicaklik.Body;
            var nem = client.Get(@"Nem/");
            veri.GelenNem = nem.Body;
            var agirlik = client.Get(@"Agirlik/");
            veri.GelenAgirlik = agirlik.Body;
            var suseviyesi = client.Get(@"SuSeviyesi/");
            veri.GelenSuSeviyesi = suseviyesi.Body;
            var hareket = client.Get(@"Hareket/");
            veri.Hareket = hareket.Body;
            var yangin = client.Get(@"Yangin/");
            veri.Yangin = yangin.Body;
            ViewBag.Sicaklik = veri.GelenSicaklik;
            ViewBag.Nem = veri.GelenNem;
            ViewBag.Agirlik = veri.GelenAgirlik;
            ViewBag.SuSeviyesi = veri.GelenSuSeviyesi;
            if(veri.Yangin=="0")
            {
                ViewBag.Yangin = "Stabil";
            }
            else
            {
                ViewBag.Yangin = "Olumsuz bir durum oluştu!";
            }
            if (veri.Hareket == "0")
            {
                ViewBag.Hareket = "Hareket gözlemlenmedi.";
            }
            else
            {
                ViewBag.Hareket = "Hareketli bir cisim/nesne algılandı!";
            }
            return View();
        }
        public ActionResult SicaklikDegistir(FirebaseCekilenVeriler veriler)
        {
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            var sicaklik = client.Set(@"GidenSicaklik/",veriler.GidenSicaklik);
            return RedirectToAction("Index");
        }
        public ActionResult NemDegistir(FirebaseCekilenVeriler veriler)
        {
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            var nem = client.Set(@"GidenNem/", veriler.GidenNem);
            return RedirectToAction("Index");
        }
        public ActionResult YemDegistir(FirebaseCekilenVeriler veriler)
        {
            string yemDurumu;
            if(veriler.YemDurumu== "{ value = 0 }")
            {
                yemDurumu = "0";
            }
            else
            {
                yemDurumu = "1";
            }
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            var yem = client.Set(@"YemDurumu/", yemDurumu);
            return RedirectToAction("Index");
        }
        public ActionResult SuDegistir(FirebaseCekilenVeriler veriler)
        {
            string suDurumu;
            if (veriler.SuDurumu == "{ value = 0 }")
            {
                suDurumu = "0";
            }
            else
            {
                suDurumu = "1";
            }
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            var yem = client.Set(@"SuDurumu/", suDurumu);
            return RedirectToAction("Index");
        }
        public ActionResult AlarmDurumu(FirebaseCekilenVeriler veriler)
        {
            string alarmDurumu;
            if (veriler.Alarm == "{ value = 0 }")
            {
                alarmDurumu = "0";
            }
            else
            {
                alarmDurumu = "1";
            }
            IFirebaseConfig ifc = new FirebaseConfig()
            {
                AuthSecret = "Rs1oLkt5fsfBfUKUJA7ZwsOdqcsCBhdn7fN1dlQc",
                BasePath = "https://arduino-afb8e.firebaseio.com/"
            };
            IFirebaseClient client;
            client = new FireSharp.FirebaseClient(ifc);
            var yem = client.Set(@"Alarm/", alarmDurumu);
            return RedirectToAction("Index");
        }

    }
}



