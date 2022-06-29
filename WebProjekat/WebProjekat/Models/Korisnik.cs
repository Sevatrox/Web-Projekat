using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum Uloga { POSETILAC, TRENER, VLASNIK};
    public abstract class Korisnik
    {
        private int id;
        private string korisnickoIme;
        private string lozinka;
        private string ime;
        private string prezime;
        private string pol;
        private string email;
        private string datumRodjenja;
        private Uloga uloga;

        public string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        public string Lozinka { get => lozinka; set => lozinka = value; }
        public string Ime { get => ime; set => ime = value; }
        public string Prezime { get => prezime; set => prezime = value; }
        public string Pol { get => pol; set => pol = value; }
        public string Email { get => email; set => email = value; }
        public string DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        public Uloga Uloga { get => uloga; set => uloga = value; }
        public int Id { get => id; set => id = value; }
    }
}