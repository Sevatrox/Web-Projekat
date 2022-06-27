using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProjekat.Models
{
    public enum Uloga { POSETILAC, TRENER, VLASNIK};
    public abstract class Korisnik
    {
        private string korisnickoIme;
        private string lozinka;
        private string ime;
        private string prezime;
        private char pol;
        private string email;
        private DateTime datumRodjenja;
        private Uloga uloga;

        protected string KorisnickoIme { get => korisnickoIme; set => korisnickoIme = value; }
        protected string Lozinka { get => lozinka; set => lozinka = value; }
        protected string Ime { get => ime; set => ime = value; }
        protected string Prezime { get => prezime; set => prezime = value; }
        protected char Pol { get => pol; set => pol = value; }
        protected string Email { get => email; set => email = value; }
        protected DateTime DatumRodjenja { get => datumRodjenja; set => datumRodjenja = value; }
        protected Uloga Uloga { get => uloga; set => uloga = value; }
    }
}