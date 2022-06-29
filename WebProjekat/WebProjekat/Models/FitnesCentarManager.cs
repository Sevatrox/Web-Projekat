using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class FitnesCentarManager
    {
        public static List<FitnesCentar> listaCentara { get; set; } = new List<FitnesCentar>();
        public static string path = "C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/fitnesCentri.json";

        public static FitnesCentar FindById(int id)
        {
            return listaCentara.Find(item => item.Id == id);
        }

        public static List<FitnesCentar> GetList()
        {
            listaCentara = UcitavanjeJSON(path);
            return listaCentara;
        }

        public static FitnesCentar AddFitnesCentar(FitnesCentar centar)
        {
            centar.Id = GenerateId();
            listaCentara.Add(centar);
            UpisJSON(path, listaCentara);
            return centar;
        }

        public static void RemoveProduct(FitnesCentar product)
        {
            listaCentara.Remove(product);
        }

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        public static void UpisJSON(string path, List<FitnesCentar> listaCentara)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaCentara);
            }
        }

        public static List<FitnesCentar> UcitavanjeJSON(string path)
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