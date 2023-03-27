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
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/fitnesCentri.json");

        public static List<FitnesCentar> listaCentara { get; set; } = UcitavanjeJSON(path);

        public static FitnesCentar FindById(int id)
        {
            listaCentara = UcitavanjeJSON(path);
            return listaCentara.Find(item => item.Id == id);
        }

        public static bool FindByName(FitnesCentar centar)
        {
            listaCentara = UcitavanjeJSON(path);
            foreach (FitnesCentar item in listaCentara)
            {
                if (item.Naziv == centar.Naziv)
                    return true;
            }
            return false;
        }

        public static List<FitnesCentar> GetList()
        {
            listaCentara = UcitavanjeJSON(path);
            return listaCentara;
        }

        public static FitnesCentar AddFitnesCentar(FitnesCentar centar)
        {
            listaCentara = UcitavanjeJSON(path);
            centar.Id = GenerateId();
            listaCentara.Add(centar);
            UpisJSON(path, listaCentara);
            return centar;
        }

        public static bool UpdateCentar(FitnesCentar centar)
        {
            listaCentara = UcitavanjeJSON(path);
            foreach (var item in listaCentara)
            {
                if(item.Id == centar.Id)
                {
                    item.Naziv = centar.Naziv;
                    item.Adresa = centar.Adresa;
                    item.GodinaOtvaranja = centar.GodinaOtvaranja;
                    item.MesecnaCena = centar.MesecnaCena;
                    item.GodisnjaCena = centar.GodisnjaCena;
                    item.CenaTreninga = centar.CenaTreninga;
                    item.CenaGrupnogTreninga = centar.CenaGrupnogTreninga;
                    item.CenaTreningaSaPersonalnim = centar.CenaTreningaSaPersonalnim;
                    UpisJSON(path, listaCentara);
                    return true;
                }
            }
            return false;
        }

        public static bool DeleteCentar(FitnesCentar centar)
        {
            listaCentara = UcitavanjeJSON(path);
            foreach (var item in listaCentara)
            {
                if(item.Id == centar.Id)
                {
                    item.Obrisan = true;
                    UpisJSON(path, listaCentara);
                    return true;
                }
            }
            return false;
        }

        public static void RemoveCentar(FitnesCentar centar)
        {
            listaCentara = UcitavanjeJSON(path);
            listaCentara.Remove(centar);
            UpisJSON(path, listaCentara);
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