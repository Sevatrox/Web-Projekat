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
                Vlasnik = new Vlasnik("Markec", "markec321", "Marko", "Markovic", "M", "marko@gmail.com", new DateTime(1980, 10, 10), Uloga.VLASNIK, new List<FitnesCentar>()),
                MesecnaCena = 3000.0,
                GodisnjaCena = 30000.0,
                CenaTreninga = 500.0,
                CenaGrupnogTreninga = 800.0,
                CenaTreningaSaPersonalnim = 1000.0
            };

            /*FitnesCentar fitnes2 = new FitnesCentar()
            {
                Naziv = "Liman",
                Adresa = "REEE",
                GodinaOtvaranja = 2000,
                Vlasnik = new Vlasnik("Markec", "markec321", "Marko", "Markovic", "M", "marko@gmail.com", new DateTime(1980, 10, 10), Uloga.VLASNIK, new List<FitnesCentar>()),
                MesecnaCena = 3000.0,
                GodisnjaCena = 30000.0,
                CenaTreninga = 500.0,
                CenaGrupnogTreninga = 800.0,
                CenaTreningaSaPersonalnim = 1000.0
            };

            List<FitnesCentar> lista = new List<FitnesCentar>();
            lista.Add(fitnes);
            //lista.Add(fitnes2);

            /*Vlasnik vlasnik = new Vlasnik();
            vlasnik.KorisnickoIme = "Markec";
            vlasnik.Lozinka = "markec123";
            vlasnik.Ime = "Marko";
            vlasnik.Prezime = "Markovic";
            vlasnik.Pol = "M";
            vlasnik.Email = "markec@gmail.com";
            vlasnik.DatumRodjenja = new DateTime(1980, 10, 10);
            vlasnik.Uloga = Uloga.VLASNIK;
            vlasnik.VlasnikFitnesCentri = new List<FitnesCentar>();
            using (StreamWriter file = File.CreateText("C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/fitnesCentri.json"))
            {
                JsonSerializer serializer = new JsonSerializer();
                //serialize object directly into file stream
                serializer.Serialize(file, lista);
            }
            
            
            //HttpContext.Current.Application["fitnesCentri"] = UcitavanjeJSON("C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/fitnesCentri.json");
            //HttpContext.Current.Application["vlasnik"] = UcitavanjeJSON("C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/vlasnici.json");
            */
        }

        public List<FitnesCentar> UcitavanjeJSON(string path)
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
        }
    }

}
