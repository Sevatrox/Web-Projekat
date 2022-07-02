using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebProjekat.Models;

namespace WebProjekat
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            /*FitnesCentar fitnes = new FitnesCentar()
            {
                Naziv = "Total Gym",
                Adresa = "Sutjeska 2, Novi Sad, 21101",
                GodinaOtvaranja = 2000,
                MesecnaCena = 3000.0,
                GodisnjaCena = 30000.0,
                CenaTreninga = 500.0,
                CenaGrupnogTreninga = 800.0,
                CenaTreningaSaPersonalnim = 1000.0
            };

            FitnesCentar fitnes2 = new FitnesCentar()
            {
                Naziv = "Fitnes centar Liman",
                Adresa = "Resavska 4, Novi Sad, 21101",
                GodinaOtvaranja = 2008,
                MesecnaCena = 3000.0,
                GodisnjaCena = 30000.0,
                CenaTreninga = 500.0,
                CenaGrupnogTreninga = 800.0,
                CenaTreningaSaPersonalnim = 1000.0
            };

            Vlasnik vlasnik = new Vlasnik("Markec", "markec321", "Marko", "Markovic", "M", "marko@gmail.com", "10/10/1980", Uloga.VLASNIK, new List<int>());
            Vlasnik vlasnik2 = new Vlasnik("Dozet", "doza123", "Doz", "Simic", "M", "dozet123@gmail.com", "04/08/1990", Uloga.VLASNIK, new List<int>());

            
            FitnesCentarManager.AddFitnesCentar(fitnes);
            FitnesCentarManager.AddFitnesCentar(fitnes2);

            vlasnik.VlasnikFitnesCentri.Add(fitnes.Id);
            vlasnik2.VlasnikFitnesCentri.Add(fitnes2.Id);

            VlasnikManager.AddVlasnik(vlasnik);
            VlasnikManager.AddVlasnik(vlasnik2);

            fitnes.Vlasnik.Id = vlasnik.Id;
            fitnes2.Vlasnik.Id = vlasnik2.Id;

            /*FitnesCentar fitnes = new FitnesCentar()
            {
                Naziv = "Total Gym",
                Adresa = "Sutjeska 2, Novi Sad, 21101",
                GodinaOtvaranja = 2000,
                MesecnaCena = 3000.0,
                GodisnjaCena = 30000.0,
                CenaTreninga = 500.0,
                CenaGrupnogTreninga = 800.0,
                CenaTreningaSaPersonalnim = 1000.0
            };
            
            Posetilac posetilac1 = new Posetilac("Stefo", "stefo321", "Stefan", "Stefanovic", "M", "stefke@gmail.com", new DateTime(1995, 2, 24), Uloga.POSETILAC, new List<int>() );
            Posetilac posetilac2 = new Posetilac("Marija", "maja", "Marija", "Tatic", "Z", "maja111@gmail.com", new DateTime(2000, 4, 14), Uloga.POSETILAC, new List<int>());
            Posetilac posetilac3 = new Posetilac("necke", "nele11111", "Nemanja", "Stajic", "M", "nemanjaaa3@gmail.com", new DateTime(1999, 4, 24), Uloga.POSETILAC, new List<int>());

            PosetilacManager.AddPosetilac(posetilac1);
            PosetilacManager.AddPosetilac(posetilac2);
            PosetilacManager.AddPosetilac(posetilac3);

            GrupniTrening grupniTrening1 = new GrupniTrening("Razbudjivanje", TipTreninga.YOGA, fitnes, 60, new DateTime(2022, 7, 8, 7, 0, 0), 30, new List<int>());
            GrupniTrening grupniTrening2 = new GrupniTrening("Trening snage", TipTreninga.BODY_PUMP, fitnes, 80, new DateTime(2022, 6, 29, 19, 30, 0), 10, new List<int>());

            grupniTrening1.FitnesCentar = fitnes;
            grupniTrening1.SpisakPosetilaca.Add(posetilac1.Id);
            grupniTrening1.SpisakPosetilaca.Add(posetilac2.Id);
            GrupniTreningManager.AddTrening(grupniTrening1);
            grupniTrening2.SpisakPosetilaca.Add(posetilac3.Id);
            GrupniTreningManager.AddTrening(grupniTrening2);

        

            Komentar komentar1 = new Komentar(posetilac1, fitnes, "Odlicna atmosfera, definitivno svaka topla preporuka za Total Gym!", 5);
            Komentar komentar2 = new Komentar(posetilac2, fitnes, "Teretana je odlicno opremljena, ali svlacionice bi mogle biti uredjenije.", 4);

            KomentarManager.AddKomentar(komentar1);
            KomentarManager.AddKomentar(komentar2);*/
        }

        /*public List<FitnesCentar> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<FitnesCentar>>(json, new JsonSerializerSettings() { Converters = converters });
                return test;
            }
        }

        public class FitnesConverter : JsonConverter
        {
            public override bool CanConvert(Type objectType)
            {
                return (objectType == typeof(Korisnik));
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                JObject jo = JObject.Load(reader);
                if (jo["Uloga"].Value<string>() == "VLASNIK")
                    return jo.ToObject<Vlasnik>(serializer);

                return null;
            }

            public override bool CanWrite
            {
                get { return false; }
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }*/
    }

}
