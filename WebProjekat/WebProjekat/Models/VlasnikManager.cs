using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class VlasnikManager
    {
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/vlasnici.json");

        public static List<Vlasnik> listaVlasnika { get; set; } = UcitavanjeJSON(path);

        public static Vlasnik FindById(int id)
        {
            listaVlasnika = UcitavanjeJSON(path);
            return listaVlasnika.Find(item => item.Id == id);
        }

        public static bool FindByUsername(string korisnickoIme)
        {
            listaVlasnika = UcitavanjeJSON(path);
            foreach (var item in listaVlasnika)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return true;
            }
            return false;
        }

        public static bool FindIfExitsById(int id, string korisnickoIme)
        {
            listaVlasnika = UcitavanjeJSON(path);
            foreach (var item in listaVlasnika)
            {
                if (item.KorisnickoIme == korisnickoIme)
                {
                    if (item.Id != id)
                        return true;
                }
            }
            return false;
        }

        public static Vlasnik FindAccount(string korisnickoIme, string lozinka)
        {
            listaVlasnika = UcitavanjeJSON(path);
            foreach (var item in listaVlasnika)
            {
                if (item.KorisnickoIme == korisnickoIme && item.Lozinka == lozinka)
                    return item;
            }
            return null;
        }


        public static List<Vlasnik> GetList()
        {
            listaVlasnika = UcitavanjeJSON(path);
            return listaVlasnika;
        }

        public static Vlasnik AddVlasnik(Vlasnik vlasnik)
        {
            listaVlasnika = UcitavanjeJSON(path);
            vlasnik.Id = GenerateId();
            listaVlasnika.Add(vlasnik);
            UpisJSON(path, listaVlasnika);
            return vlasnik;
        }

        public static Vlasnik UpdateVlasnik(Vlasnik vlasnik)
        {
            listaVlasnika = UcitavanjeJSON(path);

            foreach (Vlasnik item in listaVlasnika)
            {
                if (item.Id == vlasnik.Id)
                {
                    item.KorisnickoIme = vlasnik.KorisnickoIme;
                    item.Lozinka = vlasnik.Lozinka;
                    item.Ime = vlasnik.Ime;
                    item.Prezime = vlasnik.Prezime;
                    item.DatumRodjenja = vlasnik.DatumRodjenja;
                    item.Email = vlasnik.Email;
                    item.Pol = vlasnik.Pol;
                    if (vlasnik.VlasnikFitnesCentri != null)
                    {
                        foreach (int centar in vlasnik.VlasnikFitnesCentri)
                        {
                            if(!item.VlasnikFitnesCentri.Contains(centar))
                                item.VlasnikFitnesCentri.Add(centar);
                        }
                    }
                    UpisJSON(path, listaVlasnika);
                    return item;
                }
            }
            return null;
        }

        public static void RemoveVlasnik(Vlasnik vlasnik)
        {
            listaVlasnika.Remove(vlasnik);
            UpisJSON(path, listaVlasnika);
        }

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        public static void UpisJSON(string path, List<Vlasnik> listaVlasnika)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaVlasnika);
            }
        }

        public static List<Vlasnik> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<Vlasnik>>(json, new JsonSerializerSettings() { Converters = converters });
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