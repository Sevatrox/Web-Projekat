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

            Vlasnik vlasnik = new Vlasnik("Markec", "markec321", "Marko", "Markovic", "M", "marko@gmail.com", new DateTime(1980, 10, 10), Uloga.VLASNIK, new List<int>());
            Vlasnik vlasnik2 = new Vlasnik("Dozet", "doza123", "Doz", "Simic", "M", "dozet123@gmail.com", new DateTime(1990, 8, 4), Uloga.VLASNIK, new List<int>());

            fitnes.Vlasnik = vlasnik;
            fitnes2.Vlasnik = vlasnik2;

            FitnesCentarManager.AddFitnesCentar(fitnes);
            FitnesCentarManager.AddFitnesCentar(fitnes2);

            vlasnik.VlasnikFitnesCentri.Add(fitnes.Id);
            vlasnik2.VlasnikFitnesCentri.Add(fitnes2.Id);

            VlasnikManager.AddVlasnik(vlasnik);
            VlasnikManager.AddVlasnik(vlasnik2);*/
            
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
