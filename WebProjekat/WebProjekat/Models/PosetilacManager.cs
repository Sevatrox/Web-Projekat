﻿using Newtonsoft.Json;
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
        public static string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"App_Data/posetioci.json");

        public static List<Posetilac> listaPosetilaca { get; set; } = UcitavanjeJSON(path);

        public static Posetilac FindById(int id)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            return listaPosetilaca.Find(item => item.Id == id);
        }

        public static bool FindIfExitsById(int id, string korisnickoIme)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (var item in listaPosetilaca)
            {
                if (item.KorisnickoIme == korisnickoIme)
                {
                    if(item.Id != id)
                        return true;
                }
            }
            return false;
        }

        public static bool FindByUsername(string korisnickoIme)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (var item in listaPosetilaca)
            {
                if (item.KorisnickoIme == korisnickoIme)
                    return true;
            }
            return false;
        }

        public static Posetilac FindAccount(string korisnickoIme, string lozinka)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (var item in listaPosetilaca)
            {
                if (item.KorisnickoIme == korisnickoIme && item.Lozinka == lozinka)
                    return item;
            }
            return null;
        }

        public static List<Posetilac> GetList()
        {
            listaPosetilaca = UcitavanjeJSON(path);
            return listaPosetilaca;
        }

        public static Posetilac GetPosetilac(int id)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (var item in listaPosetilaca)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        public static Posetilac AddPosetilac(Posetilac posetilac)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            posetilac.Id = GenerateId();
            posetilac.ListaTreningaPosetioca = new List<int>();
            listaPosetilaca.Add(posetilac);
            UpisJSON(path, listaPosetilaca);
            return posetilac;
        }

        public static Posetilac UpdatePosetilac(Posetilac posetilac)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (Posetilac item in listaPosetilaca)
            {
                if(item.Id == posetilac.Id)
                {
                    item.KorisnickoIme = posetilac.KorisnickoIme;
                    item.Lozinka = posetilac.Lozinka;
                    item.Ime = posetilac.Ime;
                    item.Prezime = posetilac.Prezime;
                    item.DatumRodjenja = posetilac.DatumRodjenja;
                    item.Email = posetilac.Email;
                    item.Pol = posetilac.Pol;
                    if (posetilac.ListaTreningaPosetioca != null)
                    {
                        foreach (int trening in posetilac.ListaTreningaPosetioca)
                        {
                            if (!item.ListaTreningaPosetioca.Contains(trening))
                            {
                                item.ListaTreningaPosetioca.Add(trening);
                            }
                        }
                    }
                    UpisJSON(path, listaPosetilaca);
                    return item;
                }
            }
            return null;
        }

        public static bool RemovePosetilac(Posetilac posetilac)
        {
            listaPosetilaca = UcitavanjeJSON(path);
            foreach (var item in listaPosetilaca)
            {
                if(item.Id == posetilac.Id)
                {
                    listaPosetilaca.Remove(item);
                    UpisJSON(path, listaPosetilaca);
                    return true;
                }
            }
            return false;
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