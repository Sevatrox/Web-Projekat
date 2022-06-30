using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class PosetilacManager
    {
        public static List<Posetilac> listaPosetilaca { get; set; } = new List<Posetilac>();

        public static string path = "C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/posetioci.json";


        public static Posetilac FindById(int id)
        {
            return listaPosetilaca.Find(item => item.Id == id);
        }

        public static List<Posetilac> GetList()
        {
            listaPosetilaca = UcitavanjeJSON(path);
            return listaPosetilaca;
        }

        public static Posetilac AddPosetilac(Posetilac posetilac)
        {
            posetilac.Id = GenerateId();
            listaPosetilaca.Add(posetilac);
            UpisJSON(path, listaPosetilaca);
            return posetilac;
        }

        public static void RemovePosetilac(Posetilac posetilac)
        {
            listaPosetilaca.Remove(posetilac);
        }

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }



        public static void UpisJSON(string path, List<Posetilac> listaPosetilaca)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaPosetilaca);
            }
        }

        public static List<Posetilac> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<Posetilac>>(json, new JsonSerializerSettings() { Converters = converters });
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