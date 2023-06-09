﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public class TrenerManager
    {
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/treneri.json");

        public static List<Trener> listaTrenera = UcitavanjeJSON(path);

        public static Trener FindById(int id)
        {
            listaTrenera = UcitavanjeJSON(path);
            return listaTrenera.Find(item => item.Id == id);
        }

        public static bool FindByUsername(string korisnickoIme)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (var item in listaTrenera)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return true;
            }
            return false;
        }

        public static bool FindIfExitsById(int id, string korisnickoIme)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (var item in listaTrenera)
            {
                if (item.KorisnickoIme == korisnickoIme)
                {
                    if (item.Id != id)
                        return true;
                }
            }
            return false;
        }

        public static Trener FindAccount(string korisnickoIme, string lozinka)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (var item in listaTrenera)
            {
                if (item.KorisnickoIme == korisnickoIme && item.Lozinka == lozinka)
                    return item;
            }
            return null;
        }

        public static bool AlreadyWorking(Trener trener)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (var item in listaTrenera)
            {
                if(item.KorisnickoIme == trener.KorisnickoIme)
                {
                    if (item.AngazovanFitnesCentar != null)
                        return true;
                }
            }
            return false;
        }

        public static List<Trener> GetList()
        {
            listaTrenera = UcitavanjeJSON(path);
            return listaTrenera;
        }

        public static List<Trener> GetListByCenter(int id)
        {
            listaTrenera = UcitavanjeJSON(path);
            List<Trener> rezultat = new List<Trener>();
            foreach (var item in listaTrenera)
            {
                if (item.AngazovanFitnesCentar.Id == id)
                    rezultat.Add(item);
            }
            return rezultat;
        }

        public static Trener AddTrener(Trener trener)
        {
            listaTrenera = UcitavanjeJSON(path);
            trener.Id = GenerateId();
            trener.ListaTreningaTrenera = new List<int>();
            listaTrenera.Add(trener);
            UpisJSON(path, listaTrenera);
            return trener;
        }

        public static Trener UpdateTrener(Trener trener)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (Trener item in listaTrenera)
            {
                if (item.Id == trener.Id)
                {
                    item.KorisnickoIme = trener.KorisnickoIme;
                    item.Lozinka = trener.Lozinka;
                    item.Ime = trener.Ime;
                    item.Prezime = trener.Prezime;
                    item.DatumRodjenja = trener.DatumRodjenja;
                    item.Email = trener.Email;
                    item.Pol = trener.Pol;
                    UpisJSON(path, listaTrenera);
                    return item;
                }
            }
            return null;
        }

        public static bool DeleteTrener(Trener trener)
        {
            listaTrenera = UcitavanjeJSON(path);
            foreach (var item in listaTrenera)
            {
                if(item.Id == trener.Id)
                {
                    item.Zabranjen = true;
                    UpisJSON(path, listaTrenera);
                    return true;
                }
            }
            return false;
        }

        public static void RemoveTrener(Trener trener)
        {
            listaTrenera.Remove(trener);
            UpisJSON(path, listaTrenera);
        }

        private static int GenerateId()
        {
            return Math.Abs(Guid.NewGuid().GetHashCode());
        }

        public static void UpisJSON(string path, List<Trener> listaTrenera)
        {
            using (StreamWriter file = File.CreateText(path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.Serialize(file, listaTrenera);
            }
        }

        public static List<Trener> UcitavanjeJSON(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                string json = r.ReadToEnd();
                JsonConverter[] converters = { new FitnesConverter() };
                var test = JsonConvert.DeserializeObject<List<Trener>>(json, new JsonSerializerSettings() { Converters = converters });
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
                if (jo["Uloga"].Value<string>() == "TRENER")
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