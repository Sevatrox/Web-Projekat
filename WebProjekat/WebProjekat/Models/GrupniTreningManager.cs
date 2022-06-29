﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class GrupniTreningManager
    {
        public static string path = "C:/Users/pc/source/repos/Projekat/WebProjekat/WebProjekat/App_Data/treninzi.json";

        /*public static GrupniTrening FindById(int id)
        {
            return listaTreninga.Find(item => item.Id == id);
        }

        public static List<GrupniTrening> GetList()
        {
            listaTreninga = UcitavanjeJSON(path);
            return listaTreninga;
        }

        public static GrupniTrening AddTrening(GrupniTrening trening)
        {
            trening.Id = GenerateId();
            listaTreninga.Add(trening);
            UpisJSON(path, listaTreninga);
            return trening;
        }

        public static void RemoveTrening(GrupniTrening trening)
        {
            listaTreninga.Remove(trening);
        }*/

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }


        public static void UpisJSON(string path, List<GrupniTrening> listaCentara)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaCentara);
            }
        }

        public static List<GrupniTrening> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<GrupniTrening>>(json, new JsonSerializerSettings() { Converters = converters });
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
                throw new NotImplementedException();
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