using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class KomentarManager
    {
        public static string path = "C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/komentari.json";

        public static List<Komentar> listaKomentara { get; set; } = UcitavanjeJSON(path);

        public static Komentar FindById(int id)
        {
            listaKomentara = UcitavanjeJSON(path);
            return listaKomentara.Find(item => item.Id == id);
        }

        public static List<Komentar> GetList()
        {
            listaKomentara = UcitavanjeJSON(path);
            return listaKomentara;
        }

        public static List<Komentar> GetListByCentar(int id)
        {
            listaKomentara = UcitavanjeJSON(path);
            List<Komentar> rezultat = new List<Komentar>();
            foreach (var item in listaKomentara)
            {
                if (item.FitnesCentar.Id == id)
                    rezultat.Add(item);
            }
            return rezultat;
        }

        public static Komentar AddKomentar(Komentar komentar)
        {
            listaKomentara = UcitavanjeJSON(path);
            komentar.Id = GenerateId();
            komentar.Odobren = false;
            listaKomentara.Add(komentar);
            UpisJSON(path, listaKomentara);
            return komentar;
        }
        public static Komentar UpdateKomentar(Komentar komentar)
        {
            listaKomentara = UcitavanjeJSON(path);
            foreach (Komentar item in listaKomentara)
            {
                if (item.Id == komentar.Id)
                {
                    item.Odobren = komentar.Odobren;
                    item.Odbijen = komentar.Odbijen;
                    UpisJSON(path, listaKomentara);
                    return item;
                }
            }
            return null;
        }

        public static void RemoveKomentar(Komentar komentar)
        {
            listaKomentara.Remove(komentar);
            UpisJSON(path, listaKomentara);
        }

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        public static void UpisJSON(string path, List<Komentar> listaKomentara)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaKomentara);
            }
        }

        public static List<Komentar> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<Komentar>>(json, new JsonSerializerSettings() { Converters = converters });
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
                if (jo["Uloga"].Value<string>() == "POSETILAC")
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