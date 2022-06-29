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
        public static List<Vlasnik> listaVlasnika { get; set; } = new List<Vlasnik>();

        public static string path = "C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/vlasnici.json";

        public static Vlasnik FindById(int id)
        {
            return listaVlasnika.Find(item => item.Id == id);
        }

        public static List<Vlasnik> GetList()
        {
            listaVlasnika = UcitavanjeJSON(path);
            return listaVlasnika;
        }

        public static Vlasnik AddVlasnik(Vlasnik vlasnik)
        {
            vlasnik.Id = GenerateId();
            listaVlasnika.Add(vlasnik);
            UpisJSON(path, listaVlasnika);
            return vlasnik;
        }

        public static void RemoveVlasnik(Vlasnik vlasnik)
        {
            listaVlasnika.Remove(vlasnik);
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